using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LZHBaseFrame.Business;
using DevExpress.XtraReports.UI;

namespace LZHBaseFrame.ReportsDevExpress
{
    public partial class frmRptSO : LZHBaseFrame.ReportsDevExpress.frmPrintBase
    {
        public frmRptSO()
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
            frmRptSO form = new frmRptSO();
            form.txtNoFrom.Text = docNoFrom;
            form.txtNoTo.Text = docNoTo;
            form.ShowDialog();
        }

        protected override XtraReport DoPrepareReport()
        {
            rptSO mReport = new rptSO(); //报表实例

            //取报表数据
            DataSet ds = new bllSO().GetReportData(txtNoFrom.Text, txtNoTo.Text, txtDateFrom.DateTime, txtDateTo.DateTime);
            mReport.SetReportDataSource(ds);//绑定报表的数据源

            return mReport;
        }

    }
}
