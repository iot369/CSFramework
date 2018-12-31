
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace  Service.Common.Domain
{

    [Serializable]
    public enum KeyTypes
    {
        // Key Fields
        None = 0,
        Primary = 1
    }


    //表格属性
	[Serializable]
	[AttributeUsage(AttributeTargets.Class)]
	public class TableMapAttribute : Attribute
	{
		public TableMapAttribute(string tableName, string keyFields):this(tableName, keyFields, true)
		{
		}

		public TableMapAttribute(string tableName, string keyFields, bool clusteredPrimaryKey)
		{
			this._clusteredPK = clusteredPrimaryKey;
			this. _keyFields = keyFields;//字段名
			this._tableName = tableName;//表名
			this._keyType = KeyTypes.Primary;
		}

		public string TableName
		{
			get
			{
				return this._tableName;
			}
			set
			{
				this._tableName = value;
			}
		}

		public KeyTypes KeyType
		{
			get
			{
				return this._keyType;
			}
			set
			{
				this._keyType = value;
			}
		}

		public string  KeyFields
		{
			get
			{
				return this._keyFields;
			}
			set
			{
				this._keyFields = value;
			}
		}

		public string[] GetKeyFields()
		{
			char[] chArray1 = new char[1] { ',' } ;
			string[] textArray1 = this._keyFields.ToLower().Split(chArray1);
			for (int num1 = 0; num1 < textArray1.Length; num1++)
			{
				textArray1[num1] = textArray1[num1].Trim();
			}
			return textArray1;
		}

		public override int GetHashCode()
		{
			return _tableName.GetHashCode ();
		}


		// Fields
		protected bool _clusteredPK;
		protected string _keyFields;
		protected string _tableName;
		protected KeyTypes _keyType;
	}


}
