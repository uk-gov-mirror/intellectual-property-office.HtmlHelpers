using System.Collections.Generic;
using System.Web.Mvc;
using IPO.Web.Mvc.GovUk.HtmlHelpers.Html;

namespace IPO.Web.Mvc.GovUk.HtmlHelpers
{
    public static class TextPanelForLabelHelper
    {
        public static MvcHtmlString GovUkTextPanelForLabel<TModel>(
            this HtmlHelper<TModel> htmlHelper,
            string panelText,
            string labelName)
        {
            return TextPanelHtml.GenerateTextPanelForLabel(htmlHelper, panelText, labelName);
        }

        public static MvcHtmlString GovUkTextPanelForLabel<TModel>(
            this HtmlHelper<TModel> htmlHelper,
            IEnumerable<string> panelTextList,
            string labelName)
        {
            return TextPanelHtml.GenerateTextPanelForLabel(htmlHelper, panelTextList, labelName);
        }
    }
}
