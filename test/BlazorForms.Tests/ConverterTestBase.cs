using AspxParser;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace BlazorForms.Tests
{
    public abstract class ConverterTestBase
    {
        protected ConverterTestBase(ITestOutputHelper output)
        {
            Output = output;
        }

        public ITestOutputHelper Output { get; }

        protected void TestConverter(string input, string expected)
        {
            var converter = new WebFormsConverter(Substitute.For<ILogger<WebFormsConverter>>());
            var options = new TestOptions(input);

            converter.Run(options);

            var result = options.GetResult();

            Assert.Equal(expected, result);
        }

        private class TestOptions : IConverterOptions
        {
            private readonly string _text;
            private readonly string _name;
            private StringBuilder _builder;

            public TestOptions(string text)
            {
                _text = text;
                _name = Guid.NewGuid().ToString();
                RootDirectory = Path.GetTempPath();
            }

            public string RootDirectory { get; }

            public bool IsNet35 => false;

            public IEnumerable<IAspxSource> Sources
            {
                get
                {
                    yield return new AspxSource(_name, _text);
                }
            }

            public string GetResult() => _builder?.ToString();

            public TextWriter OpenWrite(string name)
            {
                if (_builder != null)
                {
                    throw new InvalidOperationException();
                }

                if (name != _name)
                {
                    throw new InvalidOperationException();
                }

                _builder = new StringBuilder();

                return new StringWriter(_builder);
            }
        }
    }
}
