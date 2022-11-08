using System.Text;
using MedicineHelper.Core.Abstractions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSampleMvcApp.Helpers;

[HtmlTargetElement("serverSummary")]
public class ServerSummaryTagHelper : TagHelper
{
    private readonly IVisitService _visitsService;
    public bool Visible { get; set; }
    public StyleInformation? Style { get; set; }

    public ServerSummaryTagHelper(IVisitService visitsService)
    {
        _visitsService = visitsService;
    }
    
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = "div";

        var target = await output.GetChildContentAsync();

        var sb = new StringBuilder("<h3>Server information:</h3>");
        sb.Append(target.GetContent());

        var style = "";

        if (Visible)
        {
            //var randomSourceName = (await _visitsService())
            //    .FirstOrDefault()?
            //    .Name;
            //sb.Append($"<h6>Random source name: {randomSourceName}</h6>");
        }

        if (Style != null)
        {
            if (Style.Color != null)
            {
                style = $"color: {Style.Color};";
            }
            if (Style.BackgroundColor != null)
            {
                style = $"{style}background-color: {Style.BackgroundColor};";
            }
        }

        output.Attributes.SetAttribute("style", style);

        output.Content.SetHtmlContent(sb.ToString());
    }
}

public class StyleInformation
{
    public string? Color { get; set; }
    public string? BackgroundColor { get; set; }
}