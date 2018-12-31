using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// 注意: 如果更改此处的接口名称 "ICommonService"，也必须更新 Web.config 中对 "ICommonService" 的引用。
[ServiceContract]
public interface ICommonService
{

    [OperationContract]
    bool BackupDatabase(string DBNAME, string BKPATH);

    [OperationContract]
    byte[] GetAttachedFiles(byte[] loginTicket, string docID);

    [OperationContract]
    byte[] GetBackupHistory(byte[] loginTicket, int topList);

    [OperationContract]
    byte[] GetBusinessTables(byte[] loginTicket);

    [OperationContract]
    byte[] GetDB4Backup(byte[] loginTicket);

    [OperationContract]
    byte[] GetLogFieldDef(byte[] loginTicket, string tableName);

    [OperationContract]
    byte[] GetModules(byte[] loginTicket);

    [OperationContract]
    byte[] GetSystemDataSet(byte[] validationTicket);

    [OperationContract]
    byte[] GetTableFields(byte[] loginTicket, string tableName);

    [OperationContract]
    byte[] GetTableFieldsDef(byte[] loginTicket, string tableName, bool onlyDisplayField);

    [OperationContract]
    string[] GetTracedFields(byte[] loginTicket, string tableName);

    [OperationContract]
    bool RestoreDatabase(string BKFILE, string DBNAME);

    [OperationContract]
    bool SaveFieldDef(byte[] loginTicket, byte[] data);

    [OperationContract]
    byte[] SearchLog(byte[] loginTicket, string logUser, string tableName, DateTime dateFrom, DateTime dateTo);

    [OperationContract]
    bool TestConnection(byte[] validationTicket);

    [OperationContract]
    void WriteLog(byte[] loginTicket, string logID, byte[] originalData, byte[] changes, string tableName, string keyFieldName, bool isMaster);

    [OperationContract]
    string GetDataSN(byte[] loginTicket, string dataCode, bool asHeader);

    [OperationContract]
    byte[] SearchOutstanding(byte[] loginTicket, string invoiceNo, string customer, DateTime dateFrom, DateTime dateTo, DateTime dateEnd, string outstandingType);

}
