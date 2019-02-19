using AngleSharp;
using AngleSharp.Dom;

namespace SvgClean.Format
{
    internal static class FormatExtensions
    {
        static SvgFormatter Formatter = new SvgFormatter();
        public static string ToSvgString(this IElement element)
        {
            return element.ToHtml(Formatter);
        }
    }
}
