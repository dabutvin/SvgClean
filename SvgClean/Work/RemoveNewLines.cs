using System.Text.RegularExpressions;

namespace SvgClean.Work
{
    // Replace all newlines with spaces
    public class RemoveNewLines : IWork
    {
        public string Work(string input) => input.Replace("\r\n", " ").Replace("\n", " ");
    }
}
