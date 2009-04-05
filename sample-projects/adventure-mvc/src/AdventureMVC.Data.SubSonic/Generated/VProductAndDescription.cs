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
    /// Strongly-typed collection for the VProductAndDescription class.
    /// </summary>
    [Serializable]
    public partial class VProductAndDescriptionCollection : ReadOnlyList<VProductAndDescription, VProductAndDescriptionCollection>
    {        
        public VProductAndDescriptionCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vProductAndDescription view.
    /// </summary>
    [Serializable]
    public partial class VProductAndDescription : ReadOnlyRecord<VProductAndDescription>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("vProductAndDescription", TableType.View, DataService.GetInstance("AdventureWorks"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"Production";
                //columns
                
                TableSchema.TableColumn colvarProductID = new TableSchema.TableColumn(schema);
                colvarProductID.ColumnName = "ProductID";
                colvarProductID.DataType = DbType.Int32;
                colvarProductID.MaxLength = 0;
                colvarProductID.AutoIncrement = false;
                colvarProductID.IsNullable = false;
                colvarProductID.IsPrimaryKey = false;
                colvarProductID.IsForeignKey = false;
                colvarProductID.IsReadOnly = false;
                
                schema.Columns.Add(colvarProductID);
                
                TableSchema.TableColumn colvarName = new TableSchema.TableColumn(schema);
                colvarName.ColumnName = "Name";
                colvarName.DataType = DbType.String;
                colvarName.MaxLength = 50;
                colvarName.AutoIncrement = false;
                colvarName.IsNullable = false;
                colvarName.IsPrimaryKey = false;
                colvarName.IsForeignKey = false;
                colvarName.IsReadOnly = false;
                
                schema.Columns.Add(colvarName);
                
                TableSchema.TableColumn colvarProductModel = new TableSchema.TableColumn(schema);
                colvarProductModel.ColumnName = "ProductModel";
                colvarProductModel.DataType = DbType.String;
                colvarProductModel.MaxLength = 50;
                colvarProductModel.AutoIncrement = false;
                colvarProductModel.IsNullable = false;
                colvarProductModel.IsPrimaryKey = false;
                colvarProductModel.IsForeignKey = false;
                colvarProductModel.IsReadOnly = false;
                
                schema.Columns.Add(colvarProductModel);
                
                TableSchema.TableColumn colvarCultureID = new TableSchema.TableColumn(schema);
                colvarCultureID.ColumnName = "CultureID";
                colvarCultureID.DataType = DbType.String;
                colvarCultureID.MaxLength = 6;
                colvarCultureID.AutoIncrement = false;
                colvarCultureID.IsNullable = false;
                colvarCultureID.IsPrimaryKey = false;
                colvarCultureID.IsForeignKey = false;
                colvarCultureID.IsReadOnly = false;
                
                schema.Columns.Add(colvarCultureID);
                
                TableSchema.TableColumn colvarDescription = new TableSchema.TableColumn(schema);
                colvarDescription.ColumnName = "Description";
                colvarDescription.DataType = DbType.String;
                colvarDescription.MaxLength = 400;
                colvarDescription.AutoIncrement = false;
                colvarDescription.IsNullable = false;
                colvarDescription.IsPrimaryKey = false;
                colvarDescription.IsForeignKey = false;
                colvarDescription.IsReadOnly = false;
                
                schema.Columns.Add(colvarDescription);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["AdventureWorks"].AddSchema("vProductAndDescription",schema);
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
	    public VProductAndDescription()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VProductAndDescription(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VProductAndDescription(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VProductAndDescription(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("ProductID")]
        [Bindable(true)]
        public int ProductID 
	    {
		    get
		    {
			    return GetColumnValue<int>("ProductID");
		    }
            set 
		    {
			    SetColumnValue("ProductID", value);
            }
        }
	      
        [XmlAttribute("Name")]
        [Bindable(true)]
        public string Name 
	    {
		    get
		    {
			    return GetColumnValue<string>("Name");
		    }
            set 
		    {
			    SetColumnValue("Name", value);
            }
        }
	      
        [XmlAttribute("ProductModel")]
        [Bindable(true)]
        public string ProductModel 
	    {
		    get
		    {
			    return GetColumnValue<string>("ProductModel");
		    }
            set 
		    {
			    SetColumnValue("ProductModel", value);
            }
        }
	      
        [XmlAttribute("CultureID")]
        [Bindable(true)]
        public string CultureID 
	    {
		    get
		    {
			    return GetColumnValue<string>("CultureID");
		    }
            set 
		    {
			    SetColumnValue("CultureID", value);
            }
        }
	      
        [XmlAttribute("Description")]
        [Bindable(true)]
        public string Description 
	    {
		    get
		    {
			    return GetColumnValue<string>("Description");
		    }
            set 
		    {
			    SetColumnValue("Description", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string ProductID = @"ProductID";
            
            public static string Name = @"Name";
            
            public static string ProductModel = @"ProductModel";
            
            public static string CultureID = @"CultureID";
            
            public static string Description = @"Description";
            
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
