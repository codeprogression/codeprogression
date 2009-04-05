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
	/// Strongly-typed collection for the Address class.
	/// </summary>
    [Serializable]
	public partial class AddressCollection : ActiveList<Address, AddressCollection>
	{	   
		public AddressCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>AddressCollection</returns>
		public AddressCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Address o = this[i];
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
	/// This is an ActiveRecord class which wraps the Address table.
	/// </summary>
	[Serializable]
	public partial class Address : ActiveRecord<Address>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Address()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Address(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Address(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Address(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Address", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Person";
				//columns
				
				TableSchema.TableColumn colvarAddressID = new TableSchema.TableColumn(schema);
				colvarAddressID.ColumnName = "AddressID";
				colvarAddressID.DataType = DbType.Int32;
				colvarAddressID.MaxLength = 0;
				colvarAddressID.AutoIncrement = true;
				colvarAddressID.IsNullable = false;
				colvarAddressID.IsPrimaryKey = true;
				colvarAddressID.IsForeignKey = false;
				colvarAddressID.IsReadOnly = false;
				colvarAddressID.DefaultSetting = @"";
				colvarAddressID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAddressID);
				
				TableSchema.TableColumn colvarAddressLine1 = new TableSchema.TableColumn(schema);
				colvarAddressLine1.ColumnName = "AddressLine1";
				colvarAddressLine1.DataType = DbType.String;
				colvarAddressLine1.MaxLength = 60;
				colvarAddressLine1.AutoIncrement = false;
				colvarAddressLine1.IsNullable = false;
				colvarAddressLine1.IsPrimaryKey = false;
				colvarAddressLine1.IsForeignKey = false;
				colvarAddressLine1.IsReadOnly = false;
				colvarAddressLine1.DefaultSetting = @"";
				colvarAddressLine1.ForeignKeyTableName = "";
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
				colvarAddressLine2.DefaultSetting = @"";
				colvarAddressLine2.ForeignKeyTableName = "";
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
				colvarCity.DefaultSetting = @"";
				colvarCity.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCity);
				
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
				
				TableSchema.TableColumn colvarPostalCode = new TableSchema.TableColumn(schema);
				colvarPostalCode.ColumnName = "PostalCode";
				colvarPostalCode.DataType = DbType.String;
				colvarPostalCode.MaxLength = 15;
				colvarPostalCode.AutoIncrement = false;
				colvarPostalCode.IsNullable = false;
				colvarPostalCode.IsPrimaryKey = false;
				colvarPostalCode.IsForeignKey = false;
				colvarPostalCode.IsReadOnly = false;
				colvarPostalCode.DefaultSetting = @"";
				colvarPostalCode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPostalCode);
				
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
				DataService.Providers["AdventureWorks"].AddSchema("Address",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("AddressID")]
		[Bindable(true)]
		public int AddressID 
		{
			get { return GetColumnValue<int>(Columns.AddressID); }
			set { SetColumnValue(Columns.AddressID, value); }
		}
		  
		[XmlAttribute("AddressLine1")]
		[Bindable(true)]
		public string AddressLine1 
		{
			get { return GetColumnValue<string>(Columns.AddressLine1); }
			set { SetColumnValue(Columns.AddressLine1, value); }
		}
		  
		[XmlAttribute("AddressLine2")]
		[Bindable(true)]
		public string AddressLine2 
		{
			get { return GetColumnValue<string>(Columns.AddressLine2); }
			set { SetColumnValue(Columns.AddressLine2, value); }
		}
		  
		[XmlAttribute("City")]
		[Bindable(true)]
		public string City 
		{
			get { return GetColumnValue<string>(Columns.City); }
			set { SetColumnValue(Columns.City, value); }
		}
		  
		[XmlAttribute("StateProvinceID")]
		[Bindable(true)]
		public int StateProvinceID 
		{
			get { return GetColumnValue<int>(Columns.StateProvinceID); }
			set { SetColumnValue(Columns.StateProvinceID, value); }
		}
		  
		[XmlAttribute("PostalCode")]
		[Bindable(true)]
		public string PostalCode 
		{
			get { return GetColumnValue<string>(Columns.PostalCode); }
			set { SetColumnValue(Columns.PostalCode, value); }
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
        
		
		public AdventureWorks.EmployeeAddressCollection EmployeeAddressRecords()
		{
			return new AdventureWorks.EmployeeAddressCollection().Where(EmployeeAddress.Columns.AddressID, AddressID).Load();
		}
		public AdventureWorks.VendorAddressCollection VendorAddressRecords()
		{
			return new AdventureWorks.VendorAddressCollection().Where(VendorAddress.Columns.AddressID, AddressID).Load();
		}
		public AdventureWorks.CustomerAddressCollection CustomerAddressRecords()
		{
			return new AdventureWorks.CustomerAddressCollection().Where(CustomerAddress.Columns.AddressID, AddressID).Load();
		}
		public AdventureWorks.SalesOrderHeaderCollection SalesOrderHeaderRecords()
		{
			return new AdventureWorks.SalesOrderHeaderCollection().Where(SalesOrderHeader.Columns.BillToAddressID, AddressID).Load();
		}
		public AdventureWorks.SalesOrderHeaderCollection SalesOrderHeaderRecordsFromAddress()
		{
			return new AdventureWorks.SalesOrderHeaderCollection().Where(SalesOrderHeader.Columns.ShipToAddressID, AddressID).Load();
		}
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a StateProvince ActiveRecord object related to this Address
		/// 
		/// </summary>
		public AdventureWorks.StateProvince StateProvince
		{
			get { return AdventureWorks.StateProvince.FetchByID(this.StateProvinceID); }
			set { SetColumnValue("StateProvinceID", value.StateProvinceID); }
		}
		
		
		#endregion
		
		
		
		#region Many To Many Helpers
		
		 
		public AdventureWorks.AddressTypeCollection GetAddressTypeCollection() { return Address.GetAddressTypeCollection(this.AddressID); }
		public static AdventureWorks.AddressTypeCollection GetAddressTypeCollection(int varAddressID)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [Person].[AddressType] INNER JOIN [VendorAddress] ON [AddressType].[AddressTypeID] = [VendorAddress].[AddressTypeID] WHERE [VendorAddress].[AddressID] = @AddressID", Address.Schema.Provider.Name);
			cmd.AddParameter("@AddressID", varAddressID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			AddressTypeCollection coll = new AddressTypeCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveAddressTypeMap(int varAddressID, AddressTypeCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [VendorAddress] WHERE [VendorAddress].[AddressID] = @AddressID", Address.Schema.Provider.Name);
			cmdDel.AddParameter("@AddressID", varAddressID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (AddressType item in items)
			{
				VendorAddress varVendorAddress = new VendorAddress();
				varVendorAddress.SetColumnValue("AddressID", varAddressID);
				varVendorAddress.SetColumnValue("AddressTypeID", item.GetPrimaryKeyValue());
				varVendorAddress.Save();
			}
		}
		public static void SaveAddressTypeMap(int varAddressID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [VendorAddress] WHERE [VendorAddress].[AddressID] = @AddressID", Address.Schema.Provider.Name);
			cmdDel.AddParameter("@AddressID", varAddressID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					VendorAddress varVendorAddress = new VendorAddress();
					varVendorAddress.SetColumnValue("AddressID", varAddressID);
					varVendorAddress.SetColumnValue("AddressTypeID", l.Value);
					varVendorAddress.Save();
				}
			}
		}
		public static void SaveAddressTypeMap(int varAddressID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [VendorAddress] WHERE [VendorAddress].[AddressID] = @AddressID", Address.Schema.Provider.Name);
			cmdDel.AddParameter("@AddressID", varAddressID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				VendorAddress varVendorAddress = new VendorAddress();
				varVendorAddress.SetColumnValue("AddressID", varAddressID);
				varVendorAddress.SetColumnValue("AddressTypeID", item);
				varVendorAddress.Save();
			}
		}
		
		public static void DeleteAddressTypeMap(int varAddressID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [VendorAddress] WHERE [VendorAddress].[AddressID] = @AddressID", Address.Schema.Provider.Name);
			cmdDel.AddParameter("@AddressID", varAddressID, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		 
		public AdventureWorks.VendorCollection GetVendorCollection() { return Address.GetVendorCollection(this.AddressID); }
		public static AdventureWorks.VendorCollection GetVendorCollection(int varAddressID)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [Purchasing].[Vendor] INNER JOIN [VendorAddress] ON [Vendor].[VendorID] = [VendorAddress].[VendorID] WHERE [VendorAddress].[AddressID] = @AddressID", Address.Schema.Provider.Name);
			cmd.AddParameter("@AddressID", varAddressID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			VendorCollection coll = new VendorCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveVendorMap(int varAddressID, VendorCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [VendorAddress] WHERE [VendorAddress].[AddressID] = @AddressID", Address.Schema.Provider.Name);
			cmdDel.AddParameter("@AddressID", varAddressID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Vendor item in items)
			{
				VendorAddress varVendorAddress = new VendorAddress();
				varVendorAddress.SetColumnValue("AddressID", varAddressID);
				varVendorAddress.SetColumnValue("VendorID", item.GetPrimaryKeyValue());
				varVendorAddress.Save();
			}
		}
		public static void SaveVendorMap(int varAddressID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [VendorAddress] WHERE [VendorAddress].[AddressID] = @AddressID", Address.Schema.Provider.Name);
			cmdDel.AddParameter("@AddressID", varAddressID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					VendorAddress varVendorAddress = new VendorAddress();
					varVendorAddress.SetColumnValue("AddressID", varAddressID);
					varVendorAddress.SetColumnValue("VendorID", l.Value);
					varVendorAddress.Save();
				}
			}
		}
		public static void SaveVendorMap(int varAddressID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [VendorAddress] WHERE [VendorAddress].[AddressID] = @AddressID", Address.Schema.Provider.Name);
			cmdDel.AddParameter("@AddressID", varAddressID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				VendorAddress varVendorAddress = new VendorAddress();
				varVendorAddress.SetColumnValue("AddressID", varAddressID);
				varVendorAddress.SetColumnValue("VendorID", item);
				varVendorAddress.Save();
			}
		}
		
		public static void DeleteVendorMap(int varAddressID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [VendorAddress] WHERE [VendorAddress].[AddressID] = @AddressID", Address.Schema.Provider.Name);
			cmdDel.AddParameter("@AddressID", varAddressID, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		 
		public AdventureWorks.CustomerCollection GetCustomerCollection() { return Address.GetCustomerCollection(this.AddressID); }
		public static AdventureWorks.CustomerCollection GetCustomerCollection(int varAddressID)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [Sales].[Customer] INNER JOIN [CustomerAddress] ON [Customer].[CustomerID] = [CustomerAddress].[CustomerID] WHERE [CustomerAddress].[AddressID] = @AddressID", Address.Schema.Provider.Name);
			cmd.AddParameter("@AddressID", varAddressID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			CustomerCollection coll = new CustomerCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveCustomerMap(int varAddressID, CustomerCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [CustomerAddress] WHERE [CustomerAddress].[AddressID] = @AddressID", Address.Schema.Provider.Name);
			cmdDel.AddParameter("@AddressID", varAddressID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Customer item in items)
			{
				CustomerAddress varCustomerAddress = new CustomerAddress();
				varCustomerAddress.SetColumnValue("AddressID", varAddressID);
				varCustomerAddress.SetColumnValue("CustomerID", item.GetPrimaryKeyValue());
				varCustomerAddress.Save();
			}
		}
		public static void SaveCustomerMap(int varAddressID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [CustomerAddress] WHERE [CustomerAddress].[AddressID] = @AddressID", Address.Schema.Provider.Name);
			cmdDel.AddParameter("@AddressID", varAddressID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					CustomerAddress varCustomerAddress = new CustomerAddress();
					varCustomerAddress.SetColumnValue("AddressID", varAddressID);
					varCustomerAddress.SetColumnValue("CustomerID", l.Value);
					varCustomerAddress.Save();
				}
			}
		}
		public static void SaveCustomerMap(int varAddressID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [CustomerAddress] WHERE [CustomerAddress].[AddressID] = @AddressID", Address.Schema.Provider.Name);
			cmdDel.AddParameter("@AddressID", varAddressID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				CustomerAddress varCustomerAddress = new CustomerAddress();
				varCustomerAddress.SetColumnValue("AddressID", varAddressID);
				varCustomerAddress.SetColumnValue("CustomerID", item);
				varCustomerAddress.Save();
			}
		}
		
		public static void DeleteCustomerMap(int varAddressID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [CustomerAddress] WHERE [CustomerAddress].[AddressID] = @AddressID", Address.Schema.Provider.Name);
			cmdDel.AddParameter("@AddressID", varAddressID, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		 
		public AdventureWorks.EmployeeCollection GetEmployeeCollection() { return Address.GetEmployeeCollection(this.AddressID); }
		public static AdventureWorks.EmployeeCollection GetEmployeeCollection(int varAddressID)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [HumanResources].[Employee] INNER JOIN [EmployeeAddress] ON [Employee].[EmployeeID] = [EmployeeAddress].[EmployeeID] WHERE [EmployeeAddress].[AddressID] = @AddressID", Address.Schema.Provider.Name);
			cmd.AddParameter("@AddressID", varAddressID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			EmployeeCollection coll = new EmployeeCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveEmployeeMap(int varAddressID, EmployeeCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [EmployeeAddress] WHERE [EmployeeAddress].[AddressID] = @AddressID", Address.Schema.Provider.Name);
			cmdDel.AddParameter("@AddressID", varAddressID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Employee item in items)
			{
				EmployeeAddress varEmployeeAddress = new EmployeeAddress();
				varEmployeeAddress.SetColumnValue("AddressID", varAddressID);
				varEmployeeAddress.SetColumnValue("EmployeeID", item.GetPrimaryKeyValue());
				varEmployeeAddress.Save();
			}
		}
		public static void SaveEmployeeMap(int varAddressID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [EmployeeAddress] WHERE [EmployeeAddress].[AddressID] = @AddressID", Address.Schema.Provider.Name);
			cmdDel.AddParameter("@AddressID", varAddressID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					EmployeeAddress varEmployeeAddress = new EmployeeAddress();
					varEmployeeAddress.SetColumnValue("AddressID", varAddressID);
					varEmployeeAddress.SetColumnValue("EmployeeID", l.Value);
					varEmployeeAddress.Save();
				}
			}
		}
		public static void SaveEmployeeMap(int varAddressID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [EmployeeAddress] WHERE [EmployeeAddress].[AddressID] = @AddressID", Address.Schema.Provider.Name);
			cmdDel.AddParameter("@AddressID", varAddressID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				EmployeeAddress varEmployeeAddress = new EmployeeAddress();
				varEmployeeAddress.SetColumnValue("AddressID", varAddressID);
				varEmployeeAddress.SetColumnValue("EmployeeID", item);
				varEmployeeAddress.Save();
			}
		}
		
		public static void DeleteEmployeeMap(int varAddressID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [EmployeeAddress] WHERE [EmployeeAddress].[AddressID] = @AddressID", Address.Schema.Provider.Name);
			cmdDel.AddParameter("@AddressID", varAddressID, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		#endregion
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varAddressLine1,string varAddressLine2,string varCity,int varStateProvinceID,string varPostalCode,Guid varRowguid,DateTime varModifiedDate)
		{
			Address item = new Address();
			
			item.AddressLine1 = varAddressLine1;
			
			item.AddressLine2 = varAddressLine2;
			
			item.City = varCity;
			
			item.StateProvinceID = varStateProvinceID;
			
			item.PostalCode = varPostalCode;
			
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
		public static void Update(int varAddressID,string varAddressLine1,string varAddressLine2,string varCity,int varStateProvinceID,string varPostalCode,Guid varRowguid,DateTime varModifiedDate)
		{
			Address item = new Address();
			
				item.AddressID = varAddressID;
			
				item.AddressLine1 = varAddressLine1;
			
				item.AddressLine2 = varAddressLine2;
			
				item.City = varCity;
			
				item.StateProvinceID = varStateProvinceID;
			
				item.PostalCode = varPostalCode;
			
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
        
        
        public static TableSchema.TableColumn AddressIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn AddressLine1Column
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn AddressLine2Column
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn CityColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn StateProvinceIDColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn PostalCodeColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn RowguidColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedDateColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string AddressID = @"AddressID";
			 public static string AddressLine1 = @"AddressLine1";
			 public static string AddressLine2 = @"AddressLine2";
			 public static string City = @"City";
			 public static string StateProvinceID = @"StateProvinceID";
			 public static string PostalCode = @"PostalCode";
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
