//------------------------------------------------------------------------------
// <copyright file="HtmlTextWriter.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System.IO;
using System.Text;
using System.Web.UI.WebControls;

namespace System.Web.UI
{
    public interface IHtmlTextWriter
    {
        Encoding Encoding { get; }
        int Indent { get; set; }
        TextWriter InnerWriter { get; set; }
        string NewLine { get; set; }

        void AddAttribute(HtmlTextWriterAttribute key, string value);
        void AddAttribute(HtmlTextWriterAttribute key, string value, bool fEncode);
        void AddAttribute(string name, string value);
        void AddAttribute(string name, string value, bool fEndode);
        void AddStyleAttribute(HtmlTextWriterStyle key, string value);
        void AddStyleAttribute(string name, string value);
        void BeginRender();
        void Close();
        void EndRender();
        void EnterStyle(Style style);
        void EnterStyle(Style style, HtmlTextWriterTag tag);
        void ExitStyle(Style style);
        void ExitStyle(Style style, HtmlTextWriterTag tag);
        void Flush();
        bool IsValidFormAttribute(string attribute);
        void RenderBeginTag(HtmlTextWriterTag tagKey);
        void RenderBeginTag(string tagName);
        void RenderEndTag();
        void Write(bool value);
        void Write(char value);
        void Write(char[] buffer);
        void Write(char[] buffer, int index, int count);
        void Write(double value);
        void Write(float value);
        void Write(int value);
        void Write(long value);
        void Write(object value);
        void Write(string s);
        void Write(string format, object arg0);
        void Write(string format, object arg0, object arg1);
        void Write(string format, params object[] arg);
        void WriteAttribute(string name, string value);
        void WriteAttribute(string name, string value, bool fEncode);
        void WriteBeginTag(string tagName);
        void WriteBreak();
        void WriteEncodedText(string text);
        void WriteEncodedUrl(string url);
        void WriteEncodedUrlParameter(string urlText);
        void WriteEndTag(string tagName);
        void WriteFullBeginTag(string tagName);
        void WriteLine();
        void WriteLine(bool value);
        void WriteLine(char value);
        void WriteLine(char[] buffer);
        void WriteLine(char[] buffer, int index, int count);
        void WriteLine(double value);
        void WriteLine(float value);
        void WriteLine(int value);
        void WriteLine(long value);
        void WriteLine(object value);
        void WriteLine(string s);
        void WriteLine(string format, object arg0);
        void WriteLine(string format, object arg0, object arg1);
        void WriteLine(string format, params object[] arg);
        void WriteLine(uint value);
        void WriteLineNoTabs(string s);
        void WriteStyleAttribute(string name, string value);
        void WriteStyleAttribute(string name, string value, bool fEncode);
    }
}