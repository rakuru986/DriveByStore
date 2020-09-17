﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Projekt.Pages.Extensions
{
    public static class DisabledControlsForHtmlExtension
    {
        public static IHtmlContent DisabledControlsFor<TClassType, TPropertyType>(this IHtmlHelper<TClassType> htmlHelper,
            Expression<Func<TClassType, TPropertyType>> expression)
        {
            var s = htmlStrings(htmlHelper, expression);

            return new HtmlContentBuilder(s);
        }

        internal static List<object> htmlStrings<TClassType, TPropertyType>(IHtmlHelper<TClassType> htmlHelper,
            Expression<Func<TClassType, TPropertyType>> expression)
        {
            return new List<object>
            {
                new HtmlString("<div class=\"form-group\">"),
                new HtmlString("<fieldset disabled>"),
                htmlHelper.LabelFor(expression, new {@class = "text-dark"}),
                htmlHelper.EditorFor(expression,
                    new {htmlAttributes = new {@class = "form-control"}}),
                htmlHelper.ValidationMessageFor(expression, "", new {@class = "text-danger"}),
                new HtmlString("</fieldset>"),
                new HtmlString("</div>")
            };
        }
    }
}