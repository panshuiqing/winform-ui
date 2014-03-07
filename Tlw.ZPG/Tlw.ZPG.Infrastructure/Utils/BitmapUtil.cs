using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Tlw.ZPG.Infrastructure.Utils
{
    /// <summary>
    /// 可以生成验证码图像的类
    /// </summary>
    public class BitmapUtil
    {
        #region 私有变量
        private int fontSize = 14;//字体大小
        private int offsetX;
        private int offsetY;
        private Color bgColor = Color.Empty;
        private Color borderColor = Color.Empty;
        private ImageFormat imageFormat = ImageFormat.Png;
        private Color foreColor = Color.White;

        #endregion

        #region 公共属性

        /// <summary>
        /// 获取或设置字符颜色，当IsRandomforeColor属性为true的时候，该属性则无效
        /// </summary>
        public Color ForeColor
        {
            get
            {
                return foreColor;
            }
            set
            {
                foreColor = value;
            }
        }

        /// <summary>
        /// 字符颜色是否随机，为true，则foreColor属性无效
        /// </summary>
        public bool IsRandomColor { get; set; }

        /// <summary>
        /// 设置X轴偏移量
        /// </summary>
        public int OffsetX
        {
            set
            {
                offsetX = value;
            }
        }

        /// <summary>
        /// 设置Y轴偏移量
        /// </summary>
        public int OffsetY
        {
            set
            {
                offsetY = value;
            }
        }

        /// <summary>
        /// 设置图像文件格式，默认为Png格式
        /// </summary>
        public ImageFormat ImageFormat
        {
            set
            {
                imageFormat = value;
            }
        }

        /// <summary>
        /// 设置图像背景色
        /// </summary>
        public Color BgColor
        {
            set
            {
                this.bgColor = value;
            }
        }

        /// <summary>
        /// 设置边框颜色
        /// </summary>
        public Color BorderColor
        {
            set
            {
                this.borderColor = value;
            }
        }

        /// <summary>
        /// 设置字体大小
        /// </summary>
        public int FontSize
        {
            set { fontSize = value; }
        }

        #endregion


        /// <summary>
        /// 生成验证码输出流
        /// </summary>
        /// <returns></returns>
        public MemoryStream OutputStream(string code)
        {
            return OutputStream(GetBitmap(code));
        }

        /// <summary>
        /// 生成验证码输出流
        /// </summary>
        /// <returns></returns>
        public MemoryStream OutputStream(Bitmap map)
        {
            MemoryStream memoryStream = new MemoryStream();
            if (map != null)
            {
                map.Save(memoryStream, imageFormat);//保存到流
            }
            return memoryStream;
        }

        //生成随机颜色
        private System.Drawing.Color GetRandomColor()
        {
            Random redRandom = new Random((int)DateTime.Now.Ticks);
            System.Threading.Thread.Sleep(redRandom.Next(50));
            Random greenRandom = new Random((int)DateTime.Now.Ticks);
            System.Threading.Thread.Sleep(greenRandom.Next(50));
            Random blueRandom = new Random((int)DateTime.Now.Ticks);

            int red = redRandom.Next(256);
            int green = greenRandom.Next(256);
            int blue = blueRandom.Next(256);

            return System.Drawing.Color.FromArgb(red, green, blue);
        }

        /// <summary>
        /// 初始化验证码图像
        /// </summary>
        /// <returns></returns>
        public Bitmap GetBitmap(string code)
        {
            Bitmap bitmap = null;
            if (!string.IsNullOrEmpty(code))
            {
                int int_ImageWidth = code.Length * fontSize;//计算图像宽度
                Random newRandom = new Random();
                Font theFont = new Font("Arial", fontSize);//默认14px的字体
                float hight = theFont.GetHeight();//字体高度
                bitmap = new System.Drawing.Bitmap(int_ImageWidth + offsetX, (int)hight + offsetY);//默认图高为字体高度
                using (System.Drawing.Graphics theGraphics = System.Drawing.Graphics.FromImage(bitmap))
                {
                    //设置背景色
                    theGraphics.Clear(bgColor);
                    //画矩形边框
                    theGraphics.DrawRectangle(new Pen(borderColor, 1), 0, 0, int_ImageWidth + offsetX - 2, hight + offsetY - 2);

                    //画每个字符
                    for (int int_index = 0; int_index < code.Length; int_index++)
                    {
                        string str_char = code[int_index].ToString();
                        //字符颜色
                        Brush newBrush = null;
                        if (IsRandomColor)
                        {
                            newBrush = new SolidBrush(GetRandomColor());
                        }
                        else
                        {
                            newBrush = new SolidBrush(foreColor);
                        }
                        //字符位置随机
                        Point thePos = new Point(int_index * (fontSize - 1) + newRandom.Next(offsetX), newRandom.Next(offsetY));
                        theGraphics.DrawString(str_char, theFont, newBrush, thePos);
                    }
                }
            }
            return bitmap;
        }
    }
}
