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
            TestConverter("<br/>", "<br />");
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
            var webforms = @"<% foreach(var i in other) { %>
<div>
    <%=i%>
</div>
}";
            var razor = @"@ foreach(var i in other) {
<div>
    @i
</div>
}";

            TestConverter(webforms, razor);
        }

        [Fact]
        public void AspxSelfClosing()
        {
            TestConverter("<asp:Label />", "<Label />");
        }
    }
}
