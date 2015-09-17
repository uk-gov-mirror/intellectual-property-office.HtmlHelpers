using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;

namespace IPO.Web.Mvc.GovUk.HtmlHelpers.Framework
{
    public static class HtmlHelperMethods
    {
        public static string GetPropertyName<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper, 
            Expression<Func<TModel, TProperty>> expression)
        {
            var propertyName = ExpressionHelper.GetExpressionText(expression);
            return htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(propertyName);
        }

        public static string GetDisplayName<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper, 
            Expression<Func<TModel, TProperty>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return metadata.DisplayName;
        }

        public static string GetDescription<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper, 
            Expression<Func<TModel, TProperty>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return metadata.Description;
        }

        public static IDictionary<string, object> GetValidationAttributes<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper, 
            Expression<Func<TModel, TProperty>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var propertyName = ExpressionHelper.GetExpressionText(expression);
            var validationAttributes = htmlHelper.GetUnobtrusiveValidationAttributes(propertyName, metadata);

            return validationAttributes;
        }

        public static bool HasModelErrors<TModel>(this HtmlHelper<TModel> htmlHelper)
        {
            return !htmlHelper.ViewData.ModelState.IsValid;
        }
        
        public static MvcHtmlString CreateOpenTag<TModel>(
            this HtmlHelper<TModel> htmlHelper,
            string tagName,
            object tagAttributes = null,
            object additionaltagAttributes = null)
        {
            var tagBuilder = new TagBuilder(tagName);

            if (tagAttributes != null)
            {
                tagBuilder.MergeAttributes(new RouteValueDictionary(tagAttributes));
            }

            if (additionaltagAttributes != null)
            {
                tagBuilder.MergeAttributes(new RouteValueDictionary(additionaltagAttributes));
            }

            return new MvcHtmlString(tagBuilder.ToString(TagRenderMode.StartTag));
        }

        public static MvcHtmlString CreateCloseTag<TModel>(
            this HtmlHelper<TModel> htmlHelper, 
            string tagName)
        {
            var tagBuilder = new TagBuilder(tagName);

            return new MvcHtmlString(tagBuilder.ToString(TagRenderMode.EndTag));
        }

        public static MvcHtmlString CreateTag<TModel>(
            this HtmlHelper<TModel> htmlHelper, 
            string tagName, 
            string tagContent, 
            object tagAttributes = null)
        {
            var tagBuilder = new TagBuilder(tagName);

            if (tagAttributes != null)
            {
                tagBuilder.MergeAttributes(new RouteValueDictionary(tagAttributes));
            }

            if (tagContent != null)
            {
                tagBuilder.SetInnerText(tagContent);
            }

            return new MvcHtmlString(tagBuilder.ToString(TagRenderMode.Normal));
        }
    }
}