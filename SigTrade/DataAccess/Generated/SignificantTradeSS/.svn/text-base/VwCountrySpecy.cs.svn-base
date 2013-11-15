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
namespace SignificantTradeSS{
    /// <summary>
    /// Strongly-typed collection for the VwCountrySpecy class.
    /// </summary>
    [Serializable]
    public partial class VwCountrySpecyCollection : ReadOnlyList<VwCountrySpecy, VwCountrySpecyCollection>
    {        
        public VwCountrySpecyCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vwCountrySpecies view.
    /// </summary>
    [Serializable]
    public partial class VwCountrySpecy : ReadOnlyRecord<VwCountrySpecy>, IReadOnlyRecord
    {
    
	    #region Default Settings
	    protected static void SetSQLProps() 
	    {
		    GetTableSchema();
	    }
	    #endregion
        #region Schema Accessor
	    public static TableSchema.Table Schema
        {
            get
            {
                if (BaseSchema == null)
                {
                    SetSQLProps();
                }
                return BaseSchema;
            }
        }
    	
        private static void GetTableSchema() 
        {
            if(!IsSchemaInitialized)
            {
                //Schema declaration
                TableSchema.Table schema = new TableSchema.Table("vwCountrySpecies", TableType.View, DataService.GetInstance("SignificantTradeSS"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
                TableSchema.TableColumn colvarSpcRecID = new TableSchema.TableColumn(schema);
                colvarSpcRecID.ColumnName = "SpcRecID";
                colvarSpcRecID.DataType = DbType.Int32;
                colvarSpcRecID.MaxLength = 0;
                colvarSpcRecID.AutoIncrement = false;
                colvarSpcRecID.IsNullable = true;
                colvarSpcRecID.IsPrimaryKey = false;
                colvarSpcRecID.IsForeignKey = false;
                colvarSpcRecID.IsReadOnly = false;
                
                schema.Columns.Add(colvarSpcRecID);
                
                TableSchema.TableColumn colvarSpcName = new TableSchema.TableColumn(schema);
                colvarSpcName.ColumnName = "SpcName";
                colvarSpcName.DataType = DbType.String;
                colvarSpcName.MaxLength = 40;
                colvarSpcName.AutoIncrement = false;
                colvarSpcName.IsNullable = true;
                colvarSpcName.IsPrimaryKey = false;
                colvarSpcName.IsForeignKey = false;
                colvarSpcName.IsReadOnly = false;
                
                schema.Columns.Add(colvarSpcName);
                
                TableSchema.TableColumn colvarCtyShort = new TableSchema.TableColumn(schema);
                colvarCtyShort.ColumnName = "CtyShort";
                colvarCtyShort.DataType = DbType.String;
                colvarCtyShort.MaxLength = 70;
                colvarCtyShort.AutoIncrement = false;
                colvarCtyShort.IsNullable = true;
                colvarCtyShort.IsPrimaryKey = false;
                colvarCtyShort.IsForeignKey = false;
                colvarCtyShort.IsReadOnly = false;
                
                schema.Columns.Add(colvarCtyShort);
                
                TableSchema.TableColumn colvarCtyRecID = new TableSchema.TableColumn(schema);
                colvarCtyRecID.ColumnName = "CtyRecID";
                colvarCtyRecID.DataType = DbType.Int32;
                colvarCtyRecID.MaxLength = 0;
                colvarCtyRecID.AutoIncrement = false;
                colvarCtyRecID.IsNullable = true;
                colvarCtyRecID.IsPrimaryKey = false;
                colvarCtyRecID.IsForeignKey = false;
                colvarCtyRecID.IsReadOnly = false;
                
                schema.Columns.Add(colvarCtyRecID);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["SignificantTradeSS"].AddSchema("vwCountrySpecies",schema);
            }
        }
        #endregion
        
        #region Query Accessor
	    public static Query CreateQuery()
	    {
		    return new Query(Schema);
	    }
	    #endregion
	    
	    #region .ctors
	    public VwCountrySpecy()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VwCountrySpecy(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VwCountrySpecy(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VwCountrySpecy(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("SpcRecID")]
        [Bindable(true)]
        public int? SpcRecID 
	    {
		    get
		    {
			    return GetColumnValue<int?>("SpcRecID");
		    }
            set 
		    {
			    SetColumnValue("SpcRecID", value);
            }
        }
	      
        [XmlAttribute("SpcName")]
        [Bindable(true)]
        public string SpcName 
	    {
		    get
		    {
			    return GetColumnValue<string>("SpcName");
		    }
            set 
		    {
			    SetColumnValue("SpcName", value);
            }
        }
	      
        [XmlAttribute("CtyShort")]
        [Bindable(true)]
        public string CtyShort 
	    {
		    get
		    {
			    return GetColumnValue<string>("CtyShort");
		    }
            set 
		    {
			    SetColumnValue("CtyShort", value);
            }
        }
	      
        [XmlAttribute("CtyRecID")]
        [Bindable(true)]
        public int? CtyRecID 
	    {
		    get
		    {
			    return GetColumnValue<int?>("CtyRecID");
		    }
            set 
		    {
			    SetColumnValue("CtyRecID", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string SpcRecID = @"SpcRecID";
            
            public static string SpcName = @"SpcName";
            
            public static string CtyShort = @"CtyShort";
            
            public static string CtyRecID = @"CtyRecID";
            
	    }
	    #endregion
	    
	    
	    #region IAbstractRecord Members
        public new CT GetColumnValue<CT>(string columnName) {
            return base.GetColumnValue<CT>(columnName);
        }
        public object GetColumnValue(string columnName) {
            return base.GetColumnValue<object>(columnName);
        }
        #endregion
	    
    }
}
