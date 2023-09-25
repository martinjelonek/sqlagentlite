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
    }
}