using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IPO.Web.Mvc.GovUk.HtmlHelpers
{
    public static class HintTextHelper
    {
        /// <summary>
        /// In order to use the HintText attribute you will need to register the GovUkModelMetadataProvider in your Global.asax Application_Start method
        /// </summary>
        public static MvcHtmlString GovUkHintTextFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return GovUkHintTextFor(htmlHelper, expression, null /* htmlAttributes */);
        }

        /// <summary>
        /// In order to use the HintText attribute you will need to register the GovUkModelMetadataProvider in your Global.asax Application_Start method
        /// </summary>
        public static MvcHtmlString GovUkHintTextFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            return GovUkHintTextFor(htmlHelper, expression, new RouteValueDictionary(htmlAttributes));
        }

        /// <summary>
        /// In order to use the HintText attribute you will need to register the GovUkModelMetadataProvider in your Global.asax Application_Start method
        /// </summary>
        public static MvcHtmlString GovUkHintTextFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var values = metadata.AdditionalValues;
            return htmlHelper.GovUkHintText(values["HintText"] as IEnumerable<string>);
        }

        public static MvcHtmlString GovUkHintText<TModel>(
            this HtmlHelper<TModel> htmlHelper,
            string hintText, bool
            internalElement = false)
        {
            return new MvcHtmlString(BuildHintTextHtml(hintText, internalElement));
        }

        public static IHtmlString GovUkHtmlHintText<TModel>(
            this HtmlHelper<TModel> htmlHelper,
            string hintText,
            bool internalElement = false)
        {
            return htmlHelper.Raw(BuildHintTextHtml(hintText, internalElement));
        }

        public static MvcHtmlString GovUkHintText<TModel>(
            this HtmlHelper<TModel> htmlHelper,
            IEnumerable<string> hintTextList,
            bool internalElement = false)
        {
            var html = new StringBuilder();

            foreach (var hintText in hintTextList)
            {
                html.Append(BuildHintTextHtml(hintText, internalElement));
            }

            return MvcHtmlString.Create(html.ToString());
        }

        public static IHtmlString GovUkHtmlHintText<TModel>(
            this HtmlHelper<TModel> htmlHelper,
            IEnumerable<string> hintTextList,
            bool internalElement = false)
        {
            var html = new StringBuilder();

            foreach (var htmlHintText in hintTextList)
            {
                html.Append(BuildHintTextHtml(htmlHintText, internalElement));
            }

            return htmlHelper.Raw(html.ToString());
        }

        private static string BuildHintTextHtml(string hintText, bool internalElement)
        {
            return internalElement
                ? string.Format("<span class='form-hint text'>{0}</span>", hintText)
                : string.Format("<p class='form-hint text'>{0}</p>", hintText);
        }
    }
}
