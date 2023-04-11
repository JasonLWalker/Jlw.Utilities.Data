using System;

namespace Jlw.Utilities.Data;

public class CsvParserOption
{
	private string _label;
	private Type _parseType = typeof(string);
	private ParserTransform _transform;

	// Declare a delegate for transformations.
	public delegate string ParserTransform(object rowData);

	public string Key { get; set; }

	public string Label
	{
		get => _label ?? Key;
		set => _label = value;
	}

	public Type ParseType
	{
		get => _parseType ?? typeof(string);
		set => _parseType = value;
	}

	public ParserTransform Transform
	{
		get => _transform ?? DefaultTransform;
		set => _transform = value;
	}

	public string DefaultTransform(object rowData)
	{
		if (ParseType == null) return "";

		switch (Type.GetTypeCode(ParseType))
		{
			case TypeCode.Boolean:
				return DataUtility.ParseBool(rowData, Key).ToString();
			case TypeCode.Int16:
			case TypeCode.Int32:
			case TypeCode.Int64:
				return DataUtility.ParseInt64(rowData, Key).ToString();
			case TypeCode.Single:
			case TypeCode.Double:
				return DataUtility.ParseDouble(rowData, Key).ToString();
			case TypeCode.DateTime:
				return DataUtility.ParseDateTime(rowData, Key).ToString();
			case TypeCode.Empty:
			case TypeCode.DBNull:
				return "";
		}

		string s = DataUtility.ParseString(rowData, Key);

		return $"\"{(s??"").Replace(@"\", @"\\").Replace("\"", "\"\"")}\"";
	}
}