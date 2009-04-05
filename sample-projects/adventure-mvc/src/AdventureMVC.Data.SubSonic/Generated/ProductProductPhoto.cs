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
	/// Strongly-typed collection for the ProductProductPhoto class.
	/// </summary>
    [Serializable]
	public partial class ProductProductPhotoCollection : ActiveList<ProductProductPhoto, ProductProductPhotoCollection>
	{	   
		public ProductProductPhotoCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ProductProductPhotoCollection</returns>
		public ProductProductPhotoCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ProductProductPhoto o = this[i];
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
	/// This is an ActiveRecord class which wraps the ProductProductPhoto table.
	/// </summary>
	[Serializable]
	public partial class ProductProductPhoto : ActiveRecord<ProductProductPhoto>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ProductProductPhoto()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ProductProductPhoto(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ProductProductPhoto(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ProductProductPhoto(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ProductProductPhoto", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Production";
				//columns
				
				TableSchema.TableColumn colvarProductID = new TableSchema.TableColumn(schema);
				colvarProductID.ColumnName = "ProductID";
				colvarProductID.DataType = DbType.Int32;
				colvarProductID.MaxLength = 0;
				colvarProductID.AutoIncrement = false;
				colvarProductID.IsNullable = false;
				colvarProductID.IsPrimaryKey = true;
				colvarProductID.IsForeignKey = true;
				colvarProductID.IsReadOnly = false;
				colvarProductID.DefaultSetting = @"";
				
					colvarProductID.ForeignKeyTableName = "Product";
				schema.Columns.Add(colvarProductID);
				
				TableSchema.TableColumn colvarProductPhotoID = new TableSchema.TableColumn(schema);
				colvarProductPhotoID.ColumnName = "ProductPhotoID";
				colvarProductPhotoID.DataType = DbType.Int32;
				colvarProductPhotoID.MaxLength = 0;
				colvarProductPhotoID.AutoIncrement = false;
				colvarProductPhotoID.IsNullable = false;
				colvarProductPhotoID.IsPrimaryKey = true;
				colvarProductPhotoID.IsForeignKey = true;
				colvarProductPhotoID.IsReadOnly = false;
				colvarProductPhotoID.DefaultSetting = @"";
				
					colvarProductPhotoID.ForeignKeyTableName = "ProductPhoto";
				schema.Columns.Add(colvarProductPhotoID);
				
				TableSchema.TableColumn colvarPrimary = new TableSchema.TableColumn(schema);
				colvarPrimary.ColumnName = "Primary";
				colvarPrimary.DataType = DbType.Boolean;
				colvarPrimary.MaxLength = 0;
				colvarPrimary.AutoIncrement = false;
				colvarPrimary.IsNullable = false;
				colvarPrimary.IsPrimaryKey = false;
				colvarPrimary.IsForeignKey = false;
				colvarPrimary.IsReadOnly = false;
				
						colvarPrimary.DefaultSetting = @"((0))";
				colvarPrimary.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPrimary);
				
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
				DataService.Providers["AdventureWorks"].AddSchema("ProductProductPhoto",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("ProductID")]
		[Bindable(true)]
		public int ProductID 
		{
			get { return GetColumnValue<int>(Columns.ProductID); }
			set { SetColumnValue(Columns.ProductID, value); }
		}
		  
		[XmlAttribute("ProductPhotoID")]
		[Bindable(true)]
		public int ProductPhotoID 
		{
			get { return GetColumnValue<int>(Columns.ProductPhotoID); }
			set { SetColumnValue(Columns.ProductPhotoID, value); }
		}
		  
		[XmlAttribute("Primary")]
		[Bindable(true)]
		public bool Primary 
		{
			get { return GetColumnValue<bool>(Columns.Primary); }
			set { SetColumnValue(Columns.Primary, value); }
		}
		  
		[XmlAttribute("ModifiedDate")]
		[Bindable(true)]
		public DateTime ModifiedDate 
		{
			get { return GetColumnValue<DateTime>(Columns.ModifiedDate); }
			set { SetColumnValue(Columns.ModifiedDate, value); }
		}
		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Product ActiveRecord object related to this ProductProductPhoto
		/// 
		/// </summary>
		public AdventureWorks.Product Product
		{
			get { return AdventureWorks.Product.FetchByID(this.ProductID); }
			set { SetColumnValue("ProductID", value.ProductID); }
		}
		
		
		/// <summary>
		/// Returns a ProductPhoto ActiveRecord object related to this ProductProductPhoto
		/// 
		/// </summary>
		public AdventureWorks.ProductPhoto ProductPhoto
		{
			get { return AdventureWorks.ProductPhoto.FetchByID(this.ProductPhotoID); }
			set { SetColumnValue("ProductPhotoID", value.ProductPhotoID); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varProductID,int varProductPhotoID,bool varPrimary,DateTime varModifiedDate)
		{
			ProductProductPhoto item = new ProductProductPhoto();
			
			item.ProductID = varProductID;
			
			item.ProductPhotoID = varProductPhotoID;
			
			item.Primary = varPrimary;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varProductID,int varProductPhotoID,bool varPrimary,DateTime varModifiedDate)
		{
			ProductProductPhoto item = new ProductProductPhoto();
			
				item.ProductID = varProductID;
			
				item.ProductPhotoID = varProductPhotoID;
			
				item.Primary = varPrimary;
			
				item.ModifiedDate = varModifiedDate;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn ProductIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ProductPhotoIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn PrimaryColumn
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
			 public static string ProductID = @"ProductID";
			 public static string ProductPhotoID = @"ProductPhotoID";
			 public static string Primary = @"Primary";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
