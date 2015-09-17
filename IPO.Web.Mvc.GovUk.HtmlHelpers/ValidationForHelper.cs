using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using IPO.Web.Mvc.GovUk.HtmlHelpers.Framework;

namespace IPO.Web.Mvc.GovUk.HtmlHelpers
{
    public static class ValidationForHelperExtensions
    {
        private const string ValidationErrorClass = "error";
        private const string ValidationClientSideClass = "field-input-validation-{0}";

        public static MvcHtmlString ValidationClassFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper, 
            Expression<Func<TModel, TProperty>> expression)
        {
            var propertyName = htmlHelper.GetPropertyName(expression);
            var clientSideClass = string.Format(ValidationClientSideClass, propertyName);

            return (htmlHelper.ViewData.ModelState[propertyName] != null && htmlHelper.ViewData.ModelState[propertyName].Errors.Count > 0)
                ? MvcHtmlString.Create(string.Format("{0} {1}", ValidationErrorClass, clientSideClass))
                : MvcHtmlString.Create(clientSideClass);
        }

        public static MvcHtmlString ValidationAnchorFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            var propertyName = expression.GetPropertyName(htmlHelper);

            return MvcHtmlString.Create(string.Format("<a id='{0}Error' name='{0}Error'></a>", propertyName));
        }
    }
}