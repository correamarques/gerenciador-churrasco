using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace ChurrascoManager.Helpers
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString DropDownList(this HtmlHelper html, string name, IEnumerable<SelectListItem> selectList, object htmlAttributes, bool canEdit )
        {
            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            if (!canEdit)
                attributes.Add("disabled", "disabled");

            return html.DropDownList(name, selectList, attributes);
        }

    }
}