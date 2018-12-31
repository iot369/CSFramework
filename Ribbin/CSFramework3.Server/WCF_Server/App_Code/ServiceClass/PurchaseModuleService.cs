using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using CSFramework.Common;
using CSFramework.Core;
using CSFramework3.Server.DataAccess.DAL_Business;

// 注意: 如果更改此处的类名 "PurchaseModuleService"，也必须更新 Web.config 中对 "PurchaseModuleService" 的引用。
public class PurchaseModuleService : IPurchaseModuleService
{
    public bool PO_Delete(byte[] loginTicket, string docNo)
    {
        try
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            return new dalPO(loginer).Delete(docNo);
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }

    public byte[] PO_GetBusinessByKey(byte[] loginTicket, string docNo)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataSet data = new dalPO(loginer).GetBusinessByKey(docNo);
        return ZipTools.CompressionDataSet(data);
    }

    public byte[] PO_GetReportData(byte[] loginTicket, string DocNoFrom, string DocNoTo, DateTime DateFrom, DateTime DateTo)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataSet data = new dalPO(loginer).GetReportData(DocNoFrom, DocNoTo, DateFrom, DateTo);
        return ZipTools.CompressionDataSet(data);
    }

    public byte[] PO_GetSummaryByParam(byte[] loginTicket, string docNoFrom, string docNoTo, DateTime docDateFrom, DateTime docDateTo, string StockCode, string Customer)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataSet data = new dalPO(loginer).GetSummaryByParam(docNoFrom, docNoTo, docDateFrom, docDateTo, StockCode, Customer);
        return ZipTools.CompressionDataSet(data);
    }

    public byte[] PO_Update(byte[] loginTicket, byte[] data)
    {
        try
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataSet ds = ZipTools.DecompressionDataSet(data);
            SaveResult result = new dalPO(loginer).Update(ds);
            return ZipTools.CompressionObject(result);
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }

    public bool PO_CheckNoExists(byte[] loginTicket, string keyValue)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
        return new dalPO(loginer).CheckNoExists(keyValue);
    }

    public void PO_ApprovalBusiness(byte[] loginTicket, string keyValue, string flagApp, string appUser, DateTime appDate)
    {
        try
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            new dalPO(loginer).ApprovalBusiness(keyValue, flagApp, appUser, appDate);
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }

}
