///*************************************************************************/
///*
///* 文件名    ：Msg.cs                                      
///* 程序说明  : 消息提示类
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.LZHBaseFrame.com
///**************************************************************************/

using System.Reflection;

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Repository.Hierarchy;

[assembly: log4net.Config.DOMConfigurator(ConfigFile = "log4net.dll.log4net", Watch = true)]
namespace LZHBaseFrame.Common
{
    /// <summary>
    /// 系统消息提示窗体
    /// </summary>
    public class Msg
    {

        /// <summary>
        /// 打开对话框
        /// </summary>
        /// <param name="msg">本次对话内容</param>
        /// <returns></returns>
        public static bool AskQuestion(string msg)
        {
            DialogResult r;
            //r = MessageBox.Show(msg, "确认",
            //    MessageBoxButtons.YesNo,
            //    MessageBoxIcon.Question,
            //    MessageBoxDefaultButton.Button2);
            
            r = DevExpress.XtraEditors.XtraMessageBox.Show(msg, "确认信息！",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            return (r == DialogResult.Yes);
        }

        /// <summary>
        /// 显示系统异常
        /// </summary>
        /// <param name="e">系统异常</param>
        public static void ShowException(Exception e)
        {
            string s = e.Message;
            string innerMsg = string.Empty;

            if (e.InnerException != null)
            {
                innerMsg = e.InnerException.Message;
                s += "\n" + innerMsg;
            }

            Warning(s);
        }

        public static void ShowException(Exception ex, string customMessage)
        {
            if (ex is CustomException)
                ShowException(ex);
            else if (customMessage != "")
                Warning(customMessage);
            else
                Warning(ex.Message);
        }

        /// <summary>
        /// 警告提示框
        /// </summary>
        /// <param name="msg">警告内容</param>
        public static void Warning(string msg)
        {
            DevExpress.XtraEditors.XtraMessageBox.Show(msg, "警告",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// 错误消息提示框
        /// </summary>
        /// <param name="msg">错误消息内容</param>
        public static void ShowError(string msg)
        {
            DevExpress.XtraEditors.XtraMessageBox.Show(msg, "警告",
                MessageBoxButtons.OK,
                MessageBoxIcon.Hand,
                MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// 信息提示框
        /// </summary>
        /// <param name="msg">本次显示的消息</param>
        public static void ShowInformation(string msg)
        {
            DevExpress.XtraEditors.XtraMessageBox.Show(msg, "信息",
                MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk,
                MessageBoxDefaultButton.Button1);
        }




    }

    public class FileLog
    {
        private static ILog Logger;
        private static string configFile = "log4net.dll.log4net";

        static FileLog()
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
            Logger = GetLogger(typeof(FileLog));
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


}
