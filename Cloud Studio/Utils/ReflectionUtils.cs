using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CloudStudio.GUI.Utils
{
    public static class ReflectionUtils
    {

        public static IList<string> GetProperties(Object obj)
        {

            IList<string> properties = new List<String>();

            PropertyInfo[] props = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            for (int i = 0; i < props.Length; i++)
            {
                //if (props[i].PropertyType == typeof(string) && props[i].CanWrite)
                {
                    // Do something with the props[i].
                    properties.Add(props[i].Name);
                }
            }

            return properties;

        }

        public static Object GetPropValue(this Object obj, String name)
        {
            foreach (String part in name.Split('.')) {

                if (obj == null) { return null; }

                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(part);
                if (info == null) { return null; }

                obj = info.GetValue(obj, null);
            }
            return obj;
        }

    }
}
