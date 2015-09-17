using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace IPO.Web.Mvc.GovUk.HtmlHelpers.Framework
{
    public static class ExpressionHelperMethods
    {
        public static Dictionary<string, object> GetStringLengthAttributeDictionary<TModel, TProperty>(this Expression<Func<TModel, TProperty>> expression)
        {
            var stringLengthDictionary = new Dictionary<string, object>();

            var stringLengthAttribute = expression.GetStringLengthAttribute();

            if (stringLengthAttribute == null)
            {
                return stringLengthDictionary;
            }

            if (stringLengthAttribute.MaximumLength > 0)
            {
                stringLengthDictionary.Add("maxlength", stringLengthAttribute.MaximumLength);
            }

            if (stringLengthAttribute.MinimumLength > 0)
            {
                stringLengthDictionary.Add("minlength", stringLengthAttribute.MinimumLength);
            }

            return stringLengthDictionary;
        }

        private static StringLengthAttribute GetStringLengthAttribute<TModel, TProperty>(this Expression<Func<TModel, TProperty>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;

            if (memberExpression == null)
            {
                return null;
            }

            return memberExpression.Member.GetCustomAttributes(typeof(StringLengthAttribute), false).FirstOrDefault() as StringLengthAttribute;
        }

        public static string GetPropertyName<TModel, TProperty>(this Expression<Func<TModel, TProperty>> expression, HtmlHelper<TModel> htmlHelper)
        {
            var propertyName = ExpressionHelper.GetExpressionText(expression);
            return htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(propertyName);
        }
    }
}
