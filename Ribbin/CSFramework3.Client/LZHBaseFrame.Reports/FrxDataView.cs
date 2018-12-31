/// <summary>
/// {******************************************}
/// {                                          }
/// {             FastReport v3.0              }
/// {          .NET DataView wrapper           }
/// {                                          }
/// {         Copyright (c) 1998-2006          }
/// {            Fast Reports Inc.             }
/// {                                          }
/// {******************************************}
/// </summary>
using System;
using System.Data;
using FastReport;

namespace LZHBaseFrame.Reports
{
    /// <summary>
    /// Summary description for FrxDataView.
    /// </summary>
    public class FrxDataView : DataView
    {
        private int nItem;
        TfrxUserDataSetClass m_ds;

        public event FrxOnFirst FrxEventOnFirst;
        public event FrxOnNext FrxEventOnNext;
        public event FrxOnPrior FrxEventOnPrior;

        /// <summary>
        /// Class constructor
        /// </summary>
        public FrxDataView(DataTable table, string name)
            : base(table)
        {
            m_ds = new TfrxUserDataSetClass();

            m_ds.OnCheckEOF += new IfrxUserDataSetEventDispatcher_OnCheckEOFEventHandler(OnCheckEOFEventHandler);
            m_ds.OnGetValue += new IfrxUserDataSetEventDispatcher_OnGetValueEventHandler(OnGetValueHandler);
            m_ds.OnFirst += new IfrxUserDataSetEventDispatcher_OnFirstEventHandler(OnFirstEventHandler);
            m_ds.OnNext += new IfrxUserDataSetEventDispatcher_OnNextEventHandler(OnNextEventHandler);
            m_ds.OnPrior += new IfrxUserDataSetEventDispatcher_OnPriorEventHandler(OnPriorEventHandler);

            m_ds.Name = name; // "change_me";

            DataColumnCollection cols = Table.Columns;
            string FieldNames = null;
            foreach (DataColumn col in cols) FieldNames += col.Caption + "\n";
            m_ds.Fields = FieldNames;
            
        }



        /// <summary>
        /// Assigns view to report
        /// </summary>
        public void AssignToReport(bool Enable, TfrxReportClass report)
        {
            report.SelectDataset(Enable, m_ds);
        }

        /// <summary>
        /// Assigns table to report
        /// </summary>
        public void AssignToDataBand(string BandName, TfrxReportClass report)
        {
            IfrxComponent frx_component;
            frx_component = ((IfrxComponent)report).FindObject(BandName);
            ((IfrxDataBand)frx_component).DataSet = (IfrxDataSet)m_ds;
        }

        /// <summary>
        /// On First event handler
        /// </summary>
        private void OnFirstEventHandler()
        {
            bool eof;

            nItem = 0;

            OnCheckEOFEventHandler(out eof);
            if (!eof && FrxEventOnFirst != null) FrxEventOnFirst();
        }

        /// <summary>
        /// On Next event handler
        /// </summary>
        private void OnNextEventHandler()
        {
            bool eof;

            nItem++;

            OnCheckEOFEventHandler(out eof);
            if (!eof && FrxEventOnNext != null) FrxEventOnNext();
        }

        /// <summary>
        /// On Prior event handler
        /// </summary>
        private void OnPriorEventHandler()
        {
            bool eof;

            nItem--;

            OnCheckEOFEventHandler(out eof);
            if (!eof && FrxEventOnPrior != null) FrxEventOnPrior();
        }

        /// <summary>
        /// On check EndOfFile event handler
        /// </summary>
        private void OnCheckEOFEventHandler(out bool eof)
        {
            eof = (nItem >= Count);
        }

        /// <summary>
        /// On get value handler
        /// </summary>
        public void OnGetValueHandler(object VarName, out object Val)
        {
            DataRowView drv = this[nItem];
            Val = drv[VarName.ToString()];

            // FastReport does not know about System.Decimal object type
            // so convert it to Integer
            if (Val is Decimal)
            {
                Val = Decimal.ToInt32((Decimal)Val);
            }
        }



    }
}
