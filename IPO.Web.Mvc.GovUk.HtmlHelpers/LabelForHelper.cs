using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using IPO.Web.Mvc.GovUk.HtmlHelpers.Html;

namespace IPO.Web.Mvc.GovUk.HtmlHelpers
{
    public static class LabelForHelper
    {
        public static MvcHtmlString GovUkLabelFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            bool hasValidation = false)
        {
            return LabelHtml.GenerateLabelFor(htmlHelper, expression, hasValidation);
        }

        public static MvcHtmlString GovUkHiddenLabelFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            bool hasValidation = false)
        {
            return LabelHtml.GenerateHiddenLabelFor(htmlHelper, expression, hasValidation);
        }
    }
}
