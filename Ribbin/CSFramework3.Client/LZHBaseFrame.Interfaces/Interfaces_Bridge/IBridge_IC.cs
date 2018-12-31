using System;
using System.Collections.Generic;
using System.Text;
using LZHBaseFrame.Common;
using System.Data;

namespace LZHBaseFrame.Interfaces
{
    public interface IBridge_IC
    {
        DataSet GetBusinessByKey(string keyValue);

        DataTable GetSummaryByParam(string docNoFrom, string docNoTo, DateTime docDateFrom, DateTime docDateTo);
        SaveResult Update(System.Data.DataSet saveData);

        bool Delete(string keyValue);
        bool CheckNoExists(string keyValue);
        void ApprovalBusiness(string keyValue, string flagApp, string appUser, DateTime appDate);        
    }
}
