using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CSFramework.Common;
using CSFramework.Core;
using System.Data;
using CSFramework3.Server.DataAccess.DAL_System;
using CSFramework3.Server.DataAccess.DAL_Business;

// 注意: 如果更改此处的类名 "AccountModuleService"，也必须更新 Web.config 中对 "AccountModuleService" 的引用。
public class AccountModuleService : IAccountModuleService
{
    #region 应收款(AR Account Receive)的WCF接口,对应的数据层是dalAR

    public byte[] AR_GetBusinessByKey(byte[] loginTicket, string keyValue)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataSet data = new dalAR(loginer).GetBusinessByKey(keyValue);
        return ZipTools.CompressionDataSet(data);
    }

    public byte[] AR_GetSummaryByParam(byte[] loginTicket, string DocNoFrom, string DocNoTo, DateTime docDateFrom, DateTime docDateTo)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataTable data = new dalAR(loginer).GetSummaryByParam(DocNoFrom, DocNoTo, docDateFrom, docDateTo);
        return ZipTools.CompressionDataSet(ServerLibrary.TableToDataSet(data));
    }

    public byte[] AR_Update(byte[] loginTicket, byte[] saveData)
    {
        try
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataSet ds = ZipTools.DecompressionDataSet(saveData);
            SaveResult result = new dalAR(loginer).Update(ds);
            return ZipTools.CompressionObject(result);
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }

    public bool AR_Delete(byte[] loginTicket, string keyValue)
    {
        try
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            return new dalAR(loginer).Delete(keyValue);
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }

    public bool AR_CheckNoExists(byte[] loginTicket, string keyValue)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
        return new dalAR(loginer).CheckNoExists(keyValue);
    }

    public void AR_ApprovalBusiness(byte[] loginTicket, string keyValue, string flagApp, string appUser, DateTime appDate)
    {
        try
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            new dalAR(loginer).ApprovalBusiness(keyValue, flagApp, appUser, appDate);
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }

    public byte[] AR_GetReportData_Checklist(byte[] loginTicket, string DocNoFrom, string DocNoTo, DateTime DateFrom, DateTime DateTo)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
        DataSet data = new dalAR(loginer).GetReportData_Checklist(DocNoFrom, DocNoTo, DateFrom, DateTo);
        return ZipTools.CompressionDataSet(data);
    }


    public byte[] AR_GetReportData(byte[] loginTicket, string DocNoFrom, string DocNoTo, DateTime DateFrom, DateTime DateTo)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
        DataSet data = new dalAR(loginer).GetReportData(DocNoFrom, DocNoTo, DateFrom, DateTo);
        return ZipTools.CompressionDataSet(data);
    }


    #endregion


    #region 应付款(AP Account Payable)的WCF接口,对应的数据层是dalAP

    public byte[] AP_GetBusinessByKey(byte[] loginTicket, string keyValue)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataSet data = new dalAP(loginer).GetBusinessByKey(keyValue);
        return ZipTools.CompressionDataSet(data);
    }

    public byte[] AP_GetSummaryByParam(byte[] loginTicket, string DocNoFrom, string DocNoTo, DateTime docDateFrom, DateTime docDateTo)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataTable data = new dalAP(loginer).GetSummaryByParam(DocNoFrom, DocNoTo, docDateFrom, docDateTo);
        return ZipTools.CompressionDataSet(ServerLibrary.TableToDataSet(data));
    }

    public byte[] AP_Update(byte[] loginTicket, byte[] saveData)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataSet ds = ZipTools.DecompressionDataSet(saveData);
        SaveResult result = new dalAP(loginer).Update(ds);
        return ZipTools.CompressionObject(result);
    }

    public bool AP_Delete(byte[] loginTicket, string keyValue)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
        return new dalAP(loginer).Delete(keyValue);
    }

    public bool AP_CheckNoExists(byte[] loginTicket, string keyValue)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
        return new dalAP(loginer).CheckNoExists(keyValue);
    }

    public void AP_ApprovalBusiness(byte[] loginTicket, string keyValue, string flagApp, string appUser, DateTime appDate)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
        new dalAP(loginer).ApprovalBusiness(keyValue, flagApp, appUser, appDate);
    }

    public byte[] AP_GetReportData(byte[] loginTicket, string DocNoFrom, string DocNoTo, DateTime DateFrom, DateTime DateTo)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
        DataSet data = new dalAP(loginer).GetReportData(DocNoFrom, DocNoTo, DateFrom, DateTo);
        return ZipTools.CompressionDataSet(data);
    }

    public byte[] AP_GetReportData_Checklist(byte[] loginTicket, string DocNoFrom, string DocNoTo, DateTime DateFrom, DateTime DateTo)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
        DataSet data = new dalAP(loginer).GetReportData_Checklist(DocNoFrom, DocNoTo, DateFrom, DateTo);
        return ZipTools.CompressionDataSet(data);
    }

    #endregion

}
