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
	/// Strongly-typed collection for the PurchaseOrderHeader class.
	/// </summary>
    [Serializable]
	public partial class PurchaseOrderHeaderCollection : ActiveList<PurchaseOrderHeader, PurchaseOrderHeaderCollection>
	{	   
		public PurchaseOrderHeaderCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>PurchaseOrderHeaderCollection</returns>
		public PurchaseOrderHeaderCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                PurchaseOrderHeader o = this[i];
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
	/// This is an ActiveRecord class which wraps the PurchaseOrderHeader table.
	/// </summary>
	[Serializable]
	public partial class PurchaseOrderHeader : ActiveRecord<PurchaseOrderHeader>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public PurchaseOrderHeader()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public PurchaseOrderHeader(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public PurchaseOrderHeader(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public PurchaseOrderHeader(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("PurchaseOrderHeader", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Purchasing";
				//columns
				
				TableSchema.TableColumn colvarPurchaseOrderID = new TableSchema.TableColumn(schema);
				colvarPurchaseOrderID.ColumnName = "PurchaseOrderID";
				colvarPurchaseOrderID.DataType = DbType.Int32;
				colvarPurchaseOrderID.MaxLength = 0;
				colvarPurchaseOrderID.AutoIncrement = true;
				colvarPurchaseOrderID.IsNullable = false;
				colvarPurchaseOrderID.IsPrimaryKey = true;
				colvarPurchaseOrderID.IsForeignKey = false;
				colvarPurchaseOrderID.IsReadOnly = false;
				colvarPurchaseOrderID.DefaultSetting = @"";
				colvarPurchaseOrderID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPurchaseOrderID);
				
				TableSchema.TableColumn colvarRevisionNumber = new TableSchema.TableColumn(schema);
				colvarRevisionNumber.ColumnName = "RevisionNumber";
				colvarRevisionNumber.DataType = DbType.Byte;
				colvarRevisionNumber.MaxLength = 0;
				colvarRevisionNumber.AutoIncrement = false;
				colvarRevisionNumber.IsNullable = false;
				colvarRevisionNumber.IsPrimaryKey = false;
				colvarRevisionNumber.IsForeignKey = false;
				colvarRevisionNumber.IsReadOnly = false;
				
						colvarRevisionNumber.DefaultSetting = @"((0))";
				colvarRevisionNumber.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRevisionNumber);
				
				TableSchema.TableColumn colvarStatus = new TableSchema.TableColumn(schema);
				colvarStatus.ColumnName = "Status";
				colvarStatus.DataType = DbType.Byte;
				colvarStatus.MaxLength = 0;
				colvarStatus.AutoIncrement = false;
				colvarStatus.IsNullable = false;
				colvarStatus.IsPrimaryKey = false;
				colvarStatus.IsForeignKey = false;
				colvarStatus.IsReadOnly = false;
				
						colvarStatus.DefaultSetting = @"((1))";
				colvarStatus.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStatus);
				
				TableSchema.TableColumn colvarEmployeeID = new TableSchema.TableColumn(schema);
				colvarEmployeeID.ColumnName = "EmployeeID";
				colvarEmployeeID.DataType = DbType.Int32;
				colvarEmployeeID.MaxLength = 0;
				colvarEmployeeID.AutoIncrement = false;
				colvarEmployeeID.IsNullable = false;
				colvarEmployeeID.IsPrimaryKey = false;
				colvarEmployeeID.IsForeignKey = true;
				colvarEmployeeID.IsReadOnly = false;
				colvarEmployeeID.DefaultSetting = @"";
				
					colvarEmployeeID.ForeignKeyTableName = "Employee";
				schema.Columns.Add(colvarEmployeeID);
				
				TableSchema.TableColumn colvarVendorID = new TableSchema.TableColumn(schema);
				colvarVendorID.ColumnName = "VendorID";
				colvarVendorID.DataType = DbType.Int32;
				colvarVendorID.MaxLength = 0;
				colvarVendorID.AutoIncrement = false;
				colvarVendorID.IsNullable = false;
				colvarVendorID.IsPrimaryKey = false;
				colvarVendorID.IsForeignKey = true;
				colvarVendorID.IsReadOnly = false;
				colvarVendorID.DefaultSetting = @"";
				
					colvarVendorID.ForeignKeyTableName = "Vendor";
				schema.Columns.Add(colvarVendorID);
				
				TableSchema.TableColumn colvarShipMethodID = new TableSchema.TableColumn(schema);
				colvarShipMethodID.ColumnName = "ShipMethodID";
				colvarShipMethodID.DataType = DbType.Int32;
				colvarShipMethodID.MaxLength = 0;
				colvarShipMethodID.AutoIncrement = false;
				colvarShipMethodID.IsNullable = false;
				colvarShipMethodID.IsPrimaryKey = false;
				colvarShipMethodID.IsForeignKey = true;
				colvarShipMethodID.IsReadOnly = false;
				colvarShipMethodID.DefaultSetting = @"";
				
					colvarShipMethodID.ForeignKeyTableName = "ShipMethod";
				schema.Columns.Add(colvarShipMethodID);
				
				TableSchema.TableColumn colvarOrderDate = new TableSchema.TableColumn(schema);
				colvarOrderDate.ColumnName = "OrderDate";
				colvarOrderDate.DataType = DbType.DateTime;
				colvarOrderDate.MaxLength = 0;
				colvarOrderDate.AutoIncrement = false;
				colvarOrderDate.IsNullable = false;
				colvarOrderDate.IsPrimaryKey = false;
				colvarOrderDate.IsForeignKey = false;
				colvarOrderDate.IsReadOnly = false;
				
						colvarOrderDate.DefaultSetting = @"(getdate())";
				colvarOrderDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOrderDate);
				
				TableSchema.TableColumn colvarShipDate = new TableSchema.TableColumn(schema);
				colvarShipDate.ColumnName = "ShipDate";
				colvarShipDate.DataType = DbType.DateTime;
				colvarShipDate.MaxLength = 0;
				colvarShipDate.AutoIncrement = false;
				colvarShipDate.IsNullable = true;
				colvarShipDate.IsPrimaryKey = false;
				colvarShipDate.IsForeignKey = false;
				colvarShipDate.IsReadOnly = false;
				colvarShipDate.DefaultSetting = @"";
				colvarShipDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarShipDate);
				
				TableSchema.TableColumn colvarSubTotal = new TableSchema.TableColumn(schema);
				colvarSubTotal.ColumnName = "SubTotal";
				colvarSubTotal.DataType = DbType.Currency;
				colvarSubTotal.MaxLength = 0;
				colvarSubTotal.AutoIncrement = false;
				colvarSubTotal.IsNullable = false;
				colvarSubTotal.IsPrimaryKey = false;
				colvarSubTotal.IsForeignKey = false;
				colvarSubTotal.IsReadOnly = false;
				
						colvarSubTotal.DefaultSetting = @"((0.00))";
				colvarSubTotal.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSubTotal);
				
				TableSchema.TableColumn colvarTaxAmt = new TableSchema.TableColumn(schema);
				colvarTaxAmt.ColumnName = "TaxAmt";
				colvarTaxAmt.DataType = DbType.Currency;
				colvarTaxAmt.MaxLength = 0;
				colvarTaxAmt.AutoIncrement = false;
				colvarTaxAmt.IsNullable = false;
				colvarTaxAmt.IsPrimaryKey = false;
				colvarTaxAmt.IsForeignKey = false;
				colvarTaxAmt.IsReadOnly = false;
				
						colvarTaxAmt.DefaultSetting = @"((0.00))";
				colvarTaxAmt.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTaxAmt);
				
				TableSchema.TableColumn colvarFreight = new TableSchema.TableColumn(schema);
				colvarFreight.ColumnName = "Freight";
				colvarFreight.DataType = DbType.Currency;
				colvarFreight.MaxLength = 0;
				colvarFreight.AutoIncrement = false;
				colvarFreight.IsNullable = false;
				colvarFreight.IsPrimaryKey = false;
				colvarFreight.IsForeignKey = false;
				colvarFreight.IsReadOnly = false;
				
						colvarFreight.DefaultSetting = @"((0.00))";
				colvarFreight.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFreight);
				
				TableSchema.TableColumn colvarTotalDue = new TableSchema.TableColumn(schema);
				colvarTotalDue.ColumnName = "TotalDue";
				colvarTotalDue.DataType = DbType.Currency;
				colvarTotalDue.MaxLength = 0;
				colvarTotalDue.AutoIncrement = false;
				colvarTotalDue.IsNullable = false;
				colvarTotalDue.IsPrimaryKey = false;
				colvarTotalDue.IsForeignKey = false;
				colvarTotalDue.IsReadOnly = true;
				colvarTotalDue.DefaultSetting = @"";
				colvarTotalDue.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTotalDue);
				
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
				DataService.Providers["AdventureWorks"].AddSchema("PurchaseOrderHeader",schema);
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
		  
		[XmlAttribute("RevisionNumber")]
		[Bindable(true)]
		public byte RevisionNumber 
		{
			get { return GetColumnValue<byte>(Columns.RevisionNumber); }
			set { SetColumnValue(Columns.RevisionNumber, value); }
		}
		  
		[XmlAttribute("Status")]
		[Bindable(true)]
		public byte Status 
		{
			get { return GetColumnValue<byte>(Columns.Status); }
			set { SetColumnValue(Columns.Status, value); }
		}
		  
		[XmlAttribute("EmployeeID")]
		[Bindable(true)]
		public int EmployeeID 
		{
			get { return GetColumnValue<int>(Columns.EmployeeID); }
			set { SetColumnValue(Columns.EmployeeID, value); }
		}
		  
		[XmlAttribute("VendorID")]
		[Bindable(true)]
		public int VendorID 
		{
			get { return GetColumnValue<int>(Columns.VendorID); }
			set { SetColumnValue(Columns.VendorID, value); }
		}
		  
		[XmlAttribute("ShipMethodID")]
		[Bindable(true)]
		public int ShipMethodID 
		{
			get { return GetColumnValue<int>(Columns.ShipMethodID); }
			set { SetColumnValue(Columns.ShipMethodID, value); }
		}
		  
		[XmlAttribute("OrderDate")]
		[Bindable(true)]
		public DateTime OrderDate 
		{
			get { return GetColumnValue<DateTime>(Columns.OrderDate); }
			set { SetColumnValue(Columns.OrderDate, value); }
		}
		  
		[XmlAttribute("ShipDate")]
		[Bindable(true)]
		public DateTime? ShipDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.ShipDate); }
			set { SetColumnValue(Columns.ShipDate, value); }
		}
		  
		[XmlAttribute("SubTotal")]
		[Bindable(true)]
		public decimal SubTotal 
		{
			get { return GetColumnValue<decimal>(Columns.SubTotal); }
			set { SetColumnValue(Columns.SubTotal, value); }
		}
		  
		[XmlAttribute("TaxAmt")]
		[Bindable(true)]
		public decimal TaxAmt 
		{
			get { return GetColumnValue<decimal>(Columns.TaxAmt); }
			set { SetColumnValue(Columns.TaxAmt, value); }
		}
		  
		[XmlAttribute("Freight")]
		[Bindable(true)]
		public decimal Freight 
		{
			get { return GetColumnValue<decimal>(Columns.Freight); }
			set { SetColumnValue(Columns.Freight, value); }
		}
		  
		[XmlAttribute("TotalDue")]
		[Bindable(true)]
		public decimal TotalDue 
		{
			get { return GetColumnValue<decimal>(Columns.TotalDue); }
			set { SetColumnValue(Columns.TotalDue, value); }
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
        
		
		public AdventureWorks.PurchaseOrderDetailCollection PurchaseOrderDetailRecords()
		{
			return new AdventureWorks.PurchaseOrderDetailCollection().Where(PurchaseOrderDetail.Columns.PurchaseOrderID, PurchaseOrderID).Load();
		}
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Employee ActiveRecord object related to this PurchaseOrderHeader
		/// 
		/// </summary>
		public AdventureWorks.Employee Employee
		{
			get { return AdventureWorks.Employee.FetchByID(this.EmployeeID); }
			set { SetColumnValue("EmployeeID", value.EmployeeID); }
		}
		
		
		/// <summary>
		/// Returns a ShipMethod ActiveRecord object related to this PurchaseOrderHeader
		/// 
		/// </summary>
		public AdventureWorks.ShipMethod ShipMethod
		{
			get { return AdventureWorks.ShipMethod.FetchByID(this.ShipMethodID); }
			set { SetColumnValue("ShipMethodID", value.ShipMethodID); }
		}
		
		
		/// <summary>
		/// Returns a Vendor ActiveRecord object related to this PurchaseOrderHeader
		/// 
		/// </summary>
		public AdventureWorks.Vendor Vendor
		{
			get { return AdventureWorks.Vendor.FetchByID(this.VendorID); }
			set { SetColumnValue("VendorID", value.VendorID); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(byte varRevisionNumber,byte varStatus,int varEmployeeID,int varVendorID,int varShipMethodID,DateTime varOrderDate,DateTime? varShipDate,decimal varSubTotal,decimal varTaxAmt,decimal varFreight,decimal varTotalDue,DateTime varModifiedDate)
		{
			PurchaseOrderHeader item = new PurchaseOrderHeader();
			
			item.RevisionNumber = varRevisionNumber;
			
			item.Status = varStatus;
			
			item.EmployeeID = varEmployeeID;
			
			item.VendorID = varVendorID;
			
			item.ShipMethodID = varShipMethodID;
			
			item.OrderDate = varOrderDate;
			
			item.ShipDate = varShipDate;
			
			item.SubTotal = varSubTotal;
			
			item.TaxAmt = varTaxAmt;
			
			item.Freight = varFreight;
			
			item.TotalDue = varTotalDue;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varPurchaseOrderID,byte varRevisionNumber,byte varStatus,int varEmployeeID,int varVendorID,int varShipMethodID,DateTime varOrderDate,DateTime? varShipDate,decimal varSubTotal,decimal varTaxAmt,decimal varFreight,decimal varTotalDue,DateTime varModifiedDate)
		{
			PurchaseOrderHeader item = new PurchaseOrderHeader();
			
				item.PurchaseOrderID = varPurchaseOrderID;
			
				item.RevisionNumber = varRevisionNumber;
			
				item.Status = varStatus;
			
				item.EmployeeID = varEmployeeID;
			
				item.VendorID = varVendorID;
			
				item.ShipMethodID = varShipMethodID;
			
				item.OrderDate = varOrderDate;
			
				item.ShipDate = varShipDate;
			
				item.SubTotal = varSubTotal;
			
				item.TaxAmt = varTaxAmt;
			
				item.Freight = varFreight;
			
				item.TotalDue = varTotalDue;
			
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
        
        
        
        public static TableSchema.TableColumn RevisionNumberColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn StatusColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn EmployeeIDColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn VendorIDColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ShipMethodIDColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn OrderDateColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn ShipDateColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn SubTotalColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn TaxAmtColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn FreightColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn TotalDueColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedDateColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string PurchaseOrderID = @"PurchaseOrderID";
			 public static string RevisionNumber = @"RevisionNumber";
			 public static string Status = @"Status";
			 public static string EmployeeID = @"EmployeeID";
			 public static string VendorID = @"VendorID";
			 public static string ShipMethodID = @"ShipMethodID";
			 public static string OrderDate = @"OrderDate";
			 public static string ShipDate = @"ShipDate";
			 public static string SubTotal = @"SubTotal";
			 public static string TaxAmt = @"TaxAmt";
			 public static string Freight = @"Freight";
			 public static string TotalDue = @"TotalDue";
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
