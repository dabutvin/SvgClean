using System.Text.RegularExpressions;

namespace SvgClean.Work
{
    internal class RemoveMetadata : IWork
    {
        public string Work(string input) => Regex.Replace(input, @"<metadata>.*?</metadata>", "", RegexOptions.Compiled);
    }
}
