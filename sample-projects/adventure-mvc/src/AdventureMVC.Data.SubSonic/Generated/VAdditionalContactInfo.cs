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
    /// Strongly-typed collection for the VAdditionalContactInfo class.
    /// </summary>
    [Serializable]
    public partial class VAdditionalContactInfoCollection : ReadOnlyList<VAdditionalContactInfo, VAdditionalContactInfoCollection>
    {        
        public VAdditionalContactInfoCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vAdditionalContactInfo view.
    /// </summary>
    [Serializable]
    public partial class VAdditionalContactInfo : ReadOnlyRecord<VAdditionalContactInfo>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("vAdditionalContactInfo", TableType.View, DataService.GetInstance("AdventureWorks"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"Person";
                //columns
                
                TableSchema.TableColumn colvarContactID = new TableSchema.TableColumn(schema);
                colvarContactID.ColumnName = "ContactID";
                colvarContactID.DataType = DbType.Int32;
                colvarContactID.MaxLength = 0;
                colvarContactID.AutoIncrement = false;
                colvarContactID.IsNullable = false;
                colvarContactID.IsPrimaryKey = false;
                colvarContactID.IsForeignKey = false;
                colvarContactID.IsReadOnly = false;
                
                schema.Columns.Add(colvarContactID);
                
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
                
                TableSchema.TableColumn colvarTelephoneNumber = new TableSchema.TableColumn(schema);
                colvarTelephoneNumber.ColumnName = "TelephoneNumber";
                colvarTelephoneNumber.DataType = DbType.String;
                colvarTelephoneNumber.MaxLength = 50;
                colvarTelephoneNumber.AutoIncrement = false;
                colvarTelephoneNumber.IsNullable = true;
                colvarTelephoneNumber.IsPrimaryKey = false;
                colvarTelephoneNumber.IsForeignKey = false;
                colvarTelephoneNumber.IsReadOnly = false;
                
                schema.Columns.Add(colvarTelephoneNumber);
                
                TableSchema.TableColumn colvarTelephoneSpecialInstructions = new TableSchema.TableColumn(schema);
                colvarTelephoneSpecialInstructions.ColumnName = "TelephoneSpecialInstructions";
                colvarTelephoneSpecialInstructions.DataType = DbType.String;
                colvarTelephoneSpecialInstructions.MaxLength = -1;
                colvarTelephoneSpecialInstructions.AutoIncrement = false;
                colvarTelephoneSpecialInstructions.IsNullable = true;
                colvarTelephoneSpecialInstructions.IsPrimaryKey = false;
                colvarTelephoneSpecialInstructions.IsForeignKey = false;
                colvarTelephoneSpecialInstructions.IsReadOnly = false;
                
                schema.Columns.Add(colvarTelephoneSpecialInstructions);
                
                TableSchema.TableColumn colvarStreet = new TableSchema.TableColumn(schema);
                colvarStreet.ColumnName = "Street";
                colvarStreet.DataType = DbType.String;
                colvarStreet.MaxLength = 50;
                colvarStreet.AutoIncrement = false;
                colvarStreet.IsNullable = true;
                colvarStreet.IsPrimaryKey = false;
                colvarStreet.IsForeignKey = false;
                colvarStreet.IsReadOnly = false;
                
                schema.Columns.Add(colvarStreet);
                
                TableSchema.TableColumn colvarCity = new TableSchema.TableColumn(schema);
                colvarCity.ColumnName = "City";
                colvarCity.DataType = DbType.String;
                colvarCity.MaxLength = 50;
                colvarCity.AutoIncrement = false;
                colvarCity.IsNullable = true;
                colvarCity.IsPrimaryKey = false;
                colvarCity.IsForeignKey = false;
                colvarCity.IsReadOnly = false;
                
                schema.Columns.Add(colvarCity);
                
                TableSchema.TableColumn colvarStateProvince = new TableSchema.TableColumn(schema);
                colvarStateProvince.ColumnName = "StateProvince";
                colvarStateProvince.DataType = DbType.String;
                colvarStateProvince.MaxLength = 50;
                colvarStateProvince.AutoIncrement = false;
                colvarStateProvince.IsNullable = true;
                colvarStateProvince.IsPrimaryKey = false;
                colvarStateProvince.IsForeignKey = false;
                colvarStateProvince.IsReadOnly = false;
                
                schema.Columns.Add(colvarStateProvince);
                
                TableSchema.TableColumn colvarPostalCode = new TableSchema.TableColumn(schema);
                colvarPostalCode.ColumnName = "PostalCode";
                colvarPostalCode.DataType = DbType.String;
                colvarPostalCode.MaxLength = 50;
                colvarPostalCode.AutoIncrement = false;
                colvarPostalCode.IsNullable = true;
                colvarPostalCode.IsPrimaryKey = false;
                colvarPostalCode.IsForeignKey = false;
                colvarPostalCode.IsReadOnly = false;
                
                schema.Columns.Add(colvarPostalCode);
                
                TableSchema.TableColumn colvarCountryRegion = new TableSchema.TableColumn(schema);
                colvarCountryRegion.ColumnName = "CountryRegion";
                colvarCountryRegion.DataType = DbType.String;
                colvarCountryRegion.MaxLength = 50;
                colvarCountryRegion.AutoIncrement = false;
                colvarCountryRegion.IsNullable = true;
                colvarCountryRegion.IsPrimaryKey = false;
                colvarCountryRegion.IsForeignKey = false;
                colvarCountryRegion.IsReadOnly = false;
                
                schema.Columns.Add(colvarCountryRegion);
                
                TableSchema.TableColumn colvarHomeAddressSpecialInstructions = new TableSchema.TableColumn(schema);
                colvarHomeAddressSpecialInstructions.ColumnName = "HomeAddressSpecialInstructions";
                colvarHomeAddressSpecialInstructions.DataType = DbType.String;
                colvarHomeAddressSpecialInstructions.MaxLength = -1;
                colvarHomeAddressSpecialInstructions.AutoIncrement = false;
                colvarHomeAddressSpecialInstructions.IsNullable = true;
                colvarHomeAddressSpecialInstructions.IsPrimaryKey = false;
                colvarHomeAddressSpecialInstructions.IsForeignKey = false;
                colvarHomeAddressSpecialInstructions.IsReadOnly = false;
                
                schema.Columns.Add(colvarHomeAddressSpecialInstructions);
                
                TableSchema.TableColumn colvarEMailAddress = new TableSchema.TableColumn(schema);
                colvarEMailAddress.ColumnName = "EMailAddress";
                colvarEMailAddress.DataType = DbType.String;
                colvarEMailAddress.MaxLength = 128;
                colvarEMailAddress.AutoIncrement = false;
                colvarEMailAddress.IsNullable = true;
                colvarEMailAddress.IsPrimaryKey = false;
                colvarEMailAddress.IsForeignKey = false;
                colvarEMailAddress.IsReadOnly = false;
                
                schema.Columns.Add(colvarEMailAddress);
                
                TableSchema.TableColumn colvarEMailSpecialInstructions = new TableSchema.TableColumn(schema);
                colvarEMailSpecialInstructions.ColumnName = "EMailSpecialInstructions";
                colvarEMailSpecialInstructions.DataType = DbType.String;
                colvarEMailSpecialInstructions.MaxLength = -1;
                colvarEMailSpecialInstructions.AutoIncrement = false;
                colvarEMailSpecialInstructions.IsNullable = true;
                colvarEMailSpecialInstructions.IsPrimaryKey = false;
                colvarEMailSpecialInstructions.IsForeignKey = false;
                colvarEMailSpecialInstructions.IsReadOnly = false;
                
                schema.Columns.Add(colvarEMailSpecialInstructions);
                
                TableSchema.TableColumn colvarEMailTelephoneNumber = new TableSchema.TableColumn(schema);
                colvarEMailTelephoneNumber.ColumnName = "EMailTelephoneNumber";
                colvarEMailTelephoneNumber.DataType = DbType.String;
                colvarEMailTelephoneNumber.MaxLength = 50;
                colvarEMailTelephoneNumber.AutoIncrement = false;
                colvarEMailTelephoneNumber.IsNullable = true;
                colvarEMailTelephoneNumber.IsPrimaryKey = false;
                colvarEMailTelephoneNumber.IsForeignKey = false;
                colvarEMailTelephoneNumber.IsReadOnly = false;
                
                schema.Columns.Add(colvarEMailTelephoneNumber);
                
                TableSchema.TableColumn colvarRowguid = new TableSchema.TableColumn(schema);
                colvarRowguid.ColumnName = "rowguid";
                colvarRowguid.DataType = DbType.Guid;
                colvarRowguid.MaxLength = 0;
                colvarRowguid.AutoIncrement = false;
                colvarRowguid.IsNullable = false;
                colvarRowguid.IsPrimaryKey = false;
                colvarRowguid.IsForeignKey = false;
                colvarRowguid.IsReadOnly = false;
                
                schema.Columns.Add(colvarRowguid);
                
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
                DataService.Providers["AdventureWorks"].AddSchema("vAdditionalContactInfo",schema);
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
	    public VAdditionalContactInfo()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VAdditionalContactInfo(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VAdditionalContactInfo(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VAdditionalContactInfo(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("ContactID")]
        [Bindable(true)]
        public int ContactID 
	    {
		    get
		    {
			    return GetColumnValue<int>("ContactID");
		    }
            set 
		    {
			    SetColumnValue("ContactID", value);
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
	      
        [XmlAttribute("TelephoneNumber")]
        [Bindable(true)]
        public string TelephoneNumber 
	    {
		    get
		    {
			    return GetColumnValue<string>("TelephoneNumber");
		    }
            set 
		    {
			    SetColumnValue("TelephoneNumber", value);
            }
        }
	      
        [XmlAttribute("TelephoneSpecialInstructions")]
        [Bindable(true)]
        public string TelephoneSpecialInstructions 
	    {
		    get
		    {
			    return GetColumnValue<string>("TelephoneSpecialInstructions");
		    }
            set 
		    {
			    SetColumnValue("TelephoneSpecialInstructions", value);
            }
        }
	      
        [XmlAttribute("Street")]
        [Bindable(true)]
        public string Street 
	    {
		    get
		    {
			    return GetColumnValue<string>("Street");
		    }
            set 
		    {
			    SetColumnValue("Street", value);
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
	      
        [XmlAttribute("StateProvince")]
        [Bindable(true)]
        public string StateProvince 
	    {
		    get
		    {
			    return GetColumnValue<string>("StateProvince");
		    }
            set 
		    {
			    SetColumnValue("StateProvince", value);
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
	      
        [XmlAttribute("CountryRegion")]
        [Bindable(true)]
        public string CountryRegion 
	    {
		    get
		    {
			    return GetColumnValue<string>("CountryRegion");
		    }
            set 
		    {
			    SetColumnValue("CountryRegion", value);
            }
        }
	      
        [XmlAttribute("HomeAddressSpecialInstructions")]
        [Bindable(true)]
        public string HomeAddressSpecialInstructions 
	    {
		    get
		    {
			    return GetColumnValue<string>("HomeAddressSpecialInstructions");
		    }
            set 
		    {
			    SetColumnValue("HomeAddressSpecialInstructions", value);
            }
        }
	      
        [XmlAttribute("EMailAddress")]
        [Bindable(true)]
        public string EMailAddress 
	    {
		    get
		    {
			    return GetColumnValue<string>("EMailAddress");
		    }
            set 
		    {
			    SetColumnValue("EMailAddress", value);
            }
        }
	      
        [XmlAttribute("EMailSpecialInstructions")]
        [Bindable(true)]
        public string EMailSpecialInstructions 
	    {
		    get
		    {
			    return GetColumnValue<string>("EMailSpecialInstructions");
		    }
            set 
		    {
			    SetColumnValue("EMailSpecialInstructions", value);
            }
        }
	      
        [XmlAttribute("EMailTelephoneNumber")]
        [Bindable(true)]
        public string EMailTelephoneNumber 
	    {
		    get
		    {
			    return GetColumnValue<string>("EMailTelephoneNumber");
		    }
            set 
		    {
			    SetColumnValue("EMailTelephoneNumber", value);
            }
        }
	      
        [XmlAttribute("Rowguid")]
        [Bindable(true)]
        public Guid Rowguid 
	    {
		    get
		    {
			    return GetColumnValue<Guid>("rowguid");
		    }
            set 
		    {
			    SetColumnValue("rowguid", value);
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
		    
		    
            public static string ContactID = @"ContactID";
            
            public static string FirstName = @"FirstName";
            
            public static string MiddleName = @"MiddleName";
            
            public static string LastName = @"LastName";
            
            public static string TelephoneNumber = @"TelephoneNumber";
            
            public static string TelephoneSpecialInstructions = @"TelephoneSpecialInstructions";
            
            public static string Street = @"Street";
            
            public static string City = @"City";
            
            public static string StateProvince = @"StateProvince";
            
            public static string PostalCode = @"PostalCode";
            
            public static string CountryRegion = @"CountryRegion";
            
            public static string HomeAddressSpecialInstructions = @"HomeAddressSpecialInstructions";
            
            public static string EMailAddress = @"EMailAddress";
            
            public static string EMailSpecialInstructions = @"EMailSpecialInstructions";
            
            public static string EMailTelephoneNumber = @"EMailTelephoneNumber";
            
            public static string Rowguid = @"rowguid";
            
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
