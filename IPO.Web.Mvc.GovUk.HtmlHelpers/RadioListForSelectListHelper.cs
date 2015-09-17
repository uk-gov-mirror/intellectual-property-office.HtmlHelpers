using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using IPO.Web.Mvc.GovUk.HtmlHelpers.Framework;
using IPO.Web.Mvc.GovUk.HtmlHelpers.Html;

namespace IPO.Web.Mvc.GovUk.HtmlHelpers
{
    public static class RadioListForSelectListHelper
    {
        public static MvcHtmlString GovUkRadioListForSelectList<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            SelectList selectList, bool hasCustomValidation = false)
        {
            var validationAttributes = htmlHelper.GetValidationAttributes(expression);
            var hasValidation = hasCustomValidation || validationAttributes.Count > 0;

            return ControlContainerHtml.GenerateGroupContainer(
                htmlHelper,
                expression,
                RadioListHtml.GenerateRadioListFor(htmlHelper, expression, selectList),
                hasValidation);
        }
    }
}
