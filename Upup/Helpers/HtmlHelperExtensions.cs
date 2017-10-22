using System.Web.Mvc;
using System.Web.Routing;

namespace Upup.Helpers {
    public static class HtmlHelperExtensions {
        public static MvcHtmlString Image(this HtmlHelper html, string url, string altText, object htmlAttributes) {
            var builder = new TagBuilder("img");
            builder.Attributes.Add("src", url);
            builder.Attributes.Add("alt", altText);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
        public static MvcHtmlString ActionImage(this HtmlHelper html, string action, string controller, object routeValues, object linkAttributes, string imagePath, string alt, object imageAttributes) {
            var url = new UrlHelper(html.ViewContext.RequestContext);

            // build the <img> tag
            var imgBuilder = new TagBuilder("img");
            imgBuilder.MergeAttribute("src", url.Content(imagePath));
            imgBuilder.MergeAttribute("alt", alt);
            imgBuilder.MergeAttributes(new RouteValueDictionary(HtmlHelper.AnonymousObjectToHtmlAttributes(imageAttributes)));
            var imgHtml = imgBuilder.ToString(TagRenderMode.SelfClosing);

            // build the <a> tag
            var anchorBuilder = new TagBuilder("a");
            anchorBuilder.MergeAttribute("href", url.Action(action, controller, routeValues));
            anchorBuilder.MergeAttributes(new RouteValueDictionary(HtmlHelper.AnonymousObjectToHtmlAttributes(linkAttributes)));
            anchorBuilder.InnerHtml = imgHtml; // include the <img> tag inside
            var anchorHtml = anchorBuilder.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(anchorHtml);
        }

        public static MvcHtmlString ActionIcon(this HtmlHelper html, string action, string controller, object routeValues, object linkAttributes, string displayText, object iconAttributes) {
            var url = new UrlHelper(html.ViewContext.RequestContext);

            // build the <i> tag
            var iBuilder = new TagBuilder("i"); ;
            iBuilder.MergeAttributes(new RouteValueDictionary(HtmlHelper.AnonymousObjectToHtmlAttributes(iconAttributes)));
            var iHtml = iBuilder.ToString(TagRenderMode.Normal);

            // build the <a> tag
            var anchorBuilder = new TagBuilder("a");
            if (string.IsNullOrEmpty(action) || string.IsNullOrEmpty(action)) {
                anchorBuilder.MergeAttribute("href", "javascript:void(0)");
            } else {
                anchorBuilder.MergeAttribute("href", url.Action(action, controller, routeValues));
            }
            anchorBuilder.MergeAttributes(new RouteValueDictionary(HtmlHelper.AnonymousObjectToHtmlAttributes(linkAttributes)));
            anchorBuilder.InnerHtml = displayText + " " + iHtml; // include the <i> tag inside
            var anchorHtml = anchorBuilder.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(anchorHtml);
        }

        public static MvcHtmlString ActionSlideMenu(this HtmlHelper html, string action, string controller, object routeValues, string displayText, object iconAttributes, string notificationNumber, object notificationAttributes) {
            var url = new UrlHelper(html.ViewContext.RequestContext);

            // build the <i> tag
            var iBuilder = new TagBuilder("i");
            iBuilder.MergeAttributes(new RouteValueDictionary(HtmlHelper.AnonymousObjectToHtmlAttributes(iconAttributes)));
            var iHtml = iBuilder.ToString(TagRenderMode.Normal);

            // build the <span> tag
            var spanBuilder = new TagBuilder("span");
            spanBuilder.SetInnerText(displayText);
            var spanHtml = spanBuilder.ToString(TagRenderMode.Normal);

            // build the <small> tag
            var smallBuilder = new TagBuilder("small");
            smallBuilder.MergeAttributes(new RouteValueDictionary(HtmlHelper.AnonymousObjectToHtmlAttributes(notificationAttributes)));
            smallBuilder.SetInnerText(notificationNumber);
            var smallHtml = smallBuilder.ToString(TagRenderMode.Normal);

            // build the <a> tag
            var anchorBuilder = new TagBuilder("a");
            anchorBuilder.MergeAttribute("href", url.Action(action, controller, routeValues));
            anchorBuilder.InnerHtml = iHtml + spanHtml + smallHtml; // include the <img> tag inside
            var anchorHtml = anchorBuilder.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(anchorHtml);
        }

        public static MvcHtmlString ActionSlideParentMenu(this HtmlHelper html, string displayText, object iconAttributes,  object iconExtendAttributes) {
            var url = new UrlHelper(html.ViewContext.RequestContext);

            // build the <i> tag
            var iBuilder = new TagBuilder("i");
            iBuilder.MergeAttributes(new RouteValueDictionary(HtmlHelper.AnonymousObjectToHtmlAttributes(iconAttributes)));
            var iHtml = iBuilder.ToString(TagRenderMode.Normal);

            // build the <span> tag
            var spanBuilder = new TagBuilder("span");
            spanBuilder.SetInnerText(displayText);
            var spanHtml = spanBuilder.ToString(TagRenderMode.Normal);

            // build the <i> tag
            var ieBuilder = new TagBuilder("i");
            ieBuilder.MergeAttributes(new RouteValueDictionary(HtmlHelper.AnonymousObjectToHtmlAttributes(iconExtendAttributes)));
            var ieHtml = ieBuilder.ToString(TagRenderMode.Normal);

            // build the <a> tag
            var anchorBuilder = new TagBuilder("a");
            anchorBuilder.MergeAttribute("href", "javascript:void(0)");
            anchorBuilder.InnerHtml = iHtml + spanHtml + ieBuilder; // include the <img> tag inside
            var anchorHtml = anchorBuilder.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(anchorHtml);
        }

        public static MvcHtmlString ActionSiteMap(this HtmlHelper html, string action, string controller, object routeValues, string displayText, object iconAttributes) {
            var url = new UrlHelper(html.ViewContext.RequestContext);

            // build the <i> tag
            var iBuilder = new TagBuilder("i");
            iBuilder.MergeAttributes(new RouteValueDictionary(HtmlHelper.AnonymousObjectToHtmlAttributes(iconAttributes)));
            var iHtml = iBuilder.ToString(TagRenderMode.Normal);

            // build the <a> tag
            var anchorBuilder = new TagBuilder("a");
            anchorBuilder.MergeAttribute("href", url.Action(action, controller, routeValues));
            anchorBuilder.InnerHtml = iHtml + displayText; // include the <img> tag inside
            var anchorHtml = anchorBuilder.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(anchorHtml);
        }

        public static MvcHtmlString RenderGrowlMessage(this HtmlHelper html) {
            if (!html.ViewData.ModelState.IsValid) {
                var divBuilder = new TagBuilder("div");
                divBuilder.MergeAttribute("id", "growlMsg");
                divBuilder.MergeAttribute("class", "display-none");
                divBuilder.SetInnerText(html.ViewData.ModelState["ErrorMsg"].Errors[0].ErrorMessage);
                return MvcHtmlString.Create(divBuilder.ToString(TagRenderMode.Normal));
            }

            return MvcHtmlString.Empty;
        }
    }
}