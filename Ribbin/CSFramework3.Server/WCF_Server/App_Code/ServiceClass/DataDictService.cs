using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CSFramework.Common;
using CSFramework.Core;
using CSFramework3.Server.DataAccess.DAL_DataDict;
using System.Data;
using CSFramework3.Server.DataAccess.DAL_System;
using CSFramework3.Server.DataAccess.DAL_Base;

[ServiceBehavior(IncludeExceptionDetailInFaults = true)]
public class DataDictService : IDataDictService
{

    public byte[] FuzzySearchCustomer(byte[] loginTicket, string customerFrom, string customerTo, string customerName, string customerAttribute)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataTable data = new dalCustomer(loginer).SearchBy(customerFrom, customerTo, customerName, customerAttribute);
        return ZipTools.CompressionObject(ServerLibrary.TableToDataSet(data));
    }

    //模糊查询
    public byte[] FuzzySearchCustomerByContent(byte[] loginTicket, string content)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataTable data = new dalCustomer(loginer).FuzzySearch(content);
        return ZipTools.CompressionObject(ServerLibrary.TableToDataSet(data));
    }

    //模糊查询
    public byte[] FuzzySearchCustomerByAttributes(byte[] loginTicket, string attributeCodes, string content)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataTable data = new dalCustomer(loginer).FuzzySearch(attributeCodes, content);
        return ZipTools.CompressionObject(ServerLibrary.TableToDataSet(data));
    }

    public byte[] FuzzySearchProduct(byte[] loginTicket, string content)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataTable data = new dalProduct(loginer).FuzzySearch(content);
        return ZipTools.CompressionObject(ServerLibrary.TableToDataSet(data));
    }


    public byte[] GetCustomerByAttributeCodes(byte[] loginTicket, string attributeCodes, bool nameWithCode)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataTable data = new dalCustomer(loginer).GetCustomerByAttributeCodes(attributeCodes, nameWithCode);
        return ZipTools.CompressionObject(ServerLibrary.TableToDataSet(data));
    }


    public byte[] GetDataByKey(byte[] loginTicket, string ORM_TypeName, string key)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        dalBaseDataDict dict = dalBaseDataDict.CreateDalByORM(loginer, ORM_TypeName);
        DataTable data = dict.GetDataByKey(key);
        return ZipTools.CompressionObject(ServerLibrary.TableToDataSet(data));
    }


    public byte[] GetSummaryData(byte[] loginTicket, string ORM_TypeName)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        dalBaseDataDict dict = dalBaseDataDict.CreateDalByORM(loginer, ORM_TypeName);
        DataTable data = dict.GetSummaryData();
        return ZipTools.CompressionObject(ServerLibrary.TableToDataSet(data));
    }


    public byte[] DownloadDicts(byte[] loginTicket)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataSet ds = new dalBaseDataDict(loginer).DownloadDicts();
        return ZipTools.CompressionObject(ds);
    }


    public byte[] GetDataDictByTableName(byte[] loginTicket, string tableName)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        dalBaseDataDict dict = new dalBaseDataDict(loginer, tableName);
        DataTable data = dict.GetSummaryData();
        return ZipTools.CompressionObject(ServerLibrary.TableToDataSet(data));
    }


    public bool Update(byte[] loginTicket, byte[] bs, string ORM_TypeName)
    {
        try
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataSet data = ZipTools.DecompressionDataSet(bs);
            dalBaseDataDict dict = dalBaseDataDict.CreateDalByORM(loginer, ORM_TypeName);
            return dict.Update(data);
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }

    public byte[] UpdateEx(byte[] loginTicket, byte[] bs, string ORM_TypeName)
    {
        try
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataSet data = ZipTools.DecompressionDataSet(bs);
            dalBaseDataDict dict = dalBaseDataDict.CreateDalByORM(loginer, ORM_TypeName);
            SaveResultEx result = dict.UpdateEx(data);//保存数据
            return ZipTools.CompressionObject(result);//序列化返回对象
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }


    /// <summary>
    /// 删除一条数据字典记录
    /// </summary>
    /// <param name="loginTicket"></param>
    /// <param name="keyValue">主键</param>
    /// <param name="ORM_TypeName">ORM类型</param>
    /// <returns></returns>
    public bool Delete(byte[] loginTicket, string keyValue, string ORM_TypeName)
    {
        try
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            dalBaseDataDict dict = dalBaseDataDict.CreateDalByORM(loginer, ORM_TypeName);//创建DAL层实例
            return dict.Delete(keyValue);
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);//转换为客户端可截取的异常类型(FaultException)信息。
            //throw new FaultException("删除记录发生错误！");//或者提示更具体的异常信息，屏蔽WCF系统内部消息。
        }
    }


    public bool CheckNoExists(byte[] loginTicket, string keyValue, string ORM_TypeName)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        dalBaseDataDict dict = dalBaseDataDict.CreateDalByORM(loginer, ORM_TypeName);
        return dict.CheckNoExists(keyValue);
    }

    #region 公共数据字典表

    public byte[] SearchCommonType(byte[] loginTicket, int dataType)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataTable data = new dalCommonDataDict(loginer).SearchBy(dataType);
        return ZipTools.CompressionDataSet(ServerLibrary.TableToDataSet(data));
    }


    public bool AddCommonType(byte[] loginTicket, int code, string name)
    {
        try
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            return new dalCommonDataDict(loginer).AddCommonType(code, name);
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }


    public bool DeleteCommonType(byte[] loginTicket, int code)
    {
        try
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            return new dalCommonDataDict(loginer).DeleteCommonType(code);
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }


    public bool IsExistsCommonType(byte[] loginTicket, int id)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
        return new dalCommonDataDict(loginer).IsExistsCommonType(id);
    }

    #endregion

}
