using System;
using System.Collections.Generic;
using System.Text;

namespace Teleware.ZPG.Client.Controls
{
    public class xCheckBox:CCWin.SkinControl.SkinCheckBox
    {
        public xCheckBox()
        {
            this.SelectedDownBack = Properties.Resources.checkbox_tick_pushed;
            this.SelectedMouseBack = Properties.Resources.checkbox_tick_hover;
            this.SelectedNormlBack = Properties.Resources.checkbox_tick_normal;
            this.MouseBack =Properties.Resources.checkbox_hover;
            this.NormlBack = Properties.Resources.checkbox_normal;
            this.DownBack = Properties.Resources.checkbox_pushed;
        }
    }
}
