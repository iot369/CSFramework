using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LZHBaseFrame.Models;
using LZHBaseFrame.Common;
//using LZHBaseFrame.Core.Interfaces;
//using LZHBaseFrame.Core.Log;
using LZHBaseFrame.Server.DataAccess;
//using LZHBaseFrame.Core;
//using LZHBaseFrame.Core.BLL_Base;

using LZHBaseFrame.Bridge;
using LZHBaseFrame.Interfaces;
using LZHBaseFrame.Bridge.DataDictModule;
using LZHBaseFrame.Business.BLL_Base;

/*==========================================
 *   程序说明: test03的业务逻辑层
 *   作者姓名: C/S框架网 www.LZHBaseFrame.com
 *   创建日期: 2014/04/24 09:24:12
 *   最后修改: 2014/04/24 09:24:12
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   版权所有 C/S框架网 www.LZHBaseFrame.com
 *==========================================*/

namespace LZHBaseFrame.Business
{
    public class blltest03 : bllBaseDataDict
    {
        private IBridge_Customer _MyBridge; //桥接/策略接口
         public blltest03()
         {
             _KeyFieldName = tb_test01.__KeyName; //主键字段
             _SummaryTableName = tb_test01.__TableName;//表名
             _WriteDataLog = true;//是否保存日志
             //_DAL = new daltest03(Loginer.CurrentUser);//数据层的实例
             _DataDictBridge = BridgeFactory.CreateDataDictBridge(typeof(tb_test01));
             _MyBridge = this.CreateBridge();
         }

         /// <summary>
         /// 创建桥接通信通道
         /// </summary>
         /// <returns></returns>
         private IBridge_Customer CreateBridge()
         {
             if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                 return new ADODirect_Customer().GetInstance();

             if (BridgeFactory.BridgeType == BridgeType.WebService)
                 return new WebService_Customer();

             return null;
         }
     }
}
