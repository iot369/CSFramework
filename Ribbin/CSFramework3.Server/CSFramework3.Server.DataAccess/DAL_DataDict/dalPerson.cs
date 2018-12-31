using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LZHBaseFrame.Models;
using LZHBaseFrame.Common;
using LZHBaseFrame.Server.DataAccess.DAL_System;
using LZHBaseFrame.ORM;
using LZHBaseFrame.Server.DataAccess.DAL_Base;

/*==========================================
 *   程序说明: Person的数据访问层
 *   作者姓名: C/S框架网 www.LZHBaseFrame.com
 *   创建日期: 2011-04-05 01:18:57
 *   最后修改: 2011-04-05 01:18:57
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   版权所有 C/S框架网 www.LZHBaseFrame.com
 *==========================================*/

namespace LZHBaseFrame.Server.DataAccess.DAL_DataDict
{
    /// <summary>
    /// Person的数据访问层
    /// </summary>
    [DefaultORM_UpdateMode(typeof(tb_Person), true)]
    public class dalPerson : dalBaseDataDict
    {
        public dalPerson(Loginer loginer)
            : base(loginer)
        {
            _KeyName = tb_Person.__KeyName; //主键字段
            _TableName = tb_Person.__TableName;//表名
            _ModelType = typeof(tb_Person);
        }

        protected override IGenerateSqlCommand CreateSqlGenerator(string tableName)
        {
            Type ORM = null;
            if (tableName == tb_Person.__TableName) ORM = typeof(tb_Person);
            if (ORM == null) throw new Exception(tableName + "表没有ORM模型！");
            //return new GenerateSqlCmdByTableFields(ORM);
            return new GenerateSqlCmdByObjectClass(ORM);
        }

    }
}
