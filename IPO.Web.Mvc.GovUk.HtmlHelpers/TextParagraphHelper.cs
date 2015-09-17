using System.Web.Mvc;
using IPO.Web.Mvc.GovUk.HtmlHelpers.Framework;

namespace IPO.Web.Mvc.GovUk.HtmlHelpers
{
    public static class TextParagraphHelper
    {
        public static MvcHtmlString GovUkParagraphText<TModel>(
            this HtmlHelper<TModel> htmlHelper, 
            string paragraphText)
        {
            return htmlHelper.CreateTag("p", paragraphText, new { @class = "text" });
        }
    }
}

