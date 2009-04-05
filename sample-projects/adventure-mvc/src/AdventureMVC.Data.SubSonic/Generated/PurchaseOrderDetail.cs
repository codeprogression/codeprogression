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
	/// Strongly-typed collection for the PurchaseOrderDetail class.
	/// </summary>
    [Serializable]
	public partial class PurchaseOrderDetailCollection : ActiveList<PurchaseOrderDetail, PurchaseOrderDetailCollection>
	{	   
		public PurchaseOrderDetailCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PurchaseOrderDetailCollection</returns>
		public PurchaseOrderDetailCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PurchaseOrderDetail o = this[i];
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
	/// This is an ActiveRecord class which wraps the PurchaseOrderDetail table.
	/// </summary>
	[Serializable]
	public partial class PurchaseOrderDetail : ActiveRecord<PurchaseOrderDetail>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PurchaseOrderDetail()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PurchaseOrderDetail(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PurchaseOrderDetail(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PurchaseOrderDetail(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PurchaseOrderDetail", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Purchasing";
				//columns
				
				TableSchema.TableColumn colvarPurchaseOrderID = new TableSchema.TableColumn(schema);
				colvarPurchaseOrderID.ColumnName = "PurchaseOrderID";
				colvarPurchaseOrderID.DataType = DbType.Int32;
				colvarPurchaseOrderID.MaxLength = 0;
				colvarPurchaseOrderID.AutoIncrement = false;
				colvarPurchaseOrderID.IsNullable = false;
				colvarPurchaseOrderID.IsPrimaryKey = true;
				colvarPurchaseOrderID.IsForeignKey = true;
				colvarPurchaseOrderID.IsReadOnly = false;
				colvarPurchaseOrderID.DefaultSetting = @"";
				
					colvarPurchaseOrderID.ForeignKeyTableName = "PurchaseOrderHeader";
				schema.Columns.Add(colvarPurchaseOrderID);
				
				TableSchema.TableColumn colvarPurchaseOrderDetailID = new TableSchema.TableColumn(schema);
				colvarPurchaseOrderDetailID.ColumnName = "PurchaseOrderDetailID";
				colvarPurchaseOrderDetailID.DataType = DbType.Int32;
				colvarPurchaseOrderDetailID.MaxLength = 0;
				colvarPurchaseOrderDetailID.AutoIncrement = true;
				colvarPurchaseOrderDetailID.IsNullable = false;
				colvarPurchaseOrderDetailID.IsPrimaryKey = true;
				colvarPurchaseOrderDetailID.IsForeignKey = false;
				colvarPurchaseOrderDetailID.IsReadOnly = false;
				colvarPurchaseOrderDetailID.DefaultSetting = @"";
				colvarPurchaseOrderDetailID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPurchaseOrderDetailID);
				
				TableSchema.TableColumn colvarDueDate = new TableSchema.TableColumn(schema);
				colvarDueDate.ColumnName = "DueDate";
				colvarDueDate.DataType = DbType.DateTime;
				colvarDueDate.MaxLength = 0;
				colvarDueDate.AutoIncrement = false;
				colvarDueDate.IsNullable = false;
				colvarDueDate.IsPrimaryKey = false;
				colvarDueDate.IsForeignKey = false;
				colvarDueDate.IsReadOnly = false;
				colvarDueDate.DefaultSetting = @"";
				colvarDueDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDueDate);
				
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
				
					colvarProductID.ForeignKeyTableName = "Product";
				schema.Columns.Add(colvarProductID);
				
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
				
				TableSchema.TableColumn colvarLineTotal = new TableSchema.TableColumn(schema);
				colvarLineTotal.ColumnName = "LineTotal";
				colvarLineTotal.DataType = DbType.Currency;
				colvarLineTotal.MaxLength = 0;
				colvarLineTotal.AutoIncrement = false;
				colvarLineTotal.IsNullable = false;
				colvarLineTotal.IsPrimaryKey = false;
				colvarLineTotal.IsForeignKey = false;
				colvarLineTotal.IsReadOnly = true;
				colvarLineTotal.DefaultSetting = @"";
				colvarLineTotal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLineTotal);
				
				TableSchema.TableColumn colvarReceivedQty = new TableSchema.TableColumn(schema);
				colvarReceivedQty.ColumnName = "ReceivedQty";
				colvarReceivedQty.DataType = DbType.Decimal;
				colvarReceivedQty.MaxLength = 0;
				colvarReceivedQty.AutoIncrement = false;
				colvarReceivedQty.IsNullable = false;
				colvarReceivedQty.IsPrimaryKey = false;
				colvarReceivedQty.IsForeignKey = false;
				colvarReceivedQty.IsReadOnly = false;
				colvarReceivedQty.DefaultSetting = @"";
				colvarReceivedQty.ForeignKeyTableName = "";
				schema.Columns.Add(colvarReceivedQty);
				
				TableSchema.TableColumn colvarRejectedQty = new TableSchema.TableColumn(schema);
				colvarRejectedQty.ColumnName = "RejectedQty";
				colvarRejectedQty.DataType = DbType.Decimal;
				colvarRejectedQty.MaxLength = 0;
				colvarRejectedQty.AutoIncrement = false;
				colvarRejectedQty.IsNullable = false;
				colvarRejectedQty.IsPrimaryKey = false;
				colvarRejectedQty.IsForeignKey = false;
				colvarRejectedQty.IsReadOnly = false;
				colvarRejectedQty.DefaultSetting = @"";
				colvarRejectedQty.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRejectedQty);
				
				TableSchema.TableColumn colvarStockedQty = new TableSchema.TableColumn(schema);
				colvarStockedQty.ColumnName = "StockedQty";
				colvarStockedQty.DataType = DbType.Decimal;
				colvarStockedQty.MaxLength = 0;
				colvarStockedQty.AutoIncrement = false;
				colvarStockedQty.IsNullable = false;
				colvarStockedQty.IsPrimaryKey = false;
				colvarStockedQty.IsForeignKey = false;
				colvarStockedQty.IsReadOnly = true;
				colvarStockedQty.DefaultSetting = @"";
				colvarStockedQty.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStockedQty);
				
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
				DataService.Providers["AdventureWorks"].AddSchema("PurchaseOrderDetail",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("PurchaseOrderID")]
		[Bindable(true)]
		public int PurchaseOrderID 
		{
			get { return GetColumnValue<int>(Columns.PurchaseOrderID); }
			set { SetColumnValue(Columns.PurchaseOrderID, value); }
		}
		  
		[XmlAttribute("PurchaseOrderDetailID")]
		[Bindable(true)]
		public int PurchaseOrderDetailID 
		{
			get { return GetColumnValue<int>(Columns.PurchaseOrderDetailID); }
			set { SetColumnValue(Columns.PurchaseOrderDetailID, value); }
		}
		  
		[XmlAttribute("DueDate")]
		[Bindable(true)]
		public DateTime DueDate 
		{
			get { return GetColumnValue<DateTime>(Columns.DueDate); }
			set { SetColumnValue(Columns.DueDate, value); }
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
		  
		[XmlAttribute("UnitPrice")]
		[Bindable(true)]
		public decimal UnitPrice 
		{
			get { return GetColumnValue<decimal>(Columns.UnitPrice); }
			set { SetColumnValue(Columns.UnitPrice, value); }
		}
		  
		[XmlAttribute("LineTotal")]
		[Bindable(true)]
		public decimal LineTotal 
		{
			get { return GetColumnValue<decimal>(Columns.LineTotal); }
			set { SetColumnValue(Columns.LineTotal, value); }
		}
		  
		[XmlAttribute("ReceivedQty")]
		[Bindable(true)]
		public decimal ReceivedQty 
		{
			get { return GetColumnValue<decimal>(Columns.ReceivedQty); }
			set { SetColumnValue(Columns.ReceivedQty, value); }
		}
		  
		[XmlAttribute("RejectedQty")]
		[Bindable(true)]
		public decimal RejectedQty 
		{
			get { return GetColumnValue<decimal>(Columns.RejectedQty); }
			set { SetColumnValue(Columns.RejectedQty, value); }
		}
		  
		[XmlAttribute("StockedQty")]
		[Bindable(true)]
		public decimal StockedQty 
		{
			get { return GetColumnValue<decimal>(Columns.StockedQty); }
			set { SetColumnValue(Columns.StockedQty, value); }
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
		/// Returns a Product ActiveRecord object related to this PurchaseOrderDetail
		/// 
		/// </summary>
		public AdventureWorks.Product Product
		{
			get { return AdventureWorks.Product.FetchByID(this.ProductID); }
			set { SetColumnValue("ProductID", value.ProductID); }
		}
		
		
		/// <summary>
		/// Returns a PurchaseOrderHeader ActiveRecord object related to this PurchaseOrderDetail
		/// 
		/// </summary>
		public AdventureWorks.PurchaseOrderHeader PurchaseOrderHeader
		{
			get { return AdventureWorks.PurchaseOrderHeader.FetchByID(this.PurchaseOrderID); }
			set { SetColumnValue("PurchaseOrderID", value.PurchaseOrderID); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varPurchaseOrderID,DateTime varDueDate,short varOrderQty,int varProductID,decimal varUnitPrice,decimal varLineTotal,decimal varReceivedQty,decimal varRejectedQty,decimal varStockedQty,DateTime varModifiedDate)
		{
			PurchaseOrderDetail item = new PurchaseOrderDetail();
			
			item.PurchaseOrderID = varPurchaseOrderID;
			
			item.DueDate = varDueDate;
			
			item.OrderQty = varOrderQty;
			
			item.ProductID = varProductID;
			
			item.UnitPrice = varUnitPrice;
			
			item.LineTotal = varLineTotal;
			
			item.ReceivedQty = varReceivedQty;
			
			item.RejectedQty = varRejectedQty;
			
			item.StockedQty = varStockedQty;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varPurchaseOrderID,int varPurchaseOrderDetailID,DateTime varDueDate,short varOrderQty,int varProductID,decimal varUnitPrice,decimal varLineTotal,decimal varReceivedQty,decimal varRejectedQty,decimal varStockedQty,DateTime varModifiedDate)
		{
			PurchaseOrderDetail item = new PurchaseOrderDetail();
			
				item.PurchaseOrderID = varPurchaseOrderID;
			
				item.PurchaseOrderDetailID = varPurchaseOrderDetailID;
			
				item.DueDate = varDueDate;
			
				item.OrderQty = varOrderQty;
			
				item.ProductID = varProductID;
			
				item.UnitPrice = varUnitPrice;
			
				item.LineTotal = varLineTotal;
			
				item.ReceivedQty = varReceivedQty;
			
				item.RejectedQty = varRejectedQty;
			
				item.StockedQty = varStockedQty;
			
				item.ModifiedDate = varModifiedDate;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn PurchaseOrderIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn PurchaseOrderDetailIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DueDateColumn
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
        
        
        
        public static TableSchema.TableColumn UnitPriceColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn LineTotalColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn ReceivedQtyColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn RejectedQtyColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn StockedQtyColumn
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
			 public static string PurchaseOrderID = @"PurchaseOrderID";
			 public static string PurchaseOrderDetailID = @"PurchaseOrderDetailID";
			 public static string DueDate = @"DueDate";
			 public static string OrderQty = @"OrderQty";
			 public static string ProductID = @"ProductID";
			 public static string UnitPrice = @"UnitPrice";
			 public static string LineTotal = @"LineTotal";
			 public static string ReceivedQty = @"ReceivedQty";
			 public static string RejectedQty = @"RejectedQty";
			 public static string StockedQty = @"StockedQty";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
