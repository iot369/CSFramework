using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// 注意: 如果更改此处的接口名称 "ISalesModuleService"，也必须更新 Web.config 中对 "ISalesModuleService" 的引用。
[ServiceContract]
public interface ISalesModuleService
{

    #region 销售合同(Sales Contract)的WCF接口,SC对应的数据层是dalSC

    [OperationContract]
    bool SC_Delete(byte[] loginTicket, string keyValue);

    #endregion

    #region 销售订单(Sales Order)的WCF接口,SO对应的数据层是dalSO

    [OperationContract]
    void SO_ApprovalBusiness(byte[] loginTicket, string keyValue, string flagApp, string appUser, DateTime appDate);

    [OperationContract]
    bool SO_CheckNoExists(byte[] loginTicket, string keyValue);

    [OperationContract]
    bool SO_Delete(byte[] loginTicket, string keyValue);

    [OperationContract]
    byte[] SO_GetBusinessByKey(byte[] loginTicket, string keyValue);

    [OperationContract]
    byte[] SO_GetReportData(byte[] loginTicket, string DocNoFrom, string DocNoTo, DateTime DateFrom, DateTime DateTo);

    [OperationContract]
    byte[] SO_GetSummaryByParam(byte[] loginTicket, string DocNoFrom, string DocNoTo, DateTime docDateFrom, DateTime docDateTo);

    [OperationContract]
    byte[] SO_Update(byte[] loginTicket, byte[] saveData);

    #endregion
}
