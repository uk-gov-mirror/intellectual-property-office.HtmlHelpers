using System;
using System.Web.Mvc;
using IPO.Web.Mvc.GovUk.HtmlHelpers.Framework;

namespace IPO.Web.Mvc.GovUk.HtmlHelpers
{
    public static class WarningMessageHelper
    {
        public static MvcHtmlString GovUkWarningMessage<TModel>(
            this HtmlHelper<TModel> htmlHelper,
            string message)
        {
            return String.IsNullOrWhiteSpace(message) 
                ? MvcHtmlString.Empty 
                : htmlHelper.CreateTag("div", message, new { @class = "alert alert-block" });
        }
    }
}

