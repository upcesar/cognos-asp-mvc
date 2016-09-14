using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cognossystem_testes.Models;
using System.ComponentModel.DataAnnotations;

namespace cognossystem_testes.Helpers
{
    public static class Miscellaneous
    {
        public static string GetStatusName(Status value)
        {
            // Get the MemberInfo object for supplied enum value
            var memberInfo = value.GetType().GetMember(value.ToString());
            if (memberInfo.Length != 1)
                return null;

            // Get DisplayAttibute on the supplied enum value
            var displayAttribute = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false)
                                   as DisplayAttribute[];

            if (displayAttribute != null && displayAttribute.Length > 0)                
                return displayAttribute[0].Name;

            // Get Name on the supplied enum value
            var displayName = memberInfo[0].Name;

            if (displayName != null && displayName.Length > 0)
                return displayName;

            return null;

        }

        public static IEnumerable<SelectListItem> GetStatusSelectListItems(string selectedValue = null)
        {
            var selectList = new List<SelectListItem>();

            // Get all values of the Industry enum
            var enumValues = Enum.GetValues(typeof(Status)) as Status[];
            if (enumValues == null)
                return null;

            foreach (var enumValue in enumValues)
            {
                // Create a new SelectListItem element and set its 
                // Value and Text to the enum value and description.
                selectList.Add(new SelectListItem
                {
                    Value = enumValue.ToString(),
                    // GetIndustryName just returns the Display.Name value
                    // of the enum - check out the next chapter for the code of this function.
                    Text = GetStatusName(enumValue),

                    Selected = enumValue.ToString() == selectedValue
                });
            }

            return selectList;
        }

        public static T ParseEnum<T>(string value, T defaultValue)
        {
            return value != null ?
                         (T)Enum.Parse(typeof(T), value, true) : 
                         defaultValue;

        }
    }
}