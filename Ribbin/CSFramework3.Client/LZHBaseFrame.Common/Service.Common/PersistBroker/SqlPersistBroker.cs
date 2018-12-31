using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Text;
using System.Xml;
using Service.Common.Domain;
using System.Collections;

namespace Service.Common.PersistBroker
{
    /// <summary>
    /// OraPersistBroker 的摘要说明。
    /// </summary>
    public class SqlPersistBroker : AbstractSQLPersistBroker, IPersistBroker
    {
        public SqlPersistBroker(string connectionString)
            : base(new SqlConnection(connectionString))
        {

        }

        public SqlPersistBroker(string connectionString, System.Globalization.CultureInfo cultureInfo)
            : base(new SqlConnection(connectionString), cultureInfo)
        {
        }

        //		~SqlPersistBroker()
        //		{
        //			this.CloseConnection(); 
        //		}

        public override IDbDataAdapter GetDbDataAdapter()
        {
            return new SqlDataAdapter();
        }
        /// <summary>
        /// Laws Lu,2006/12/20 修改,支持手动关闭连接
        /// 是否 自动关闭连接
        /// </summary>
        public override bool AutoCloseConnection
        {
            get
            {
                return base.AutoCloseConnection;
            }
            set
            {
                base.AutoCloseConnection = value;
            }
        }

        public override void Execute(string commandText, string[] parameters, Type[] parameterTypes, object[] parameterValues)
        {
            OpenConnection();
            using (SqlCommand command = (SqlCommand)this.Connection.CreateCommand())
            {
                command.CommandText = this.changeParameterPerfix(commandText);

                for (int i = 0; i < parameters.Length; i++)
                {
                    command.Parameters.Add(parameters[i], CSharpType2SqlType(parameterTypes[i])).Value = parameterValues[i];
                    //					command.CommandText = 	ChangeParameterPerfix(command.CommandText, parameters[i]);
                }
                if (this.Transaction != null)
                {
                    command.Transaction = (SqlTransaction)this.Transaction;
                }
                try
                {
                    //在Debug状态下不允许Log日志
#if DEBUG
                    Log.Info(" Parameter SQL:" + this.spellCommandText(command.CommandText, parameterValues));
#endif


                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Log.Error(e.Message + " Parameter SQL:" + this.spellCommandText(command.CommandText, parameterValues));
                    ExceptionManager.Raise(this.GetType(), "$Error_Command_Execute", e);
                }
                finally
                {
                    //Laws Lu,2006/12/20 修改如果自动关闭为True并且不在Transaction中时才会自动关闭Connection
                    if (this.Transaction == null && AutoCloseConnection == true)
                    {
                        //CloseConnection();
                    }
                }
            }
        }
        /// <summary>
        /// 执行语句并返回生成的自增ID
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <param name="parameterTypes"></param>
        /// <param name="parameterValues"></param>
        public override int Execute(string commandText, string[] parameters, Type[] parameterTypes, object[] parameterValues, bool retID)
        {
            int returnID = 0;

            OpenConnection();
            using (SqlCommand command = (SqlCommand)this.Connection.CreateCommand())
            {
                command.CommandText = this.changeParameterPerfix(commandText);

                for (int i = 0; i < parameters.Length; i++)
                {
                    command.Parameters.Add(parameters[i], CSharpType2SqlType(parameterTypes[i])).Value = parameterValues[i];
                    //					command.CommandText = 	ChangeParameterPerfix(command.CommandText, parameters[i]);
                }
                if (this.Transaction != null)
                {
                    command.Transaction = (SqlTransaction)this.Transaction;
                }
                try
                {
                    //在Debug状态下不允许Log日志
#if DEBUG
                    Log.Info(" Parameter SQL:" + this.spellCommandText(command.CommandText, parameterValues));
#endif


                    returnID = int.Parse(command.ExecuteScalar().ToString());
                }
                catch (Exception e)
                {
                    Log.Error(e.Message + " Parameter SQL:" + this.spellCommandText(command.CommandText, parameterValues));
                    ExceptionManager.Raise(this.GetType(), "$Error_Command_Execute", e);
                }
                finally
                {
                    //Laws Lu,2006/12/20 修改如果自动关闭为True并且不在Transaction中时才会自动关闭Connection
                    if (this.Transaction == null && AutoCloseConnection == true)
                    {
                        //CloseConnection();
                    }
                }
                return returnID;
            }
        }
        public override int ExecuteWithReturn(string commandText, string[] parameters, Type[] parameterTypes, object[] parameterValues)
        {
            int iReturn = 0;
            OpenConnection();
            using (SqlCommand command = (SqlCommand)this.Connection.CreateCommand())
            {
                command.CommandText = this.changeParameterPerfix(commandText);

                for (int i = 0; i < parameters.Length; i++)
                {
                    command.Parameters.Add(parameters[i], CSharpType2SqlType(parameterTypes[i])).Value = parameterValues[i];
                    //					command.CommandText = 	ChangeParameterPerfix(command.CommandText, parameters[i]);
                }
                if (this.Transaction != null)
                {
                    command.Transaction = (SqlTransaction)this.Transaction;
                }
                try
                {
                    //Laws Lu,在Debug状态下不允许Log日志
#if Debug
					Log.Info(" Parameter SQL:" + this.spellCommandText(command.CommandText, parameterValues) );
#endif

                    iReturn = command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Log.Error(e.Message + " Parameter SQL:" + this.spellCommandText(command.CommandText, parameterValues));
                    ExceptionManager.Raise(this.GetType(), "$Error_Command_Execute", e);
                }
                finally
                {
                    //Laws Lu,2006/12/20 修改如果自动关闭为True并且不在Transaction中时才会自动关闭Connection
                    if (this.Transaction == null && AutoCloseConnection == true)
                    {
                        //CloseConnection();
                    }
                }
                return iReturn;
            }
        }

