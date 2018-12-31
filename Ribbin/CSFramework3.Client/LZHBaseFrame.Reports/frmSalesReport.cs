
///*************************************************************************/
///*
///* 文件名    ：frmSalesReport.cs    
///* 程序说明  : 销售订单报表打印窗体. 业务报表(主从表)报表模板
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
using LZHBaseFrame.Common;

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
    /// 销售订单报表打印窗体. 业务报表(主从表)报表模板
    /// </summary>
    public partial class frmSalesReport : LZHBaseFrame.Reports.frmPrintBase
    {
        private FrxDataTable dtSummary = null; //主表数据代理对象
        private FrxDataView dtDetailView = null; //明细表数据代理对象
        private TfrxReportClass _report = null; //报表的类

        private object _CurrentDocNo = null; //业务单号
        private object _CurrentContracTerms = null;

        //private构造器,禁止外部构造实例
        private frmSalesReport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 打开打印窗体
        /// </summary>
        /// <param name="docNoFrom">单号由</param>
        /// <param name="docNoTo">单号至</param>
        public static void Execute(string docNoFrom, string docNoTo)
        {
            frmSalesReport form = new frmSalesReport();
            form.txtNoFrom.Text = docNoFrom;
            form.txtNoTo.Text = docNoTo;
            form.ShowDialog();
        }

        protected override void DoPreview()
        {
            this.PrepareReport(); //准备报表数据
            frmPrintViewerFR.ExecutePreview(this, _report);//显示打印预览窗体
        }

        protected override void DoPrint()
        {
            this.PrepareReport(); //准备报表数据
            _report.PrintReport();//打印报表
        }

        //准备报表数据
        private void PrepareReport()
        {
            //取报表数据
            DataSet ds = new bllSO().GetReportData(txtNoFrom.Text, txtNoTo.Text, txtDateFrom.DateTime, txtDateTo.DateTime);

            //报表实例
            _report = new TfrxReportClass();
            _report.OnBeforePrint += new IfrxReportEventDispatcher_OnBeforePrintEventHandler(Report_OnBeforePrint);
            _report.OnAfterPrint += new IfrxReportEventDispatcher_OnAfterPrintEventHandler(Report_OnAfterPrint);

            ds.Tables[0].TableName = "M";//Master 主表
            ds.Tables[1].TableName = "D";//Detail 明细
            dtSummary = new FrxDataTable(ds.Tables[0]); //创建主表的报表代理数据
            dtDetailView = new FrxDataView(ds.Tables[1], "D");//创建明细表的报表代理数据

            //主从表数据需要绑定3个事件, 取主表的主键用于过滤明细数据
            dtSummary.FrxEventOnFirst += new FrxOnFirst(OnGetValueHandler); //对应Delphi的DataSet.First
            dtSummary.FrxEventOnNext += new FrxOnNext(OnGetValueHandler); //对应Delphi的DataSet.Next
            dtSummary.FrxEventOnPrior += new FrxOnPrior(OnGetValueHandler); //对应Delphi的DataSet.Prior

            _report.MainWindowHandle = (int)this.Handle;
            _report.LoadReportFromFile(GetReportFile("SO.fr3")); //从文件加载报表
            _report.ClearDatasets();

            dtSummary.AssignToReport(true, _report);//绑定报表数据集
            dtDetailView.AssignToReport(true, _report);//绑定报表数据集

            dtSummary.AssignToDataBand("MasterData1", _report); //绑定主表Band
            dtDetailView.AssignToDataBand("DetailData1", _report);//绑定明细表Bank

        }

        //通过该事件获取从表数据
        private void OnGetValueHandler()
        {
            dtSummary.OnGetValueHandler("SONO", out _CurrentDocNo); //取主表当前记录的单据号码            
            dtSummary.OnGetValueHandler("VerNo", out _CurrentContracTerms);//取单个字段的值(用于演示)

            dtDetailView.RowFilter = string.Format("SONO='{0}' ", _CurrentDocNo); //设置明细表的外键，过滤明细表

            //处理多个明细
            //dtDetailView.RowFilter = string.Format("SONO='{0}' ", _CurrentDocNo); //过滤明细表
            //dtDetailView.RowFilter = string.Format("SONO='{0}' ", _CurrentDocNo); //过滤明细表
        }

        private static string GetReportFile(string fr3FileName)
        {
            return Application.StartupPath + @"\Reports\" + fr3FileName;
        }

        #region 打印图片代码备份
        protected void LoadPicture(IfrxPictureView pictureView, object pictureData)
        {
            if (pictureData == null || !(pictureData is byte[])) return;

            MemoryStream stream = new MemoryStream();
            Byte[] array = pictureData as Byte[];
            stream.Write(array, 0, array.Length);
            pictureView.LoadViewFromStream(stream);
            stream.Close();
            stream = null;
        }
        #endregion

        private void Report_OnBeforePrint(IfrxComponent Sender)
        {
            if (Sender is FastReport.IfrxView)
            {
                if (Sender.Name == "Memo1")
                {
                    (Sender as FastReport.IfrxMemoView).Memo = CommonData.CompanyInfo.NativeName;
                }
                if (Sender.Name == "MemoContractTerms") //打印合同条款
                {
                    (Sender as FastReport.IfrxMemoView).Memo = ConvertEx.ToString(_CurrentContracTerms);
                }
                if (Sender.Name == "Picture1")
                {
                    IfrxPictureView pic = Sender as IfrxPictureView;

                    //    Object pictureData;
                    //    dtSummary.OnGetValueHandler("IMG", out pictureData);
                    //    LoadPicture((IfrxPictureView)Sender, pictureData);
                }
            }
        }

        private void Report_OnAfterPrint(IfrxComponent Sender)
        {
            //
        }
    }
}
