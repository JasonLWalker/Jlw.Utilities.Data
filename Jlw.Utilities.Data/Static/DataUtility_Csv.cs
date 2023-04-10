
// ReSharper disable once CheckNamespace

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using MySqlX.XDevAPI.Relational;
using Newtonsoft.Json.Linq;

namespace Jlw.Utilities.Data
{
    // Based on answer provided by SchLx to the StackOverflow question found at: 
    // https://stackoverflow.com/questions/3776458/split-a-comma-separated-string-with-both-quoted-and-unquoted-strings/25120396


    public partial class DataUtility
    {

        private static Regex _rxCsvSplit = new Regex(@"(?x:(
        (?<FULL>
        (^|[,;\t\r\n])\s*
        ( (?<CODAT> (?<CO>[""'])(?<DAT>([^,;\t\r\n]|(?<!\k<CO>\s*)[,;\t\r\n])*)\k<CO>) |
          (?<CODAT> (?<DAT> [^""',;\s\r\n]* )) )
        (?=\s*([,;\t\r\n]|$))
        ) |
        (?<FULL>
        (^|[\s\t\r\n])
        ( (?<CODAT> (?<CO>[""'])(?<DAT> [^""',;\s\t\r\n]* )\k<CO>) |
        (?<CODAT> (?<DAT> [^""',;\s\t\r\n]* )) )
        (?=[,;\s\t\r\n]|$))
        ))", RegexOptions.Compiled);

        // Regex to split CSV file into individual lines.
        private static Regex _rxCsvLineSplit = new Regex(@"(?x:
            (
                (?<FULL>
                    (^|[\r\n])[\s]*
                    ( 
                        (?<CODAT> (?<CO>[""'])(?<DAT>([^\r\n]|(?<!\k<CO>\s*)[\r\n])*)\k<CO>) 
                        |
                        (?<CODAT> (?<DAT> [^\r\n]* )) 
                    )
                    (?=[\s]*([\r\n]|$))
                ) 
                |
                (?<FULL>
                    (^|[\r\n])
                    ( 
                        (?<CODAT> (?<CO>[""'])(?<DAT> [^""'\r\n]* )\k<CO>) 
                        |
                        (?<CODAT> (?<DAT> [^\r\n]* )) 
                    )
                    (?=[\r\n]|$)
                )
            )
        )", RegexOptions.Compiled);


        public static ICollection ParseCsv(string sText, bool useHeader = true, bool keepEmptyRows = false)
        {
            var aReturn = new List<Dictionary<string, string>>();
            var aHeaders = new List<string>();

            // Split CSV into individual rows
            string[] rows = _rxCsvLineSplit.Matches(sText).Cast<Match>().Select(x => x.Groups["CODAT"].Value).ToArray();

            // Parse each row
            foreach (var sRow in rows)
            {
                // Initialize row dictionary
                var aRow = new Dictionary<string, string>();

                // Is row empty?
                if (string.IsNullOrWhiteSpace(sRow))
                {
                    if (keepEmptyRows)
                    {
                        if (aHeaders.Count > 0)
                        {
                            foreach (string header in aHeaders)
                            {
                                aRow.Add(header, "");
                            }
                            aReturn.Add(aRow);
                        }
                        else
                        {
                            aReturn.Add(aRow);
                        }
                    }
                }
                else
                {
                    var data = _rxCsvSplit.Matches(sRow).Cast<Match>().Select(x => x.Groups["DAT"].Value).ToArray();
                    if (useHeader)
                    {
                        if (aHeaders.Count > 0)
                        {
                            for (int i = 0; i < aHeaders.Count; i++)
                            {
                                aRow.Add(aHeaders[i], data.Length >= i ? data[i] ?? "" : "");
                            }
                            aReturn.Add(aRow);
                        }
                        else
                        {
                            for (int i = 0; i < data.Length; i++)
                            {
                                aHeaders.Add(data[i] ?? "");
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < data.Length; i++)
                        {
                            aRow.Add(i.ToString(), data[i] ?? "");
                        }
                        aReturn.Add(aRow);
                    }
                }
            }
            return aReturn;
        }

		public static string ParseToCsv(object o, IEnumerable<CsvParserOption> opts)
		{
			// Initialize StringBuilder to hold CSV
			StringBuilder sb = new StringBuilder();
			List<string> aHeader = new List<string>();
			JToken oToken = JToken.FromObject(o);


			bool useComma = false;
			foreach (var opt in opts)
			{
				if (useComma)
					sb.Append(",");
				useComma = true;

				sb.Append($"\"{opt.Label}\"");
			}

			sb.AppendLine();

			foreach (var row in oToken)
			{
				useComma = false;
				foreach (var opt in opts)
				{
					if (useComma)
						sb.Append(",");
					useComma = true;
					sb.Append(opt.Transform(row));
				}
				sb.AppendLine();
			}


			return sb.ToString();
		}

		public static string ParseToCsv(object o)
		{
			// Initialize StringBuilder to hold CSV
			JToken oToken = JToken.FromObject(o);
			List<string> aHeaders = new List<string>();

			// Pre-parse headers
			foreach (var obj in oToken)
			{
				var headers = obj.Select(x => x.ToObject<JProperty>().Name).Except(aHeaders).ToArray();
				if (headers.Any())
				{
					aHeaders.AddRange(headers);
				}
			}

			return ParseToCsv(o, aHeaders.Select(s => new CsvParserOption() { Key = s }).ToList());
		}

	}
}
