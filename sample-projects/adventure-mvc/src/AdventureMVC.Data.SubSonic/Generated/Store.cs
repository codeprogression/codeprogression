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
	/// Strongly-typed collection for the Store class.
	/// </summary>
    [Serializable]
	public partial class StoreCollection : ActiveList<Store, StoreCollection>
	{	   
		public StoreCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>StoreCollection</returns>
		public StoreCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Store o = this[i];
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
	/// This is an ActiveRecord class which wraps the Store table.
	/// </summary>
	[Serializable]
	public partial class Store : ActiveRecord<Store>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Store()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Store(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Store(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Store(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Store", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Sales";
				//columns
				
				TableSchema.TableColumn colvarCustomerID = new TableSchema.TableColumn(schema);
				colvarCustomerID.ColumnName = "CustomerID";
				colvarCustomerID.DataType = DbType.Int32;
				colvarCustomerID.MaxLength = 0;
				colvarCustomerID.AutoIncrement = false;
				colvarCustomerID.IsNullable = false;
				colvarCustomerID.IsPrimaryKey = true;
				colvarCustomerID.IsForeignKey = true;
				colvarCustomerID.IsReadOnly = false;
				colvarCustomerID.DefaultSetting = @"";
				
					colvarCustomerID.ForeignKeyTableName = "Customer";
				schema.Columns.Add(colvarCustomerID);
				
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
				
				TableSchema.TableColumn colvarSalesPersonID = new TableSchema.TableColumn(schema);
				colvarSalesPersonID.ColumnName = "SalesPersonID";
				colvarSalesPersonID.DataType = DbType.Int32;
				colvarSalesPersonID.MaxLength = 0;
				colvarSalesPersonID.AutoIncrement = false;
				colvarSalesPersonID.IsNullable = true;
				colvarSalesPersonID.IsPrimaryKey = false;
				colvarSalesPersonID.IsForeignKey = true;
				colvarSalesPersonID.IsReadOnly = false;
				colvarSalesPersonID.DefaultSetting = @"";
				
					colvarSalesPersonID.ForeignKeyTableName = "SalesPerson";
				schema.Columns.Add(colvarSalesPersonID);
				
				TableSchema.TableColumn colvarDemographics = new TableSchema.TableColumn(schema);
				colvarDemographics.ColumnName = "Demographics";
				colvarDemographics.DataType = DbType.AnsiString;
				colvarDemographics.MaxLength = -1;
				colvarDemographics.AutoIncrement = false;
				colvarDemographics.IsNullable = true;
				colvarDemographics.IsPrimaryKey = false;
				colvarDemographics.IsForeignKey = false;
				colvarDemographics.IsReadOnly = false;
				colvarDemographics.DefaultSetting = @"";
				colvarDemographics.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDemographics);
				
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
				DataService.Providers["AdventureWorks"].AddSchema("Store",schema);
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
		  
		[XmlAttribute("Name")]
		[Bindable(true)]
		public string Name 
		{
			get { return GetColumnValue<string>(Columns.Name); }
			set { SetColumnValue(Columns.Name, value); }
		}
		  
		[XmlAttribute("SalesPersonID")]
		[Bindable(true)]
		public int? SalesPersonID 
		{
			get { return GetColumnValue<int?>(Columns.SalesPersonID); }
			set { SetColumnValue(Columns.SalesPersonID, value); }
		}
		  
		[XmlAttribute("Demographics")]
		[Bindable(true)]
		public string Demographics 
		{
			get { return GetColumnValue<string>(Columns.Demographics); }
			set { SetColumnValue(Columns.Demographics, value); }
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
        
		
		public AdventureWorks.StoreContactCollection StoreContactRecords()
		{
			return new AdventureWorks.StoreContactCollection().Where(StoreContact.Columns.CustomerID, CustomerID).Load();
		}
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Customer ActiveRecord object related to this Store
		/// 
		/// </summary>
		public AdventureWorks.Customer Customer
		{
			get { return AdventureWorks.Customer.FetchByID(this.CustomerID); }
			set { SetColumnValue("CustomerID", value.CustomerID); }
		}
		
		
		/// <summary>
		/// Returns a SalesPerson ActiveRecord object related to this Store
		/// 
		/// </summary>
		public AdventureWorks.SalesPerson SalesPerson
		{
			get { return AdventureWorks.SalesPerson.FetchByID(this.SalesPersonID); }
			set { SetColumnValue("SalesPersonID", value.SalesPersonID); }
		}
		
		
		#endregion
		
		
		
		#region Many To Many Helpers
		
		 
		public AdventureWorks.ContactCollection GetContactCollection() { return Store.GetContactCollection(this.CustomerID); }
		public static AdventureWorks.ContactCollection GetContactCollection(int varCustomerID)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [Person].[Contact] INNER JOIN [StoreContact] ON [Contact].[ContactID] = [StoreContact].[ContactID] WHERE [StoreContact].[CustomerID] = @CustomerID", Store.Schema.Provider.Name);
			cmd.AddParameter("@CustomerID", varCustomerID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			ContactCollection coll = new ContactCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveContactMap(int varCustomerID, ContactCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [StoreContact] WHERE [StoreContact].[CustomerID] = @CustomerID", Store.Schema.Provider.Name);
			cmdDel.AddParameter("@CustomerID", varCustomerID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Contact item in items)
			{
				StoreContact varStoreContact = new StoreContact();
				varStoreContact.SetColumnValue("CustomerID", varCustomerID);
				varStoreContact.SetColumnValue("ContactID", item.GetPrimaryKeyValue());
				varStoreContact.Save();
			}
		}
		public static void SaveContactMap(int varCustomerID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [StoreContact] WHERE [StoreContact].[CustomerID] = @CustomerID", Store.Schema.Provider.Name);
			cmdDel.AddParameter("@CustomerID", varCustomerID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					StoreContact varStoreContact = new StoreContact();
					varStoreContact.SetColumnValue("CustomerID", varCustomerID);
					varStoreContact.SetColumnValue("ContactID", l.Value);
					varStoreContact.Save();
				}
			}
		}
		public static void SaveContactMap(int varCustomerID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [StoreContact] WHERE [StoreContact].[CustomerID] = @CustomerID", Store.Schema.Provider.Name);
			cmdDel.AddParameter("@CustomerID", varCustomerID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				StoreContact varStoreContact = new StoreContact();
				varStoreContact.SetColumnValue("CustomerID", varCustomerID);
				varStoreContact.SetColumnValue("ContactID", item);
				varStoreContact.Save();
			}
		}
		
		public static void DeleteContactMap(int varCustomerID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [StoreContact] WHERE [StoreContact].[CustomerID] = @CustomerID", Store.Schema.Provider.Name);
			cmdDel.AddParameter("@CustomerID", varCustomerID, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		 
		public AdventureWorks.ContactTypeCollection GetContactTypeCollection() { return Store.GetContactTypeCollection(this.CustomerID); }
		public static AdventureWorks.ContactTypeCollection GetContactTypeCollection(int varCustomerID)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [Person].[ContactType] INNER JOIN [StoreContact] ON [ContactType].[ContactTypeID] = [StoreContact].[ContactTypeID] WHERE [StoreContact].[CustomerID] = @CustomerID", Store.Schema.Provider.Name);
			cmd.AddParameter("@CustomerID", varCustomerID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			ContactTypeCollection coll = new ContactTypeCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveContactTypeMap(int varCustomerID, ContactTypeCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [StoreContact] WHERE [StoreContact].[CustomerID] = @CustomerID", Store.Schema.Provider.Name);
			cmdDel.AddParameter("@CustomerID", varCustomerID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (ContactType item in items)
			{
				StoreContact varStoreContact = new StoreContact();
				varStoreContact.SetColumnValue("CustomerID", varCustomerID);
				varStoreContact.SetColumnValue("ContactTypeID", item.GetPrimaryKeyValue());
				varStoreContact.Save();
			}
		}
		public static void SaveContactTypeMap(int varCustomerID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [StoreContact] WHERE [StoreContact].[CustomerID] = @CustomerID", Store.Schema.Provider.Name);
			cmdDel.AddParameter("@CustomerID", varCustomerID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					StoreContact varStoreContact = new StoreContact();
					varStoreContact.SetColumnValue("CustomerID", varCustomerID);
					varStoreContact.SetColumnValue("ContactTypeID", l.Value);
					varStoreContact.Save();
				}
			}
		}
		public static void SaveContactTypeMap(int varCustomerID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [StoreContact] WHERE [StoreContact].[CustomerID] = @CustomerID", Store.Schema.Provider.Name);
			cmdDel.AddParameter("@CustomerID", varCustomerID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				StoreContact varStoreContact = new StoreContact();
				varStoreContact.SetColumnValue("CustomerID", varCustomerID);
				varStoreContact.SetColumnValue("ContactTypeID", item);
				varStoreContact.Save();
			}
		}
		
		public static void DeleteContactTypeMap(int varCustomerID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [StoreContact] WHERE [StoreContact].[CustomerID] = @CustomerID", Store.Schema.Provider.Name);
			cmdDel.AddParameter("@CustomerID", varCustomerID, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		#endregion
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varCustomerID,string varName,int? varSalesPersonID,string varDemographics,Guid varRowguid,DateTime varModifiedDate)
		{
			Store item = new Store();
			
			item.CustomerID = varCustomerID;
			
			item.Name = varName;
			
			item.SalesPersonID = varSalesPersonID;
			
			item.Demographics = varDemographics;
			
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
		public static void Update(int varCustomerID,string varName,int? varSalesPersonID,string varDemographics,Guid varRowguid,DateTime varModifiedDate)
		{
			Store item = new Store();
			
				item.CustomerID = varCustomerID;
			
				item.Name = varName;
			
				item.SalesPersonID = varSalesPersonID;
			
				item.Demographics = varDemographics;
			
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
        
        
        
        public static TableSchema.TableColumn NameColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn SalesPersonIDColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DemographicsColumn
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
			 public static string Name = @"Name";
			 public static string SalesPersonID = @"SalesPersonID";
			 public static string Demographics = @"Demographics";
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
