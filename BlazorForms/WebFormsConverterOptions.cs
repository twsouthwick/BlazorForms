using AspxParser;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BlazorForms
{
    internal class WebFormsConverterOptions : IConverterOptions
    {
        public DirectoryInfo RootDirectory { get; set; }

        public bool IsNet35 { get; set; }

        public DirectoryInfo OutputDirectory { get; set; }

        public IEnumerable<IAspxSource> Sources
        {
            get
            {
                var files = GetFiles(RootDirectory);

                foreach (var file in files)
                {
                    yield return new FileInfoAspxSource(file);
                }
            }
        }

        string IConverterOptions.RootDirectory => RootDirectory.FullName;

        private class FileInfoAspxSource : IAspxSource
        {
            private readonly FileInfo _info;
            private string _text;

            public FileInfoAspxSource(FileInfo info)
            {
                _info = info;
            }

            public string Name => _info.Name;

            public string Text
            {
                get
                {
                    if (_text is null)
                    {
                        _text = File.ReadAllText(_info.FullName);
                    }

                    return _text;
                }
            }
        }

        private static IEnumerable<FileInfo> GetFiles(DirectoryInfo rootDirectory)
        {
            var aspx = rootDirectory.EnumerateFiles("*.aspx", SearchOption.AllDirectories);
            var ascx = rootDirectory.EnumerateFiles("*.ascx", SearchOption.AllDirectories);

            return aspx.Concat(ascx);
        }

        public void Log(ILogger logger)
        {
            if (!OutputDirectory.Exists)
            {
                OutputDirectory.Create();
            }

            logger.LogInformation("Root directory   : {RootDirectory}", RootDirectory);
            logger.LogInformation("Is .NET 3.5      : {IsNet35}", IsNet35);
            logger.LogInformation("Output directory : {OutputDirectory}", OutputDirectory);
        }

        public TextWriter OpenWrite(string name)
        {
            var newPath = Path.Combine(OutputDirectory.FullName, name);
            newPath = Path.ChangeExtension(newPath, "razor");

            var output = File.OpenWrite(newPath);

            return new StreamWriter(output);
        }
    }
}
