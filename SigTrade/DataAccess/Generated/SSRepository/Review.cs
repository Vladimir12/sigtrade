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
namespace SignificantTradeSSRepository
{
	/// <summary>
	/// Strongly-typed collection for the Review class.
	/// </summary>
    [Serializable]
	public partial class ReviewCollection : RepositoryList<Review, ReviewCollection>
	{	   
		public ReviewCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ReviewCollection</returns>
		public ReviewCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Review o = this[i];
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
	/// This is an ActiveRecord class which wraps the tblReview table.
	/// </summary>
	[Serializable]
	public partial class Review : RepositoryRecord<Review>, IRecordBase
	{
		#region .ctors and Default Settings
		
		public Review()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Review(bool useDatabaseDefaults)
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
				TableSchema.Table schema = new TableSchema.Table("tblReview", TableType.Table, DataService.GetInstance("SSRepository"));
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
				
				TableSchema.TableColumn colvarPhaseID = new TableSchema.TableColumn(schema);
				colvarPhaseID.ColumnName = "PhaseID";
				colvarPhaseID.DataType = DbType.Int32;
				colvarPhaseID.MaxLength = 0;
				colvarPhaseID.AutoIncrement = false;
				colvarPhaseID.IsNullable = true;
				colvarPhaseID.IsPrimaryKey = false;
				colvarPhaseID.IsForeignKey = false;
				colvarPhaseID.IsReadOnly = false;
				colvarPhaseID.DefaultSetting = @"";
				colvarPhaseID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPhaseID);
				
				TableSchema.TableColumn colvarCountryID = new TableSchema.TableColumn(schema);
				colvarCountryID.ColumnName = "CountryID";
				colvarCountryID.DataType = DbType.Int32;
				colvarCountryID.MaxLength = 0;
				colvarCountryID.AutoIncrement = false;
				colvarCountryID.IsNullable = true;
				colvarCountryID.IsPrimaryKey = false;
				colvarCountryID.IsForeignKey = false;
				colvarCountryID.IsReadOnly = false;
				colvarCountryID.DefaultSetting = @"";
				colvarCountryID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCountryID);
				
				TableSchema.TableColumn colvarTaxonID = new TableSchema.TableColumn(schema);
				colvarTaxonID.ColumnName = "TaxonID";
				colvarTaxonID.DataType = DbType.Int32;
				colvarTaxonID.MaxLength = 0;
				colvarTaxonID.AutoIncrement = false;
				colvarTaxonID.IsNullable = true;
				colvarTaxonID.IsPrimaryKey = false;
				colvarTaxonID.IsForeignKey = false;
				colvarTaxonID.IsReadOnly = false;
				colvarTaxonID.DefaultSetting = @"";
				colvarTaxonID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTaxonID);
				
				TableSchema.TableColumn colvarTaxonLevel = new TableSchema.TableColumn(schema);
				colvarTaxonLevel.ColumnName = "TaxonLevel";
				colvarTaxonLevel.DataType = DbType.Int32;
				colvarTaxonLevel.MaxLength = 0;
				colvarTaxonLevel.AutoIncrement = false;
				colvarTaxonLevel.IsNullable = true;
				colvarTaxonLevel.IsPrimaryKey = false;
				colvarTaxonLevel.IsForeignKey = false;
				colvarTaxonLevel.IsReadOnly = false;
				colvarTaxonLevel.DefaultSetting = @"";
				colvarTaxonLevel.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTaxonLevel);
				
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
				
				TableSchema.TableColumn colvarAddedBy = new TableSchema.TableColumn(schema);
				colvarAddedBy.ColumnName = "AddedBy";
				colvarAddedBy.DataType = DbType.Int32;
				colvarAddedBy.MaxLength = 0;
				colvarAddedBy.AutoIncrement = false;
				colvarAddedBy.IsNullable = true;
				colvarAddedBy.IsPrimaryKey = false;
				colvarAddedBy.IsForeignKey = false;
				colvarAddedBy.IsReadOnly = false;
				colvarAddedBy.DefaultSetting = @"";
				colvarAddedBy.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAddedBy);
				
				TableSchema.TableColumn colvarKingdomID = new TableSchema.TableColumn(schema);
				colvarKingdomID.ColumnName = "KingdomID";
				colvarKingdomID.DataType = DbType.Int32;
				colvarKingdomID.MaxLength = 0;
				colvarKingdomID.AutoIncrement = false;
				colvarKingdomID.IsNullable = true;
				colvarKingdomID.IsPrimaryKey = false;
				colvarKingdomID.IsForeignKey = false;
				colvarKingdomID.IsReadOnly = false;
				colvarKingdomID.DefaultSetting = @"";
				colvarKingdomID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarKingdomID);
				
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["SSRepository"].AddSchema("tblReview",schema);
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
		  
		[XmlAttribute("PhaseID")]
		[Bindable(true)]
		public int? PhaseID 
		{
			get { return GetColumnValue<int?>(Columns.PhaseID); }
			set { SetColumnValue(Columns.PhaseID, value); }
		}
		  
		[XmlAttribute("CountryID")]
		[Bindable(true)]
		public int? CountryID 
		{
			get { return GetColumnValue<int?>(Columns.CountryID); }
			set { SetColumnValue(Columns.CountryID, value); }
		}
		  
		[XmlAttribute("TaxonID")]
		[Bindable(true)]
		public int? TaxonID 
		{
			get { return GetColumnValue<int?>(Columns.TaxonID); }
			set { SetColumnValue(Columns.TaxonID, value); }
		}
		  
		[XmlAttribute("TaxonLevel")]
		[Bindable(true)]
		public int? TaxonLevel 
		{
			get { return GetColumnValue<int?>(Columns.TaxonLevel); }
			set { SetColumnValue(Columns.TaxonLevel, value); }
		}
		  
		[XmlAttribute("DateAdded")]
		[Bindable(true)]
		public DateTime? DateAdded 
		{
			get { return GetColumnValue<DateTime?>(Columns.DateAdded); }
			set { SetColumnValue(Columns.DateAdded, value); }
		}
		  
		[XmlAttribute("AddedBy")]
		[Bindable(true)]
		public int? AddedBy 
		{
			get { return GetColumnValue<int?>(Columns.AddedBy); }
			set { SetColumnValue(Columns.AddedBy, value); }
		}
		  
		[XmlAttribute("KingdomID")]
		[Bindable(true)]
		public int? KingdomID 
		{
			get { return GetColumnValue<int?>(Columns.KingdomID); }
			set { SetColumnValue(Columns.KingdomID, value); }
		}
		  
		[XmlAttribute("Deleted")]
		[Bindable(true)]
		public bool Deleted 
		{
			get { return GetColumnValue<bool>(Columns.Deleted); }
			set { SetColumnValue(Columns.Deleted, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn PhaseIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn CountryIDColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn TaxonIDColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn TaxonLevelColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn DateAddedColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn AddedByColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn KingdomIDColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn DeletedColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"ID";
			 public static string PhaseID = @"PhaseID";
			 public static string CountryID = @"CountryID";
			 public static string TaxonID = @"TaxonID";
			 public static string TaxonLevel = @"TaxonLevel";
			 public static string DateAdded = @"DateAdded";
			 public static string AddedBy = @"AddedBy";
			 public static string KingdomID = @"KingdomID";
			 public static string Deleted = @"Deleted";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
