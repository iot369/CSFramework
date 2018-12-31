/// <summary>
/// {******************************************}
/// {                                          }
/// {             FastReport v3.0              }
/// {          .NET DataTable wrapper          }
/// {                                          }
/// {         Copyright (c) 1998-2006          }
/// {            Fast Reports Inc.             }
/// {                                          }
/// {******************************************}
/// </summary>

using System;
using System.Data;
using System.ComponentModel;
using FastReport;

namespace LZHBaseFrame.Reports
{

    public delegate void FrxOnFirst();
    public delegate void FrxOnNext();
    public delegate void FrxOnPrior();


    /// <summary>
    /// Summary description for FrxDataSet.
    /// </summary>
    public class FrxDataTable : DataTable
    {
        private int nItem;
        TfrxUserDataSetClass m_ds;
        private DataTable m_ChildTable;

        public new string TableName
        {
            get { return m_ds.Name; }
        }

        public IfrxDataSet FrxTable
        {
            get { return m_ds as IfrxDataSet; }
        }

        public event FrxOnFirst FrxEventOnFirst;
        public event FrxOnNext FrxEventOnNext;
        public event FrxOnPrior FrxEventOnPrior;

        private void constructor(string name)
        {
            m_ChildTable = null;
            m_ds = new TfrxUserDataSetClass();

            m_ds.OnCheckEOF += new IfrxUserDataSetEventDispatcher_OnCheckEOFEventHandler(OnCheckEOFEventHandler);
            m_ds.OnGetValue += new IfrxUserDataSetEventDispatcher_OnGetValueEventHandler(OnGetValueHandler);
            m_ds.OnFirst += new IfrxUserDataSetEventDispatcher_OnFirstEventHandler(OnFirstEventHandler);
            m_ds.OnNext += new IfrxUserDataSetEventDispatcher_OnNextEventHandler(OnNextEventHandler);
            m_ds.OnPrior += new IfrxUserDataSetEventDispatcher_OnPriorEventHandler(OnPriorEventHandler);

            m_ds.Name = name;

            DataColumnCollection cols = Columns;
            cols.CollectionChanged += new CollectionChangeEventHandler(ColumnsCollection_Changed);
        }

        public FrxDataTable(string name)
        {
            constructor(name);
        }

        public FrxDataTable(DataTable t)
        {
            constructor(t.TableName);
            string FieldNames = null;
            foreach (DataColumn col in t.Columns) FieldNames += col.Caption + "\n";
            m_ds.Fields = FieldNames;
            m_ChildTable = t;
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
        /// Assigns table to report
        /// </summary>
        public void AssignToReport(bool Enable, TfrxReportClass report)
        {
            report.SelectDataset(Enable, m_ds);
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
        /// On Prior evene handler
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
            if (m_ChildTable == null)
            {
                eof = (nItem >= Rows.Count);
            }
            else
            {
                eof = (nItem >= m_ChildTable.Rows.Count);
            }
        }

        /// <summary>
        /// On get value handler
        /// </summary>
        public void OnGetValueHandler(object VarName, out object Val)
        {
            Val = null;

            if (m_ChildTable == null)
            {
                Val = Rows[nItem][VarName.ToString()];
            }
            else if (nItem <= m_ChildTable.Rows.Count - 1)
            {
                Val = m_ChildTable.Rows[nItem][VarName.ToString()];
            }
            // FastReport does not know about System.Decimal object type
            // so convert it to Integer
            if (Val is Decimal)
            {
                Val = Decimal.ToInt32((Decimal)Val);
            }

        }

        /// <summary>
        /// Updates FastReport UserDataSet on Column addition
        /// </summary>
        private void ColumnsCollection_Changed(object sender, CollectionChangeEventArgs e)
        {
            DataColumnCollection cols = (DataColumnCollection)sender;
            string FieldNames = null;
            foreach (DataColumn col in cols) FieldNames += col.Caption + "\n";
            m_ds.Fields = FieldNames;
        }
    }
}

