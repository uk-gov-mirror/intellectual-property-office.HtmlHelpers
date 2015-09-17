using System.Web.Mvc;
using IPO.Web.Mvc.GovUk.HtmlHelpers.Html;

namespace IPO.Web.Mvc.GovUk.HtmlHelpers
{
    public static class LegendHelper
    {
        public static MvcHtmlString GovUkLegend<TModel>(
            this HtmlHelper<TModel> htmlHelper, 
            string legendText, 
            string hintText = null)
        {
            return LegendHtml.GenerateLegend(htmlHelper, legendText, hintText); 
        }

        public static MvcHtmlString GovUkHiddenLegend<TModel>(
            this HtmlHelper<TModel> htmlHelper, 
            string legendText)
        {
            return LegendHtml.GenerateHiddenLegend(htmlHelper, legendText); 
        }
    }
}
