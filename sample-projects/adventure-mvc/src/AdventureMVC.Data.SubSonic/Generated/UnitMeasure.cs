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
	/// Strongly-typed collection for the UnitMeasure class.
	/// </summary>
    [Serializable]
	public partial class UnitMeasureCollection : ActiveList<UnitMeasure, UnitMeasureCollection>
	{	   
		public UnitMeasureCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>UnitMeasureCollection</returns>
		public UnitMeasureCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                UnitMeasure o = this[i];
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
	/// This is an ActiveRecord class which wraps the UnitMeasure table.
	/// </summary>
	[Serializable]
	public partial class UnitMeasure : ActiveRecord<UnitMeasure>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public UnitMeasure()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public UnitMeasure(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public UnitMeasure(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public UnitMeasure(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("UnitMeasure", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Production";
				//columns
				
				TableSchema.TableColumn colvarUnitMeasureCode = new TableSchema.TableColumn(schema);
				colvarUnitMeasureCode.ColumnName = "UnitMeasureCode";
				colvarUnitMeasureCode.DataType = DbType.String;
				colvarUnitMeasureCode.MaxLength = 3;
				colvarUnitMeasureCode.AutoIncrement = false;
				colvarUnitMeasureCode.IsNullable = false;
				colvarUnitMeasureCode.IsPrimaryKey = true;
				colvarUnitMeasureCode.IsForeignKey = false;
				colvarUnitMeasureCode.IsReadOnly = false;
				colvarUnitMeasureCode.DefaultSetting = @"";
				colvarUnitMeasureCode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUnitMeasureCode);
				
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
				DataService.Providers["AdventureWorks"].AddSchema("UnitMeasure",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("UnitMeasureCode")]
		[Bindable(true)]
		public string UnitMeasureCode 
		{
			get { return GetColumnValue<string>(Columns.UnitMeasureCode); }
			set { SetColumnValue(Columns.UnitMeasureCode, value); }
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
        
		
		public AdventureWorks.BillOfMaterialCollection BillOfMaterials()
		{
			return new AdventureWorks.BillOfMaterialCollection().Where(BillOfMaterial.Columns.UnitMeasureCode, UnitMeasureCode).Load();
		}
		public AdventureWorks.ProductCollection ProductRecords()
		{
			return new AdventureWorks.ProductCollection().Where(Product.Columns.SizeUnitMeasureCode, UnitMeasureCode).Load();
		}
		public AdventureWorks.ProductCollection ProductRecordsFromUnitMeasure()
		{
			return new AdventureWorks.ProductCollection().Where(Product.Columns.WeightUnitMeasureCode, UnitMeasureCode).Load();
		}
		public AdventureWorks.ProductVendorCollection ProductVendorRecords()
		{
			return new AdventureWorks.ProductVendorCollection().Where(ProductVendor.Columns.UnitMeasureCode, UnitMeasureCode).Load();
		}
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		#region Many To Many Helpers
		
		 
		public AdventureWorks.ProductCollection GetProductCollection() { return UnitMeasure.GetProductCollection(this.UnitMeasureCode); }
		public static AdventureWorks.ProductCollection GetProductCollection(string varUnitMeasureCode)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [Production].[Product] INNER JOIN [ProductVendor] ON [Product].[ProductID] = [ProductVendor].[ProductID] WHERE [ProductVendor].[UnitMeasureCode] = @UnitMeasureCode", UnitMeasure.Schema.Provider.Name);
			cmd.AddParameter("@UnitMeasureCode", varUnitMeasureCode, DbType.String);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			ProductCollection coll = new ProductCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveProductMap(string varUnitMeasureCode, ProductCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductVendor] WHERE [ProductVendor].[UnitMeasureCode] = @UnitMeasureCode", UnitMeasure.Schema.Provider.Name);
			cmdDel.AddParameter("@UnitMeasureCode", varUnitMeasureCode, DbType.String);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Product item in items)
			{
				ProductVendor varProductVendor = new ProductVendor();
				varProductVendor.SetColumnValue("UnitMeasureCode", varUnitMeasureCode);
				varProductVendor.SetColumnValue("ProductID", item.GetPrimaryKeyValue());
				varProductVendor.Save();
			}
		}
		public static void SaveProductMap(string varUnitMeasureCode, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductVendor] WHERE [ProductVendor].[UnitMeasureCode] = @UnitMeasureCode", UnitMeasure.Schema.Provider.Name);
			cmdDel.AddParameter("@UnitMeasureCode", varUnitMeasureCode, DbType.String);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					ProductVendor varProductVendor = new ProductVendor();
					varProductVendor.SetColumnValue("UnitMeasureCode", varUnitMeasureCode);
					varProductVendor.SetColumnValue("ProductID", l.Value);
					varProductVendor.Save();
				}
			}
		}
		public static void SaveProductMap(string varUnitMeasureCode , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductVendor] WHERE [ProductVendor].[UnitMeasureCode] = @UnitMeasureCode", UnitMeasure.Schema.Provider.Name);
			cmdDel.AddParameter("@UnitMeasureCode", varUnitMeasureCode, DbType.String);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				ProductVendor varProductVendor = new ProductVendor();
				varProductVendor.SetColumnValue("UnitMeasureCode", varUnitMeasureCode);
				varProductVendor.SetColumnValue("ProductID", item);
				varProductVendor.Save();
			}
		}
		
		public static void DeleteProductMap(string varUnitMeasureCode) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductVendor] WHERE [ProductVendor].[UnitMeasureCode] = @UnitMeasureCode", UnitMeasure.Schema.Provider.Name);
			cmdDel.AddParameter("@UnitMeasureCode", varUnitMeasureCode, DbType.String);
			DataService.ExecuteQuery(cmdDel);
		}
		
		 
		public AdventureWorks.VendorCollection GetVendorCollection() { return UnitMeasure.GetVendorCollection(this.UnitMeasureCode); }
		public static AdventureWorks.VendorCollection GetVendorCollection(string varUnitMeasureCode)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [Purchasing].[Vendor] INNER JOIN [ProductVendor] ON [Vendor].[VendorID] = [ProductVendor].[VendorID] WHERE [ProductVendor].[UnitMeasureCode] = @UnitMeasureCode", UnitMeasure.Schema.Provider.Name);
			cmd.AddParameter("@UnitMeasureCode", varUnitMeasureCode, DbType.String);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			VendorCollection coll = new VendorCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveVendorMap(string varUnitMeasureCode, VendorCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductVendor] WHERE [ProductVendor].[UnitMeasureCode] = @UnitMeasureCode", UnitMeasure.Schema.Provider.Name);
			cmdDel.AddParameter("@UnitMeasureCode", varUnitMeasureCode, DbType.String);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Vendor item in items)
			{
				ProductVendor varProductVendor = new ProductVendor();
				varProductVendor.SetColumnValue("UnitMeasureCode", varUnitMeasureCode);
				varProductVendor.SetColumnValue("VendorID", item.GetPrimaryKeyValue());
				varProductVendor.Save();
			}
		}
		public static void SaveVendorMap(string varUnitMeasureCode, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductVendor] WHERE [ProductVendor].[UnitMeasureCode] = @UnitMeasureCode", UnitMeasure.Schema.Provider.Name);
			cmdDel.AddParameter("@UnitMeasureCode", varUnitMeasureCode, DbType.String);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					ProductVendor varProductVendor = new ProductVendor();
					varProductVendor.SetColumnValue("UnitMeasureCode", varUnitMeasureCode);
					varProductVendor.SetColumnValue("VendorID", l.Value);
					varProductVendor.Save();
				}
			}
		}
		public static void SaveVendorMap(string varUnitMeasureCode , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductVendor] WHERE [ProductVendor].[UnitMeasureCode] = @UnitMeasureCode", UnitMeasure.Schema.Provider.Name);
			cmdDel.AddParameter("@UnitMeasureCode", varUnitMeasureCode, DbType.String);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				ProductVendor varProductVendor = new ProductVendor();
				varProductVendor.SetColumnValue("UnitMeasureCode", varUnitMeasureCode);
				varProductVendor.SetColumnValue("VendorID", item);
				varProductVendor.Save();
			}
		}
		
		public static void DeleteVendorMap(string varUnitMeasureCode) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductVendor] WHERE [ProductVendor].[UnitMeasureCode] = @UnitMeasureCode", UnitMeasure.Schema.Provider.Name);
			cmdDel.AddParameter("@UnitMeasureCode", varUnitMeasureCode, DbType.String);
			DataService.ExecuteQuery(cmdDel);
		}
		
		#endregion
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varUnitMeasureCode,string varName,DateTime varModifiedDate)
		{
			UnitMeasure item = new UnitMeasure();
			
			item.UnitMeasureCode = varUnitMeasureCode;
			
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
		public static void Update(string varUnitMeasureCode,string varName,DateTime varModifiedDate)
		{
			UnitMeasure item = new UnitMeasure();
			
				item.UnitMeasureCode = varUnitMeasureCode;
			
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
        
        
        public static TableSchema.TableColumn UnitMeasureCodeColumn
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
			 public static string UnitMeasureCode = @"UnitMeasureCode";
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
