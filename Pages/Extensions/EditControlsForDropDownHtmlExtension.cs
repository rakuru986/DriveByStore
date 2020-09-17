﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Projekt.Pages.Extensions
{
    public static class EditControlsForDropDownHtmlExtension
    {
        public static IHtmlContent EditControlsForDropDown<TModel, TResult>(
            this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression,
            IEnumerable<SelectListItem> items) {

            var htmlStrings = EditControlsForDropDownHtmlExtension.htmlStrings(htmlHelper, expression, items);

            return new HtmlContentBuilder(htmlStrings);
        }

        internal static List<object> htmlStrings<TModel, TResult>(IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, IEnumerable<SelectListItem> items) {
            return new List<object> {
                new HtmlString("<div class=\"form-group\">"),
                htmlHelper.LabelFor(expression, new {@class = "text-dark"}),
                htmlHelper.DropDownListFor(expression, items, new {@class = "form-control"}),
                htmlHelper.ValidationMessageFor(expression, "", new {@class = "text-danger"}),
                new HtmlString("</div>")
            };
        }

    }
}
