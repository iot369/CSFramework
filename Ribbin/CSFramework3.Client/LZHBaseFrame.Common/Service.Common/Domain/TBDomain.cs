using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Common.Domain
{

    #region HOST
    /// <summary> 
    /// HOST 
    /// </summary> 
    [Serializable, TableMap("tb_host", "ID")]
    public class HOST 
    {

        ///<summary>
        /// ID 
        ///</summary>

        [FieldMapAttribute("ID", 10, false, true)]
        public int ID;

        ///<summary>
        /// master_HOST 
        ///</summary>

        [FieldMapAttribute("MASTER_HOST", typeof(string), 50, true)]
        public string master_HOST;

        ///<summary>
        /// master_DBPORT 
        ///</summary>

        [FieldMapAttribute("MASTER_DBPORT", typeof(string), 50, true)]
        public string master_DBPORT;

        ///<summary>
        /// master_DBNAME 
        ///</summary>

        [FieldMapAttribute("MASTER_DBNAME", typeof(string), 50, true)]
        public string master_DBNAME;

        ///<summary>
        /// USERID 
        ///</summary>

        [FieldMapAttribute("USERID", typeof(string), 50, true)]
        public string USERID;

        ///<summary>
        /// PWD 
        ///</summary>

        [FieldMapAttribute("PWD", typeof(string), 50, true)]
        public string PWD;

        ///<summary>
        /// DBTYPE 
        ///</summary>

        [FieldMapAttribute("DBTYPE", typeof(string), 50, true)]
        public string DBTYPE;

        ///<summary>
        /// HOSTSTATUS 
        ///</summary>

        [FieldMapAttribute("HOSTSTATUS", typeof(string), 50, true)]
        public string HOSTSTATUS;

        ///<summary>
        /// pressure_num 
        ///</summary>

        [FieldMapAttribute("PRESSURE_NUM", typeof(int), 10, true)]
        public int pressure_num;

        ///<summary>
        /// is_full 
        ///</summary>

        [FieldMapAttribute("IS_FULL", typeof(int), 10, true)]
        public int is_full;

        ///<summary>
        /// slave_host 
        ///</summary>

        [FieldMapAttribute("SLAVE_HOST", typeof(string), 50, true)]
        public string slave_host;

        ///<summary>
        /// slave_dbport 
        ///</summary>

        [FieldMapAttribute("SLAVE_DBPORT", typeof(string), 50, true)]
        public string slave_dbport;

        ///<summary>
        /// slave_dbname 
        ///</summary>

        [FieldMapAttribute("SLAVE_DBNAME", typeof(string), 50, true)]
        public string slave_dbname;

        ///<summary>
        /// Mdatetime 
        ///</summary>

        [FieldMapAttribute("MDATETIME", typeof(DateTime), 8, true)]
        public DateTime Mdatetime;
    }
    #endregion 
    #region PRESSURELOG
    /// <summary> 
    /// PRESSURELOG 
    /// </summary> 
    [Serializable, TableMap("tb_pressurelog", "ID")]
    public class PRESSURELOG
    {

        ///<summary>
        /// ID 
        ///</summary>

        [FieldMapAttribute("ID", 10, false, true)]
        public int ID;

        ///<summary>
        /// DBID 
        ///</summary>

        [FieldMapAttribute("DBID", typeof(int), 10, true)]
        public int DBID;

        ///<summary>
        /// pressure_num 
        ///</summary>

        [FieldMapAttribute("PRESSURE_NUM", typeof(int), 10, true)]
        public int pressure_num;

        ///<summary>
        /// is_full 
        ///</summary>

        [FieldMapAttribute("IS_FULL", typeof(int), 10, true)]
        public int is_full;

        ///<summary>
        /// Mdatetime 
        ///</summary>

        [FieldMapAttribute("MDATETIME", typeof(DateTime), 8, true)]
        public DateTime Mdatetime;
    }
    #endregion 

}