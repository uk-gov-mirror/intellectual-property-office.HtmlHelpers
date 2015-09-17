using System;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using IPO.Web.Mvc.GovUk.HtmlHelpers.Framework;

namespace IPO.Web.Mvc.GovUk.HtmlHelpers.Html
{
    public class ControlContainerHtml
    {
        internal static MvcHtmlString GenerateSingleContainer<TModel, TProperty>(
            HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            MvcHtmlString htmlContent,
            bool hideLabel,
            bool hasValidation)
        {
            return GenerateSingleContainerHtml(htmlHelper, expression, htmlContent, hideLabel, hasValidation);
        }

        internal static MvcHtmlString GenerateGroupContainer<TModel, TProperty>(
            HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            MvcHtmlString htmlContent,
            bool hasValidation)
        {
            return GenerateGroupContainerHtml(htmlHelper, expression, htmlContent, hasValidation);
        }

        private static MvcHtmlString GenerateSingleContainerHtml<TModel, TProperty>(
            HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            MvcHtmlString htmlContent,
            bool hideLabel,
            bool hasValidation)
        {
            var html = new StringBuilder();

            html.Append(hideLabel ? htmlHelper.GovUkHiddenLabelFor(expression, hasValidation) : htmlHelper.GovUkLabelFor(expression, hasValidation));
            html.Append(htmlContent);

            return GenerateContainerHtml(htmlHelper, expression, html.ToString(), hasValidation);
        }

        private static MvcHtmlString GenerateGroupContainerHtml<TModel, TProperty>(
            HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            MvcHtmlString htmlContent,
            bool hasValidation)
        {
            var html = new StringBuilder();
            
            html.Append(htmlHelper.CreateOpenTag("fieldset"));
            html.Append(htmlHelper.GovUkLegendFor(expression, hasValidation));
            html.Append(htmlContent);
            html.Append(htmlHelper.CreateCloseTag("fieldset"));

            return GenerateContainerHtml(htmlHelper, expression, html.ToString(), hasValidation);
        }

        private static MvcHtmlString GenerateContainerHtml<TModel, TProperty>(
            HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            string htmlContent,
            bool hasValidation)
        {
            var html = new StringBuilder();
            
            html.Append(htmlHelper.CreateOpenTag("div", new { @class = hasValidation ? string.Format("form-group {0}", htmlHelper.ValidationClassFor(expression)) : "form-group" }));
            html.Append(htmlContent);
            html.Append(htmlHelper.CreateCloseTag("div"));

            return MvcHtmlString.Create(html.ToString());
        }
    }
}