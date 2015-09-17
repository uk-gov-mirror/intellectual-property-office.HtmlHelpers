using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using IPO.Web.Mvc.GovUk.HtmlHelpers.Framework;
using IPO.Web.Mvc.GovUk.HtmlHelpers.Html;

namespace IPO.Web.Mvc.GovUk.HtmlHelpers
{
    public static class RadioListForEnumHelper
    {
        public static MvcHtmlString GovUkRadioListForEnum<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            bool hasCustomValidation = false)
        {
            var validationAttributes = htmlHelper.GetValidationAttributes(expression);
            var hasValidation = hasCustomValidation || validationAttributes.Count > 0;

            return ControlContainerHtml.GenerateGroupContainer(
                htmlHelper,
                expression,
                RadioListHtml.GenerateRadioListForEnum(htmlHelper, expression),
                hasValidation);
        }
    }
}