        public DataSet GetDataSetByProc(string procName, SqlParameter[] param)
        {
            OpenConnection();
            SqlDataAdapter da = (SqlDataAdapter)this.GetDbDataAdapter();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {
                using (da.SelectCommand = (SqlCommand)this.Connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure; //创建存储过程
                    cmd.CommandText = procName; //调用存储过程名称
                }
                if (param != null)
                {
                    foreach (SqlParameter sp in param)//添加存储过程参数
                    {
                        cmd.Parameters.Add(sp);
                    }
                }
                da.SelectCommand = cmd;
                da.Fill(ds);
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return ds;
        }

        //重载
        public DataSet GetDataSetByProc(string procName)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandType = CommandType.StoredProcedure; //创建存储过程
                cmd.CommandText = procName; //调用存储过程名称
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return ds;
        }

        public override DataSet Query(string commandText, string[] parameters, Type[] parameterTypes, object[] parameterValues)
        {
            OpenConnection();
            SqlDataAdapter dataAdapter = (SqlDataAdapter)this.GetDbDataAdapter();
            using (dataAdapter.SelectCommand = (SqlCommand)this.Connection.CreateCommand())
            {
                //edit by luozh 
                dataAdapter.SelectCommand.CommandText = commandText.Replace("$", "@");//this.changeParameterPerfix(commandText);
                //end edit
                for (int i = 0; i < parameters.Length; i++)
                {
                    dataAdapter.SelectCommand.Parameters.Add(parameters[i], CSharpType2SqlType(parameterTypes[i])).Value = parameterValues[i];
                    //					dataAdapter.SelectCommand.CommandText = ChangeParameterPerfix(dataAdapter.SelectCommand.CommandText, parameters[i]);
                }
                if (this.Transaction != null)
                {
                    dataAdapter.SelectCommand.Transaction = (SqlTransaction)this.Transaction;
                }

                DataSet dataSet = new DataSet();

                try
                {
                    //Laws Lu,在Debug状态下不允许Log日志
#if Debug
					Log.Info(" Parameter SQL:" + this.spellCommandText(dataAdapter.SelectCommand.CommandText, parameterValues) );
#endif

                    dataAdapter.Fill(dataSet);
                }
                catch (Exception e)
                {
                    Log.Error(e.Message + " Parameter SQL:" + this.spellCommandText(dataAdapter.SelectCommand.CommandText, parameterValues));
                    ExceptionManager.Raise(this.GetType(), "$Error_Command_Execute", e);
                }
                finally
                {
                    //Laws Lu,2006/12/20 修改如果自动关闭为True并且不在Transaction中时才会自动关闭Connection
                    if (this.Transaction == null && AutoCloseConnection == true)
                    {
                        //CloseConnection();
                    }
                }

                return dataSet;
            }
        }

