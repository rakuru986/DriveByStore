﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Projekt.Pages.Extensions {

    public static class DropDownNavigationMenuForHtmlExtension {

        internal static void addDropDownMenuItem(List<object> htmlStrings, Link item) {
            if (htmlStrings is null) return;
            if (item is null) return;
            var s = $"<a class='dropdown-item text-dark' href=\"{item.Url}\">{item.DisplayName}</a>";
            htmlStrings.Add(new HtmlString(s));
        }

        internal static void beginDropDownNavigationMenu(List<object> htmlStrings, string name) {
            if (htmlStrings is null) return;
            htmlStrings.Add(new HtmlString("<li class=\"nav-item dropdown\">"));
            htmlStrings.Add(new HtmlString(
                "<a class=\"nav-link text-dark dropdown-toggle\" href=\"#\" id=\"navbardrop\" data-toggle=\"dropdown\">"));
            htmlStrings.Add(new HtmlString(name));
            htmlStrings.Add(new HtmlString("</a>"));
            htmlStrings.Add(new HtmlString("<div class=\"dropdown-menu\">"));
        }

        internal static void endDropDownNavigationMenu(List<object> htmlStrings) {
            if (htmlStrings is null) return;
            htmlStrings.Add(new HtmlString("</div>"));
            htmlStrings.Add(new HtmlString("</li>"));
        }

        public static IHtmlContent
            DropDownNavigationMenuFor(this IHtmlHelper helper, string name, params Link[] items) {
            var strings = htmlStrings(name, items);

            return new HtmlContentBuilder(strings);
        }

        internal static List<object> htmlStrings(string name, params Link[] items) {
            var list = new List<object>();
            beginDropDownNavigationMenu(list, name);
            foreach (var item in items) addDropDownMenuItem(list, item);
            endDropDownNavigationMenu(list);

            return list;
        }

    }

}
