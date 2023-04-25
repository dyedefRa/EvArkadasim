using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvArkadasim.Web.Helpers
{
    public static class EnumMvcHelper
    {
        public static List<SelectListItem> GetEnumSelectList<T>() where T : Enum
        {
            return (Enum.GetValues(typeof(T)).Cast<int>().Select(e => new SelectListItem() { Text = Enum.GetName(typeof(T), e), Value = e.ToString() })).ToList();
        }
    }
}
