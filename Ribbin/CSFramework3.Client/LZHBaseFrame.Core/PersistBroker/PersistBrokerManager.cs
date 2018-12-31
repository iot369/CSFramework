using System;

namespace LZHBaseFrame.Core.PersistBroker
{
    /// <summary>
    /// PersistBrokerManager 的摘要说明。
    /// </summary>
    public class PersistBrokerManager
    {
        public PersistBrokerManager()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public static IPersistBroker PersistBroker(string connectionString)
        {
            return PersistBrokerManager.PersistBroker(connectionString, new System.Globalization.CultureInfo("en-US", false), false);
        }

        //public static IPersistBroker PersistBroker(bool usePool)
        //{
        //    return PersistBrokerPool.Pool(new System.Globalization.CultureInfo("en-US", false)).RetriveFromPool(usePool);
        //}

        public static IPersistBroker PersistBroker(string connectionString, System.Globalization.CultureInfo cultureInfo)
        {
            return PersistBrokerManager.PersistBroker(connectionString, cultureInfo, false);
        }

        public static IPersistBroker PersistBroker(string connectString, System.Globalization.CultureInfo cultureInfo, string type)
        {
            switch (type)
            {
                case "SqlPersistBroker":
                    return new LZHBaseFrame.Core.PersistBroker.SqlPersistBroker(connectString, cultureInfo);
                //case "ODBCPersistBroker":
                //    return new LZHBaseFrame.Core.PersistBroker.ODBCPersistBroker(connectString, cultureInfo);
                //case "ODPPersistBroker":
                //    return new LZHBaseFrame.Core.PersistBroker.ODPPersistBroker(connectString, cultureInfo);
                default:
                    return new LZHBaseFrame.Core.PersistBroker.SqlPersistBroker(connectString, cultureInfo);
            }
        }

        protected static IPersistBroker PersistBroker(string connectString, System.Globalization.CultureInfo cultureInfo, bool isUserInit)
        {
            if (string.IsNullOrEmpty(connectString))
                return null;

            if (cultureInfo == null)
            {
                cultureInfo = new System.Globalization.CultureInfo("en-US", false);
            }

            if (isUserInit)
            {
                return new LZHBaseFrame.Core.PersistBroker.SqlPersistBroker(connectString, cultureInfo);
                //return PersistBrokerPool.Pool(cultureInfo).RetriveFromPool(connectString);
            }
            else
            {
                return new LZHBaseFrame.Core.PersistBroker.SqlPersistBroker(connectString, cultureInfo);
                //return PersistBrokerPool.Pool(cultureInfo).RetriveFromPool();
            }
        }


    }
}