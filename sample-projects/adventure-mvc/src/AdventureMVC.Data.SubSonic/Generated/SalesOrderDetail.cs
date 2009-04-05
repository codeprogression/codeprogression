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
	/// Strongly-typed collection for the SalesOrderDetail class.
	/// </summary>
    [Serializable]
	public partial class SalesOrderDetailCollection : ActiveList<SalesOrderDetail, SalesOrderDetailCollection>
	{	   
		public SalesOrderDetailCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SalesOrderDetailCollection</returns>
		public SalesOrderDetailCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SalesOrderDetail o = this[i];
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
	/// This is an ActiveRecord class which wraps the SalesOrderDetail table.
	/// </summary>
	[Serializable]
	public partial class SalesOrderDetail : ActiveRecord<SalesOrderDetail>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SalesOrderDetail()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SalesOrderDetail(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SalesOrderDetail(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SalesOrderDetail(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("SalesOrderDetail", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Sales";
				//columns
				
				TableSchema.TableColumn colvarSalesOrderID = new TableSchema.TableColumn(schema);
				colvarSalesOrderID.ColumnName = "SalesOrderID";
				colvarSalesOrderID.DataType = DbType.Int32;
				colvarSalesOrderID.MaxLength = 0;
				colvarSalesOrderID.AutoIncrement = false;
				colvarSalesOrderID.IsNullable = false;
				colvarSalesOrderID.IsPrimaryKey = true;
				colvarSalesOrderID.IsForeignKey = true;
				colvarSalesOrderID.IsReadOnly = false;
				colvarSalesOrderID.DefaultSetting = @"";
				
					colvarSalesOrderID.ForeignKeyTableName = "SalesOrderHeader";
				schema.Columns.Add(colvarSalesOrderID);
				
				TableSchema.TableColumn colvarSalesOrderDetailID = new TableSchema.TableColumn(schema);
				colvarSalesOrderDetailID.ColumnName = "SalesOrderDetailID";
				colvarSalesOrderDetailID.DataType = DbType.Int32;
				colvarSalesOrderDetailID.MaxLength = 0;
				colvarSalesOrderDetailID.AutoIncrement = true;
				colvarSalesOrderDetailID.IsNullable = false;
				colvarSalesOrderDetailID.IsPrimaryKey = true;
				colvarSalesOrderDetailID.IsForeignKey = false;
				colvarSalesOrderDetailID.IsReadOnly = false;
				colvarSalesOrderDetailID.DefaultSetting = @"";
				colvarSalesOrderDetailID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSalesOrderDetailID);
				
				TableSchema.TableColumn colvarCarrierTrackingNumber = new TableSchema.TableColumn(schema);
				colvarCarrierTrackingNumber.ColumnName = "CarrierTrackingNumber";
				colvarCarrierTrackingNumber.DataType = DbType.String;
				colvarCarrierTrackingNumber.MaxLength = 25;
				colvarCarrierTrackingNumber.AutoIncrement = false;
				colvarCarrierTrackingNumber.IsNullable = true;
				colvarCarrierTrackingNumber.IsPrimaryKey = false;
				colvarCarrierTrackingNumber.IsForeignKey = false;
				colvarCarrierTrackingNumber.IsReadOnly = false;
				colvarCarrierTrackingNumber.DefaultSetting = @"";
				colvarCarrierTrackingNumber.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCarrierTrackingNumber);
				
				TableSchema.TableColumn colvarOrderQty = new TableSchema.TableColumn(schema);
				colvarOrderQty.ColumnName = "OrderQty";
				colvarOrderQty.DataType = DbType.Int16;
				colvarOrderQty.MaxLength = 0;
				colvarOrderQty.AutoIncrement = false;
				colvarOrderQty.IsNullable = false;
				colvarOrderQty.IsPrimaryKey = false;
				colvarOrderQty.IsForeignKey = false;
				colvarOrderQty.IsReadOnly = false;
				colvarOrderQty.DefaultSetting = @"";
				colvarOrderQty.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOrderQty);
				
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
				
					colvarProductID.ForeignKeyTableName = "SpecialOfferProduct";
				schema.Columns.Add(colvarProductID);
				
				TableSchema.TableColumn colvarSpecialOfferID = new TableSchema.TableColumn(schema);
				colvarSpecialOfferID.ColumnName = "SpecialOfferID";
				colvarSpecialOfferID.DataType = DbType.Int32;
				colvarSpecialOfferID.MaxLength = 0;
				colvarSpecialOfferID.AutoIncrement = false;
				colvarSpecialOfferID.IsNullable = false;
				colvarSpecialOfferID.IsPrimaryKey = false;
				colvarSpecialOfferID.IsForeignKey = true;
				colvarSpecialOfferID.IsReadOnly = false;
				colvarSpecialOfferID.DefaultSetting = @"";
				
					colvarSpecialOfferID.ForeignKeyTableName = "SpecialOfferProduct";
				schema.Columns.Add(colvarSpecialOfferID);
				
				TableSchema.TableColumn colvarUnitPrice = new TableSchema.TableColumn(schema);
				colvarUnitPrice.ColumnName = "UnitPrice";
				colvarUnitPrice.DataType = DbType.Currency;
				colvarUnitPrice.MaxLength = 0;
				colvarUnitPrice.AutoIncrement = false;
				colvarUnitPrice.IsNullable = false;
				colvarUnitPrice.IsPrimaryKey = false;
				colvarUnitPrice.IsForeignKey = false;
				colvarUnitPrice.IsReadOnly = false;
				colvarUnitPrice.DefaultSetting = @"";
				colvarUnitPrice.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUnitPrice);
				
				TableSchema.TableColumn colvarUnitPriceDiscount = new TableSchema.TableColumn(schema);
				colvarUnitPriceDiscount.ColumnName = "UnitPriceDiscount";
				colvarUnitPriceDiscount.DataType = DbType.Currency;
				colvarUnitPriceDiscount.MaxLength = 0;
				colvarUnitPriceDiscount.AutoIncrement = false;
				colvarUnitPriceDiscount.IsNullable = false;
				colvarUnitPriceDiscount.IsPrimaryKey = false;
				colvarUnitPriceDiscount.IsForeignKey = false;
				colvarUnitPriceDiscount.IsReadOnly = false;
				
						colvarUnitPriceDiscount.DefaultSetting = @"((0.0))";
				colvarUnitPriceDiscount.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUnitPriceDiscount);
				
				TableSchema.TableColumn colvarLineTotal = new TableSchema.TableColumn(schema);
				colvarLineTotal.ColumnName = "LineTotal";
				colvarLineTotal.DataType = DbType.Decimal;
				colvarLineTotal.MaxLength = 0;
				colvarLineTotal.AutoIncrement = false;
				colvarLineTotal.IsNullable = false;
				colvarLineTotal.IsPrimaryKey = false;
				colvarLineTotal.IsForeignKey = false;
				colvarLineTotal.IsReadOnly = true;
				colvarLineTotal.DefaultSetting = @"";
				colvarLineTotal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLineTotal);
				
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
				DataService.Providers["AdventureWorks"].AddSchema("SalesOrderDetail",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("SalesOrderID")]
		[Bindable(true)]
		public int SalesOrderID 
		{
			get { return GetColumnValue<int>(Columns.SalesOrderID); }
			set { SetColumnValue(Columns.SalesOrderID, value); }
		}
		  
		[XmlAttribute("SalesOrderDetailID")]
		[Bindable(true)]
		public int SalesOrderDetailID 
		{
			get { return GetColumnValue<int>(Columns.SalesOrderDetailID); }
			set { SetColumnValue(Columns.SalesOrderDetailID, value); }
		}
		  
		[XmlAttribute("CarrierTrackingNumber")]
		[Bindable(true)]
		public string CarrierTrackingNumber 
		{
			get { return GetColumnValue<string>(Columns.CarrierTrackingNumber); }
			set { SetColumnValue(Columns.CarrierTrackingNumber, value); }
		}
		  
		[XmlAttribute("OrderQty")]
		[Bindable(true)]
		public short OrderQty 
		{
			get { return GetColumnValue<short>(Columns.OrderQty); }
			set { SetColumnValue(Columns.OrderQty, value); }
		}
		  
		[XmlAttribute("ProductID")]
		[Bindable(true)]
		public int ProductID 
		{
			get { return GetColumnValue<int>(Columns.ProductID); }
			set { SetColumnValue(Columns.ProductID, value); }
		}
		  
		[XmlAttribute("SpecialOfferID")]
		[Bindable(true)]
		public int SpecialOfferID 
		{
			get { return GetColumnValue<int>(Columns.SpecialOfferID); }
			set { SetColumnValue(Columns.SpecialOfferID, value); }
		}
		  
		[XmlAttribute("UnitPrice")]
		[Bindable(true)]
		public decimal UnitPrice 
		{
			get { return GetColumnValue<decimal>(Columns.UnitPrice); }
			set { SetColumnValue(Columns.UnitPrice, value); }
		}
		  
		[XmlAttribute("UnitPriceDiscount")]
		[Bindable(true)]
		public decimal UnitPriceDiscount 
		{
			get { return GetColumnValue<decimal>(Columns.UnitPriceDiscount); }
			set { SetColumnValue(Columns.UnitPriceDiscount, value); }
		}
		  
		[XmlAttribute("LineTotal")]
		[Bindable(true)]
		public decimal LineTotal 
		{
			get { return GetColumnValue<decimal>(Columns.LineTotal); }
			set { SetColumnValue(Columns.LineTotal, value); }
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
		/// Returns a SalesOrderHeader ActiveRecord object related to this SalesOrderDetail
		/// 
		/// </summary>
		public AdventureWorks.SalesOrderHeader SalesOrderHeader
		{
			get { return AdventureWorks.SalesOrderHeader.FetchByID(this.SalesOrderID); }
			set { SetColumnValue("SalesOrderID", value.SalesOrderID); }
		}
		
		
		/// <summary>
		/// Returns a SpecialOfferProduct ActiveRecord object related to this SalesOrderDetail
		/// 
		/// </summary>
		public AdventureWorks.SpecialOfferProduct SpecialOfferProduct
		{
			get { return AdventureWorks.SpecialOfferProduct.FetchByID(this.ProductID); }
			set { SetColumnValue("ProductID", value.SpecialOfferID); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varSalesOrderID,string varCarrierTrackingNumber,short varOrderQty,int varProductID,int varSpecialOfferID,decimal varUnitPrice,decimal varUnitPriceDiscount,decimal varLineTotal,Guid varRowguid,DateTime varModifiedDate)
		{
			SalesOrderDetail item = new SalesOrderDetail();
			
			item.SalesOrderID = varSalesOrderID;
			
			item.CarrierTrackingNumber = varCarrierTrackingNumber;
			
			item.OrderQty = varOrderQty;
			
			item.ProductID = varProductID;
			
			item.SpecialOfferID = varSpecialOfferID;
			
			item.UnitPrice = varUnitPrice;
			
			item.UnitPriceDiscount = varUnitPriceDiscount;
			
			item.LineTotal = varLineTotal;
			
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
		public static void Update(int varSalesOrderID,int varSalesOrderDetailID,string varCarrierTrackingNumber,short varOrderQty,int varProductID,int varSpecialOfferID,decimal varUnitPrice,decimal varUnitPriceDiscount,decimal varLineTotal,Guid varRowguid,DateTime varModifiedDate)
		{
			SalesOrderDetail item = new SalesOrderDetail();
			
				item.SalesOrderID = varSalesOrderID;
			
				item.SalesOrderDetailID = varSalesOrderDetailID;
			
				item.CarrierTrackingNumber = varCarrierTrackingNumber;
			
				item.OrderQty = varOrderQty;
			
				item.ProductID = varProductID;
			
				item.SpecialOfferID = varSpecialOfferID;
			
				item.UnitPrice = varUnitPrice;
			
				item.UnitPriceDiscount = varUnitPriceDiscount;
			
				item.LineTotal = varLineTotal;
			
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
        
        
        public static TableSchema.TableColumn SalesOrderIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn SalesOrderDetailIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn CarrierTrackingNumberColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn OrderQtyColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ProductIDColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn SpecialOfferIDColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn UnitPriceColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn UnitPriceDiscountColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn LineTotalColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn RowguidColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedDateColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string SalesOrderID = @"SalesOrderID";
			 public static string SalesOrderDetailID = @"SalesOrderDetailID";
			 public static string CarrierTrackingNumber = @"CarrierTrackingNumber";
			 public static string OrderQty = @"OrderQty";
			 public static string ProductID = @"ProductID";
			 public static string SpecialOfferID = @"SpecialOfferID";
			 public static string UnitPrice = @"UnitPrice";
			 public static string UnitPriceDiscount = @"UnitPriceDiscount";
			 public static string LineTotal = @"LineTotal";
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
