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
namespace SignificantTradeSSRepository{
    /// <summary>
    /// Strongly-typed collection for the VwGenusSpecy class.
    /// </summary>
    [Serializable]
    public partial class VwGenusSpecyCollection : ReadOnlyList<VwGenusSpecy, VwGenusSpecyCollection>
    {        
        public VwGenusSpecyCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vwGenusSpecies view.
    /// </summary>
    [Serializable]
    public partial class VwGenusSpecy : ReadOnlyRecord<VwGenusSpecy>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("vwGenusSpecies", TableType.View, DataService.GetInstance("SSRepository"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
                TableSchema.TableColumn colvarGenRecID = new TableSchema.TableColumn(schema);
                colvarGenRecID.ColumnName = "GenRecID";
                colvarGenRecID.DataType = DbType.Int32;
                colvarGenRecID.MaxLength = 0;
                colvarGenRecID.AutoIncrement = false;
                colvarGenRecID.IsNullable = true;
                colvarGenRecID.IsPrimaryKey = false;
                colvarGenRecID.IsForeignKey = false;
                colvarGenRecID.IsReadOnly = false;
                
                schema.Columns.Add(colvarGenRecID);
                
                TableSchema.TableColumn colvarGenName = new TableSchema.TableColumn(schema);
                colvarGenName.ColumnName = "GenName";
                colvarGenName.DataType = DbType.String;
                colvarGenName.MaxLength = 50;
                colvarGenName.AutoIncrement = false;
                colvarGenName.IsNullable = true;
                colvarGenName.IsPrimaryKey = false;
                colvarGenName.IsForeignKey = false;
                colvarGenName.IsReadOnly = false;
                
                schema.Columns.Add(colvarGenName);
                
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
                
                TableSchema.TableColumn colvarSpcInfraEpithet = new TableSchema.TableColumn(schema);
                colvarSpcInfraEpithet.ColumnName = "SpcInfraEpithet";
                colvarSpcInfraEpithet.DataType = DbType.String;
                colvarSpcInfraEpithet.MaxLength = 30;
                colvarSpcInfraEpithet.AutoIncrement = false;
                colvarSpcInfraEpithet.IsNullable = true;
                colvarSpcInfraEpithet.IsPrimaryKey = false;
                colvarSpcInfraEpithet.IsForeignKey = false;
                colvarSpcInfraEpithet.IsReadOnly = false;
                
                schema.Columns.Add(colvarSpcInfraEpithet);
                
                TableSchema.TableColumn colvarSpcStatus = new TableSchema.TableColumn(schema);
                colvarSpcStatus.ColumnName = "SpcStatus";
                colvarSpcStatus.DataType = DbType.String;
                colvarSpcStatus.MaxLength = 1;
                colvarSpcStatus.AutoIncrement = false;
                colvarSpcStatus.IsNullable = true;
                colvarSpcStatus.IsPrimaryKey = false;
                colvarSpcStatus.IsForeignKey = false;
                colvarSpcStatus.IsReadOnly = false;
                
                schema.Columns.Add(colvarSpcStatus);
                
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
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["SSRepository"].AddSchema("vwGenusSpecies",schema);
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
	    public VwGenusSpecy()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VwGenusSpecy(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VwGenusSpecy(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VwGenusSpecy(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("GenRecID")]
        [Bindable(true)]
        public int? GenRecID 
	    {
		    get
		    {
			    return GetColumnValue<int?>("GenRecID");
		    }
            set 
		    {
			    SetColumnValue("GenRecID", value);
            }
        }
	      
        [XmlAttribute("GenName")]
        [Bindable(true)]
        public string GenName 
	    {
		    get
		    {
			    return GetColumnValue<string>("GenName");
		    }
            set 
		    {
			    SetColumnValue("GenName", value);
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
	      
        [XmlAttribute("SpcInfraEpithet")]
        [Bindable(true)]
        public string SpcInfraEpithet 
	    {
		    get
		    {
			    return GetColumnValue<string>("SpcInfraEpithet");
		    }
            set 
		    {
			    SetColumnValue("SpcInfraEpithet", value);
            }
        }
	      
        [XmlAttribute("SpcStatus")]
        [Bindable(true)]
        public string SpcStatus 
	    {
		    get
		    {
			    return GetColumnValue<string>("SpcStatus");
		    }
            set 
		    {
			    SetColumnValue("SpcStatus", value);
            }
        }
	      
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
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string GenRecID = @"GenRecID";
            
            public static string GenName = @"GenName";
            
            public static string SpcName = @"SpcName";
            
            public static string SpcInfraEpithet = @"SpcInfraEpithet";
            
            public static string SpcStatus = @"SpcStatus";
            
            public static string SpcRecID = @"SpcRecID";
            
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
