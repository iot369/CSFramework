using System;
using System.Collections.Generic;

using System;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting;

using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Repository.Hierarchy;

using Service.Common.Domain;

[assembly: log4net.Config.DOMConfigurator(ConfigFile = "log4net.dll.log4net", Watch = true)]
namespace Service.Common
{
    public class Log
    {
        private static ILog Logger;
        private static string configFile = "log4net.dll.log4net";

        static Log()
        {
            if (File.Exists(Log4NetConfigFile))
            {
                if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                {
                    DOMConfigurator.ConfigureAndWatch(new FileInfo(Log4NetConfigFile));
                }
                else
                {
                    DOMConfigurator.Configure(new FileInfo(Log4NetConfigFile));
                }
            }
            else
            {
                BasicConfigurator.Configure();
            }
            Logger = GetLogger(typeof(Log));
        }

        #region Abbributes
        public static string Log4NetConfigFile
        {
            get
            {
                return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), configFile);
            }
        }

        public static ILog GetLogger(System.Type type)
        {
            return LogManager.GetLogger(type);
        }
        #endregion

        #region wrapper log type
        public static void Error(string message)
        {
            try
            {
                Logger.Error(message);
            }
            catch (Exception e)
            {
                ExceptionManager.Raise(typeof(Log), "$Error_Log_Fail", string.Format("Logger.Error() failed on logging '{0}'.", message), e);
            }
        }

        public static void Warning(string message, Exception exception)
        {
            try
            {
                Logger.Warn(message, exception);
            }
            catch (Exception e)
            {
                ExceptionManager.Raise(typeof(Log), "$Error_Log_Warn", String.Format("Logger.Warn() failed on logging '{0}'.", message + "::" + exception.Message), e);
            }
        }

        public static void Warning(string message)
        {
            try
            {
                Logger.Warn(message);
            }
            catch (Exception e)
            {
                ExceptionManager.Raise(typeof(Log), "$Error_Log_Warn", String.Format("Logger.Warn() failed on logging '{0}'.", message), e);
            }
        }

        public static void Fatal(string message, Exception exception)
        {
            try
            {
                Logger.Fatal(message, exception);
            }
            catch (Exception e)
            {
                ExceptionManager.Raise(typeof(Log), "$Error_Log_Fatal", String.Format("Logger.Fatal() failed on logging '{0}'.", message + "::" + exception.Message), e);
            }
        }

        public static void Fatal(string message)
        {
            try
            {
                Logger.Fatal(message);
            }
            catch (Exception e)
            {
                ExceptionManager.Raise(typeof(Log), "$Error_Log_Fatal", String.Format("Logger.Fatal() failed on logging '{0}'.", message), e);
            }
        }

        public static void Info(string message, Exception exception)
        {
            try
            {
                Logger.Info(message, exception);
            }
            catch (Exception e)
            {
                ExceptionManager.Raise(typeof(Log), "$Error_Log_Info", String.Format("Logger.Info() failed on logging '{0}'.", message + "::" + exception.Message), e);
            }
        }

        public static void Info(string message)
        {
            try
            {
                Logger.Info(message);
            }
            catch (Exception e)
            {
                ExceptionManager.Raise(typeof(Log), "$Error_Log_Info", String.Format("Logger.Info() failed on logging '{0}'.", message), e);
            }
        }


        #endregion

        public static void ClearOldLogFiles(string keepDays)
        {
            int days = 0;
            int.TryParse(keepDays, out days);
            if (days <= 0)
            {
                return;
            }

            try
            {
                DateTime now = DateTime.Now;

                Hierarchy hierarchy = (Hierarchy)LogManager.GetLoggerRepository();
                foreach (IAppender appender in hierarchy.Root.Appenders)
                {
                    if (appender is RollingFileAppender)
                    {
                        string logPath = ((RollingFileAppender)appender).File;
                        DirectoryInfo dir = new DirectoryInfo(logPath.Substring(0, logPath.LastIndexOf("\\")));

                        foreach (FileInfo file in dir.GetFiles())
                        {
                            if (file.LastWriteTime < now.AddDays(-days))
                            {
                                file.Delete();
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }

    /// <summary>
    /// 抛出异常，统一记录
    /// </summary>
    public class ExceptionManager
    {
        //		private static ExceptionManager s_exMgr = null;
        //		public static ExceptionManager Instance()
        //		{
        //			if( ExceptionManager.s_exMgr == null )
        //			{
        //				ExceptionManager.s_exMgr = new ExceptionManager();
        //			}
        //			return ExceptionManager.s_exMgr;
        //		}

        public static void Raise(Type type, string errorCode)
        {
            ExceptionManager.Raise(type, errorCode, "", null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="errorCode"></param>
        /// <param name="innerException"></param>
        public static void Raise(Type type, string errorCode, string message)
        {
            ExceptionManager.Raise(type, errorCode, message, null);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="errorCode"></param>
        /// <param name="innerException"></param>
        public static void Raise(Type type, string errorCode, Exception innerException)
        {
            ExceptionManager.Raise(type, errorCode, "", innerException);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message">rd自己定义的一些信息</param>
        /// <param name="innerException"></param>
        public static void Raise(Type type, string errorCode, string message, Exception innerException)
        {
            if (message == null)
            {
                message = string.Empty;
            }

            Log.Error(string.Format("{0}--{1}",type.FullName.ToString(), message) );
        }

    }
}
