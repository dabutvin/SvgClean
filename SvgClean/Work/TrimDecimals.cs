using System.Text.RegularExpressions;

namespace SvgClean.Work
{
    // Limits the number of digits in decimals
    internal class TrimDecimals : IWork
    {
        public string Work(string input) => Regex.Replace(input, @"(?<=\.\d\d\d)\d*", "", RegexOptions.Compiled);
    }
}
