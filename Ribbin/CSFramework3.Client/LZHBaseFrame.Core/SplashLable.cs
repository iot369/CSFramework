
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using LZHBaseFrame.Common;

namespace LZHBaseFrame.Core
{
    /// <summary>
    /// 加载模块时进度显示
    /// </summary>
    public class LoadStatus : IMsg
    {
        private Label _lbl = null;
        public LoadStatus(Label lbl)
        {
            _lbl = lbl;
        }

        public void UpdateMessage(string msg)
        {
            _lbl.Text = msg;
            _lbl.Update();
        }
    }
}
