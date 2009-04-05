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
    /// Strongly-typed collection for the VProductModelCatalogDescription class.
    /// </summary>
    [Serializable]
    public partial class VProductModelCatalogDescriptionCollection : ReadOnlyList<VProductModelCatalogDescription, VProductModelCatalogDescriptionCollection>
    {        
        public VProductModelCatalogDescriptionCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vProductModelCatalogDescription view.
    /// </summary>
    [Serializable]
    public partial class VProductModelCatalogDescription : ReadOnlyRecord<VProductModelCatalogDescription>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("vProductModelCatalogDescription", TableType.View, DataService.GetInstance("AdventureWorks"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"Production";
                //columns
                
                TableSchema.TableColumn colvarProductModelID = new TableSchema.TableColumn(schema);
                colvarProductModelID.ColumnName = "ProductModelID";
                colvarProductModelID.DataType = DbType.Int32;
                colvarProductModelID.MaxLength = 0;
                colvarProductModelID.AutoIncrement = false;
                colvarProductModelID.IsNullable = false;
                colvarProductModelID.IsPrimaryKey = false;
                colvarProductModelID.IsForeignKey = false;
                colvarProductModelID.IsReadOnly = false;
                
                schema.Columns.Add(colvarProductModelID);
                
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
                
                TableSchema.TableColumn colvarSummary = new TableSchema.TableColumn(schema);
                colvarSummary.ColumnName = "Summary";
                colvarSummary.DataType = DbType.String;
                colvarSummary.MaxLength = -1;
                colvarSummary.AutoIncrement = false;
                colvarSummary.IsNullable = true;
                colvarSummary.IsPrimaryKey = false;
                colvarSummary.IsForeignKey = false;
                colvarSummary.IsReadOnly = false;
                
                schema.Columns.Add(colvarSummary);
                
                TableSchema.TableColumn colvarManufacturer = new TableSchema.TableColumn(schema);
                colvarManufacturer.ColumnName = "Manufacturer";
                colvarManufacturer.DataType = DbType.String;
                colvarManufacturer.MaxLength = -1;
                colvarManufacturer.AutoIncrement = false;
                colvarManufacturer.IsNullable = true;
                colvarManufacturer.IsPrimaryKey = false;
                colvarManufacturer.IsForeignKey = false;
                colvarManufacturer.IsReadOnly = false;
                
                schema.Columns.Add(colvarManufacturer);
                
                TableSchema.TableColumn colvarCopyright = new TableSchema.TableColumn(schema);
                colvarCopyright.ColumnName = "Copyright";
                colvarCopyright.DataType = DbType.String;
                colvarCopyright.MaxLength = 30;
                colvarCopyright.AutoIncrement = false;
                colvarCopyright.IsNullable = true;
                colvarCopyright.IsPrimaryKey = false;
                colvarCopyright.IsForeignKey = false;
                colvarCopyright.IsReadOnly = false;
                
                schema.Columns.Add(colvarCopyright);
                
                TableSchema.TableColumn colvarProductURL = new TableSchema.TableColumn(schema);
                colvarProductURL.ColumnName = "ProductURL";
                colvarProductURL.DataType = DbType.String;
                colvarProductURL.MaxLength = 256;
                colvarProductURL.AutoIncrement = false;
                colvarProductURL.IsNullable = true;
                colvarProductURL.IsPrimaryKey = false;
                colvarProductURL.IsForeignKey = false;
                colvarProductURL.IsReadOnly = false;
                
                schema.Columns.Add(colvarProductURL);
                
                TableSchema.TableColumn colvarWarrantyPeriod = new TableSchema.TableColumn(schema);
                colvarWarrantyPeriod.ColumnName = "WarrantyPeriod";
                colvarWarrantyPeriod.DataType = DbType.String;
                colvarWarrantyPeriod.MaxLength = 256;
                colvarWarrantyPeriod.AutoIncrement = false;
                colvarWarrantyPeriod.IsNullable = true;
                colvarWarrantyPeriod.IsPrimaryKey = false;
                colvarWarrantyPeriod.IsForeignKey = false;
                colvarWarrantyPeriod.IsReadOnly = false;
                
                schema.Columns.Add(colvarWarrantyPeriod);
                
                TableSchema.TableColumn colvarWarrantyDescription = new TableSchema.TableColumn(schema);
                colvarWarrantyDescription.ColumnName = "WarrantyDescription";
                colvarWarrantyDescription.DataType = DbType.String;
                colvarWarrantyDescription.MaxLength = 256;
                colvarWarrantyDescription.AutoIncrement = false;
                colvarWarrantyDescription.IsNullable = true;
                colvarWarrantyDescription.IsPrimaryKey = false;
                colvarWarrantyDescription.IsForeignKey = false;
                colvarWarrantyDescription.IsReadOnly = false;
                
                schema.Columns.Add(colvarWarrantyDescription);
                
                TableSchema.TableColumn colvarNoOfYears = new TableSchema.TableColumn(schema);
                colvarNoOfYears.ColumnName = "NoOfYears";
                colvarNoOfYears.DataType = DbType.String;
                colvarNoOfYears.MaxLength = 256;
                colvarNoOfYears.AutoIncrement = false;
                colvarNoOfYears.IsNullable = true;
                colvarNoOfYears.IsPrimaryKey = false;
                colvarNoOfYears.IsForeignKey = false;
                colvarNoOfYears.IsReadOnly = false;
                
                schema.Columns.Add(colvarNoOfYears);
                
                TableSchema.TableColumn colvarMaintenanceDescription = new TableSchema.TableColumn(schema);
                colvarMaintenanceDescription.ColumnName = "MaintenanceDescription";
                colvarMaintenanceDescription.DataType = DbType.String;
                colvarMaintenanceDescription.MaxLength = 256;
                colvarMaintenanceDescription.AutoIncrement = false;
                colvarMaintenanceDescription.IsNullable = true;
                colvarMaintenanceDescription.IsPrimaryKey = false;
                colvarMaintenanceDescription.IsForeignKey = false;
                colvarMaintenanceDescription.IsReadOnly = false;
                
                schema.Columns.Add(colvarMaintenanceDescription);
                
                TableSchema.TableColumn colvarWheel = new TableSchema.TableColumn(schema);
                colvarWheel.ColumnName = "Wheel";
                colvarWheel.DataType = DbType.String;
                colvarWheel.MaxLength = 256;
                colvarWheel.AutoIncrement = false;
                colvarWheel.IsNullable = true;
                colvarWheel.IsPrimaryKey = false;
                colvarWheel.IsForeignKey = false;
                colvarWheel.IsReadOnly = false;
                
                schema.Columns.Add(colvarWheel);
                
                TableSchema.TableColumn colvarSaddle = new TableSchema.TableColumn(schema);
                colvarSaddle.ColumnName = "Saddle";
                colvarSaddle.DataType = DbType.String;
                colvarSaddle.MaxLength = 256;
                colvarSaddle.AutoIncrement = false;
                colvarSaddle.IsNullable = true;
                colvarSaddle.IsPrimaryKey = false;
                colvarSaddle.IsForeignKey = false;
                colvarSaddle.IsReadOnly = false;
                
                schema.Columns.Add(colvarSaddle);
                
                TableSchema.TableColumn colvarPedal = new TableSchema.TableColumn(schema);
                colvarPedal.ColumnName = "Pedal";
                colvarPedal.DataType = DbType.String;
                colvarPedal.MaxLength = 256;
                colvarPedal.AutoIncrement = false;
                colvarPedal.IsNullable = true;
                colvarPedal.IsPrimaryKey = false;
                colvarPedal.IsForeignKey = false;
                colvarPedal.IsReadOnly = false;
                
                schema.Columns.Add(colvarPedal);
                
                TableSchema.TableColumn colvarBikeFrame = new TableSchema.TableColumn(schema);
                colvarBikeFrame.ColumnName = "BikeFrame";
                colvarBikeFrame.DataType = DbType.String;
                colvarBikeFrame.MaxLength = -1;
                colvarBikeFrame.AutoIncrement = false;
                colvarBikeFrame.IsNullable = true;
                colvarBikeFrame.IsPrimaryKey = false;
                colvarBikeFrame.IsForeignKey = false;
                colvarBikeFrame.IsReadOnly = false;
                
                schema.Columns.Add(colvarBikeFrame);
                
                TableSchema.TableColumn colvarCrankset = new TableSchema.TableColumn(schema);
                colvarCrankset.ColumnName = "Crankset";
                colvarCrankset.DataType = DbType.String;
                colvarCrankset.MaxLength = 256;
                colvarCrankset.AutoIncrement = false;
                colvarCrankset.IsNullable = true;
                colvarCrankset.IsPrimaryKey = false;
                colvarCrankset.IsForeignKey = false;
                colvarCrankset.IsReadOnly = false;
                
                schema.Columns.Add(colvarCrankset);
                
                TableSchema.TableColumn colvarPictureAngle = new TableSchema.TableColumn(schema);
                colvarPictureAngle.ColumnName = "PictureAngle";
                colvarPictureAngle.DataType = DbType.String;
                colvarPictureAngle.MaxLength = 256;
                colvarPictureAngle.AutoIncrement = false;
                colvarPictureAngle.IsNullable = true;
                colvarPictureAngle.IsPrimaryKey = false;
                colvarPictureAngle.IsForeignKey = false;
                colvarPictureAngle.IsReadOnly = false;
                
                schema.Columns.Add(colvarPictureAngle);
                
                TableSchema.TableColumn colvarPictureSize = new TableSchema.TableColumn(schema);
                colvarPictureSize.ColumnName = "PictureSize";
                colvarPictureSize.DataType = DbType.String;
                colvarPictureSize.MaxLength = 256;
                colvarPictureSize.AutoIncrement = false;
                colvarPictureSize.IsNullable = true;
                colvarPictureSize.IsPrimaryKey = false;
                colvarPictureSize.IsForeignKey = false;
                colvarPictureSize.IsReadOnly = false;
                
                schema.Columns.Add(colvarPictureSize);
                
                TableSchema.TableColumn colvarProductPhotoID = new TableSchema.TableColumn(schema);
                colvarProductPhotoID.ColumnName = "ProductPhotoID";
                colvarProductPhotoID.DataType = DbType.String;
                colvarProductPhotoID.MaxLength = 256;
                colvarProductPhotoID.AutoIncrement = false;
                colvarProductPhotoID.IsNullable = true;
                colvarProductPhotoID.IsPrimaryKey = false;
                colvarProductPhotoID.IsForeignKey = false;
                colvarProductPhotoID.IsReadOnly = false;
                
                schema.Columns.Add(colvarProductPhotoID);
                
                TableSchema.TableColumn colvarMaterial = new TableSchema.TableColumn(schema);
                colvarMaterial.ColumnName = "Material";
                colvarMaterial.DataType = DbType.String;
                colvarMaterial.MaxLength = 256;
                colvarMaterial.AutoIncrement = false;
                colvarMaterial.IsNullable = true;
                colvarMaterial.IsPrimaryKey = false;
                colvarMaterial.IsForeignKey = false;
                colvarMaterial.IsReadOnly = false;
                
                schema.Columns.Add(colvarMaterial);
                
                TableSchema.TableColumn colvarColor = new TableSchema.TableColumn(schema);
                colvarColor.ColumnName = "Color";
                colvarColor.DataType = DbType.String;
                colvarColor.MaxLength = 256;
                colvarColor.AutoIncrement = false;
                colvarColor.IsNullable = true;
                colvarColor.IsPrimaryKey = false;
                colvarColor.IsForeignKey = false;
                colvarColor.IsReadOnly = false;
                
                schema.Columns.Add(colvarColor);
                
                TableSchema.TableColumn colvarProductLine = new TableSchema.TableColumn(schema);
                colvarProductLine.ColumnName = "ProductLine";
                colvarProductLine.DataType = DbType.String;
                colvarProductLine.MaxLength = 256;
                colvarProductLine.AutoIncrement = false;
                colvarProductLine.IsNullable = true;
                colvarProductLine.IsPrimaryKey = false;
                colvarProductLine.IsForeignKey = false;
                colvarProductLine.IsReadOnly = false;
                
                schema.Columns.Add(colvarProductLine);
                
                TableSchema.TableColumn colvarStyle = new TableSchema.TableColumn(schema);
                colvarStyle.ColumnName = "Style";
                colvarStyle.DataType = DbType.String;
                colvarStyle.MaxLength = 256;
                colvarStyle.AutoIncrement = false;
                colvarStyle.IsNullable = true;
                colvarStyle.IsPrimaryKey = false;
                colvarStyle.IsForeignKey = false;
                colvarStyle.IsReadOnly = false;
                
                schema.Columns.Add(colvarStyle);
                
                TableSchema.TableColumn colvarRiderExperience = new TableSchema.TableColumn(schema);
                colvarRiderExperience.ColumnName = "RiderExperience";
                colvarRiderExperience.DataType = DbType.String;
                colvarRiderExperience.MaxLength = 1024;
                colvarRiderExperience.AutoIncrement = false;
                colvarRiderExperience.IsNullable = true;
                colvarRiderExperience.IsPrimaryKey = false;
                colvarRiderExperience.IsForeignKey = false;
                colvarRiderExperience.IsReadOnly = false;
                
                schema.Columns.Add(colvarRiderExperience);
                
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
                DataService.Providers["AdventureWorks"].AddSchema("vProductModelCatalogDescription",schema);
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
	    public VProductModelCatalogDescription()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VProductModelCatalogDescription(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VProductModelCatalogDescription(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VProductModelCatalogDescription(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }
        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("ProductModelID")]
        [Bindable(true)]
        public int ProductModelID 
	    {
		    get
		    {
			    return GetColumnValue<int>("ProductModelID");
		    }
            set 
		    {
			    SetColumnValue("ProductModelID", value);
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
	      
        [XmlAttribute("Summary")]
        [Bindable(true)]
        public string Summary 
	    {
		    get
		    {
			    return GetColumnValue<string>("Summary");
		    }
            set 
		    {
			    SetColumnValue("Summary", value);
            }
        }
	      
        [XmlAttribute("Manufacturer")]
        [Bindable(true)]
        public string Manufacturer 
	    {
		    get
		    {
			    return GetColumnValue<string>("Manufacturer");
		    }
            set 
		    {
			    SetColumnValue("Manufacturer", value);
            }
        }
	      
        [XmlAttribute("Copyright")]
        [Bindable(true)]
        public string Copyright 
	    {
		    get
		    {
			    return GetColumnValue<string>("Copyright");
		    }
            set 
		    {
			    SetColumnValue("Copyright", value);
            }
        }
	      
        [XmlAttribute("ProductURL")]
        [Bindable(true)]
        public string ProductURL 
	    {
		    get
		    {
			    return GetColumnValue<string>("ProductURL");
		    }
            set 
		    {
			    SetColumnValue("ProductURL", value);
            }
        }
	      
        [XmlAttribute("WarrantyPeriod")]
        [Bindable(true)]
        public string WarrantyPeriod 
	    {
		    get
		    {
			    return GetColumnValue<string>("WarrantyPeriod");
		    }
            set 
		    {
			    SetColumnValue("WarrantyPeriod", value);
            }
        }
	      
        [XmlAttribute("WarrantyDescription")]
        [Bindable(true)]
        public string WarrantyDescription 
	    {
		    get
		    {
			    return GetColumnValue<string>("WarrantyDescription");
		    }
            set 
		    {
			    SetColumnValue("WarrantyDescription", value);
            }
        }
	      
        [XmlAttribute("NoOfYears")]
        [Bindable(true)]
        public string NoOfYears 
	    {
		    get
		    {
			    return GetColumnValue<string>("NoOfYears");
		    }
            set 
		    {
			    SetColumnValue("NoOfYears", value);
            }
        }
	      
        [XmlAttribute("MaintenanceDescription")]
        [Bindable(true)]
        public string MaintenanceDescription 
	    {
		    get
		    {
			    return GetColumnValue<string>("MaintenanceDescription");
		    }
            set 
		    {
			    SetColumnValue("MaintenanceDescription", value);
            }
        }
	      
        [XmlAttribute("Wheel")]
        [Bindable(true)]
        public string Wheel 
	    {
		    get
		    {
			    return GetColumnValue<string>("Wheel");
		    }
            set 
		    {
			    SetColumnValue("Wheel", value);
            }
        }
	      
        [XmlAttribute("Saddle")]
        [Bindable(true)]
        public string Saddle 
	    {
		    get
		    {
			    return GetColumnValue<string>("Saddle");
		    }
            set 
		    {
			    SetColumnValue("Saddle", value);
            }
        }
	      
        [XmlAttribute("Pedal")]
        [Bindable(true)]
        public string Pedal 
	    {
		    get
		    {
			    return GetColumnValue<string>("Pedal");
		    }
            set 
		    {
			    SetColumnValue("Pedal", value);
            }
        }
	      
        [XmlAttribute("BikeFrame")]
        [Bindable(true)]
        public string BikeFrame 
	    {
		    get
		    {
			    return GetColumnValue<string>("BikeFrame");
		    }
            set 
		    {
			    SetColumnValue("BikeFrame", value);
            }
        }
	      
        [XmlAttribute("Crankset")]
        [Bindable(true)]
        public string Crankset 
	    {
		    get
		    {
			    return GetColumnValue<string>("Crankset");
		    }
            set 
		    {
			    SetColumnValue("Crankset", value);
            }
        }
	      
        [XmlAttribute("PictureAngle")]
        [Bindable(true)]
        public string PictureAngle 
	    {
		    get
		    {
			    return GetColumnValue<string>("PictureAngle");
		    }
            set 
		    {
			    SetColumnValue("PictureAngle", value);
            }
        }
	      
        [XmlAttribute("PictureSize")]
        [Bindable(true)]
        public string PictureSize 
	    {
		    get
		    {
			    return GetColumnValue<string>("PictureSize");
		    }
            set 
		    {
			    SetColumnValue("PictureSize", value);
            }
        }
	      
        [XmlAttribute("ProductPhotoID")]
        [Bindable(true)]
        public string ProductPhotoID 
	    {
		    get
		    {
			    return GetColumnValue<string>("ProductPhotoID");
		    }
            set 
		    {
			    SetColumnValue("ProductPhotoID", value);
            }
        }
	      
        [XmlAttribute("Material")]
        [Bindable(true)]
        public string Material 
	    {
		    get
		    {
			    return GetColumnValue<string>("Material");
		    }
            set 
		    {
			    SetColumnValue("Material", value);
            }
        }
	      
        [XmlAttribute("Color")]
        [Bindable(true)]
        public string Color 
	    {
		    get
		    {
			    return GetColumnValue<string>("Color");
		    }
            set 
		    {
			    SetColumnValue("Color", value);
            }
        }
	      
        [XmlAttribute("ProductLine")]
        [Bindable(true)]
        public string ProductLine 
	    {
		    get
		    {
			    return GetColumnValue<string>("ProductLine");
		    }
            set 
		    {
			    SetColumnValue("ProductLine", value);
            }
        }
	      
        [XmlAttribute("Style")]
        [Bindable(true)]
        public string Style 
	    {
		    get
		    {
			    return GetColumnValue<string>("Style");
		    }
            set 
		    {
			    SetColumnValue("Style", value);
            }
        }
	      
        [XmlAttribute("RiderExperience")]
        [Bindable(true)]
        public string RiderExperience 
	    {
		    get
		    {
			    return GetColumnValue<string>("RiderExperience");
		    }
            set 
		    {
			    SetColumnValue("RiderExperience", value);
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
		    
		    
            public static string ProductModelID = @"ProductModelID";
            
            public static string Name = @"Name";
            
            public static string Summary = @"Summary";
            
            public static string Manufacturer = @"Manufacturer";
            
            public static string Copyright = @"Copyright";
            
            public static string ProductURL = @"ProductURL";
            
            public static string WarrantyPeriod = @"WarrantyPeriod";
            
            public static string WarrantyDescription = @"WarrantyDescription";
            
            public static string NoOfYears = @"NoOfYears";
            
            public static string MaintenanceDescription = @"MaintenanceDescription";
            
            public static string Wheel = @"Wheel";
            
            public static string Saddle = @"Saddle";
            
            public static string Pedal = @"Pedal";
            
            public static string BikeFrame = @"BikeFrame";
            
            public static string Crankset = @"Crankset";
            
            public static string PictureAngle = @"PictureAngle";
            
            public static string PictureSize = @"PictureSize";
            
            public static string ProductPhotoID = @"ProductPhotoID";
            
            public static string Material = @"Material";
            
            public static string Color = @"Color";
            
            public static string ProductLine = @"ProductLine";
            
            public static string Style = @"Style";
            
            public static string RiderExperience = @"RiderExperience";
            
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
