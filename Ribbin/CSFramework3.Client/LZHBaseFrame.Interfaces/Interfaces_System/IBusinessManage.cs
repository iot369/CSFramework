///*************************************************************************/
///*
///* 文件名    ：IBusinessManage.cs                                
///* 程序说明  : 业务单据的业务逻辑层接口
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using CSFramework.Common;
using System.Data;

namespace CSFramework3.Interfaces
{
    /// <summary>
    /// 业务单据的业务逻辑层接口
    /// </summary>
    public interface IBusinessManage
    {
        /// <summary>
        /// 业务单据的资料表，.Tables[0]为主表,Tables[1..n]为第1..n个明细表
        /// </summary>
        DataTableCollection BusinessTables { get; }

        /// <summary>
        /// 业务单据主表
        /// </summary>
        DataTable SummaryTable { get; }

        /// <summary>
        /// 主表主键字段名
        /// </summary>
        string KeyFieldName { get; }

        /// <summary>
        /// 跟据单据号码获取整张业务单据所有数据表(主表及明细表)
        /// </summary>        
        void GetBusinessByKey(string key);

        /// <summary>
        /// 创建业务数据(新增单据)
        /// </summary>
        void CreateNew();

        /// <summary>
        /// 删除记录
        /// </summary>        
        bool Delete(string key);

        /// <summary>
        /// 储存资料
        /// </summary>        
        SaveResult Update(UpdateType updateType);

        /// <summary>
        /// 检查单号是否存在
        /// </summary>
        /// <param name="key">单据号码</param>
        /// <returns></returns>
        bool CheckNoExists(string key);

        /// <summary>
        /// 搜索功能
        /// </summary>
        /// <param name="paramList">查询条件</param>
        void GetSummaryByParam(object[] paramList);

        /// <summary>
        /// 获取预设业务数据，如获取当前月份的业务数据
        /// </summary>
        void GetSummaryDefault();

        /// <summary>
        /// 锁定/解锁单据
        /// </summary>
        /// <param name="DocNo">单号</param>
        /// <param name="isLock">锁定/解锁</param>
        /// <returns></returns>
        bool Lock(string DocNo, bool isLock);

        /// <summary>
        /// 单据作废/取消作废
        /// </summary>
        /// <param name="DocNo">单号</param>
        /// <param name="isVoid">作废/取消作废</param>
        /// <returns></returns>
        bool Void(string DocNo, bool isVoid);

        /// <summary>
        /// 审核/批准功能(取消审核/取消批准功能)
        /// </summary>
        /// <param name="DocNo">单号</param>
        /// <param name="isApproval">审核人/批准人(取消审核人/取消批准人)</param>
        /// <param name="approvalUser"></param>
        /// <returns></returns>
        bool Approval(string DocNo, bool isApproval, string approvalUser);

        /// <summary>
        /// 批量锁定单据
        /// </summary>
        /// <param name="keys">单号列表，多个单号以","分开</param>
        /// <returns></returns>
        bool Lock(string keys);

        /// <summary>
        /// 批量作废单据
        /// </summary>
        /// <param name="keys">单号列表，多个单号以","分开</param>
        /// <param name="applyCount">受影响的记录数</param>
        /// <returns></returns>
        bool Void(string keys, out int applyCount);

        /// <summary>
        /// 批量审核/批准单据
        /// </summary>
        /// <param name="keys">单号列表，多个单号以","分开</param>
        /// <returns></returns>
        bool Approval(string keys);
        
        /// <summary>
        /// 批量删除单据
        /// </summary>
        /// <param name="keys">单号列表，多个单号以","分开</param>
        /// <returns></returns>
        bool DeleteByKeys(string keys);
    }
}
