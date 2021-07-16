using LearningCoding.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LearningCoding.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "paging-info")]
    public class FeedbackTagHelper : TagHelper
    {
        public IUrlHelperFactory _urlHelperFactory { get; }
        public FeedbackTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            _urlHelperFactory = urlHelperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext viewContext { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string PageAction { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(viewContext);
            TagBuilder result = new TagBuilder("div");
            result.Attributes["class"] = "btn-group";
            for (int i = 0; i < PagingInfo.NumberOfPages; i++)
            {
                TagBuilder a = new TagBuilder("a");
                a.Attributes["href"] = urlHelper.Action(PageAction,
                             new { currentPage = i + 1 });
                a.Attributes["class"] = i + 1 == PagingInfo.CurrentPage ? "btn btn-dark" : "btn btn-primary";
                a.InnerHtml.Append((i + 1).ToString());
                result.InnerHtml.AppendHtml(a);
            }
            output.Content.AppendHtml(result);
        }

    }
}
