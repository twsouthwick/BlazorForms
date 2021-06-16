using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlazorForms
{
    public partial class BlazorShimUserControl : System.Web.UI.WebControls.WebControl
    {
    }
    internal class ShimHtmlTextWriter : IHtmlTextWriter
    {
        private readonly HtmlTextWriter _writer;

        public ShimHtmlTextWriter(HtmlTextWriter writer)
        {
            _writer = writer;
        }

        public Encoding Encoding => _writer.Encoding;

        public int Indent
        {
            get => _writer.Indent;
            set => _writer.Indent;
        }
        public TextWriter InnerWriter { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string NewLine { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void AddAttribute(HtmlTextWriterAttribute key, string value)
        {
            throw new NotImplementedException();
        }

        public void AddAttribute(HtmlTextWriterAttribute key, string value, bool fEncode)
        {
            throw new NotImplementedException();
        }

        public void AddAttribute(string name, string value)
        {
            throw new NotImplementedException();
        }

        public void AddAttribute(string name, string value, bool fEndode)
        {
            throw new NotImplementedException();
        }

        public void AddStyleAttribute(HtmlTextWriterStyle key, string value)
        {
            throw new NotImplementedException();
        }

        public void AddStyleAttribute(string name, string value)
        {
            throw new NotImplementedException();
        }

        public void BeginRender()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void EndRender()
        {
            throw new NotImplementedException();
        }

        public void EnterStyle(Style style)
        {
            throw new NotImplementedException();
        }

        public void EnterStyle(Style style, HtmlTextWriterTag tag)
        {
            throw new NotImplementedException();
        }

        public void ExitStyle(Style style)
        {
            throw new NotImplementedException();
        }

        public void ExitStyle(Style style, HtmlTextWriterTag tag)
        {
            throw new NotImplementedException();
        }

        public void Flush()
        {
            throw new NotImplementedException();
        }

        public bool IsValidFormAttribute(string attribute)
        {
            throw new NotImplementedException();
        }

        public void RenderBeginTag(HtmlTextWriterTag tagKey)
        {
            throw new NotImplementedException();
        }

        public void RenderBeginTag(string tagName)
        {
            throw new NotImplementedException();
        }

        public void RenderEndTag()
        {
            throw new NotImplementedException();
        }

        public void Write(bool value)
        {
            throw new NotImplementedException();
        }

        public void Write(char value)
        {
            throw new NotImplementedException();
        }

        public void Write(char[] buffer)
        {
            throw new NotImplementedException();
        }

        public void Write(char[] buffer, int index, int count)
        {
            throw new NotImplementedException();
        }

        public void Write(double value)
        {
            throw new NotImplementedException();
        }

        public void Write(float value)
        {
            throw new NotImplementedException();
        }

        public void Write(int value)
        {
            throw new NotImplementedException();
        }

        public void Write(long value)
        {
            throw new NotImplementedException();
        }

        public void Write(object value)
        {
            throw new NotImplementedException();
        }

        public void Write(string s)
        {
            throw new NotImplementedException();
        }

        public void Write(string format, object arg0)
        {
            throw new NotImplementedException();
        }

        public void Write(string format, object arg0, object arg1)
        {
            throw new NotImplementedException();
        }

        public void Write(string format, params object[] arg)
        {
            throw new NotImplementedException();
        }

        public void WriteAttribute(string name, string value)
        {
            throw new NotImplementedException();
        }

        public void WriteAttribute(string name, string value, bool fEncode)
        {
            throw new NotImplementedException();
        }

        public void WriteBeginTag(string tagName)
        {
            throw new NotImplementedException();
        }

        public void WriteBreak()
        {
            throw new NotImplementedException();
        }

        public void WriteEncodedText(string text)
        {
            throw new NotImplementedException();
        }

        public void WriteEncodedUrl(string url)
        {
            throw new NotImplementedException();
        }

        public void WriteEncodedUrlParameter(string urlText)
        {
            throw new NotImplementedException();
        }

        public void WriteEndTag(string tagName)
        {
            throw new NotImplementedException();
        }

        public void WriteFullBeginTag(string tagName)
        {
            throw new NotImplementedException();
        }

        public void WriteLine()
        {
            throw new NotImplementedException();
        }

        public void WriteLine(bool value)
        {
            throw new NotImplementedException();
        }

        public void WriteLine(char value)
        {
            throw new NotImplementedException();
        }

        public void WriteLine(char[] buffer)
        {
            throw new NotImplementedException();
        }

        public void WriteLine(char[] buffer, int index, int count)
        {
            throw new NotImplementedException();
        }

        public void WriteLine(double value)
        {
            throw new NotImplementedException();
        }

        public void WriteLine(float value)
        {
            throw new NotImplementedException();
        }

        public void WriteLine(int value)
        {
            throw new NotImplementedException();
        }

        public void WriteLine(long value)
        {
            throw new NotImplementedException();
        }

        public void WriteLine(object value)
        {
            throw new NotImplementedException();
        }

        public void WriteLine(string s)
        {
            throw new NotImplementedException();
        }

        public void WriteLine(string format, object arg0)
        {
            throw new NotImplementedException();
        }

        public void WriteLine(string format, object arg0, object arg1)
        {
            throw new NotImplementedException();
        }

        public void WriteLine(string format, params object[] arg)
        {
            throw new NotImplementedException();
        }

        public void WriteLine(uint value)
        {
            throw new NotImplementedException();
        }

        public void WriteLineNoTabs(string s)
        {
            throw new NotImplementedException();
        }

        public void WriteStyleAttribute(string name, string value)
        {
            throw new NotImplementedException();
        }

        public void WriteStyleAttribute(string name, string value, bool fEncode)
        {
            throw new NotImplementedException();
        }
    }
}
