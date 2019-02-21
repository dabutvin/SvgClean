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
    internal class RemoveHiddenElements : IWork
    {
        public string Work(string input)
        {
            var parser = new HtmlParser();
            var document = parser.ParseDocument(input).GetElementsByTagName("svg")[0];

            var element = document.QuerySelectorAll("[display='none']").FirstOrDefault();
            while (element != null)
            {
                element.Remove();
                element = document.QuerySelectorAll("[display='none']").FirstOrDefault();
            }

            return document.ToSvgString();
        }
    }
}
