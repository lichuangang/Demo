using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hx.Extend
{
    public static class ObjectExtend
    {
        public static T CopyTo<T>(this object source, T target = null)
            where T : class,new()
        {
            if (source == null)
                return null;

            if (target == null)
            {
                target = new T();
            }

            foreach (var property in target.GetType().GetProperties())
            {
                //跳过没有的属性
                if (source.GetType().GetProperty(property.Name) == null) continue;

                var propertyValue = source.GetType().GetProperty(property.Name).GetValue(source, null);
                if (propertyValue != null)
                {
                    if (propertyValue.GetType().IsClass)
                    {

                    }
                    target.GetType().InvokeMember(property.Name, BindingFlags.SetProperty, null, target, new object[] { propertyValue });
                }

            }

            foreach (var field in target.GetType().GetFields())
            {
                if (source.GetType().GetProperty(field.Name) == null) continue;

                var fieldValue = source.GetType().GetField(field.Name).GetValue(source);
                if (fieldValue != null)
                {
                    target.GetType().InvokeMember(field.Name, BindingFlags.SetField, null, target, new object[] { fieldValue });
                }
            }

            return target;
        }
    }
}
