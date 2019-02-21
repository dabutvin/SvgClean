using System.Text.RegularExpressions;

namespace SvgClean.Work
{
    internal class RemoveEmptyText : IWork
    {
        // Remove extra <text>
        // Remove extra <tspan>
        // Remove extra <tref xlink:href="">
        public string Work(string input)
        {
            var result = Regex.Replace(input, @"<text>\s*</text>", "", RegexOptions.Compiled);
            result = Regex.Replace(result, @"<text\s*/>", "", RegexOptions.Compiled);
            result = Regex.Replace(result, @"<tspan>\s*</tspan>", "", RegexOptions.Compiled);
            result = Regex.Replace(result, @"<tspan\s*/>", "", RegexOptions.Compiled);
            result = Regex.Replace(result, @"<tref\s*xlink:href=""\s*"">", "", RegexOptions.Compiled);
            return result;
        }
    }
}
