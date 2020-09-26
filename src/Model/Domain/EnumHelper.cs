using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.Reflection;
using System.ComponentModel;
using Simple;

namespace Locadora.Domain
{
    public static class EnumHelper
    {
        public static string Description(this Enum value)
        {
            var attr = AttributeCache.Do.First<DescriptionAttribute>(
                value.GetType().GetField(Enum.GetName(value.GetType(), value)));
            if (attr != null) return attr.Description;
            else return null;
        }

        public static IEnumerable<T> ListAll<T>()
        {
            return Enum.GetValues(typeof(T).GetValueTypeIfNullable()).Cast<T>();
        }
    }
}
