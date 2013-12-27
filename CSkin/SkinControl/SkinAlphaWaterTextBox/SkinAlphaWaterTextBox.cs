/********************************************************************
 * *
 * * 使本项目源码或本项目生成的DLL前请仔细阅读以下协议内容，如果你同意以下协议才能使用本项目所有的功能，
 * * 否则如果你违反了以下协议，有可能陷入法律纠纷和赔偿，作者保留追究法律责任的权利。
 * *
 * * 1、你可以在开发的软件产品中使用和修改本项目的源码和DLL，但是请保留所有相关的版权信息。
 * * 2、不能将本项目源码与作者的其他项目整合作为一个单独的软件售卖给他人使用。
 * * 3、不能传播本项目的源码和DLL，包括上传到网上、拷贝给他人等方式。
 * * 4、以上协议暂时定制，由于还不完善，作者保留以后修改协议的权利。
 * *
 * * Copyright (C) 2013-? cskin Corporation All rights reserved.
 * * 网站：CSkin界面库 http://www.cskin.net
 * * 作者： 乔克斯 QQ：345015918 .Net项目技术组群：306485590
 * * 请保留以上版权信息，否则作者将保留追究法律责任。
 * *
 * * 创建时间：2013-12-08
 * * 说明：SkinAlphaWaterTextBox.cs
 * *
********************************************************************/

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Imaging;
using CCWin.Win32;
using CCWin.Win32.Const;
using CCWin.SkinClass;

namespace CCWin.SkinControl
{
    [ToolboxBitmap(typeof(TextBox))]
    public class SkinAlphaWaterTextBox : System.Windows.Forms.TextBox
    {
        #region 私有变量
        private uPictureBox myPictureBox;
        private bool myUpToDate = false;
        private bool myCaretUpToDate = false;
        private Bitmap myBitmap;
        private Bitmap myAlphaBitmap;
        private int myFontHeight = 10;
        private System.Windows.Forms.Timer myTimer1;
        private bool myCaretState = true;
        private bool myPaintedFirstTime = false;
        private Color myBackColor = Color.White;
        private int myBackAlpha = 10;
        #endregion

        #region 无参构造函数与重载事件

        public SkinAlphaWaterTextBox()
        {
            this.Font = CCWin.Localization.Localizer.DefaultFont;
            InitializeComponent();

            this.BackColor = myBackColor;

            this.SetStyle(ControlStyles.UserPaint, false);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);


