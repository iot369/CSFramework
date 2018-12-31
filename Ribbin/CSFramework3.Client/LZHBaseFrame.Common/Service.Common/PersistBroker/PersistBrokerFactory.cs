using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Common.Domain;

namespace Service.Common.PersistBroker
{
    public class PersistBrokerFactory
    {
        public static IPersistBroker PersistBroker(string connectString, System.Globalization.CultureInfo cultureInfo, string type)
        {
            if (string.IsNullOrEmpty(connectString))
                return null;

            if (cultureInfo == null)
            {
                cultureInfo = new System.Globalization.CultureInfo("en-US", false);
            }
            switch (type)
            {
                case "SQLSERVER":
                    return new Service.Common.PersistBroker.SqlPersistBroker(connectString, cultureInfo);
                //case "ODBCPersistBroker":
                //    return new Service.Common.PersistBroker.ODBCPersistBroker(connectString, cultureInfo);
                //case "ODPPersistBroker":
                //    return new Service.Common.PersistBroker.ODPPersistBroker(connectString, cultureInfo);
                default:
                    return new Service.Common.PersistBroker.SqlPersistBroker(connectString, cultureInfo);
            }
        }

        public static IPersistBroker PersistBroker( HOST hostInfo ,System.Globalization.CultureInfo cultureInfo)
        {
            if (hostInfo == null)
            {
                Log.Info("$Need_dbinfo");
                return null;
            }
            if (cultureInfo == null)
            {
                cultureInfo = new System.Globalization.CultureInfo("en-US", false);
            }
            if (hostInfo.DBTYPE == DBType.sqlserver)
            {
                return new Service.Common.PersistBroker.SqlPersistBroker(GetConnectString(hostInfo), cultureInfo);
            }
            else
            {
                //当前只支持sqlserver
                Log.Info("$dbtype_erro");
                return null;
                //return new Service.Common.PersistBroker.SqlPersistBroker(connectString, cultureInfo);
            }

        }


        public static string GetConnectString(HOST hostinfo)
        {
            string sqlConnectionStr = "";
            if (hostinfo.DBTYPE == DBType.sqlserver)
            {
                sqlConnectionStr = string.Format("server={0};database={1};uid={2};pwd={3}", hostinfo.master_HOST, hostinfo.master_DBNAME, hostinfo.USERID, hostinfo.PWD);
            }
            else if (hostinfo.DBTYPE == DBType.oracle)
            {
                sqlConnectionStr = string.Format("Driver={0};dbq = {1}; UID = {2}; PWD = {3};", hostinfo.master_HOST, hostinfo.master_DBNAME, hostinfo.USERID, hostinfo.PWD);
            }
           

            return sqlConnectionStr;
        }
        

        

    }
    public static class  DBType 
    {
        public static string sqlserver = "sqlserver";
        public static string oracle ="oracle";
            //其他数据类型
    
    }

}