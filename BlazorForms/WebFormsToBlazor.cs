using AspxParser;
using System.Diagnostics;
using System.IO;

namespace BlazorForms
{
    internal class WebFormsToBlazor : DepthFirstAspxVisitor<object>
    {
        private readonly TextWriter _writer;

        public WebFormsToBlazor(TextWriter writer)
        {
            _writer = writer;
        }

        public override object Visit(AspxNode.AspxDirective node)
        {
            return base.Visit(node);
        }

        public override object Visit(AspxNode.CloseHtmlTag node)
        {
            _writer.Write("</");
            _writer.Write(node.Name);
            _writer.Write(">");

            return null;
        }

        public override object Visit(AspxNode.CloseAspxTag node)
        {
            _writer.Write("</");
            _writer.Write(node.ControlName);
            _writer.Write(">");

            return null;
        }

        public override object Visit(AspxNode.CodeRender node)
        {
            Debug.Assert(node.Children.Count == 0);

            _writer.Write("@{");
            _writer.Write(node.Expression);
            _writer.Write("}");

            return null;
        }

        public override object Visit(AspxNode.CodeRenderEncode node)
        {
            return base.Visit(node);
        }

        public override object Visit(AspxNode.CodeRenderExpression node)
        {
            return base.Visit(node);
        }

        public override object Visit(AspxNode.DataBinding node)
        {
            return base.Visit(node);
        }

        public override object Visit(AspxNode.Literal node)
        {
            Debug.Assert(node.Children.Count == 0);
            _writer.Write(node.Text);
            return null;
        }

        public override object Visit(AspxNode.OpenAspxTag node)
        {
            WriteTag(node.ControlName, node.Attributes, false);
            return base.Visit(node);
        }

        public override object Visit(AspxNode.OpenHtmlTag node)
        {
            WriteTag(node.Name, node.Attributes, false);

            return base.Visit(node);
        }

        public override object Visit(AspxNode.Root node)
        {
            return base.Visit(node);
        }

        public override object Visit(AspxNode.SelfClosingAspxTag node)
        {
            WriteTag(node.ControlName, node.Attributes, true);
            return base.Visit(node);
        }

        public override object Visit(AspxNode.SelfClosingHtmlTag node)
        {
            WriteTag(node.Name, node.Attributes, true);
            return base.Visit(node);
        }

        private void WriteTag(string name, TagAttributes attributes, bool isSelfClosing)
        {
            _writer.Write("<");
            _writer.Write(name);

            foreach (var attribute in attributes)
            {
                _writer.Write(" ");
                _writer.Write(attribute.Key);
                _writer.Write("=\"");
                _writer.Write(attribute.Value);
                _writer.Write("\"");
            }

            if (isSelfClosing)
            {
                _writer.Write("/>");
            }
            else
            {
                _writer.Write(">");
            }
        }
    }
}
