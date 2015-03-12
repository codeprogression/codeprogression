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
	/// Strongly-typed collection for the ShipMethod class.
	/// </summary>
    [Serializable]
	public partial class ShipMethodCollection : ActiveList<ShipMethod, ShipMethodCollection>
	{	   
		public ShipMethodCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ShipMethodCollection</returns>
		public ShipMethodCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ShipMethod o = this[i];
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
	/// This is an ActiveRecord class which wraps the ShipMethod table.
	/// </summary>
	[Serializable]
	public partial class ShipMethod : ActiveRecord<ShipMethod>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ShipMethod()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ShipMethod(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ShipMethod(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ShipMethod(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ShipMethod", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Purchasing";
				//columns
				
				TableSchema.TableColumn colvarShipMethodID = new TableSchema.TableColumn(schema);
				colvarShipMethodID.ColumnName = "ShipMethodID";
				colvarShipMethodID.DataType = DbType.Int32;
				colvarShipMethodID.MaxLength = 0;
				colvarShipMethodID.AutoIncrement = true;
				colvarShipMethodID.IsNullable = false;
				colvarShipMethodID.IsPrimaryKey = true;
				colvarShipMethodID.IsForeignKey = false;
				colvarShipMethodID.IsReadOnly = false;
				colvarShipMethodID.DefaultSetting = @"";
				colvarShipMethodID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarShipMethodID);
				
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
				
				TableSchema.TableColumn colvarShipBase = new TableSchema.TableColumn(schema);
				colvarShipBase.ColumnName = "ShipBase";
				colvarShipBase.DataType = DbType.Currency;
				colvarShipBase.MaxLength = 0;
				colvarShipBase.AutoIncrement = false;
				colvarShipBase.IsNullable = false;
				colvarShipBase.IsPrimaryKey = false;
				colvarShipBase.IsForeignKey = false;
				colvarShipBase.IsReadOnly = false;
				
						colvarShipBase.DefaultSetting = @"((0.00))";
				colvarShipBase.ForeignKeyTableName = "";
				schema.Columns.Add(colvarShipBase);
				
				TableSchema.TableColumn colvarShipRate = new TableSchema.TableColumn(schema);
				colvarShipRate.ColumnName = "ShipRate";
				colvarShipRate.DataType = DbType.Currency;
				colvarShipRate.MaxLength = 0;
				colvarShipRate.AutoIncrement = false;
				colvarShipRate.IsNullable = false;
				colvarShipRate.IsPrimaryKey = false;
				colvarShipRate.IsForeignKey = false;
				colvarShipRate.IsReadOnly = false;
				
						colvarShipRate.DefaultSetting = @"((0.00))";
				colvarShipRate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarShipRate);
				
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
				DataService.Providers["AdventureWorks"].AddSchema("ShipMethod",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("ShipMethodID")]
		[Bindable(true)]
		public int ShipMethodID 
		{
			get { return GetColumnValue<int>(Columns.ShipMethodID); }
			set { SetColumnValue(Columns.ShipMethodID, value); }
		}
		  
		[XmlAttribute("Name")]
		[Bindable(true)]
		public string Name 
		{
			get { return GetColumnValue<string>(Columns.Name); }
			set { SetColumnValue(Columns.Name, value); }
		}
		  
		[XmlAttribute("ShipBase")]
		[Bindable(true)]
		public decimal ShipBase 
		{
			get { return GetColumnValue<decimal>(Columns.ShipBase); }
			set { SetColumnValue(Columns.ShipBase, value); }
		}
		  
		[XmlAttribute("ShipRate")]
		[Bindable(true)]
		public decimal ShipRate 
		{
			get { return GetColumnValue<decimal>(Columns.ShipRate); }
			set { SetColumnValue(Columns.ShipRate, value); }
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
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
		
		public AdventureWorks.PurchaseOrderHeaderCollection PurchaseOrderHeaderRecords()
		{
			return new AdventureWorks.PurchaseOrderHeaderCollection().Where(PurchaseOrderHeader.Columns.ShipMethodID, ShipMethodID).Load();
		}
		public AdventureWorks.SalesOrderHeaderCollection SalesOrderHeaderRecords()
		{
			return new AdventureWorks.SalesOrderHeaderCollection().Where(SalesOrderHeader.Columns.ShipMethodID, ShipMethodID).Load();
		}
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varName,decimal varShipBase,decimal varShipRate,Guid varRowguid,DateTime varModifiedDate)
		{
			ShipMethod item = new ShipMethod();
			
			item.Name = varName;
			
			item.ShipBase = varShipBase;
			
			item.ShipRate = varShipRate;
			
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
		public static void Update(int varShipMethodID,string varName,decimal varShipBase,decimal varShipRate,Guid varRowguid,DateTime varModifiedDate)
		{
			ShipMethod item = new ShipMethod();
			
				item.ShipMethodID = varShipMethodID;
			
				item.Name = varName;
			
				item.ShipBase = varShipBase;
			
				item.ShipRate = varShipRate;
			
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
        
        
        public static TableSchema.TableColumn ShipMethodIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NameColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ShipBaseColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ShipRateColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn RowguidColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedDateColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string ShipMethodID = @"ShipMethodID";
			 public static string Name = @"Name";
			 public static string ShipBase = @"ShipBase";
			 public static string ShipRate = @"ShipRate";
			 public static string Rowguid = @"rowguid";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
}
        #endregion
	}
}
