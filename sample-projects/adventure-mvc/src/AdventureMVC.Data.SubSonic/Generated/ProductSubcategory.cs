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
	/// Strongly-typed collection for the ProductSubcategory class.
	/// </summary>
    [Serializable]
	public partial class ProductSubcategoryCollection : ActiveList<ProductSubcategory, ProductSubcategoryCollection>
	{	   
		public ProductSubcategoryCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ProductSubcategoryCollection</returns>
		public ProductSubcategoryCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ProductSubcategory o = this[i];
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
	/// This is an ActiveRecord class which wraps the ProductSubcategory table.
	/// </summary>
	[Serializable]
	public partial class ProductSubcategory : ActiveRecord<ProductSubcategory>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ProductSubcategory()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ProductSubcategory(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ProductSubcategory(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ProductSubcategory(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ProductSubcategory", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Production";
				//columns
				
				TableSchema.TableColumn colvarProductSubcategoryID = new TableSchema.TableColumn(schema);
				colvarProductSubcategoryID.ColumnName = "ProductSubcategoryID";
				colvarProductSubcategoryID.DataType = DbType.Int32;
				colvarProductSubcategoryID.MaxLength = 0;
				colvarProductSubcategoryID.AutoIncrement = true;
				colvarProductSubcategoryID.IsNullable = false;
				colvarProductSubcategoryID.IsPrimaryKey = true;
				colvarProductSubcategoryID.IsForeignKey = false;
				colvarProductSubcategoryID.IsReadOnly = false;
				colvarProductSubcategoryID.DefaultSetting = @"";
				colvarProductSubcategoryID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProductSubcategoryID);
				
				TableSchema.TableColumn colvarProductCategoryID = new TableSchema.TableColumn(schema);
				colvarProductCategoryID.ColumnName = "ProductCategoryID";
				colvarProductCategoryID.DataType = DbType.Int32;
				colvarProductCategoryID.MaxLength = 0;
				colvarProductCategoryID.AutoIncrement = false;
				colvarProductCategoryID.IsNullable = false;
				colvarProductCategoryID.IsPrimaryKey = false;
				colvarProductCategoryID.IsForeignKey = true;
				colvarProductCategoryID.IsReadOnly = false;
				colvarProductCategoryID.DefaultSetting = @"";
				
					colvarProductCategoryID.ForeignKeyTableName = "ProductCategory";
				schema.Columns.Add(colvarProductCategoryID);
				
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
				DataService.Providers["AdventureWorks"].AddSchema("ProductSubcategory",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("ProductSubcategoryID")]
		[Bindable(true)]
		public int ProductSubcategoryID 
		{
			get { return GetColumnValue<int>(Columns.ProductSubcategoryID); }
			set { SetColumnValue(Columns.ProductSubcategoryID, value); }
		}
		  
		[XmlAttribute("ProductCategoryID")]
		[Bindable(true)]
		public int ProductCategoryID 
		{
			get { return GetColumnValue<int>(Columns.ProductCategoryID); }
			set { SetColumnValue(Columns.ProductCategoryID, value); }
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
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
		
		public AdventureWorks.ProductCollection ProductRecords()
		{
			return new AdventureWorks.ProductCollection().Where(Product.Columns.ProductSubcategoryID, ProductSubcategoryID).Load();
		}
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a ProductCategory ActiveRecord object related to this ProductSubcategory
		/// 
		/// </summary>
		public AdventureWorks.ProductCategory ProductCategory
		{
			get { return AdventureWorks.ProductCategory.FetchByID(this.ProductCategoryID); }
			set { SetColumnValue("ProductCategoryID", value.ProductCategoryID); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varProductCategoryID,string varName,Guid varRowguid,DateTime varModifiedDate)
		{
			ProductSubcategory item = new ProductSubcategory();
			
			item.ProductCategoryID = varProductCategoryID;
			
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
		public static void Update(int varProductSubcategoryID,int varProductCategoryID,string varName,Guid varRowguid,DateTime varModifiedDate)
		{
			ProductSubcategory item = new ProductSubcategory();
			
				item.ProductSubcategoryID = varProductSubcategoryID;
			
				item.ProductCategoryID = varProductCategoryID;
			
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
        
        
        public static TableSchema.TableColumn ProductSubcategoryIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ProductCategoryIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn NameColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn RowguidColumn
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
			 public static string ProductSubcategoryID = @"ProductSubcategoryID";
			 public static string ProductCategoryID = @"ProductCategoryID";
			 public static string Name = @"Name";
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
