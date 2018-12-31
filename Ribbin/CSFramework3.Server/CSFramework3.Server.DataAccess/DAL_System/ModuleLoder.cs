using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LZHBaseFrame.Models;
using LZHBaseFrame.Common;
using LZHBaseFrame.ORM;
using LZHBaseFrame.Interfaces;
using LZHBaseFrame.Server.DataAccess.DAL_Base;

namespace LZHBaseFrame.Server.DataAccess.DAL_System
{
    public class ModuleLoder
    {
        ModuleLoder()
        { 
        
        }
        /// <summary>        
        /// 获取模块列表，转换为ModuleInfo集合.
        /// </summary>        
        public virtual IList<ModuleInfo> GetModuleList()
        {
            try
            {

                string[] files = null; //模块文件(*.dll)
                IList<ModuleInfo> list = new List<ModuleInfo>();

                if (Directory.Exists(MODULE_PATH))
                    files = Directory.GetFiles(MODULE_PATH, "*.dll");

                foreach (string mod in files)
                {
                    Assembly asm = null;
                    try
                    {
                        //.net framework dll
                        asm = Assembly.LoadFile(mod);
                    }
                    catch { continue; }

                    ModuleID id = GetModuleID(asm);
                    string name = GetCurrentModuleName();
                    if (id != ModuleID.None)
                    {
                        ModuleInfo m = new ModuleInfo(asm, id, name, mod);
                        list.Add(m);
                    }
                }

                SortModule(list); //模块排序.

                return list;
            }
            catch (Exception ex)
            {
                Msg.ShowException(ex);
                return null;
            }
        }
    }
}
