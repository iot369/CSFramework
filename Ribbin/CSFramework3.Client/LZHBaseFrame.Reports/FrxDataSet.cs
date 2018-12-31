/// <summary>
/// {******************************************}
/// {                                          }
/// {             FastReport v3.0              }
/// {          .NET DataSet wrapper            }
/// {                                          }
/// {         Copyright (c) 1998-2006          }
/// {            Fast Reports Inc.             }
/// {                                          }
/// {******************************************}
/// </summary>

using System;
using System.Data;
using System.ComponentModel;
using System.Collections;
using FastReport;

namespace LZHBaseFrame.Reports
{
    /// <summary>
    /// Summary description for FrxDataSet.
    /// </summary>
    public class FrxDataSet : DataSet
    {
        private ArrayList frx_tables_array;

        public FrxDataSet() { frx_tables_array = new ArrayList(); }
        public FrxDataSet(string name) : base(name) { frx_tables_array = new ArrayList(); }

        public void BindToReport(TfrxReportClass report)
        {
            foreach (DataTable tbl in Tables)
            {
                FrxDataTable local_table = new FrxDataTable(tbl);
                frx_tables_array.Add(local_table);
                local_table.AssignToReport(true, report);
            }
        }

        public void UnbindFromReport(TfrxReportClass report)
        {
            foreach (FrxDataTable local_table in frx_tables_array)
            {
                local_table.AssignToReport(false, report);
                local_table.Dispose();
            }
            frx_tables_array.Clear();
        }

        public void BindTableToBand(string table_name, TfrxReportClass report, string band_name)
        {
            IfrxComponent MasterData3;

            MasterData3 = (report as IfrxComponent).FindObject(band_name);
            if (MasterData3 is IfrxDataBand)
            {
                if (table_name == null || table_name == "")
                {
                    (MasterData3 as IfrxDataBand).ResetDataSet();
                }
                else foreach (FrxDataTable local_table in frx_tables_array)
                    {
                        if (local_table.TableName == table_name)
                        {
                            (MasterData3 as IfrxDataBand).DataSet = local_table.FrxTable;
                        }
                    }
            }
            MasterData3 = null;
        }
    }
}
