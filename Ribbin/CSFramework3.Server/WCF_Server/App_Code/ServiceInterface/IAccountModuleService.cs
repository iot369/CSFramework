using System.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[ServiceContract]
public interface IAccountModuleService
{
    #region 应收款(AR Account Receive)的WCF接口,对应的数据层是dalAR

    [OperationContract]
    void AR_ApprovalBusiness(byte[] loginTicket, string keyValue, string flagApp, string appUser, DateTime appDate);

    [OperationContract]
    bool AR_CheckNoExists(byte[] loginTicket, string keyValue);

    [OperationContract]
    bool AR_Delete(byte[] loginTicket, string keyValue);

    [OperationContract]
    byte[] AR_GetBusinessByKey(byte[] loginTicket, string keyValue);

    [OperationContract]
    byte[] AR_GetSummaryByParam(byte[] loginTicket, string DocNoFrom, string DocNoTo, DateTime docDateFrom, DateTime docDateTo);

    [OperationContract]
    byte[] AR_Update(byte[] loginTicket, byte[] saveData);

    [OperationContract]
    byte[] AR_GetReportData_Checklist(byte[] loginTicket, string DocNoFrom, string DocNoTo, DateTime DateFrom, DateTime DateTo);

    [OperationContract]
    byte[] AR_GetReportData(byte[] loginTicket, string DocNoFrom, string DocNoTo, DateTime DateFrom, DateTime DateTo);

    #endregion


    #region 应付款(AP Account Payable)的WCF接口,对应的数据层是dalAP

    [OperationContract]
    void AP_ApprovalBusiness(byte[] loginTicket, string keyValue, string flagApp, string appUser, DateTime appDate);

    [OperationContract]
    bool AP_CheckNoExists(byte[] loginTicket, string keyValue);

    [OperationContract]
    bool AP_Delete(byte[] loginTicket, string keyValue);

    [OperationContract]
    byte[] AP_GetBusinessByKey(byte[] loginTicket, string keyValue);

    [OperationContract]
    byte[] AP_GetSummaryByParam(byte[] loginTicket, string DocNoFrom, string DocNoTo, DateTime docDateFrom, DateTime docDateTo);

    [OperationContract]
    byte[] AP_Update(byte[] loginTicket, byte[] saveData);

    [OperationContract]
    byte[] AP_GetReportData(byte[] loginTicket, string DocNoFrom, string DocNoTo, DateTime DateFrom, DateTime DateTo);

    #endregion
}