        private string changeParameterPerfix(string commandText)
        {
            return commandText.Replace("$", "@");//new Regex(@"\$([0-9A-Za-z_]+)").Replace(commandText, "?");
        }

        private string spellCommandText(string commandText, object[] parameterValues)
        {
            StringBuilder builder = new StringBuilder();
            string[] texts = commandText.Split('?');

            for (int i = 0; i < texts.Length; i++)
            {
                if (i < parameterValues.Length)
                {
                    builder.Append(string.Format("{0}'{1}'", texts[i], parameterValues[i]));
                }
                else
                {
                    builder.Append(texts[i]);
                }
            }

            return builder.ToString();
        }

        private System.Data.SqlDbType CSharpType2SqlType(Type cSharpType)
        {
            if (cSharpType == typeof(string))
            {
                return SqlDbType.VarChar;
            }

            if (cSharpType == typeof(int))
            {
                return SqlDbType.Int;
            }

            if (cSharpType == typeof(long))
            {
                return SqlDbType.BigInt;
            }

            if (cSharpType == typeof(double))
            {
                return SqlDbType.Float;
            }

            if (cSharpType == typeof(float))
            {
                return SqlDbType.Float;
            }

            if (cSharpType == typeof(decimal))
            {
                return SqlDbType.Decimal;
            }

            if (cSharpType == typeof(bool))
            {
                return SqlDbType.VarChar;
            }

            if (cSharpType == typeof(DateTime))
            {
                return SqlDbType.VarChar;
            }

            if (cSharpType == typeof(byte[]))
            {
                return SqlDbType.Binary;
            }

            return SqlDbType.Variant;
        }

        public IDataReader QueryDataReader(string commandText)
        {
            OpenConnection();

            using (IDbCommand command = (IDbCommand)this.Connection.CreateCommand())
            {
                command.CommandText = commandText;

                if (this.Transaction != null)
                {
                    command.Transaction = this.Transaction;
                }

                DateTime dtStart = new DateTime();
                IDataReader reader = null;
                try
                {
                    //修改	在Debug模式下不允许Log日志文件
#if DEBUG
                    dtStart = DateTime.Now;
                    Log.Info("************StartDateTime:" + dtStart.ToString() + "," + dtStart.Millisecond);
                    Log.Info(" Text SQL:" + command.CommandText);
#endif

                    reader = command.ExecuteReader();
                    //command.

#if DEBUG
                    DateTime dtEnd = DateTime.Now;
                    TimeSpan ts = dtEnd - dtStart;
                    Log.Info("************EndDateTime:" + dtEnd.ToString() + "," + dtEnd.Millisecond + "*********"
                        + "Cost: " + ts.Seconds + ":" + ts.Milliseconds);
#endif

                    return reader;
                }
                catch (Exception e)
                {
                    Log.Error(e.Message + " Text SQL:" + command.CommandText);
#if DEBUG
                    DateTime dtEnd = DateTime.Now;
                    TimeSpan ts = dtEnd - dtStart;
                    Log.Info("************EndDateTime:" + dtEnd.ToString() + "," + dtEnd.Millisecond + "*********"
                        + "Cost: " + ts.Seconds + ":" + ts.Milliseconds);
#endif

                    ExceptionManager.Raise(this.GetType(), "$Error_Command_Execute", e);
                }
                finally
                {
                    //Laws Lu,2006/12/20 修改如果自动关闭为True并且不在Transaction中时才会自动关闭Connection
                    if (this.Transaction == null && AutoCloseConnection == true)
                    {
                        //CloseConnection();
                    }
                }
            }

            return null;
        }

