using AspxParser;
using System;
using System.Diagnostics;
using System.IO;

namespace BlazorForms
{
    internal class WebFormsToBlazor : DepthFirstAspxVisitor<object>, IDisposable
    {
        private readonly RazorTextWriter _writer;

        public WebFormsToBlazor(TextWriter writer)
        {
            _writer = new RazorTextWriter(writer);
        }

        public void Dispose()
        {
            _writer.Dispose();
        }

        public override object Visit(AspxNode.AspxDirective node)
        {
            return base.Visit(node);
        }

        public override object Visit(AspxNode.CloseHtmlTag node)
        {
            _writer.EndElement();

            return base.Visit(node);
        }

        public override object Visit(AspxNode.CloseAspxTag node)
        {
            _writer.EndElement();

            return base.Visit(node);
        }

        public override object Visit(AspxNode.CodeRender node)
        {
            Debug.Assert(node.Children.Count == 0);

            _writer.StartCodeBlock(node.Expression);

            return base.Visit(node);
        }

        public override object Visit(AspxNode.CodeRenderEncode node)
        {
            _writer.WriteCodeExpression(node.Expression);

            return base.Visit(node);
        }

        public override object Visit(AspxNode.CodeRenderExpression node)
        {
            _writer.WriteCodeExpression(node.Expression);

            return base.Visit(node);
        }

        public override object Visit(AspxNode.DataBinding node)
        {
            return base.Visit(node);
        }

        public override object Visit(AspxNode.Literal node)
        {
            _writer.WriteString(node.Text);

            return base.Visit(node);
        }

        public override object Visit(AspxNode.OpenAspxTag node)
        {
            _writer.StartElement(node.ControlName, node.Attributes);

            return base.Visit(node);
        }

        public override object Visit(AspxNode.OpenHtmlTag node)
        {
            _writer.StartElement(node.Name, node.Attributes);

            return base.Visit(node);
        }

        public override object Visit(AspxNode.Root node)
        {
            return base.Visit(node);
        }

        public override object Visit(AspxNode.SelfClosingAspxTag node)
        {
            _writer.StartElement(node.ControlName, node.Attributes);
            _writer.EndElement();

            return base.Visit(node);
        }

        public override object Visit(AspxNode.SelfClosingHtmlTag node)
        {
            _writer.StartElement(node.Name, node.Attributes);
            _writer.EndElement();

            return base.Visit(node);
        }
    }
}
