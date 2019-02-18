using System;
using System.Linq;
using System.Text.RegularExpressions;
using NUglify;

namespace SvgClean.Work
{
    // Find all the <style>'s and run them through css minifier (NUglify)

    internal class MinifyStyles : IWork
    {
        public string Work(string input)
        {
            var regex = new Regex(@"(?<=<style>).*(?=<\/style>)", RegexOptions.Compiled);
            return regex.Replace(input, match =>
            {
                var result = Uglify.Css(match.Value);
                if (result.HasErrors) return match.Value;
                return result.Code;
            });
        }
    }
}
