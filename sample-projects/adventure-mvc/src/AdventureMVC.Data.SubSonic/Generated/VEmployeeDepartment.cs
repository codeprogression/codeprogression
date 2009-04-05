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
    /// Strongly-typed collection for the VEmployeeDepartment class.
    /// </summary>
    [Serializable]
    public partial class VEmployeeDepartmentCollection : ReadOnlyList<VEmployeeDepartment, VEmployeeDepartmentCollection>
    {        
        public VEmployeeDepartmentCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vEmployeeDepartment view.
    /// </summary>
    [Serializable]
    public partial class VEmployeeDepartment : ReadOnlyRecord<VEmployeeDepartment>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("vEmployeeDepartment", TableType.View, DataService.GetInstance("AdventureWorks"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"HumanResources";
                //columns
                
                TableSchema.TableColumn colvarEmployeeID = new TableSchema.TableColumn(schema);
                colvarEmployeeID.ColumnName = "EmployeeID";
                colvarEmployeeID.DataType = DbType.Int32;
                colvarEmployeeID.MaxLength = 0;
                colvarEmployeeID.AutoIncrement = false;
                colvarEmployeeID.IsNullable = false;
                colvarEmployeeID.IsPrimaryKey = false;
                colvarEmployeeID.IsForeignKey = false;
                colvarEmployeeID.IsReadOnly = false;
                
                schema.Columns.Add(colvarEmployeeID);
                
                TableSchema.TableColumn colvarTitle = new TableSchema.TableColumn(schema);
                colvarTitle.ColumnName = "Title";
                colvarTitle.DataType = DbType.String;
                colvarTitle.MaxLength = 8;
                colvarTitle.AutoIncrement = false;
                colvarTitle.IsNullable = true;
                colvarTitle.IsPrimaryKey = false;
                colvarTitle.IsForeignKey = false;
                colvarTitle.IsReadOnly = false;
                
                schema.Columns.Add(colvarTitle);
                
                TableSchema.TableColumn colvarFirstName = new TableSchema.TableColumn(schema);
                colvarFirstName.ColumnName = "FirstName";
                colvarFirstName.DataType = DbType.String;
                colvarFirstName.MaxLength = 50;
                colvarFirstName.AutoIncrement = false;
                colvarFirstName.IsNullable = false;
                colvarFirstName.IsPrimaryKey = false;
                colvarFirstName.IsForeignKey = false;
                colvarFirstName.IsReadOnly = false;
                
                schema.Columns.Add(colvarFirstName);
                
                TableSchema.TableColumn colvarMiddleName = new TableSchema.TableColumn(schema);
                colvarMiddleName.ColumnName = "MiddleName";
                colvarMiddleName.DataType = DbType.String;
                colvarMiddleName.MaxLength = 50;
                colvarMiddleName.AutoIncrement = false;
                colvarMiddleName.IsNullable = true;
                colvarMiddleName.IsPrimaryKey = false;
                colvarMiddleName.IsForeignKey = false;
                colvarMiddleName.IsReadOnly = false;
                
                schema.Columns.Add(colvarMiddleName);
                
                TableSchema.TableColumn colvarLastName = new TableSchema.TableColumn(schema);
                colvarLastName.ColumnName = "LastName";
                colvarLastName.DataType = DbType.String;
                colvarLastName.MaxLength = 50;
                colvarLastName.AutoIncrement = false;
                colvarLastName.IsNullable = false;
                colvarLastName.IsPrimaryKey = false;
                colvarLastName.IsForeignKey = false;
                colvarLastName.IsReadOnly = false;
                
                schema.Columns.Add(colvarLastName);
                
                TableSchema.TableColumn colvarSuffix = new TableSchema.TableColumn(schema);
                colvarSuffix.ColumnName = "Suffix";
                colvarSuffix.DataType = DbType.String;
                colvarSuffix.MaxLength = 10;
                colvarSuffix.AutoIncrement = false;
                colvarSuffix.IsNullable = true;
                colvarSuffix.IsPrimaryKey = false;
                colvarSuffix.IsForeignKey = false;
                colvarSuffix.IsReadOnly = false;
                
                schema.Columns.Add(colvarSuffix);
                
                TableSchema.TableColumn colvarJobTitle = new TableSchema.TableColumn(schema);
                colvarJobTitle.ColumnName = "JobTitle";
                colvarJobTitle.DataType = DbType.String;
                colvarJobTitle.MaxLength = 50;
                colvarJobTitle.AutoIncrement = false;
                colvarJobTitle.IsNullable = false;
                colvarJobTitle.IsPrimaryKey = false;
                colvarJobTitle.IsForeignKey = false;
                colvarJobTitle.IsReadOnly = false;
                
                schema.Columns.Add(colvarJobTitle);
                
                TableSchema.TableColumn colvarDepartment = new TableSchema.TableColumn(schema);
                colvarDepartment.ColumnName = "Department";
                colvarDepartment.DataType = DbType.String;
                colvarDepartment.MaxLength = 50;
                colvarDepartment.AutoIncrement = false;
                colvarDepartment.IsNullable = false;
                colvarDepartment.IsPrimaryKey = false;
                colvarDepartment.IsForeignKey = false;
                colvarDepartment.IsReadOnly = false;
                
                schema.Columns.Add(colvarDepartment);
                
                TableSchema.TableColumn colvarGroupName = new TableSchema.TableColumn(schema);
                colvarGroupName.ColumnName = "GroupName";
                colvarGroupName.DataType = DbType.String;
                colvarGroupName.MaxLength = 50;
                colvarGroupName.AutoIncrement = false;
                colvarGroupName.IsNullable = false;
                colvarGroupName.IsPrimaryKey = false;
                colvarGroupName.IsForeignKey = false;
                colvarGroupName.IsReadOnly = false;
                
                schema.Columns.Add(colvarGroupName);
                
                TableSchema.TableColumn colvarStartDate = new TableSchema.TableColumn(schema);
                colvarStartDate.ColumnName = "StartDate";
                colvarStartDate.DataType = DbType.DateTime;
                colvarStartDate.MaxLength = 0;
                colvarStartDate.AutoIncrement = false;
                colvarStartDate.IsNullable = false;
                colvarStartDate.IsPrimaryKey = false;
                colvarStartDate.IsForeignKey = false;
                colvarStartDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarStartDate);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["AdventureWorks"].AddSchema("vEmployeeDepartment",schema);
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
	    public VEmployeeDepartment()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VEmployeeDepartment(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VEmployeeDepartment(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VEmployeeDepartment(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("EmployeeID")]
        [Bindable(true)]
        public int EmployeeID 
	    {
		    get
		    {
			    return GetColumnValue<int>("EmployeeID");
		    }
            set 
		    {
			    SetColumnValue("EmployeeID", value);
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
	      
        [XmlAttribute("FirstName")]
        [Bindable(true)]
        public string FirstName 
	    {
		    get
		    {
			    return GetColumnValue<string>("FirstName");
		    }
            set 
		    {
			    SetColumnValue("FirstName", value);
            }
        }
	      
        [XmlAttribute("MiddleName")]
        [Bindable(true)]
        public string MiddleName 
	    {
		    get
		    {
			    return GetColumnValue<string>("MiddleName");
		    }
            set 
		    {
			    SetColumnValue("MiddleName", value);
            }
        }
	      
        [XmlAttribute("LastName")]
        [Bindable(true)]
        public string LastName 
	    {
		    get
		    {
			    return GetColumnValue<string>("LastName");
		    }
            set 
		    {
			    SetColumnValue("LastName", value);
            }
        }
	      
        [XmlAttribute("Suffix")]
        [Bindable(true)]
        public string Suffix 
	    {
		    get
		    {
			    return GetColumnValue<string>("Suffix");
		    }
            set 
		    {
			    SetColumnValue("Suffix", value);
            }
        }
	      
        [XmlAttribute("JobTitle")]
        [Bindable(true)]
        public string JobTitle 
	    {
		    get
		    {
			    return GetColumnValue<string>("JobTitle");
		    }
            set 
		    {
			    SetColumnValue("JobTitle", value);
            }
        }
	      
        [XmlAttribute("Department")]
        [Bindable(true)]
        public string Department 
	    {
		    get
		    {
			    return GetColumnValue<string>("Department");
		    }
            set 
		    {
			    SetColumnValue("Department", value);
            }
        }
	      
        [XmlAttribute("GroupName")]
        [Bindable(true)]
        public string GroupName 
	    {
		    get
		    {
			    return GetColumnValue<string>("GroupName");
		    }
            set 
		    {
			    SetColumnValue("GroupName", value);
            }
        }
	      
        [XmlAttribute("StartDate")]
        [Bindable(true)]
        public DateTime StartDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime>("StartDate");
		    }
            set 
		    {
			    SetColumnValue("StartDate", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string EmployeeID = @"EmployeeID";
            
            public static string Title = @"Title";
            
            public static string FirstName = @"FirstName";
            
            public static string MiddleName = @"MiddleName";
            
            public static string LastName = @"LastName";
            
            public static string Suffix = @"Suffix";
            
            public static string JobTitle = @"JobTitle";
            
            public static string Department = @"Department";
            
            public static string GroupName = @"GroupName";
            
            public static string StartDate = @"StartDate";
            
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
