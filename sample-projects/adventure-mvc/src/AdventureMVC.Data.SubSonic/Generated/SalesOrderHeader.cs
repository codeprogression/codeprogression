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
	/// Strongly-typed collection for the SalesOrderHeader class.
	/// </summary>
    [Serializable]
	public partial class SalesOrderHeaderCollection : ActiveList<SalesOrderHeader, SalesOrderHeaderCollection>
	{	   
		public SalesOrderHeaderCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SalesOrderHeaderCollection</returns>
		public SalesOrderHeaderCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SalesOrderHeader o = this[i];
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
	/// This is an ActiveRecord class which wraps the SalesOrderHeader table.
	/// </summary>
	[Serializable]
	public partial class SalesOrderHeader : ActiveRecord<SalesOrderHeader>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SalesOrderHeader()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SalesOrderHeader(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SalesOrderHeader(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SalesOrderHeader(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("SalesOrderHeader", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Sales";
				//columns
				
				TableSchema.TableColumn colvarSalesOrderID = new TableSchema.TableColumn(schema);
				colvarSalesOrderID.ColumnName = "SalesOrderID";
				colvarSalesOrderID.DataType = DbType.Int32;
				colvarSalesOrderID.MaxLength = 0;
				colvarSalesOrderID.AutoIncrement = true;
				colvarSalesOrderID.IsNullable = false;
				colvarSalesOrderID.IsPrimaryKey = true;
				colvarSalesOrderID.IsForeignKey = false;
				colvarSalesOrderID.IsReadOnly = false;
				colvarSalesOrderID.DefaultSetting = @"";
				colvarSalesOrderID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSalesOrderID);
				
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
				
				TableSchema.TableColumn colvarOnlineOrderFlag = new TableSchema.TableColumn(schema);
				colvarOnlineOrderFlag.ColumnName = "OnlineOrderFlag";
				colvarOnlineOrderFlag.DataType = DbType.Boolean;
				colvarOnlineOrderFlag.MaxLength = 0;
				colvarOnlineOrderFlag.AutoIncrement = false;
				colvarOnlineOrderFlag.IsNullable = false;
				colvarOnlineOrderFlag.IsPrimaryKey = false;
				colvarOnlineOrderFlag.IsForeignKey = false;
				colvarOnlineOrderFlag.IsReadOnly = false;
				
						colvarOnlineOrderFlag.DefaultSetting = @"((1))";
				colvarOnlineOrderFlag.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOnlineOrderFlag);
				
				TableSchema.TableColumn colvarSalesOrderNumber = new TableSchema.TableColumn(schema);
				colvarSalesOrderNumber.ColumnName = "SalesOrderNumber";
				colvarSalesOrderNumber.DataType = DbType.String;
				colvarSalesOrderNumber.MaxLength = 25;
				colvarSalesOrderNumber.AutoIncrement = false;
				colvarSalesOrderNumber.IsNullable = false;
				colvarSalesOrderNumber.IsPrimaryKey = false;
				colvarSalesOrderNumber.IsForeignKey = false;
				colvarSalesOrderNumber.IsReadOnly = true;
				colvarSalesOrderNumber.DefaultSetting = @"";
				colvarSalesOrderNumber.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSalesOrderNumber);
				
				TableSchema.TableColumn colvarPurchaseOrderNumber = new TableSchema.TableColumn(schema);
				colvarPurchaseOrderNumber.ColumnName = "PurchaseOrderNumber";
				colvarPurchaseOrderNumber.DataType = DbType.String;
				colvarPurchaseOrderNumber.MaxLength = 25;
				colvarPurchaseOrderNumber.AutoIncrement = false;
				colvarPurchaseOrderNumber.IsNullable = true;
				colvarPurchaseOrderNumber.IsPrimaryKey = false;
				colvarPurchaseOrderNumber.IsForeignKey = false;
				colvarPurchaseOrderNumber.IsReadOnly = false;
				colvarPurchaseOrderNumber.DefaultSetting = @"";
				colvarPurchaseOrderNumber.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPurchaseOrderNumber);
				
				TableSchema.TableColumn colvarAccountNumber = new TableSchema.TableColumn(schema);
				colvarAccountNumber.ColumnName = "AccountNumber";
				colvarAccountNumber.DataType = DbType.String;
				colvarAccountNumber.MaxLength = 15;
				colvarAccountNumber.AutoIncrement = false;
				colvarAccountNumber.IsNullable = true;
				colvarAccountNumber.IsPrimaryKey = false;
				colvarAccountNumber.IsForeignKey = false;
				colvarAccountNumber.IsReadOnly = false;
				colvarAccountNumber.DefaultSetting = @"";
				colvarAccountNumber.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAccountNumber);
				
				TableSchema.TableColumn colvarCustomerID = new TableSchema.TableColumn(schema);
				colvarCustomerID.ColumnName = "CustomerID";
				colvarCustomerID.DataType = DbType.Int32;
				colvarCustomerID.MaxLength = 0;
				colvarCustomerID.AutoIncrement = false;
				colvarCustomerID.IsNullable = false;
				colvarCustomerID.IsPrimaryKey = false;
				colvarCustomerID.IsForeignKey = true;
				colvarCustomerID.IsReadOnly = false;
				colvarCustomerID.DefaultSetting = @"";
				
					colvarCustomerID.ForeignKeyTableName = "Customer";
				schema.Columns.Add(colvarCustomerID);
				
				TableSchema.TableColumn colvarContactID = new TableSchema.TableColumn(schema);
				colvarContactID.ColumnName = "ContactID";
				colvarContactID.DataType = DbType.Int32;
				colvarContactID.MaxLength = 0;
				colvarContactID.AutoIncrement = false;
				colvarContactID.IsNullable = false;
				colvarContactID.IsPrimaryKey = false;
				colvarContactID.IsForeignKey = true;
				colvarContactID.IsReadOnly = false;
				colvarContactID.DefaultSetting = @"";
				
					colvarContactID.ForeignKeyTableName = "Contact";
				schema.Columns.Add(colvarContactID);
				
				TableSchema.TableColumn colvarSalesPersonID = new TableSchema.TableColumn(schema);
				colvarSalesPersonID.ColumnName = "SalesPersonID";
				colvarSalesPersonID.DataType = DbType.Int32;
				colvarSalesPersonID.MaxLength = 0;
				colvarSalesPersonID.AutoIncrement = false;
				colvarSalesPersonID.IsNullable = true;
				colvarSalesPersonID.IsPrimaryKey = false;
				colvarSalesPersonID.IsForeignKey = true;
				colvarSalesPersonID.IsReadOnly = false;
				colvarSalesPersonID.DefaultSetting = @"";
				
					colvarSalesPersonID.ForeignKeyTableName = "SalesPerson";
				schema.Columns.Add(colvarSalesPersonID);
				
				TableSchema.TableColumn colvarTerritoryID = new TableSchema.TableColumn(schema);
				colvarTerritoryID.ColumnName = "TerritoryID";
				colvarTerritoryID.DataType = DbType.Int32;
				colvarTerritoryID.MaxLength = 0;
				colvarTerritoryID.AutoIncrement = false;
				colvarTerritoryID.IsNullable = true;
				colvarTerritoryID.IsPrimaryKey = false;
				colvarTerritoryID.IsForeignKey = true;
				colvarTerritoryID.IsReadOnly = false;
				colvarTerritoryID.DefaultSetting = @"";
				
					colvarTerritoryID.ForeignKeyTableName = "SalesTerritory";
				schema.Columns.Add(colvarTerritoryID);
				
				TableSchema.TableColumn colvarBillToAddressID = new TableSchema.TableColumn(schema);
				colvarBillToAddressID.ColumnName = "BillToAddressID";
				colvarBillToAddressID.DataType = DbType.Int32;
				colvarBillToAddressID.MaxLength = 0;
				colvarBillToAddressID.AutoIncrement = false;
				colvarBillToAddressID.IsNullable = false;
				colvarBillToAddressID.IsPrimaryKey = false;
				colvarBillToAddressID.IsForeignKey = true;
				colvarBillToAddressID.IsReadOnly = false;
				colvarBillToAddressID.DefaultSetting = @"";
				
					colvarBillToAddressID.ForeignKeyTableName = "Address";
				schema.Columns.Add(colvarBillToAddressID);
				
				TableSchema.TableColumn colvarShipToAddressID = new TableSchema.TableColumn(schema);
				colvarShipToAddressID.ColumnName = "ShipToAddressID";
				colvarShipToAddressID.DataType = DbType.Int32;
				colvarShipToAddressID.MaxLength = 0;
				colvarShipToAddressID.AutoIncrement = false;
				colvarShipToAddressID.IsNullable = false;
				colvarShipToAddressID.IsPrimaryKey = false;
				colvarShipToAddressID.IsForeignKey = true;
				colvarShipToAddressID.IsReadOnly = false;
				colvarShipToAddressID.DefaultSetting = @"";
				
					colvarShipToAddressID.ForeignKeyTableName = "Address";
				schema.Columns.Add(colvarShipToAddressID);
				
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
				
				TableSchema.TableColumn colvarCreditCardID = new TableSchema.TableColumn(schema);
				colvarCreditCardID.ColumnName = "CreditCardID";
				colvarCreditCardID.DataType = DbType.Int32;
				colvarCreditCardID.MaxLength = 0;
				colvarCreditCardID.AutoIncrement = false;
				colvarCreditCardID.IsNullable = true;
				colvarCreditCardID.IsPrimaryKey = false;
				colvarCreditCardID.IsForeignKey = true;
				colvarCreditCardID.IsReadOnly = false;
				colvarCreditCardID.DefaultSetting = @"";
				
					colvarCreditCardID.ForeignKeyTableName = "CreditCard";
				schema.Columns.Add(colvarCreditCardID);
				
				TableSchema.TableColumn colvarCreditCardApprovalCode = new TableSchema.TableColumn(schema);
				colvarCreditCardApprovalCode.ColumnName = "CreditCardApprovalCode";
				colvarCreditCardApprovalCode.DataType = DbType.AnsiString;
				colvarCreditCardApprovalCode.MaxLength = 15;
				colvarCreditCardApprovalCode.AutoIncrement = false;
				colvarCreditCardApprovalCode.IsNullable = true;
				colvarCreditCardApprovalCode.IsPrimaryKey = false;
				colvarCreditCardApprovalCode.IsForeignKey = false;
				colvarCreditCardApprovalCode.IsReadOnly = false;
				colvarCreditCardApprovalCode.DefaultSetting = @"";
				colvarCreditCardApprovalCode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreditCardApprovalCode);
				
				TableSchema.TableColumn colvarCurrencyRateID = new TableSchema.TableColumn(schema);
				colvarCurrencyRateID.ColumnName = "CurrencyRateID";
				colvarCurrencyRateID.DataType = DbType.Int32;
				colvarCurrencyRateID.MaxLength = 0;
				colvarCurrencyRateID.AutoIncrement = false;
				colvarCurrencyRateID.IsNullable = true;
				colvarCurrencyRateID.IsPrimaryKey = false;
				colvarCurrencyRateID.IsForeignKey = true;
				colvarCurrencyRateID.IsReadOnly = false;
				colvarCurrencyRateID.DefaultSetting = @"";
				
					colvarCurrencyRateID.ForeignKeyTableName = "CurrencyRate";
				schema.Columns.Add(colvarCurrencyRateID);
				
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
				
				TableSchema.TableColumn colvarComment = new TableSchema.TableColumn(schema);
				colvarComment.ColumnName = "Comment";
				colvarComment.DataType = DbType.String;
				colvarComment.MaxLength = 128;
				colvarComment.AutoIncrement = false;
				colvarComment.IsNullable = true;
				colvarComment.IsPrimaryKey = false;
				colvarComment.IsForeignKey = false;
				colvarComment.IsReadOnly = false;
				colvarComment.DefaultSetting = @"";
				colvarComment.ForeignKeyTableName = "";
				schema.Columns.Add(colvarComment);
				
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
				DataService.Providers["AdventureWorks"].AddSchema("SalesOrderHeader",schema);
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
		  
		[XmlAttribute("RevisionNumber")]
		[Bindable(true)]
		public byte RevisionNumber 
		{
			get { return GetColumnValue<byte>(Columns.RevisionNumber); }
			set { SetColumnValue(Columns.RevisionNumber, value); }
		}
		  
		[XmlAttribute("OrderDate")]
		[Bindable(true)]
		public DateTime OrderDate 
		{
			get { return GetColumnValue<DateTime>(Columns.OrderDate); }
			set { SetColumnValue(Columns.OrderDate, value); }
		}
		  
		[XmlAttribute("DueDate")]
		[Bindable(true)]
		public DateTime DueDate 
		{
			get { return GetColumnValue<DateTime>(Columns.DueDate); }
			set { SetColumnValue(Columns.DueDate, value); }
		}
		  
		[XmlAttribute("ShipDate")]
		[Bindable(true)]
		public DateTime? ShipDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.ShipDate); }
			set { SetColumnValue(Columns.ShipDate, value); }
		}
		  
		[XmlAttribute("Status")]
		[Bindable(true)]
		public byte Status 
		{
			get { return GetColumnValue<byte>(Columns.Status); }
			set { SetColumnValue(Columns.Status, value); }
		}
		  
		[XmlAttribute("OnlineOrderFlag")]
		[Bindable(true)]
		public bool OnlineOrderFlag 
		{
			get { return GetColumnValue<bool>(Columns.OnlineOrderFlag); }
			set { SetColumnValue(Columns.OnlineOrderFlag, value); }
		}
		  
		[XmlAttribute("SalesOrderNumber")]
		[Bindable(true)]
		public string SalesOrderNumber 
		{
			get { return GetColumnValue<string>(Columns.SalesOrderNumber); }
			set { SetColumnValue(Columns.SalesOrderNumber, value); }
		}
		  
		[XmlAttribute("PurchaseOrderNumber")]
		[Bindable(true)]
		public string PurchaseOrderNumber 
		{
			get { return GetColumnValue<string>(Columns.PurchaseOrderNumber); }
			set { SetColumnValue(Columns.PurchaseOrderNumber, value); }
		}
		  
		[XmlAttribute("AccountNumber")]
		[Bindable(true)]
		public string AccountNumber 
		{
			get { return GetColumnValue<string>(Columns.AccountNumber); }
			set { SetColumnValue(Columns.AccountNumber, value); }
		}
		  
		[XmlAttribute("CustomerID")]
		[Bindable(true)]
		public int CustomerID 
		{
			get { return GetColumnValue<int>(Columns.CustomerID); }
			set { SetColumnValue(Columns.CustomerID, value); }
		}
		  
		[XmlAttribute("ContactID")]
		[Bindable(true)]
		public int ContactID 
		{
			get { return GetColumnValue<int>(Columns.ContactID); }
			set { SetColumnValue(Columns.ContactID, value); }
		}
		  
		[XmlAttribute("SalesPersonID")]
		[Bindable(true)]
		public int? SalesPersonID 
		{
			get { return GetColumnValue<int?>(Columns.SalesPersonID); }
			set { SetColumnValue(Columns.SalesPersonID, value); }
		}
		  
		[XmlAttribute("TerritoryID")]
		[Bindable(true)]
		public int? TerritoryID 
		{
			get { return GetColumnValue<int?>(Columns.TerritoryID); }
			set { SetColumnValue(Columns.TerritoryID, value); }
		}
		  
		[XmlAttribute("BillToAddressID")]
		[Bindable(true)]
		public int BillToAddressID 
		{
			get { return GetColumnValue<int>(Columns.BillToAddressID); }
			set { SetColumnValue(Columns.BillToAddressID, value); }
		}
		  
		[XmlAttribute("ShipToAddressID")]
		[Bindable(true)]
		public int ShipToAddressID 
		{
			get { return GetColumnValue<int>(Columns.ShipToAddressID); }
			set { SetColumnValue(Columns.ShipToAddressID, value); }
		}
		  
		[XmlAttribute("ShipMethodID")]
		[Bindable(true)]
		public int ShipMethodID 
		{
			get { return GetColumnValue<int>(Columns.ShipMethodID); }
			set { SetColumnValue(Columns.ShipMethodID, value); }
		}
		  
		[XmlAttribute("CreditCardID")]
		[Bindable(true)]
		public int? CreditCardID 
		{
			get { return GetColumnValue<int?>(Columns.CreditCardID); }
			set { SetColumnValue(Columns.CreditCardID, value); }
		}
		  
		[XmlAttribute("CreditCardApprovalCode")]
		[Bindable(true)]
		public string CreditCardApprovalCode 
		{
			get { return GetColumnValue<string>(Columns.CreditCardApprovalCode); }
			set { SetColumnValue(Columns.CreditCardApprovalCode, value); }
		}
		  
		[XmlAttribute("CurrencyRateID")]
		[Bindable(true)]
		public int? CurrencyRateID 
		{
			get { return GetColumnValue<int?>(Columns.CurrencyRateID); }
			set { SetColumnValue(Columns.CurrencyRateID, value); }
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
		  
		[XmlAttribute("Comment")]
		[Bindable(true)]
		public string Comment 
		{
			get { return GetColumnValue<string>(Columns.Comment); }
			set { SetColumnValue(Columns.Comment, value); }
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
        
		
		public AdventureWorks.SalesOrderDetailCollection SalesOrderDetailRecords()
		{
			return new AdventureWorks.SalesOrderDetailCollection().Where(SalesOrderDetail.Columns.SalesOrderID, SalesOrderID).Load();
		}
		public AdventureWorks.SalesOrderHeaderSalesReasonCollection SalesOrderHeaderSalesReasonRecords()
		{
			return new AdventureWorks.SalesOrderHeaderSalesReasonCollection().Where(SalesOrderHeaderSalesReason.Columns.SalesOrderID, SalesOrderID).Load();
		}
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Address ActiveRecord object related to this SalesOrderHeader
		/// 
		/// </summary>
		public AdventureWorks.Address Address
		{
			get { return AdventureWorks.Address.FetchByID(this.BillToAddressID); }
			set { SetColumnValue("BillToAddressID", value.AddressID); }
		}
		
		
		/// <summary>
		/// Returns a Address ActiveRecord object related to this SalesOrderHeader
		/// 
		/// </summary>
		public AdventureWorks.Address AddressToShipToAddressID
		{
			get { return AdventureWorks.Address.FetchByID(this.ShipToAddressID); }
			set { SetColumnValue("ShipToAddressID", value.AddressID); }
		}
		
		
		/// <summary>
		/// Returns a Contact ActiveRecord object related to this SalesOrderHeader
		/// 
		/// </summary>
		public AdventureWorks.Contact Contact
		{
			get { return AdventureWorks.Contact.FetchByID(this.ContactID); }
			set { SetColumnValue("ContactID", value.ContactID); }
		}
		
		
		/// <summary>
		/// Returns a CreditCard ActiveRecord object related to this SalesOrderHeader
		/// 
		/// </summary>
		public AdventureWorks.CreditCard CreditCard
		{
			get { return AdventureWorks.CreditCard.FetchByID(this.CreditCardID); }
			set { SetColumnValue("CreditCardID", value.CreditCardID); }
		}
		
		
		/// <summary>
		/// Returns a CurrencyRate ActiveRecord object related to this SalesOrderHeader
		/// 
		/// </summary>
		public AdventureWorks.CurrencyRate CurrencyRate
		{
			get { return AdventureWorks.CurrencyRate.FetchByID(this.CurrencyRateID); }
			set { SetColumnValue("CurrencyRateID", value.CurrencyRateID); }
		}
		
		
		/// <summary>
		/// Returns a Customer ActiveRecord object related to this SalesOrderHeader
		/// 
		/// </summary>
		public AdventureWorks.Customer Customer
		{
			get { return AdventureWorks.Customer.FetchByID(this.CustomerID); }
			set { SetColumnValue("CustomerID", value.CustomerID); }
		}
		
		
		/// <summary>
		/// Returns a SalesPerson ActiveRecord object related to this SalesOrderHeader
		/// 
		/// </summary>
		public AdventureWorks.SalesPerson SalesPerson
		{
			get { return AdventureWorks.SalesPerson.FetchByID(this.SalesPersonID); }
			set { SetColumnValue("SalesPersonID", value.SalesPersonID); }
		}
		
		
		/// <summary>
		/// Returns a SalesTerritory ActiveRecord object related to this SalesOrderHeader
		/// 
		/// </summary>
		public AdventureWorks.SalesTerritory SalesTerritory
		{
			get { return AdventureWorks.SalesTerritory.FetchByID(this.TerritoryID); }
			set { SetColumnValue("TerritoryID", value.TerritoryID); }
		}
		
		
		/// <summary>
		/// Returns a ShipMethod ActiveRecord object related to this SalesOrderHeader
		/// 
		/// </summary>
		public AdventureWorks.ShipMethod ShipMethod
		{
			get { return AdventureWorks.ShipMethod.FetchByID(this.ShipMethodID); }
			set { SetColumnValue("ShipMethodID", value.ShipMethodID); }
		}
		
		
		#endregion
		
		
		
		#region Many To Many Helpers
		
		 
		public AdventureWorks.SalesReasonCollection GetSalesReasonCollection() { return SalesOrderHeader.GetSalesReasonCollection(this.SalesOrderID); }
		public static AdventureWorks.SalesReasonCollection GetSalesReasonCollection(int varSalesOrderID)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [Sales].[SalesReason] INNER JOIN [SalesOrderHeaderSalesReason] ON [SalesReason].[SalesReasonID] = [SalesOrderHeaderSalesReason].[SalesReasonID] WHERE [SalesOrderHeaderSalesReason].[SalesOrderID] = @SalesOrderID", SalesOrderHeader.Schema.Provider.Name);
			cmd.AddParameter("@SalesOrderID", varSalesOrderID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			SalesReasonCollection coll = new SalesReasonCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveSalesReasonMap(int varSalesOrderID, SalesReasonCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [SalesOrderHeaderSalesReason] WHERE [SalesOrderHeaderSalesReason].[SalesOrderID] = @SalesOrderID", SalesOrderHeader.Schema.Provider.Name);
			cmdDel.AddParameter("@SalesOrderID", varSalesOrderID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (SalesReason item in items)
			{
				SalesOrderHeaderSalesReason varSalesOrderHeaderSalesReason = new SalesOrderHeaderSalesReason();
				varSalesOrderHeaderSalesReason.SetColumnValue("SalesOrderID", varSalesOrderID);
				varSalesOrderHeaderSalesReason.SetColumnValue("SalesReasonID", item.GetPrimaryKeyValue());
				varSalesOrderHeaderSalesReason.Save();
			}
		}
		public static void SaveSalesReasonMap(int varSalesOrderID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [SalesOrderHeaderSalesReason] WHERE [SalesOrderHeaderSalesReason].[SalesOrderID] = @SalesOrderID", SalesOrderHeader.Schema.Provider.Name);
			cmdDel.AddParameter("@SalesOrderID", varSalesOrderID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					SalesOrderHeaderSalesReason varSalesOrderHeaderSalesReason = new SalesOrderHeaderSalesReason();
					varSalesOrderHeaderSalesReason.SetColumnValue("SalesOrderID", varSalesOrderID);
					varSalesOrderHeaderSalesReason.SetColumnValue("SalesReasonID", l.Value);
					varSalesOrderHeaderSalesReason.Save();
				}
			}
		}
		public static void SaveSalesReasonMap(int varSalesOrderID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [SalesOrderHeaderSalesReason] WHERE [SalesOrderHeaderSalesReason].[SalesOrderID] = @SalesOrderID", SalesOrderHeader.Schema.Provider.Name);
			cmdDel.AddParameter("@SalesOrderID", varSalesOrderID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				SalesOrderHeaderSalesReason varSalesOrderHeaderSalesReason = new SalesOrderHeaderSalesReason();
				varSalesOrderHeaderSalesReason.SetColumnValue("SalesOrderID", varSalesOrderID);
				varSalesOrderHeaderSalesReason.SetColumnValue("SalesReasonID", item);
				varSalesOrderHeaderSalesReason.Save();
			}
		}
		
		public static void DeleteSalesReasonMap(int varSalesOrderID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [SalesOrderHeaderSalesReason] WHERE [SalesOrderHeaderSalesReason].[SalesOrderID] = @SalesOrderID", SalesOrderHeader.Schema.Provider.Name);
			cmdDel.AddParameter("@SalesOrderID", varSalesOrderID, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		#endregion
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(byte varRevisionNumber,DateTime varOrderDate,DateTime varDueDate,DateTime? varShipDate,byte varStatus,bool varOnlineOrderFlag,string varSalesOrderNumber,string varPurchaseOrderNumber,string varAccountNumber,int varCustomerID,int varContactID,int? varSalesPersonID,int? varTerritoryID,int varBillToAddressID,int varShipToAddressID,int varShipMethodID,int? varCreditCardID,string varCreditCardApprovalCode,int? varCurrencyRateID,decimal varSubTotal,decimal varTaxAmt,decimal varFreight,decimal varTotalDue,string varComment,Guid varRowguid,DateTime varModifiedDate)
		{
			SalesOrderHeader item = new SalesOrderHeader();
			
			item.RevisionNumber = varRevisionNumber;
			
			item.OrderDate = varOrderDate;
			
			item.DueDate = varDueDate;
			
			item.ShipDate = varShipDate;
			
			item.Status = varStatus;
			
			item.OnlineOrderFlag = varOnlineOrderFlag;
			
			item.SalesOrderNumber = varSalesOrderNumber;
			
			item.PurchaseOrderNumber = varPurchaseOrderNumber;
			
			item.AccountNumber = varAccountNumber;
			
			item.CustomerID = varCustomerID;
			
			item.ContactID = varContactID;
			
			item.SalesPersonID = varSalesPersonID;
			
			item.TerritoryID = varTerritoryID;
			
			item.BillToAddressID = varBillToAddressID;
			
			item.ShipToAddressID = varShipToAddressID;
			
			item.ShipMethodID = varShipMethodID;
			
			item.CreditCardID = varCreditCardID;
			
			item.CreditCardApprovalCode = varCreditCardApprovalCode;
			
			item.CurrencyRateID = varCurrencyRateID;
			
			item.SubTotal = varSubTotal;
			
			item.TaxAmt = varTaxAmt;
			
			item.Freight = varFreight;
			
			item.TotalDue = varTotalDue;
			
			item.Comment = varComment;
			
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
		public static void Update(int varSalesOrderID,byte varRevisionNumber,DateTime varOrderDate,DateTime varDueDate,DateTime? varShipDate,byte varStatus,bool varOnlineOrderFlag,string varSalesOrderNumber,string varPurchaseOrderNumber,string varAccountNumber,int varCustomerID,int varContactID,int? varSalesPersonID,int? varTerritoryID,int varBillToAddressID,int varShipToAddressID,int varShipMethodID,int? varCreditCardID,string varCreditCardApprovalCode,int? varCurrencyRateID,decimal varSubTotal,decimal varTaxAmt,decimal varFreight,decimal varTotalDue,string varComment,Guid varRowguid,DateTime varModifiedDate)
		{
			SalesOrderHeader item = new SalesOrderHeader();
			
				item.SalesOrderID = varSalesOrderID;
			
				item.RevisionNumber = varRevisionNumber;
			
				item.OrderDate = varOrderDate;
			
				item.DueDate = varDueDate;
			
				item.ShipDate = varShipDate;
			
				item.Status = varStatus;
			
				item.OnlineOrderFlag = varOnlineOrderFlag;
			
				item.SalesOrderNumber = varSalesOrderNumber;
			
				item.PurchaseOrderNumber = varPurchaseOrderNumber;
			
				item.AccountNumber = varAccountNumber;
			
				item.CustomerID = varCustomerID;
			
				item.ContactID = varContactID;
			
				item.SalesPersonID = varSalesPersonID;
			
				item.TerritoryID = varTerritoryID;
			
				item.BillToAddressID = varBillToAddressID;
			
				item.ShipToAddressID = varShipToAddressID;
			
				item.ShipMethodID = varShipMethodID;
			
				item.CreditCardID = varCreditCardID;
			
				item.CreditCardApprovalCode = varCreditCardApprovalCode;
			
				item.CurrencyRateID = varCurrencyRateID;
			
				item.SubTotal = varSubTotal;
			
				item.TaxAmt = varTaxAmt;
			
				item.Freight = varFreight;
			
				item.TotalDue = varTotalDue;
			
				item.Comment = varComment;
			
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
        
        
        
        public static TableSchema.TableColumn RevisionNumberColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn OrderDateColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn DueDateColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ShipDateColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn StatusColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn OnlineOrderFlagColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn SalesOrderNumberColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn PurchaseOrderNumberColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn AccountNumberColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn CustomerIDColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn ContactIDColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn SalesPersonIDColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn TerritoryIDColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn BillToAddressIDColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn ShipToAddressIDColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn ShipMethodIDColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn CreditCardIDColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn CreditCardApprovalCodeColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn CurrencyRateIDColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn SubTotalColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn TaxAmtColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn FreightColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn TotalDueColumn
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn CommentColumn
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        public static TableSchema.TableColumn RowguidColumn
        {
            get { return Schema.Columns[25]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedDateColumn
        {
            get { return Schema.Columns[26]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string SalesOrderID = @"SalesOrderID";
			 public static string RevisionNumber = @"RevisionNumber";
			 public static string OrderDate = @"OrderDate";
			 public static string DueDate = @"DueDate";
			 public static string ShipDate = @"ShipDate";
			 public static string Status = @"Status";
			 public static string OnlineOrderFlag = @"OnlineOrderFlag";
			 public static string SalesOrderNumber = @"SalesOrderNumber";
			 public static string PurchaseOrderNumber = @"PurchaseOrderNumber";
			 public static string AccountNumber = @"AccountNumber";
			 public static string CustomerID = @"CustomerID";
			 public static string ContactID = @"ContactID";
			 public static string SalesPersonID = @"SalesPersonID";
			 public static string TerritoryID = @"TerritoryID";
			 public static string BillToAddressID = @"BillToAddressID";
			 public static string ShipToAddressID = @"ShipToAddressID";
			 public static string ShipMethodID = @"ShipMethodID";
			 public static string CreditCardID = @"CreditCardID";
			 public static string CreditCardApprovalCode = @"CreditCardApprovalCode";
			 public static string CurrencyRateID = @"CurrencyRateID";
			 public static string SubTotal = @"SubTotal";
			 public static string TaxAmt = @"TaxAmt";
			 public static string Freight = @"Freight";
			 public static string TotalDue = @"TotalDue";
			 public static string Comment = @"Comment";
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
