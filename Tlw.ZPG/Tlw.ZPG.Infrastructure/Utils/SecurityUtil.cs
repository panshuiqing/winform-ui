using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Tlw.ZPG.Infrastructure.Utils
{
    public class SecurityUtil
    {
        #region md5
        public static string MD5Encrypt(string value)
        {
            System.Security.Cryptography.MD5 md5Hasher = System.Security.Cryptography.MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.GetEncoding("UTF-8").GetBytes(value));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        } 
        #endregion

        #region Base64
        /// <summary>
        /// Base64编码
        /// </summary>
        /// <param name="value">要编码的字符串</param>
        /// <param name="encodeName">utf-8</param>
        /// <returns></returns>
        public static string EncodeBase64(string value, Encoding encoding)
        {
            byte[] bytes = encoding.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// Base64编码
        /// </summary>
        /// <param name="value">要编码的字符串</param>
        /// <param name="encodeName">utf-8</param>
        /// <returns></returns>
        public static string EncodeBase64(string value)
        {
            return EncodeBase64(value, Encoding.UTF8);
        }

        /// <summary>
        /// Base64解码
        /// </summary>
        /// <param name="value">要解码的字符串</param>
        /// <param name="encoding">utf-8</param>
        /// <returns></returns>
        public static string DecodeBase64(string value, Encoding encoding)
        {
            byte[] bytes = Convert.FromBase64String(value);
            return encoding.GetString(bytes);
        }

        /// <summary>
        /// Base64解码
        /// </summary>
        /// <param name="value">要解码的字符串</param>
        /// <param name="encoding">utf-8</param>
        /// <returns></returns>
        public static string DecodeBase64(string value)
        {
            return DecodeBase64(value, Encoding.UTF8);
        }
        #endregion

        #region SHA1散列加密+Base64
        /// <summary>
        /// SHA1散列加密+Base64
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SHA1Hash(string value, Encoding encoding)
        {
            //SHA1散列加密
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] bytes = encoding.GetBytes(value);
            byte[] hash = sha1.ComputeHash(bytes);

            //Base64
            string base64 = Convert.ToBase64String(hash);
            return base64;
        }

        /// <summary>
        /// SHA1散列加密+Base64
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SHA1Hash(string value)
        {
            return SHA1Hash(value, System.Text.Encoding.UTF8);
        }
        #endregion

        #region 3des加密 + base64
        /// <summary>
        /// base64+3des加密
        /// </summary>
        /// <param name="sSrc">需加密串</param>
        /// <param name="sKey">密钥</param>
        /// <param name="code">字符集</param>
        /// <returns></returns>
        public static string EncryptTriDes(string value, string key, Encoding encoding)
        {
            //3DES加密
            TripleDES des = TripleDES.Create();
            des.Key = HexToByte(key);
            des.IV = GetIVBytes();
            ICryptoTransform icry = des.CreateEncryptor();
            Byte[] input = encoding.GetBytes(value);
            Byte[] output = icry.TransformFinalBlock(input, 0, input.Length);

            //Base64编码
            string base64 = Convert.ToBase64String(output);
            return base64;
        }

        /// <summary>
        /// base64+3des加密
        /// </summary>
        /// <param name="sSrc">需加密串</param>
        /// <param name="sKey">密钥</param>
        /// <param name="code">字符集</param>
        /// <returns></returns>
        public static string EncryptTriDes(string value, string key)
        {
            return EncryptTriDes(value, key, System.Text.Encoding.UTF8);
        }
        #endregion

        #region 3des解密 + base64

        /// <summary>
        /// base64+3des解密
        /// </summary>
        /// <param name="sSrc">需解密串</param>
        /// <param name="sKey">密钥</param>
        /// <param name="code"> 字符集</param>
        /// <returns></returns>
        public static string DecryptTriDes(string value, string key, Encoding encoding)
        {
            //3DES加密
            TripleDES des = TripleDES.Create();
            des.Key = HexToByte(key);
            des.IV = GetIVBytes(); ;
            ICryptoTransform icry = des.CreateDecryptor();

            //Base64解码
            Byte[] base64bytes = Convert.FromBase64String(value);

            Byte[] bytes = icry.TransformFinalBlock(base64bytes, 0, base64bytes.Length);

            return encoding.GetString(bytes);
        }

        /// <summary>
        /// base64+3des解密
        /// </summary>
        /// <param name="sSrc">需解密串</param>
        /// <param name="sKey">密钥</param>
        /// <param name="code"> 字符集</param>
        /// <returns></returns>
        public static string DecryptTriDes(string value, string key)
        {
            return DecryptTriDes(value, key, System.Text.Encoding.UTF8);
        }
        #endregion

        #region 16进制转为字节数组
        /// <summary>
        /// 16进制转为字节数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static byte[] HexToByte(string value)
        {
            //16进制转为字节数组
            byte[] bytes = new byte[value.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(value.Substring(i * 2, 2), 16);
            }
            return bytes;
        }
        #endregion

        #region base64+3des+sha1校验串
        /// <summary>
        /// base64+3des+sha1校验串
        /// </summary>
        /// <param name="a_strString">需加密源串</param>
        /// <param name="sKey">密钥</param>
        /// <returns></returns>
        public static string GeneratorAuther(string value, string key, Encoding encoding)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            Byte[] bytes = encoding.GetBytes(value);
            Byte[] hash = sha1.ComputeHash(bytes);

            //3DES加密
            TripleDES des = TripleDES.Create();
            des.Key = HexToByte(key);
            des.IV = GetIVBytes();
            ICryptoTransform icry = des.CreateEncryptor();
            Byte[] output1 = icry.TransformFinalBlock(hash, 0, hash.Length);

            //Base64编码
            String md5base64 = Convert.ToBase64String(output1);
            return md5base64;

        }

        /// <summary>
        /// base64+3des+sha1校验串
        /// </summary>
        /// <param name="a_strString">需加密源串</param>
        /// <param name="sKey">密钥</param>
        /// <returns></returns>
        public static string GeneratorAuther(string value, string key)
        {
            return GeneratorAuther(value, key, System.Text.Encoding.UTF8);
        }
        #endregion

        #region IV
        /// <summary>
        /// 获取3des加解密密的向量数组
        /// </summary>
        /// <returns></returns>
        private static Byte[] GetIVBytes()
        {
            string IV = "12345678";
            return Encoding.UTF8.GetBytes(IV);
        }
        #endregion
    }
}
