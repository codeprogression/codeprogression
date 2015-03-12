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
    /// Strongly-typed collection for the VVendor class.
    /// </summary>
    [Serializable]
    public partial class VVendorCollection : ReadOnlyList<VVendor, VVendorCollection>
    {        
        public VVendorCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vVendor view.
    /// </summary>
    [Serializable]
    public partial class VVendor : ReadOnlyRecord<VVendor>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("vVendor", TableType.View, DataService.GetInstance("AdventureWorks"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"Purchasing";
                //columns
                
                TableSchema.TableColumn colvarVendorID = new TableSchema.TableColumn(schema);
                colvarVendorID.ColumnName = "VendorID";
                colvarVendorID.DataType = DbType.Int32;
                colvarVendorID.MaxLength = 0;
                colvarVendorID.AutoIncrement = false;
                colvarVendorID.IsNullable = false;
                colvarVendorID.IsPrimaryKey = false;
                colvarVendorID.IsForeignKey = false;
                colvarVendorID.IsReadOnly = false;
                
                schema.Columns.Add(colvarVendorID);
                
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
                
                TableSchema.TableColumn colvarContactType = new TableSchema.TableColumn(schema);
                colvarContactType.ColumnName = "ContactType";
                colvarContactType.DataType = DbType.String;
                colvarContactType.MaxLength = 50;
                colvarContactType.AutoIncrement = false;
                colvarContactType.IsNullable = false;
                colvarContactType.IsPrimaryKey = false;
                colvarContactType.IsForeignKey = false;
                colvarContactType.IsReadOnly = false;
                
                schema.Columns.Add(colvarContactType);
                
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
                
                TableSchema.TableColumn colvarPhone = new TableSchema.TableColumn(schema);
                colvarPhone.ColumnName = "Phone";
                colvarPhone.DataType = DbType.String;
                colvarPhone.MaxLength = 25;
                colvarPhone.AutoIncrement = false;
                colvarPhone.IsNullable = true;
                colvarPhone.IsPrimaryKey = false;
                colvarPhone.IsForeignKey = false;
                colvarPhone.IsReadOnly = false;
                
                schema.Columns.Add(colvarPhone);
                
                TableSchema.TableColumn colvarEmailAddress = new TableSchema.TableColumn(schema);
                colvarEmailAddress.ColumnName = "EmailAddress";
                colvarEmailAddress.DataType = DbType.String;
                colvarEmailAddress.MaxLength = 50;
                colvarEmailAddress.AutoIncrement = false;
                colvarEmailAddress.IsNullable = true;
                colvarEmailAddress.IsPrimaryKey = false;
                colvarEmailAddress.IsForeignKey = false;
                colvarEmailAddress.IsReadOnly = false;
                
                schema.Columns.Add(colvarEmailAddress);
                
                TableSchema.TableColumn colvarEmailPromotion = new TableSchema.TableColumn(schema);
                colvarEmailPromotion.ColumnName = "EmailPromotion";
                colvarEmailPromotion.DataType = DbType.Int32;
                colvarEmailPromotion.MaxLength = 0;
                colvarEmailPromotion.AutoIncrement = false;
                colvarEmailPromotion.IsNullable = false;
                colvarEmailPromotion.IsPrimaryKey = false;
                colvarEmailPromotion.IsForeignKey = false;
                colvarEmailPromotion.IsReadOnly = false;
                
                schema.Columns.Add(colvarEmailPromotion);
                
                TableSchema.TableColumn colvarAddressLine1 = new TableSchema.TableColumn(schema);
                colvarAddressLine1.ColumnName = "AddressLine1";
                colvarAddressLine1.DataType = DbType.String;
                colvarAddressLine1.MaxLength = 60;
                colvarAddressLine1.AutoIncrement = false;
                colvarAddressLine1.IsNullable = false;
                colvarAddressLine1.IsPrimaryKey = false;
                colvarAddressLine1.IsForeignKey = false;
                colvarAddressLine1.IsReadOnly = false;
                
                schema.Columns.Add(colvarAddressLine1);
                
                TableSchema.TableColumn colvarAddressLine2 = new TableSchema.TableColumn(schema);
                colvarAddressLine2.ColumnName = "AddressLine2";
                colvarAddressLine2.DataType = DbType.String;
                colvarAddressLine2.MaxLength = 60;
                colvarAddressLine2.AutoIncrement = false;
                colvarAddressLine2.IsNullable = true;
                colvarAddressLine2.IsPrimaryKey = false;
                colvarAddressLine2.IsForeignKey = false;
                colvarAddressLine2.IsReadOnly = false;
                
                schema.Columns.Add(colvarAddressLine2);
                
                TableSchema.TableColumn colvarCity = new TableSchema.TableColumn(schema);
                colvarCity.ColumnName = "City";
                colvarCity.DataType = DbType.String;
                colvarCity.MaxLength = 30;
                colvarCity.AutoIncrement = false;
                colvarCity.IsNullable = false;
                colvarCity.IsPrimaryKey = false;
                colvarCity.IsForeignKey = false;
                colvarCity.IsReadOnly = false;
                
                schema.Columns.Add(colvarCity);
                
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
                
                TableSchema.TableColumn colvarPostalCode = new TableSchema.TableColumn(schema);
                colvarPostalCode.ColumnName = "PostalCode";
                colvarPostalCode.DataType = DbType.String;
                colvarPostalCode.MaxLength = 15;
                colvarPostalCode.AutoIncrement = false;
                colvarPostalCode.IsNullable = false;
                colvarPostalCode.IsPrimaryKey = false;
                colvarPostalCode.IsForeignKey = false;
                colvarPostalCode.IsReadOnly = false;
                
                schema.Columns.Add(colvarPostalCode);
                
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
                DataService.Providers["AdventureWorks"].AddSchema("vVendor",schema);
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
	    public VVendor()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VVendor(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VVendor(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VVendor(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("VendorID")]
        [Bindable(true)]
        public int VendorID 
	    {
		    get
		    {
			    return GetColumnValue<int>("VendorID");
		    }
            set 
		    {
			    SetColumnValue("VendorID", value);
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
	      
        [XmlAttribute("ContactType")]
        [Bindable(true)]
        public string ContactType 
	    {
		    get
		    {
			    return GetColumnValue<string>("ContactType");
		    }
            set 
		    {
			    SetColumnValue("ContactType", value);
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
	      
        [XmlAttribute("Phone")]
        [Bindable(true)]
        public string Phone 
	    {
		    get
		    {
			    return GetColumnValue<string>("Phone");
		    }
            set 
		    {
			    SetColumnValue("Phone", value);
            }
        }
	      
        [XmlAttribute("EmailAddress")]
        [Bindable(true)]
        public string EmailAddress 
	    {
		    get
		    {
			    return GetColumnValue<string>("EmailAddress");
		    }
            set 
		    {
			    SetColumnValue("EmailAddress", value);
            }
        }
	      
        [XmlAttribute("EmailPromotion")]
        [Bindable(true)]
        public int EmailPromotion 
	    {
		    get
		    {
			    return GetColumnValue<int>("EmailPromotion");
		    }
            set 
		    {
			    SetColumnValue("EmailPromotion", value);
            }
        }
	      
        [XmlAttribute("AddressLine1")]
        [Bindable(true)]
        public string AddressLine1 
	    {
		    get
		    {
			    return GetColumnValue<string>("AddressLine1");
		    }
            set 
		    {
			    SetColumnValue("AddressLine1", value);
            }
        }
	      
        [XmlAttribute("AddressLine2")]
        [Bindable(true)]
        public string AddressLine2 
	    {
		    get
		    {
			    return GetColumnValue<string>("AddressLine2");
		    }
            set 
		    {
			    SetColumnValue("AddressLine2", value);
            }
        }
	      
        [XmlAttribute("City")]
        [Bindable(true)]
        public string City 
	    {
		    get
		    {
			    return GetColumnValue<string>("City");
		    }
            set 
		    {
			    SetColumnValue("City", value);
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
	      
        [XmlAttribute("PostalCode")]
        [Bindable(true)]
        public string PostalCode 
	    {
		    get
		    {
			    return GetColumnValue<string>("PostalCode");
		    }
            set 
		    {
			    SetColumnValue("PostalCode", value);
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
		    
		    
            public static string VendorID = @"VendorID";
            
            public static string Name = @"Name";
            
            public static string ContactType = @"ContactType";
            
            public static string Title = @"Title";
            
            public static string FirstName = @"FirstName";
            
            public static string MiddleName = @"MiddleName";
            
            public static string LastName = @"LastName";
            
            public static string Suffix = @"Suffix";
            
            public static string Phone = @"Phone";
            
            public static string EmailAddress = @"EmailAddress";
            
            public static string EmailPromotion = @"EmailPromotion";
            
            public static string AddressLine1 = @"AddressLine1";
            
            public static string AddressLine2 = @"AddressLine2";
            
            public static string City = @"City";
            
            public static string StateProvinceName = @"StateProvinceName";
            
            public static string PostalCode = @"PostalCode";
            
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
