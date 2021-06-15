using AspxParser;
using System.Collections.Generic;
using System.IO;

namespace BlazorForms
{
    /// <summary>
    /// Options used to convert web forms files.
    /// </summary>
    public interface IConverterOptions
    {
        /// <summary>
        /// Root directory
        /// </summary>
        string RootDirectory { get; }

        /// <summary>
        /// Gets whether the solution targets .NET 3.5
        /// </summary>
        bool IsNet35 { get; }

        /// <summary>
        /// Retrieves a collection of source files
        /// </summary>
        IEnumerable<IAspxSource> Sources { get; }

        /// <summary>
        /// Opens a writer for a resulting file
        /// </summary>
        /// <param name="name">File name</param>
        /// <returns>A text writer</returns>
        TextWriter OpenWrite(string name);
    }
}
