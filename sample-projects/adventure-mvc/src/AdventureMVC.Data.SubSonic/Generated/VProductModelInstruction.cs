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
    /// Strongly-typed collection for the VProductModelInstruction class.
    /// </summary>
    [Serializable]
    public partial class VProductModelInstructionCollection : ReadOnlyList<VProductModelInstruction, VProductModelInstructionCollection>
    {        
        public VProductModelInstructionCollection() {}
    }
    /// <summary>
    /// This is  Read-only wrapper class for the vProductModelInstructions view.
    /// </summary>
    [Serializable]
    public partial class VProductModelInstruction : ReadOnlyRecord<VProductModelInstruction>, IReadOnlyRecord
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
                TableSchema.Table schema = new TableSchema.Table("vProductModelInstructions", TableType.View, DataService.GetInstance("AdventureWorks"));
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
                
                TableSchema.TableColumn colvarInstructions = new TableSchema.TableColumn(schema);
                colvarInstructions.ColumnName = "Instructions";
                colvarInstructions.DataType = DbType.String;
                colvarInstructions.MaxLength = -1;
                colvarInstructions.AutoIncrement = false;
                colvarInstructions.IsNullable = true;
                colvarInstructions.IsPrimaryKey = false;
                colvarInstructions.IsForeignKey = false;
                colvarInstructions.IsReadOnly = false;
                
                schema.Columns.Add(colvarInstructions);
                
                TableSchema.TableColumn colvarLocationID = new TableSchema.TableColumn(schema);
                colvarLocationID.ColumnName = "LocationID";
                colvarLocationID.DataType = DbType.Int32;
                colvarLocationID.MaxLength = 0;
                colvarLocationID.AutoIncrement = false;
                colvarLocationID.IsNullable = true;
                colvarLocationID.IsPrimaryKey = false;
                colvarLocationID.IsForeignKey = false;
                colvarLocationID.IsReadOnly = false;
                
                schema.Columns.Add(colvarLocationID);
                
                TableSchema.TableColumn colvarSetupHours = new TableSchema.TableColumn(schema);
                colvarSetupHours.ColumnName = "SetupHours";
                colvarSetupHours.DataType = DbType.Decimal;
                colvarSetupHours.MaxLength = 0;
                colvarSetupHours.AutoIncrement = false;
                colvarSetupHours.IsNullable = true;
                colvarSetupHours.IsPrimaryKey = false;
                colvarSetupHours.IsForeignKey = false;
                colvarSetupHours.IsReadOnly = false;
                
                schema.Columns.Add(colvarSetupHours);
                
                TableSchema.TableColumn colvarMachineHours = new TableSchema.TableColumn(schema);
                colvarMachineHours.ColumnName = "MachineHours";
                colvarMachineHours.DataType = DbType.Decimal;
                colvarMachineHours.MaxLength = 0;
                colvarMachineHours.AutoIncrement = false;
                colvarMachineHours.IsNullable = true;
                colvarMachineHours.IsPrimaryKey = false;
                colvarMachineHours.IsForeignKey = false;
                colvarMachineHours.IsReadOnly = false;
                
                schema.Columns.Add(colvarMachineHours);
                
                TableSchema.TableColumn colvarLaborHours = new TableSchema.TableColumn(schema);
                colvarLaborHours.ColumnName = "LaborHours";
                colvarLaborHours.DataType = DbType.Decimal;
                colvarLaborHours.MaxLength = 0;
                colvarLaborHours.AutoIncrement = false;
                colvarLaborHours.IsNullable = true;
                colvarLaborHours.IsPrimaryKey = false;
                colvarLaborHours.IsForeignKey = false;
                colvarLaborHours.IsReadOnly = false;
                
                schema.Columns.Add(colvarLaborHours);
                
                TableSchema.TableColumn colvarLotSize = new TableSchema.TableColumn(schema);
                colvarLotSize.ColumnName = "LotSize";
                colvarLotSize.DataType = DbType.Int32;
                colvarLotSize.MaxLength = 0;
                colvarLotSize.AutoIncrement = false;
                colvarLotSize.IsNullable = true;
                colvarLotSize.IsPrimaryKey = false;
                colvarLotSize.IsForeignKey = false;
                colvarLotSize.IsReadOnly = false;
                
                schema.Columns.Add(colvarLotSize);
                
                TableSchema.TableColumn colvarStepX = new TableSchema.TableColumn(schema);
                colvarStepX.ColumnName = "Step";
                colvarStepX.DataType = DbType.String;
                colvarStepX.MaxLength = 1024;
                colvarStepX.AutoIncrement = false;
                colvarStepX.IsNullable = true;
                colvarStepX.IsPrimaryKey = false;
                colvarStepX.IsForeignKey = false;
                colvarStepX.IsReadOnly = false;
                
                schema.Columns.Add(colvarStepX);
                
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
                DataService.Providers["AdventureWorks"].AddSchema("vProductModelInstructions",schema);
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
	    public VProductModelInstruction()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }
        public VProductModelInstruction(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}
			MarkNew();
	    }
	    
	    public VProductModelInstruction(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }
    	 
	    public VProductModelInstruction(string columnName, object columnValue)
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
	      
        [XmlAttribute("Instructions")]
        [Bindable(true)]
        public string Instructions 
	    {
		    get
		    {
			    return GetColumnValue<string>("Instructions");
		    }
            set 
		    {
			    SetColumnValue("Instructions", value);
            }
        }
	      
        [XmlAttribute("LocationID")]
        [Bindable(true)]
        public int? LocationID 
	    {
		    get
		    {
			    return GetColumnValue<int?>("LocationID");
		    }
            set 
		    {
			    SetColumnValue("LocationID", value);
            }
        }
	      
        [XmlAttribute("SetupHours")]
        [Bindable(true)]
        public decimal? SetupHours 
	    {
		    get
		    {
			    return GetColumnValue<decimal?>("SetupHours");
		    }
            set 
		    {
			    SetColumnValue("SetupHours", value);
            }
        }
	      
        [XmlAttribute("MachineHours")]
        [Bindable(true)]
        public decimal? MachineHours 
	    {
		    get
		    {
			    return GetColumnValue<decimal?>("MachineHours");
		    }
            set 
		    {
			    SetColumnValue("MachineHours", value);
            }
        }
	      
        [XmlAttribute("LaborHours")]
        [Bindable(true)]
        public decimal? LaborHours 
	    {
		    get
		    {
			    return GetColumnValue<decimal?>("LaborHours");
		    }
            set 
		    {
			    SetColumnValue("LaborHours", value);
            }
        }
	      
        [XmlAttribute("LotSize")]
        [Bindable(true)]
        public int? LotSize 
	    {
		    get
		    {
			    return GetColumnValue<int?>("LotSize");
		    }
            set 
		    {
			    SetColumnValue("LotSize", value);
            }
        }
	      
        [XmlAttribute("StepX")]
        [Bindable(true)]
        public string StepX 
	    {
		    get
		    {
			    return GetColumnValue<string>("Step");
		    }
            set 
		    {
			    SetColumnValue("Step", value);
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
            
            public static string Instructions = @"Instructions";
            
            public static string LocationID = @"LocationID";
            
            public static string SetupHours = @"SetupHours";
            
            public static string MachineHours = @"MachineHours";
            
            public static string LaborHours = @"LaborHours";
            
            public static string LotSize = @"LotSize";
            
            public static string StepX = @"Step";
            
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
