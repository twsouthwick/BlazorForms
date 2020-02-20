using System;
using System.Collections;
using System.Collections.Generic;

namespace BlazorForms
{
    internal class RazorLiteral : RazorNode
    {
        public RazorLiteral(string literal)
        {
            Literal = literal;
        }

        public string Literal { get; }

        public override string ToString() => Literal;
    }

    internal class RazorNodeList : RazorNode, IEnumerable<RazorNode>
    {
        private readonly IEnumerable<RazorNode> _nodes;

        public RazorNodeList(IEnumerable<RazorNode> nodes)
        {
            _nodes = nodes ?? throw new ArgumentNullException(nameof(nodes));
        }

        public IEnumerator<RazorNode> GetEnumerator() => _nodes.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    internal class HtmlNode : RazorNode
    {
        public HtmlNode(string name, IEnumerable<KeyValuePair<string, string>> attributes, RazorNodeList children)
        {
            Name = name;
            Attributes = attributes;
            Children = children;
        }

        public string Name { get; }

        public IEnumerable<KeyValuePair<string, string>> Attributes { get; }

        public RazorNodeList Children { get; }

        public override string ToString() => Name;
    }

    internal class CodeNode : RazorNode
    {
        public CodeNode(string expression)
        {
            Expression = expression;
        }

        public string Expression { get; }

        public override string ToString() => Expression;
    }

    internal struct RazorNodeListBuilder
    {
        private List<RazorNode> _nodes;

        public void Add(RazorNode node)
        {
            if (node is null)
            {
                return;
            }

            if (_nodes is null)
            {
                _nodes = new List<RazorNode>();
            }

            _nodes.Add(node);
        }

        public RazorNode Node
        {
            get
            {
                if (_nodes is null)
                {
                    return null;
                }
                else if (_nodes.Count == 1)
                {
                    return _nodes[0];
                }
                else
                {
                    return new RazorNodeList(_nodes);
                }
            }
        }
    }

    internal class RazorNode
    {
    }
}
