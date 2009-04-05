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
	/// Strongly-typed collection for the ProductInventory class.
	/// </summary>
    [Serializable]
	public partial class ProductInventoryCollection : ActiveList<ProductInventory, ProductInventoryCollection>
	{	   
		public ProductInventoryCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ProductInventoryCollection</returns>
		public ProductInventoryCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ProductInventory o = this[i];
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
	/// This is an ActiveRecord class which wraps the ProductInventory table.
	/// </summary>
	[Serializable]
	public partial class ProductInventory : ActiveRecord<ProductInventory>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ProductInventory()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ProductInventory(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ProductInventory(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ProductInventory(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ProductInventory", TableType.Table, DataService.GetInstance("AdventureWorks"));
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
				
				TableSchema.TableColumn colvarLocationID = new TableSchema.TableColumn(schema);
				colvarLocationID.ColumnName = "LocationID";
				colvarLocationID.DataType = DbType.Int16;
				colvarLocationID.MaxLength = 0;
				colvarLocationID.AutoIncrement = false;
				colvarLocationID.IsNullable = false;
				colvarLocationID.IsPrimaryKey = true;
				colvarLocationID.IsForeignKey = true;
				colvarLocationID.IsReadOnly = false;
				colvarLocationID.DefaultSetting = @"";
				
					colvarLocationID.ForeignKeyTableName = "Location";
				schema.Columns.Add(colvarLocationID);
				
				TableSchema.TableColumn colvarShelf = new TableSchema.TableColumn(schema);
				colvarShelf.ColumnName = "Shelf";
				colvarShelf.DataType = DbType.String;
				colvarShelf.MaxLength = 10;
				colvarShelf.AutoIncrement = false;
				colvarShelf.IsNullable = false;
				colvarShelf.IsPrimaryKey = false;
				colvarShelf.IsForeignKey = false;
				colvarShelf.IsReadOnly = false;
				colvarShelf.DefaultSetting = @"";
				colvarShelf.ForeignKeyTableName = "";
				schema.Columns.Add(colvarShelf);
				
				TableSchema.TableColumn colvarBin = new TableSchema.TableColumn(schema);
				colvarBin.ColumnName = "Bin";
				colvarBin.DataType = DbType.Byte;
				colvarBin.MaxLength = 0;
				colvarBin.AutoIncrement = false;
				colvarBin.IsNullable = false;
				colvarBin.IsPrimaryKey = false;
				colvarBin.IsForeignKey = false;
				colvarBin.IsReadOnly = false;
				colvarBin.DefaultSetting = @"";
				colvarBin.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBin);
				
				TableSchema.TableColumn colvarQuantity = new TableSchema.TableColumn(schema);
				colvarQuantity.ColumnName = "Quantity";
				colvarQuantity.DataType = DbType.Int16;
				colvarQuantity.MaxLength = 0;
				colvarQuantity.AutoIncrement = false;
				colvarQuantity.IsNullable = false;
				colvarQuantity.IsPrimaryKey = false;
				colvarQuantity.IsForeignKey = false;
				colvarQuantity.IsReadOnly = false;
				
						colvarQuantity.DefaultSetting = @"((0))";
				colvarQuantity.ForeignKeyTableName = "";
				schema.Columns.Add(colvarQuantity);
				
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
				DataService.Providers["AdventureWorks"].AddSchema("ProductInventory",schema);
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
		  
		[XmlAttribute("LocationID")]
		[Bindable(true)]
		public short LocationID 
		{
			get { return GetColumnValue<short>(Columns.LocationID); }
			set { SetColumnValue(Columns.LocationID, value); }
		}
		  
		[XmlAttribute("Shelf")]
		[Bindable(true)]
		public string Shelf 
		{
			get { return GetColumnValue<string>(Columns.Shelf); }
			set { SetColumnValue(Columns.Shelf, value); }
		}
		  
		[XmlAttribute("Bin")]
		[Bindable(true)]
		public byte Bin 
		{
			get { return GetColumnValue<byte>(Columns.Bin); }
			set { SetColumnValue(Columns.Bin, value); }
		}
		  
		[XmlAttribute("Quantity")]
		[Bindable(true)]
		public short Quantity 
		{
			get { return GetColumnValue<short>(Columns.Quantity); }
			set { SetColumnValue(Columns.Quantity, value); }
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
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Location ActiveRecord object related to this ProductInventory
		/// 
		/// </summary>
		public AdventureWorks.Location Location
		{
			get { return AdventureWorks.Location.FetchByID(this.LocationID); }
			set { SetColumnValue("LocationID", value.LocationID); }
		}
		
		
		/// <summary>
		/// Returns a Product ActiveRecord object related to this ProductInventory
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
		public static void Insert(int varProductID,short varLocationID,string varShelf,byte varBin,short varQuantity,Guid varRowguid,DateTime varModifiedDate)
		{
			ProductInventory item = new ProductInventory();
			
			item.ProductID = varProductID;
			
			item.LocationID = varLocationID;
			
			item.Shelf = varShelf;
			
			item.Bin = varBin;
			
			item.Quantity = varQuantity;
			
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
		public static void Update(int varProductID,short varLocationID,string varShelf,byte varBin,short varQuantity,Guid varRowguid,DateTime varModifiedDate)
		{
			ProductInventory item = new ProductInventory();
			
				item.ProductID = varProductID;
			
				item.LocationID = varLocationID;
			
				item.Shelf = varShelf;
			
				item.Bin = varBin;
			
				item.Quantity = varQuantity;
			
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
        
        
        public static TableSchema.TableColumn ProductIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn LocationIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ShelfColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn BinColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn QuantityColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn RowguidColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedDateColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string ProductID = @"ProductID";
			 public static string LocationID = @"LocationID";
			 public static string Shelf = @"Shelf";
			 public static string Bin = @"Bin";
			 public static string Quantity = @"Quantity";
			 public static string Rowguid = @"rowguid";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
