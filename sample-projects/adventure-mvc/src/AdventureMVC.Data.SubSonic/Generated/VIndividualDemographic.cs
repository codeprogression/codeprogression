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
    /// Strongly-typed collection for the VIndividualDemographic class.
    /// </summary>
    [Serializable]
    public partial class VIndividualDemographicCollection : ReadOnlyList<VIndividualDemographic, VIndividualDemographicCollection>
    {        
        public VIndividualDemographicCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vIndividualDemographics view.
    /// </summary>
    [Serializable]
    public partial class VIndividualDemographic : ReadOnlyRecord<VIndividualDemographic>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("vIndividualDemographics", TableType.View, DataService.GetInstance("AdventureWorks"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"Sales";
                //columns
                
                TableSchema.TableColumn colvarCustomerID = new TableSchema.TableColumn(schema);
                colvarCustomerID.ColumnName = "CustomerID";
                colvarCustomerID.DataType = DbType.Int32;
                colvarCustomerID.MaxLength = 0;
                colvarCustomerID.AutoIncrement = false;
                colvarCustomerID.IsNullable = false;
                colvarCustomerID.IsPrimaryKey = false;
                colvarCustomerID.IsForeignKey = false;
                colvarCustomerID.IsReadOnly = false;
                
                schema.Columns.Add(colvarCustomerID);
                
                TableSchema.TableColumn colvarTotalPurchaseYTD = new TableSchema.TableColumn(schema);
                colvarTotalPurchaseYTD.ColumnName = "TotalPurchaseYTD";
                colvarTotalPurchaseYTD.DataType = DbType.Currency;
                colvarTotalPurchaseYTD.MaxLength = 0;
                colvarTotalPurchaseYTD.AutoIncrement = false;
                colvarTotalPurchaseYTD.IsNullable = true;
                colvarTotalPurchaseYTD.IsPrimaryKey = false;
                colvarTotalPurchaseYTD.IsForeignKey = false;
                colvarTotalPurchaseYTD.IsReadOnly = false;
                
                schema.Columns.Add(colvarTotalPurchaseYTD);
                
                TableSchema.TableColumn colvarDateFirstPurchase = new TableSchema.TableColumn(schema);
                colvarDateFirstPurchase.ColumnName = "DateFirstPurchase";
                colvarDateFirstPurchase.DataType = DbType.DateTime;
                colvarDateFirstPurchase.MaxLength = 0;
                colvarDateFirstPurchase.AutoIncrement = false;
                colvarDateFirstPurchase.IsNullable = true;
                colvarDateFirstPurchase.IsPrimaryKey = false;
                colvarDateFirstPurchase.IsForeignKey = false;
                colvarDateFirstPurchase.IsReadOnly = false;
                
                schema.Columns.Add(colvarDateFirstPurchase);
                
                TableSchema.TableColumn colvarBirthDate = new TableSchema.TableColumn(schema);
                colvarBirthDate.ColumnName = "BirthDate";
                colvarBirthDate.DataType = DbType.DateTime;
                colvarBirthDate.MaxLength = 0;
                colvarBirthDate.AutoIncrement = false;
                colvarBirthDate.IsNullable = true;
                colvarBirthDate.IsPrimaryKey = false;
                colvarBirthDate.IsForeignKey = false;
                colvarBirthDate.IsReadOnly = false;
                
                schema.Columns.Add(colvarBirthDate);
                
                TableSchema.TableColumn colvarMaritalStatus = new TableSchema.TableColumn(schema);
                colvarMaritalStatus.ColumnName = "MaritalStatus";
                colvarMaritalStatus.DataType = DbType.String;
                colvarMaritalStatus.MaxLength = 1;
                colvarMaritalStatus.AutoIncrement = false;
                colvarMaritalStatus.IsNullable = true;
                colvarMaritalStatus.IsPrimaryKey = false;
                colvarMaritalStatus.IsForeignKey = false;
                colvarMaritalStatus.IsReadOnly = false;
                
                schema.Columns.Add(colvarMaritalStatus);
                
                TableSchema.TableColumn colvarYearlyIncome = new TableSchema.TableColumn(schema);
                colvarYearlyIncome.ColumnName = "YearlyIncome";
                colvarYearlyIncome.DataType = DbType.String;
                colvarYearlyIncome.MaxLength = 30;
                colvarYearlyIncome.AutoIncrement = false;
                colvarYearlyIncome.IsNullable = true;
                colvarYearlyIncome.IsPrimaryKey = false;
                colvarYearlyIncome.IsForeignKey = false;
                colvarYearlyIncome.IsReadOnly = false;
                
                schema.Columns.Add(colvarYearlyIncome);
                
                TableSchema.TableColumn colvarGender = new TableSchema.TableColumn(schema);
                colvarGender.ColumnName = "Gender";
                colvarGender.DataType = DbType.String;
                colvarGender.MaxLength = 1;
                colvarGender.AutoIncrement = false;
                colvarGender.IsNullable = true;
                colvarGender.IsPrimaryKey = false;
                colvarGender.IsForeignKey = false;
                colvarGender.IsReadOnly = false;
                
                schema.Columns.Add(colvarGender);
                
                TableSchema.TableColumn colvarTotalChildren = new TableSchema.TableColumn(schema);
                colvarTotalChildren.ColumnName = "TotalChildren";
                colvarTotalChildren.DataType = DbType.Int32;
                colvarTotalChildren.MaxLength = 0;
                colvarTotalChildren.AutoIncrement = false;
                colvarTotalChildren.IsNullable = true;
                colvarTotalChildren.IsPrimaryKey = false;
                colvarTotalChildren.IsForeignKey = false;
                colvarTotalChildren.IsReadOnly = false;
                
                schema.Columns.Add(colvarTotalChildren);
                
                TableSchema.TableColumn colvarNumberChildrenAtHome = new TableSchema.TableColumn(schema);
                colvarNumberChildrenAtHome.ColumnName = "NumberChildrenAtHome";
                colvarNumberChildrenAtHome.DataType = DbType.Int32;
                colvarNumberChildrenAtHome.MaxLength = 0;
                colvarNumberChildrenAtHome.AutoIncrement = false;
                colvarNumberChildrenAtHome.IsNullable = true;
                colvarNumberChildrenAtHome.IsPrimaryKey = false;
                colvarNumberChildrenAtHome.IsForeignKey = false;
                colvarNumberChildrenAtHome.IsReadOnly = false;
                
                schema.Columns.Add(colvarNumberChildrenAtHome);
                
                TableSchema.TableColumn colvarEducation = new TableSchema.TableColumn(schema);
                colvarEducation.ColumnName = "Education";
                colvarEducation.DataType = DbType.String;
                colvarEducation.MaxLength = 30;
                colvarEducation.AutoIncrement = false;
                colvarEducation.IsNullable = true;
                colvarEducation.IsPrimaryKey = false;
                colvarEducation.IsForeignKey = false;
                colvarEducation.IsReadOnly = false;
                
                schema.Columns.Add(colvarEducation);
                
                TableSchema.TableColumn colvarOccupation = new TableSchema.TableColumn(schema);
                colvarOccupation.ColumnName = "Occupation";
                colvarOccupation.DataType = DbType.String;
                colvarOccupation.MaxLength = 30;
                colvarOccupation.AutoIncrement = false;
                colvarOccupation.IsNullable = true;
                colvarOccupation.IsPrimaryKey = false;
                colvarOccupation.IsForeignKey = false;
                colvarOccupation.IsReadOnly = false;
                
                schema.Columns.Add(colvarOccupation);
                
                TableSchema.TableColumn colvarHomeOwnerFlag = new TableSchema.TableColumn(schema);
                colvarHomeOwnerFlag.ColumnName = "HomeOwnerFlag";
                colvarHomeOwnerFlag.DataType = DbType.Boolean;
                colvarHomeOwnerFlag.MaxLength = 0;
                colvarHomeOwnerFlag.AutoIncrement = false;
                colvarHomeOwnerFlag.IsNullable = true;
                colvarHomeOwnerFlag.IsPrimaryKey = false;
                colvarHomeOwnerFlag.IsForeignKey = false;
                colvarHomeOwnerFlag.IsReadOnly = false;
                
                schema.Columns.Add(colvarHomeOwnerFlag);
                
                TableSchema.TableColumn colvarNumberCarsOwned = new TableSchema.TableColumn(schema);
                colvarNumberCarsOwned.ColumnName = "NumberCarsOwned";
                colvarNumberCarsOwned.DataType = DbType.Int32;
                colvarNumberCarsOwned.MaxLength = 0;
                colvarNumberCarsOwned.AutoIncrement = false;
                colvarNumberCarsOwned.IsNullable = true;
                colvarNumberCarsOwned.IsPrimaryKey = false;
                colvarNumberCarsOwned.IsForeignKey = false;
                colvarNumberCarsOwned.IsReadOnly = false;
                
                schema.Columns.Add(colvarNumberCarsOwned);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["AdventureWorks"].AddSchema("vIndividualDemographics",schema);
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
	    public VIndividualDemographic()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VIndividualDemographic(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VIndividualDemographic(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VIndividualDemographic(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("CustomerID")]
        [Bindable(true)]
        public int CustomerID 
	    {
		    get
		    {
			    return GetColumnValue<int>("CustomerID");
		    }
            set 
		    {
			    SetColumnValue("CustomerID", value);
            }
        }
	      
        [XmlAttribute("TotalPurchaseYTD")]
        [Bindable(true)]
        public decimal? TotalPurchaseYTD 
	    {
		    get
		    {
			    return GetColumnValue<decimal?>("TotalPurchaseYTD");
		    }
            set 
		    {
			    SetColumnValue("TotalPurchaseYTD", value);
            }
        }
	      
        [XmlAttribute("DateFirstPurchase")]
        [Bindable(true)]
        public DateTime? DateFirstPurchase 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("DateFirstPurchase");
		    }
            set 
		    {
			    SetColumnValue("DateFirstPurchase", value);
            }
        }
	      
        [XmlAttribute("BirthDate")]
        [Bindable(true)]
        public DateTime? BirthDate 
	    {
		    get
		    {
			    return GetColumnValue<DateTime?>("BirthDate");
		    }
            set 
		    {
			    SetColumnValue("BirthDate", value);
            }
        }
	      
        [XmlAttribute("MaritalStatus")]
        [Bindable(true)]
        public string MaritalStatus 
	    {
		    get
		    {
			    return GetColumnValue<string>("MaritalStatus");
		    }
            set 
		    {
			    SetColumnValue("MaritalStatus", value);
            }
        }
	      
        [XmlAttribute("YearlyIncome")]
        [Bindable(true)]
        public string YearlyIncome 
	    {
		    get
		    {
			    return GetColumnValue<string>("YearlyIncome");
		    }
            set 
		    {
			    SetColumnValue("YearlyIncome", value);
            }
        }
	      
        [XmlAttribute("Gender")]
        [Bindable(true)]
        public string Gender 
	    {
		    get
		    {
			    return GetColumnValue<string>("Gender");
		    }
            set 
		    {
			    SetColumnValue("Gender", value);
            }
        }
	      
        [XmlAttribute("TotalChildren")]
        [Bindable(true)]
        public int? TotalChildren 
	    {
		    get
		    {
			    return GetColumnValue<int?>("TotalChildren");
		    }
            set 
		    {
			    SetColumnValue("TotalChildren", value);
            }
        }
	      
        [XmlAttribute("NumberChildrenAtHome")]
        [Bindable(true)]
        public int? NumberChildrenAtHome 
	    {
		    get
		    {
			    return GetColumnValue<int?>("NumberChildrenAtHome");
		    }
            set 
		    {
			    SetColumnValue("NumberChildrenAtHome", value);
            }
        }
	      
        [XmlAttribute("Education")]
        [Bindable(true)]
        public string Education 
	    {
		    get
		    {
			    return GetColumnValue<string>("Education");
		    }
            set 
		    {
			    SetColumnValue("Education", value);
            }
        }
	      
        [XmlAttribute("Occupation")]
        [Bindable(true)]
        public string Occupation 
	    {
		    get
		    {
			    return GetColumnValue<string>("Occupation");
		    }
            set 
		    {
			    SetColumnValue("Occupation", value);
            }
        }
	      
        [XmlAttribute("HomeOwnerFlag")]
        [Bindable(true)]
        public bool? HomeOwnerFlag 
	    {
		    get
		    {
			    return GetColumnValue<bool?>("HomeOwnerFlag");
		    }
            set 
		    {
			    SetColumnValue("HomeOwnerFlag", value);
            }
        }
	      
        [XmlAttribute("NumberCarsOwned")]
        [Bindable(true)]
        public int? NumberCarsOwned 
	    {
		    get
		    {
			    return GetColumnValue<int?>("NumberCarsOwned");
		    }
            set 
		    {
			    SetColumnValue("NumberCarsOwned", value);
            }
        }
	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string CustomerID = @"CustomerID";
            
            public static string TotalPurchaseYTD = @"TotalPurchaseYTD";
            
            public static string DateFirstPurchase = @"DateFirstPurchase";
            
            public static string BirthDate = @"BirthDate";
            
            public static string MaritalStatus = @"MaritalStatus";
            
            public static string YearlyIncome = @"YearlyIncome";
            
            public static string Gender = @"Gender";
            
            public static string TotalChildren = @"TotalChildren";
            
            public static string NumberChildrenAtHome = @"NumberChildrenAtHome";
            
            public static string Education = @"Education";
            
            public static string Occupation = @"Occupation";
            
            public static string HomeOwnerFlag = @"HomeOwnerFlag";
            
            public static string NumberCarsOwned = @"NumberCarsOwned";
            
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
