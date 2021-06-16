using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.UI;

namespace BlazorForms
{
    public partial class BlazorShimUserControl : BlazorWebFormsComponents.BaseStyledComponent
    {
        public virtual void RenderControl(HtmlTextWriter writer)
        {
            RenderChildren(writer);
        }

        public virtual void RenderChildren(HtmlTextWriter writer)
        {
            ChildComponents()
        }

        protected override sealed void BuildRenderTree(RenderTreeBuilder builder)
        {
            using var sw = new StringWriter();
            using var writer = new HtmlTextWriter(sw);

            RenderControl(writer);

            builder.AddMarkupContent(0, sw.ToString());
        }

        private class BlazorHtmlTextWriter : HtmlTextWriter
        {
            private readonly StringWriter _writer;

            public BlazorHtmlTextWriter()
                : this(new StringWriter())
            {

            }

            public BlazorHtmlTextWriter(StringWriter writer)
                : base(writer)
            {
                _writer = writer;
            }

            public void Write(RenderFragment fragment)
            {

            }
        }
    }
}
