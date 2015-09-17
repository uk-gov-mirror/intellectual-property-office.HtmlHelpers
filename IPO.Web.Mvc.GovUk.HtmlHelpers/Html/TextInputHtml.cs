using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using IPO.Web.Mvc.GovUk.HtmlHelpers.Framework;

namespace IPO.Web.Mvc.GovUk.HtmlHelpers.Html
{
    public class TextInputHtml
    {
        internal static MvcHtmlString GenerateTextInputFor<TModel, TProperty>(
            HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            IDictionary<string, object> validationAttributes)
        {
            return MvcHtmlString.Create(GenerateTextInputHtml(htmlHelper, expression, null, validationAttributes, null));
        }

        internal static MvcHtmlString GenerateTextInputWithPrefixFor<TModel, TProperty>(
            HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            string prefixText,
            IDictionary<string, object> validationAttributes)
        {
            return MvcHtmlString.Create(GenerateTextInputHtml(htmlHelper, expression, prefixText, validationAttributes, null));
        }

        internal static MvcHtmlString GenerateCustomTextInputFor<TModel, TProperty>(
            HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            object customFieldAttributes,
            IDictionary<string, object> validationAttributes)
        {
            return MvcHtmlString.Create(GenerateTextInputHtml(htmlHelper, expression, null, validationAttributes, customFieldAttributes));
        }

        internal static MvcHtmlString GenerateCustomTextInputWithPrefixFor<TModel, TProperty>(
            HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            string prefixText,
            object customFieldAttributes,
            IDictionary<string, object> validationAttributes)
        {
            return MvcHtmlString.Create(GenerateTextInputHtml(htmlHelper, expression, prefixText, validationAttributes, customFieldAttributes));
        }

        private static string GenerateTextInputHtml<TModel, TProperty>(
            HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            string prefixText,
            IDictionary<string, object> validationAttributes,
            object customFieldAttributes)
        {
            var html = new StringBuilder();

            if (!string.IsNullOrEmpty(prefixText))
            {
                html.Append(htmlHelper.CreateTag("span", prefixText, new { @class = "pre-input" }));
            }

            var fieldAttributes = new RouteValueDictionary(customFieldAttributes ?? new { @class = "form-control" });

            if (validationAttributes != null)
            {
                AddValidationAttributes(validationAttributes, expression, fieldAttributes);
            }

            html.Append(htmlHelper.TextBoxFor(expression, null, fieldAttributes));

            return html.ToString();
        }

        private static void AddValidationAttributes<TModel, TProperty>(
            IDictionary<string, object> validationAttributes,
            Expression<Func<TModel, TProperty>> expression,
            RouteValueDictionary fieldAttributes
            )
        {

            if (validationAttributes == null || !validationAttributes.ContainsKey("data-val-length"))
            {
                return;
            }

            foreach (var item in expression.GetStringLengthAttributeDictionary())
            {
                fieldAttributes.Add(item.Key, item.Value);
            }
        }
    }
}