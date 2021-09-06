using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilTechsGame.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value, bool nameInstead = true)
        {
            if (value == null)
            {
                return null;
            }

            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name == null)
            {
                return null;
            }

            DescriptionAttribute descriptionAttribute = Attribute.GetCustomAttribute(type.GetField(name), typeof(DescriptionAttribute)) as DescriptionAttribute;
            if (descriptionAttribute == null && nameInstead)
            {
                return name;
            }

            return descriptionAttribute?.Description;
        }
    }
}
