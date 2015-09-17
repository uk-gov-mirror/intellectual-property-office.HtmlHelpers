using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using IPO.Web.Mvc.GovUk.HtmlHelpers.Framework;
using IPO.Web.Mvc.GovUk.HtmlHelpers.Html;

namespace IPO.Web.Mvc.GovUk.HtmlHelpers
{
    public static class TextAreaInputForHelper
    {
        public static MvcHtmlString GovUkTextAreaInputFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            int rows = 4,
            int cols = 30,
            bool hideLabel = false,
            bool hasCustomValidation = false)
        {
            var validationAttributes = htmlHelper.GetValidationAttributes(expression);
            var hasValidation = hasCustomValidation || validationAttributes.Count > 0;

            return ControlContainerHtml.GenerateSingleContainer(
            htmlHelper,
            expression,
            TextAreaInputHtml.GenerateTextAreaInputFor(htmlHelper, expression, rows, cols, validationAttributes),
            hideLabel,
            hasValidation);
        }

        public static MvcHtmlString GovUkCustomTextAreaInputFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            object customFieldAttributes,
            int rows = 4,
            int cols = 30,
            bool hideLabel = false,
            bool hasCustomValidation = false)
        {
            var validationAttributes = htmlHelper.GetValidationAttributes(expression);
            var hasValidation = hasCustomValidation || validationAttributes.Count > 0;

            return ControlContainerHtml.GenerateSingleContainer(
            htmlHelper,
            expression,
            TextAreaInputHtml.GenerateCustomTextAreaInputFor(htmlHelper, expression, customFieldAttributes, rows, cols, validationAttributes),
            hideLabel,
            hasValidation);
        }
    }
}