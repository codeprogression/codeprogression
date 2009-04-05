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
	/// Strongly-typed collection for the Vendor class.
	/// </summary>
    [Serializable]
	public partial class VendorCollection : ActiveList<Vendor, VendorCollection>
	{	   
		public VendorCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>VendorCollection</returns>
		public VendorCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Vendor o = this[i];
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
	/// This is an ActiveRecord class which wraps the Vendor table.
	/// </summary>
	[Serializable]
	public partial class Vendor : ActiveRecord<Vendor>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Vendor()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Vendor(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Vendor(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Vendor(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Vendor", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Purchasing";
				//columns
				
				TableSchema.TableColumn colvarVendorID = new TableSchema.TableColumn(schema);
				colvarVendorID.ColumnName = "VendorID";
				colvarVendorID.DataType = DbType.Int32;
				colvarVendorID.MaxLength = 0;
				colvarVendorID.AutoIncrement = true;
				colvarVendorID.IsNullable = false;
				colvarVendorID.IsPrimaryKey = true;
				colvarVendorID.IsForeignKey = false;
				colvarVendorID.IsReadOnly = false;
				colvarVendorID.DefaultSetting = @"";
				colvarVendorID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVendorID);
				
				TableSchema.TableColumn colvarAccountNumber = new TableSchema.TableColumn(schema);
				colvarAccountNumber.ColumnName = "AccountNumber";
				colvarAccountNumber.DataType = DbType.String;
				colvarAccountNumber.MaxLength = 15;
				colvarAccountNumber.AutoIncrement = false;
				colvarAccountNumber.IsNullable = false;
				colvarAccountNumber.IsPrimaryKey = false;
				colvarAccountNumber.IsForeignKey = false;
				colvarAccountNumber.IsReadOnly = false;
				colvarAccountNumber.DefaultSetting = @"";
				colvarAccountNumber.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAccountNumber);
				
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
				
				TableSchema.TableColumn colvarCreditRating = new TableSchema.TableColumn(schema);
				colvarCreditRating.ColumnName = "CreditRating";
				colvarCreditRating.DataType = DbType.Byte;
				colvarCreditRating.MaxLength = 0;
				colvarCreditRating.AutoIncrement = false;
				colvarCreditRating.IsNullable = false;
				colvarCreditRating.IsPrimaryKey = false;
				colvarCreditRating.IsForeignKey = false;
				colvarCreditRating.IsReadOnly = false;
				colvarCreditRating.DefaultSetting = @"";
				colvarCreditRating.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreditRating);
				
				TableSchema.TableColumn colvarPreferredVendorStatus = new TableSchema.TableColumn(schema);
				colvarPreferredVendorStatus.ColumnName = "PreferredVendorStatus";
				colvarPreferredVendorStatus.DataType = DbType.Boolean;
				colvarPreferredVendorStatus.MaxLength = 0;
				colvarPreferredVendorStatus.AutoIncrement = false;
				colvarPreferredVendorStatus.IsNullable = false;
				colvarPreferredVendorStatus.IsPrimaryKey = false;
				colvarPreferredVendorStatus.IsForeignKey = false;
				colvarPreferredVendorStatus.IsReadOnly = false;
				
						colvarPreferredVendorStatus.DefaultSetting = @"((1))";
				colvarPreferredVendorStatus.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPreferredVendorStatus);
				
				TableSchema.TableColumn colvarActiveFlag = new TableSchema.TableColumn(schema);
				colvarActiveFlag.ColumnName = "ActiveFlag";
				colvarActiveFlag.DataType = DbType.Boolean;
				colvarActiveFlag.MaxLength = 0;
				colvarActiveFlag.AutoIncrement = false;
				colvarActiveFlag.IsNullable = false;
				colvarActiveFlag.IsPrimaryKey = false;
				colvarActiveFlag.IsForeignKey = false;
				colvarActiveFlag.IsReadOnly = false;
				
						colvarActiveFlag.DefaultSetting = @"((1))";
				colvarActiveFlag.ForeignKeyTableName = "";
				schema.Columns.Add(colvarActiveFlag);
				
				TableSchema.TableColumn colvarPurchasingWebServiceURL = new TableSchema.TableColumn(schema);
				colvarPurchasingWebServiceURL.ColumnName = "PurchasingWebServiceURL";
				colvarPurchasingWebServiceURL.DataType = DbType.String;
				colvarPurchasingWebServiceURL.MaxLength = 1024;
				colvarPurchasingWebServiceURL.AutoIncrement = false;
				colvarPurchasingWebServiceURL.IsNullable = true;
				colvarPurchasingWebServiceURL.IsPrimaryKey = false;
				colvarPurchasingWebServiceURL.IsForeignKey = false;
				colvarPurchasingWebServiceURL.IsReadOnly = false;
				colvarPurchasingWebServiceURL.DefaultSetting = @"";
				colvarPurchasingWebServiceURL.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPurchasingWebServiceURL);
				
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
				DataService.Providers["AdventureWorks"].AddSchema("Vendor",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("VendorID")]
		[Bindable(true)]
		public int VendorID 
		{
			get { return GetColumnValue<int>(Columns.VendorID); }
			set { SetColumnValue(Columns.VendorID, value); }
		}
		  
		[XmlAttribute("AccountNumber")]
		[Bindable(true)]
		public string AccountNumber 
		{
			get { return GetColumnValue<string>(Columns.AccountNumber); }
			set { SetColumnValue(Columns.AccountNumber, value); }
		}
		  
		[XmlAttribute("Name")]
		[Bindable(true)]
		public string Name 
		{
			get { return GetColumnValue<string>(Columns.Name); }
			set { SetColumnValue(Columns.Name, value); }
		}
		  
		[XmlAttribute("CreditRating")]
		[Bindable(true)]
		public byte CreditRating 
		{
			get { return GetColumnValue<byte>(Columns.CreditRating); }
			set { SetColumnValue(Columns.CreditRating, value); }
		}
		  
		[XmlAttribute("PreferredVendorStatus")]
		[Bindable(true)]
		public bool PreferredVendorStatus 
		{
			get { return GetColumnValue<bool>(Columns.PreferredVendorStatus); }
			set { SetColumnValue(Columns.PreferredVendorStatus, value); }
		}
		  
		[XmlAttribute("ActiveFlag")]
		[Bindable(true)]
		public bool ActiveFlag 
		{
			get { return GetColumnValue<bool>(Columns.ActiveFlag); }
			set { SetColumnValue(Columns.ActiveFlag, value); }
		}
		  
		[XmlAttribute("PurchasingWebServiceURL")]
		[Bindable(true)]
		public string PurchasingWebServiceURL 
		{
			get { return GetColumnValue<string>(Columns.PurchasingWebServiceURL); }
			set { SetColumnValue(Columns.PurchasingWebServiceURL, value); }
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
        
		
		public AdventureWorks.ProductVendorCollection ProductVendorRecords()
		{
			return new AdventureWorks.ProductVendorCollection().Where(ProductVendor.Columns.VendorID, VendorID).Load();
		}
		public AdventureWorks.PurchaseOrderHeaderCollection PurchaseOrderHeaderRecords()
		{
			return new AdventureWorks.PurchaseOrderHeaderCollection().Where(PurchaseOrderHeader.Columns.VendorID, VendorID).Load();
		}
		public AdventureWorks.VendorAddressCollection VendorAddressRecords()
		{
			return new AdventureWorks.VendorAddressCollection().Where(VendorAddress.Columns.VendorID, VendorID).Load();
		}
		public AdventureWorks.VendorContactCollection VendorContactRecords()
		{
			return new AdventureWorks.VendorContactCollection().Where(VendorContact.Columns.VendorID, VendorID).Load();
		}
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		#region Many To Many Helpers
		
		 
		public AdventureWorks.ProductCollection GetProductCollection() { return Vendor.GetProductCollection(this.VendorID); }
		public static AdventureWorks.ProductCollection GetProductCollection(int varVendorID)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [Production].[Product] INNER JOIN [ProductVendor] ON [Product].[ProductID] = [ProductVendor].[ProductID] WHERE [ProductVendor].[VendorID] = @VendorID", Vendor.Schema.Provider.Name);
			cmd.AddParameter("@VendorID", varVendorID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			ProductCollection coll = new ProductCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveProductMap(int varVendorID, ProductCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductVendor] WHERE [ProductVendor].[VendorID] = @VendorID", Vendor.Schema.Provider.Name);
			cmdDel.AddParameter("@VendorID", varVendorID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Product item in items)
			{
				ProductVendor varProductVendor = new ProductVendor();
				varProductVendor.SetColumnValue("VendorID", varVendorID);
				varProductVendor.SetColumnValue("ProductID", item.GetPrimaryKeyValue());
				varProductVendor.Save();
			}
		}
		public static void SaveProductMap(int varVendorID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductVendor] WHERE [ProductVendor].[VendorID] = @VendorID", Vendor.Schema.Provider.Name);
			cmdDel.AddParameter("@VendorID", varVendorID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					ProductVendor varProductVendor = new ProductVendor();
					varProductVendor.SetColumnValue("VendorID", varVendorID);
					varProductVendor.SetColumnValue("ProductID", l.Value);
					varProductVendor.Save();
				}
			}
		}
		public static void SaveProductMap(int varVendorID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductVendor] WHERE [ProductVendor].[VendorID] = @VendorID", Vendor.Schema.Provider.Name);
			cmdDel.AddParameter("@VendorID", varVendorID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				ProductVendor varProductVendor = new ProductVendor();
				varProductVendor.SetColumnValue("VendorID", varVendorID);
				varProductVendor.SetColumnValue("ProductID", item);
				varProductVendor.Save();
			}
		}
		
		public static void DeleteProductMap(int varVendorID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductVendor] WHERE [ProductVendor].[VendorID] = @VendorID", Vendor.Schema.Provider.Name);
			cmdDel.AddParameter("@VendorID", varVendorID, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		 
		public AdventureWorks.UnitMeasureCollection GetUnitMeasureCollection() { return Vendor.GetUnitMeasureCollection(this.VendorID); }
		public static AdventureWorks.UnitMeasureCollection GetUnitMeasureCollection(int varVendorID)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [Production].[UnitMeasure] INNER JOIN [ProductVendor] ON [UnitMeasure].[UnitMeasureCode] = [ProductVendor].[UnitMeasureCode] WHERE [ProductVendor].[VendorID] = @VendorID", Vendor.Schema.Provider.Name);
			cmd.AddParameter("@VendorID", varVendorID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			UnitMeasureCollection coll = new UnitMeasureCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveUnitMeasureMap(int varVendorID, UnitMeasureCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductVendor] WHERE [ProductVendor].[VendorID] = @VendorID", Vendor.Schema.Provider.Name);
			cmdDel.AddParameter("@VendorID", varVendorID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (UnitMeasure item in items)
			{
				ProductVendor varProductVendor = new ProductVendor();
				varProductVendor.SetColumnValue("VendorID", varVendorID);
				varProductVendor.SetColumnValue("UnitMeasureCode", item.GetPrimaryKeyValue());
				varProductVendor.Save();
			}
		}
		public static void SaveUnitMeasureMap(int varVendorID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductVendor] WHERE [ProductVendor].[VendorID] = @VendorID", Vendor.Schema.Provider.Name);
			cmdDel.AddParameter("@VendorID", varVendorID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					ProductVendor varProductVendor = new ProductVendor();
					varProductVendor.SetColumnValue("VendorID", varVendorID);
					varProductVendor.SetColumnValue("UnitMeasureCode", l.Value);
					varProductVendor.Save();
				}
			}
		}
		public static void SaveUnitMeasureMap(int varVendorID , string[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductVendor] WHERE [ProductVendor].[VendorID] = @VendorID", Vendor.Schema.Provider.Name);
			cmdDel.AddParameter("@VendorID", varVendorID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (string item in itemList) 
			{
				ProductVendor varProductVendor = new ProductVendor();
				varProductVendor.SetColumnValue("VendorID", varVendorID);
				varProductVendor.SetColumnValue("UnitMeasureCode", item);
				varProductVendor.Save();
			}
		}
		
		public static void DeleteUnitMeasureMap(int varVendorID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductVendor] WHERE [ProductVendor].[VendorID] = @VendorID", Vendor.Schema.Provider.Name);
			cmdDel.AddParameter("@VendorID", varVendorID, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		 
		public AdventureWorks.AddressCollection GetAddressCollection() { return Vendor.GetAddressCollection(this.VendorID); }
		public static AdventureWorks.AddressCollection GetAddressCollection(int varVendorID)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [Person].[Address] INNER JOIN [VendorAddress] ON [Address].[AddressID] = [VendorAddress].[AddressID] WHERE [VendorAddress].[VendorID] = @VendorID", Vendor.Schema.Provider.Name);
			cmd.AddParameter("@VendorID", varVendorID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			AddressCollection coll = new AddressCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveAddressMap(int varVendorID, AddressCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [VendorAddress] WHERE [VendorAddress].[VendorID] = @VendorID", Vendor.Schema.Provider.Name);
			cmdDel.AddParameter("@VendorID", varVendorID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Address item in items)
			{
				VendorAddress varVendorAddress = new VendorAddress();
				varVendorAddress.SetColumnValue("VendorID", varVendorID);
				varVendorAddress.SetColumnValue("AddressID", item.GetPrimaryKeyValue());
				varVendorAddress.Save();
			}
		}
		public static void SaveAddressMap(int varVendorID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [VendorAddress] WHERE [VendorAddress].[VendorID] = @VendorID", Vendor.Schema.Provider.Name);
			cmdDel.AddParameter("@VendorID", varVendorID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					VendorAddress varVendorAddress = new VendorAddress();
					varVendorAddress.SetColumnValue("VendorID", varVendorID);
					varVendorAddress.SetColumnValue("AddressID", l.Value);
					varVendorAddress.Save();
				}
			}
		}
		public static void SaveAddressMap(int varVendorID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [VendorAddress] WHERE [VendorAddress].[VendorID] = @VendorID", Vendor.Schema.Provider.Name);
			cmdDel.AddParameter("@VendorID", varVendorID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				VendorAddress varVendorAddress = new VendorAddress();
				varVendorAddress.SetColumnValue("VendorID", varVendorID);
				varVendorAddress.SetColumnValue("AddressID", item);
				varVendorAddress.Save();
			}
		}
		
		public static void DeleteAddressMap(int varVendorID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [VendorAddress] WHERE [VendorAddress].[VendorID] = @VendorID", Vendor.Schema.Provider.Name);
			cmdDel.AddParameter("@VendorID", varVendorID, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		 
		public AdventureWorks.AddressTypeCollection GetAddressTypeCollection() { return Vendor.GetAddressTypeCollection(this.VendorID); }
		public static AdventureWorks.AddressTypeCollection GetAddressTypeCollection(int varVendorID)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [Person].[AddressType] INNER JOIN [VendorAddress] ON [AddressType].[AddressTypeID] = [VendorAddress].[AddressTypeID] WHERE [VendorAddress].[VendorID] = @VendorID", Vendor.Schema.Provider.Name);
			cmd.AddParameter("@VendorID", varVendorID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			AddressTypeCollection coll = new AddressTypeCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveAddressTypeMap(int varVendorID, AddressTypeCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [VendorAddress] WHERE [VendorAddress].[VendorID] = @VendorID", Vendor.Schema.Provider.Name);
			cmdDel.AddParameter("@VendorID", varVendorID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (AddressType item in items)
			{
				VendorAddress varVendorAddress = new VendorAddress();
				varVendorAddress.SetColumnValue("VendorID", varVendorID);
				varVendorAddress.SetColumnValue("AddressTypeID", item.GetPrimaryKeyValue());
				varVendorAddress.Save();
			}
		}
		public static void SaveAddressTypeMap(int varVendorID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [VendorAddress] WHERE [VendorAddress].[VendorID] = @VendorID", Vendor.Schema.Provider.Name);
			cmdDel.AddParameter("@VendorID", varVendorID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					VendorAddress varVendorAddress = new VendorAddress();
					varVendorAddress.SetColumnValue("VendorID", varVendorID);
					varVendorAddress.SetColumnValue("AddressTypeID", l.Value);
					varVendorAddress.Save();
				}
			}
		}
		public static void SaveAddressTypeMap(int varVendorID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [VendorAddress] WHERE [VendorAddress].[VendorID] = @VendorID", Vendor.Schema.Provider.Name);
			cmdDel.AddParameter("@VendorID", varVendorID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				VendorAddress varVendorAddress = new VendorAddress();
				varVendorAddress.SetColumnValue("VendorID", varVendorID);
				varVendorAddress.SetColumnValue("AddressTypeID", item);
				varVendorAddress.Save();
			}
		}
		
		public static void DeleteAddressTypeMap(int varVendorID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [VendorAddress] WHERE [VendorAddress].[VendorID] = @VendorID", Vendor.Schema.Provider.Name);
			cmdDel.AddParameter("@VendorID", varVendorID, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		 
		public AdventureWorks.ContactCollection GetContactCollection() { return Vendor.GetContactCollection(this.VendorID); }
		public static AdventureWorks.ContactCollection GetContactCollection(int varVendorID)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [Person].[Contact] INNER JOIN [VendorContact] ON [Contact].[ContactID] = [VendorContact].[ContactID] WHERE [VendorContact].[VendorID] = @VendorID", Vendor.Schema.Provider.Name);
			cmd.AddParameter("@VendorID", varVendorID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			ContactCollection coll = new ContactCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveContactMap(int varVendorID, ContactCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [VendorContact] WHERE [VendorContact].[VendorID] = @VendorID", Vendor.Schema.Provider.Name);
			cmdDel.AddParameter("@VendorID", varVendorID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Contact item in items)
			{
				VendorContact varVendorContact = new VendorContact();
				varVendorContact.SetColumnValue("VendorID", varVendorID);
				varVendorContact.SetColumnValue("ContactID", item.GetPrimaryKeyValue());
				varVendorContact.Save();
			}
		}
		public static void SaveContactMap(int varVendorID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [VendorContact] WHERE [VendorContact].[VendorID] = @VendorID", Vendor.Schema.Provider.Name);
			cmdDel.AddParameter("@VendorID", varVendorID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					VendorContact varVendorContact = new VendorContact();
					varVendorContact.SetColumnValue("VendorID", varVendorID);
					varVendorContact.SetColumnValue("ContactID", l.Value);
					varVendorContact.Save();
				}
			}
		}
		public static void SaveContactMap(int varVendorID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [VendorContact] WHERE [VendorContact].[VendorID] = @VendorID", Vendor.Schema.Provider.Name);
			cmdDel.AddParameter("@VendorID", varVendorID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				VendorContact varVendorContact = new VendorContact();
				varVendorContact.SetColumnValue("VendorID", varVendorID);
				varVendorContact.SetColumnValue("ContactID", item);
				varVendorContact.Save();
			}
		}
		
		public static void DeleteContactMap(int varVendorID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [VendorContact] WHERE [VendorContact].[VendorID] = @VendorID", Vendor.Schema.Provider.Name);
			cmdDel.AddParameter("@VendorID", varVendorID, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		 
		public AdventureWorks.ContactTypeCollection GetContactTypeCollection() { return Vendor.GetContactTypeCollection(this.VendorID); }
		public static AdventureWorks.ContactTypeCollection GetContactTypeCollection(int varVendorID)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [Person].[ContactType] INNER JOIN [VendorContact] ON [ContactType].[ContactTypeID] = [VendorContact].[ContactTypeID] WHERE [VendorContact].[VendorID] = @VendorID", Vendor.Schema.Provider.Name);
			cmd.AddParameter("@VendorID", varVendorID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			ContactTypeCollection coll = new ContactTypeCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveContactTypeMap(int varVendorID, ContactTypeCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [VendorContact] WHERE [VendorContact].[VendorID] = @VendorID", Vendor.Schema.Provider.Name);
			cmdDel.AddParameter("@VendorID", varVendorID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (ContactType item in items)
			{
				VendorContact varVendorContact = new VendorContact();
				varVendorContact.SetColumnValue("VendorID", varVendorID);
				varVendorContact.SetColumnValue("ContactTypeID", item.GetPrimaryKeyValue());
				varVendorContact.Save();
			}
		}
		public static void SaveContactTypeMap(int varVendorID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [VendorContact] WHERE [VendorContact].[VendorID] = @VendorID", Vendor.Schema.Provider.Name);
			cmdDel.AddParameter("@VendorID", varVendorID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					VendorContact varVendorContact = new VendorContact();
					varVendorContact.SetColumnValue("VendorID", varVendorID);
					varVendorContact.SetColumnValue("ContactTypeID", l.Value);
					varVendorContact.Save();
				}
			}
		}
		public static void SaveContactTypeMap(int varVendorID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [VendorContact] WHERE [VendorContact].[VendorID] = @VendorID", Vendor.Schema.Provider.Name);
			cmdDel.AddParameter("@VendorID", varVendorID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				VendorContact varVendorContact = new VendorContact();
				varVendorContact.SetColumnValue("VendorID", varVendorID);
				varVendorContact.SetColumnValue("ContactTypeID", item);
				varVendorContact.Save();
			}
		}
		
		public static void DeleteContactTypeMap(int varVendorID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [VendorContact] WHERE [VendorContact].[VendorID] = @VendorID", Vendor.Schema.Provider.Name);
			cmdDel.AddParameter("@VendorID", varVendorID, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		#endregion
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varAccountNumber,string varName,byte varCreditRating,bool varPreferredVendorStatus,bool varActiveFlag,string varPurchasingWebServiceURL,DateTime varModifiedDate)
		{
			Vendor item = new Vendor();
			
			item.AccountNumber = varAccountNumber;
			
			item.Name = varName;
			
			item.CreditRating = varCreditRating;
			
			item.PreferredVendorStatus = varPreferredVendorStatus;
			
			item.ActiveFlag = varActiveFlag;
			
			item.PurchasingWebServiceURL = varPurchasingWebServiceURL;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varVendorID,string varAccountNumber,string varName,byte varCreditRating,bool varPreferredVendorStatus,bool varActiveFlag,string varPurchasingWebServiceURL,DateTime varModifiedDate)
		{
			Vendor item = new Vendor();
			
				item.VendorID = varVendorID;
			
				item.AccountNumber = varAccountNumber;
			
				item.Name = varName;
			
				item.CreditRating = varCreditRating;
			
				item.PreferredVendorStatus = varPreferredVendorStatus;
			
				item.ActiveFlag = varActiveFlag;
			
				item.PurchasingWebServiceURL = varPurchasingWebServiceURL;
			
				item.ModifiedDate = varModifiedDate;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn VendorIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn AccountNumberColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NameColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn CreditRatingColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn PreferredVendorStatusColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ActiveFlagColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn PurchasingWebServiceURLColumn
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
			 public static string VendorID = @"VendorID";
			 public static string AccountNumber = @"AccountNumber";
			 public static string Name = @"Name";
			 public static string CreditRating = @"CreditRating";
			 public static string PreferredVendorStatus = @"PreferredVendorStatus";
			 public static string ActiveFlag = @"ActiveFlag";
			 public static string PurchasingWebServiceURL = @"PurchasingWebServiceURL";
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
