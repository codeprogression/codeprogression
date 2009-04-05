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
	/// Strongly-typed collection for the ContactType class.
	/// </summary>
    [Serializable]
	public partial class ContactTypeCollection : ActiveList<ContactType, ContactTypeCollection>
	{	   
		public ContactTypeCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ContactTypeCollection</returns>
		public ContactTypeCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ContactType o = this[i];
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
	/// This is an ActiveRecord class which wraps the ContactType table.
	/// </summary>
	[Serializable]
	public partial class ContactType : ActiveRecord<ContactType>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ContactType()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ContactType(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ContactType(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ContactType(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ContactType", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Person";
				//columns
				
				TableSchema.TableColumn colvarContactTypeID = new TableSchema.TableColumn(schema);
				colvarContactTypeID.ColumnName = "ContactTypeID";
				colvarContactTypeID.DataType = DbType.Int32;
				colvarContactTypeID.MaxLength = 0;
				colvarContactTypeID.AutoIncrement = true;
				colvarContactTypeID.IsNullable = false;
				colvarContactTypeID.IsPrimaryKey = true;
				colvarContactTypeID.IsForeignKey = false;
				colvarContactTypeID.IsReadOnly = false;
				colvarContactTypeID.DefaultSetting = @"";
				colvarContactTypeID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarContactTypeID);
				
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
				DataService.Providers["AdventureWorks"].AddSchema("ContactType",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("ContactTypeID")]
		[Bindable(true)]
		public int ContactTypeID 
		{
			get { return GetColumnValue<int>(Columns.ContactTypeID); }
			set { SetColumnValue(Columns.ContactTypeID, value); }
		}
		  
		[XmlAttribute("Name")]
		[Bindable(true)]
		public string Name 
		{
			get { return GetColumnValue<string>(Columns.Name); }
			set { SetColumnValue(Columns.Name, value); }
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
        
		
		public AdventureWorks.VendorContactCollection VendorContactRecords()
		{
			return new AdventureWorks.VendorContactCollection().Where(VendorContact.Columns.ContactTypeID, ContactTypeID).Load();
		}
		public AdventureWorks.StoreContactCollection StoreContactRecords()
		{
			return new AdventureWorks.StoreContactCollection().Where(StoreContact.Columns.ContactTypeID, ContactTypeID).Load();
		}
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		#region Many To Many Helpers
		
		 
		public AdventureWorks.ContactCollection GetContactCollection() { return ContactType.GetContactCollection(this.ContactTypeID); }
		public static AdventureWorks.ContactCollection GetContactCollection(int varContactTypeID)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [Person].[Contact] INNER JOIN [StoreContact] ON [Contact].[ContactID] = [StoreContact].[ContactID] WHERE [StoreContact].[ContactTypeID] = @ContactTypeID", ContactType.Schema.Provider.Name);
			cmd.AddParameter("@ContactTypeID", varContactTypeID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			ContactCollection coll = new ContactCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveContactMap(int varContactTypeID, ContactCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [StoreContact] WHERE [StoreContact].[ContactTypeID] = @ContactTypeID", ContactType.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactTypeID", varContactTypeID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Contact item in items)
			{
				StoreContact varStoreContact = new StoreContact();
				varStoreContact.SetColumnValue("ContactTypeID", varContactTypeID);
				varStoreContact.SetColumnValue("ContactID", item.GetPrimaryKeyValue());
				varStoreContact.Save();
			}
		}
		public static void SaveContactMap(int varContactTypeID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [StoreContact] WHERE [StoreContact].[ContactTypeID] = @ContactTypeID", ContactType.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactTypeID", varContactTypeID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					StoreContact varStoreContact = new StoreContact();
					varStoreContact.SetColumnValue("ContactTypeID", varContactTypeID);
					varStoreContact.SetColumnValue("ContactID", l.Value);
					varStoreContact.Save();
				}
			}
		}
		public static void SaveContactMap(int varContactTypeID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [StoreContact] WHERE [StoreContact].[ContactTypeID] = @ContactTypeID", ContactType.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactTypeID", varContactTypeID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				StoreContact varStoreContact = new StoreContact();
				varStoreContact.SetColumnValue("ContactTypeID", varContactTypeID);
				varStoreContact.SetColumnValue("ContactID", item);
				varStoreContact.Save();
			}
		}
		
		public static void DeleteContactMap(int varContactTypeID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [StoreContact] WHERE [StoreContact].[ContactTypeID] = @ContactTypeID", ContactType.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactTypeID", varContactTypeID, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		 
		public AdventureWorks.StoreCollection GetStoreCollection() { return ContactType.GetStoreCollection(this.ContactTypeID); }
		public static AdventureWorks.StoreCollection GetStoreCollection(int varContactTypeID)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [Sales].[Store] INNER JOIN [StoreContact] ON [Store].[CustomerID] = [StoreContact].[CustomerID] WHERE [StoreContact].[ContactTypeID] = @ContactTypeID", ContactType.Schema.Provider.Name);
			cmd.AddParameter("@ContactTypeID", varContactTypeID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			StoreCollection coll = new StoreCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveStoreMap(int varContactTypeID, StoreCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [StoreContact] WHERE [StoreContact].[ContactTypeID] = @ContactTypeID", ContactType.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactTypeID", varContactTypeID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Store item in items)
			{
				StoreContact varStoreContact = new StoreContact();
				varStoreContact.SetColumnValue("ContactTypeID", varContactTypeID);
				varStoreContact.SetColumnValue("CustomerID", item.GetPrimaryKeyValue());
				varStoreContact.Save();
			}
		}
		public static void SaveStoreMap(int varContactTypeID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [StoreContact] WHERE [StoreContact].[ContactTypeID] = @ContactTypeID", ContactType.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactTypeID", varContactTypeID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					StoreContact varStoreContact = new StoreContact();
					varStoreContact.SetColumnValue("ContactTypeID", varContactTypeID);
					varStoreContact.SetColumnValue("CustomerID", l.Value);
					varStoreContact.Save();
				}
			}
		}
		public static void SaveStoreMap(int varContactTypeID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [StoreContact] WHERE [StoreContact].[ContactTypeID] = @ContactTypeID", ContactType.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactTypeID", varContactTypeID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				StoreContact varStoreContact = new StoreContact();
				varStoreContact.SetColumnValue("ContactTypeID", varContactTypeID);
				varStoreContact.SetColumnValue("CustomerID", item);
				varStoreContact.Save();
			}
		}
		
		public static void DeleteStoreMap(int varContactTypeID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [StoreContact] WHERE [StoreContact].[ContactTypeID] = @ContactTypeID", ContactType.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactTypeID", varContactTypeID, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		 
		public AdventureWorks.VendorCollection GetVendorCollection() { return ContactType.GetVendorCollection(this.ContactTypeID); }
		public static AdventureWorks.VendorCollection GetVendorCollection(int varContactTypeID)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [Purchasing].[Vendor] INNER JOIN [VendorContact] ON [Vendor].[VendorID] = [VendorContact].[VendorID] WHERE [VendorContact].[ContactTypeID] = @ContactTypeID", ContactType.Schema.Provider.Name);
			cmd.AddParameter("@ContactTypeID", varContactTypeID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			VendorCollection coll = new VendorCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveVendorMap(int varContactTypeID, VendorCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [VendorContact] WHERE [VendorContact].[ContactTypeID] = @ContactTypeID", ContactType.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactTypeID", varContactTypeID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Vendor item in items)
			{
				VendorContact varVendorContact = new VendorContact();
				varVendorContact.SetColumnValue("ContactTypeID", varContactTypeID);
				varVendorContact.SetColumnValue("VendorID", item.GetPrimaryKeyValue());
				varVendorContact.Save();
			}
		}
		public static void SaveVendorMap(int varContactTypeID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [VendorContact] WHERE [VendorContact].[ContactTypeID] = @ContactTypeID", ContactType.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactTypeID", varContactTypeID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					VendorContact varVendorContact = new VendorContact();
					varVendorContact.SetColumnValue("ContactTypeID", varContactTypeID);
					varVendorContact.SetColumnValue("VendorID", l.Value);
					varVendorContact.Save();
				}
			}
		}
		public static void SaveVendorMap(int varContactTypeID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [VendorContact] WHERE [VendorContact].[ContactTypeID] = @ContactTypeID", ContactType.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactTypeID", varContactTypeID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				VendorContact varVendorContact = new VendorContact();
				varVendorContact.SetColumnValue("ContactTypeID", varContactTypeID);
				varVendorContact.SetColumnValue("VendorID", item);
				varVendorContact.Save();
			}
		}
		
		public static void DeleteVendorMap(int varContactTypeID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [VendorContact] WHERE [VendorContact].[ContactTypeID] = @ContactTypeID", ContactType.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactTypeID", varContactTypeID, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		#endregion
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varName,DateTime varModifiedDate)
		{
			ContactType item = new ContactType();
			
			item.Name = varName;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varContactTypeID,string varName,DateTime varModifiedDate)
		{
			ContactType item = new ContactType();
			
				item.ContactTypeID = varContactTypeID;
			
				item.Name = varName;
			
				item.ModifiedDate = varModifiedDate;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn ContactTypeIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NameColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedDateColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string ContactTypeID = @"ContactTypeID";
			 public static string Name = @"Name";
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
