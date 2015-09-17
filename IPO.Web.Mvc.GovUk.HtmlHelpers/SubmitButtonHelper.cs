using System.Web.Mvc;
using IPO.Web.Mvc.GovUk.HtmlHelpers.Framework;

namespace IPO.Web.Mvc.GovUk.HtmlHelpers
{
    public static class SubmitButtonHelper
    {
        public static MvcHtmlString GovUkSubmitButton<TModel>(
            this HtmlHelper<TModel> htmlHelper, 
            string buttonText = "Continue",
            string buttonName="Continue")
        {
            return htmlHelper.CreateTag("button", buttonText, new { @class = "button", @type = "submit", @name = buttonName });
        }
    }
}