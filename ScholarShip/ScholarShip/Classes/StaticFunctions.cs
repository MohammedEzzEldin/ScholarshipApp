using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScholarShip.Classes
{
    public static class StaticFunctions
    {
        public static SelectList ToSelectList(Dictionary<int, string> table)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (var item in table)
            {
                list.Add(new SelectListItem() { Text = item.Value, Value = item.Key.ToString() });
            }

            return new SelectList(list, "Value", "Text");
        }
    }
}