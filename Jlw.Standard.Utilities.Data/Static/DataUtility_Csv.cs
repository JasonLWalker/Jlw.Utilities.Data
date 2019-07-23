
// ReSharper disable once CheckNamespace

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Jlw.Standard.Utilities.Data
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

        public static ICollection ParseCsv(string sText)
        {
            var oReturn = new List<Dictionary<string, object>>();
            var oHeaders = new List<string>();

            var data = _rxCsvSplit.Matches(sText).Cast<Match>().Select(x => x.Groups["DAT"].Value).ToArray();

            return oReturn;
        }


    }
}
