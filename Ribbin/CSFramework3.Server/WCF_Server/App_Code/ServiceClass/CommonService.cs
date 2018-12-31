using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CSFramework.Core;
using CSFramework.Common;
using CSFramework3.Server.DataAccess.DAL_System;
using System.Data;

// 注意: 如果更改此处的类名 "CommonService"，也必须更新 Web.config 中对 "CommonService" 的引用。
public class CommonService : ICommonService
{

    public bool TestConnection(byte[] validationTicket)
    {
        bool pass = WebServiceSecurity.ValidateLoginIdentity(validationTicket);

        //检查校验码成功,有效的登录请求.
        if (pass)
        {

            IWriteSQLConfigValue cfgWebConfig = new WebConfigCfg();

            //设置连接系统数据库的参数，重要！
            SqlConfiguration.SetSQLConfig(cfgWebConfig);

            return new dalCommon(null).TestConnection();
        }
        else
            return false;
    }


    public byte[] GetSystemDataSet(byte[] validationTicket)
    {
        bool pass = WebServiceSecurity.ValidateLoginIdentity(validationTicket);

        //检查校验码成功,有效的登录请求.
        if (pass)
        {
            DataTable data = new dalCommon(null).GetSystemDataSet();
            return ZipTools.CompressionDataSet(ServerLibrary.TableToDataSet(data));
        }
        else
            return null;
    }


    public byte[] GetTableFields(byte[] loginTicket, string tableName)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataTable data = new dalCommon(loginer).GetTableFields(tableName);
        return ZipTools.CompressionDataSet(ServerLibrary.TableToDataSet(data));
    }


    public byte[] GetBusinessTables(byte[] loginTicket)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataTable data = new dalCommon(loginer).GetBusinessTables();
        return ZipTools.CompressionDataSet(ServerLibrary.TableToDataSet(data));
    }


    public byte[] GetModules(byte[] loginTicket)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataTable data = new dalCommon(loginer).GetModules();
        return ZipTools.CompressionDataSet(ServerLibrary.TableToDataSet(data));
    }


    public byte[] GetTableFieldsDef(byte[] loginTicket, string tableName, bool onlyDisplayField)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataTable data = new dalCommon(loginer).GetTableFieldsDef(tableName, onlyDisplayField);
        return ZipTools.CompressionDataSet(ServerLibrary.TableToDataSet(data));
    }


    public byte[] GetAttachedFiles(byte[] loginTicket, string docID)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataTable data = new dalAttachFile(loginer).GetData(docID);
        return ZipTools.CompressionDataSet(ServerLibrary.TableToDataSet(data));
    }



    public byte[] SearchLog(byte[] loginTicket, string logUser, string tableName, DateTime dateFrom, DateTime dateTo)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataSet data = new dalEditLogHistory(loginer).SearchLog(logUser, tableName, dateFrom, dateTo);
        return ZipTools.CompressionDataSet(data);
    }


    public byte[] GetLogFieldDef(byte[] loginTicket, string tableName)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataTable data = new dalEditLogHistory(loginer).GetLogFieldDef(tableName);
        return ZipTools.CompressionDataSet(ServerLibrary.TableToDataSet(data));
    }


    public string[] GetTracedFields(byte[] loginTicket, string tableName)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
        return new dalEditLogHistory(loginer).GetTracedFields(tableName);
    }


    public bool SaveFieldDef(byte[] loginTicket, byte[] data)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
        DataSet ds = ZipTools.DecompressionDataSet(data);
        return new dalEditLogHistory(loginer).SaveFieldDef(ds.Tables[0]);
    }



    public void WriteLog(byte[] loginTicket, string logID, byte[] originalData, byte[] changes,
        string tableName, string keyFieldName, bool isMaster)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataSet dsOriginal = ZipTools.DecompressionDataSet(originalData);
        DataSet dsChanges = ZipTools.DecompressionDataSet(changes);

        new dalEditLogHistory(loginer).WriteLog(logID,
            dsOriginal.Tables[0], dsChanges.Tables[0], tableName, keyFieldName, isMaster);
    }



    public byte[] GetDB4Backup(byte[] loginTicket)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
        DataTable data = new dalCommon(null).GetDB4Backup();
        return ZipTools.CompressionDataSet(ServerLibrary.TableToDataSet(data));
    }


    public byte[] GetBackupHistory(byte[] loginTicket, int topList)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
        DataTable data = new dalCommon(null).GetBackupHistory(topList);
        return ZipTools.CompressionDataSet(ServerLibrary.TableToDataSet(data));
    }


    public bool BackupDatabase(string DBNAME, string BKPATH)
    {
        try
        {
            new dalCommon(null).BackupDatabase(DBNAME, BKPATH);
            return true;
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }


    public bool RestoreDatabase(string BKFILE, string DBNAME)
    {
        try
        {
            new dalCommon(null).RestoreDatabase(BKFILE, DBNAME);
            return true;
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }

    public string GetDataSN(byte[] loginTicket, string dataCode, bool asHeader)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
        return new dalCommon(loginer).GetDataSN(dataCode, asHeader);
    }

    public byte[] SearchOutstanding(byte[] loginTicket, string invoiceNo, string customer, DateTime dateFrom, DateTime dateTo, DateTime dateEnd, string outstandingType)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
        DataTable data = new dalCommon(loginer).SearchOutstanding(invoiceNo, customer, dateFrom, dateTo, dateEnd, outstandingType);
        return ZipTools.CompressionDataSet(ServerLibrary.TableToDataSet(data));
    }

}
