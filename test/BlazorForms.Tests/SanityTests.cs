using Xunit;
using Xunit.Abstractions;

namespace BlazorForms.Tests
{
    public class SanityTests : ConverterTestBase
    {
        public SanityTests(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        public void EmptyString()
        {
            TestConverter(string.Empty, string.Empty);
        }

        [Fact]
        public void SelfClosingHtml()
        {
            TestConverter("<div/>", "<div/>");
        }

        [Fact]
        public void OpenCloseHtml()
        {
            TestConverter("<div></div>", "<div></div>");
        }

        [Fact]
        public void OpenCloseAspx()
        {
            TestConverter("<asp:Label></asp:Label>", "<Label></Label>");
        }

        [Fact]
        public void AspxSelfClosing()
        {
            TestConverter("<asp:Label />", "<Label/>");
        }

        [Fact]
        public void Literal()
        {
            TestConverter("hello", "hello");
        }
    }
}
