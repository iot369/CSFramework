using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CSFramework.Core;
using CSFramework.Common;
using System.Data;
using CSFramework3.Server.DataAccess.DAL_Business;
using CSFramework3.Server.DataAccess.DAL_System;

// 注意: 如果更改此处的类名 "SalesModuleService"，也必须更新 Web.config 中对 "SalesModuleService" 的引用。
public class SalesModuleService : ISalesModuleService
{

    #region 销售订单(Sales Order)的WCF接口,SO对应的数据层是dalSO

    public byte[] SO_GetBusinessByKey(byte[] loginTicket, string keyValue)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataSet data = new dalSO(loginer).GetBusinessByKey(keyValue);
        return ZipTools.CompressionDataSet(data);
    }


    public byte[] SO_GetReportData(byte[] loginTicket, string DocNoFrom, string DocNoTo, DateTime DateFrom, DateTime DateTo)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataSet data = new dalSO(loginer).GetReportData(DocNoFrom, DocNoTo, DateFrom, DateTo);
        return ZipTools.CompressionDataSet(data);
    }


    public byte[] SO_GetSummaryByParam(byte[] loginTicket, string DocNoFrom, string DocNoTo, DateTime docDateFrom, DateTime docDateTo)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataTable data = new dalSO(loginer).GetSummaryByParam(DocNoFrom, DocNoTo, docDateFrom, docDateTo);
        return ZipTools.CompressionDataSet(ServerLibrary.TableToDataSet(data));
    }


    public byte[] SO_Update(byte[] loginTicket, byte[] saveData)
    {
        try
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataSet ds = ZipTools.DecompressionDataSet(saveData);
            SaveResult result = new dalSO(loginer).Update(ds);
            return ZipTools.CompressionObject(result);
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }


    public bool SO_Delete(byte[] loginTicket, string keyValue)
    {
        try
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            return new dalSO(loginer).Delete(keyValue);
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }


    public bool SO_CheckNoExists(byte[] loginTicket, string keyValue)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
        return new dalSO(loginer).CheckNoExists(keyValue);
    }


    public void SO_ApprovalBusiness(byte[] loginTicket, string keyValue, string flagApp, string appUser, DateTime appDate)
    {
        try
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            new dalSO(loginer).ApprovalBusiness(keyValue, flagApp, appUser, appDate);
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }

    #endregion

    #region 销售合同(Sales Contract)的WCF接口,SC对应的数据层是dalSC


    public bool SC_Delete(byte[] loginTicket, string keyValue)
    {
        return false;//举例
    }

    #endregion

}
