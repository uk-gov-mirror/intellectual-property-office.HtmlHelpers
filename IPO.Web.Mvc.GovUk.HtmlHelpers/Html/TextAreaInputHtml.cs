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
    public class TextAreaInputHtml
    {
        internal static MvcHtmlString GenerateTextAreaInputFor<TModel, TProperty>(
            HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            int rows,
            int cols,
            IDictionary<string, object> validationAttributes)
        {
            return MvcHtmlString.Create(GenerateTextAreaInputHtml(htmlHelper, expression, rows, cols, validationAttributes, null));
        }

        internal static MvcHtmlString GenerateCustomTextAreaInputFor<TModel, TProperty>(
            HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            object customFieldAttributes,
            int rows,
            int cols,
            IDictionary<string, object> validationAttributes)
        {
            return MvcHtmlString.Create(GenerateTextAreaInputHtml(htmlHelper, expression, rows, cols, validationAttributes, customFieldAttributes));
        }

        private static string GenerateTextAreaInputHtml<TModel, TProperty>(
            HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            int rows,
            int cols,
            IDictionary<string, object> validationAttributes,
            object customFieldAttributes)
        {
            var html = new StringBuilder();

            var fieldAttributes = new RouteValueDictionary(customFieldAttributes ?? new { @class = "form-control", style = "resize:none" });

            if (validationAttributes != null)
            {
                AddValidationAttributes(validationAttributes, expression, fieldAttributes);
            }

            html.Append(htmlHelper.TextAreaFor(expression, rows, cols, fieldAttributes));

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
