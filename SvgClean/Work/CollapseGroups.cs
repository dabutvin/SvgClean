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
            var document = parser.ParseDocument(result);
            var svg = document.GetElementsByTagName("svg")[0];

            foreach (var child in svg.Children)
            {
                ProcessElement(child);
            }

            return svg.ToSvgString();
        }

        private void ProcessElement(IElement element)
        {
            if (element.TagName == "g" && element.ChildElementCount == 1)
            {
                // this is a group of one item, let's apply attributes to the child
                foreach (var attribute in element.Attributes)
                {
                    if (!element.FirstElementChild.HasAttribute(attribute.Name))
                    {
                        element.FirstElementChild.SetAttribute(attribute.Name, attribute.Value);
                    }
                }

                element.OuterHtml = element.FirstElementChild.ToSvgString();
                //ProcessElement(element);
            }
            else
            {
                foreach (var child in element.Children)
                {
                    ProcessElement(child);
                }
            }
        }
    }
}
