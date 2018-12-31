using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LZHBaseFrame.Models;
using LZHBaseFrame.Common;
using LZHBaseFrame.Interfaces;
using LZHBaseFrame.Core.Log;
using LZHBaseFrame.Core;

using LZHBaseFrame.Bridge;
using LZHBaseFrame.Business.BLL_Base;

/*==========================================
 *   程序说明: Person的业务逻辑层
 *   作者姓名: C/S框架网 www.LZHBaseFrame.com
 *   创建日期: 2011-04-05 01:18:30
 *   最后修改: 2011-04-05 01:18:30
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   版权所有 C/S框架网 www.LZHBaseFrame.com
 *==========================================*/

namespace LZHBaseFrame.Business
{
    public class bllPerson : bllBaseDataDict
    {
        public bllPerson()
        {
            _KeyFieldName = tb_Person.__KeyName; //主键字段
            _SummaryTableName = tb_Person.__TableName;//表名
            _WriteDataLog = true;//是否保存日志

            //方式一：由ORM自动查询DAL类
            _DataDictBridge = BridgeFactory.CreateDataDictBridge(typeof(tb_Person));
        }
    }
}
