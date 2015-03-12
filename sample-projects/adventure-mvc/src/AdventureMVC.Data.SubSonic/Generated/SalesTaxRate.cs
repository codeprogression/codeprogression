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
namespace AdventureWorks
{
	/// <summary>
	/// Strongly-typed collection for the SalesTaxRate class.
	/// </summary>
    [Serializable]
	public partial class SalesTaxRateCollection : ActiveList<SalesTaxRate, SalesTaxRateCollection>
	{	   
		public SalesTaxRateCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SalesTaxRateCollection</returns>
		public SalesTaxRateCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SalesTaxRate o = this[i];
                foreach (SubSonic.Where w in this.wheres)
                {
                    bool remove = false;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case SubSonic.Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        this.Remove(o);
                        break;
                    }
                }
            }
            return this;
        }
		
		
	}
	/// <summary>
	/// This is an ActiveRecord class which wraps the SalesTaxRate table.
	/// </summary>
	[Serializable]
	public partial class SalesTaxRate : ActiveRecord<SalesTaxRate>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SalesTaxRate()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SalesTaxRate(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SalesTaxRate(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SalesTaxRate(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}
		
		protected static void SetSQLProps() { GetTableSchema(); }
		
		#endregion
		
		#region Schema and Query Accessor	
		public static Query CreateQuery() { return new Query(Schema); }
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}
		}
		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("SalesTaxRate", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Sales";
				//columns
				
				TableSchema.TableColumn colvarSalesTaxRateID = new TableSchema.TableColumn(schema);
				colvarSalesTaxRateID.ColumnName = "SalesTaxRateID";
				colvarSalesTaxRateID.DataType = DbType.Int32;
				colvarSalesTaxRateID.MaxLength = 0;
				colvarSalesTaxRateID.AutoIncrement = true;
				colvarSalesTaxRateID.IsNullable = false;
				colvarSalesTaxRateID.IsPrimaryKey = true;
				colvarSalesTaxRateID.IsForeignKey = false;
				colvarSalesTaxRateID.IsReadOnly = false;
				colvarSalesTaxRateID.DefaultSetting = @"";
				colvarSalesTaxRateID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSalesTaxRateID);
				
				TableSchema.TableColumn colvarStateProvinceID = new TableSchema.TableColumn(schema);
				colvarStateProvinceID.ColumnName = "StateProvinceID";
				colvarStateProvinceID.DataType = DbType.Int32;
				colvarStateProvinceID.MaxLength = 0;
				colvarStateProvinceID.AutoIncrement = false;
				colvarStateProvinceID.IsNullable = false;
				colvarStateProvinceID.IsPrimaryKey = false;
				colvarStateProvinceID.IsForeignKey = true;
				colvarStateProvinceID.IsReadOnly = false;
				colvarStateProvinceID.DefaultSetting = @"";
				
					colvarStateProvinceID.ForeignKeyTableName = "StateProvince";
				schema.Columns.Add(colvarStateProvinceID);
				
				TableSchema.TableColumn colvarTaxType = new TableSchema.TableColumn(schema);
				colvarTaxType.ColumnName = "TaxType";
				colvarTaxType.DataType = DbType.Byte;
				colvarTaxType.MaxLength = 0;
				colvarTaxType.AutoIncrement = false;
				colvarTaxType.IsNullable = false;
				colvarTaxType.IsPrimaryKey = false;
				colvarTaxType.IsForeignKey = false;
				colvarTaxType.IsReadOnly = false;
				colvarTaxType.DefaultSetting = @"";
				colvarTaxType.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTaxType);
				
				TableSchema.TableColumn colvarTaxRate = new TableSchema.TableColumn(schema);
				colvarTaxRate.ColumnName = "TaxRate";
				colvarTaxRate.DataType = DbType.Currency;
				colvarTaxRate.MaxLength = 0;
				colvarTaxRate.AutoIncrement = false;
				colvarTaxRate.IsNullable = false;
				colvarTaxRate.IsPrimaryKey = false;
				colvarTaxRate.IsForeignKey = false;
				colvarTaxRate.IsReadOnly = false;
				
						colvarTaxRate.DefaultSetting = @"((0.00))";
				colvarTaxRate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTaxRate);
				
				TableSchema.TableColumn colvarName = new TableSchema.TableColumn(schema);
				colvarName.ColumnName = "Name";
				colvarName.DataType = DbType.String;
				colvarName.MaxLength = 50;
				colvarName.AutoIncrement = false;
				colvarName.IsNullable = false;
				colvarName.IsPrimaryKey = false;
				colvarName.IsForeignKey = false;
				colvarName.IsReadOnly = false;
				colvarName.DefaultSetting = @"";
				colvarName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarName);
				
				TableSchema.TableColumn colvarRowguid = new TableSchema.TableColumn(schema);
				colvarRowguid.ColumnName = "rowguid";
				colvarRowguid.DataType = DbType.Guid;
				colvarRowguid.MaxLength = 0;
				colvarRowguid.AutoIncrement = false;
				colvarRowguid.IsNullable = false;
				colvarRowguid.IsPrimaryKey = false;
				colvarRowguid.IsForeignKey = false;
				colvarRowguid.IsReadOnly = false;
				
						colvarRowguid.DefaultSetting = @"(newid())";
				colvarRowguid.ForeignKeyTableName = "";
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
				
						colvarModifiedDate.DefaultSetting = @"(getdate())";
				colvarModifiedDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedDate);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["AdventureWorks"].AddSchema("SalesTaxRate",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("SalesTaxRateID")]
		[Bindable(true)]
		public int SalesTaxRateID 
		{
			get { return GetColumnValue<int>(Columns.SalesTaxRateID); }
			set { SetColumnValue(Columns.SalesTaxRateID, value); }
		}
		  
		[XmlAttribute("StateProvinceID")]
		[Bindable(true)]
		public int StateProvinceID 
		{
			get { return GetColumnValue<int>(Columns.StateProvinceID); }
			set { SetColumnValue(Columns.StateProvinceID, value); }
		}
		  
		[XmlAttribute("TaxType")]
		[Bindable(true)]
		public byte TaxType 
		{
			get { return GetColumnValue<byte>(Columns.TaxType); }
			set { SetColumnValue(Columns.TaxType, value); }
		}
		  
		[XmlAttribute("TaxRate")]
		[Bindable(true)]
		public decimal TaxRate 
		{
			get { return GetColumnValue<decimal>(Columns.TaxRate); }
			set { SetColumnValue(Columns.TaxRate, value); }
		}
		  
		[XmlAttribute("Name")]
		[Bindable(true)]
		public string Name 
		{
			get { return GetColumnValue<string>(Columns.Name); }
			set { SetColumnValue(Columns.Name, value); }
		}
		  
		[XmlAttribute("Rowguid")]
		[Bindable(true)]
		public Guid Rowguid 
		{
			get { return GetColumnValue<Guid>(Columns.Rowguid); }
			set { SetColumnValue(Columns.Rowguid, value); }
		}
		  
		[XmlAttribute("ModifiedDate")]
		[Bindable(true)]
		public DateTime ModifiedDate 
		{
			get { return GetColumnValue<DateTime>(Columns.ModifiedDate); }
			set { SetColumnValue(Columns.ModifiedDate, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a StateProvince ActiveRecord object related to this SalesTaxRate
		/// 
		/// </summary>
		public AdventureWorks.StateProvince StateProvince
		{
			get { return AdventureWorks.StateProvince.FetchByID(this.StateProvinceID); }
			set { SetColumnValue("StateProvinceID", value.StateProvinceID); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varStateProvinceID,byte varTaxType,decimal varTaxRate,string varName,Guid varRowguid,DateTime varModifiedDate)
		{
			SalesTaxRate item = new SalesTaxRate();
			
			item.StateProvinceID = varStateProvinceID;
			
			item.TaxType = varTaxType;
			
			item.TaxRate = varTaxRate;
			
			item.Name = varName;
			
			item.Rowguid = varRowguid;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varSalesTaxRateID,int varStateProvinceID,byte varTaxType,decimal varTaxRate,string varName,Guid varRowguid,DateTime varModifiedDate)
		{
			SalesTaxRate item = new SalesTaxRate();
			
				item.SalesTaxRateID = varSalesTaxRateID;
			
				item.StateProvinceID = varStateProvinceID;
			
				item.TaxType = varTaxType;
			
				item.TaxRate = varTaxRate;
			
				item.Name = varName;
			
				item.Rowguid = varRowguid;
			
				item.ModifiedDate = varModifiedDate;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn SalesTaxRateIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn StateProvinceIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn TaxTypeColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn TaxRateColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn NameColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn RowguidColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedDateColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string SalesTaxRateID = @"SalesTaxRateID";
			 public static string StateProvinceID = @"StateProvinceID";
			 public static string TaxType = @"TaxType";
			 public static string TaxRate = @"TaxRate";
			 public static string Name = @"Name";
			 public static string Rowguid = @"rowguid";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
