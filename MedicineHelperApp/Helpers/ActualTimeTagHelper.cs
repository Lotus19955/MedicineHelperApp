using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text;

namespace MedicineHelperApp.Helpers
{
    public class TimeTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagMode = TagMode.StartTagAndEndTag;
            output.TagName = "div";
            output.Content.SetContent($"Actual server date: {DateTime.Now:R}");

        }
    }
}
