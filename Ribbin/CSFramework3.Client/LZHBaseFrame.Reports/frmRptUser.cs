
///*************************************************************************/
///*
///* 文件名    ：frmRptUser.cs    
///* 程序说明  : 用户报表打印窗体. 数据字典(单表)报表模板
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 LZHBaseFrame www.LZHBaseFrame.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FastReport;
using System.IO;
using System.Drawing.Imaging;
using LZHBaseFrame.Business;
using LZHBaseFrame.Business.Security;

namespace LZHBaseFrame.Reports
{
    /***********************************************************************************
    * 
    * 当运行报表时出现如下错误:
    * 
    * 正在 OS 载入器锁定内尝试 Managed 执行。 
    * 请勿尝试在 DllMain 或影像初始设定函式内部执行 Managed 程式码，
    * 因为这样做可能导致应用程式停止回应。
    * 
    * 解决方法: 主菜单\Debug\Exceptions\Managed Debugging Assistants\LoadLock=False
    * 
    ************************************************************************************/

    /// <summary>
    /// 用户报表打印窗体
    /// </summary>
    public partial class frmRptUser : frmPrintBase
    {
        private FrxDataTable dtSummary = null; //主表数据代理对象
        private TfrxReportClass _report = null; //报表类

        public frmRptUser()
        {
            InitializeComponent();
        }

        private void frmPrintReport_Load(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        protected override void DoPreview()
        {
            ExecutePreview();
        }

        protected override void DoPrint()
        {
            ExecutePreview();
        }

        public void ExecutePreview()
        {
            this.Hide();

            DataSet ds = new DataSet();
            ds.Tables.Add(new bllUser().GetUsers().Copy());//取报表数据

            _report = new TfrxReportClass();
            _report.OnBeforePrint += new IfrxReportEventDispatcher_OnBeforePrintEventHandler(Report_OnBeforePrint);
            _report.OnAfterPrint += new IfrxReportEventDispatcher_OnAfterPrintEventHandler(Report_OnAfterPrint);

            ds.Tables[0].TableName = "User"; //设置表名，与FastReport报表内名称定义一致
            dtSummary = new FrxDataTable(ds.Tables[0]); //创建报表代理数据

            _report.MainWindowHandle = (int)this.Handle; //设置报表窗体的主窗体
            _report.LoadReportFromFile(GetReportFile("users.fr3")); //加载报表文件
            _report.ClearDatasets();//先清空报表数据

            dtSummary.AssignToReport(true, _report); //设置报表的主数据源
            dtSummary.AssignToDataBand("MasterData1", _report); //绑定主表的报表数据

            frmPrintViewerFR.ExecutePreview(this, _report);//显示打印预览窗体

            this.Close(); //预览或打印完成关闭本窗体
        }

        private static string GetReportFile(string fr3FileName)
        {
            return Application.StartupPath + @"\Reports\" + fr3FileName;
        }

        private void Report_OnBeforePrint(IfrxComponent Sender)
        {
            if (Sender is FastReport.IfrxView)
            {
                if (Sender.Name == "Memo10")
                {
                    Object data;
                    dtSummary.OnGetValueHandler("EMail", out data);
                    (Sender as IfrxMemoView).Memo = data.ToString();
                }
            }
        }

        private void Report_OnAfterPrint(IfrxComponent Sender)
        {
            //
        }
    }
}
