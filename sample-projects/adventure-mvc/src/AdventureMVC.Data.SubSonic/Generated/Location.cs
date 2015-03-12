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
	/// Strongly-typed collection for the Location class.
	/// </summary>
    [Serializable]
	public partial class LocationCollection : ActiveList<Location, LocationCollection>
	{	   
		public LocationCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>LocationCollection</returns>
		public LocationCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Location o = this[i];
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
	/// This is an ActiveRecord class which wraps the Location table.
	/// </summary>
	[Serializable]
	public partial class Location : ActiveRecord<Location>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Location()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Location(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Location(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Location(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Location", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Production";
				//columns
				
				TableSchema.TableColumn colvarLocationID = new TableSchema.TableColumn(schema);
				colvarLocationID.ColumnName = "LocationID";
				colvarLocationID.DataType = DbType.Int16;
				colvarLocationID.MaxLength = 0;
				colvarLocationID.AutoIncrement = true;
				colvarLocationID.IsNullable = false;
				colvarLocationID.IsPrimaryKey = true;
				colvarLocationID.IsForeignKey = false;
				colvarLocationID.IsReadOnly = false;
				colvarLocationID.DefaultSetting = @"";
				colvarLocationID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLocationID);
				
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
				
				TableSchema.TableColumn colvarCostRate = new TableSchema.TableColumn(schema);
				colvarCostRate.ColumnName = "CostRate";
				colvarCostRate.DataType = DbType.Currency;
				colvarCostRate.MaxLength = 0;
				colvarCostRate.AutoIncrement = false;
				colvarCostRate.IsNullable = false;
				colvarCostRate.IsPrimaryKey = false;
				colvarCostRate.IsForeignKey = false;
				colvarCostRate.IsReadOnly = false;
				
						colvarCostRate.DefaultSetting = @"((0.00))";
				colvarCostRate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCostRate);
				
				TableSchema.TableColumn colvarAvailability = new TableSchema.TableColumn(schema);
				colvarAvailability.ColumnName = "Availability";
				colvarAvailability.DataType = DbType.Decimal;
				colvarAvailability.MaxLength = 0;
				colvarAvailability.AutoIncrement = false;
				colvarAvailability.IsNullable = false;
				colvarAvailability.IsPrimaryKey = false;
				colvarAvailability.IsForeignKey = false;
				colvarAvailability.IsReadOnly = false;
				
						colvarAvailability.DefaultSetting = @"((0.00))";
				colvarAvailability.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAvailability);
				
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
				DataService.Providers["AdventureWorks"].AddSchema("Location",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("LocationID")]
		[Bindable(true)]
		public short LocationID 
		{
			get { return GetColumnValue<short>(Columns.LocationID); }
			set { SetColumnValue(Columns.LocationID, value); }
		}
		  
		[XmlAttribute("Name")]
		[Bindable(true)]
		public string Name 
		{
			get { return GetColumnValue<string>(Columns.Name); }
			set { SetColumnValue(Columns.Name, value); }
		}
		  
		[XmlAttribute("CostRate")]
		[Bindable(true)]
		public decimal CostRate 
		{
			get { return GetColumnValue<decimal>(Columns.CostRate); }
			set { SetColumnValue(Columns.CostRate, value); }
		}
		  
		[XmlAttribute("Availability")]
		[Bindable(true)]
		public decimal Availability 
		{
			get { return GetColumnValue<decimal>(Columns.Availability); }
			set { SetColumnValue(Columns.Availability, value); }
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
        
		
		public AdventureWorks.ProductInventoryCollection ProductInventoryRecords()
		{
			return new AdventureWorks.ProductInventoryCollection().Where(ProductInventory.Columns.LocationID, LocationID).Load();
		}
		public AdventureWorks.WorkOrderRoutingCollection WorkOrderRoutingRecords()
		{
			return new AdventureWorks.WorkOrderRoutingCollection().Where(WorkOrderRouting.Columns.LocationID, LocationID).Load();
		}
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		#region Many To Many Helpers
		
		 
		public AdventureWorks.ProductCollection GetProductCollection() { return Location.GetProductCollection(this.LocationID); }
		public static AdventureWorks.ProductCollection GetProductCollection(short varLocationID)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [Production].[Product] INNER JOIN [ProductInventory] ON [Product].[ProductID] = [ProductInventory].[ProductID] WHERE [ProductInventory].[LocationID] = @LocationID", Location.Schema.Provider.Name);
			cmd.AddParameter("@LocationID", varLocationID, DbType.Int16);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			ProductCollection coll = new ProductCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveProductMap(short varLocationID, ProductCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductInventory] WHERE [ProductInventory].[LocationID] = @LocationID", Location.Schema.Provider.Name);
			cmdDel.AddParameter("@LocationID", varLocationID, DbType.Int16);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Product item in items)
			{
				ProductInventory varProductInventory = new ProductInventory();
				varProductInventory.SetColumnValue("LocationID", varLocationID);
				varProductInventory.SetColumnValue("ProductID", item.GetPrimaryKeyValue());
				varProductInventory.Save();
			}
		}
		public static void SaveProductMap(short varLocationID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductInventory] WHERE [ProductInventory].[LocationID] = @LocationID", Location.Schema.Provider.Name);
			cmdDel.AddParameter("@LocationID", varLocationID, DbType.Int16);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					ProductInventory varProductInventory = new ProductInventory();
					varProductInventory.SetColumnValue("LocationID", varLocationID);
					varProductInventory.SetColumnValue("ProductID", l.Value);
					varProductInventory.Save();
				}
			}
		}
		public static void SaveProductMap(short varLocationID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductInventory] WHERE [ProductInventory].[LocationID] = @LocationID", Location.Schema.Provider.Name);
			cmdDel.AddParameter("@LocationID", varLocationID, DbType.Int16);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				ProductInventory varProductInventory = new ProductInventory();
				varProductInventory.SetColumnValue("LocationID", varLocationID);
				varProductInventory.SetColumnValue("ProductID", item);
				varProductInventory.Save();
			}
		}
		
		public static void DeleteProductMap(short varLocationID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductInventory] WHERE [ProductInventory].[LocationID] = @LocationID", Location.Schema.Provider.Name);
			cmdDel.AddParameter("@LocationID", varLocationID, DbType.Int16);
			DataService.ExecuteQuery(cmdDel);
		}
		
		#endregion
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varName,decimal varCostRate,decimal varAvailability,DateTime varModifiedDate)
		{
			Location item = new Location();
			
			item.Name = varName;
			
			item.CostRate = varCostRate;
			
			item.Availability = varAvailability;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(short varLocationID,string varName,decimal varCostRate,decimal varAvailability,DateTime varModifiedDate)
		{
			Location item = new Location();
			
				item.LocationID = varLocationID;
			
				item.Name = varName;
			
				item.CostRate = varCostRate;
			
				item.Availability = varAvailability;
			
				item.ModifiedDate = varModifiedDate;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn LocationIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NameColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn CostRateColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn AvailabilityColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedDateColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string LocationID = @"LocationID";
			 public static string Name = @"Name";
			 public static string CostRate = @"CostRate";
			 public static string Availability = @"Availability";
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
