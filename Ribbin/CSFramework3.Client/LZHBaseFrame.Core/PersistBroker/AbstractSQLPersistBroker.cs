using System;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using LZHBaseFrame.Common;

namespace LZHBaseFrame.Core.PersistBroker
{
    /// <summary>
    /// 数据访问控制类
    /// </summary>
    public abstract class AbstractSQLPersistBroker : MarshalByRefObject, IPersistBroker
    {
        public bool allowSQLLog = false;
        public string sqlLogConnString = String.Empty;

        public string executeUser = "MESDefaultUser";
        public bool autoCloseConn = true;
        /// <summary>
        ///修改,支持手动关闭连接
        /// 是否 自动关闭连接
        /// </summary>
        public virtual bool AutoCloseConnection
        {
            get
            {
                return autoCloseConn;
            }
            set
            {
                autoCloseConn = value;
            }
        }

        /// <summary>
        /// Laws Lu,2007/04/03 是否Log用户操作
        /// </summary>
        public virtual bool AllowSQLLog
        {
            get
            {
                return allowSQLLog;
            }
            set
            {
                allowSQLLog = value;
            }
        }

        /// <summary>
        /// Laws Lu,2007/04/03 Log数据库
        /// </summary>
        public virtual string SQLLogConnectString
        {
            get
            {
                return sqlLogConnString;
            }
            set
            {
                sqlLogConnString = value;
            }
        }

        /// <summary>
        /// Laws Lu,2007/04/03 修改,允许记录当前用户
        /// 获取或者设置执行用户
        /// </summary>
        public virtual string ExecuteUser
        {
            get
            {
                return executeUser;
            }
            set
            {
                executeUser = value;
            }
        }

        private System.Globalization.CultureInfo _cultureInfo = null;
        private IDbConnection _connection = null;
        private IDbTransaction _transaction = null;
        private object _lock = new object();


        public AbstractSQLPersistBroker(IDbConnection connection)
            : this(connection, new System.Globalization.CultureInfo("en-US", false))
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public AbstractSQLPersistBroker(IDbConnection connection, System.Globalization.CultureInfo cultureInfo)
        {
            this._connection = connection;
            this._cultureInfo = cultureInfo;
        }
        //modify by benny 从protected改为public
        public IDbConnection Connection
        {
            get
            {
                return _connection;
            }
        }

        protected IDbTransaction Transaction
        {
            get
            {
                return _transaction;
            }
        }

        public bool IsInTransaction
        {
            get
            {
                lock (_lock)
                {
                    if (this._transaction != null)
                    {
                        return true;
                    }

                    return false;
                }
            }
        }
        /// <summary>
        /// 执行SQL并返回影响行数
        /// </summary>
        /// <param name="commandText">SQL语句</param>
        /// <returns>影响行数</returns>
        public int ExecuteWithReturn(string commandText)
        {
            int i = 0;
            OpenConnection();
            using (IDbCommand command = this.Connection.CreateCommand())
            {
                command.CommandText = commandText;
                //if (!(command is Oracle.DataAccess.Client.OracleCommand))
                    command.Transaction = this.Transaction;

#if DEBUG
                DateTime dtStart = DateTime.Now;
                string sqlText = command.CommandText;
#endif

                try
                {

                    i = command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                     FileLog.Error(e.Message + " Text SQL:" + command.CommandText);
                    throw new Exception("$Error_Command_Execute", e);
                }
                finally
                {
                    if (this.Transaction == null)
                    {
                        CloseConnection();
                    }
                }

                return i;
            }
        }
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="commandText">SQL语句</param>
        public void Execute(string commandText)
        {
            OpenConnection();
            using (IDbCommand command = this.Connection.CreateCommand())
            {
                command.CommandText = commandText;
                //if (!(command is Oracle.DataAccess.Client.OracleCommand))
                    command.Transaction = this.Transaction;
                try
                {

                    command.ExecuteNonQuery();
                }
                catch (System.Data.OleDb.OleDbException e)
                {
                    FileLog.Error(e.Message + " Text SQL:" + command.CommandText);
                    throw new Exception("$Error_Command_Execute", e);
                }
                catch (Exception e)
                {
                    throw new Exception("$Error_Command_Execute", e);
                }
                finally
                {
                    if (this.Transaction == null)
                    {
                        CloseConnection();
                    }
                }
            }
        }

        public abstract IDbDataAdapter GetDbDataAdapter();
        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public void OpenConnection()
        {
            if (this.Connection != null)
            {
                if (this.Connection.State != ConnectionState.Open)
                {
                    try
                    {
                        this.Connection.Open();

                    }
                    catch (Exception ex)
                    {
                        FileLog.Info(ex.Message);
                        throw ex;
                    }
                }
            }
        }
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void CloseConnection()
        {
            if (this.Connection != null)
            {
                if (this.Connection.State != ConnectionState.Closed)
                {
                    try
                    {
                        this.Connection.Close();

                    }
                    catch (Exception ex)
                    {
                        FileLog.Info("Close Connection Failure\t" + ex.Message + "\t" + ex.Source + "\t" + ex.StackTrace + "\t" + ex.TargetSite);
                        throw ex;
                    }

                }
            }
        }

