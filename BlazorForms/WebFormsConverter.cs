using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BlazorForms
{
    internal class WebFormsConverter
    {
        private readonly ILogger<WebFormsConverter> _logger;

        public WebFormsConverter(ILogger<WebFormsConverter> logger)
        {
            _logger = logger;
        }

        public void Run(WebFormsConverterOptions options)
        {
            options.Log(_logger);

            var files = GetFiles(options.RootDirectory);
            var parser = new AspxParser.AspxParser(options.RootDirectory.FullName, !options.IsNet35);

            foreach (var file in files)
            {
                _logger.LogInformation("Converting {Source}", file.FullName);

                var fileCode = File.ReadAllText(file.FullName);

                var source = new AspxParser.AspxSource(file.Name, fileCode);
                var aspxTree = parser.Parse(source);

                var newPath = Path.Combine(options.OutputDirectory.FullName, file.Name);
                newPath = Path.ChangeExtension(newPath, "razor");

                using var output = File.OpenWrite(newPath);
                using var writer = new StreamWriter(output);
                using var converter = new WebFormsToBlazor(writer);

                var result = aspxTree.RootNode.Accept(converter);
            }
        }

        private static IEnumerable<FileInfo> GetFiles(DirectoryInfo rootDirectory)
        {
            var aspx = rootDirectory.EnumerateFiles("*.aspx", SearchOption.AllDirectories);
            var ascx = rootDirectory.EnumerateFiles("*.ascx", SearchOption.AllDirectories);

            return aspx.Concat(ascx);
        }
    }
}
