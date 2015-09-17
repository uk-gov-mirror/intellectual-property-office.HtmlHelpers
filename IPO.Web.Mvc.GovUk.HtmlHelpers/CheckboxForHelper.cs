using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using IPO.Web.Mvc.GovUk.HtmlHelpers.Framework;
using IPO.Web.Mvc.GovUk.HtmlHelpers.Html;

namespace IPO.Web.Mvc.GovUk.HtmlHelpers
{
    public static class CheckboxForHelper
    {
        public static MvcHtmlString GovUkCheckboxFor<TModel>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, bool>> expression,
            bool hasCustomValidation = false)
        {
            var validationAttributes = htmlHelper.GetValidationAttributes(expression);
            var hasValidation = hasCustomValidation || validationAttributes.Count > 0;

            return CheckBoxHtml.GenerateCheckBoxFor(htmlHelper, expression, hasValidation);
        }
    }
}
