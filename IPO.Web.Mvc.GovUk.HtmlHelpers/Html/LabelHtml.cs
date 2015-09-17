using System;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using IPO.Web.Mvc.GovUk.HtmlHelpers.Framework;

namespace IPO.Web.Mvc.GovUk.HtmlHelpers.Html
{
    public class LabelHtml
    {
        internal static MvcHtmlString GenerateLabelFor<TModel, TProperty>(
            HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            bool hasValidation)
        {
            return MvcHtmlString.Create(GenerateLabelHtml(htmlHelper, expression, hasValidation));
        }

        internal static MvcHtmlString GenerateHiddenLabelFor<TModel, TProperty>(
            HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            bool hasValidation)
        {
            return MvcHtmlString.Create(GenerateHiddenLabelHtml(htmlHelper, expression, hasValidation));
        }

        private static string GenerateLabelHtml<TModel, TProperty>(
            HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            bool hasValidation)
        {
            var propertyName = htmlHelper.GetPropertyName(expression);
            var labelText = htmlHelper.GetDisplayName(expression);
            var html = new StringBuilder();

            html.Append(htmlHelper.CreateOpenTag("label", new { @for = propertyName }));
            html.Append(htmlHelper.CreateTag("span", labelText, new { @class = "form-label-bold text" }));
            html.Append(GenerateLabelContentHtml(htmlHelper, expression, hasValidation));
            html.Append(htmlHelper.CreateCloseTag("label"));

            return html.ToString();
        }

        private static string GenerateHiddenLabelHtml<TModel, TProperty>(
            HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            bool hasValidation)
        {
            var propertyName = htmlHelper.GetPropertyName(expression);
            var labelText = htmlHelper.GetDisplayName(expression);
            var html = new StringBuilder();

            html.Append(htmlHelper.CreateTag("label", labelText, new { @for = propertyName, @class = "visuallyhidden" }));
            html.Append(GenerateLabelContentHtml(htmlHelper, expression, hasValidation));

            return html.ToString();
        }

        private static string GenerateLabelContentHtml<TModel, TProperty>(
            HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            bool hasValidation)
        {
            var html = new StringBuilder();

            var hintText = htmlHelper.GetDescription(expression);
            var validationHtml = hasValidation ? htmlHelper.ValidationMessageFor(expression, null, new { @class = "error-message text" }) : null;

            if (hintText != null)
            {
                html.Append(htmlHelper.GovUkHintText(hintText, true));
            }

            if (validationHtml != null)
            {
                html.Append(validationHtml);
            }

            return html.ToString();
        }
    }
}