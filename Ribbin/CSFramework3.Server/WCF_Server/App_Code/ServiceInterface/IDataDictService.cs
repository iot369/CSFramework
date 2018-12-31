using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CSFramework.Common;
using System.Net.Security;

// 注意: 如果更改此处的接口名称 "IDataDictService"，也必须更新 Web.config 中对 "IDataDictService" 的引用。
[ServiceContract]
public interface IDataDictService
{
    [OperationContract]
    bool AddCommonType(byte[] loginTicket, int code, string name);

    [OperationContract]
    bool CheckNoExists(byte[] loginTicket, string keyValue, string ORM_TypeName);

    [OperationContract]
    bool Delete(byte[] loginTicket, string keyValue, string ORM_TypeName);

    [OperationContract]
    bool DeleteCommonType(byte[] loginTicket, int code);

    [OperationContract]
    byte[] DownloadDicts(byte[] loginTicket);

    [OperationContract]
    byte[] FuzzySearchCustomer(byte[] loginTicket, string customerFrom, string customerTo, string customerName, string customerAttribute);

    [OperationContract]
    byte[] FuzzySearchCustomerByContent(byte[] loginTicket, string content);

    [OperationContract]
    byte[] FuzzySearchCustomerByAttributes(byte[] loginTicket, string attributeCodes, string content);

    [OperationContract]
    byte[] FuzzySearchProduct(byte[] loginTicket, string content);

    [OperationContract]
    byte[] GetCustomerByAttributeCodes(byte[] loginTicket, string attributeCodes, bool nameWithCode);

    [OperationContract]
    byte[] GetDataByKey(byte[] loginTicket, string ORM_TypeName, string key);

    [OperationContract]
    byte[] GetDataDictByTableName(byte[] loginTicket, string tableName);

    [OperationContract]
    byte[] GetSummaryData(byte[] loginTicket, string ORM_TypeName);

    [OperationContract]
    bool IsExistsCommonType(byte[] loginTicket, int id);

    [OperationContract]
    byte[] SearchCommonType(byte[] loginTicket, int dataType);

    [OperationContract]
    bool Update(byte[] loginTicket, byte[] bs, string ORM_TypeName);

    [OperationContract]
    byte[] UpdateEx(byte[] loginTicket, byte[] bs, string ORM_TypeName);

}
