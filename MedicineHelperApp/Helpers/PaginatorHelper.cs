using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text;

namespace MedicineHelperApp.Helpers
{
    public static class PaginatorHelper
    {
        public static HtmlString GeneratePaginator (this IHtmlHelper html, int[] pages)
        {
            var sb = new StringBuilder("<div>");
            foreach (var page in pages)
            {
                sb.Append($"<p>{page}</p>");
            }
            sb.Append("<div>");
            return new HtmlString(sb.ToString());
        }
    }
}
