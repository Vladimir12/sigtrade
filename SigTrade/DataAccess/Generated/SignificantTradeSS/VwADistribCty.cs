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
namespace SignificantTradeSS{
    /// <summary>
    /// Strongly-typed collection for the VwADistribCty class.
    /// </summary>
    [Serializable]
    public partial class VwADistribCtyCollection : ReadOnlyList<VwADistribCty, VwADistribCtyCollection>
    {        
        public VwADistribCtyCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vwADistribCty view.
    /// </summary>
    [Serializable]
    public partial class VwADistribCty : ReadOnlyRecord<VwADistribCty>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("vwADistribCty", TableType.View, DataService.GetInstance("SignificantTradeSS"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns
                
                TableSchema.TableColumn colvarDCtRecID = new TableSchema.TableColumn(schema);
                colvarDCtRecID.ColumnName = "DCtRecID";
                colvarDCtRecID.DataType = DbType.Int32;
                colvarDCtRecID.MaxLength = 0;
                colvarDCtRecID.AutoIncrement = false;
                colvarDCtRecID.IsNullable = false;
                colvarDCtRecID.IsPrimaryKey = false;
                colvarDCtRecID.IsForeignKey = false;
                colvarDCtRecID.IsReadOnly = false;
                
                schema.Columns.Add(colvarDCtRecID);
                
                TableSchema.TableColumn colvarDCtSpcRecID = new TableSchema.TableColumn(schema);
                colvarDCtSpcRecID.ColumnName = "DCtSpcRecID";
                colvarDCtSpcRecID.DataType = DbType.Int32;
                colvarDCtSpcRecID.MaxLength = 0;
                colvarDCtSpcRecID.AutoIncrement = false;
                colvarDCtSpcRecID.IsNullable = true;
                colvarDCtSpcRecID.IsPrimaryKey = false;
                colvarDCtSpcRecID.IsForeignKey = false;
                colvarDCtSpcRecID.IsReadOnly = false;
                
                schema.Columns.Add(colvarDCtSpcRecID);
                
                TableSchema.TableColumn colvarDCtCtyRecID = new TableSchema.TableColumn(schema);
                colvarDCtCtyRecID.ColumnName = "DCtCtyRecID";
                colvarDCtCtyRecID.DataType = DbType.Int32;
                colvarDCtCtyRecID.MaxLength = 0;
                colvarDCtCtyRecID.AutoIncrement = false;
                colvarDCtCtyRecID.IsNullable = true;
                colvarDCtCtyRecID.IsPrimaryKey = false;
                colvarDCtCtyRecID.IsForeignKey = false;
                colvarDCtCtyRecID.IsReadOnly = false;
                
                schema.Columns.Add(colvarDCtCtyRecID);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["SignificantTradeSS"].AddSchema("vwADistribCty",schema);
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
	    public VwADistribCty()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VwADistribCty(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VwADistribCty(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VwADistribCty(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("DCtRecID")]
        [Bindable(true)]
        public int DCtRecID 
	    {
		    get
		    {
			    return GetColumnValue<int>("DCtRecID");
		    }
            set 
		    {
			    SetColumnValue("DCtRecID", value);
            }
        }
	      
        [XmlAttribute("DCtSpcRecID")]
        [Bindable(true)]
        public int? DCtSpcRecID 
	    {
		    get
		    {
			    return GetColumnValue<int?>("DCtSpcRecID");
		    }
            set 
		    {
			    SetColumnValue("DCtSpcRecID", value);
            }
        }
	      
        [XmlAttribute("DCtCtyRecID")]
        [Bindable(true)]
        public int? DCtCtyRecID 
	    {
		    get
		    {
			    return GetColumnValue<int?>("DCtCtyRecID");
		    }
            set 
		    {
			    SetColumnValue("DCtCtyRecID", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string DCtRecID = @"DCtRecID";
            
            public static string DCtSpcRecID = @"DCtSpcRecID";
            
            public static string DCtCtyRecID = @"DCtCtyRecID";
            
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