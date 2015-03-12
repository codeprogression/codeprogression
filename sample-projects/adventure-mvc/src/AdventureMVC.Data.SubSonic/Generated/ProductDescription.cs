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
	/// Strongly-typed collection for the ProductDescription class.
	/// </summary>
    [Serializable]
	public partial class ProductDescriptionCollection : ActiveList<ProductDescription, ProductDescriptionCollection>
	{	   
		public ProductDescriptionCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ProductDescriptionCollection</returns>
		public ProductDescriptionCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ProductDescription o = this[i];
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
	/// This is an ActiveRecord class which wraps the ProductDescription table.
	/// </summary>
	[Serializable]
	public partial class ProductDescription : ActiveRecord<ProductDescription>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ProductDescription()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ProductDescription(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ProductDescription(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ProductDescription(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ProductDescription", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Production";
				//columns
				
				TableSchema.TableColumn colvarProductDescriptionID = new TableSchema.TableColumn(schema);
				colvarProductDescriptionID.ColumnName = "ProductDescriptionID";
				colvarProductDescriptionID.DataType = DbType.Int32;
				colvarProductDescriptionID.MaxLength = 0;
				colvarProductDescriptionID.AutoIncrement = true;
				colvarProductDescriptionID.IsNullable = false;
				colvarProductDescriptionID.IsPrimaryKey = true;
				colvarProductDescriptionID.IsForeignKey = false;
				colvarProductDescriptionID.IsReadOnly = false;
				colvarProductDescriptionID.DefaultSetting = @"";
				colvarProductDescriptionID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProductDescriptionID);
				
				TableSchema.TableColumn colvarDescription = new TableSchema.TableColumn(schema);
				colvarDescription.ColumnName = "Description";
				colvarDescription.DataType = DbType.String;
				colvarDescription.MaxLength = 400;
				colvarDescription.AutoIncrement = false;
				colvarDescription.IsNullable = false;
				colvarDescription.IsPrimaryKey = false;
				colvarDescription.IsForeignKey = false;
				colvarDescription.IsReadOnly = false;
				colvarDescription.DefaultSetting = @"";
				colvarDescription.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescription);
				
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
				DataService.Providers["AdventureWorks"].AddSchema("ProductDescription",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("ProductDescriptionID")]
		[Bindable(true)]
		public int ProductDescriptionID 
		{
			get { return GetColumnValue<int>(Columns.ProductDescriptionID); }
			set { SetColumnValue(Columns.ProductDescriptionID, value); }
		}
		  
		[XmlAttribute("Description")]
		[Bindable(true)]
		public string Description 
		{
			get { return GetColumnValue<string>(Columns.Description); }
			set { SetColumnValue(Columns.Description, value); }
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
        
		
		public AdventureWorks.ProductModelProductDescriptionCultureCollection ProductModelProductDescriptionCultureRecords()
		{
			return new AdventureWorks.ProductModelProductDescriptionCultureCollection().Where(ProductModelProductDescriptionCulture.Columns.ProductDescriptionID, ProductDescriptionID).Load();
		}
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		#region Many To Many Helpers
		
		 
		public AdventureWorks.CultureCollection GetCultureCollection() { return ProductDescription.GetCultureCollection(this.ProductDescriptionID); }
		public static AdventureWorks.CultureCollection GetCultureCollection(int varProductDescriptionID)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [Production].[Culture] INNER JOIN [ProductModelProductDescriptionCulture] ON [Culture].[CultureID] = [ProductModelProductDescriptionCulture].[CultureID] WHERE [ProductModelProductDescriptionCulture].[ProductDescriptionID] = @ProductDescriptionID", ProductDescription.Schema.Provider.Name);
			cmd.AddParameter("@ProductDescriptionID", varProductDescriptionID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			CultureCollection coll = new CultureCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveCultureMap(int varProductDescriptionID, CultureCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductModelProductDescriptionCulture] WHERE [ProductModelProductDescriptionCulture].[ProductDescriptionID] = @ProductDescriptionID", ProductDescription.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductDescriptionID", varProductDescriptionID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Culture item in items)
			{
				ProductModelProductDescriptionCulture varProductModelProductDescriptionCulture = new ProductModelProductDescriptionCulture();
				varProductModelProductDescriptionCulture.SetColumnValue("ProductDescriptionID", varProductDescriptionID);
				varProductModelProductDescriptionCulture.SetColumnValue("CultureID", item.GetPrimaryKeyValue());
				varProductModelProductDescriptionCulture.Save();
			}
		}
		public static void SaveCultureMap(int varProductDescriptionID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductModelProductDescriptionCulture] WHERE [ProductModelProductDescriptionCulture].[ProductDescriptionID] = @ProductDescriptionID", ProductDescription.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductDescriptionID", varProductDescriptionID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					ProductModelProductDescriptionCulture varProductModelProductDescriptionCulture = new ProductModelProductDescriptionCulture();
					varProductModelProductDescriptionCulture.SetColumnValue("ProductDescriptionID", varProductDescriptionID);
					varProductModelProductDescriptionCulture.SetColumnValue("CultureID", l.Value);
					varProductModelProductDescriptionCulture.Save();
				}
			}
		}
		public static void SaveCultureMap(int varProductDescriptionID , string[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductModelProductDescriptionCulture] WHERE [ProductModelProductDescriptionCulture].[ProductDescriptionID] = @ProductDescriptionID", ProductDescription.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductDescriptionID", varProductDescriptionID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (string item in itemList) 
			{
				ProductModelProductDescriptionCulture varProductModelProductDescriptionCulture = new ProductModelProductDescriptionCulture();
				varProductModelProductDescriptionCulture.SetColumnValue("ProductDescriptionID", varProductDescriptionID);
				varProductModelProductDescriptionCulture.SetColumnValue("CultureID", item);
				varProductModelProductDescriptionCulture.Save();
			}
		}
		
		public static void DeleteCultureMap(int varProductDescriptionID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductModelProductDescriptionCulture] WHERE [ProductModelProductDescriptionCulture].[ProductDescriptionID] = @ProductDescriptionID", ProductDescription.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductDescriptionID", varProductDescriptionID, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		 
		public AdventureWorks.ProductModelCollection GetProductModelCollection() { return ProductDescription.GetProductModelCollection(this.ProductDescriptionID); }
		public static AdventureWorks.ProductModelCollection GetProductModelCollection(int varProductDescriptionID)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [Production].[ProductModel] INNER JOIN [ProductModelProductDescriptionCulture] ON [ProductModel].[ProductModelID] = [ProductModelProductDescriptionCulture].[ProductModelID] WHERE [ProductModelProductDescriptionCulture].[ProductDescriptionID] = @ProductDescriptionID", ProductDescription.Schema.Provider.Name);
			cmd.AddParameter("@ProductDescriptionID", varProductDescriptionID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			ProductModelCollection coll = new ProductModelCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveProductModelMap(int varProductDescriptionID, ProductModelCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductModelProductDescriptionCulture] WHERE [ProductModelProductDescriptionCulture].[ProductDescriptionID] = @ProductDescriptionID", ProductDescription.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductDescriptionID", varProductDescriptionID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (ProductModel item in items)
			{
				ProductModelProductDescriptionCulture varProductModelProductDescriptionCulture = new ProductModelProductDescriptionCulture();
				varProductModelProductDescriptionCulture.SetColumnValue("ProductDescriptionID", varProductDescriptionID);
				varProductModelProductDescriptionCulture.SetColumnValue("ProductModelID", item.GetPrimaryKeyValue());
				varProductModelProductDescriptionCulture.Save();
			}
		}
		public static void SaveProductModelMap(int varProductDescriptionID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductModelProductDescriptionCulture] WHERE [ProductModelProductDescriptionCulture].[ProductDescriptionID] = @ProductDescriptionID", ProductDescription.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductDescriptionID", varProductDescriptionID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					ProductModelProductDescriptionCulture varProductModelProductDescriptionCulture = new ProductModelProductDescriptionCulture();
					varProductModelProductDescriptionCulture.SetColumnValue("ProductDescriptionID", varProductDescriptionID);
					varProductModelProductDescriptionCulture.SetColumnValue("ProductModelID", l.Value);
					varProductModelProductDescriptionCulture.Save();
				}
			}
		}
		public static void SaveProductModelMap(int varProductDescriptionID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductModelProductDescriptionCulture] WHERE [ProductModelProductDescriptionCulture].[ProductDescriptionID] = @ProductDescriptionID", ProductDescription.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductDescriptionID", varProductDescriptionID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				ProductModelProductDescriptionCulture varProductModelProductDescriptionCulture = new ProductModelProductDescriptionCulture();
				varProductModelProductDescriptionCulture.SetColumnValue("ProductDescriptionID", varProductDescriptionID);
				varProductModelProductDescriptionCulture.SetColumnValue("ProductModelID", item);
				varProductModelProductDescriptionCulture.Save();
			}
		}
		
		public static void DeleteProductModelMap(int varProductDescriptionID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductModelProductDescriptionCulture] WHERE [ProductModelProductDescriptionCulture].[ProductDescriptionID] = @ProductDescriptionID", ProductDescription.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductDescriptionID", varProductDescriptionID, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		#endregion
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varDescription,Guid varRowguid,DateTime varModifiedDate)
		{
			ProductDescription item = new ProductDescription();
			
			item.Description = varDescription;
			
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
		public static void Update(int varProductDescriptionID,string varDescription,Guid varRowguid,DateTime varModifiedDate)
		{
			ProductDescription item = new ProductDescription();
			
				item.ProductDescriptionID = varProductDescriptionID;
			
				item.Description = varDescription;
			
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
        
        
        public static TableSchema.TableColumn ProductDescriptionIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn DescriptionColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn RowguidColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedDateColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string ProductDescriptionID = @"ProductDescriptionID";
			 public static string Description = @"Description";
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
