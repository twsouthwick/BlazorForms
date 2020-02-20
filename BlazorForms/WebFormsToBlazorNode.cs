using AspxParser;
using System.Diagnostics;
using System.Linq;

namespace BlazorForms
{
    internal class WebFormsToBlazorNode : DepthFirstAspxVisitor<RazorNode>
    {
        public override RazorNode Visit(AspxNode.AspxDirective node)
        {
            return base.Visit(node);
        }

        public override RazorNode Visit(AspxNode.CloseHtmlTag node)
        {
            return base.Visit(node);
        }

        public override RazorNode Visit(AspxNode.CloseAspxTag node)
        {
            return base.Visit(node);
        }

        public override RazorNode Visit(AspxNode.CodeRender node)
        {
            Debug.Assert(node.Children.Count == 0);
            return new CodeNode(node.Expression);
        }

        public override RazorNode Visit(AspxNode.CodeRenderEncode node)
        {
            return base.Visit(node);
        }

        public override RazorNode Visit(AspxNode.CodeRenderExpression node)
        {
            return base.Visit(node);
        }

        public override RazorNode Visit(AspxNode.DataBinding node)
        {
            return base.Visit(node);
        }

        public override RazorNode Visit(AspxNode.Literal node)
        {
            Debug.Assert(node.Children.Count == 0);
            return new RazorLiteral(node.Text);
        }

        public override RazorNode Visit(AspxNode.OpenAspxTag node)
        {
            return base.Visit(node);
        }

        public override RazorNode Visit(AspxNode.OpenHtmlTag node)
        {
            var children = base.Visit(node);

            if (children is RazorNodeList list)
            {
                return new HtmlNode(node.Name, node.Attributes, list);
            }
            else if (children is null)
            {
                return new HtmlNode(node.Name, node.Attributes, new RazorNodeList(Enumerable.Empty<RazorNode>()));
            }
            else
            {
                return new HtmlNode(node.Name, node.Attributes, new RazorNodeList(new[] { children }));
            }
        }

        public override RazorNode Visit(AspxNode.Root node)
        {
            return base.Visit(node);
        }

        public override RazorNode Visit(AspxNode.SelfClosingAspxTag node)
        {
            return base.Visit(node);
        }

        public override RazorNode Visit(AspxNode.SelfClosingHtmlTag node)
        {
            return base.Visit(node);
        }

        protected override RazorNode VisitChildren(AspxNode node)
        {
            var nodeList = new RazorNodeListBuilder();

            foreach (var child in node.Children)
            {
                nodeList.Add(child.Accept(this));
            }

            return nodeList.Node;
        }
    }
}
