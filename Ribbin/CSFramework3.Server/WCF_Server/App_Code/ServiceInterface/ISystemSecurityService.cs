using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// 注意: 如果更改此处的接口名称 "ISystemSecurityService"，也必须更新 Web.config 中对 "ISystemSecurityService" 的引用。
[ServiceContract]
public interface ISystemSecurityService
{

    #region 用户管理(dalUser)的方法

    [OperationContract]
    byte[] U_GetUsers(byte[] loginTicket);

    [OperationContract]
    byte[] U_GetUserReportData(byte[] loginTicket, DateTime createDateFrom, DateTime createDateTo);

    [OperationContract]
    byte[] U_GetUser(byte[] loginTicket, string account);

    [OperationContract]
    byte[] U_GetUserGroups(byte[] loginTicket, string account);

    [OperationContract]
    byte[] U_GetUserByNovellID(byte[] loginTicket, string novellAccount);

    [OperationContract]
    bool U_UpdateUser(byte[] loginTicket, byte[] userData);

    [OperationContract]
    bool U_DeleteUser(byte[] loginTicket, string account);

    [OperationContract]
    bool U_ExistsUser(byte[] loginTicket, string account);

    [OperationContract]
    bool U_ModifyPassword(byte[] loginTicket, string account, string pwd);

    [OperationContract]
    byte[] U_GetUserAuthorities(byte[] loginTicket);

    [OperationContract]
    void U_Logout(byte[] loginTicket);

    [OperationContract]
    byte[] U_Login(byte[] validationTicket, byte[] loginUser, char LoginUserType);

    [OperationContract]
    bool U_ModifyPwdDirect(byte[] validationTicket, string account, string pwd, string DBName);

    [OperationContract]
    byte[] U_GetUserDirect(byte[] validationTicket, string account, string DBName);


    #endregion

    #region 用户组管理(dalUserGroup)的方法

    [OperationContract]
    byte[] G_GetAuthorityItem(byte[] loginTicket);

    [OperationContract]
    byte[] G_GetUserGroup(byte[] loginTicket);

    [OperationContract]
    byte[] G_GetUserGroupByCode(byte[] loginTicket, string groupCode);

    [OperationContract]
    byte[] G_GetFormTagCustomName(byte[] loginTicket);

    [OperationContract]
    bool G_CheckNoExists(byte[] loginTicket, string groupCode);

    [OperationContract]
    bool G_DeleteGroupByKey(byte[] loginTicket, string groupCode);

    [OperationContract]
    int G_GetFormAuthority(byte[] loginTicket, string account, int moduleID, string menuName);


    #endregion



}
