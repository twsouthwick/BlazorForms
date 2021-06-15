using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace BlazorForms
{
    class Program
    {
        /// <summary>
        /// Main entry point
        /// </summary>
        /// <param name="input">Root directory of WebForms controls</param>
        /// <param name="isNet35">Flag to indicate whether WebForms is .NET 3.5 (otherwise assumed to be 4.x)</param>
        /// <param name="out">Directory to write output (default is current working directory).</param>
        /// <param name="verbose">Flag to indicate of output should be verbose.</param>
        static void Main(DirectoryInfo input, bool isNet35 = false, DirectoryInfo @out = null, bool verbose = false)
        {
            var services = new ServiceCollection();

            services.AddLogging(l =>
            {
                l.AddConsole();
                l.SetMinimumLevel(verbose ? LogLevel.Trace : LogLevel.Information);
            });

            services.AddSingleton<WebFormsConverter>();

            using (var provider = services.BuildServiceProvider())
            {
                var options = new WebFormsConverterOptions
                {
                    RootDirectory = input,
                    IsNet35 = isNet35,
                    OutputDirectory = @out ?? GetDefaultDirectory(input),
                };

                provider.GetRequiredService<WebFormsConverter>().Run(options);
            }
        }

        private static DirectoryInfo GetDefaultDirectory(DirectoryInfo root) => new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, root.Name));
    }
}
