using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LZHBaseFrame.ORM;


/*==========================================
 *   程序说明: tb_test01的ORM模型
 *   作者姓名: C/S框架网 www.LZHBaseFrame.com
 *   创建日期: 2014/04/22 03:48:34
 *   最后修改: 2014/04/22 03:48:34
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   版权所有 C/S框架网 www.LZHBaseFrame.com
 *==========================================*/

namespace LZHBaseFrame.Models
{
    ///<summary>
    /// ORM模型, 数据表:test01,由ClassGenerator自动生成
    /// </summary>
    [ORM_ObjectClassAttribute("test01", "testcode", true)]
    public sealed class tb_test01
    {
        #region 所有字段的局部变量定义
        private int F_testcode;
        private string F_testname;
        #endregion

        public static string __TableName = "test01";

        public static string __KeyName = "testcode";

        #region 所有字段名常量
        public const string _testcode = "testcode";
        public const string _testname = "testname";
        #endregion

        #region 所有字段属性
        [ORM_FieldAttribute(SqlDbType.Int, 4, true, true, true, false, false)]
        public int testcode { get { return F_testcode; } set { F_testcode = value; } }

        [ORM_FieldAttribute(SqlDbType.VarChar, 50, true, true, false, false, false)]
        public string testname { get { return F_testname; } set { F_testname = value; } }

        #endregion
    }
}