using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BlazorForms
{
    internal class HttpUtility
    {
        internal static string UrlEncodeNonAscii(string v, Encoding uTF8)
        {
            return v;
        }

        internal static void HtmlAttributeEncode(string s, TextWriter writer)
        {
            throw new NotImplementedException();
        }

        internal static string HtmlAttributeEncode(string value)
        {
            return value;
        }

        internal static void HtmlEncode(string v, HtmlTextWriter htmlTextWriter)
        {
            throw new NotImplementedException();
        }
    }
}
