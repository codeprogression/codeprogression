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
    /// Strongly-typed collection for the VJobCandidateEmployment class.
    /// </summary>
    [Serializable]
    public partial class VJobCandidateEmploymentCollection : ReadOnlyList<VJobCandidateEmployment, VJobCandidateEmploymentCollection>
    {        
        public VJobCandidateEmploymentCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vJobCandidateEmployment view.
    /// </summary>
    [Serializable]
    public partial class VJobCandidateEmployment : ReadOnlyRecord<VJobCandidateEmployment>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("vJobCandidateEmployment", TableType.View, DataService.GetInstance("AdventureWorks"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"HumanResources";
                //columns
                
                TableSchema.TableColumn colvarJobCandidateID = new TableSchema.TableColumn(schema);
                colvarJobCandidateID.ColumnName = "JobCandidateID";
                colvarJobCandidateID.DataType = DbType.Int32;
                colvarJobCandidateID.MaxLength = 0;
                colvarJobCandidateID.AutoIncrement = false;
                colvarJobCandidateID.IsNullable = false;
                colvarJobCandidateID.IsPrimaryKey = false;
                colvarJobCandidateID.IsForeignKey = false;
                colvarJobCandidateID.IsReadOnly = false;
                
                schema.Columns.Add(colvarJobCandidateID);
                
                TableSchema.TableColumn colvarEmpStartDate = new TableSchema.TableColumn(schema);
                colvarEmpStartDate.ColumnName = "Emp.StartDate";
                colvarEmpStartDate.DataType = DbType.DateTime;
                colvarEmpStartDate.MaxLength = 0;
                colvarEmpStartDate.AutoIncrement = false;
                colvarEmpStartDate.IsNullable = true;
                colvarEmpStartDate.IsPrimaryKey = false;
                colvarEmpStartDate.IsForeignKey = false;
                colvarEmpStartDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarEmpStartDate);
                
                TableSchema.TableColumn colvarEmpEndDate = new TableSchema.TableColumn(schema);
                colvarEmpEndDate.ColumnName = "Emp.EndDate";
                colvarEmpEndDate.DataType = DbType.DateTime;
                colvarEmpEndDate.MaxLength = 0;
                colvarEmpEndDate.AutoIncrement = false;
                colvarEmpEndDate.IsNullable = true;
                colvarEmpEndDate.IsPrimaryKey = false;
                colvarEmpEndDate.IsForeignKey = false;
                colvarEmpEndDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarEmpEndDate);
                
                TableSchema.TableColumn colvarEmpOrgName = new TableSchema.TableColumn(schema);
                colvarEmpOrgName.ColumnName = "Emp.OrgName";
                colvarEmpOrgName.DataType = DbType.String;
                colvarEmpOrgName.MaxLength = 100;
                colvarEmpOrgName.AutoIncrement = false;
                colvarEmpOrgName.IsNullable = true;
                colvarEmpOrgName.IsPrimaryKey = false;
                colvarEmpOrgName.IsForeignKey = false;
                colvarEmpOrgName.IsReadOnly = false;
                
                schema.Columns.Add(colvarEmpOrgName);
                
                TableSchema.TableColumn colvarEmpJobTitle = new TableSchema.TableColumn(schema);
                colvarEmpJobTitle.ColumnName = "Emp.JobTitle";
                colvarEmpJobTitle.DataType = DbType.String;
                colvarEmpJobTitle.MaxLength = 100;
                colvarEmpJobTitle.AutoIncrement = false;
                colvarEmpJobTitle.IsNullable = true;
                colvarEmpJobTitle.IsPrimaryKey = false;
                colvarEmpJobTitle.IsForeignKey = false;
                colvarEmpJobTitle.IsReadOnly = false;
                
                schema.Columns.Add(colvarEmpJobTitle);
                
                TableSchema.TableColumn colvarEmpResponsibility = new TableSchema.TableColumn(schema);
                colvarEmpResponsibility.ColumnName = "Emp.Responsibility";
                colvarEmpResponsibility.DataType = DbType.String;
                colvarEmpResponsibility.MaxLength = -1;
                colvarEmpResponsibility.AutoIncrement = false;
                colvarEmpResponsibility.IsNullable = true;
                colvarEmpResponsibility.IsPrimaryKey = false;
                colvarEmpResponsibility.IsForeignKey = false;
                colvarEmpResponsibility.IsReadOnly = false;
                
                schema.Columns.Add(colvarEmpResponsibility);
                
                TableSchema.TableColumn colvarEmpFunctionCategory = new TableSchema.TableColumn(schema);
                colvarEmpFunctionCategory.ColumnName = "Emp.FunctionCategory";
                colvarEmpFunctionCategory.DataType = DbType.String;
                colvarEmpFunctionCategory.MaxLength = -1;
                colvarEmpFunctionCategory.AutoIncrement = false;
                colvarEmpFunctionCategory.IsNullable = true;
                colvarEmpFunctionCategory.IsPrimaryKey = false;
                colvarEmpFunctionCategory.IsForeignKey = false;
                colvarEmpFunctionCategory.IsReadOnly = false;
                
                schema.Columns.Add(colvarEmpFunctionCategory);
                
                TableSchema.TableColumn colvarEmpIndustryCategory = new TableSchema.TableColumn(schema);
                colvarEmpIndustryCategory.ColumnName = "Emp.IndustryCategory";
                colvarEmpIndustryCategory.DataType = DbType.String;
                colvarEmpIndustryCategory.MaxLength = -1;
                colvarEmpIndustryCategory.AutoIncrement = false;
                colvarEmpIndustryCategory.IsNullable = true;
                colvarEmpIndustryCategory.IsPrimaryKey = false;
                colvarEmpIndustryCategory.IsForeignKey = false;
                colvarEmpIndustryCategory.IsReadOnly = false;
                
                schema.Columns.Add(colvarEmpIndustryCategory);
                
                TableSchema.TableColumn colvarEmpLocCountryRegion = new TableSchema.TableColumn(schema);
                colvarEmpLocCountryRegion.ColumnName = "Emp.Loc.CountryRegion";
                colvarEmpLocCountryRegion.DataType = DbType.String;
                colvarEmpLocCountryRegion.MaxLength = -1;
                colvarEmpLocCountryRegion.AutoIncrement = false;
                colvarEmpLocCountryRegion.IsNullable = true;
                colvarEmpLocCountryRegion.IsPrimaryKey = false;
                colvarEmpLocCountryRegion.IsForeignKey = false;
                colvarEmpLocCountryRegion.IsReadOnly = false;
                
                schema.Columns.Add(colvarEmpLocCountryRegion);
                
                TableSchema.TableColumn colvarEmpLocState = new TableSchema.TableColumn(schema);
                colvarEmpLocState.ColumnName = "Emp.Loc.State";
                colvarEmpLocState.DataType = DbType.String;
                colvarEmpLocState.MaxLength = -1;
                colvarEmpLocState.AutoIncrement = false;
                colvarEmpLocState.IsNullable = true;
                colvarEmpLocState.IsPrimaryKey = false;
                colvarEmpLocState.IsForeignKey = false;
                colvarEmpLocState.IsReadOnly = false;
                
                schema.Columns.Add(colvarEmpLocState);
                
                TableSchema.TableColumn colvarEmpLocCity = new TableSchema.TableColumn(schema);
                colvarEmpLocCity.ColumnName = "Emp.Loc.City";
                colvarEmpLocCity.DataType = DbType.String;
                colvarEmpLocCity.MaxLength = -1;
                colvarEmpLocCity.AutoIncrement = false;
                colvarEmpLocCity.IsNullable = true;
                colvarEmpLocCity.IsPrimaryKey = false;
                colvarEmpLocCity.IsForeignKey = false;
                colvarEmpLocCity.IsReadOnly = false;
                
                schema.Columns.Add(colvarEmpLocCity);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["AdventureWorks"].AddSchema("vJobCandidateEmployment",schema);
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
	    public VJobCandidateEmployment()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VJobCandidateEmployment(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VJobCandidateEmployment(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VJobCandidateEmployment(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("JobCandidateID")]
        [Bindable(true)]
        public int JobCandidateID 
	    {
		    get
		    {
			    return GetColumnValue<int>("JobCandidateID");
		    }
            set 
		    {
			    SetColumnValue("JobCandidateID", value);
            }
        }
	      
        [XmlAttribute("EmpStartDate")]
        [Bindable(true)]
        public DateTime? EmpStartDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("Emp.StartDate");
		    }
            set 
		    {
			    SetColumnValue("Emp.StartDate", value);
            }
        }
	      
        [XmlAttribute("EmpEndDate")]
        [Bindable(true)]
        public DateTime? EmpEndDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("Emp.EndDate");
		    }
            set 
		    {
			    SetColumnValue("Emp.EndDate", value);
            }
        }
	      
        [XmlAttribute("EmpOrgName")]
        [Bindable(true)]
        public string EmpOrgName 
	    {
		    get
		    {
			    return GetColumnValue<string>("Emp.OrgName");
		    }
            set 
		    {
			    SetColumnValue("Emp.OrgName", value);
            }
        }
	      
        [XmlAttribute("EmpJobTitle")]
        [Bindable(true)]
        public string EmpJobTitle 
	    {
		    get
		    {
			    return GetColumnValue<string>("Emp.JobTitle");
		    }
            set 
		    {
			    SetColumnValue("Emp.JobTitle", value);
            }
        }
	      
        [XmlAttribute("EmpResponsibility")]
        [Bindable(true)]
        public string EmpResponsibility 
	    {
		    get
		    {
			    return GetColumnValue<string>("Emp.Responsibility");
		    }
            set 
		    {
			    SetColumnValue("Emp.Responsibility", value);
            }
        }
	      
        [XmlAttribute("EmpFunctionCategory")]
        [Bindable(true)]
        public string EmpFunctionCategory 
	    {
		    get
		    {
			    return GetColumnValue<string>("Emp.FunctionCategory");
		    }
            set 
		    {
			    SetColumnValue("Emp.FunctionCategory", value);
            }
        }
	      
        [XmlAttribute("EmpIndustryCategory")]
        [Bindable(true)]
        public string EmpIndustryCategory 
	    {
		    get
		    {
			    return GetColumnValue<string>("Emp.IndustryCategory");
		    }
            set 
		    {
			    SetColumnValue("Emp.IndustryCategory", value);
            }
        }
	      
        [XmlAttribute("EmpLocCountryRegion")]
        [Bindable(true)]
        public string EmpLocCountryRegion 
	    {
		    get
		    {
			    return GetColumnValue<string>("Emp.Loc.CountryRegion");
		    }
            set 
		    {
			    SetColumnValue("Emp.Loc.CountryRegion", value);
            }
        }
	      
        [XmlAttribute("EmpLocState")]
        [Bindable(true)]
        public string EmpLocState 
	    {
		    get
		    {
			    return GetColumnValue<string>("Emp.Loc.State");
		    }
            set 
		    {
			    SetColumnValue("Emp.Loc.State", value);
            }
        }
	      
        [XmlAttribute("EmpLocCity")]
        [Bindable(true)]
        public string EmpLocCity 
	    {
		    get
		    {
			    return GetColumnValue<string>("Emp.Loc.City");
		    }
            set 
		    {
			    SetColumnValue("Emp.Loc.City", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string JobCandidateID = @"JobCandidateID";
            
            public static string EmpStartDate = @"Emp.StartDate";
            
            public static string EmpEndDate = @"Emp.EndDate";
            
            public static string EmpOrgName = @"Emp.OrgName";
            
            public static string EmpJobTitle = @"Emp.JobTitle";
            
            public static string EmpResponsibility = @"Emp.Responsibility";
            
            public static string EmpFunctionCategory = @"Emp.FunctionCategory";
            
            public static string EmpIndustryCategory = @"Emp.IndustryCategory";
            
            public static string EmpLocCountryRegion = @"Emp.Loc.CountryRegion";
            
            public static string EmpLocState = @"Emp.Loc.State";
            
            public static string EmpLocCity = @"Emp.Loc.City";
            
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
