using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using IPO.Web.Mvc.GovUk.HtmlHelpers.Framework;
using IPO.Web.Mvc.GovUk.HtmlHelpers.Html;

namespace IPO.Web.Mvc.GovUk.HtmlHelpers
{
    public static class DropDownListForHelper
    {
        public static MvcHtmlString GovUkDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            SelectList selectList,
            bool hasCustomValidation = false)
        {
            var validationAttributes = htmlHelper.GetValidationAttributes(expression);
            var hasValidation = hasCustomValidation || validationAttributes.Count > 0;

            return ControlContainerHtml.GenerateSingleContainer(
                htmlHelper,
                expression,
                DropDownListHtml.GenerateDropDownList(htmlHelper, expression, selectList),
                false,
                hasValidation);  
        }

        public static MvcHtmlString GovUkDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            Dictionary<string, string> dictionarylist,
            bool hasCustomValidation = false)
        {
            var validationAttributes = htmlHelper.GetValidationAttributes(expression);
            var hasValidation = hasCustomValidation || validationAttributes.Count > 0;
            
            return ControlContainerHtml.GenerateSingleContainer(
                htmlHelper,
                expression,
                DropDownListHtml.GenerateDropDownList(htmlHelper, expression, dictionarylist),
                false,
                hasValidation);              
        }
    }
}
