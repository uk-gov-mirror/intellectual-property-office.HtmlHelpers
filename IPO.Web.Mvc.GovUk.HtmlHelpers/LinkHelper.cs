using System.Web.Mvc;
using IPO.Web.Mvc.GovUk.HtmlHelpers.Html;

namespace IPO.Web.Mvc.GovUk.HtmlHelpers
{
    public static class LinkHelper
    {
        public static MvcHtmlString GovUkLink<TModel>(
            this HtmlHelper<TModel> htmlHelper,
            string linkText,
            string actionName,
            string controllerName,
            object routeValues = null,
            object htmlAttributes = null)
        {
            return LinkHtml.GenerateLink(htmlHelper, linkText, actionName, controllerName, routeValues, htmlAttributes);
        }

        public static MvcHtmlString GovUkAccessibleLink<TModel>(
            this HtmlHelper<TModel> htmlHelper,
            string linkText,
            string accessibleText,
            string actionName,
            string controllerName,
            object routeValues = null,
            object htmlAttributes = null)
        {
            return LinkHtml.GenerateAccessibleLink(htmlHelper, linkText, accessibleText, actionName, controllerName, routeValues, htmlAttributes);
        }
    }
}
