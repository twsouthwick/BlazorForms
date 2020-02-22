using AspxParser;
using System;
using System.IO;
using System.Xml;

namespace BlazorForms
{
    internal class RazorTextWriter : IDisposable
    {
        private readonly XmlWriter _xmlWriter;

        public RazorTextWriter(TextWriter writer)
        {
            _xmlWriter = XmlWriter.Create(writer, new XmlWriterSettings
            {
                OmitXmlDeclaration = true
            });
        }

        public void Dispose() => _xmlWriter.Dispose();

        public void StartElement(string name, TagAttributes attributes)
        {
            _xmlWriter.WriteStartElement(name);

            foreach (var attribute in attributes)
            {
                _xmlWriter.WriteAttributeString(attribute.Key, attribute.Value);
            }
        }

        public void EndElement()
        {
            _xmlWriter.WriteEndElement();
        }

        public void WriteString(string str)
        {
            _xmlWriter.WriteRaw(str);
        }

        public void StartCodeBlock(string code)
        {
            if (!code.AsSpan().TrimStart().StartsWith("}", StringComparison.Ordinal))
            {
                _xmlWriter.WriteRaw("@ ");
            }

            _xmlWriter.WriteRaw(code);
        }

        public void EndCodeBlock()
        {

        }

        public void WriteCode(string expression)
        {
            _xmlWriter.WriteRaw(expression);
        }

        public void WriteCodeExpression(string input)
        {
            _xmlWriter.WriteRaw("@");
            _xmlWriter.WriteRaw(input);
        }
    }
}
