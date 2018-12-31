

using System;
using System.IO;
using Microsoft.Win32;
using System.Reflection;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Data;
using DevExpress.XtraTab;
using DevExpress.XtraBars;
using DevExpress.XtraNavBar;
using LZHBaseFrame.Common;
using LZHBaseFrame.Library;
using LZHBaseFrame.Interfaces;
using LZHBaseFrame.Core;

namespace LZHBaseFrame.Library
{
    public interface IModuleManager
    {
        //XtraTabControl _tabControlModules;
        //XtraTabControl TabControlModules;
        //Form _MDIMainForm;
        //IList<IModuleBase> _ModulesLoadSucceed = new List<IModuleBase>();
        //IList<IModuleBase> ModulesLoadSucceed;
        //static IList<ModuleInfo> _Modules;
        //static IList<ModuleInfo> GetAvailableModules();
        void LoadModules(IMsg msg, MenuStrip moduleMenus);
        void CreateToolButtons(Bar menuBar, ToolStrip moduleMainMenu);
        void menuOwner_ItemClick(object sender, ItemClickEventArgs e);
        void LoadBarButtonItem(BarSubItem owner, ToolStripItem item);
        void OnBarButtonItemClick(object sender, ItemClickEventArgs e);
        void LoadBarSubItems(BarSubItem itemOwner, ToolStripMenuItem menuItem);
        void CreateNavBarButtons(NavBarControl navBarControl, MenuStrip mainMenu, NavigatorStyle style);
        void ActiveModule(string moduleDisplayName);
        void SetModuleSecurity(MenuStrip menuStrip);
    }
}
