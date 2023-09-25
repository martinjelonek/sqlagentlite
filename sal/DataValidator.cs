using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace SAL
{
    public static class DataValidator
    {
        public static bool IsValidTimeFormat(string input)
        {
            Regex timePattern = new(@"^([01]?[0-9]|2[0-3]):[0-5][0-9]$");
            return timePattern.IsMatch(input);
        }

        public static bool IsValidDateFormat(string input)
        {
            Regex datePattern = new(@"^(\d{4})-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])$");
            return datePattern.IsMatch(input);
        }
    }
}