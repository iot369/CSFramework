using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CSFramework.Common;
using System.Data;
using CSFramework.Core;
using CSFramework3.Server.DataAccess.DAL_System;

// 注意: 如果更改此处的类名 "SystemSecurityService"，也必须更新 Web.config 中对 "SystemSecurityService" 的引用。
public class SystemSecurityService : ISystemSecurityService
{

    #region 用户管理(dalUser)的方法


    public byte[] U_GetUsers(byte[] loginTicket)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataTable data = new dalUser(loginer).GetUsers();
        return ZipTools.CompressionObject(ServerLibrary.TableToDataSet(data));
    }


    public byte[] U_GetUserReportData(byte[] loginTicket, DateTime createDateFrom, DateTime createDateTo)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataSet data = new dalUser(loginer).GetUserReportData(createDateFrom, createDateTo);
        return ZipTools.CompressionObject(data);
    }


    public byte[] U_GetUser(byte[] loginTicket, string account)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataTable data = new dalUser(loginer).GetUser(account);
        return ZipTools.CompressionObject(ServerLibrary.TableToDataSet(data));
    }


    public byte[] U_GetUserGroups(byte[] loginTicket, string account)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataTable data = new dalUser(loginer).GetUserGroups(account);
        return ZipTools.CompressionObject(ServerLibrary.TableToDataSet(data));
    }


    public byte[] U_GetUserByNovellID(byte[] loginTicket, string novellAccount)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataTable data = new dalUser(loginer).GetUserByNovellID(novellAccount);
        return ZipTools.CompressionObject(ServerLibrary.TableToDataSet(data));
    }


    public bool U_UpdateUser(byte[] loginTicket, byte[] userData)
    {
        try
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataSet data = ZipTools.DecompressionDataSet(userData);
            return new dalUser(loginer).Update(data);
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }


    public bool U_DeleteUser(byte[] loginTicket, string account)
    {
        try
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            return new dalUser(loginer).DeleteUser(account);
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }


    public bool U_ExistsUser(byte[] loginTicket, string account)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        return new dalUser(loginer).ExistsUser(account);
    }


    public bool U_ModifyPassword(byte[] loginTicket, string account, string pwd)
    {
        try
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            return new dalUser(loginer).ModifyPassword(account, pwd);
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }


    public byte[] U_GetUserAuthorities(byte[] loginTicket)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataTable data = new dalUser(loginer).GetUserAuthorities(loginer);
        return ZipTools.CompressionDataSet(ServerLibrary.TableToDataSet(data));
    }


    public void U_Logout(byte[] loginTicket)
    {
        try
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            new dalUser(loginer).Logout(loginer.Account);
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }


    public byte[] U_Login(byte[] validationTicket, byte[] loginUser, char LoginUserType)
    {
        bool pass = WebServiceSecurity.ValidateLoginIdentity(validationTicket);

        //检查校验码成功,有效的登录请求.
        if (pass)
        {
            LoginUser userInfo = ZipTools.DecompressionObject(loginUser) as LoginUser;
            DataTable dt = new dalUser(null).Login(userInfo, LoginUserType);
            return ZipTools.CompressionDataSet(ServerLibrary.TableToDataSet(dt));
        }
        else
            return null;
    }


    public bool U_ModifyPwdDirect(byte[] validationTicket, string account, string pwd, string DBName)
    {
        try
        {
            bool pass = WebServiceSecurity.ValidateLoginIdentity(validationTicket);

            //检查校验码成功,有效的登录请求.
            if (pass)
                return new dalUser(null).ModifyPwdDirect(account, pwd, DBName);
            else
                return false;
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }


    public byte[] U_GetUserDirect(byte[] validationTicket, string account, string DBName)
    {
        bool pass = WebServiceSecurity.ValidateLoginIdentity(validationTicket);

        //检查校验码成功,有效的登录请求.
        if (pass)
        {
            DataTable dt = new dalUser(null).GetUserDirect(account, DBName);
            return ZipTools.CompressionDataSet(ServerLibrary.TableToDataSet(dt));
        }
        else
            return null;
    }

    #endregion

    #region 用户组管理(dalUserGroup)的方法



    public byte[] G_GetAuthorityItem(byte[] loginTicket)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

        DataTable dt = new dalUserGroup(loginer).GetAuthorityItem();
        return ZipTools.CompressionDataSet(ServerLibrary.TableToDataSet(dt));
    }


    public byte[] G_GetUserGroup(byte[] loginTicket)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
        DataTable dt = new dalUserGroup(loginer).GetUserGroup();
        return ZipTools.CompressionDataSet(ServerLibrary.TableToDataSet(dt));
    }


    public byte[] G_GetUserGroupByCode(byte[] loginTicket, string groupCode)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
        DataSet ds = new dalUserGroup(loginer).GetUserGroup(groupCode);
        return ZipTools.CompressionDataSet(ds);
    }


    public byte[] G_GetFormTagCustomName(byte[] loginTicket)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
        DataTable dt = new dalUserGroup(loginer).GetFormTagCustomName();
        return ZipTools.CompressionDataSet(ServerLibrary.TableToDataSet(dt));
    }


    public bool G_CheckNoExists(byte[] loginTicket, string groupCode)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
        return new dalUserGroup(loginer).CheckNoExists(groupCode);
    }


    public bool G_DeleteGroupByKey(byte[] loginTicket, string groupCode)
    {
        try
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            return new dalUserGroup(loginer).DeleteGroupByKey(groupCode);
        }
        catch (Exception ex)
        {
            throw new FaultException(ex.Message);
        }
    }


    public int G_GetFormAuthority(byte[] loginTicket, string account, int moduleID, string menuName)
    {
        Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
        return new dalUserGroup(loginer).GetFormAuthority(account, moduleID, menuName);
    }

    #endregion


}
