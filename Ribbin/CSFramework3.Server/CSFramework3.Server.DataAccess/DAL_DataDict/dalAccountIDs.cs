using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LZHBaseFrame.Models;
using LZHBaseFrame.Common;
using LZHBaseFrame.Server.DataAccess.DAL_System;
using LZHBaseFrame.ORM;
using LZHBaseFrame.Interfaces;
using LZHBaseFrame.Server.DataAccess.DAL_Base;

namespace LZHBaseFrame.Server.DataAccess.DAL_DataDict
{
    [DefaultORM_UpdateMode(typeof(tb_AccountIDs), true)]
    public class dalAccountIDs : dalBaseDataDict
    {
        public dalAccountIDs(Loginer loginer)
            : base(loginer)
        {
            _KeyName = tb_AccountIDs.__KeyName; //主键字段
            _TableName = tb_AccountIDs.__TableName;//表名
            _ModelType = typeof(tb_AccountIDs);
        }
    }
}
