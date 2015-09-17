using System.Web.Mvc;
using IPO.Web.Mvc.GovUk.HtmlHelpers.Framework;

namespace IPO.Web.Mvc.GovUk.HtmlHelpers
{
    public static class PageTitleHelper
    {
        public static MvcHtmlString GovUkPageTitle<TModel>(
            this HtmlHelper<TModel> htmlHelper, 
            string titleText)
        {
            return htmlHelper.CreateTag("h1", titleText, new { @class = "heading-large" });
        }
    }
}
