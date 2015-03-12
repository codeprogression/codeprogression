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
    /// Strongly-typed collection for the VJobCandidate class.
    /// </summary>
    [Serializable]
    public partial class VJobCandidateCollection : ReadOnlyList<VJobCandidate, VJobCandidateCollection>
    {        
        public VJobCandidateCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vJobCandidate view.
    /// </summary>
    [Serializable]
    public partial class VJobCandidate : ReadOnlyRecord<VJobCandidate>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("vJobCandidate", TableType.View, DataService.GetInstance("AdventureWorks"));
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
                
                TableSchema.TableColumn colvarEmployeeID = new TableSchema.TableColumn(schema);
                colvarEmployeeID.ColumnName = "EmployeeID";
                colvarEmployeeID.DataType = DbType.Int32;
                colvarEmployeeID.MaxLength = 0;
                colvarEmployeeID.AutoIncrement = false;
                colvarEmployeeID.IsNullable = true;
                colvarEmployeeID.IsPrimaryKey = false;
                colvarEmployeeID.IsForeignKey = false;
                colvarEmployeeID.IsReadOnly = false;
                
                schema.Columns.Add(colvarEmployeeID);
                
                TableSchema.TableColumn colvarNamePrefix = new TableSchema.TableColumn(schema);
                colvarNamePrefix.ColumnName = "Name.Prefix";
                colvarNamePrefix.DataType = DbType.String;
                colvarNamePrefix.MaxLength = 30;
                colvarNamePrefix.AutoIncrement = false;
                colvarNamePrefix.IsNullable = true;
                colvarNamePrefix.IsPrimaryKey = false;
                colvarNamePrefix.IsForeignKey = false;
                colvarNamePrefix.IsReadOnly = false;
                
                schema.Columns.Add(colvarNamePrefix);
                
                TableSchema.TableColumn colvarNameFirst = new TableSchema.TableColumn(schema);
                colvarNameFirst.ColumnName = "Name.First";
                colvarNameFirst.DataType = DbType.String;
                colvarNameFirst.MaxLength = 30;
                colvarNameFirst.AutoIncrement = false;
                colvarNameFirst.IsNullable = true;
                colvarNameFirst.IsPrimaryKey = false;
                colvarNameFirst.IsForeignKey = false;
                colvarNameFirst.IsReadOnly = false;
                
                schema.Columns.Add(colvarNameFirst);
                
                TableSchema.TableColumn colvarNameMiddle = new TableSchema.TableColumn(schema);
                colvarNameMiddle.ColumnName = "Name.Middle";
                colvarNameMiddle.DataType = DbType.String;
                colvarNameMiddle.MaxLength = 30;
                colvarNameMiddle.AutoIncrement = false;
                colvarNameMiddle.IsNullable = true;
                colvarNameMiddle.IsPrimaryKey = false;
                colvarNameMiddle.IsForeignKey = false;
                colvarNameMiddle.IsReadOnly = false;
                
                schema.Columns.Add(colvarNameMiddle);
                
                TableSchema.TableColumn colvarNameLast = new TableSchema.TableColumn(schema);
                colvarNameLast.ColumnName = "Name.Last";
                colvarNameLast.DataType = DbType.String;
                colvarNameLast.MaxLength = 30;
                colvarNameLast.AutoIncrement = false;
                colvarNameLast.IsNullable = true;
                colvarNameLast.IsPrimaryKey = false;
                colvarNameLast.IsForeignKey = false;
                colvarNameLast.IsReadOnly = false;
                
                schema.Columns.Add(colvarNameLast);
                
                TableSchema.TableColumn colvarNameSuffix = new TableSchema.TableColumn(schema);
                colvarNameSuffix.ColumnName = "Name.Suffix";
                colvarNameSuffix.DataType = DbType.String;
                colvarNameSuffix.MaxLength = 30;
                colvarNameSuffix.AutoIncrement = false;
                colvarNameSuffix.IsNullable = true;
                colvarNameSuffix.IsPrimaryKey = false;
                colvarNameSuffix.IsForeignKey = false;
                colvarNameSuffix.IsReadOnly = false;
                
                schema.Columns.Add(colvarNameSuffix);
                
                TableSchema.TableColumn colvarSkills = new TableSchema.TableColumn(schema);
                colvarSkills.ColumnName = "Skills";
                colvarSkills.DataType = DbType.String;
                colvarSkills.MaxLength = -1;
                colvarSkills.AutoIncrement = false;
                colvarSkills.IsNullable = true;
                colvarSkills.IsPrimaryKey = false;
                colvarSkills.IsForeignKey = false;
                colvarSkills.IsReadOnly = false;
                
                schema.Columns.Add(colvarSkills);
                
                TableSchema.TableColumn colvarAddrType = new TableSchema.TableColumn(schema);
                colvarAddrType.ColumnName = "Addr.Type";
                colvarAddrType.DataType = DbType.String;
                colvarAddrType.MaxLength = 30;
                colvarAddrType.AutoIncrement = false;
                colvarAddrType.IsNullable = true;
                colvarAddrType.IsPrimaryKey = false;
                colvarAddrType.IsForeignKey = false;
                colvarAddrType.IsReadOnly = false;
                
                schema.Columns.Add(colvarAddrType);
                
                TableSchema.TableColumn colvarAddrLocCountryRegion = new TableSchema.TableColumn(schema);
                colvarAddrLocCountryRegion.ColumnName = "Addr.Loc.CountryRegion";
                colvarAddrLocCountryRegion.DataType = DbType.String;
                colvarAddrLocCountryRegion.MaxLength = 100;
                colvarAddrLocCountryRegion.AutoIncrement = false;
                colvarAddrLocCountryRegion.IsNullable = true;
                colvarAddrLocCountryRegion.IsPrimaryKey = false;
                colvarAddrLocCountryRegion.IsForeignKey = false;
                colvarAddrLocCountryRegion.IsReadOnly = false;
                
                schema.Columns.Add(colvarAddrLocCountryRegion);
                
                TableSchema.TableColumn colvarAddrLocState = new TableSchema.TableColumn(schema);
                colvarAddrLocState.ColumnName = "Addr.Loc.State";
                colvarAddrLocState.DataType = DbType.String;
                colvarAddrLocState.MaxLength = 100;
                colvarAddrLocState.AutoIncrement = false;
                colvarAddrLocState.IsNullable = true;
                colvarAddrLocState.IsPrimaryKey = false;
                colvarAddrLocState.IsForeignKey = false;
                colvarAddrLocState.IsReadOnly = false;
                
                schema.Columns.Add(colvarAddrLocState);
                
                TableSchema.TableColumn colvarAddrLocCity = new TableSchema.TableColumn(schema);
                colvarAddrLocCity.ColumnName = "Addr.Loc.City";
                colvarAddrLocCity.DataType = DbType.String;
                colvarAddrLocCity.MaxLength = 100;
                colvarAddrLocCity.AutoIncrement = false;
                colvarAddrLocCity.IsNullable = true;
                colvarAddrLocCity.IsPrimaryKey = false;
                colvarAddrLocCity.IsForeignKey = false;
                colvarAddrLocCity.IsReadOnly = false;
                
                schema.Columns.Add(colvarAddrLocCity);
                
                TableSchema.TableColumn colvarAddrPostalCode = new TableSchema.TableColumn(schema);
                colvarAddrPostalCode.ColumnName = "Addr.PostalCode";
                colvarAddrPostalCode.DataType = DbType.String;
                colvarAddrPostalCode.MaxLength = 20;
                colvarAddrPostalCode.AutoIncrement = false;
                colvarAddrPostalCode.IsNullable = true;
                colvarAddrPostalCode.IsPrimaryKey = false;
                colvarAddrPostalCode.IsForeignKey = false;
                colvarAddrPostalCode.IsReadOnly = false;
                
                schema.Columns.Add(colvarAddrPostalCode);
                
                TableSchema.TableColumn colvarEMail = new TableSchema.TableColumn(schema);
                colvarEMail.ColumnName = "EMail";
                colvarEMail.DataType = DbType.String;
                colvarEMail.MaxLength = -1;
                colvarEMail.AutoIncrement = false;
                colvarEMail.IsNullable = true;
                colvarEMail.IsPrimaryKey = false;
                colvarEMail.IsForeignKey = false;
                colvarEMail.IsReadOnly = false;
                
                schema.Columns.Add(colvarEMail);
                
                TableSchema.TableColumn colvarWebSite = new TableSchema.TableColumn(schema);
                colvarWebSite.ColumnName = "WebSite";
                colvarWebSite.DataType = DbType.String;
                colvarWebSite.MaxLength = -1;
                colvarWebSite.AutoIncrement = false;
                colvarWebSite.IsNullable = true;
                colvarWebSite.IsPrimaryKey = false;
                colvarWebSite.IsForeignKey = false;
                colvarWebSite.IsReadOnly = false;
                
                schema.Columns.Add(colvarWebSite);
                
                TableSchema.TableColumn colvarModifiedDate = new TableSchema.TableColumn(schema);
                colvarModifiedDate.ColumnName = "ModifiedDate";
                colvarModifiedDate.DataType = DbType.DateTime;
                colvarModifiedDate.MaxLength = 0;
                colvarModifiedDate.AutoIncrement = false;
                colvarModifiedDate.IsNullable = false;
                colvarModifiedDate.IsPrimaryKey = false;
                colvarModifiedDate.IsForeignKey = false;
                colvarModifiedDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarModifiedDate);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["AdventureWorks"].AddSchema("vJobCandidate",schema);
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
	    public VJobCandidate()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VJobCandidate(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VJobCandidate(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VJobCandidate(string columnName, object columnValue)
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
	      
        [XmlAttribute("EmployeeID")]
        [Bindable(true)]
        public int? EmployeeID 
	    {
		    get
		    {
			    return GetColumnValue<int?>("EmployeeID");
		    }
            set 
		    {
			    SetColumnValue("EmployeeID", value);
            }
        }
	      
        [XmlAttribute("NamePrefix")]
        [Bindable(true)]
        public string NamePrefix 
	    {
		    get
		    {
			    return GetColumnValue<string>("Name.Prefix");
		    }
            set 
		    {
			    SetColumnValue("Name.Prefix", value);
            }
        }
	      
        [XmlAttribute("NameFirst")]
        [Bindable(true)]
        public string NameFirst 
	    {
		    get
		    {
			    return GetColumnValue<string>("Name.First");
		    }
            set 
		    {
			    SetColumnValue("Name.First", value);
            }
        }
	      
        [XmlAttribute("NameMiddle")]
        [Bindable(true)]
        public string NameMiddle 
	    {
		    get
		    {
			    return GetColumnValue<string>("Name.Middle");
		    }
            set 
		    {
			    SetColumnValue("Name.Middle", value);
            }
        }
	      
        [XmlAttribute("NameLast")]
        [Bindable(true)]
        public string NameLast 
	    {
		    get
		    {
			    return GetColumnValue<string>("Name.Last");
		    }
            set 
		    {
			    SetColumnValue("Name.Last", value);
            }
        }
	      
        [XmlAttribute("NameSuffix")]
        [Bindable(true)]
        public string NameSuffix 
	    {
		    get
		    {
			    return GetColumnValue<string>("Name.Suffix");
		    }
            set 
		    {
			    SetColumnValue("Name.Suffix", value);
            }
        }
	      
        [XmlAttribute("Skills")]
        [Bindable(true)]
        public string Skills 
	    {
		    get
		    {
			    return GetColumnValue<string>("Skills");
		    }
            set 
		    {
			    SetColumnValue("Skills", value);
            }
        }
	      
        [XmlAttribute("AddrType")]
        [Bindable(true)]
        public string AddrType 
	    {
		    get
		    {
			    return GetColumnValue<string>("Addr.Type");
		    }
            set 
		    {
			    SetColumnValue("Addr.Type", value);
            }
        }
	      
        [XmlAttribute("AddrLocCountryRegion")]
        [Bindable(true)]
        public string AddrLocCountryRegion 
	    {
		    get
		    {
			    return GetColumnValue<string>("Addr.Loc.CountryRegion");
		    }
            set 
		    {
			    SetColumnValue("Addr.Loc.CountryRegion", value);
            }
        }
	      
        [XmlAttribute("AddrLocState")]
        [Bindable(true)]
        public string AddrLocState 
	    {
		    get
		    {
			    return GetColumnValue<string>("Addr.Loc.State");
		    }
            set 
		    {
			    SetColumnValue("Addr.Loc.State", value);
            }
        }
	      
        [XmlAttribute("AddrLocCity")]
        [Bindable(true)]
        public string AddrLocCity 
	    {
		    get
		    {
			    return GetColumnValue<string>("Addr.Loc.City");
		    }
            set 
		    {
			    SetColumnValue("Addr.Loc.City", value);
            }
        }
	      
        [XmlAttribute("AddrPostalCode")]
        [Bindable(true)]
        public string AddrPostalCode 
	    {
		    get
		    {
			    return GetColumnValue<string>("Addr.PostalCode");
		    }
            set 
		    {
			    SetColumnValue("Addr.PostalCode", value);
            }
        }
	      
        [XmlAttribute("EMail")]
        [Bindable(true)]
        public string EMail 
	    {
		    get
		    {
			    return GetColumnValue<string>("EMail");
		    }
            set 
		    {
			    SetColumnValue("EMail", value);
            }
        }
	      
        [XmlAttribute("WebSite")]
        [Bindable(true)]
        public string WebSite 
	    {
		    get
		    {
			    return GetColumnValue<string>("WebSite");
		    }
            set 
		    {
			    SetColumnValue("WebSite", value);
            }
        }
	      
        [XmlAttribute("ModifiedDate")]
        [Bindable(true)]
        public DateTime ModifiedDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime>("ModifiedDate");
		    }
            set 
		    {
			    SetColumnValue("ModifiedDate", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string JobCandidateID = @"JobCandidateID";
            
            public static string EmployeeID = @"EmployeeID";
            
            public static string NamePrefix = @"Name.Prefix";
            
            public static string NameFirst = @"Name.First";
            
            public static string NameMiddle = @"Name.Middle";
            
            public static string NameLast = @"Name.Last";
            
            public static string NameSuffix = @"Name.Suffix";
            
            public static string Skills = @"Skills";
            
            public static string AddrType = @"Addr.Type";
            
            public static string AddrLocCountryRegion = @"Addr.Loc.CountryRegion";
            
            public static string AddrLocState = @"Addr.Loc.State";
            
            public static string AddrLocCity = @"Addr.Loc.City";
            
            public static string AddrPostalCode = @"Addr.PostalCode";
            
            public static string EMail = @"EMail";
            
            public static string WebSite = @"WebSite";
            
            public static string ModifiedDate = @"ModifiedDate";
            
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
