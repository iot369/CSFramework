using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LZHBaseFrame.Common;

namespace LZHBaseFrame.Interfaces
{
    public interface IBridge_DataDict
    {
        DataTable GetDataByKey(string key);
        DataTable GetSummaryData();
        DataTable GetDataDictByTableName(string tableName);
        DataSet DownloadDicts();

        bool Update(DataSet data);
        SaveResultEx UpdateEx(DataSet data);
        bool Delete(string keyValue);
        bool CheckNoExists(string keyValue);

        Type ORM { get; set; }
        string TableName { get; set; }
    }
}
