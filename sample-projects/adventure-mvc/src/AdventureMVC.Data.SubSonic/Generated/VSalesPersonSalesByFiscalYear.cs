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
namespace AdventureWorks{
    /// <summary>
    /// Strongly-typed collection for the VSalesPersonSalesByFiscalYear class.
    /// </summary>
    [Serializable]
    public partial class VSalesPersonSalesByFiscalYearCollection : ReadOnlyList<VSalesPersonSalesByFiscalYear, VSalesPersonSalesByFiscalYearCollection>
    {        
        public VSalesPersonSalesByFiscalYearCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vSalesPersonSalesByFiscalYears view.
    /// </summary>
    [Serializable]
    public partial class VSalesPersonSalesByFiscalYear : ReadOnlyRecord<VSalesPersonSalesByFiscalYear>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("vSalesPersonSalesByFiscalYears", TableType.View, DataService.GetInstance("AdventureWorks"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"Sales";
                //columns
                
                TableSchema.TableColumn colvarSalesPersonID = new TableSchema.TableColumn(schema);
                colvarSalesPersonID.ColumnName = "SalesPersonID";
                colvarSalesPersonID.DataType = DbType.Int32;
                colvarSalesPersonID.MaxLength = 0;
                colvarSalesPersonID.AutoIncrement = false;
                colvarSalesPersonID.IsNullable = true;
                colvarSalesPersonID.IsPrimaryKey = false;
                colvarSalesPersonID.IsForeignKey = false;
                colvarSalesPersonID.IsReadOnly = false;
                
                schema.Columns.Add(colvarSalesPersonID);
                
                TableSchema.TableColumn colvarFullName = new TableSchema.TableColumn(schema);
                colvarFullName.ColumnName = "FullName";
                colvarFullName.DataType = DbType.String;
                colvarFullName.MaxLength = 152;
                colvarFullName.AutoIncrement = false;
                colvarFullName.IsNullable = true;
                colvarFullName.IsPrimaryKey = false;
                colvarFullName.IsForeignKey = false;
                colvarFullName.IsReadOnly = false;
                
                schema.Columns.Add(colvarFullName);
                
                TableSchema.TableColumn colvarTitle = new TableSchema.TableColumn(schema);
                colvarTitle.ColumnName = "Title";
                colvarTitle.DataType = DbType.String;
                colvarTitle.MaxLength = 50;
                colvarTitle.AutoIncrement = false;
                colvarTitle.IsNullable = false;
                colvarTitle.IsPrimaryKey = false;
                colvarTitle.IsForeignKey = false;
                colvarTitle.IsReadOnly = false;
                
                schema.Columns.Add(colvarTitle);
                
                TableSchema.TableColumn colvarSalesTerritory = new TableSchema.TableColumn(schema);
                colvarSalesTerritory.ColumnName = "SalesTerritory";
                colvarSalesTerritory.DataType = DbType.String;
                colvarSalesTerritory.MaxLength = 50;
                colvarSalesTerritory.AutoIncrement = false;
                colvarSalesTerritory.IsNullable = false;
                colvarSalesTerritory.IsPrimaryKey = false;
                colvarSalesTerritory.IsForeignKey = false;
                colvarSalesTerritory.IsReadOnly = false;
                
                schema.Columns.Add(colvarSalesTerritory);
                
                TableSchema.TableColumn colvar_2002 = new TableSchema.TableColumn(schema);
                colvar_2002.ColumnName = "2002";
                colvar_2002.DataType = DbType.Currency;
                colvar_2002.MaxLength = 0;
                colvar_2002.AutoIncrement = false;
                colvar_2002.IsNullable = true;
                colvar_2002.IsPrimaryKey = false;
                colvar_2002.IsForeignKey = false;
                colvar_2002.IsReadOnly = false;
                
                schema.Columns.Add(colvar_2002);
                
                TableSchema.TableColumn colvar_2003 = new TableSchema.TableColumn(schema);
                colvar_2003.ColumnName = "2003";
                colvar_2003.DataType = DbType.Currency;
                colvar_2003.MaxLength = 0;
                colvar_2003.AutoIncrement = false;
                colvar_2003.IsNullable = true;
                colvar_2003.IsPrimaryKey = false;
                colvar_2003.IsForeignKey = false;
                colvar_2003.IsReadOnly = false;
                
                schema.Columns.Add(colvar_2003);
                
                TableSchema.TableColumn colvar_2004 = new TableSchema.TableColumn(schema);
                colvar_2004.ColumnName = "2004";
                colvar_2004.DataType = DbType.Currency;
                colvar_2004.MaxLength = 0;
                colvar_2004.AutoIncrement = false;
                colvar_2004.IsNullable = true;
                colvar_2004.IsPrimaryKey = false;
                colvar_2004.IsForeignKey = false;
                colvar_2004.IsReadOnly = false;
                
                schema.Columns.Add(colvar_2004);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["AdventureWorks"].AddSchema("vSalesPersonSalesByFiscalYears",schema);
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
	    public VSalesPersonSalesByFiscalYear()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VSalesPersonSalesByFiscalYear(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VSalesPersonSalesByFiscalYear(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VSalesPersonSalesByFiscalYear(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("SalesPersonID")]
        [Bindable(true)]
        public int? SalesPersonID 
	    {
		    get
		    {
			    return GetColumnValue<int?>("SalesPersonID");
		    }
            set 
		    {
			    SetColumnValue("SalesPersonID", value);
            }
        }
	      
        [XmlAttribute("FullName")]
        [Bindable(true)]
        public string FullName 
	    {
		    get
		    {
			    return GetColumnValue<string>("FullName");
		    }
            set 
		    {
			    SetColumnValue("FullName", value);
            }
        }
	      
        [XmlAttribute("Title")]
        [Bindable(true)]
        public string Title 
	    {
		    get
		    {
			    return GetColumnValue<string>("Title");
		    }
            set 
		    {
			    SetColumnValue("Title", value);
            }
        }
	      
        [XmlAttribute("SalesTerritory")]
        [Bindable(true)]
        public string SalesTerritory 
	    {
		    get
		    {
			    return GetColumnValue<string>("SalesTerritory");
		    }
            set 
		    {
			    SetColumnValue("SalesTerritory", value);
            }
        }
	      
        [XmlAttribute("_2002")]
        [Bindable(true)]
        public decimal? _2002 
	    {
		    get
		    {
			    return GetColumnValue<decimal?>("2002");
		    }
            set 
		    {
			    SetColumnValue("2002", value);
            }
        }
	      
        [XmlAttribute("_2003")]
        [Bindable(true)]
        public decimal? _2003 
	    {
		    get
		    {
			    return GetColumnValue<decimal?>("2003");
		    }
            set 
		    {
			    SetColumnValue("2003", value);
            }
        }
	      
        [XmlAttribute("_2004")]
        [Bindable(true)]
        public decimal? _2004 
	    {
		    get
		    {
			    return GetColumnValue<decimal?>("2004");
		    }
            set 
		    {
			    SetColumnValue("2004", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string SalesPersonID = @"SalesPersonID";
            
            public static string FullName = @"FullName";
            
            public static string Title = @"Title";
            
            public static string SalesTerritory = @"SalesTerritory";
            
            public static string _2002 = @"2002";
            
            public static string _2003 = @"2003";
            
            public static string _2004 = @"2004";
            
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
