using Medical.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Medical.Helper
{
    public static class EnumHelper
    {
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field?.GetCustomAttributes(typeof(DescriptionAttribute), false)
                                  .FirstOrDefault() as DescriptionAttribute;
            return attribute?.Description ?? value.ToString();
        }

        public static IEnumerable<KeyAndValue> GetEnumKeyAndValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T))
                       .Cast<T>()
                       .Select(e => new KeyAndValue
                       {
                           Key = Convert.ToInt32(e),
                           Value = e.GetDescription()
                       })
                       .ToList();
        }
    }
}
