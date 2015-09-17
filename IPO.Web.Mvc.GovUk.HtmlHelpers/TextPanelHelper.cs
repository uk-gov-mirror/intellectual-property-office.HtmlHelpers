using System.Collections.Generic;
using System.Web.Mvc;
using IPO.Web.Mvc.GovUk.HtmlHelpers.Html;

namespace IPO.Web.Mvc.GovUk.HtmlHelpers
{
    public static class TextPanelHelper
    {
        public static MvcHtmlString GovUkTextPanel<TModel>(
            this HtmlHelper<TModel> htmlHelper, 
            string panelText)
        {
            return TextPanelHtml.GenerateTextPanel(htmlHelper, panelText);
        }

        public static MvcHtmlString GovUkTextPanel<TModel>(
            this HtmlHelper<TModel> htmlHelper,
            IEnumerable<string> panelTextList)
        {
            return TextPanelHtml.GenerateTextPanel(htmlHelper, panelTextList);
        }
    }
}
