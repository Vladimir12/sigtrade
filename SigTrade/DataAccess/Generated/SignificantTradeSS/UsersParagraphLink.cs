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
namespace SignificantTradeSS
{
	/// <summary>
	/// Strongly-typed collection for the UsersParagraphLink class.
	/// </summary>
    [Serializable]
	public partial class UsersParagraphLinkCollection : ActiveList<UsersParagraphLink, UsersParagraphLinkCollection>
	{	   
		public UsersParagraphLinkCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>UsersParagraphLinkCollection</returns>
		public UsersParagraphLinkCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                UsersParagraphLink o = this[i];
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
	/// This is an ActiveRecord class which wraps the UsersParagraphLink table.
	/// </summary>
	[Serializable]
	public partial class UsersParagraphLink : ActiveRecord<UsersParagraphLink>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public UsersParagraphLink()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public UsersParagraphLink(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public UsersParagraphLink(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public UsersParagraphLink(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
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
				TableSchema.Table schema = new TableSchema.Table("UsersParagraphLink", TableType.Table, DataService.GetInstance("SignificantTradeSS"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "ID";
				colvarId.DataType = DbType.Int32;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = true;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				colvarId.DefaultSetting = @"";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
				TableSchema.TableColumn colvarSourceType = new TableSchema.TableColumn(schema);
				colvarSourceType.ColumnName = "SourceType";
				colvarSourceType.DataType = DbType.Int32;
				colvarSourceType.MaxLength = 0;
				colvarSourceType.AutoIncrement = false;
				colvarSourceType.IsNullable = true;
				colvarSourceType.IsPrimaryKey = false;
				colvarSourceType.IsForeignKey = false;
				colvarSourceType.IsReadOnly = false;
				colvarSourceType.DefaultSetting = @"";
				colvarSourceType.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSourceType);
				
				TableSchema.TableColumn colvarSourceID = new TableSchema.TableColumn(schema);
				colvarSourceID.ColumnName = "SourceID";
				colvarSourceID.DataType = DbType.Int32;
				colvarSourceID.MaxLength = 0;
				colvarSourceID.AutoIncrement = false;
				colvarSourceID.IsNullable = true;
				colvarSourceID.IsPrimaryKey = false;
				colvarSourceID.IsForeignKey = false;
				colvarSourceID.IsReadOnly = false;
				colvarSourceID.DefaultSetting = @"";
				colvarSourceID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSourceID);
				
				TableSchema.TableColumn colvarUserID = new TableSchema.TableColumn(schema);
				colvarUserID.ColumnName = "UserID";
				colvarUserID.DataType = DbType.AnsiString;
				colvarUserID.MaxLength = 100;
				colvarUserID.AutoIncrement = false;
				colvarUserID.IsNullable = true;
				colvarUserID.IsPrimaryKey = false;
				colvarUserID.IsForeignKey = false;
				colvarUserID.IsReadOnly = false;
				colvarUserID.DefaultSetting = @"";
				colvarUserID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUserID);
				
				TableSchema.TableColumn colvarDeleted = new TableSchema.TableColumn(schema);
				colvarDeleted.ColumnName = "Deleted";
				colvarDeleted.DataType = DbType.Boolean;
				colvarDeleted.MaxLength = 0;
				colvarDeleted.AutoIncrement = false;
				colvarDeleted.IsNullable = false;
				colvarDeleted.IsPrimaryKey = false;
				colvarDeleted.IsForeignKey = false;
				colvarDeleted.IsReadOnly = false;
				
						colvarDeleted.DefaultSetting = @"((0))";
				colvarDeleted.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDeleted);
				
				TableSchema.TableColumn colvarDeletedDate = new TableSchema.TableColumn(schema);
				colvarDeletedDate.ColumnName = "DeletedDate";
				colvarDeletedDate.DataType = DbType.DateTime;
				colvarDeletedDate.MaxLength = 0;
				colvarDeletedDate.AutoIncrement = false;
				colvarDeletedDate.IsNullable = true;
				colvarDeletedDate.IsPrimaryKey = false;
				colvarDeletedDate.IsForeignKey = false;
				colvarDeletedDate.IsReadOnly = false;
				colvarDeletedDate.DefaultSetting = @"";
				colvarDeletedDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDeletedDate);
				
