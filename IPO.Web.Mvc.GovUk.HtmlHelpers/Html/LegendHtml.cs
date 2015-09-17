using System;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using IPO.Web.Mvc.GovUk.HtmlHelpers.Framework;

namespace IPO.Web.Mvc.GovUk.HtmlHelpers.Html
{
    public class LegendHtml
    {
        internal static MvcHtmlString GenerateLegendFor<TModel, TProperty>(
            HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            bool hasValidation)
        {
            var legendText = htmlHelper.GetDisplayName(expression);
            var hintText = htmlHelper.GetDescription(expression);
            var validationHtml = hasValidation ? htmlHelper.ValidationMessageFor(expression, null, new { @class = "error-message text" }) : null;

            return MvcHtmlString.Create(GenerateLegendHtml(htmlHelper, legendText, hintText, validationHtml));
        }

        internal static MvcHtmlString GenerateLegend<TModel>(
            HtmlHelper<TModel> htmlHelper,
            string legendText,
            string hintText = null)
        {
            return MvcHtmlString.Create(GenerateLegendHtml(htmlHelper, legendText, hintText));
        }

        internal static MvcHtmlString GenerateHiddenLegend<TModel>(
            HtmlHelper<TModel> htmlHelper,
            string legendText)
        {
            return GenerateHiddenLegendHtml(htmlHelper, legendText);
        }

        private static string GenerateLegendHtml<TModel>(
            HtmlHelper<TModel> htmlHelper,
            string legendText,
            string hintText,
            MvcHtmlString validationContentHtml = null)
        {
            var html = new StringBuilder();

            html.Append(htmlHelper.CreateOpenTag("legend"));
            html.Append(htmlHelper.CreateTag("span", legendText, new { @class = "form-label-bold text" }));

            if (hintText != null)
            {
                html.Append(htmlHelper.GovUkHintText(hintText, true));
            }

            if (validationContentHtml != null)
            {
                html.Append(validationContentHtml);
            }

            html.Append(htmlHelper.CreateCloseTag("legend"));

            return html.ToString();
        }

        private static MvcHtmlString GenerateHiddenLegendHtml<TModel>(
            HtmlHelper<TModel> htmlHelper,
            string legendText)
        {

            return htmlHelper.CreateTag("legend", legendText, new { @class = "visuallyhidden" });
        }
    }
}