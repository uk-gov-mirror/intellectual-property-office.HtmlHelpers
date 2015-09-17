using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using IPO.Web.Mvc.GovUk.HtmlHelpers.Framework;
using IPO.Web.Mvc.GovUk.HtmlHelpers.Html;

namespace IPO.Web.Mvc.GovUk.HtmlHelpers
{
    public static class TextInputForHelper
    {
        public static MvcHtmlString GovUkTextInputFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            bool hideLabel = false,
            bool hasCustomValidation = false)
        {
            var validationAttributes = htmlHelper.GetValidationAttributes(expression);
            var hasValidation = hasCustomValidation || validationAttributes.Count > 0;

            return ControlContainerHtml.GenerateSingleContainer(
                htmlHelper,
                expression,
                TextInputHtml.GenerateTextInputFor(htmlHelper, expression, validationAttributes),
                hideLabel,
                hasValidation);
        }

        public static MvcHtmlString GovUkTextInputWithPrefixFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            string prefixText,
            bool hideLabel = false,
            bool hasCustomValidation = false)
        {
            var validationAttributes = htmlHelper.GetValidationAttributes(expression);
            var hasValidation = hasCustomValidation || validationAttributes.Count > 0;

            return ControlContainerHtml.GenerateSingleContainer(
                htmlHelper,
                expression,
                TextInputHtml.GenerateTextInputWithPrefixFor(htmlHelper, expression, prefixText, validationAttributes),
                hideLabel,
                hasValidation);
        }

        public static MvcHtmlString GovUkCustomTextInputFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            object customFieldAttributes,
            bool hideLabel = false,
            bool hasCustomValidation = false)
        {
            var validationAttributes = htmlHelper.GetValidationAttributes(expression);
            var hasValidation = hasCustomValidation || validationAttributes.Count > 0;

            return ControlContainerHtml.GenerateSingleContainer(
                htmlHelper,
                expression,
                TextInputHtml.GenerateCustomTextInputFor(htmlHelper, expression, customFieldAttributes, validationAttributes),
                hideLabel,
                hasValidation);
        }

        public static MvcHtmlString GovUkCustomTextInputWithPrefixFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            string prefixText,
            object customFieldAttributes,
            bool hideLabel = false,
            bool hasCustomValidation = false)
        {
            var validationAttributes = htmlHelper.GetValidationAttributes(expression);
            var hasValidation = hasCustomValidation || validationAttributes.Count > 0;

            return ControlContainerHtml.GenerateSingleContainer(
                htmlHelper,
                expression,
                TextInputHtml.GenerateCustomTextInputWithPrefixFor(htmlHelper, expression, prefixText, customFieldAttributes, validationAttributes),
                hideLabel,
                hasValidation);
        }
    }
}