using Microsoft.Extensions.Logging;
using System.IO;

namespace BlazorForms
{
    internal class WebFormsConverterOptions
    {
        public DirectoryInfo RootDirectory { get; set; }

        public bool IsNet35 { get; set; }

        public DirectoryInfo OutputDirectory { get; set; }

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
    }
}
