using System.Text;

namespace CsvParse
{
    public static class CsvToHtml
    {
        public static string ConvertCsvToHtml(string input)
        {
            const string openTags = "<!DOCTYPE html>\n<html>\n<head>\n<meta charset=\"utf-8\">\n<title>Converted from CSV</title>\n</head>\n<body>\n<table border=\"1\">\n<tr>\n<td>";
            const string closeTags = "</td>\n</tr>\n</table>\n</body>\n</html>";

            input = input.Replace("&", "&amp;");
            input = input.Replace("<", "&lt;");
            input = input.Replace(">", "&gt;");

            input = input.Replace("\r\n", "\n");
            input = input.Replace("\r", "\n");
            input = input.Replace("\n", "\r\n");

            var stringLength = input.Length;

            var firstInCell = true;
            var skipNext = false;
            var openEscape = false;

            var output = new StringBuilder();

            output.Append(openTags);

            for (var i = 0; i < stringLength; i++)
            {
                if (skipNext)
                {
                    skipNext = false;
                    continue;
                }

                var _char = input[i];

                switch (_char)
                {
                    case '"':
                        if (i < stringLength - 1
                            && input[i + 1] == '"'
                            && !firstInCell)
                        {
                            output.Append('"');
                            skipNext = true;
                        }
                        else
                        {
                            openEscape = !openEscape;
                        }
                        firstInCell = false;
                        break;
                    case ',':
                        if (openEscape)
                        {
                            output.Append(',');
                        }
                        else
                        {
                            output.Append("</td><td>");
                            firstInCell = true;
                        }
                        break;
                    case '\n':
                        if (openEscape)
                        {
                            output.Append("<br/>");
                        }
                        else
                        {
                            output.Append("</td>\n</tr>\n<tr>\n<td>");
                            firstInCell = true;
                        }
                        break;
                    default:
                        output.Append(_char);
                        firstInCell = false;
                        break;
                }
            }

            output.Append(closeTags);

            return output.ToString();
        }
    }
}