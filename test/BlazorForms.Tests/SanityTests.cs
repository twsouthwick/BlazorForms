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
            TestConverter("<div/>", "<div />");
        }

        [Fact]
        public void OpenCloseHtml()
        {
            TestConverter("<div>content</div>", "<div>content</div>");
        }

        [Fact]
        public void OpenCloseAspx()
        {
            TestConverter("<asp:Label>content</asp:Label>", "<Label>content</Label>");
        }

        [Fact]
        public void SimpleCodeExpression()
        {
            TestConverter("<%=someVariable%>", "@someVariable");
        }

        [Fact]
        public void SimpleCodeBlock()
        {
            TestConverter("<% foreach(var i in other) { %> <div><%=i%></div> <% } %>", "@ foreach(var i in other) {<div>@i</div> }");
        }

        [Fact]
        public void AspxSelfClosing()
        {
            TestConverter("<asp:Label />", "<Label />");
        }
    }
}
