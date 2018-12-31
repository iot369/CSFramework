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

// 注意: 如果更改此处的类名 "InventoryModuleService"，也必须更新 Web.config 中对 "InventoryModuleService" 的引用。
public class InventoryModuleService : IInventoryModuleService
{
    #region 库存调整(IA)的WCF接口,IA对应的数据层是dalIA

    public byte[] IA_GetBusinessByKey(byte[] loginTicket, string keyValue)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataSet data = new dalIA(loginer).GetBusinessByKey(keyValue);
        return ZipTools.CompressionDataSet(data);
    }

    public byte[] IA_GetSummaryByParam(byte[] loginTicket, string DocNoFrom, string DocNoTo, DateTime docDateFrom, DateTime docDateTo)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataTable data = new dalIA(loginer).GetSummaryByParam(DocNoFrom, DocNoTo, docDateFrom, docDateTo);
        return ZipTools.CompressionDataSet(ServerLibrary.TableToDataSet(data));
    }

    public byte[] IA_Update(byte[] loginTicket, byte[] saveData)
    {
        try
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataSet ds = ZipTools.DecompressionDataSet(saveData);
            SaveResult result = new dalIA(loginer).Update(ds);
            return ZipTools.CompressionObject(result);
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }

    public bool IA_Delete(byte[] loginTicket, string keyValue)
    {
        try
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            return new dalIA(loginer).Delete(keyValue);
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }

    public bool IA_CheckNoExists(byte[] loginTicket, string keyValue)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
        return new dalIA(loginer).CheckNoExists(keyValue);
    }

    public void IA_ApprovalBusiness(byte[] loginTicket, string keyValue, string flagApp, string appUser, DateTime appDate)
    {
        try
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            new dalIA(loginer).ApprovalBusiness(keyValue, flagApp, appUser, appDate);
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }

    #endregion

    #region 库存盘点(IC)的WCF接口,IC对应的数据层是dalIC

    public byte[] IC_GetBusinessByKey(byte[] loginTicket, string keyValue)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataSet data = new dalIC(loginer).GetBusinessByKey(keyValue);
        return ZipTools.CompressionDataSet(data);
    }

    public byte[] IC_GetSummaryByParam(byte[] loginTicket, string DocNoFrom, string DocNoTo, DateTime docDateFrom, DateTime docDateTo)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataTable data = new dalIC(loginer).GetSummaryByParam(DocNoFrom, DocNoTo, docDateFrom, docDateTo);
        return ZipTools.CompressionDataSet(ServerLibrary.TableToDataSet(data));
    }

    public byte[] IC_Update(byte[] loginTicket, byte[] saveData)
    {
        try
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataSet ds = ZipTools.DecompressionDataSet(saveData);
            SaveResult result = new dalIC(loginer).Update(ds);
            return ZipTools.CompressionObject(result);

        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }

    public bool IC_Delete(byte[] loginTicket, string keyValue)
    {
        try
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            return new dalIC(loginer).Delete(keyValue);
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }

    public bool IC_CheckNoExists(byte[] loginTicket, string keyValue)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
        return new dalIC(loginer).CheckNoExists(keyValue);
    }

    public void IC_ApprovalBusiness(byte[] loginTicket, string keyValue, string flagApp, string appUser, DateTime appDate)
    {
        try
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            new dalIC(loginer).ApprovalBusiness(keyValue, flagApp, appUser, appDate);
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }

    #endregion

    #region 入库单(IN)的WCF接口,IN对应的数据层是dalIN

    public byte[] IN_GetBusinessByKey(byte[] loginTicket, string keyValue)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataSet data = new dalIN(loginer).GetBusinessByKey(keyValue);
        return ZipTools.CompressionDataSet(data);
    }

    public byte[] IN_GetSummaryByParam(byte[] loginTicket, string DocNoFrom, string DocNoTo, DateTime docDateFrom, DateTime docDateTo)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataTable data = new dalIN(loginer).GetSummaryByParam(DocNoFrom, DocNoTo, docDateFrom, docDateTo);
        return ZipTools.CompressionDataSet(ServerLibrary.TableToDataSet(data));
    }

    public byte[] IN_Update(byte[] loginTicket, byte[] saveData)
    {
        try
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataSet ds = ZipTools.DecompressionDataSet(saveData);
            SaveResult result = new dalIN(loginer).Update(ds);
            return ZipTools.CompressionObject(result);
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }

    public bool IN_Delete(byte[] loginTicket, string keyValue)
    {
        try
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            return new dalIN(loginer).Delete(keyValue);
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }

    public bool IN_CheckNoExists(byte[] loginTicket, string keyValue)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
        return new dalIN(loginer).CheckNoExists(keyValue);
    }

    public void IN_ApprovalBusiness(byte[] loginTicket, string keyValue, string flagApp, string appUser, DateTime appDate)
    {
        try
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            new dalIN(loginer).ApprovalBusiness(keyValue, flagApp, appUser, appDate);
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }

    #endregion

    #region 出库单(IO)的WCF接口,IO对应的数据层是dalIO

    public byte[] IO_GetBusinessByKey(byte[] loginTicket, string keyValue)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataSet data = new dalIO(loginer).GetBusinessByKey(keyValue);
        return ZipTools.CompressionDataSet(data);
    }

    public byte[] IO_GetSummaryByParam(byte[] loginTicket, string DocNoFrom, string DocNoTo, DateTime docDateFrom, DateTime docDateTo)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataTable data = new dalIO(loginer).GetSummaryByParam(DocNoFrom, DocNoTo, docDateFrom, docDateTo);
        return ZipTools.CompressionDataSet(ServerLibrary.TableToDataSet(data));
    }

    public byte[] IO_Update(byte[] loginTicket, byte[] saveData)
    {
        try
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataSet ds = ZipTools.DecompressionDataSet(saveData);
            SaveResult result = new dalIO(loginer).Update(ds);
            return ZipTools.CompressionObject(result);
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }

    public bool IO_Delete(byte[] loginTicket, string keyValue)
    {
        try
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            return new dalIO(loginer).Delete(keyValue);
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }

    public bool IO_CheckNoExists(byte[] loginTicket, string keyValue)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
        return new dalIO(loginer).CheckNoExists(keyValue);
    }

    public void IO_ApprovalBusiness(byte[] loginTicket, string keyValue, string flagApp, string appUser, DateTime appDate)
    {
        try
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            new dalIO(loginer).ApprovalBusiness(keyValue, flagApp, appUser, appDate);
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }

    #endregion
}
