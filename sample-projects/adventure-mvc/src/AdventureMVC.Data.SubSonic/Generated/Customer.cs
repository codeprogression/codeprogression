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
	/// Strongly-typed collection for the Customer class.
	/// </summary>
    [Serializable]
	public partial class CustomerCollection : ActiveList<Customer, CustomerCollection>
	{	   
		public CustomerCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>CustomerCollection</returns>
		public CustomerCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Customer o = this[i];
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
	/// This is an ActiveRecord class which wraps the Customer table.
	/// </summary>
	[Serializable]
	public partial class Customer : ActiveRecord<Customer>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Customer()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Customer(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Customer(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Customer(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Customer", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Sales";
				//columns
				
				TableSchema.TableColumn colvarCustomerID = new TableSchema.TableColumn(schema);
				colvarCustomerID.ColumnName = "CustomerID";
				colvarCustomerID.DataType = DbType.Int32;
				colvarCustomerID.MaxLength = 0;
				colvarCustomerID.AutoIncrement = true;
				colvarCustomerID.IsNullable = false;
				colvarCustomerID.IsPrimaryKey = true;
				colvarCustomerID.IsForeignKey = false;
				colvarCustomerID.IsReadOnly = false;
				colvarCustomerID.DefaultSetting = @"";
				colvarCustomerID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCustomerID);
				
				TableSchema.TableColumn colvarTerritoryID = new TableSchema.TableColumn(schema);
				colvarTerritoryID.ColumnName = "TerritoryID";
				colvarTerritoryID.DataType = DbType.Int32;
				colvarTerritoryID.MaxLength = 0;
				colvarTerritoryID.AutoIncrement = false;
				colvarTerritoryID.IsNullable = true;
				colvarTerritoryID.IsPrimaryKey = false;
				colvarTerritoryID.IsForeignKey = true;
				colvarTerritoryID.IsReadOnly = false;
				colvarTerritoryID.DefaultSetting = @"";
				
					colvarTerritoryID.ForeignKeyTableName = "SalesTerritory";
				schema.Columns.Add(colvarTerritoryID);
				
				TableSchema.TableColumn colvarAccountNumber = new TableSchema.TableColumn(schema);
				colvarAccountNumber.ColumnName = "AccountNumber";
				colvarAccountNumber.DataType = DbType.AnsiString;
				colvarAccountNumber.MaxLength = 10;
				colvarAccountNumber.AutoIncrement = false;
				colvarAccountNumber.IsNullable = false;
				colvarAccountNumber.IsPrimaryKey = false;
				colvarAccountNumber.IsForeignKey = false;
				colvarAccountNumber.IsReadOnly = true;
				colvarAccountNumber.DefaultSetting = @"";
				colvarAccountNumber.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAccountNumber);
				
				TableSchema.TableColumn colvarCustomerType = new TableSchema.TableColumn(schema);
				colvarCustomerType.ColumnName = "CustomerType";
				colvarCustomerType.DataType = DbType.String;
				colvarCustomerType.MaxLength = 1;
				colvarCustomerType.AutoIncrement = false;
				colvarCustomerType.IsNullable = false;
				colvarCustomerType.IsPrimaryKey = false;
				colvarCustomerType.IsForeignKey = false;
				colvarCustomerType.IsReadOnly = false;
				colvarCustomerType.DefaultSetting = @"";
				colvarCustomerType.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCustomerType);
				
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
				DataService.Providers["AdventureWorks"].AddSchema("Customer",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("CustomerID")]
		[Bindable(true)]
		public int CustomerID 
		{
			get { return GetColumnValue<int>(Columns.CustomerID); }
			set { SetColumnValue(Columns.CustomerID, value); }
		}
		  
		[XmlAttribute("TerritoryID")]
		[Bindable(true)]
		public int? TerritoryID 
		{
			get { return GetColumnValue<int?>(Columns.TerritoryID); }
			set { SetColumnValue(Columns.TerritoryID, value); }
		}
		  
		[XmlAttribute("AccountNumber")]
		[Bindable(true)]
		public string AccountNumber 
		{
			get { return GetColumnValue<string>(Columns.AccountNumber); }
			set { SetColumnValue(Columns.AccountNumber, value); }
		}
		  
		[XmlAttribute("CustomerType")]
		[Bindable(true)]
		public string CustomerType 
		{
			get { return GetColumnValue<string>(Columns.CustomerType); }
			set { SetColumnValue(Columns.CustomerType, value); }
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
        
		
		public AdventureWorks.CustomerAddressCollection CustomerAddressRecords()
		{
			return new AdventureWorks.CustomerAddressCollection().Where(CustomerAddress.Columns.CustomerID, CustomerID).Load();
		}
		public AdventureWorks.IndividualCollection IndividualRecords()
		{
			return new AdventureWorks.IndividualCollection().Where(Individual.Columns.CustomerID, CustomerID).Load();
		}
		public AdventureWorks.SalesOrderHeaderCollection SalesOrderHeaderRecords()
		{
			return new AdventureWorks.SalesOrderHeaderCollection().Where(SalesOrderHeader.Columns.CustomerID, CustomerID).Load();
		}
		public AdventureWorks.StoreCollection StoreRecords()
		{
			return new AdventureWorks.StoreCollection().Where(Store.Columns.CustomerID, CustomerID).Load();
		}
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SalesTerritory ActiveRecord object related to this Customer
		/// 
		/// </summary>
		public AdventureWorks.SalesTerritory SalesTerritory
		{
			get { return AdventureWorks.SalesTerritory.FetchByID(this.TerritoryID); }
			set { SetColumnValue("TerritoryID", value.TerritoryID); }
		}
		
		
		#endregion
		
		
		
		#region Many To Many Helpers
		
		 
		public AdventureWorks.AddressCollection GetAddressCollection() { return Customer.GetAddressCollection(this.CustomerID); }
		public static AdventureWorks.AddressCollection GetAddressCollection(int varCustomerID)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [Person].[Address] INNER JOIN [CustomerAddress] ON [Address].[AddressID] = [CustomerAddress].[AddressID] WHERE [CustomerAddress].[CustomerID] = @CustomerID", Customer.Schema.Provider.Name);
			cmd.AddParameter("@CustomerID", varCustomerID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			AddressCollection coll = new AddressCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveAddressMap(int varCustomerID, AddressCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [CustomerAddress] WHERE [CustomerAddress].[CustomerID] = @CustomerID", Customer.Schema.Provider.Name);
			cmdDel.AddParameter("@CustomerID", varCustomerID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Address item in items)
			{
				CustomerAddress varCustomerAddress = new CustomerAddress();
				varCustomerAddress.SetColumnValue("CustomerID", varCustomerID);
				varCustomerAddress.SetColumnValue("AddressID", item.GetPrimaryKeyValue());
				varCustomerAddress.Save();
			}
		}
		public static void SaveAddressMap(int varCustomerID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [CustomerAddress] WHERE [CustomerAddress].[CustomerID] = @CustomerID", Customer.Schema.Provider.Name);
			cmdDel.AddParameter("@CustomerID", varCustomerID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					CustomerAddress varCustomerAddress = new CustomerAddress();
					varCustomerAddress.SetColumnValue("CustomerID", varCustomerID);
					varCustomerAddress.SetColumnValue("AddressID", l.Value);
					varCustomerAddress.Save();
				}
			}
		}
		public static void SaveAddressMap(int varCustomerID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [CustomerAddress] WHERE [CustomerAddress].[CustomerID] = @CustomerID", Customer.Schema.Provider.Name);
			cmdDel.AddParameter("@CustomerID", varCustomerID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				CustomerAddress varCustomerAddress = new CustomerAddress();
				varCustomerAddress.SetColumnValue("CustomerID", varCustomerID);
				varCustomerAddress.SetColumnValue("AddressID", item);
				varCustomerAddress.Save();
			}
		}
		
		public static void DeleteAddressMap(int varCustomerID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [CustomerAddress] WHERE [CustomerAddress].[CustomerID] = @CustomerID", Customer.Schema.Provider.Name);
			cmdDel.AddParameter("@CustomerID", varCustomerID, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		 
		public AdventureWorks.AddressTypeCollection GetAddressTypeCollection() { return Customer.GetAddressTypeCollection(this.CustomerID); }
		public static AdventureWorks.AddressTypeCollection GetAddressTypeCollection(int varCustomerID)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [Person].[AddressType] INNER JOIN [CustomerAddress] ON [AddressType].[AddressTypeID] = [CustomerAddress].[AddressTypeID] WHERE [CustomerAddress].[CustomerID] = @CustomerID", Customer.Schema.Provider.Name);
			cmd.AddParameter("@CustomerID", varCustomerID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			AddressTypeCollection coll = new AddressTypeCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveAddressTypeMap(int varCustomerID, AddressTypeCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [CustomerAddress] WHERE [CustomerAddress].[CustomerID] = @CustomerID", Customer.Schema.Provider.Name);
			cmdDel.AddParameter("@CustomerID", varCustomerID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (AddressType item in items)
			{
				CustomerAddress varCustomerAddress = new CustomerAddress();
				varCustomerAddress.SetColumnValue("CustomerID", varCustomerID);
				varCustomerAddress.SetColumnValue("AddressTypeID", item.GetPrimaryKeyValue());
				varCustomerAddress.Save();
			}
		}
		public static void SaveAddressTypeMap(int varCustomerID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [CustomerAddress] WHERE [CustomerAddress].[CustomerID] = @CustomerID", Customer.Schema.Provider.Name);
			cmdDel.AddParameter("@CustomerID", varCustomerID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					CustomerAddress varCustomerAddress = new CustomerAddress();
					varCustomerAddress.SetColumnValue("CustomerID", varCustomerID);
					varCustomerAddress.SetColumnValue("AddressTypeID", l.Value);
					varCustomerAddress.Save();
				}
			}
		}
		public static void SaveAddressTypeMap(int varCustomerID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [CustomerAddress] WHERE [CustomerAddress].[CustomerID] = @CustomerID", Customer.Schema.Provider.Name);
			cmdDel.AddParameter("@CustomerID", varCustomerID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				CustomerAddress varCustomerAddress = new CustomerAddress();
				varCustomerAddress.SetColumnValue("CustomerID", varCustomerID);
				varCustomerAddress.SetColumnValue("AddressTypeID", item);
				varCustomerAddress.Save();
			}
		}
		
		public static void DeleteAddressTypeMap(int varCustomerID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [CustomerAddress] WHERE [CustomerAddress].[CustomerID] = @CustomerID", Customer.Schema.Provider.Name);
			cmdDel.AddParameter("@CustomerID", varCustomerID, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		#endregion
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varTerritoryID,string varAccountNumber,string varCustomerType,Guid varRowguid,DateTime varModifiedDate)
		{
			Customer item = new Customer();
			
			item.TerritoryID = varTerritoryID;
			
			item.AccountNumber = varAccountNumber;
			
			item.CustomerType = varCustomerType;
			
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
		public static void Update(int varCustomerID,int? varTerritoryID,string varAccountNumber,string varCustomerType,Guid varRowguid,DateTime varModifiedDate)
		{
			Customer item = new Customer();
			
				item.CustomerID = varCustomerID;
			
				item.TerritoryID = varTerritoryID;
			
				item.AccountNumber = varAccountNumber;
			
				item.CustomerType = varCustomerType;
			
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
        
        
        public static TableSchema.TableColumn CustomerIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn TerritoryIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn AccountNumberColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn CustomerTypeColumn
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
			 public static string CustomerID = @"CustomerID";
			 public static string TerritoryID = @"TerritoryID";
			 public static string AccountNumber = @"AccountNumber";
			 public static string CustomerType = @"CustomerType";
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
