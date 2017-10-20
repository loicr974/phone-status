using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneStatus.helpers
{
    public static class HtmlHelperExtension
    {
        public static MvcHtmlString ActionLinkGlyphicon(this HtmlHelper helper, string actionName, string controllerName, string glyphIconName)
        {
            return ActionLinkGlyphion(GenerateUrl(actionName, controllerName), glyphIconName);
        }

        public static MvcHtmlString ActionLinkGlyphicon(this HtmlHelper helper, string actionName, string controllerName, string glyphIconName, object routeValues)
        {
            return ActionLinkGlyphion(GenerateUrl(actionName, controllerName, routeValues), glyphIconName);
        }

        private static MvcHtmlString ActionLinkGlyphion(string url, string glyphIconName)
        {
            TagBuilder spanBuilder = new TagBuilder("span");
            spanBuilder.Attributes.Add("class", "glyphicon glyphicon-" + glyphIconName);
            
            string stringInnerHtml = spanBuilder.ToString();
            //return BuildNestedAnchor(spanBuilder.ToString(), string.Format("/{0}/{1}", controllerName, actionName), htmlAttributes);
            //}

            //private static string BuildNestedAnchor(string innerHtml, string url, object htmlAttributes)
            TagBuilder anchorBuilder = new TagBuilder("a");
            anchorBuilder.Attributes.Add("href", url);
            //anchorBuilder.mer
            anchorBuilder.InnerHtml = stringInnerHtml;


            return new MvcHtmlString(anchorBuilder.ToString());
        }

        private static string GenerateUrl(string actionName, string controllerName, object routeValues=null)
        {
            string url;
            var requestContext = HttpContext.Current.Request.RequestContext;
            if (routeValues != null)
            {
                url = new UrlHelper(requestContext).Action(actionName, controllerName, routeValues);
            }
            else {
                url = new UrlHelper(requestContext).Action(actionName, controllerName);
            }
            return url;
        }
    }
}