        #region ILanguage 成员

        public System.Globalization.CultureInfo CultureInfo
        {
            get
            {
                // TODO:  添加 SQLPersistBroker.CultureInfo getter 实现
                return _cultureInfo;
            }
        }

        #endregion

        #region IPersistBrokerTransaction 成员

        /// <summary>
        /// 开始事务
        /// </summary>
        public void BeginTransaction()
        {
            lock (_lock)
            {
                if (this._transaction != null)
                {
                    throw new Exception("$error_transaction");
                }
                OpenConnection();

                this._transaction = this.Connection.BeginTransaction();
            }
        }

        /// <summary>
        /// 回滚事务
        /// </summary>
        public void RollbackTransaction()
        {
            lock (_lock)
            {
                if (this._transaction == null)
                {
                    return;
                }

                try
                {

                    this._transaction.Rollback();

                }
                finally
                {
                    this._transaction = null;
                }
            }
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        public void CommitTransaction()
        {
            lock (_lock)
            {
                if (this._transaction == null)
                {
                    return;
                }

                try
                {

                    this._transaction.Commit();
                }
                finally
                {
                    this._transaction = null;
                }
            }
        }

        #endregion

        #region IPersistBroker Members


        public abstract void ExecuteProcedure(string commandText, ref ArrayList parameters);
        public virtual void Execute(string commandText, string[] parameters, Type[] parameterTypes, object[] parameterValues)
        {
            return;
        }
        public virtual int Execute(string commandText, string[] parameters, Type[] parameterTypes, object[] parameterValues, bool retID)
        {
            return 0;
        }
        public virtual int ExecuteWithReturn(string commandText, string[] parameters, Type[] parameterTypes, object[] parameterValues)
        {
            return 0;
        }
        public virtual DataSet Query(string commandText, string[] parameters, Type[] parameterTypes, object[] parameterValues)
        {
            return null;
        }
        public virtual DataSet Query(string commandText)
        {
            return null;
        }
        public abstract DataSet GetDataSetByProc(string commandText, ref ArrayList parameters, string strSql);

        #endregion

        public DataSet GetDataSetByProc(string procName, OleDbParameter[] param)
        {
            OpenConnection();
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter();
            OleDbCommand cmd = new OleDbCommand();
            try
            {
                using (IDbCommand command = this.Connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure; //创建存储过程
                    command.CommandText = procName; //调用存储过程名称
                    if (param != null)
                    {
                        foreach (OleDbParameter sp in param)//添加存储过程参数
                        {
                            cmd.Parameters.Add(sp);
                        }
                    }
                    da.SelectCommand = (OleDbCommand)command;
                    da.Fill(ds);
                    command.Parameters.Clear();
                }
            }
            catch (OleDbException ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetDataSetByProc(string procName)
        {
            OpenConnection();
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter();
            OleDbCommand cmd = new OleDbCommand();
            using (IDbCommand command = this.Connection.CreateCommand())
            {
                try
                {
                    command.CommandType = CommandType.StoredProcedure; //创建存储过程
                    command.CommandText = procName; //调用存储过程名称
                    da.SelectCommand = (OleDbCommand)command;
                    da.Fill(ds);
                }
                catch (OleDbException ex)
                {
                    throw ex;
                }
            }
            return ds;
        }

        /// <summary>
        /// 执行SQL 语句查询并返回object类型值
        /// </summary>
        /// <param name="commandText">SQL语句</param>
        /// <returns>查询结果（object）</returns>
        public object QuerySingle(string commandText)
        {
            OpenConnection();
            using (IDbCommand command = this.Connection.CreateCommand())
            {
                command.CommandText = commandText;
                //command.CommandTimeout = Enviroment.CommandTimeout; //获取环境配置文件中的过期时间

                if (this.Transaction != null)
                {
                    //if (!(command is Oracle.DataAccess.Client.OracleCommand))
                        command.Transaction = this.Transaction;
                }

#if DEBUG
                DateTime dtStart = DateTime.Now;
                string sqlText = command.CommandText;
#endif
                object rtnValue = null;
                try
                {
                    rtnValue = command.ExecuteScalar();
                }
                catch (Exception e)
                {
                    FileLog.Info(e.Message + " Text SQL:" + command.CommandText);
                    throw e;

                }
                finally
                {
                    //如果自动关闭为True并且不在Transaction中时才会自动关闭Connection
                    if (this.Transaction == null && AutoCloseConnection == true)
                    {
                        CloseConnection();
                    }
                }

                return rtnValue;
            }
        }
    }
}