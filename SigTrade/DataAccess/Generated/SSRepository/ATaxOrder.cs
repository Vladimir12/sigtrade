using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;
// <auto-generated />
namespace SignificantTradeSSRepository
{
	/// <summary>
	/// Strongly-typed collection for the ATaxOrder class.
	/// </summary>
    [Serializable]
	public partial class ATaxOrderCollection : RepositoryList<ATaxOrder, ATaxOrderCollection>
	{	   
		public ATaxOrderCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ATaxOrderCollection</returns>
		public ATaxOrderCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ATaxOrder o = this[i];
                foreach (SubSonic.Where w in this.wheres)
                {
                    bool remove = false;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case SubSonic.Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        this.Remove(o);
                        break;
                    }
                }
            }
            return this;
        }
		
		
	}
	/// <summary>
	/// This is an ActiveRecord class which wraps the ATaxOrder table.
	/// </summary>
	[Serializable]
	public partial class ATaxOrder : RepositoryRecord<ATaxOrder>, IRecordBase
	{
		#region .ctors and Default Settings
		
		public ATaxOrder()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ATaxOrder(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		protected static void SetSQLProps() { GetTableSchema(); }
		
		#endregion
		
		#region Schema and Query Accessor	
		public static Query CreateQuery() { return new Query(Schema); }
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}
		}
		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("ATaxOrder", TableType.Table, DataService.GetInstance("SSRepository"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarOrdRecID = new TableSchema.TableColumn(schema);
				colvarOrdRecID.ColumnName = "OrdRecID";
				colvarOrdRecID.DataType = DbType.Int32;
				colvarOrdRecID.MaxLength = 0;
				colvarOrdRecID.AutoIncrement = false;
				colvarOrdRecID.IsNullable = false;
				colvarOrdRecID.IsPrimaryKey = true;
				colvarOrdRecID.IsForeignKey = false;
				colvarOrdRecID.IsReadOnly = false;
				colvarOrdRecID.DefaultSetting = @"";
				colvarOrdRecID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOrdRecID);
				
				TableSchema.TableColumn colvarOrdClaRecID = new TableSchema.TableColumn(schema);
				colvarOrdClaRecID.ColumnName = "OrdClaRecID";
				colvarOrdClaRecID.DataType = DbType.Int32;
				colvarOrdClaRecID.MaxLength = 0;
				colvarOrdClaRecID.AutoIncrement = false;
				colvarOrdClaRecID.IsNullable = true;
				colvarOrdClaRecID.IsPrimaryKey = false;
				colvarOrdClaRecID.IsForeignKey = false;
				colvarOrdClaRecID.IsReadOnly = false;
				colvarOrdClaRecID.DefaultSetting = @"";
				colvarOrdClaRecID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOrdClaRecID);
				
				TableSchema.TableColumn colvarOrdName = new TableSchema.TableColumn(schema);
				colvarOrdName.ColumnName = "OrdName";
				colvarOrdName.DataType = DbType.String;
				colvarOrdName.MaxLength = 30;
				colvarOrdName.AutoIncrement = false;
				colvarOrdName.IsNullable = true;
				colvarOrdName.IsPrimaryKey = false;
				colvarOrdName.IsForeignKey = false;
				colvarOrdName.IsReadOnly = false;
				colvarOrdName.DefaultSetting = @"";
				colvarOrdName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOrdName);
				
				TableSchema.TableColumn colvarOrdRecStatus = new TableSchema.TableColumn(schema);
				colvarOrdRecStatus.ColumnName = "OrdRecStatus";
				colvarOrdRecStatus.DataType = DbType.String;
				colvarOrdRecStatus.MaxLength = 1;
				colvarOrdRecStatus.AutoIncrement = false;
				colvarOrdRecStatus.IsNullable = true;
				colvarOrdRecStatus.IsPrimaryKey = false;
				colvarOrdRecStatus.IsForeignKey = false;
				colvarOrdRecStatus.IsReadOnly = false;
				colvarOrdRecStatus.DefaultSetting = @"";
				colvarOrdRecStatus.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOrdRecStatus);
				
				TableSchema.TableColumn colvarOrdOrder = new TableSchema.TableColumn(schema);
				colvarOrdOrder.ColumnName = "OrdOrder";
				colvarOrdOrder.DataType = DbType.Int32;
				colvarOrdOrder.MaxLength = 0;
				colvarOrdOrder.AutoIncrement = false;
				colvarOrdOrder.IsNullable = true;
				colvarOrdOrder.IsPrimaryKey = false;
				colvarOrdOrder.IsForeignKey = false;
				colvarOrdOrder.IsReadOnly = false;
				colvarOrdOrder.DefaultSetting = @"";
				colvarOrdOrder.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOrdOrder);
				
				TableSchema.TableColumn colvarOrdAdded = new TableSchema.TableColumn(schema);
				colvarOrdAdded.ColumnName = "OrdAdded";
				colvarOrdAdded.DataType = DbType.DateTime;
				colvarOrdAdded.MaxLength = 0;
				colvarOrdAdded.AutoIncrement = false;
				colvarOrdAdded.IsNullable = true;
				colvarOrdAdded.IsPrimaryKey = false;
				colvarOrdAdded.IsForeignKey = false;
				colvarOrdAdded.IsReadOnly = false;
				colvarOrdAdded.DefaultSetting = @"";
				colvarOrdAdded.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOrdAdded);
				
				TableSchema.TableColumn colvarOrdModified = new TableSchema.TableColumn(schema);
				colvarOrdModified.ColumnName = "OrdModified";
				colvarOrdModified.DataType = DbType.DateTime;
				colvarOrdModified.MaxLength = 0;
				colvarOrdModified.AutoIncrement = false;
				colvarOrdModified.IsNullable = true;
				colvarOrdModified.IsPrimaryKey = false;
				colvarOrdModified.IsForeignKey = false;
				colvarOrdModified.IsReadOnly = false;
				colvarOrdModified.DefaultSetting = @"";
				colvarOrdModified.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOrdModified);
				
				TableSchema.TableColumn colvarOrdByWho = new TableSchema.TableColumn(schema);
				colvarOrdByWho.ColumnName = "OrdByWho";
				colvarOrdByWho.DataType = DbType.Int32;
				colvarOrdByWho.MaxLength = 0;
				colvarOrdByWho.AutoIncrement = false;
				colvarOrdByWho.IsNullable = true;
				colvarOrdByWho.IsPrimaryKey = false;
				colvarOrdByWho.IsForeignKey = false;
				colvarOrdByWho.IsReadOnly = false;
				colvarOrdByWho.DefaultSetting = @"";
				colvarOrdByWho.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOrdByWho);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SSRepository"].AddSchema("ATaxOrder",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("OrdRecID")]
		[Bindable(true)]
		public int OrdRecID 
		{
			get { return GetColumnValue<int>(Columns.OrdRecID); }
			set { SetColumnValue(Columns.OrdRecID, value); }
		}
		  
		[XmlAttribute("OrdClaRecID")]
		[Bindable(true)]
		public int? OrdClaRecID 
		{
			get { return GetColumnValue<int?>(Columns.OrdClaRecID); }
			set { SetColumnValue(Columns.OrdClaRecID, value); }
		}
		  
		[XmlAttribute("OrdName")]
		[Bindable(true)]
		public string OrdName 
		{
			get { return GetColumnValue<string>(Columns.OrdName); }
			set { SetColumnValue(Columns.OrdName, value); }
		}
		  
		[XmlAttribute("OrdRecStatus")]
		[Bindable(true)]
		public string OrdRecStatus 
		{
			get { return GetColumnValue<string>(Columns.OrdRecStatus); }
			set { SetColumnValue(Columns.OrdRecStatus, value); }
		}
		  
		[XmlAttribute("OrdOrder")]
		[Bindable(true)]
		public int? OrdOrder 
		{
			get { return GetColumnValue<int?>(Columns.OrdOrder); }
			set { SetColumnValue(Columns.OrdOrder, value); }
		}
		  
		[XmlAttribute("OrdAdded")]
		[Bindable(true)]
		public DateTime? OrdAdded 
		{
			get { return GetColumnValue<DateTime?>(Columns.OrdAdded); }
			set { SetColumnValue(Columns.OrdAdded, value); }
		}
		  
		[XmlAttribute("OrdModified")]
		[Bindable(true)]
		public DateTime? OrdModified 
		{
			get { return GetColumnValue<DateTime?>(Columns.OrdModified); }
			set { SetColumnValue(Columns.OrdModified, value); }
		}
		  
		[XmlAttribute("OrdByWho")]
		[Bindable(true)]
		public int? OrdByWho 
		{
			get { return GetColumnValue<int?>(Columns.OrdByWho); }
			set { SetColumnValue(Columns.OrdByWho, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn OrdRecIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn OrdClaRecIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn OrdNameColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn OrdRecStatusColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn OrdOrderColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn OrdAddedColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn OrdModifiedColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn OrdByWhoColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string OrdRecID = @"OrdRecID";
			 public static string OrdClaRecID = @"OrdClaRecID";
			 public static string OrdName = @"OrdName";
			 public static string OrdRecStatus = @"OrdRecStatus";
			 public static string OrdOrder = @"OrdOrder";
			 public static string OrdAdded = @"OrdAdded";
			 public static string OrdModified = @"OrdModified";
			 public static string OrdByWho = @"OrdByWho";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}