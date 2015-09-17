using System.Text;
using System.Web.Mvc;
using IPO.Web.Mvc.GovUk.HtmlHelpers.Framework;

namespace IPO.Web.Mvc.GovUk.HtmlHelpers
{
    public static class AccessibilityTextHelper
    {
        public static MvcHtmlString GovUkAccessibilityText<TModel>(
            this HtmlHelper<TModel> htmlHelper, 
            string text)
        {
            var html = new StringBuilder();

            html.Append(htmlHelper.CreateOpenTag("span", new { @class = "visuallyhidden" }));
            html.Append(text);
            html.Append(htmlHelper.CreateCloseTag("span"));
            
            return new MvcHtmlString(html.ToString());
        }
    }
}