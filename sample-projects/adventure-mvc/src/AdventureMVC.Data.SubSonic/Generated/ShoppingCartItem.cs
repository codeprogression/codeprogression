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
	/// Strongly-typed collection for the ShoppingCartItem class.
	/// </summary>
    [Serializable]
	public partial class ShoppingCartItemCollection : ActiveList<ShoppingCartItem, ShoppingCartItemCollection>
	{	   
		public ShoppingCartItemCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ShoppingCartItemCollection</returns>
		public ShoppingCartItemCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ShoppingCartItem o = this[i];
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
	/// This is an ActiveRecord class which wraps the ShoppingCartItem table.
	/// </summary>
	[Serializable]
	public partial class ShoppingCartItem : ActiveRecord<ShoppingCartItem>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ShoppingCartItem()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ShoppingCartItem(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ShoppingCartItem(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ShoppingCartItem(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ShoppingCartItem", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Sales";
				//columns
				
				TableSchema.TableColumn colvarShoppingCartItemID = new TableSchema.TableColumn(schema);
				colvarShoppingCartItemID.ColumnName = "ShoppingCartItemID";
				colvarShoppingCartItemID.DataType = DbType.Int32;
				colvarShoppingCartItemID.MaxLength = 0;
				colvarShoppingCartItemID.AutoIncrement = true;
				colvarShoppingCartItemID.IsNullable = false;
				colvarShoppingCartItemID.IsPrimaryKey = true;
				colvarShoppingCartItemID.IsForeignKey = false;
				colvarShoppingCartItemID.IsReadOnly = false;
				colvarShoppingCartItemID.DefaultSetting = @"";
				colvarShoppingCartItemID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarShoppingCartItemID);
				
				TableSchema.TableColumn colvarShoppingCartID = new TableSchema.TableColumn(schema);
				colvarShoppingCartID.ColumnName = "ShoppingCartID";
				colvarShoppingCartID.DataType = DbType.String;
				colvarShoppingCartID.MaxLength = 50;
				colvarShoppingCartID.AutoIncrement = false;
				colvarShoppingCartID.IsNullable = false;
				colvarShoppingCartID.IsPrimaryKey = false;
				colvarShoppingCartID.IsForeignKey = false;
				colvarShoppingCartID.IsReadOnly = false;
				colvarShoppingCartID.DefaultSetting = @"";
				colvarShoppingCartID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarShoppingCartID);
				
				TableSchema.TableColumn colvarQuantity = new TableSchema.TableColumn(schema);
				colvarQuantity.ColumnName = "Quantity";
				colvarQuantity.DataType = DbType.Int32;
				colvarQuantity.MaxLength = 0;
				colvarQuantity.AutoIncrement = false;
				colvarQuantity.IsNullable = false;
				colvarQuantity.IsPrimaryKey = false;
				colvarQuantity.IsForeignKey = false;
				colvarQuantity.IsReadOnly = false;
				
						colvarQuantity.DefaultSetting = @"((1))";
				colvarQuantity.ForeignKeyTableName = "";
				schema.Columns.Add(colvarQuantity);
				
				TableSchema.TableColumn colvarProductID = new TableSchema.TableColumn(schema);
				colvarProductID.ColumnName = "ProductID";
				colvarProductID.DataType = DbType.Int32;
				colvarProductID.MaxLength = 0;
				colvarProductID.AutoIncrement = false;
				colvarProductID.IsNullable = false;
				colvarProductID.IsPrimaryKey = false;
				colvarProductID.IsForeignKey = true;
				colvarProductID.IsReadOnly = false;
				colvarProductID.DefaultSetting = @"";
				
					colvarProductID.ForeignKeyTableName = "Product";
				schema.Columns.Add(colvarProductID);
				
				TableSchema.TableColumn colvarDateCreated = new TableSchema.TableColumn(schema);
				colvarDateCreated.ColumnName = "DateCreated";
				colvarDateCreated.DataType = DbType.DateTime;
				colvarDateCreated.MaxLength = 0;
				colvarDateCreated.AutoIncrement = false;
				colvarDateCreated.IsNullable = false;
				colvarDateCreated.IsPrimaryKey = false;
				colvarDateCreated.IsForeignKey = false;
				colvarDateCreated.IsReadOnly = false;
				
						colvarDateCreated.DefaultSetting = @"(getdate())";
				colvarDateCreated.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDateCreated);
				
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
				DataService.Providers["AdventureWorks"].AddSchema("ShoppingCartItem",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("ShoppingCartItemID")]
		[Bindable(true)]
		public int ShoppingCartItemID 
		{
			get { return GetColumnValue<int>(Columns.ShoppingCartItemID); }
			set { SetColumnValue(Columns.ShoppingCartItemID, value); }
		}
		  
		[XmlAttribute("ShoppingCartID")]
		[Bindable(true)]
		public string ShoppingCartID 
		{
			get { return GetColumnValue<string>(Columns.ShoppingCartID); }
			set { SetColumnValue(Columns.ShoppingCartID, value); }
		}
		  
		[XmlAttribute("Quantity")]
		[Bindable(true)]
		public int Quantity 
		{
			get { return GetColumnValue<int>(Columns.Quantity); }
			set { SetColumnValue(Columns.Quantity, value); }
		}
		  
		[XmlAttribute("ProductID")]
		[Bindable(true)]
		public int ProductID 
		{
			get { return GetColumnValue<int>(Columns.ProductID); }
			set { SetColumnValue(Columns.ProductID, value); }
		}
		  
		[XmlAttribute("DateCreated")]
		[Bindable(true)]
		public DateTime DateCreated 
		{
			get { return GetColumnValue<DateTime>(Columns.DateCreated); }
			set { SetColumnValue(Columns.DateCreated, value); }
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
		/// Returns a Product ActiveRecord object related to this ShoppingCartItem
		/// 
		/// </summary>
		public AdventureWorks.Product Product
		{
			get { return AdventureWorks.Product.FetchByID(this.ProductID); }
			set { SetColumnValue("ProductID", value.ProductID); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varShoppingCartID,int varQuantity,int varProductID,DateTime varDateCreated,DateTime varModifiedDate)
		{
			ShoppingCartItem item = new ShoppingCartItem();
			
			item.ShoppingCartID = varShoppingCartID;
			
			item.Quantity = varQuantity;
			
			item.ProductID = varProductID;
			
			item.DateCreated = varDateCreated;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varShoppingCartItemID,string varShoppingCartID,int varQuantity,int varProductID,DateTime varDateCreated,DateTime varModifiedDate)
		{
			ShoppingCartItem item = new ShoppingCartItem();
			
				item.ShoppingCartItemID = varShoppingCartItemID;
			
				item.ShoppingCartID = varShoppingCartID;
			
				item.Quantity = varQuantity;
			
				item.ProductID = varProductID;
			
				item.DateCreated = varDateCreated;
			
				item.ModifiedDate = varModifiedDate;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn ShoppingCartItemIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ShoppingCartIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn QuantityColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ProductIDColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn DateCreatedColumn
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
			 public static string ShoppingCartItemID = @"ShoppingCartItemID";
			 public static string ShoppingCartID = @"ShoppingCartID";
			 public static string Quantity = @"Quantity";
			 public static string ProductID = @"ProductID";
			 public static string DateCreated = @"DateCreated";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
