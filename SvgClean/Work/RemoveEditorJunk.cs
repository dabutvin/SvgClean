using System.Text.RegularExpressions;

namespace SvgClean.Work
{
    internal class RemoveEditorJunk : IWork
    {
        // Remove extra <sodipod:junk />
        // Remove extra <element sodipodi:junk="value">
        public string Work(string input)
        {
            var result = Regex.Replace(input, @"(?:<|<\/)(?:sodipodi|inkscape):.+?>?.*?(?:<\/(?:sodipodi|inkscape):.+?>|/>)\s*", "", RegexOptions.Compiled);
            result = Regex.Replace(result, @"\s*(?:sodipodi|inkscape):[^""]+?="".*?""\s*", "", RegexOptions.Compiled);
            return result;
        }
    }
}
