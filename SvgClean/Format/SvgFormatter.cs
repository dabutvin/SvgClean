using System.Linq;
using System.Text;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html;

namespace SvgClean.Format
{
    internal class SvgFormatter : IMarkupFormatter
    {
        public static readonly SvgFormatter Instance = new SvgFormatter();

        public string Text(ICharacterData text) => HtmlMarkupFormatter.Instance.Text(text);
        public string Comment(IComment comment) => HtmlMarkupFormatter.Instance.Comment(comment);
        public string Processing(IProcessingInstruction processing) => HtmlMarkupFormatter.Instance.Processing(processing);
        public string Doctype(IDocumentType doctype) => HtmlMarkupFormatter.Instance.Doctype(doctype);
        public string Attribute(IAttr attribute) => HtmlMarkupFormatter.Instance.Attribute(attribute);

        public string[] SelfClosableTags = new[]
        {
            "animate",
            "animateTransform",
            "circle",
            "ellipse",
            "feComposite",
            "feFlood",
            "feGaussianBlur",
            "feImage",
            "feMergeNode",
            "feMorphology",
            "feOffset",
            "fePointLight",
            "feTurbulence",
            "hatchpath",
            "image",
            "line",
            "linearGradient",
            "mpath",
            "path",
            "polygon",
            "polyline",
            "radialGradient",
            "rect",
            "solidcolor",
            "stop",
            "view",
        };

        public string OpenTag(IElement element, bool selfClosing)
        {
            var temp = new StringBuilder();
            temp.Append('<');
            if (!string.IsNullOrEmpty(element.Prefix))
            {
                temp.Append(element.Prefix).Append(':');
            }

            temp.Append(element.LocalName);
            foreach (var attribute in element.Attributes)
            {
                temp.Append(" ").Append(Instance.Attribute(attribute));
            }

            if (!selfClosing)
            {
                selfClosing = ShouldSelfClose(element);
            }

            temp.Append(selfClosing ? "/>" : ">");

            return temp.ToString();
        }

        public string CloseTag(IElement element, bool selfClosing)
        {
            if (!selfClosing)
            {
                selfClosing = ShouldSelfClose(element);
            }

            return HtmlMarkupFormatter.Instance.CloseTag(element, selfClosing);
        }

        private bool ShouldSelfClose(IElement element)
        {
            return SelfClosableTags.Contains(element.LocalName) && string.IsNullOrEmpty(element.InnerHtml);
        }
    }
}
