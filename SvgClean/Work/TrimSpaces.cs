using System.Text.RegularExpressions;

namespace SvgClean.Work
{
    // Limits the number of blank spaces, probably want to run this last
    // Trim from the outer edges
    // 0 spaces between angle brackets
    // 1 space between words
    // 0 spaces between attributes and angle brackets

    internal class TrimSpaces : IWork
    {
        public string Work(string input)
        {
            var result = Regex.Replace(input, @"[\s]+", " ", RegexOptions.Compiled);
            result = Regex.Replace(result, @"(?<=>)[\s]+", "", RegexOptions.Compiled);
            result = Regex.Replace(result, @"\s+(?=\/>|>)", "", RegexOptions.Compiled);
            return result.Trim();
        }
    }
}
