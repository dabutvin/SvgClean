using System;
using System.Linq;
using System.Text.RegularExpressions;
using NUglify;

namespace SvgClean.Work
{
    // if a `<g>` only contains one element then combine them
    // if a `<g>` is empty then remove it

    internal class CollapseGroups : IWork
    {
        public string Work(string input)
        {
            var result = Regex.Replace(input, @"(?<=<style>).*(?=<\/style>)", "", RegexOptions.Compiled);
            return result;
        }
    }
}
