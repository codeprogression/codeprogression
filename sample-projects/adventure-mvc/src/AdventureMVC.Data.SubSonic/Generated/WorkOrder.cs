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
	/// Strongly-typed collection for the WorkOrder class.
	/// </summary>
    [Serializable]
	public partial class WorkOrderCollection : ActiveList<WorkOrder, WorkOrderCollection>
	{	   
		public WorkOrderCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>WorkOrderCollection</returns>
		public WorkOrderCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                WorkOrder o = this[i];
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
	/// This is an ActiveRecord class which wraps the WorkOrder table.
	/// </summary>
	[Serializable]
	public partial class WorkOrder : ActiveRecord<WorkOrder>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public WorkOrder()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public WorkOrder(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public WorkOrder(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public WorkOrder(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("WorkOrder", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Production";
				//columns
				
				TableSchema.TableColumn colvarWorkOrderID = new TableSchema.TableColumn(schema);
				colvarWorkOrderID.ColumnName = "WorkOrderID";
				colvarWorkOrderID.DataType = DbType.Int32;
				colvarWorkOrderID.MaxLength = 0;
				colvarWorkOrderID.AutoIncrement = true;
				colvarWorkOrderID.IsNullable = false;
				colvarWorkOrderID.IsPrimaryKey = true;
				colvarWorkOrderID.IsForeignKey = false;
				colvarWorkOrderID.IsReadOnly = false;
				colvarWorkOrderID.DefaultSetting = @"";
				colvarWorkOrderID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarWorkOrderID);
				
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
				
				TableSchema.TableColumn colvarOrderQty = new TableSchema.TableColumn(schema);
				colvarOrderQty.ColumnName = "OrderQty";
				colvarOrderQty.DataType = DbType.Int32;
				colvarOrderQty.MaxLength = 0;
				colvarOrderQty.AutoIncrement = false;
				colvarOrderQty.IsNullable = false;
				colvarOrderQty.IsPrimaryKey = false;
				colvarOrderQty.IsForeignKey = false;
				colvarOrderQty.IsReadOnly = false;
				colvarOrderQty.DefaultSetting = @"";
				colvarOrderQty.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOrderQty);
				
				TableSchema.TableColumn colvarStockedQty = new TableSchema.TableColumn(schema);
				colvarStockedQty.ColumnName = "StockedQty";
				colvarStockedQty.DataType = DbType.Int32;
				colvarStockedQty.MaxLength = 0;
				colvarStockedQty.AutoIncrement = false;
				colvarStockedQty.IsNullable = false;
				colvarStockedQty.IsPrimaryKey = false;
				colvarStockedQty.IsForeignKey = false;
				colvarStockedQty.IsReadOnly = true;
				colvarStockedQty.DefaultSetting = @"";
				colvarStockedQty.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStockedQty);
				
				TableSchema.TableColumn colvarScrappedQty = new TableSchema.TableColumn(schema);
				colvarScrappedQty.ColumnName = "ScrappedQty";
				colvarScrappedQty.DataType = DbType.Int16;
				colvarScrappedQty.MaxLength = 0;
				colvarScrappedQty.AutoIncrement = false;
				colvarScrappedQty.IsNullable = false;
				colvarScrappedQty.IsPrimaryKey = false;
				colvarScrappedQty.IsForeignKey = false;
				colvarScrappedQty.IsReadOnly = false;
				colvarScrappedQty.DefaultSetting = @"";
				colvarScrappedQty.ForeignKeyTableName = "";
				schema.Columns.Add(colvarScrappedQty);
				
				TableSchema.TableColumn colvarStartDate = new TableSchema.TableColumn(schema);
				colvarStartDate.ColumnName = "StartDate";
				colvarStartDate.DataType = DbType.DateTime;
				colvarStartDate.MaxLength = 0;
				colvarStartDate.AutoIncrement = false;
				colvarStartDate.IsNullable = false;
				colvarStartDate.IsPrimaryKey = false;
				colvarStartDate.IsForeignKey = false;
				colvarStartDate.IsReadOnly = false;
				colvarStartDate.DefaultSetting = @"";
				colvarStartDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStartDate);
				
				TableSchema.TableColumn colvarEndDate = new TableSchema.TableColumn(schema);
				colvarEndDate.ColumnName = "EndDate";
				colvarEndDate.DataType = DbType.DateTime;
				colvarEndDate.MaxLength = 0;
				colvarEndDate.AutoIncrement = false;
				colvarEndDate.IsNullable = true;
				colvarEndDate.IsPrimaryKey = false;
				colvarEndDate.IsForeignKey = false;
				colvarEndDate.IsReadOnly = false;
				colvarEndDate.DefaultSetting = @"";
				colvarEndDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEndDate);
				
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
				
				TableSchema.TableColumn colvarScrapReasonID = new TableSchema.TableColumn(schema);
				colvarScrapReasonID.ColumnName = "ScrapReasonID";
				colvarScrapReasonID.DataType = DbType.Int16;
				colvarScrapReasonID.MaxLength = 0;
				colvarScrapReasonID.AutoIncrement = false;
				colvarScrapReasonID.IsNullable = true;
				colvarScrapReasonID.IsPrimaryKey = false;
				colvarScrapReasonID.IsForeignKey = true;
				colvarScrapReasonID.IsReadOnly = false;
				colvarScrapReasonID.DefaultSetting = @"";
				
					colvarScrapReasonID.ForeignKeyTableName = "ScrapReason";
				schema.Columns.Add(colvarScrapReasonID);
				
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
				DataService.Providers["AdventureWorks"].AddSchema("WorkOrder",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("WorkOrderID")]
		[Bindable(true)]
		public int WorkOrderID 
		{
			get { return GetColumnValue<int>(Columns.WorkOrderID); }
			set { SetColumnValue(Columns.WorkOrderID, value); }
		}
		  
		[XmlAttribute("ProductID")]
		[Bindable(true)]
		public int ProductID 
		{
			get { return GetColumnValue<int>(Columns.ProductID); }
			set { SetColumnValue(Columns.ProductID, value); }
		}
		  
		[XmlAttribute("OrderQty")]
		[Bindable(true)]
		public int OrderQty 
		{
			get { return GetColumnValue<int>(Columns.OrderQty); }
			set { SetColumnValue(Columns.OrderQty, value); }
		}
		  
		[XmlAttribute("StockedQty")]
		[Bindable(true)]
		public int StockedQty 
		{
			get { return GetColumnValue<int>(Columns.StockedQty); }
			set { SetColumnValue(Columns.StockedQty, value); }
		}
		  
		[XmlAttribute("ScrappedQty")]
		[Bindable(true)]
		public short ScrappedQty 
		{
			get { return GetColumnValue<short>(Columns.ScrappedQty); }
			set { SetColumnValue(Columns.ScrappedQty, value); }
		}
		  
		[XmlAttribute("StartDate")]
		[Bindable(true)]
		public DateTime StartDate 
		{
			get { return GetColumnValue<DateTime>(Columns.StartDate); }
			set { SetColumnValue(Columns.StartDate, value); }
		}
		  
		[XmlAttribute("EndDate")]
		[Bindable(true)]
		public DateTime? EndDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.EndDate); }
			set { SetColumnValue(Columns.EndDate, value); }
		}
		  
		[XmlAttribute("DueDate")]
		[Bindable(true)]
		public DateTime DueDate 
		{
			get { return GetColumnValue<DateTime>(Columns.DueDate); }
			set { SetColumnValue(Columns.DueDate, value); }
		}
		  
		[XmlAttribute("ScrapReasonID")]
		[Bindable(true)]
		public short? ScrapReasonID 
		{
			get { return GetColumnValue<short?>(Columns.ScrapReasonID); }
			set { SetColumnValue(Columns.ScrapReasonID, value); }
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
        
		
		public AdventureWorks.WorkOrderRoutingCollection WorkOrderRoutingRecords()
		{
			return new AdventureWorks.WorkOrderRoutingCollection().Where(WorkOrderRouting.Columns.WorkOrderID, WorkOrderID).Load();
		}
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Product ActiveRecord object related to this WorkOrder
		/// 
		/// </summary>
		public AdventureWorks.Product Product
		{
			get { return AdventureWorks.Product.FetchByID(this.ProductID); }
			set { SetColumnValue("ProductID", value.ProductID); }
		}
		
		
		/// <summary>
		/// Returns a ScrapReason ActiveRecord object related to this WorkOrder
		/// 
		/// </summary>
		public AdventureWorks.ScrapReason ScrapReason
		{
			get { return AdventureWorks.ScrapReason.FetchByID(this.ScrapReasonID); }
			set { SetColumnValue("ScrapReasonID", value.ScrapReasonID); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varProductID,int varOrderQty,int varStockedQty,short varScrappedQty,DateTime varStartDate,DateTime? varEndDate,DateTime varDueDate,short? varScrapReasonID,DateTime varModifiedDate)
		{
			WorkOrder item = new WorkOrder();
			
			item.ProductID = varProductID;
			
			item.OrderQty = varOrderQty;
			
			item.StockedQty = varStockedQty;
			
			item.ScrappedQty = varScrappedQty;
			
			item.StartDate = varStartDate;
			
			item.EndDate = varEndDate;
			
			item.DueDate = varDueDate;
			
			item.ScrapReasonID = varScrapReasonID;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varWorkOrderID,int varProductID,int varOrderQty,int varStockedQty,short varScrappedQty,DateTime varStartDate,DateTime? varEndDate,DateTime varDueDate,short? varScrapReasonID,DateTime varModifiedDate)
		{
			WorkOrder item = new WorkOrder();
			
				item.WorkOrderID = varWorkOrderID;
			
				item.ProductID = varProductID;
			
				item.OrderQty = varOrderQty;
			
				item.StockedQty = varStockedQty;
			
				item.ScrappedQty = varScrappedQty;
			
				item.StartDate = varStartDate;
			
				item.EndDate = varEndDate;
			
				item.DueDate = varDueDate;
			
				item.ScrapReasonID = varScrapReasonID;
			
				item.ModifiedDate = varModifiedDate;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn WorkOrderIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ProductIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn OrderQtyColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn StockedQtyColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ScrappedQtyColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn StartDateColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn EndDateColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn DueDateColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn ScrapReasonIDColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedDateColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string WorkOrderID = @"WorkOrderID";
			 public static string ProductID = @"ProductID";
			 public static string OrderQty = @"OrderQty";
			 public static string StockedQty = @"StockedQty";
			 public static string ScrappedQty = @"ScrappedQty";
			 public static string StartDate = @"StartDate";
			 public static string EndDate = @"EndDate";
			 public static string DueDate = @"DueDate";
			 public static string ScrapReasonID = @"ScrapReasonID";
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