        public new DataSet Query(string commandText)
        {
            OpenConnection();
            IDbDataAdapter dataAdapter = this.GetDbDataAdapter();
            using (dataAdapter.SelectCommand = this.Connection.CreateCommand())
            {
                dataAdapter.SelectCommand.CommandText = commandText;
                //dataAdapter.SelectCommand.CommandTimeout = Enviroment.CommandTimeout;
                dataAdapter.SelectCommand.Transaction = this.Transaction;
                DataSet dataSet = new DataSet();
                DateTime dtStart = new DateTime();
                try
                {
#if DEBUG
                    dtStart = DateTime.Now;
                    Log.Info("************StartDateTime:" + dtStart.ToString() + "," + dtStart.Millisecond);
                    Log.Info(" Parameter SQL:" + commandText);
#endif

                    dataAdapter.Fill(dataSet);

#if DEBUG
                    DateTime dtEnd = DateTime.Now;
                    TimeSpan ts = dtEnd - dtStart;
                    Log.Info("************EndDateTime:" + dtEnd.ToString() + "," + dtEnd.Millisecond + "*********"
                        + "Cost: " + ts.Seconds + ":" + ts.Milliseconds);
#endif
                }
                catch (Exception e)
                {
                    Log.Error(e.Message + " " + commandText);

#if DEBUG
                    DateTime dtEnd = DateTime.Now;
                    TimeSpan ts = dtEnd - dtStart;
                    Log.Info("************EndDateTime:" + dtEnd.ToString() + "," + dtEnd.Millisecond + "*********"
                        + "Cost: " + ts.Seconds + ":" + ts.Milliseconds);
#endif
                    ExceptionManager.Raise(this.GetType(), "$Error_Command_Execute", e);
                }
                finally
                {
                    //Laws Lu,2006/12/20 修改如果自动关闭为True并且不在Transaction中时才会自动关闭Connection
                    if (this.Transaction == null && AutoCloseConnection == true)
                    {
                        //CloseConnection();
                    }
                }

                return dataSet;
            }
        }
        /// <summary>
        /// 执行Procedure
        /// </summary>
        /// <param name="commandText">Procedure名称</param>
        /// <param name="parameters">参数列表</param>
        public override void ExecuteProcedure(string commandText, ref ArrayList parameters)
        {
            OpenConnection();
            using (SqlCommand command = (SqlCommand)this.Connection.CreateCommand())
            {
                command.CommandText = commandText;
                command.CommandType = CommandType.StoredProcedure;

                object[] parameterValues = new object[parameters.Count];
                for (int i = 0; i < parameters.Count; i++)
                {
                    SqlParameter para = new SqlParameter();
                    para.ParameterName = ((ProcedureParameter)parameters[i]).Name;
                    para.SqlDbType = CSharpType2SqlType(((ProcedureParameter)parameters[i]).Type);
                    if (((ProcedureParameter)parameters[i]).Length != 0)
                    {
                        para.Size = ((ProcedureParameter)parameters[i]).Length;
                    }
                    else
                    {
                        para.Size = 100;
                    }
                    if (((ProcedureParameter)parameters[i]).Direction != DirectionType.Input)
                    {
                        para.Direction = (ParameterDirection)System.Enum.Parse(typeof(ParameterDirection), System.Enum.GetName(typeof(DirectionType), ((ProcedureParameter)parameters[i]).Direction));
                    }
                    else
                    {
                        para.Direction = ParameterDirection.Input;
                    }
                    para.Value = ((ProcedureParameter)parameters[i]).Value;
                    parameterValues[i] = para;
                    command.Parameters.Add(para);
                }
                if (this.Transaction != null)
                {
                    command.Transaction = (SqlTransaction)this.Transaction;
                }
#if DEBUG
                DateTime dtStart = DateTime.Now;
                string sqlText = this.spellCommandText(command.CommandText, parameterValues);
#endif
                try
                {
                    //2006/09/12 新增 读取配置文件Log日志文件
                    XmlDocument xmldoc = null;
                    XmlNodeReader xr = null;
                    try
                    {
                        string constr = "";
                        if (!this.AllowSQLLog && this.SQLLogConnectString == String.Empty)
                        {
                            xmldoc = new XmlDocument();

                            xmldoc.Load(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\dblog.xml");

                            xr = new XmlNodeReader(xmldoc);

                            while (xr.Read())
                            {
                                if (xr.GetAttribute("name") == "BS")
                                {
                                    this.AllowSQLLog = (xr.ReadString() == "false" ? false : true);
                                }
                                if (xr.GetAttribute("name") == "Constr")
                                {
                                    this.SQLLogConnectString = xr.ReadString();
                                }
                            }
                        }


                        if (this.AllowSQLLog && this.SQLLogConnectString != String.Empty)
                        {
                            //Laws Lu,2007/04/03 Log executing user                			
                            //db.dblog1(constr,this.spellCommandText(command.CommandText,parameterValues);
                            //db.dblog1(this.SQLLogConnectString, this.spellCommandText(command.CommandText, parameterValues), this.ExecuteUser);
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex.Message);
                    }
                    finally
                    {
                        if (xr != null)
                        {
                            xr.Close();
                        }
                        if (xmldoc != null)
                        {
                            xmldoc.Clone();
                        }
                    }

                    command.ExecuteNonQuery();
                    for (int i = 0; i < parameters.Count; i++)
                    {
                        if (((ProcedureParameter)parameters[i]).Direction != DirectionType.Input)
                        {
                            ((ProcedureParameter)parameters[i]).Value = ((SqlParameter)parameterValues[i]).Value;
                        }
                    }

#if DEBUG
                    DateTime dtEnd = DateTime.Now;
                    RecordLog("Execute SQL", sqlText, dtStart, dtEnd);
#endif
                }
                catch (System.Data.OleDb.OleDbException e)
                {
                    //Log.Error(e.Message + " Parameter SQL:" + this.spellCommandText(command.CommandText, parameterValues));
#if DEBUG
                    DateTime dtEnd = DateTime.Now;
                    RecordLog("Execute SQL", sqlText, dtStart, dtEnd);
#endif

                    if (e.ErrorCode == -2147217873)
                    {
                        //ExceptionManager.Raise(this.GetType(), "$ERROR_DATA_ALREADY_EXIST", e);
                        ExceptionManager.Raise(this.GetType(), "$Error_Command_Execute", e);
                    }
                    else
                    {
                        ExceptionManager.Raise(this.GetType(), "$Error_Command_Execute", e);
                    }
                }
                catch (Exception e)
                {
                    //Log.Error(e.Message + " Parameter SQL:" + this.spellCommandText(command.CommandText, parameterValues));
#if DEBUG
                    DateTime dtEnd = DateTime.Now;
                    RecordLog("Execute SQL", sqlText, dtStart, dtEnd);
#endif

                    ExceptionManager.Raise(this.GetType(), "$Error_Command_Execute", e);
                }
                finally
                {
                    //Laws Lu,2006/12/20 修改如果自动关闭为True并且不在Transaction中时才会自动关闭Connection
                    if (this.Transaction == null && AutoCloseConnection == true)
                    {
                        CloseConnection();
                    }
                }
            }
        }

        /// <summary>
        /// 执行Procedure
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override DataSet GetDataSetByProc(string commandText, ref ArrayList parameters, string strSql)
        {
            return null;
        }
    }
}
