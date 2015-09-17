using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace IPO.Web.Mvc.GovUk.HtmlHelpers.Html
{
    public class DropDownListHtml
    {
        internal static MvcHtmlString GenerateDropDownList<TModel, TProperty>(
            HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            SelectList selectList)
        {
            return MvcHtmlString.Create(GenerateDropDownHtml(htmlHelper, expression, selectList));
        }

        internal static MvcHtmlString GenerateDropDownList<TModel, TProperty>(
            HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            Dictionary<string, string> dictionarylist)
        {
            var selectList = new SelectList(dictionarylist, "Key", "Value");

            return MvcHtmlString.Create(GenerateDropDownHtml(htmlHelper, expression, selectList)); 
        }

        private static string GenerateDropDownHtml<TModel, TProperty>(
            HtmlHelper<TModel> htmlHelper, 
            Expression<Func<TModel, TProperty>> expression, 
            SelectList selectList)
        {
            return htmlHelper.DropDownListFor(expression, selectList, new {@class = "form-control"}).ToString();
        }       
    }
}