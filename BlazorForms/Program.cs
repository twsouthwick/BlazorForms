using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BlazorForms
{
    class Program
    {
        static void Main(string[] args)
        {
            var rootDirectory = args[0];
            var files = GetFiles(rootDirectory);
            var parser = new AspxParser.AspxParser(rootDirectory);

            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file);
                var fileCode = File.ReadAllText(file);

                var source = new AspxParser.AspxSource(fileName, fileCode);
                var aspxTree = parser.Parse(source);

                var converter = new WebFormsToBlazor(Console.Out);
                var result = aspxTree.RootNode.Accept(converter);
            }
        }

        private static IEnumerable<string> GetFiles(string rootDirectory)
        {
            var aspx = Directory.EnumerateFiles(rootDirectory, "*.aspx", SearchOption.AllDirectories);
            var ascx = Directory.EnumerateFiles(rootDirectory, "*.ascx", SearchOption.AllDirectories);

            return aspx.Concat(ascx);
        }
    }
}
