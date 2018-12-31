using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// 注意: 如果更改此处的接口名称 "IInventoryModuleService"，也必须更新 Web.config 中对 "IInventoryModuleService" 的引用。
[ServiceContract]
public interface IInventoryModuleService
{
    #region 库存调整(IA Inventory Adjustment)的WCF接口,IA对应的数据层是dalIA

    [OperationContract]
    void IA_ApprovalBusiness(byte[] loginTicket, string keyValue, string flagApp, string appUser, DateTime appDate);

    [OperationContract]
    bool IA_CheckNoExists(byte[] loginTicket, string keyValue);

    [OperationContract]
    bool IA_Delete(byte[] loginTicket, string keyValue);

    [OperationContract]
    byte[] IA_GetBusinessByKey(byte[] loginTicket, string keyValue);

    [OperationContract]
    byte[] IA_GetSummaryByParam(byte[] loginTicket, string DocNoFrom, string DocNoTo, DateTime docDateFrom, DateTime docDateTo);

    [OperationContract]
    byte[] IA_Update(byte[] loginTicket, byte[] saveData);

    #endregion

    #region 库存盘点(IC Inventory Check)的WCF接口,IC对应的数据层是dalIC

    [OperationContract]
    void IC_ApprovalBusiness(byte[] loginTicket, string keyValue, string flagApp, string appUser, DateTime appDate);

    [OperationContract]
    bool IC_CheckNoExists(byte[] loginTicket, string keyValue);

    [OperationContract]
    bool IC_Delete(byte[] loginTicket, string keyValue);

    [OperationContract]
    byte[] IC_GetBusinessByKey(byte[] loginTicket, string keyValue);

    [OperationContract]
    byte[] IC_GetSummaryByParam(byte[] loginTicket, string DocNoFrom, string DocNoTo, DateTime docDateFrom, DateTime docDateTo);

    [OperationContract]
    byte[] IC_Update(byte[] loginTicket, byte[] saveData);

    #endregion

    #region 入仓单(IN Inventory IN)的WCF接口,IA对应的数据层是dalIN

    [OperationContract]
    void IN_ApprovalBusiness(byte[] loginTicket, string keyValue, string flagApp, string appUser, DateTime appDate);

    [OperationContract]
    bool IN_CheckNoExists(byte[] loginTicket, string keyValue);

    [OperationContract]
    bool IN_Delete(byte[] loginTicket, string keyValue);

    [OperationContract]
    byte[] IN_GetBusinessByKey(byte[] loginTicket, string keyValue);

    [OperationContract]
    byte[] IN_GetSummaryByParam(byte[] loginTicket, string DocNoFrom, string DocNoTo, DateTime docDateFrom, DateTime docDateTo);

    [OperationContract]
    byte[] IN_Update(byte[] loginTicket, byte[] saveData);

    #endregion

    #region 出仓单(IO Inventory OUT)的WCF接口,IO对应的数据层是dalIO

    [OperationContract]
    void IO_ApprovalBusiness(byte[] loginTicket, string keyValue, string flagApp, string appUser, DateTime appDate);

    [OperationContract]
    bool IO_CheckNoExists(byte[] loginTicket, string keyValue);

    [OperationContract]
    bool IO_Delete(byte[] loginTicket, string keyValue);

    [OperationContract]
    byte[] IO_GetBusinessByKey(byte[] loginTicket, string keyValue);

    [OperationContract]
    byte[] IO_GetSummaryByParam(byte[] loginTicket, string DocNoFrom, string DocNoTo, DateTime docDateFrom, DateTime docDateTo);

    [OperationContract]
    byte[] IO_Update(byte[] loginTicket, byte[] saveData);

    #endregion


}
