using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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

        public static bool IsMobilePhone(string input)
        {
            return !string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^1[3|4|5|8][0-9]\d{4,8}$");
        }

        public static bool IsPostalCode(string input)
        {
            int i = 0;
            return !string.IsNullOrEmpty(input) && input.Length == 6 && int.TryParse(input, out i);
        }

        public static bool IsCardNo(string input)
        {
            return !string.IsNullOrEmpty(input) && (Regex.IsMatch(input, @"^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$") 
                || Regex.IsMatch(input, @"^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{4}$"));
        }

        /// <summary>
        /// 数字转大写（零一二三四五六七八九十）
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string DateToUpper(DateTime datetime)
        {
            string result = string.Empty;
            Dictionary<string, string> map = new Dictionary<string, string>();
            map["0"] = "零";
            map["1"] = "一";
            map["2"] = "二";
            map["3"] = "三";
            map["4"] = "四";
            map["5"] = "五";
            map["6"] = "六";
            map["7"] = "七";
            map["8"] = "八";
            map["9"] = "九";
            foreach (var item in datetime.Year.ToString())
            {
                result += map[item.ToString()];
            }
            result += "年";
            if (datetime.Month < 10)
            {
                result += map[datetime.Month.ToString()] + "月";
            }
            else
            {
                result += "十" + map[datetime.Month.ToString()] + "月"; ;
            }
            if (datetime.Day < 10)
            {
                result += map[datetime.Day.ToString()] + "日";
            }
            else
            {
                if (datetime.Day == 10)
                {
                    result += "十日";
                }
                else
                {
                    result += map[datetime.Day.ToString()[0].ToString()] + "十" + map[datetime.Day.ToString()[1].ToString()] + "日";
                }
            }
            return result;
        }
    }
}
