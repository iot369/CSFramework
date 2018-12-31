
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using LZHBaseFrame.Common;
using DevExpress.XtraEditors;

namespace LZHBaseFrame.Core
{
    /// <summary>
    /// 加载模块时进度显示
    /// </summary>
    public class LoadStatus : IMsg
    {
        private Label _lbl = null;
        private DevExpress.XtraEditors.ProgressBarControl _pc = null;

        public LoadStatus(Label lbl, DevExpress.XtraEditors.ProgressBarControl pc)
        {
            _lbl = lbl;
            _pc = pc;
        }

        public void UpdateMessage(string msg,int step)
        {
            _lbl.Text = msg;
            _lbl.Update();
            _pc.Text  = step.ToString();
            Application.DoEvents();

        }
    }
}
