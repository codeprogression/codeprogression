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
	/// Strongly-typed collection for the ProductModelIllustration class.
	/// </summary>
    [Serializable]
	public partial class ProductModelIllustrationCollection : ActiveList<ProductModelIllustration, ProductModelIllustrationCollection>
	{	   
		public ProductModelIllustrationCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ProductModelIllustrationCollection</returns>
		public ProductModelIllustrationCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ProductModelIllustration o = this[i];
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
	/// This is an ActiveRecord class which wraps the ProductModelIllustration table.
	/// </summary>
	[Serializable]
	public partial class ProductModelIllustration : ActiveRecord<ProductModelIllustration>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ProductModelIllustration()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ProductModelIllustration(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ProductModelIllustration(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ProductModelIllustration(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ProductModelIllustration", TableType.Table, DataService.GetInstance("AdventureWorks"));
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
				
				TableSchema.TableColumn colvarIllustrationID = new TableSchema.TableColumn(schema);
				colvarIllustrationID.ColumnName = "IllustrationID";
				colvarIllustrationID.DataType = DbType.Int32;
				colvarIllustrationID.MaxLength = 0;
				colvarIllustrationID.AutoIncrement = false;
				colvarIllustrationID.IsNullable = false;
				colvarIllustrationID.IsPrimaryKey = true;
				colvarIllustrationID.IsForeignKey = true;
				colvarIllustrationID.IsReadOnly = false;
				colvarIllustrationID.DefaultSetting = @"";
				
					colvarIllustrationID.ForeignKeyTableName = "Illustration";
				schema.Columns.Add(colvarIllustrationID);
				
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
				DataService.Providers["AdventureWorks"].AddSchema("ProductModelIllustration",schema);
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
		  
		[XmlAttribute("IllustrationID")]
		[Bindable(true)]
		public int IllustrationID 
		{
			get { return GetColumnValue<int>(Columns.IllustrationID); }
			set { SetColumnValue(Columns.IllustrationID, value); }
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
		/// Returns a Illustration ActiveRecord object related to this ProductModelIllustration
		/// 
		/// </summary>
		public AdventureWorks.Illustration Illustration
		{
			get { return AdventureWorks.Illustration.FetchByID(this.IllustrationID); }
			set { SetColumnValue("IllustrationID", value.IllustrationID); }
		}
		
		
		/// <summary>
		/// Returns a ProductModel ActiveRecord object related to this ProductModelIllustration
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
		public static void Insert(int varProductModelID,int varIllustrationID,DateTime varModifiedDate)
		{
			ProductModelIllustration item = new ProductModelIllustration();
			
			item.ProductModelID = varProductModelID;
			
			item.IllustrationID = varIllustrationID;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varProductModelID,int varIllustrationID,DateTime varModifiedDate)
		{
			ProductModelIllustration item = new ProductModelIllustration();
			
				item.ProductModelID = varProductModelID;
			
				item.IllustrationID = varIllustrationID;
			
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
        
        
        
        public static TableSchema.TableColumn IllustrationIDColumn
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
			 public static string ProductModelID = @"ProductModelID";
			 public static string IllustrationID = @"IllustrationID";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
