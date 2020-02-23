using AspxParser;
using System;
using System.IO;
using System.Xml;

namespace BlazorForms
{
    internal class RazorTextWriter : IDisposable
    {
        private readonly HtmlTextWriter _writer;

        public RazorTextWriter(TextWriter writer)
        {
            _writer = new HtmlTextWriter(writer);
        }

        public void Dispose() => _writer.Dispose();

        public void StartElement(string name, TagAttributes attributes)
        {
            _writer.RenderBeginTag(name);

            foreach (var attribute in attributes)
            {
                _writer.WriteAttribute(attribute.Key, attribute.Value);
            }
        }

        public void EndElement()
        {
            _writer.RenderEndTag();
        }

        public void WriteString(string str)
        {
            _writer.Write(str);
        }

        public void StartCodeBlock(string code)
        {
            if (!code.AsSpan().TrimStart().StartsWith("}", StringComparison.Ordinal))
            {
                _writer.Write("@ ");
            }

            _writer.Write(code);
        }

        public void EndCodeBlock()
        {

        }

        public void WriteCode(string expression)
        {
            _writer.Write(expression);
        }

        public void WriteCodeExpression(string input)
        {
            _writer.Write("@");
            _writer.Write(input);
        }
    }
}
