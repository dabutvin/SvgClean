using System;
using System.Linq;
using System.Text.RegularExpressions;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using SvgClean.Format;

namespace SvgClean.Work
{
    // if a `<g>` only contains one element then combine them
    // if a `<g>` is empty then remove it

    internal class CollapseGroups : IWork
    {
        public string Work(string input)
        {
            var result = Regex.Replace(input, @"<g>\s*<\/g>", "", RegexOptions.Compiled);

            var parser = new HtmlParser();
            var document = parser.ParseDocument(result).GetElementsByTagName("svg")[0];

            var group = document.QuerySelectorAll("g").FirstOrDefault(x => x.ChildElementCount == 1 || x.Attributes.Length == 0);
            while (group != null)
            {
                foreach (var attribute in group.Attributes)
                {
                    group.FirstElementChild.SetAttribute(attribute.Name, attribute.Value);
                }
                group.Replace(group.Children.ToArray());
                group = document.QuerySelectorAll("g").FirstOrDefault(x => x.ChildElementCount == 1 || x.Attributes.Length == 0);
            }

            return document.ToSvgString();
        }
    }
}
