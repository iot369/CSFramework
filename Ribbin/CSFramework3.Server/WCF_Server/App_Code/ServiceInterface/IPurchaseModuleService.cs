using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;

// 注意: 如果更改此处的接口名称 "IPurchaseModuleService"，也必须更新 Web.config 中对 "IPurchaseModuleService" 的引用。
[ServiceContract]
public interface IPurchaseModuleService
{
    [OperationContract]
    bool PO_Delete(byte[] loginTicket, string docNo);

    [OperationContract]
    byte[] PO_GetBusinessByKey(byte[] loginTicket, string docNo);

    [OperationContract]
    byte[] PO_GetReportData(byte[] loginTicket, string DocNoFrom, string DocNoTo, DateTime DateFrom, DateTime DateTo);

    [OperationContract]
    byte[] PO_GetSummaryByParam(byte[] loginTicket, string docNoFrom, string docNoTo, DateTime docDateFrom, DateTime docDateTo, string StockCode, string Customer);

    [OperationContract]
    byte[] PO_Update(byte[] loginTicket, byte[] data);

    [OperationContract]
    bool PO_CheckNoExists(byte[] loginTicket, string keyValue);

    [OperationContract]
    void PO_ApprovalBusiness(byte[] loginTicket, string keyValue, string flagApp, string appUser, DateTime appDate);

}
