using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Globalization;
using System.ComponentModel;
using System.Collections;

namespace Tlw.ZPG.Infrastructure.Utils
{

    internal abstract class ReflectBase
    {
        protected BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.IgnoreCase;
        protected readonly char[] expressionPartSeparator = new char[] { '.' };

        protected abstract object GetValueByName(object obj, string name);

        protected abstract void SetValueByName(object obj, string name, object value);

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="expression">属性表达式，例如：Item.Name</param>
        /// <returns></returns>
        internal object GetValue(object obj, string expression)
        {
            if (string.IsNullOrEmpty(expression))
            {
                throw new ArgumentNullException("expression");
            }

            if (obj == null)
            {
                return null;
            }
            string[] expressionParts = expression.Split(expressionPartSeparator);
            return GetValue(obj, expressionParts);
        }

        /// <summary>
        /// 获取属性值，并格式化
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="expression"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        internal string GetValue(object obj, string expression, string format)
        {
            object obj2 = GetValue(obj, expression);
            return FormatValue(obj2, format);
        }

        private string GetValueByName(object obj, string propName, string format)
        {
            object value = GetValueByName(obj, propName);
            return FormatValue(value, format);
        }

        private object GetValue(object obj, string[] expressionParts)
        {
            object value = obj;
            for (int i = 0; (i < expressionParts.Length) && (value != null); i++)
            {
                string propName = expressionParts[i];
                value = GetValueByName(value, propName);
            }
            return value;
        }

        protected string FormatValue(object value, string format)
        {
            if ((value == null) || (value == DBNull.Value))
            {
                return string.Empty;
            }
            if (string.IsNullOrEmpty(format))
            {
                return value.ToString();
            }
            return string.Format(format, value);
        }

        internal void SetValue(object obj, string expression, object value)
        {
            if (string.IsNullOrEmpty(expression))
            {
                throw new ArgumentNullException("expression");
            }
            if (obj == null)
            {
                return;
            }
            string[] expressionParts = expression.Split(expressionPartSeparator);
            DoSetValue(obj, expressionParts, value);
        }

        private void DoSetValue(object obj, string[] expressionParts, object value)
        {
            object current = null;
            string name = string.Empty;
            object container = null;
            if (expressionParts.Length == 1)
            {
                name = expressionParts[0];
                SetValueByName(obj, name, value);
            }
            else
            {
                current = obj;
                container = obj;
                for (int i = 0; (i < expressionParts.Length) && (current != null); i++)
                {
                    name = expressionParts[i];
                    if (i > 0)
                    {
                        //保存上一次的对象
                        container = current;
                    }
                    current = GetValueByName(current, name);
                }
                if (container != null)
                {
                    SetValueByName(container, name, value);
                }
            }
        }
    }

    internal class PropertyReflect : ReflectBase
    {
        protected override object GetValueByName(object obj, string propName)
        {
            PropertyInfo propertyInfo = GetPropertyInfo(obj, propName);
            return propertyInfo.GetValue(obj, null);
        }

        protected override void SetValueByName(object obj, string propName, object value)
        {
            PropertyInfo propertyInfo = GetPropertyInfo(obj, propName);
            propertyInfo.SetValue(obj, value, null);
        }

        private PropertyInfo GetPropertyInfo(object obj, string propName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }
            if (string.IsNullOrEmpty(propName))
            {
                throw new ArgumentNullException("propName");
            }
            PropertyInfo propertyInfo = obj.GetType().GetProperty(propName, flags);
            if (propertyInfo == null)
            {
                throw new ArgumentNullException("找不到属性，" + obj.GetType().FullName + "." + propName);
            }
            return propertyInfo;
        }
    }

    internal class FieldReflect : ReflectBase
    {
        protected override object GetValueByName(object obj, string fieldName)
        {
            FieldInfo fieldInfo = GetFieldInfo(obj, fieldName);
            return fieldInfo.GetValue(obj);
        }

        protected override void SetValueByName(object obj, string fieldName, object value)
        {
            FieldInfo fieldInfo = GetFieldInfo(obj, fieldName);
            fieldInfo.SetValue(obj, value);
        }

        private FieldInfo GetFieldInfo(object obj, string fieldName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }
            if (string.IsNullOrEmpty(fieldName))
            {
                throw new ArgumentNullException("fieldName");
            }
            FieldInfo fieldInfo = obj.GetType().GetField(fieldName, flags);
            if (fieldInfo == null)
            {
                throw new ArgumentNullException("找不到属性，" + obj.GetType().FullName + "." + fieldName);
            }
            return fieldInfo;
        }
    }

    public class ReflectUtil
    {

        private static readonly ReflectBase propertyReflect = new PropertyReflect();
        private static readonly ReflectBase fieldReflect = new FieldReflect();

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="expression">属性表达式，例如：Item.Name</param>
        /// <returns></returns>
        public static object GetPropertyValue(object obj, string expression)
        {
            return propertyReflect.GetValue(obj, expression);
        }

        /// <summary>
        /// 获取属性值，并格式化
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="expression"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string GetPropertyValue(object obj, string expression, string format)
        {
            return propertyReflect.GetValue(obj, expression, format);
        }

        public static void SetPropertyValue(object obj, string expression, object value)
        {
            propertyReflect.SetValue(obj, expression, value);
        }

        public static object GetFieldValue(object obj, string expression)
        {
            return fieldReflect.GetValue(obj, expression);
        }

        /// <summary>
        /// 获取属性值，并格式化
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="expression"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string GetFieldValue(object obj, string expression, string format)
        {
            return fieldReflect.GetValue(obj, expression, format);
        }

        public static void SetFieldValue(object obj, string expression, object value)
        {
            fieldReflect.SetValue(obj, expression, value);
        }
    }
}
