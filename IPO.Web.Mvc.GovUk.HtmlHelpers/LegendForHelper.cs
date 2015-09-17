using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using IPO.Web.Mvc.GovUk.HtmlHelpers.Html;

namespace IPO.Web.Mvc.GovUk.HtmlHelpers
{
    public static class LegendForHelper
    {
        public static MvcHtmlString GovUkLegendFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper, 
            Expression<Func<TModel, TProperty>> expression,
            bool hasValidation = false)
        {

            return LegendHtml.GenerateLegendFor(htmlHelper, expression, hasValidation);            
        }
    }
}
