using System.Text;
using System.Web;
using System.Web.Mvc;
using IPO.Web.Mvc.GovUk.HtmlHelpers.Framework;

namespace IPO.Web.Mvc.GovUk.HtmlHelpers.Html
{
    public class LinkHtml
    {
        internal static MvcHtmlString GenerateLink<TModel>(
            HtmlHelper<TModel> htmlHelper,
            string linkText,
            string actionName,
            string controllerName,
            object routeValues,
            object htmlAttributes)
        {
            return MvcHtmlString.Create(GenerateLinkHtml(htmlHelper, linkText, null, actionName, controllerName, routeValues, htmlAttributes));
        }

        internal static MvcHtmlString GenerateAccessibleLink<TModel>(
            HtmlHelper<TModel> htmlHelper,
            string linkText,
            string accessibleText,
            string actionName,
            string controllerName,
            object routeValues,
            object htmlAttributes)
        {
            return MvcHtmlString.Create(GenerateLinkHtml(htmlHelper, linkText, accessibleText, actionName, controllerName, routeValues, htmlAttributes));
        }

        private static string GenerateLinkHtml<TModel>(
            HtmlHelper<TModel> htmlHelper,
            string linkText,
            string accessibleText,
            string actionName,
            string controllerName,
            object routeValues,
            object htmlAttributes)
        {
            var html = new StringBuilder();
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var linkAttribute = new { href = urlHelper.Action(actionName, controllerName, routeValues) };

            html.Append(htmlHelper.CreateOpenTag("a", htmlAttributes, linkAttribute));

            html.Append(linkText);

            if (!string.IsNullOrEmpty(accessibleText))
            {
                html.Append(htmlHelper.GovUkAccessibilityText(accessibleText));
            }

            html.Append(htmlHelper.CreateCloseTag("a"));

            return html.ToString();
        }
    }
}
