using System;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using IPO.Web.Mvc.GovUk.HtmlHelpers.Framework;

namespace IPO.Web.Mvc.GovUk.HtmlHelpers.Html
{
    public class CheckBoxHtml
    {
        internal static MvcHtmlString GenerateCheckBoxFor<TModel>(
            HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, bool>> expression,
            bool hasValidation = false)
        {

            return GenerateCheckBoxHtml(htmlHelper, expression, hasValidation);
        }

        private static MvcHtmlString GenerateCheckBoxHtml<TModel>(
            HtmlHelper<TModel> htmlHelper, 
            Expression<Func<TModel, bool>> expression, 
            bool hasValidation)
        {
            var propertyName = htmlHelper.GetPropertyName(expression);
            var displayName = htmlHelper.GetDisplayName(expression);
            var hintText = htmlHelper.GetDescription(expression);
            var html = new StringBuilder();

            html.Append(htmlHelper.CreateOpenTag("div", new { @class = hasValidation ? string.Format("form-group {0}", htmlHelper.ValidationClassFor(expression)) : "form-group" }));
            
            if (!string.IsNullOrEmpty(hintText))
            {
                html.Append(htmlHelper.GovUkHintText(hintText));
            }

            if (hasValidation)
            {
                html.Append(htmlHelper.ValidationMessageFor(expression, null, new { @class = "error-message" }));
            }

            html.Append(htmlHelper.CreateOpenTag("label", new { @for = propertyName, @class = "block-label" }));
            html.Append(htmlHelper.CheckBoxFor(expression));
            html.Append(htmlHelper.CreateTag("span", displayName));
            html.Append(htmlHelper.CreateCloseTag("label"));
            html.Append(htmlHelper.CreateCloseTag("div"));

            return MvcHtmlString.Create(html.ToString());
        }
    }
}