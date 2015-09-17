using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using IPO.Web.Mvc.GovUk.HtmlHelpers.Framework;

namespace IPO.Web.Mvc.GovUk.HtmlHelpers.Html
{
    public class TextPanelHtml
    {
        internal static MvcHtmlString GenerateTextPanel<TModel>(
            HtmlHelper<TModel> htmlHelper,
            string panelText)
        {

            return MvcHtmlString.Create(GenerateTextPanelHtml(htmlHelper, panelText));
        }

        internal static MvcHtmlString GenerateTextPanel<TModel>(
            HtmlHelper<TModel> htmlHelper,
            IEnumerable<string> panelTextList)
        {

            return MvcHtmlString.Create(GenerateTextPanelHtml(htmlHelper, panelTextList));
        }

        internal static MvcHtmlString GenerateTextPanelForLabel<TModel>(
            HtmlHelper<TModel> htmlHelper,
            string panelText,
            string labelName)
        {

            return MvcHtmlString.Create(GenerateTextPanelForLabelHtml(htmlHelper, panelText, labelName));
        }

        internal static MvcHtmlString GenerateTextPanelForLabel<TModel>(
            HtmlHelper<TModel> htmlHelper,
            IEnumerable<string> panelTextList,
            string labelName)
        {

            return MvcHtmlString.Create(GenerateTextPanelForLabelHtml(htmlHelper, panelTextList, labelName));
        }

        private static string GenerateTextPanelHtml<TModel>(
            HtmlHelper<TModel> htmlHelper, 
            string panelText)
        {
            var html = new StringBuilder();

            html.Append(htmlHelper.CreateOpenTag("div", new { @class = "panel-indent" }));
            html.Append(htmlHelper.CreateTag("p", panelText, new { @class = "text" }));
            html.Append(htmlHelper.CreateCloseTag("div"));

            return html.ToString();
        }

        private static string GenerateTextPanelHtml<TModel>(
            HtmlHelper<TModel> htmlHelper,
            IEnumerable<string> panelTextList)
        {
            var html = new StringBuilder();

            html.Append(htmlHelper.CreateOpenTag("div", new { @class = "panel-indent" }));

            foreach (var panelText in panelTextList)
            {
                html.Append(htmlHelper.CreateTag("p", panelText, new { @class = "text" }));
            }

            html.Append(htmlHelper.CreateCloseTag("div"));

            return html.ToString();
        }

        private static string GenerateTextPanelForLabelHtml<TModel>(
            HtmlHelper<TModel> htmlHelper, 
            string panelText, 
            string labelName)
        {
            var html = new StringBuilder();
            html.Append(GenerateTextPanelHtml(htmlHelper, panelText));
            html.Append(GenerateJquery(labelName));
            return html.ToString();
        }

        private static string GenerateTextPanelForLabelHtml<TModel>(
            HtmlHelper<TModel> htmlHelper,
            IEnumerable<string> panelTextList,
            string labelName)
        {
            var html = new StringBuilder();
            html.Append(GenerateTextPanelHtml(htmlHelper, panelTextList));
            html.Append(GenerateJquery(labelName));
            return html.ToString();
        }

        private static string GenerateJquery(string labelName)
        {
            var jqueryHtml = new StringBuilder();

            jqueryHtml.Append("<script type=\"text/javascript\">");
            jqueryHtml.Append("$(document).ready(function () {");
            jqueryHtml.Append("$(\".panel-indent\").hide();");
            jqueryHtml.Append("$(\"label\").click(function () {");
            jqueryHtml.Append(string.Format("var keyword = \"{0}\";", labelName));
            jqueryHtml.Append("if ($(this).text().toLowerCase().indexOf(keyword.toLowerCase()) == 0) {");
            jqueryHtml.Append("$(\".panel-indent\").show();");
            jqueryHtml.Append("} else {");
            jqueryHtml.Append("$(\".panel-indent\").hide();");
            jqueryHtml.Append("}");
            jqueryHtml.Append("});");
            jqueryHtml.Append("});");
            jqueryHtml.Append("</script>");
            jqueryHtml.Append("");

            return jqueryHtml.ToString();
        }
    }
}