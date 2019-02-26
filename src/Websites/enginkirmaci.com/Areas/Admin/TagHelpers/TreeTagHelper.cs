using Common.Utilities;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Models;

namespace Admin.TagHelpers
{
    public class TreeTagHelper : TagHelper
    {
        public string SlugUrl { get; set; }
        public string UlClass { get; set; }
        public IEnumerable<Page> Pages { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await AsyncHelper.RunAsync(() =>
             {
                 var builder = new StringBuilder();

                 GenerateTree(builder, SlugUrl, Pages, UlClass);

                 output.TagName = "div";
                 output.Content.SetHtmlContent(builder.ToString());

                 return Task.CompletedTask;
             });
        }

        private void GenerateTree(StringBuilder builder, string slugUrl, IEnumerable<Page> pages, string ulClass)
        {
            builder.Append($"<ul class=\"{(!string.IsNullOrWhiteSpace(ulClass) ? ulClass : string.Empty)}\">");

            foreach (var page in pages)
            {
                var isActive = string.IsNullOrWhiteSpace(slugUrl) || string.IsNullOrWhiteSpace(page.SlugUrl) ? false : slugUrl.Equals(page.SlugUrl);
                var hasChildPage = page.Childs.Any();

                builder.Append("<li>");

                builder.Append($"<a href=\"/Admin/Page/?page={page.SlugUrl}\" class=\"{(isActive ? "active" : string.Empty)}\">{page.Title}</a>");

                if (hasChildPage)
                    GenerateTree(builder, slugUrl, page.Childs, string.Empty);

                builder.Append("</li>");
            }

            builder.Append("</ul>");
        }
    }
}