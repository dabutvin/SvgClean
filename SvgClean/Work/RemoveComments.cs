using System.Text.RegularExpressions;

namespace SvgClean.Work
{
    // Replace all newlines with blanks
    internal class RemoveComments : IWork
    {
        public string Work(string input) => Regex.Replace(input, @"<!--.*?-->", "", RegexOptions.Compiled);
    }
}
