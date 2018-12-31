
///*************************************************************************/
///*
///* 文件名    ：frmPrintViewerFR.cs    
///* 程序说明  : 打印预览窗体
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 LZHBaseFrame www.LZHBaseFrame.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FastReport;
using System.IO;
using LZHBaseFrame.Common;
using LZHBaseFrame.Library;

namespace LZHBaseFrame.Reports
{
    /// <summary>
    /// 打印预览窗体
    /// </summary>
    public partial class frmPrintViewerFR : Form
    {
        private TfrxReportClass _CurrentReport;
        private Form _CurrentOwnerForm;

        //private构造器,禁止外部构造实例
        private frmPrintViewerFR()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 显示预览窗体
        /// </summary>
        public static void ExecutePreview(Form owner, TfrxReportClass report)
        {
            frmPrintViewerFR preview = new frmPrintViewerFR();
            preview.ShowInTaskbar = false;
            preview.Text = "打印预览窗体";
            preview.Owner = owner;
            preview._CurrentReport = report;
            preview._CurrentOwnerForm = owner;
            preview.ShowDialog();
        }

        private void frmPrintViewerFR_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadExportTypes();
                
                _CurrentReport.PreviewOptions.Buttons ^= frxPreviewButtons.pb_Tools;
                _CurrentReport.PreviewOptions.Buttons ^= frxPreviewButtons.pb_Outline;
                _CurrentReport.PreviewOptions.Buttons ^= frxPreviewButtons.pb_NoClose;
                _CurrentReport.PreviewOptions.Buttons ^= frxPreviewButtons.pb_Edit;

                _CurrentReport.OnAfterPrintReport += new IfrxReportEventDispatcher_OnAfterPrintReportEventHandler(tfrx_OnAfterPrintReport);
                _CurrentReport.PreviewOptions.DoubleBuffered = true;

                FRPreview.Report = _CurrentReport as TfrxReport;
                FRPreview.Report.PrepareReport(true);
                //FRPreview.Report.ShowReport(); //或者这个方法
            }
            catch (Exception ex)
            {
                Msg.Warning(ex.Message);
            }
        }

        private void LoadExportTypes()
        {
            cbExportTypes.Items.Clear();
            cbExportTypes.Items.Add(new ExportReportItem("PDF格式报表", ExportReportItem.ExportType.PDF));
            cbExportTypes.Items.Add(new ExportReportItem("Excel格式报表", ExportReportItem.ExportType.XLS));
            cbExportTypes.Items.Add(new ExportReportItem("HTML格式报表", ExportReportItem.ExportType.HTML));
            cbExportTypes.SelectedIndex = 0;//PDF预设
        }

        /// <summary>
        /// 打印完成事件
        /// </summary>
        private void tfrx_OnAfterPrintReport(IfrxComponent Sender)
        {
            //
        }

        private void frmPrintViewerFR_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_CurrentOwnerForm != null) _CurrentOwnerForm.Activate();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
