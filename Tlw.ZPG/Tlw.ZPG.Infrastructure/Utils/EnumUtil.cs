using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Tlw.ZPG.Infrastructure.Utils
{
    /// <summary>
    /// 处理枚举工具类
    /// </summary>
    public sealed class EnumUtil
    {
        /// <summary>
        /// 获取枚举DescriptionAttribute属性值
        /// </summary>
        /// <param name="e">枚举值</param>
        /// <returns></returns>
        public static string GetDescription(Enum e)
        {
            var attr = e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attr != null && attr.Length > 0) ? (attr[0] as DescriptionAttribute).Description : null;
        }

        /// <summary>
        /// 获取枚举DescriptionAttribute属性值
        /// </summary>
        /// <param name="value">枚举名称或值</param>
        /// <returns></returns>
        public static string GetDescription<T>(string value)
        {
            if (!typeof(T).IsEnum) throw new InvalidEnumArgumentException("泛型T不是枚举类型");
            return GetDescription((Enum)Enum.Parse(typeof(T), value));
        }

        public static T ToEnum<T>(string name)
        {
            return (T)Enum.Parse(typeof(T), name);
        }
    }
}
