using Microsoft.Extensions.Logging;

namespace BlazorForms
{
    /// <summary>
    /// Converts web forms
    /// </summary>
    public class WebFormsConverter
    {
        private readonly ILogger<WebFormsConverter> _logger;

        /// <summary>
        /// Creates a converter
        /// </summary>
        /// <param name="logger"></param>
        public WebFormsConverter(ILogger<WebFormsConverter> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Converts a project
        /// </summary>
        /// <param name="options"></param>
        public void Run(IConverterOptions options)
        {
            var parser = new AspxParser.AspxParser(options.RootDirectory, !options.IsNet35);

            foreach (var file in options.Sources)
            {
                _logger.LogInformation("Converting {Source}", file.Name);

                var aspxTree = parser.Parse(file);

                using var writer = options.OpenWrite(file.Name);
                using var converter = new WebFormsToBlazor(writer);

                var result = aspxTree.RootNode.Accept(converter);
            }
        }
    }
}
