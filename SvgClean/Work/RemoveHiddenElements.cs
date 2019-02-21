using System;
using System.Linq;
using System.Text.RegularExpressions;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using SvgClean.Format;

namespace SvgClean.Work
{
    // display: none element and all the children can be removed
    // <circle> with r <= 0 "A value lower or equal to zero disables rendering of the circle."
    internal class RemoveHiddenElements : IWork
    {
        public string Work(string input)
        {
            var parser = new HtmlParser();
            var document = parser.ParseDocument(input).GetElementsByTagName("svg")[0];
            var selectors = new[]
            {
                "[display='none']",
                "[visibility='hidden']",
                "[width='0']",
                "[height='0']",
                "[r='0']",
            };

            var selector = string.Join(",", selectors);

            var element = document.QuerySelector(selector);
            while (element != null)
            {
                element.Remove();
                element = document.QuerySelector(selector);
            }

            return document.ToSvgString();
        }
    }
}
