using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tlw.ZPG.Infrastructure.Utils
{
    public static class StringUtil
    {
        public static bool StringArrayEquals(string[] a, string[] b)
        {
            if ((a == null) != (b == null))
            {
                return false;
            }
            if (a != null)
            {
                return string.Compare(string.Join("", a), string.Join("", b)) == 0;
            }
            return true;
        }

        /// <summary>
        /// 删除指定字段字符串末尾部分的字符串
        /// </summary>
        /// <param name="input">输入</param>
        /// <param name="trimString">要删除的字符串</param>
        /// <returns></returns>
        public static string TrimEnd(string input, string trimString)
        {
            return System.Text.RegularExpressions.Regex.Replace(input, @"(" + trimString + ")*$", "");
        }

        ///<summary>
        /// 删除指定字符串前面部分字符串
        ///</summary>
        /// <param name="input">输入</param>
        /// <param name="trimString">要删除的字符串</param>
        ///<returns></returns>
        public static string TrimStart(string input, string trimString)
        {
            return System.Text.RegularExpressions.Regex.Replace(input, @"^(" + trimString + ")*", "");
        }

        public static string Left(string input, int length)
        {
            if (string.IsNullOrEmpty(input) || length <= 0 || input.Length <= length) return input;
            return input.Substring(0, length);
        }

        public static string Right(string input, int length)
        {
            if (string.IsNullOrEmpty(input) || length <= 0 || input.Length <= length) return input;
            return input.Substring(input.Length - length);
        }
    }
}