            myPictureBox = new uPictureBox();
            this.Controls.Add(myPictureBox);
            myPictureBox.Dock = DockStyle.Fill;
            BorderStyle = BorderStyle.None;
        }


        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.myBitmap = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);//(this.Width,this.Height);
            this.myAlphaBitmap = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);//(this.Width,this.Height);
            myUpToDate = false;
            this.Invalidate();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            myUpToDate = false;
            this.Invalidate();
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            myUpToDate = false;
            this.Invalidate();

        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            myUpToDate = false;
            this.Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.Invalidate();
        }

        protected override void OnGiveFeedback(GiveFeedbackEventArgs gfbevent)
        {
            base.OnGiveFeedback(gfbevent);
            myUpToDate = false;
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            Point ptCursor = Cursor.Position;

            Form f = this.FindForm();
            ptCursor = f.PointToClient(ptCursor);
            if (!this.Bounds.Contains(ptCursor))
                base.OnMouseLeave(e);

        }

        protected override void OnChangeUICues(UICuesEventArgs e)
        {
            base.OnChangeUICues(e);
            myUpToDate = false;
            this.Invalidate();
        }


        //--
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            myCaretUpToDate = false;
            myUpToDate = false;
            this.Invalidate();


            myTimer1 = new System.Windows.Forms.Timer();
            myTimer1.Interval = (int)NativeMethods.GetCaretBlinkTime(); //  usually around 500;

            myTimer1.Tick += new EventHandler(myTimer1_Tick);
            myTimer1.Enabled = true;

        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            myCaretUpToDate = false;
            myUpToDate = false;
            this.Invalidate();

            myTimer1.Dispose();
        }

        //--		

        protected override void OnFontChanged(EventArgs e)
        {
            if (this.myPaintedFirstTime)
                this.SetStyle(ControlStyles.UserPaint, false);

            base.OnFontChanged(e);

            if (this.myPaintedFirstTime)
                this.SetStyle(ControlStyles.UserPaint, true);


            myFontHeight = GetFontHeight();


            myUpToDate = false;
            this.Invalidate();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            myUpToDate = false;
            this.Invalidate();
        }


        protected override void WndProc(ref Message m)
        {

            base.WndProc(ref m);

            if (m.Msg == WM.WM_PAINT)
            {
                myPaintedFirstTime = true;

                if (!myUpToDate || !myCaretUpToDate)
                    GetBitmaps();
                myUpToDate = true;
                myCaretUpToDate = true;

                if (myPictureBox.Image != null) myPictureBox.Image.Dispose();
                myPictureBox.Image = (Image)myAlphaBitmap.Clone();

            }

            else if (m.Msg == WM.WM_HSCROLL || m.Msg == WM.WM_VSCROLL)
            {
                myUpToDate = false;
                this.Invalidate();
            }

            else if (m.Msg == WM.WM_LBUTTONDOWN
                || m.Msg == WM.WM_RBUTTONDOWN
                || m.Msg == WM.WM_LBUTTONDBLCLK
                //  || m.Msg == win32.WM_MOUSELEAVE  ///****
                )
            {
                myUpToDate = false;
                this.Invalidate();
            }

            else if (m.Msg == WM.WM_MOUSEMOVE)
            {
                if (m.WParam.ToInt32() != 0)  //shift key or other buttons
                {
                    myUpToDate = false;
                    this.Invalidate();
                }
            }
        }

        #endregion

        #region 属性
        /// <summary>
        /// 用于显示水印文字的字体
        /// </summary>
        private Font _waterFont = new Font(CCWin.Localization.Localizer.DefaultFont.FontFamily, 8.5f);
        [Description("用于显示水印文本的字体"), Category("Skin")]
        public Font WaterFont
        {
            get { return this._waterFont; }
            set
            {
                this._waterFont = value;
                myUpToDate = false;
                base.Invalidate();
            }
        }

        /// <summary>
        /// 水印文字
        /// </summary>
        private string _waterText = string.Empty;
        [Description("水印文字"), Category("Skin")]
        public string WaterText
        {
            get { return this._waterText; }
            set
            {
                this._waterText = value;
                myUpToDate = false;
                base.Invalidate();
            }
        }

        /// <summary>
        /// 水印文字的颜色
        /// </summary>
        private Color _waterColor = Color.FromArgb(127, 127, 127);
        [Description("水印的颜色"), Category("Skin")]
        public Color WaterColor
        {
            get { return this._waterColor; }
            set
            {
                this._waterColor = value;
                myUpToDate = false;
                base.Invalidate();
            }
        }

        public new BorderStyle BorderStyle
        {
            get { return base.BorderStyle; }
            set
            {
                if (this.myPaintedFirstTime)
                    this.SetStyle(ControlStyles.UserPaint, false);

                base.BorderStyle = value;

                if (this.myPaintedFirstTime)
                    this.SetStyle(ControlStyles.UserPaint, true);

                this.myBitmap = null;
                this.myAlphaBitmap = null;
                myUpToDate = false;
                this.Invalidate();
            }
        }

        public new Color BackColor
        {
            get
            {
                return Color.FromArgb(base.BackColor.R, base.BackColor.G, base.BackColor.B);
            }
            set
            {
                myBackColor = value;
                base.BackColor = value;
                myUpToDate = false;
            }
        }
        public override bool Multiline
        {
            get { return base.Multiline; }
            set
            {
                if (this.myPaintedFirstTime)
                    this.SetStyle(ControlStyles.UserPaint, false);

                base.Multiline = value;

                if (this.myPaintedFirstTime)
                    this.SetStyle(ControlStyles.UserPaint, true);

                this.myBitmap = null;
                this.myAlphaBitmap = null;
                myUpToDate = false;
                this.Invalidate();
            }
        }

        [
        Category("Skin"),
        Description("背景色的透明度"),
        Browsable(true),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)

        ]
        public int BackAlpha
        {
            get { return myBackAlpha; }
            set
            {
                int v = value;
                if (v > 255)
                    v = 255;
                myBackAlpha = v;
                myUpToDate = false;
                Invalidate();
            }
        }

        #endregion

        #region 私有方法

        private int GetFontHeight()
        {
            Graphics g = this.CreateGraphics();
            SizeF sf_font = g.MeasureString("X", this.Font);
            g.Dispose();
            return (int)sf_font.Height;
        }

        const long PRF_CLIENT = 0x00000004L;
        const long PRF_ERASEBKGND = 0x00000008L;
        public static bool CaptureWindow(System.Windows.Forms.Control control,
                            ref System.Drawing.Bitmap bitmap)
        {
            //This function captures the contents of a window or control

            Graphics g2 = Graphics.FromImage(bitmap);

            //PRF_CHILDREN // PRF_NONCLIENT
            int meint = (int)(PRF_CLIENT | PRF_ERASEBKGND); //| PRF_OWNED ); //  );
            System.IntPtr meptr = new System.IntPtr(meint);

            System.IntPtr hdc = g2.GetHdc();
            NativeMethods.SendMessage(control.Handle, WM.WM_PRINT, (int)hdc, meptr);

            g2.ReleaseHdc(hdc);
            g2.Dispose();

            return true;

        }


        private void GetBitmaps()
        {

            if (myBitmap == null
                || myAlphaBitmap == null
                || myBitmap.Width != Width
                || myBitmap.Height != Height
                || myAlphaBitmap.Width != Width
                || myAlphaBitmap.Height != Height)
            {
                myBitmap = null;
                myAlphaBitmap = null;
            }



            if (myBitmap == null)
            {
                myBitmap = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);//(Width,Height);
                myUpToDate = false;
            }


            if (!myUpToDate)
            {
                //Capture the TextBox control window

                this.SetStyle(ControlStyles.UserPaint, false);

                CaptureWindow(this, ref myBitmap);

                this.SetStyle(ControlStyles.UserPaint, true);
                this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                this.BackColor = Color.FromArgb(myBackAlpha, myBackColor);

            }
            //--



            Rectangle r2 = new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height);
            ImageAttributes tempImageAttr = new ImageAttributes();


            //Found the color map code in the MS Help

            ColorMap[] tempColorMap = new ColorMap[1];
            tempColorMap[0] = new ColorMap();
            tempColorMap[0].OldColor = Color.FromArgb(255, myBackColor);
            tempColorMap[0].NewColor = Color.FromArgb(myBackAlpha, myBackColor);

            tempImageAttr.SetRemapTable(tempColorMap);

            if (myAlphaBitmap != null)
                myAlphaBitmap.Dispose();


            myAlphaBitmap = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);//(Width,Height);

            Graphics tempGraphics1 = Graphics.FromImage(myAlphaBitmap);

            tempGraphics1.DrawImage(myBitmap, r2, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height, GraphicsUnit.Pixel, tempImageAttr);
            //绘制水印
            WmPaintWater(tempGraphics1);
            tempGraphics1.Dispose();

            //画光标
            if (this.Focused && (this.SelectionLength == 0))
            {
                Graphics tempGraphics2 = Graphics.FromImage(myAlphaBitmap);
                if (myCaretState)
                {
                    //Draw the caret
                    Point caret = this.findCaret();
                    Pen p = new Pen(this.ForeColor, 1);
                    tempGraphics2.DrawLine(p, caret.X, caret.Y + 0, caret.X, caret.Y + myFontHeight);
                    tempGraphics2.Dispose();
                }
            }
        }

        /// <summary>
        /// 绘制水印
        /// </summary>
        private void WmPaintWater(Graphics g)
        {
            if (this.Text.Length == 0 &&
                !string.IsNullOrEmpty(this._waterText) &&
                !this.Focused)
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                if (WaterText.Length != 0)
                {
                    Image img = SkinTools.ImageLightEffect(WaterText, WaterFont, WaterColor, BackColor, 0, ClientRectangle, !AutoSize);
                    int left = this.RightToLeft == RightToLeft.Yes ? Width - img.Width : 0;
                    g.DrawImage(img, left, (Height - img.Height) / 2);
                }
            }
        }


        private Point findCaret()
        {
            Point pointCaret = new Point(0);
            int i_char_loc = this.SelectionStart;
            IntPtr pi_char_loc = new IntPtr(i_char_loc);

            int i_point = NativeMethods.SendMessage(this.Handle, EM.EM_POSFROMCHAR, (int)pi_char_loc, IntPtr.Zero);
            pointCaret = new Point(i_point);

            if (i_char_loc == 0)
            {
                pointCaret = new Point(0);
            }
            else if (i_char_loc >= this.Text.Length)
            {
                pi_char_loc = new IntPtr(i_char_loc - 1);
                i_point = NativeMethods.SendMessage(this.Handle, EM.EM_POSFROMCHAR, (int)pi_char_loc, IntPtr.Zero);
                pointCaret = new Point(i_point);

                Graphics g = this.CreateGraphics();
                String t1 = this.Text.Substring(this.Text.Length - 1, 1) + "X";
                SizeF sizet1 = g.MeasureString(t1, this.Font);
                SizeF sizex = g.MeasureString("X", this.Font);
                g.Dispose();
                int xoffset = (int)(sizet1.Width - sizex.Width);
                pointCaret.X = pointCaret.X + xoffset;

                if (i_char_loc == this.Text.Length)
                {
                    String slast = this.Text.Substring(Text.Length - 1, 1);
                    if (slast == "\n")
                    {
                        pointCaret.X = 1;
                        pointCaret.Y = pointCaret.Y + myFontHeight;
                    }
                }

            }



            return pointCaret;
        }


        private void myTimer1_Tick(object sender, EventArgs e)
        {
            //Timer used to turn caret on and off for focused control

            myCaretState = !myCaretState;
            myCaretUpToDate = false;
            this.Invalidate();
        }


        private class uPictureBox : PictureBox
        {
            public uPictureBox()
            {
                this.SetStyle(ControlStyles.Selectable, false);
                this.SetStyle(ControlStyles.UserPaint, true);
                this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                this.SetStyle(ControlStyles.DoubleBuffer, true);

                this.Cursor = null;
                this.Enabled = true;
                this.SizeMode = PictureBoxSizeMode.Normal;

            }




            //uPictureBox
            protected override void WndProc(ref Message m)
            {
                if (m.Msg == WM.WM_LBUTTONDOWN
                    || m.Msg == WM.WM_RBUTTONDOWN
                    || m.Msg == WM.WM_LBUTTONDBLCLK
                    || m.Msg == WM.WM_MOUSELEAVE
                    || m.Msg == WM.WM_MOUSEMOVE)
                {
                    //Send the above messages back to the parent control
                    NativeMethods.PostMessage(this.Parent.Handle, (int)m.Msg, m.WParam, m.LParam);
                }

                else if (m.Msg == WM.WM_LBUTTONUP)
                {
                    //??  for selects and such
                    this.Parent.Invalidate();
                }


                base.WndProc(ref m);
            }


        }   // End uPictureBox Class


        #endregion  // end private functions and classes

        #region 窗体自动生成的代码
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
        #endregion
    }
}