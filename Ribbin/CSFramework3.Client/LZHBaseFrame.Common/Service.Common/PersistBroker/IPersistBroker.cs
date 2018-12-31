using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;

namespace Service.Common.PersistBroker
{
    /// <summary>
    /// 原始数据层类的接口
    /// </summary>
    public interface IPersistBroker : IPersistBrokerTransaction
    {
        /// <summary>
        /// 修改,支持手动关闭连接
        /// 是否 自动关闭连接
        /// </summary>
        bool AutoCloseConnection
        {
            get;
            set;
        }

        /// <summary>
        /// 是否Log用户操作
        /// </summary>
        bool AllowSQLLog
        {
            get;
            set;
        }

        /// <summary>
        /// Log数据库
        /// </summary>
        string SQLLogConnectString
        {
            get;
            set;
        }

        /// <summary>
        /// 修改,允许记录当前用户
        /// 获取或者设置执行用户
        /// </summary>
        string ExecuteUser
        {
            get;
            set;
        }

        /// <summary>
        /// 执行SQL并返回影响行数
        /// </summary>
        /// <param name="commandText">SQL语句</param>
        /// <param name="parameters">参数列表</param>
        /// <param name="parameterTypes">参数类型列表</param>
        /// <param name="parameterValues">参数值列表</param>
        /// <returns>影响行数</returns>
        int ExecuteWithReturn(string commandText, string[] parameters, Type[] parameterTypes, object[] parameterValues);
        /// <summary>
        /// 执行SQL并返回影响行数
        /// </summary>
        /// <param name="commandText">SQL语句</param>
        /// <returns>影响行数</returns>
        int ExecuteWithReturn(string commandText);
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="commandText">SQL语句</param>
        void Execute(string commandText);
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="commandText">SQL语句</param>
        /// <param name="parameters">参数列表</param>
        /// <param name="parameterTypes">参数类型列表</param>
        /// <param name="parameterValues">参数值列表</param>
        void Execute(string commandText, string[] parameters, Type[] parameterTypes, object[] parameterValues);
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="commandText">SQL语句</param>
        /// <param name="parameters">参数列表</param>
        /// <param name="parameterTypes">参数类型列表</param>
        /// <param name="parameterValues">参数值列表</param>
        int Execute(string commandText, string[] parameters, Type[] parameterTypes, object[] parameterValues, bool returnID);
        /// <summary>
        /// 执行SQL 语句查询并返回弱类型DataSet
        /// </summary>
        /// <param name="commandText">SQL语句</param>
        /// <returns>查询结果（DataSet）</returns>
        DataSet Query(string commandText);
        /// <summary>
        /// 执行SQL 语句查询并返回弱类型DataSet
        /// </summary>
        /// <param name="commandText">SQL语句</param>
        /// /// <param name="parameters">参数列表</param>
        /// <param name="parameterTypes">参数类型列表</param>
        /// <param name="parameterValues">参数值列表</param>
        /// <returns>查询结果（DataSet）</returns>
        DataSet Query(string commandText, string[] parameters, Type[] parameterTypes, object[] parameterValues);
        /// <summary>
        /// 执行SQL 语句查询并返回类型object
        /// </summary>
        /// <param name="commandText">SQL语句</param>
        /// <returns>查询结果（object）</returns>
        object QuerySingle(string commandText);
        /// <summary>
        /// 执行Procedure
        /// </summary>
        /// <param name="commandText">Procedure名称</param>
        /// <param name="parameters">参数列表</param>
        void ExecuteProcedure(string commandText, ref ArrayList parameters);
        /// <summary>
        /// 执行Procedure
        /// </summary>
        /// <param name="commandText">Procedure名称</param>
        /// <param name="parameters">参数列表</param>
        DataSet GetDataSetByProc(string commandText, ref ArrayList parameters, string strSql);

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        void OpenConnection();
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        void CloseConnection();
    }

}