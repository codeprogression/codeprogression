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
	/// Strongly-typed collection for the TransactionHistory class.
	/// </summary>
    [Serializable]
	public partial class TransactionHistoryCollection : ActiveList<TransactionHistory, TransactionHistoryCollection>
	{	   
		public TransactionHistoryCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TransactionHistoryCollection</returns>
		public TransactionHistoryCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TransactionHistory o = this[i];
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
	/// This is an ActiveRecord class which wraps the TransactionHistory table.
	/// </summary>
	[Serializable]
	public partial class TransactionHistory : ActiveRecord<TransactionHistory>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TransactionHistory()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TransactionHistory(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TransactionHistory(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TransactionHistory(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("TransactionHistory", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Production";
				//columns
				
				TableSchema.TableColumn colvarTransactionID = new TableSchema.TableColumn(schema);
				colvarTransactionID.ColumnName = "TransactionID";
				colvarTransactionID.DataType = DbType.Int32;
				colvarTransactionID.MaxLength = 0;
				colvarTransactionID.AutoIncrement = true;
				colvarTransactionID.IsNullable = false;
				colvarTransactionID.IsPrimaryKey = true;
				colvarTransactionID.IsForeignKey = false;
				colvarTransactionID.IsReadOnly = false;
				colvarTransactionID.DefaultSetting = @"";
				colvarTransactionID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTransactionID);
				
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
				
				TableSchema.TableColumn colvarReferenceOrderID = new TableSchema.TableColumn(schema);
				colvarReferenceOrderID.ColumnName = "ReferenceOrderID";
				colvarReferenceOrderID.DataType = DbType.Int32;
				colvarReferenceOrderID.MaxLength = 0;
				colvarReferenceOrderID.AutoIncrement = false;
				colvarReferenceOrderID.IsNullable = false;
				colvarReferenceOrderID.IsPrimaryKey = false;
				colvarReferenceOrderID.IsForeignKey = false;
				colvarReferenceOrderID.IsReadOnly = false;
				colvarReferenceOrderID.DefaultSetting = @"";
				colvarReferenceOrderID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarReferenceOrderID);
				
				TableSchema.TableColumn colvarReferenceOrderLineID = new TableSchema.TableColumn(schema);
				colvarReferenceOrderLineID.ColumnName = "ReferenceOrderLineID";
				colvarReferenceOrderLineID.DataType = DbType.Int32;
				colvarReferenceOrderLineID.MaxLength = 0;
				colvarReferenceOrderLineID.AutoIncrement = false;
				colvarReferenceOrderLineID.IsNullable = false;
				colvarReferenceOrderLineID.IsPrimaryKey = false;
				colvarReferenceOrderLineID.IsForeignKey = false;
				colvarReferenceOrderLineID.IsReadOnly = false;
				
						colvarReferenceOrderLineID.DefaultSetting = @"((0))";
				colvarReferenceOrderLineID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarReferenceOrderLineID);
				
				TableSchema.TableColumn colvarTransactionDate = new TableSchema.TableColumn(schema);
				colvarTransactionDate.ColumnName = "TransactionDate";
				colvarTransactionDate.DataType = DbType.DateTime;
				colvarTransactionDate.MaxLength = 0;
				colvarTransactionDate.AutoIncrement = false;
				colvarTransactionDate.IsNullable = false;
				colvarTransactionDate.IsPrimaryKey = false;
				colvarTransactionDate.IsForeignKey = false;
				colvarTransactionDate.IsReadOnly = false;
				
						colvarTransactionDate.DefaultSetting = @"(getdate())";
				colvarTransactionDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTransactionDate);
				
				TableSchema.TableColumn colvarTransactionType = new TableSchema.TableColumn(schema);
				colvarTransactionType.ColumnName = "TransactionType";
				colvarTransactionType.DataType = DbType.String;
				colvarTransactionType.MaxLength = 1;
				colvarTransactionType.AutoIncrement = false;
				colvarTransactionType.IsNullable = false;
				colvarTransactionType.IsPrimaryKey = false;
				colvarTransactionType.IsForeignKey = false;
				colvarTransactionType.IsReadOnly = false;
				colvarTransactionType.DefaultSetting = @"";
				colvarTransactionType.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTransactionType);
				
				TableSchema.TableColumn colvarQuantity = new TableSchema.TableColumn(schema);
				colvarQuantity.ColumnName = "Quantity";
				colvarQuantity.DataType = DbType.Int32;
				colvarQuantity.MaxLength = 0;
				colvarQuantity.AutoIncrement = false;
				colvarQuantity.IsNullable = false;
				colvarQuantity.IsPrimaryKey = false;
				colvarQuantity.IsForeignKey = false;
				colvarQuantity.IsReadOnly = false;
				colvarQuantity.DefaultSetting = @"";
				colvarQuantity.ForeignKeyTableName = "";
				schema.Columns.Add(colvarQuantity);
				
				TableSchema.TableColumn colvarActualCost = new TableSchema.TableColumn(schema);
				colvarActualCost.ColumnName = "ActualCost";
				colvarActualCost.DataType = DbType.Currency;
				colvarActualCost.MaxLength = 0;
				colvarActualCost.AutoIncrement = false;
				colvarActualCost.IsNullable = false;
				colvarActualCost.IsPrimaryKey = false;
				colvarActualCost.IsForeignKey = false;
				colvarActualCost.IsReadOnly = false;
				colvarActualCost.DefaultSetting = @"";
				colvarActualCost.ForeignKeyTableName = "";
				schema.Columns.Add(colvarActualCost);
				
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
				DataService.Providers["AdventureWorks"].AddSchema("TransactionHistory",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("TransactionID")]
		[Bindable(true)]
		public int TransactionID 
		{
			get { return GetColumnValue<int>(Columns.TransactionID); }
			set { SetColumnValue(Columns.TransactionID, value); }
		}
		  
		[XmlAttribute("ProductID")]
		[Bindable(true)]
		public int ProductID 
		{
			get { return GetColumnValue<int>(Columns.ProductID); }
			set { SetColumnValue(Columns.ProductID, value); }
		}
		  
		[XmlAttribute("ReferenceOrderID")]
		[Bindable(true)]
		public int ReferenceOrderID 
		{
			get { return GetColumnValue<int>(Columns.ReferenceOrderID); }
			set { SetColumnValue(Columns.ReferenceOrderID, value); }
		}
		  
		[XmlAttribute("ReferenceOrderLineID")]
		[Bindable(true)]
		public int ReferenceOrderLineID 
		{
			get { return GetColumnValue<int>(Columns.ReferenceOrderLineID); }
			set { SetColumnValue(Columns.ReferenceOrderLineID, value); }
		}
		  
		[XmlAttribute("TransactionDate")]
		[Bindable(true)]
		public DateTime TransactionDate 
		{
			get { return GetColumnValue<DateTime>(Columns.TransactionDate); }
			set { SetColumnValue(Columns.TransactionDate, value); }
		}
		  
		[XmlAttribute("TransactionType")]
		[Bindable(true)]
		public string TransactionType 
		{
			get { return GetColumnValue<string>(Columns.TransactionType); }
			set { SetColumnValue(Columns.TransactionType, value); }
		}
		  
		[XmlAttribute("Quantity")]
		[Bindable(true)]
		public int Quantity 
		{
			get { return GetColumnValue<int>(Columns.Quantity); }
			set { SetColumnValue(Columns.Quantity, value); }
		}
		  
		[XmlAttribute("ActualCost")]
		[Bindable(true)]
		public decimal ActualCost 
		{
			get { return GetColumnValue<decimal>(Columns.ActualCost); }
			set { SetColumnValue(Columns.ActualCost, value); }
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
		/// Returns a Product ActiveRecord object related to this TransactionHistory
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
		public static void Insert(int varProductID,int varReferenceOrderID,int varReferenceOrderLineID,DateTime varTransactionDate,string varTransactionType,int varQuantity,decimal varActualCost,DateTime varModifiedDate)
		{
			TransactionHistory item = new TransactionHistory();
			
			item.ProductID = varProductID;
			
			item.ReferenceOrderID = varReferenceOrderID;
			
			item.ReferenceOrderLineID = varReferenceOrderLineID;
			
			item.TransactionDate = varTransactionDate;
			
			item.TransactionType = varTransactionType;
			
			item.Quantity = varQuantity;
			
			item.ActualCost = varActualCost;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varTransactionID,int varProductID,int varReferenceOrderID,int varReferenceOrderLineID,DateTime varTransactionDate,string varTransactionType,int varQuantity,decimal varActualCost,DateTime varModifiedDate)
		{
			TransactionHistory item = new TransactionHistory();
			
				item.TransactionID = varTransactionID;
			
				item.ProductID = varProductID;
			
				item.ReferenceOrderID = varReferenceOrderID;
			
				item.ReferenceOrderLineID = varReferenceOrderLineID;
			
				item.TransactionDate = varTransactionDate;
			
				item.TransactionType = varTransactionType;
			
				item.Quantity = varQuantity;
			
				item.ActualCost = varActualCost;
			
				item.ModifiedDate = varModifiedDate;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn TransactionIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ProductIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ReferenceOrderIDColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ReferenceOrderLineIDColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn TransactionDateColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn TransactionTypeColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn QuantityColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn ActualCostColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedDateColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string TransactionID = @"TransactionID";
			 public static string ProductID = @"ProductID";
			 public static string ReferenceOrderID = @"ReferenceOrderID";
			 public static string ReferenceOrderLineID = @"ReferenceOrderLineID";
			 public static string TransactionDate = @"TransactionDate";
			 public static string TransactionType = @"TransactionType";
			 public static string Quantity = @"Quantity";
			 public static string ActualCost = @"ActualCost";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