				TableSchema.TableColumn colvarDateAdded = new TableSchema.TableColumn(schema);
				colvarDateAdded.ColumnName = "DateAdded";
				colvarDateAdded.DataType = DbType.DateTime;
				colvarDateAdded.MaxLength = 0;
				colvarDateAdded.AutoIncrement = false;
				colvarDateAdded.IsNullable = true;
				colvarDateAdded.IsPrimaryKey = false;
				colvarDateAdded.IsForeignKey = false;
				colvarDateAdded.IsReadOnly = false;
				colvarDateAdded.DefaultSetting = @"";
				colvarDateAdded.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDateAdded);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SignificantTradeSS"].AddSchema("UsersParagraphLink",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Id")]
		[Bindable(true)]
		public int Id 
		{
			get { return GetColumnValue<int>(Columns.Id); }
			set { SetColumnValue(Columns.Id, value); }
		}
		  
		[XmlAttribute("SourceType")]
		[Bindable(true)]
		public int? SourceType 
		{
			get { return GetColumnValue<int?>(Columns.SourceType); }
			set { SetColumnValue(Columns.SourceType, value); }
		}
		  
		[XmlAttribute("SourceID")]
		[Bindable(true)]
		public int? SourceID 
		{
			get { return GetColumnValue<int?>(Columns.SourceID); }
			set { SetColumnValue(Columns.SourceID, value); }
		}
		  
		[XmlAttribute("UserID")]
		[Bindable(true)]
		public string UserID 
		{
			get { return GetColumnValue<string>(Columns.UserID); }
			set { SetColumnValue(Columns.UserID, value); }
		}
		  
		[XmlAttribute("Deleted")]
		[Bindable(true)]
		public bool Deleted 
		{
			get { return GetColumnValue<bool>(Columns.Deleted); }
			set { SetColumnValue(Columns.Deleted, value); }
		}
		  
		[XmlAttribute("DeletedDate")]
		[Bindable(true)]
		public DateTime? DeletedDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.DeletedDate); }
			set { SetColumnValue(Columns.DeletedDate, value); }
		}
		  
		[XmlAttribute("DateAdded")]
		[Bindable(true)]
		public DateTime? DateAdded 
		{
			get { return GetColumnValue<DateTime?>(Columns.DateAdded); }
			set { SetColumnValue(Columns.DateAdded, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varSourceType,int? varSourceID,string varUserID,bool varDeleted,DateTime? varDeletedDate,DateTime? varDateAdded)
		{
			UsersParagraphLink item = new UsersParagraphLink();
			
			item.SourceType = varSourceType;
			
			item.SourceID = varSourceID;
			
			item.UserID = varUserID;
			
			item.Deleted = varDeleted;
			
			item.DeletedDate = varDeletedDate;
			
			item.DateAdded = varDateAdded;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int? varSourceType,int? varSourceID,string varUserID,bool varDeleted,DateTime? varDeletedDate,DateTime? varDateAdded)
		{
			UsersParagraphLink item = new UsersParagraphLink();
			
				item.Id = varId;
			
				item.SourceType = varSourceType;
			
				item.SourceID = varSourceID;
			
				item.UserID = varUserID;
			
				item.Deleted = varDeleted;
			
				item.DeletedDate = varDeletedDate;
			
				item.DateAdded = varDateAdded;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn SourceTypeColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn SourceIDColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn UserIDColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn DeletedColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn DeletedDateColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn DateAddedColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"ID";
			 public static string SourceType = @"SourceType";
			 public static string SourceID = @"SourceID";
			 public static string UserID = @"UserID";
			 public static string Deleted = @"Deleted";
			 public static string DeletedDate = @"DeletedDate";
			 public static string DateAdded = @"DateAdded";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}