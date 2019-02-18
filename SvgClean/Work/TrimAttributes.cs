using System.Text.RegularExpressions;

namespace SvgClean.Work
{
    // Remove attributes with no values
    // Trim from the outer edges of attribute values
    internal class TrimAttributes : IWork
    {
        public string Work(string input)
        {
            var result = Regex.Replace(input, @"\w+=""\s*""", "", RegexOptions.Compiled);
            result = Regex.Replace(result, @"(?<=\w="")\s+", "", RegexOptions.Compiled);
            result = Regex.Replace(result, @"\s+(?="")", "", RegexOptions.Compiled);
            return result.Trim();
        }
    }
}
