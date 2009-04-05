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
    /// Strongly-typed collection for the VJobCandidateEducation class.
    /// </summary>
    [Serializable]
    public partial class VJobCandidateEducationCollection : ReadOnlyList<VJobCandidateEducation, VJobCandidateEducationCollection>
    {        
        public VJobCandidateEducationCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vJobCandidateEducation view.
    /// </summary>
    [Serializable]
    public partial class VJobCandidateEducation : ReadOnlyRecord<VJobCandidateEducation>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("vJobCandidateEducation", TableType.View, DataService.GetInstance("AdventureWorks"));
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
                
                TableSchema.TableColumn colvarEduLevel = new TableSchema.TableColumn(schema);
                colvarEduLevel.ColumnName = "Edu.Level";
                colvarEduLevel.DataType = DbType.String;
                colvarEduLevel.MaxLength = -1;
                colvarEduLevel.AutoIncrement = false;
                colvarEduLevel.IsNullable = true;
                colvarEduLevel.IsPrimaryKey = false;
                colvarEduLevel.IsForeignKey = false;
                colvarEduLevel.IsReadOnly = false;
                
                schema.Columns.Add(colvarEduLevel);
                
                TableSchema.TableColumn colvarEduStartDate = new TableSchema.TableColumn(schema);
                colvarEduStartDate.ColumnName = "Edu.StartDate";
                colvarEduStartDate.DataType = DbType.DateTime;
                colvarEduStartDate.MaxLength = 0;
                colvarEduStartDate.AutoIncrement = false;
                colvarEduStartDate.IsNullable = true;
                colvarEduStartDate.IsPrimaryKey = false;
                colvarEduStartDate.IsForeignKey = false;
                colvarEduStartDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarEduStartDate);
                
                TableSchema.TableColumn colvarEduEndDate = new TableSchema.TableColumn(schema);
                colvarEduEndDate.ColumnName = "Edu.EndDate";
                colvarEduEndDate.DataType = DbType.DateTime;
                colvarEduEndDate.MaxLength = 0;
                colvarEduEndDate.AutoIncrement = false;
                colvarEduEndDate.IsNullable = true;
                colvarEduEndDate.IsPrimaryKey = false;
                colvarEduEndDate.IsForeignKey = false;
                colvarEduEndDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarEduEndDate);
                
                TableSchema.TableColumn colvarEduDegree = new TableSchema.TableColumn(schema);
                colvarEduDegree.ColumnName = "Edu.Degree";
                colvarEduDegree.DataType = DbType.String;
                colvarEduDegree.MaxLength = 50;
                colvarEduDegree.AutoIncrement = false;
                colvarEduDegree.IsNullable = true;
                colvarEduDegree.IsPrimaryKey = false;
                colvarEduDegree.IsForeignKey = false;
                colvarEduDegree.IsReadOnly = false;
                
                schema.Columns.Add(colvarEduDegree);
                
                TableSchema.TableColumn colvarEduMajor = new TableSchema.TableColumn(schema);
                colvarEduMajor.ColumnName = "Edu.Major";
                colvarEduMajor.DataType = DbType.String;
                colvarEduMajor.MaxLength = 50;
                colvarEduMajor.AutoIncrement = false;
                colvarEduMajor.IsNullable = true;
                colvarEduMajor.IsPrimaryKey = false;
                colvarEduMajor.IsForeignKey = false;
                colvarEduMajor.IsReadOnly = false;
                
                schema.Columns.Add(colvarEduMajor);
                
                TableSchema.TableColumn colvarEduMinor = new TableSchema.TableColumn(schema);
                colvarEduMinor.ColumnName = "Edu.Minor";
                colvarEduMinor.DataType = DbType.String;
                colvarEduMinor.MaxLength = 50;
                colvarEduMinor.AutoIncrement = false;
                colvarEduMinor.IsNullable = true;
                colvarEduMinor.IsPrimaryKey = false;
                colvarEduMinor.IsForeignKey = false;
                colvarEduMinor.IsReadOnly = false;
                
                schema.Columns.Add(colvarEduMinor);
                
                TableSchema.TableColumn colvarEduGPA = new TableSchema.TableColumn(schema);
                colvarEduGPA.ColumnName = "Edu.GPA";
                colvarEduGPA.DataType = DbType.String;
                colvarEduGPA.MaxLength = 5;
                colvarEduGPA.AutoIncrement = false;
                colvarEduGPA.IsNullable = true;
                colvarEduGPA.IsPrimaryKey = false;
                colvarEduGPA.IsForeignKey = false;
                colvarEduGPA.IsReadOnly = false;
                
                schema.Columns.Add(colvarEduGPA);
                
                TableSchema.TableColumn colvarEduGPAScale = new TableSchema.TableColumn(schema);
                colvarEduGPAScale.ColumnName = "Edu.GPAScale";
                colvarEduGPAScale.DataType = DbType.String;
                colvarEduGPAScale.MaxLength = 5;
                colvarEduGPAScale.AutoIncrement = false;
                colvarEduGPAScale.IsNullable = true;
                colvarEduGPAScale.IsPrimaryKey = false;
                colvarEduGPAScale.IsForeignKey = false;
                colvarEduGPAScale.IsReadOnly = false;
                
                schema.Columns.Add(colvarEduGPAScale);
                
                TableSchema.TableColumn colvarEduSchool = new TableSchema.TableColumn(schema);
                colvarEduSchool.ColumnName = "Edu.School";
                colvarEduSchool.DataType = DbType.String;
                colvarEduSchool.MaxLength = 100;
                colvarEduSchool.AutoIncrement = false;
                colvarEduSchool.IsNullable = true;
                colvarEduSchool.IsPrimaryKey = false;
                colvarEduSchool.IsForeignKey = false;
                colvarEduSchool.IsReadOnly = false;
                
                schema.Columns.Add(colvarEduSchool);
                
                TableSchema.TableColumn colvarEduLocCountryRegion = new TableSchema.TableColumn(schema);
                colvarEduLocCountryRegion.ColumnName = "Edu.Loc.CountryRegion";
                colvarEduLocCountryRegion.DataType = DbType.String;
                colvarEduLocCountryRegion.MaxLength = 100;
                colvarEduLocCountryRegion.AutoIncrement = false;
                colvarEduLocCountryRegion.IsNullable = true;
                colvarEduLocCountryRegion.IsPrimaryKey = false;
                colvarEduLocCountryRegion.IsForeignKey = false;
                colvarEduLocCountryRegion.IsReadOnly = false;
                
                schema.Columns.Add(colvarEduLocCountryRegion);
                
                TableSchema.TableColumn colvarEduLocState = new TableSchema.TableColumn(schema);
                colvarEduLocState.ColumnName = "Edu.Loc.State";
                colvarEduLocState.DataType = DbType.String;
                colvarEduLocState.MaxLength = 100;
                colvarEduLocState.AutoIncrement = false;
                colvarEduLocState.IsNullable = true;
                colvarEduLocState.IsPrimaryKey = false;
                colvarEduLocState.IsForeignKey = false;
                colvarEduLocState.IsReadOnly = false;
                
                schema.Columns.Add(colvarEduLocState);
                
                TableSchema.TableColumn colvarEduLocCity = new TableSchema.TableColumn(schema);
                colvarEduLocCity.ColumnName = "Edu.Loc.City";
                colvarEduLocCity.DataType = DbType.String;
                colvarEduLocCity.MaxLength = 100;
                colvarEduLocCity.AutoIncrement = false;
                colvarEduLocCity.IsNullable = true;
                colvarEduLocCity.IsPrimaryKey = false;
                colvarEduLocCity.IsForeignKey = false;
                colvarEduLocCity.IsReadOnly = false;
                
                schema.Columns.Add(colvarEduLocCity);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["AdventureWorks"].AddSchema("vJobCandidateEducation",schema);
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
	    public VJobCandidateEducation()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VJobCandidateEducation(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VJobCandidateEducation(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VJobCandidateEducation(string columnName, object columnValue)
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
	      
        [XmlAttribute("EduLevel")]
        [Bindable(true)]
        public string EduLevel 
	    {
		    get
		    {
			    return GetColumnValue<string>("Edu.Level");
		    }
            set 
		    {
			    SetColumnValue("Edu.Level", value);
            }
        }
	      
        [XmlAttribute("EduStartDate")]
        [Bindable(true)]
        public DateTime? EduStartDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("Edu.StartDate");
		    }
            set 
		    {
			    SetColumnValue("Edu.StartDate", value);
            }
        }
	      
        [XmlAttribute("EduEndDate")]
        [Bindable(true)]
        public DateTime? EduEndDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("Edu.EndDate");
		    }
            set 
		    {
			    SetColumnValue("Edu.EndDate", value);
            }
        }
	      
        [XmlAttribute("EduDegree")]
        [Bindable(true)]
        public string EduDegree 
	    {
		    get
		    {
			    return GetColumnValue<string>("Edu.Degree");
		    }
            set 
		    {
			    SetColumnValue("Edu.Degree", value);
            }
        }
	      
        [XmlAttribute("EduMajor")]
        [Bindable(true)]
        public string EduMajor 
	    {
		    get
		    {
			    return GetColumnValue<string>("Edu.Major");
		    }
            set 
		    {
			    SetColumnValue("Edu.Major", value);
            }
        }
	      
        [XmlAttribute("EduMinor")]
        [Bindable(true)]
        public string EduMinor 
	    {
		    get
		    {
			    return GetColumnValue<string>("Edu.Minor");
		    }
            set 
		    {
			    SetColumnValue("Edu.Minor", value);
            }
        }
	      
        [XmlAttribute("EduGPA")]
        [Bindable(true)]
        public string EduGPA 
	    {
		    get
		    {
			    return GetColumnValue<string>("Edu.GPA");
		    }
            set 
		    {
			    SetColumnValue("Edu.GPA", value);
            }
        }
	      
        [XmlAttribute("EduGPAScale")]
        [Bindable(true)]
        public string EduGPAScale 
	    {
		    get
		    {
			    return GetColumnValue<string>("Edu.GPAScale");
		    }
            set 
		    {
			    SetColumnValue("Edu.GPAScale", value);
            }
        }
	      
        [XmlAttribute("EduSchool")]
        [Bindable(true)]
        public string EduSchool 
	    {
		    get
		    {
			    return GetColumnValue<string>("Edu.School");
		    }
            set 
		    {
			    SetColumnValue("Edu.School", value);
            }
        }
	      
        [XmlAttribute("EduLocCountryRegion")]
        [Bindable(true)]
        public string EduLocCountryRegion 
	    {
		    get
		    {
			    return GetColumnValue<string>("Edu.Loc.CountryRegion");
		    }
            set 
		    {
			    SetColumnValue("Edu.Loc.CountryRegion", value);
            }
        }
	      
        [XmlAttribute("EduLocState")]
        [Bindable(true)]
        public string EduLocState 
	    {
		    get
		    {
			    return GetColumnValue<string>("Edu.Loc.State");
		    }
            set 
		    {
			    SetColumnValue("Edu.Loc.State", value);
            }
        }
	      
        [XmlAttribute("EduLocCity")]
        [Bindable(true)]
        public string EduLocCity 
	    {
		    get
		    {
			    return GetColumnValue<string>("Edu.Loc.City");
		    }
            set 
		    {
			    SetColumnValue("Edu.Loc.City", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string JobCandidateID = @"JobCandidateID";
            
            public static string EduLevel = @"Edu.Level";
            
            public static string EduStartDate = @"Edu.StartDate";
            
            public static string EduEndDate = @"Edu.EndDate";
            
            public static string EduDegree = @"Edu.Degree";
            
            public static string EduMajor = @"Edu.Major";
            
            public static string EduMinor = @"Edu.Minor";
            
            public static string EduGPA = @"Edu.GPA";
            
            public static string EduGPAScale = @"Edu.GPAScale";
            
            public static string EduSchool = @"Edu.School";
            
            public static string EduLocCountryRegion = @"Edu.Loc.CountryRegion";
            
            public static string EduLocState = @"Edu.Loc.State";
            
            public static string EduLocCity = @"Edu.Loc.City";
            
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
