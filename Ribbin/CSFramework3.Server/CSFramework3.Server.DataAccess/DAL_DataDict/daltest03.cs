using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LZHBaseFrame.Models;
using LZHBaseFrame.Common;
using LZHBaseFrame.ORM;
using LZHBaseFrame.Server.DataAccess.DAL_Base;


using LZHBaseFrame.Server.DataAccess.DAL_System;

using LZHBaseFrame.Interfaces;


/*==========================================
 *   程序说明: test03的数据访问层
 *   作者姓名: C/S框架网 www.LZHBaseFrame.com
 *   创建日期: 2014/04/24 11:02:29
 *   最后修改: 2014/04/24 11:02:29
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   版权所有 C/S框架网 www.LZHBaseFrame.com
 *==========================================*/

namespace LZHBaseFrame.Server.DataAccess
{
    /// <summary>
    /// daltest03
    /// </summary>
    public class daltest03 : dalBaseDataDict
    {
         /// <summary>
         /// 构造器
         /// </summary>
         /// <param name="loginer">当前登录用户</param>
        [DefaultORM_UpdateMode(typeof(tb_test01), true)]
         public daltest03(Loginer loginer): base(loginer)
         {
             _KeyName = tb_test01.__KeyName; //主键字段
             _TableName = tb_test01.__TableName;//表名
             _ModelType = typeof(tb_test01);
         }

         /// <summary>
         /// 根据表名获取该表的SQL命令生成器
         /// </summary>
         /// <param name="tableName">表名</param>
         /// <returns></returns>
         protected override IGenerateSqlCommand CreateSqlGenerator(string tableName)
         {
           Type ORM = null;
           if (tableName == tb_test01.__TableName) ORM = typeof(tb_test01);
           if (ORM == null) throw new Exception(tableName + "表没有ORM模型！");
           return new GenerateSqlCmdByTableFields(ORM);
         }

     }
}
