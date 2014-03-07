using System;
using System.Text;
using System.Security.Cryptography;

namespace Tlw.ZPG.Infrastructure.Utils
{
    /// <summary>
    /// 生产随机密码的类
    /// </summary>
    public class RandomUtil
    {
        #region 私有字段

        private string exclusionSet;
        private bool hasConsecutive;
        private bool hasRepeating;
        private int maxSize;
        private int minSize;
        private bool isRanLength = true;
        private int length = 6;
        private char[] pwdCharArray = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
        private RNGCryptoServiceProvider rng;

        #endregion

        #region 方法

        /// <summary>
        /// 初始化实例
        /// </summary>
        public RandomUtil()
        {
            Init();
        }

        /// <summary>
        /// 初始化实例
        /// </summary>
        /// <param name="pwdCharArray">组成密码的字符串</param>
        public RandomUtil(string pwdCharArray)
        {
            this.pwdCharArray = pwdCharArray.ToCharArray();
            Init();
        }

        private void Init()
        {
            this.hasConsecutive = false;
            this.hasRepeating = true;
            this.exclusionSet = null;
            this.maxSize = 6;
            this.minSize = 6;
            rng = new RNGCryptoServiceProvider();

        }

        /// <summary>
        /// 获取随机长度
        /// </summary>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns></returns>
        protected int GetCryptographicRandomNumber(int min, int max)
        {
            // 假定 min >= 0 && min < max
            // 返回一个 int >= min and < max
            uint urndnum;
            byte[] rndnum = new Byte[4];

            if (min == max - 1 || min == max)
            {
                // 只有iBound返回的情况  
                return min;
            }

            uint xcludeRndBase = (uint.MaxValue - (uint.MaxValue % (uint)(max - min)));
            do
            {
                rng.GetBytes(rndnum);
                urndnum = System.BitConverter.ToUInt32(rndnum, 0);
            } while (urndnum >= xcludeRndBase);
            return (int)(urndnum % (max - min)) + min;
        }

        /// <summary>
        /// 获取随机字符
        /// </summary>
        /// <returns></returns>
        protected char GetRandomCharacter()
        {
            int upperBound = pwdCharArray.GetUpperBound(0);
            int randomCharPosition = GetCryptographicRandomNumber(pwdCharArray.GetLowerBound(0), upperBound);
            int maxLength = pwdCharArray.Length;
            if (randomCharPosition > maxLength - 1)
            {
                randomCharPosition = maxLength - 1;
            }
            char randomChar = pwdCharArray[randomCharPosition];
            return randomChar;
        }

        /// <summary>
        /// 生成随机密码
        /// </summary>
        /// <returns></returns>
        public string Generate()
        {
            if (isRanLength)//如果密码长度随机
            {
                // 得到minimum 和 maximum 之间随机的长度
                length = GetCryptographicRandomNumber(this.minSize, this.maxSize);
            }
            StringBuilder pwdBuffer = new StringBuilder();
            pwdBuffer.Capacity = this.maxSize;
            // 产生随机字符
            char lastCharacter;
            char nextCharacter;

            // 初始化标记
            lastCharacter = nextCharacter = '\n';

            for (int i = 0; i < length; i++)
            {
                nextCharacter = GetRandomCharacter();
                if (!this.hasConsecutive)
                {
                    while (lastCharacter == nextCharacter)
                    {
                        nextCharacter = GetRandomCharacter();
                    }
                }

                if (!this.hasRepeating)
                {
                    string temp = pwdBuffer.ToString();
                    int duplicateIndex = temp.IndexOf(nextCharacter);

                    while (-1 != duplicateIndex)
                    {
                        nextCharacter = GetRandomCharacter();
                        duplicateIndex = temp.IndexOf(nextCharacter);
                    }
                }

                if ((null != this.exclusionSet))
                {
                    while (-1 != this.exclusionSet.IndexOf(nextCharacter))
                    {
                        nextCharacter = GetRandomCharacter();
                    }
                }
                pwdBuffer.Append(nextCharacter);
                lastCharacter = nextCharacter;
            }


            if (null != pwdBuffer)
            {
                return pwdBuffer.ToString();
            }
            else
            {
                return String.Empty;
            }
        }

        #endregion

        #region 公共属性

        /// <summary>
        /// 密码长度，默认为6
        /// </summary>
        public int Length
        {
            set
            {
                length = value;
                isRanLength = false;
            }
        }

        /// <summary>
        /// 字符是否连续
        /// </summary>
        public bool IsSequence
        {
            set
            {
                this.hasConsecutive = value;
            }
        }

        /// <summary>
        /// 要排除的密码字符
        /// </summary>
        public string ExcludeChar
        {
            set
            {
                this.exclusionSet = value;
            }
        }

        /// <summary>
        /// 生成密码的最大长度
        /// </summary>
        public int MaxLength
        {
            set
            {
                if (value > minSize)
                {
                    this.maxSize = value;
                }
            }
        }

        /// <summary>
        /// 生成密码的最小长度
        /// </summary>
        public int MinLength
        {
            set
            {
                if (value < maxSize)
                {
                    this.minSize = value;
                }
            }
        }

        /// <summary>
        /// 字符是否重复
        /// </summary>
        public bool IsRepeat
        {
            set
            {
                this.hasRepeating = value;
            }
        }

        #endregion

    }

}
