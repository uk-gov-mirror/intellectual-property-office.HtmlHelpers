using System;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using IPO.Web.Mvc.GovUk.HtmlHelpers.Framework;
using IPO.Web.Mvc.GovUk.HtmlHelpers.Html;

namespace IPO.Web.Mvc.GovUk.HtmlHelpers
{
    public static class PostCodeInputForHelper
    {
        public static MvcHtmlString GovUkPostCodeInputFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            string buttonText = null,
            bool hideLabel = false,
            bool hasCustomValidation = false)
        {
            var validationAttributes = htmlHelper.GetValidationAttributes(expression);
            var hasValidation = hasCustomValidation || validationAttributes.Count > 0;

            var html = new StringBuilder();
            html.Append(TextInputHtml.GenerateCustomTextInputFor(htmlHelper, expression, new { @class = "form-control form-control-1-8 post-code" }, validationAttributes));

            if (!string.IsNullOrEmpty(buttonText))
            {
                html.Append(string.Format(" <input type=\"submit\" id=\"FindAddress\" name=\"FindAddress\" class=\"button\" value=\"{0}\">", buttonText));
            }

            return ControlContainerHtml.GenerateSingleContainer(
                 htmlHelper,
                 expression,
                 new MvcHtmlString(html.ToString()),
                 hideLabel,
                 hasValidation);
        }
    }
}
