using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using IPO.Web.Mvc.GovUk.HtmlHelpers.Framework;

namespace IPO.Web.Mvc.GovUk.HtmlHelpers.Html
{
    public class RadioListHtml
    {
        internal static MvcHtmlString GenerateRadioListFor<TModel, TProperty>(
            HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            SelectList selectList)
        {
            return MvcHtmlString.Create(GenerateSelectListHtml(htmlHelper, expression, selectList));
        }

        internal static MvcHtmlString GenerateRadioListForEnum<TModel, TProperty>(
            HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression)
        {
            return MvcHtmlString.Create(GenerateSelectListForEnumHtml(htmlHelper, expression));
        }

        private static string GenerateSelectListHtml<TModel, TProperty>(
            HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>>
            expression, SelectList selectList)
        {
            var propertyName = htmlHelper.GetPropertyName(expression);
            var html = new StringBuilder();

            var count = 0;

            foreach (var listItem in selectList)
            {

                var radioItemTextArray = listItem.Text.Split(new char[] { ']', '[' }, StringSplitOptions.RemoveEmptyEntries);
                var containsVisuallyHiddenText = radioItemTextArray.Count() > 1;

                html.Append(htmlHelper.CreateOpenTag("label", new { @for = string.Format("{0}_{1}", propertyName, count), @class = "block-label" }));
                html.Append(htmlHelper.RadioButtonFor(expression, listItem.Value, new { id = string.Format("{0}_{1}", propertyName, count) }));
                html.Append(radioItemTextArray.First());

                if (containsVisuallyHiddenText)
                {
                    html.Append(htmlHelper.GovUkAccessibilityText(radioItemTextArray.Last()));
                }

                html.Append(htmlHelper.CreateCloseTag("label"));

                count++;
            }

            return html.ToString();
        }

        private static string GenerateSelectListForEnumHtml<TModel, TProperty>(
            HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression)
        {
            var propertyName = htmlHelper.GetPropertyName(expression);
            var html = new StringBuilder();

            foreach (var listItem in EnumHelper.GetSelectList(typeof(TProperty)))
            {
                if (listItem.Value == string.Empty)
                {
                    continue;
                }

                var radioItemTextArray = listItem.Text.Split(new char[] { ']', '[' }, StringSplitOptions.RemoveEmptyEntries);
                var containsVisuallyHiddenText = radioItemTextArray.Count() > 1;

                html.Append(htmlHelper.CreateOpenTag("label", new { @for = string.Format("{0}_{1}", propertyName, listItem.Value), @class = "block-label" }));
                html.Append(htmlHelper.RadioButtonFor(expression, listItem.Value, GetHtmlAttributesForEnum(htmlHelper, propertyName, listItem)));
                html.Append(radioItemTextArray.First());

                if (containsVisuallyHiddenText)
                {
                    html.Append(htmlHelper.GovUkAccessibilityText(radioItemTextArray.Last()));
                }

                html.Append(htmlHelper.CreateCloseTag("label"));
            }

            return html.ToString();
        }

        private static object GetHtmlAttributesForEnum<TModel>(
            HtmlHelper<TModel> htmlHelper,
            string propertyName,
            SelectListItem listItem)
        {
            var enumProperty = htmlHelper.ViewData.Model.GetType().GetProperty(propertyName).GetValue(htmlHelper.ViewData.Model, null);

            if (enumProperty == null || ((int)enumProperty).ToString() != listItem.Value)
            {
                return new { id = string.Format("{0}_{1}", propertyName, listItem.Value) };
            }

            return new { id = string.Format("{0}_{1}", propertyName, listItem.Value), @checked = true };
        }
    }
}