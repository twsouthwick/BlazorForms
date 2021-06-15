using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BlazorForms.App")]

namespace BlazorForms
{
    using System;
    using System.IO;

    public interface IHtmlTextWriterFactory
    {
        IHtmlTextWriter Create(TextWriter writer, string tab = "   ");
    }

    public interface IHtmlTextWriter : IDisposable
    {
        TextWriter AsTextWriter();
    }
}