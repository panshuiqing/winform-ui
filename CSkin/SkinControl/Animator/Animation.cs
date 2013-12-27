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
 * * 说明：Animation.cs
 * *
********************************************************************/

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CCWin.SkinControl
{
    /// <summary>
    /// 动画控制器
    /// </summary>
    public class Animation
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), EditorBrowsable(EditorBrowsableState.Advanced), TypeConverter(typeof (PointFConverter))]
        [Description("滑动系数")]
        public PointF SlideCoeff { get; set; }
        [Description("转动系数")]
        public float RotateCoeff { get; set; }
        [Description("旋转限度")]
        public float RotateLimit { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), EditorBrowsable(EditorBrowsableState.Advanced), TypeConverter(typeof(PointFConverter))]
        [Description("尺度系数")]
        public PointF ScaleCoeff { get; set; }
        [Description("透明系数")]
        public float TransparencyCoeff { get; set; }
        [Description("叶系数")]
        public float LeafCoeff { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), EditorBrowsable(EditorBrowsableState.Advanced), TypeConverter(typeof(PointFConverter))]
        [Description("马赛克偏移")]
        public PointF MosaicShift { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), EditorBrowsable(EditorBrowsableState.Advanced), TypeConverter(typeof(PointFConverter))]
        [Description("马赛克系数")]
        public PointF MosaicCoeff { get; set; }
        [Description("马赛克大小")]
        public int MosaicSize { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), EditorBrowsable(EditorBrowsableState.Advanced), TypeConverter(typeof(PointFConverter))]
        [Description("百叶窗系数")]
        public PointF BlindCoeff { get; set; }
        [Description("时间系数")]
        public float TimeCoeff { get; set; }
        [Description("最小时间")]
        public float MinTime { get; set; }
        [Description("最大时间")]
        public float MaxTime { get; set; }
        [Description("内边距")]
        public Padding Padding { get; set; }
        [Description("是否存在动画差异")]
        public bool AnimateOnlyDifferences { get;set;}

        public Animation()
        {
            MinTime = 0f;
            MaxTime = 1f;
            AnimateOnlyDifferences = true;
        }


        public Animation Clone()
        {
            return (Animation)MemberwiseClone();
        }


        public static Animation Rotate { get { return new Animation { RotateCoeff = 1f, TransparencyCoeff = 1, Padding = new Padding(50, 50, 50, 50) }; } }
        public static Animation HorizSlide { get { return new Animation { SlideCoeff = new PointF(1, 0) }; } }
        public static Animation VertSlide { get { return new Animation { SlideCoeff = new PointF(0, 1) }; } }
        public static Animation Scale { get { return new Animation { ScaleCoeff = new PointF(1, 1) }; } }
        public static Animation ScaleAndRotate { get { return new Animation { ScaleCoeff = new PointF(1, 1), RotateCoeff = 0.5f, RotateLimit = 0.2f, Padding = new Padding(30, 30, 30, 30) }; } }
        public static Animation HorizSlideAndRotate { get { return new Animation { SlideCoeff = new PointF(1, 0), RotateCoeff = 0.3f, RotateLimit = 0.2f,  Padding = new Padding(50, 50, 50, 50) }; } }
        public static Animation ScaleAndHorizSlide { get { return new Animation { ScaleCoeff = new PointF(1, 1), SlideCoeff = new PointF(1, 0), Padding = new Padding(30, 0, 0, 0) }; } }
        public static Animation Transparent { get { return new Animation { TransparencyCoeff = 1 }; } }
        public static Animation Leaf { get { return new Animation { LeafCoeff = 1 }; } }
        public static Animation Mosaic { get { return new Animation { MosaicCoeff = new PointF(100f, 100f), MosaicSize = 20, Padding = new Padding(30, 30, 30, 30) }; } }
        public static Animation Particles { get { return new Animation { MosaicCoeff = new PointF(200, 200), MosaicSize = 1, MosaicShift = new PointF(0, 0.5f), Padding = new Padding(100, 50, 100, 150), TimeCoeff = 2 }; } }
        public static Animation VertBlind { get { return new Animation { BlindCoeff = new PointF(0f, 1f) }; } }
        public static Animation HorizBlind { get { return new Animation { BlindCoeff = new PointF(1f, 0f) }; } }



        public void Add(Animation a)
        {
            SlideCoeff = new PointF(SlideCoeff.X + a.SlideCoeff.X, SlideCoeff.Y + a.SlideCoeff.Y);
            RotateCoeff += a.RotateCoeff;
            RotateLimit += a.RotateLimit;
            ScaleCoeff = new PointF(ScaleCoeff.X + a.ScaleCoeff.X, ScaleCoeff.Y + a.ScaleCoeff.Y);
            TransparencyCoeff += a.TransparencyCoeff;
            LeafCoeff += a.LeafCoeff;
            MosaicShift = new PointF(MosaicShift.X + a.MosaicShift.X, MosaicShift.Y + a.MosaicShift.Y);
            MosaicCoeff = new PointF(MosaicCoeff.X + a.MosaicCoeff.X, MosaicCoeff.Y + a.MosaicCoeff.Y);
            MosaicSize += a.MosaicSize;
            BlindCoeff = new PointF(BlindCoeff.X + a.BlindCoeff.X, BlindCoeff.Y + a.BlindCoeff.Y);
            TimeCoeff += a.TimeCoeff;
            Padding += a.Padding;
        }
    }

    public enum AnimationType
    {
        Custom = 0,
        Rotate,
        HorizSlide,
        VertSlide,
        Scale,
        ScaleAndRotate,
        HorizSlideAndRotate,
        ScaleAndHorizSlide,
        Transparent,
        Leaf,
        Mosaic,
        Particles,
        VertBlind,
        HorizBlind
    }                      
}