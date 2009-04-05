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
	/// Strongly-typed collection for the ProductModelProductDescriptionCulture class.
	/// </summary>
    [Serializable]
	public partial class ProductModelProductDescriptionCultureCollection : ActiveList<ProductModelProductDescriptionCulture, ProductModelProductDescriptionCultureCollection>
	{	   
		public ProductModelProductDescriptionCultureCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ProductModelProductDescriptionCultureCollection</returns>
		public ProductModelProductDescriptionCultureCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ProductModelProductDescriptionCulture o = this[i];
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
	/// This is an ActiveRecord class which wraps the ProductModelProductDescriptionCulture table.
	/// </summary>
	[Serializable]
	public partial class ProductModelProductDescriptionCulture : ActiveRecord<ProductModelProductDescriptionCulture>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ProductModelProductDescriptionCulture()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ProductModelProductDescriptionCulture(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ProductModelProductDescriptionCulture(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ProductModelProductDescriptionCulture(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ProductModelProductDescriptionCulture", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Production";
				//columns
				
				TableSchema.TableColumn colvarProductModelID = new TableSchema.TableColumn(schema);
				colvarProductModelID.ColumnName = "ProductModelID";
				colvarProductModelID.DataType = DbType.Int32;
				colvarProductModelID.MaxLength = 0;
				colvarProductModelID.AutoIncrement = false;
				colvarProductModelID.IsNullable = false;
				colvarProductModelID.IsPrimaryKey = true;
				colvarProductModelID.IsForeignKey = true;
				colvarProductModelID.IsReadOnly = false;
				colvarProductModelID.DefaultSetting = @"";
				
					colvarProductModelID.ForeignKeyTableName = "ProductModel";
				schema.Columns.Add(colvarProductModelID);
				
				TableSchema.TableColumn colvarProductDescriptionID = new TableSchema.TableColumn(schema);
				colvarProductDescriptionID.ColumnName = "ProductDescriptionID";
				colvarProductDescriptionID.DataType = DbType.Int32;
				colvarProductDescriptionID.MaxLength = 0;
				colvarProductDescriptionID.AutoIncrement = false;
				colvarProductDescriptionID.IsNullable = false;
				colvarProductDescriptionID.IsPrimaryKey = true;
				colvarProductDescriptionID.IsForeignKey = true;
				colvarProductDescriptionID.IsReadOnly = false;
				colvarProductDescriptionID.DefaultSetting = @"";
				
					colvarProductDescriptionID.ForeignKeyTableName = "ProductDescription";
				schema.Columns.Add(colvarProductDescriptionID);
				
				TableSchema.TableColumn colvarCultureID = new TableSchema.TableColumn(schema);
				colvarCultureID.ColumnName = "CultureID";
				colvarCultureID.DataType = DbType.String;
				colvarCultureID.MaxLength = 6;
				colvarCultureID.AutoIncrement = false;
				colvarCultureID.IsNullable = false;
				colvarCultureID.IsPrimaryKey = true;
				colvarCultureID.IsForeignKey = true;
				colvarCultureID.IsReadOnly = false;
				colvarCultureID.DefaultSetting = @"";
				
					colvarCultureID.ForeignKeyTableName = "Culture";
				schema.Columns.Add(colvarCultureID);
				
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
				DataService.Providers["AdventureWorks"].AddSchema("ProductModelProductDescriptionCulture",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("ProductModelID")]
		[Bindable(true)]
		public int ProductModelID 
		{
			get { return GetColumnValue<int>(Columns.ProductModelID); }
			set { SetColumnValue(Columns.ProductModelID, value); }
		}
		  
		[XmlAttribute("ProductDescriptionID")]
		[Bindable(true)]
		public int ProductDescriptionID 
		{
			get { return GetColumnValue<int>(Columns.ProductDescriptionID); }
			set { SetColumnValue(Columns.ProductDescriptionID, value); }
		}
		  
		[XmlAttribute("CultureID")]
		[Bindable(true)]
		public string CultureID 
		{
			get { return GetColumnValue<string>(Columns.CultureID); }
			set { SetColumnValue(Columns.CultureID, value); }
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
		/// Returns a Culture ActiveRecord object related to this ProductModelProductDescriptionCulture
		/// 
		/// </summary>
		public AdventureWorks.Culture Culture
		{
			get { return AdventureWorks.Culture.FetchByID(this.CultureID); }
			set { SetColumnValue("CultureID", value.CultureID); }
		}
		
		
		/// <summary>
		/// Returns a ProductDescription ActiveRecord object related to this ProductModelProductDescriptionCulture
		/// 
		/// </summary>
		public AdventureWorks.ProductDescription ProductDescription
		{
			get { return AdventureWorks.ProductDescription.FetchByID(this.ProductDescriptionID); }
			set { SetColumnValue("ProductDescriptionID", value.ProductDescriptionID); }
		}
		
		
		/// <summary>
		/// Returns a ProductModel ActiveRecord object related to this ProductModelProductDescriptionCulture
		/// 
		/// </summary>
		public AdventureWorks.ProductModel ProductModel
		{
			get { return AdventureWorks.ProductModel.FetchByID(this.ProductModelID); }
			set { SetColumnValue("ProductModelID", value.ProductModelID); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varProductModelID,int varProductDescriptionID,string varCultureID,DateTime varModifiedDate)
		{
			ProductModelProductDescriptionCulture item = new ProductModelProductDescriptionCulture();
			
			item.ProductModelID = varProductModelID;
			
			item.ProductDescriptionID = varProductDescriptionID;
			
			item.CultureID = varCultureID;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varProductModelID,int varProductDescriptionID,string varCultureID,DateTime varModifiedDate)
		{
			ProductModelProductDescriptionCulture item = new ProductModelProductDescriptionCulture();
			
				item.ProductModelID = varProductModelID;
			
				item.ProductDescriptionID = varProductDescriptionID;
			
				item.CultureID = varCultureID;
			
				item.ModifiedDate = varModifiedDate;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn ProductModelIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ProductDescriptionIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn CultureIDColumn
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
			 public static string ProductModelID = @"ProductModelID";
			 public static string ProductDescriptionID = @"ProductDescriptionID";
			 public static string CultureID = @"CultureID";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
