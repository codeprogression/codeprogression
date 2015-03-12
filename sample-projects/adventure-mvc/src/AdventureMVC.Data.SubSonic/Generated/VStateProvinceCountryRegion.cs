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
    /// Strongly-typed collection for the VStateProvinceCountryRegion class.
    /// </summary>
    [Serializable]
    public partial class VStateProvinceCountryRegionCollection : ReadOnlyList<VStateProvinceCountryRegion, VStateProvinceCountryRegionCollection>
    {        
        public VStateProvinceCountryRegionCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vStateProvinceCountryRegion view.
    /// </summary>
    [Serializable]
    public partial class VStateProvinceCountryRegion : ReadOnlyRecord<VStateProvinceCountryRegion>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("vStateProvinceCountryRegion", TableType.View, DataService.GetInstance("AdventureWorks"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"Person";
                //columns
                
                TableSchema.TableColumn colvarStateProvinceID = new TableSchema.TableColumn(schema);
                colvarStateProvinceID.ColumnName = "StateProvinceID";
                colvarStateProvinceID.DataType = DbType.Int32;
                colvarStateProvinceID.MaxLength = 0;
                colvarStateProvinceID.AutoIncrement = false;
                colvarStateProvinceID.IsNullable = false;
                colvarStateProvinceID.IsPrimaryKey = false;
                colvarStateProvinceID.IsForeignKey = false;
                colvarStateProvinceID.IsReadOnly = false;
                
                schema.Columns.Add(colvarStateProvinceID);
                
                TableSchema.TableColumn colvarStateProvinceCode = new TableSchema.TableColumn(schema);
                colvarStateProvinceCode.ColumnName = "StateProvinceCode";
                colvarStateProvinceCode.DataType = DbType.String;
                colvarStateProvinceCode.MaxLength = 3;
                colvarStateProvinceCode.AutoIncrement = false;
                colvarStateProvinceCode.IsNullable = false;
                colvarStateProvinceCode.IsPrimaryKey = false;
                colvarStateProvinceCode.IsForeignKey = false;
                colvarStateProvinceCode.IsReadOnly = false;
                
                schema.Columns.Add(colvarStateProvinceCode);
                
                TableSchema.TableColumn colvarIsOnlyStateProvinceFlag = new TableSchema.TableColumn(schema);
                colvarIsOnlyStateProvinceFlag.ColumnName = "IsOnlyStateProvinceFlag";
                colvarIsOnlyStateProvinceFlag.DataType = DbType.Boolean;
                colvarIsOnlyStateProvinceFlag.MaxLength = 0;
                colvarIsOnlyStateProvinceFlag.AutoIncrement = false;
                colvarIsOnlyStateProvinceFlag.IsNullable = false;
                colvarIsOnlyStateProvinceFlag.IsPrimaryKey = false;
                colvarIsOnlyStateProvinceFlag.IsForeignKey = false;
                colvarIsOnlyStateProvinceFlag.IsReadOnly = false;
                
                schema.Columns.Add(colvarIsOnlyStateProvinceFlag);
                
                TableSchema.TableColumn colvarStateProvinceName = new TableSchema.TableColumn(schema);
                colvarStateProvinceName.ColumnName = "StateProvinceName";
                colvarStateProvinceName.DataType = DbType.String;
                colvarStateProvinceName.MaxLength = 50;
                colvarStateProvinceName.AutoIncrement = false;
                colvarStateProvinceName.IsNullable = false;
                colvarStateProvinceName.IsPrimaryKey = false;
                colvarStateProvinceName.IsForeignKey = false;
                colvarStateProvinceName.IsReadOnly = false;
                
                schema.Columns.Add(colvarStateProvinceName);
                
                TableSchema.TableColumn colvarTerritoryID = new TableSchema.TableColumn(schema);
                colvarTerritoryID.ColumnName = "TerritoryID";
                colvarTerritoryID.DataType = DbType.Int32;
                colvarTerritoryID.MaxLength = 0;
                colvarTerritoryID.AutoIncrement = false;
                colvarTerritoryID.IsNullable = false;
                colvarTerritoryID.IsPrimaryKey = false;
                colvarTerritoryID.IsForeignKey = false;
                colvarTerritoryID.IsReadOnly = false;
                
                schema.Columns.Add(colvarTerritoryID);
                
                TableSchema.TableColumn colvarCountryRegionCode = new TableSchema.TableColumn(schema);
                colvarCountryRegionCode.ColumnName = "CountryRegionCode";
                colvarCountryRegionCode.DataType = DbType.String;
                colvarCountryRegionCode.MaxLength = 3;
                colvarCountryRegionCode.AutoIncrement = false;
                colvarCountryRegionCode.IsNullable = false;
                colvarCountryRegionCode.IsPrimaryKey = false;
                colvarCountryRegionCode.IsForeignKey = false;
                colvarCountryRegionCode.IsReadOnly = false;
                
                schema.Columns.Add(colvarCountryRegionCode);
                
                TableSchema.TableColumn colvarCountryRegionName = new TableSchema.TableColumn(schema);
                colvarCountryRegionName.ColumnName = "CountryRegionName";
                colvarCountryRegionName.DataType = DbType.String;
                colvarCountryRegionName.MaxLength = 50;
                colvarCountryRegionName.AutoIncrement = false;
                colvarCountryRegionName.IsNullable = false;
                colvarCountryRegionName.IsPrimaryKey = false;
                colvarCountryRegionName.IsForeignKey = false;
                colvarCountryRegionName.IsReadOnly = false;
                
                schema.Columns.Add(colvarCountryRegionName);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["AdventureWorks"].AddSchema("vStateProvinceCountryRegion",schema);
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
	    public VStateProvinceCountryRegion()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VStateProvinceCountryRegion(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VStateProvinceCountryRegion(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VStateProvinceCountryRegion(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("StateProvinceID")]
        [Bindable(true)]
        public int StateProvinceID 
	    {
		    get
		    {
			    return GetColumnValue<int>("StateProvinceID");
		    }
            set 
		    {
			    SetColumnValue("StateProvinceID", value);
            }
        }
	      
        [XmlAttribute("StateProvinceCode")]
        [Bindable(true)]
        public string StateProvinceCode 
	    {
		    get
		    {
			    return GetColumnValue<string>("StateProvinceCode");
		    }
            set 
		    {
			    SetColumnValue("StateProvinceCode", value);
            }
        }
	      
        [XmlAttribute("IsOnlyStateProvinceFlag")]
        [Bindable(true)]
        public bool IsOnlyStateProvinceFlag 
	    {
		    get
		    {
			    return GetColumnValue<bool>("IsOnlyStateProvinceFlag");
		    }
            set 
		    {
			    SetColumnValue("IsOnlyStateProvinceFlag", value);
            }
        }
	      
        [XmlAttribute("StateProvinceName")]
        [Bindable(true)]
        public string StateProvinceName 
	    {
		    get
		    {
			    return GetColumnValue<string>("StateProvinceName");
		    }
            set 
		    {
			    SetColumnValue("StateProvinceName", value);
            }
        }
	      
        [XmlAttribute("TerritoryID")]
        [Bindable(true)]
        public int TerritoryID 
	    {
		    get
		    {
			    return GetColumnValue<int>("TerritoryID");
		    }
            set 
		    {
			    SetColumnValue("TerritoryID", value);
            }
        }
	      
        [XmlAttribute("CountryRegionCode")]
        [Bindable(true)]
        public string CountryRegionCode 
	    {
		    get
		    {
			    return GetColumnValue<string>("CountryRegionCode");
		    }
            set 
		    {
			    SetColumnValue("CountryRegionCode", value);
            }
        }
	      
        [XmlAttribute("CountryRegionName")]
        [Bindable(true)]
        public string CountryRegionName 
	    {
		    get
		    {
			    return GetColumnValue<string>("CountryRegionName");
		    }
            set 
		    {
			    SetColumnValue("CountryRegionName", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string StateProvinceID = @"StateProvinceID";
            
            public static string StateProvinceCode = @"StateProvinceCode";
            
            public static string IsOnlyStateProvinceFlag = @"IsOnlyStateProvinceFlag";
            
            public static string StateProvinceName = @"StateProvinceName";
            
            public static string TerritoryID = @"TerritoryID";
            
            public static string CountryRegionCode = @"CountryRegionCode";
            
            public static string CountryRegionName = @"CountryRegionName";
            
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
