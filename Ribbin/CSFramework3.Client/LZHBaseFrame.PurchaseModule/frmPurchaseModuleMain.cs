
///*************************************************************************/
///*
///* 文件名    ：frmPurchaseModuleMain.cs    
///* 程序说明  : 采购模块主窗体
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.LZHBaseFrame.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LZHBaseFrame.Common;
using LZHBaseFrame.Library;
using LZHBaseFrame.Interfaces;

namespace LZHBaseFrame.PurchaseModule
{
    /// <summary>
    /// 采购模块主窗体
    /// </summary>
    public partial class frmPurchaseModuleMain : LZHBaseFrame.Library.frmModuleBase
    {
        public frmPurchaseModuleMain()
        {
            InitializeComponent();

            _ModuleID = LZHBaseFrame.Interfaces.ModuleID.PurchaseModule; //设置模块编号
            _ModuleName = LZHBaseFrame.Interfaces.ModuleNames.PurchaseModule;//设置模块名称
            menuStrip1.Text = LZHBaseFrame.Interfaces.ModuleNames.PurchaseModule; //与AssemblyModuleEntry.ModuleName定义相同

            this.MainMenuStrip = this.menuStrip1;

            this.SetMenuTag();
        }

        public override MenuStrip GetModuleMenu()
        {
            return this.menuStrip1;
        }

        private void SetMenuTag()
        {
            menuPurchaseMain.Tag = new MenuItemTag(MenuType.ItemOwner, (int)LZHBaseFrame.Interfaces.ModuleID.PurchaseModule, AuthorityCategory.NONE);
            menuItemPO.Tag = new MenuItemTag(MenuType.DataForm, (int)LZHBaseFrame.Interfaces.ModuleID.PurchaseModule, AuthorityCategory.BUSINESS_ACTION_VALUE);
            menuStockIn.Tag = new MenuItemTag(MenuType.DataForm, (int)LZHBaseFrame.Interfaces.ModuleID.PurchaseModule, AuthorityCategory.BUSINESS_ACTION_VALUE);
        }

        public override void SetSecurity(object securityInfo)
        {
            base.SetSecurity(securityInfo);

            if (securityInfo is ToolStrip)
            {
                this.LoadReportList(menuReports, listReports);
            }
        }

        private void OnModuleMenuClick(object sender, EventArgs e)
        {
            Type formClass = Type.GetType((sender as ToolStripMenuItem).Tag.ToString());
            MdiTools.OpenChildForm(this.MdiParent as IMdiForm, formClass, sender as ToolStripMenuItem);
        }

        private void menuItemPO_Click(object sender, EventArgs e)
        {
            MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmPO), menuItemPO);
        }

        private void menuGRN_Click(object sender, EventArgs e)
        {
            MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmPO), menuItemPO);
        }

        private void menuItemQuo_Click(object sender, EventArgs e)
        {
            MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmPO), menuItemPO);
        }

        private void menuRpt01_Click(object sender, EventArgs e)
        {
            Msg.ShowInformation("打开报表窗体");
        }

        private void menuRpt02_Click(object sender, EventArgs e)
        {
            Msg.ShowInformation("打开报表窗体");
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("打开窗体呢！");
        }
    }
}
