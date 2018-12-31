
///*************************************************************************/
///*
///* 文件名    ：frmPrintBase.cs    
///* 程序说明  : 报表打印窗体基类
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
using LZHBaseFrame.Common;
using LZHBaseFrame.Library;

namespace LZHBaseFrame.Reports
{
    /// <summary>
    /// 报表打印窗体基类
    /// </summary>
    public partial class frmPrintBase : frmBase
    {
        public frmPrintBase()
        {
            InitializeComponent();
        }

        private void btnPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DoPreview(); //打印预览
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DoPrint();//打印
        }

        private void btnDesign_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DoDesignReport(); //实时设计报表
        }

        private void btnHelp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DoHelp();//打开帮助
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DoClose();//关闭窗体
        }

        protected void AssertNull(object o, string throwMsg)
        {
            if (o == null) throw new Exception(throwMsg);
        }

        protected void AssertNullDataSet(DataSet ds, string throwMsg)
        {
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0) throw new Exception(throwMsg);
        }

        protected virtual void DoDesignReport()
        {
            //
        }

        protected virtual void DoPreview()
        {
            //

        }
        protected virtual void DoPrint()
        {
            //
        }
        protected virtual void DoHelp()
        {
            //
        }
        protected virtual void DoClose()
        {
            this.Close();
        }

        private void frmPrintBase_Load(object sender, EventArgs e)
        {
            btnClose.Glyph = Globals.LoadImage("24_Exit.ico");
            btnPrint.Glyph = Globals.LoadImage("24_Print.ico");
            btnPreview.Glyph = Globals.LoadImage("24_PrintPreview.ico");
            btnHelp.Glyph = Globals.LoadImage("24_Help.ico");
            btnDesign.Glyph = Globals.LoadImage("24_DesignReport.ico");
        }

        #region FastReport不支持Decimal类型(会丢失小数位)

        /// <summary>
        /// FastReport不支持Decimal类型(会丢失小数位)，要将Decimal类型转换成Double        
        /// </summary>
        /// <param name="sourceData">数据源</param>
        /// <returns>转换后的数据</returns>
        protected DataSet ConvertTableDecimalToDouble(DataSet sourceData)
        {
            if (sourceData != null && sourceData.Tables.Count > 0)
            {
                DataTable[] dtType = new DataTable[sourceData.Tables.Count];

                for (int i = 0; i < sourceData.Tables.Count; i++)
                {
                    dtType[i] = new DataTable();
                    dtType[i] = sourceData.Tables[i].Clone();
                    for (int k = 0; k < sourceData.Tables[i].Columns.Count; k++)
                    {
                        if (dtType[i].Columns[k].DataType == typeof(decimal))
                        {
                            dtType[i].Columns[k].DataType = typeof(double);//将Decimal类型转换成Double 
                        }
                    }
                    for (int j = 0; j < sourceData.Tables[i].Rows.Count; j++)
                    {
                        dtType[i].Rows.Add(sourceData.Tables[i].Rows[j].ItemArray);
                    }
                }

                sourceData.Tables.Clear();
                for (int m = 0; m < dtType.Length; m++)
                {
                    sourceData.Tables.Add(dtType[m]);
                }
                return sourceData;
            }
            else
                return null;
        }
        #endregion
    }
}