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
	/// Strongly-typed collection for the SpecialOffer class.
	/// </summary>
    [Serializable]
	public partial class SpecialOfferCollection : ActiveList<SpecialOffer, SpecialOfferCollection>
	{	   
		public SpecialOfferCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SpecialOfferCollection</returns>
		public SpecialOfferCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SpecialOffer o = this[i];
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
	/// This is an ActiveRecord class which wraps the SpecialOffer table.
	/// </summary>
	[Serializable]
	public partial class SpecialOffer : ActiveRecord<SpecialOffer>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SpecialOffer()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SpecialOffer(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SpecialOffer(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SpecialOffer(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("SpecialOffer", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Sales";
				//columns
				
				TableSchema.TableColumn colvarSpecialOfferID = new TableSchema.TableColumn(schema);
				colvarSpecialOfferID.ColumnName = "SpecialOfferID";
				colvarSpecialOfferID.DataType = DbType.Int32;
				colvarSpecialOfferID.MaxLength = 0;
				colvarSpecialOfferID.AutoIncrement = true;
				colvarSpecialOfferID.IsNullable = false;
				colvarSpecialOfferID.IsPrimaryKey = true;
				colvarSpecialOfferID.IsForeignKey = false;
				colvarSpecialOfferID.IsReadOnly = false;
				colvarSpecialOfferID.DefaultSetting = @"";
				colvarSpecialOfferID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSpecialOfferID);
				
				TableSchema.TableColumn colvarDescription = new TableSchema.TableColumn(schema);
				colvarDescription.ColumnName = "Description";
				colvarDescription.DataType = DbType.String;
				colvarDescription.MaxLength = 255;
				colvarDescription.AutoIncrement = false;
				colvarDescription.IsNullable = false;
				colvarDescription.IsPrimaryKey = false;
				colvarDescription.IsForeignKey = false;
				colvarDescription.IsReadOnly = false;
				colvarDescription.DefaultSetting = @"";
				colvarDescription.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescription);
				
				TableSchema.TableColumn colvarDiscountPct = new TableSchema.TableColumn(schema);
				colvarDiscountPct.ColumnName = "DiscountPct";
				colvarDiscountPct.DataType = DbType.Currency;
				colvarDiscountPct.MaxLength = 0;
				colvarDiscountPct.AutoIncrement = false;
				colvarDiscountPct.IsNullable = false;
				colvarDiscountPct.IsPrimaryKey = false;
				colvarDiscountPct.IsForeignKey = false;
				colvarDiscountPct.IsReadOnly = false;
				
						colvarDiscountPct.DefaultSetting = @"((0.00))";
				colvarDiscountPct.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiscountPct);
				
				TableSchema.TableColumn colvarType = new TableSchema.TableColumn(schema);
				colvarType.ColumnName = "Type";
				colvarType.DataType = DbType.String;
				colvarType.MaxLength = 50;
				colvarType.AutoIncrement = false;
				colvarType.IsNullable = false;
				colvarType.IsPrimaryKey = false;
				colvarType.IsForeignKey = false;
				colvarType.IsReadOnly = false;
				colvarType.DefaultSetting = @"";
				colvarType.ForeignKeyTableName = "";
				schema.Columns.Add(colvarType);
				
				TableSchema.TableColumn colvarCategory = new TableSchema.TableColumn(schema);
				colvarCategory.ColumnName = "Category";
				colvarCategory.DataType = DbType.String;
				colvarCategory.MaxLength = 50;
				colvarCategory.AutoIncrement = false;
				colvarCategory.IsNullable = false;
				colvarCategory.IsPrimaryKey = false;
				colvarCategory.IsForeignKey = false;
				colvarCategory.IsReadOnly = false;
				colvarCategory.DefaultSetting = @"";
				colvarCategory.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCategory);
				
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
				colvarEndDate.IsNullable = false;
				colvarEndDate.IsPrimaryKey = false;
				colvarEndDate.IsForeignKey = false;
				colvarEndDate.IsReadOnly = false;
				colvarEndDate.DefaultSetting = @"";
				colvarEndDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEndDate);
				
				TableSchema.TableColumn colvarMinQty = new TableSchema.TableColumn(schema);
				colvarMinQty.ColumnName = "MinQty";
				colvarMinQty.DataType = DbType.Int32;
				colvarMinQty.MaxLength = 0;
				colvarMinQty.AutoIncrement = false;
				colvarMinQty.IsNullable = false;
				colvarMinQty.IsPrimaryKey = false;
				colvarMinQty.IsForeignKey = false;
				colvarMinQty.IsReadOnly = false;
				
						colvarMinQty.DefaultSetting = @"((0))";
				colvarMinQty.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMinQty);
				
				TableSchema.TableColumn colvarMaxQty = new TableSchema.TableColumn(schema);
				colvarMaxQty.ColumnName = "MaxQty";
				colvarMaxQty.DataType = DbType.Int32;
				colvarMaxQty.MaxLength = 0;
				colvarMaxQty.AutoIncrement = false;
				colvarMaxQty.IsNullable = true;
				colvarMaxQty.IsPrimaryKey = false;
				colvarMaxQty.IsForeignKey = false;
				colvarMaxQty.IsReadOnly = false;
				colvarMaxQty.DefaultSetting = @"";
				colvarMaxQty.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMaxQty);
				
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
				DataService.Providers["AdventureWorks"].AddSchema("SpecialOffer",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("SpecialOfferID")]
		[Bindable(true)]
		public int SpecialOfferID 
		{
			get { return GetColumnValue<int>(Columns.SpecialOfferID); }
			set { SetColumnValue(Columns.SpecialOfferID, value); }
		}
		  
		[XmlAttribute("Description")]
		[Bindable(true)]
		public string Description 
		{
			get { return GetColumnValue<string>(Columns.Description); }
			set { SetColumnValue(Columns.Description, value); }
		}
		  
		[XmlAttribute("DiscountPct")]
		[Bindable(true)]
		public decimal DiscountPct 
		{
			get { return GetColumnValue<decimal>(Columns.DiscountPct); }
			set { SetColumnValue(Columns.DiscountPct, value); }
		}
		  
		[XmlAttribute("Type")]
		[Bindable(true)]
		public string Type 
		{
			get { return GetColumnValue<string>(Columns.Type); }
			set { SetColumnValue(Columns.Type, value); }
		}
		  
		[XmlAttribute("Category")]
		[Bindable(true)]
		public string Category 
		{
			get { return GetColumnValue<string>(Columns.Category); }
			set { SetColumnValue(Columns.Category, value); }
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
		public DateTime EndDate 
		{
			get { return GetColumnValue<DateTime>(Columns.EndDate); }
			set { SetColumnValue(Columns.EndDate, value); }
		}
		  
		[XmlAttribute("MinQty")]
		[Bindable(true)]
		public int MinQty 
		{
			get { return GetColumnValue<int>(Columns.MinQty); }
			set { SetColumnValue(Columns.MinQty, value); }
		}
		  
		[XmlAttribute("MaxQty")]
		[Bindable(true)]
		public int? MaxQty 
		{
			get { return GetColumnValue<int?>(Columns.MaxQty); }
			set { SetColumnValue(Columns.MaxQty, value); }
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
        
		
		public AdventureWorks.SpecialOfferProductCollection SpecialOfferProductRecords()
		{
			return new AdventureWorks.SpecialOfferProductCollection().Where(SpecialOfferProduct.Columns.SpecialOfferID, SpecialOfferID).Load();
		}
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		#region Many To Many Helpers
		
		 
		public AdventureWorks.ProductCollection GetProductCollection() { return SpecialOffer.GetProductCollection(this.SpecialOfferID); }
		public static AdventureWorks.ProductCollection GetProductCollection(int varSpecialOfferID)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [Production].[Product] INNER JOIN [SpecialOfferProduct] ON [Product].[ProductID] = [SpecialOfferProduct].[ProductID] WHERE [SpecialOfferProduct].[SpecialOfferID] = @SpecialOfferID", SpecialOffer.Schema.Provider.Name);
			cmd.AddParameter("@SpecialOfferID", varSpecialOfferID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			ProductCollection coll = new ProductCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveProductMap(int varSpecialOfferID, ProductCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [SpecialOfferProduct] WHERE [SpecialOfferProduct].[SpecialOfferID] = @SpecialOfferID", SpecialOffer.Schema.Provider.Name);
			cmdDel.AddParameter("@SpecialOfferID", varSpecialOfferID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Product item in items)
			{
				SpecialOfferProduct varSpecialOfferProduct = new SpecialOfferProduct();
				varSpecialOfferProduct.SetColumnValue("SpecialOfferID", varSpecialOfferID);
				varSpecialOfferProduct.SetColumnValue("ProductID", item.GetPrimaryKeyValue());
				varSpecialOfferProduct.Save();
			}
		}
		public static void SaveProductMap(int varSpecialOfferID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [SpecialOfferProduct] WHERE [SpecialOfferProduct].[SpecialOfferID] = @SpecialOfferID", SpecialOffer.Schema.Provider.Name);
			cmdDel.AddParameter("@SpecialOfferID", varSpecialOfferID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					SpecialOfferProduct varSpecialOfferProduct = new SpecialOfferProduct();
					varSpecialOfferProduct.SetColumnValue("SpecialOfferID", varSpecialOfferID);
					varSpecialOfferProduct.SetColumnValue("ProductID", l.Value);
					varSpecialOfferProduct.Save();
				}
			}
		}
		public static void SaveProductMap(int varSpecialOfferID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [SpecialOfferProduct] WHERE [SpecialOfferProduct].[SpecialOfferID] = @SpecialOfferID", SpecialOffer.Schema.Provider.Name);
			cmdDel.AddParameter("@SpecialOfferID", varSpecialOfferID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				SpecialOfferProduct varSpecialOfferProduct = new SpecialOfferProduct();
				varSpecialOfferProduct.SetColumnValue("SpecialOfferID", varSpecialOfferID);
				varSpecialOfferProduct.SetColumnValue("ProductID", item);
				varSpecialOfferProduct.Save();
			}
		}
		
		public static void DeleteProductMap(int varSpecialOfferID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [SpecialOfferProduct] WHERE [SpecialOfferProduct].[SpecialOfferID] = @SpecialOfferID", SpecialOffer.Schema.Provider.Name);
			cmdDel.AddParameter("@SpecialOfferID", varSpecialOfferID, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		#endregion
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varDescription,decimal varDiscountPct,string varType,string varCategory,DateTime varStartDate,DateTime varEndDate,int varMinQty,int? varMaxQty,Guid varRowguid,DateTime varModifiedDate)
		{
			SpecialOffer item = new SpecialOffer();
			
			item.Description = varDescription;
			
			item.DiscountPct = varDiscountPct;
			
			item.Type = varType;
			
			item.Category = varCategory;
			
			item.StartDate = varStartDate;
			
			item.EndDate = varEndDate;
			
			item.MinQty = varMinQty;
			
			item.MaxQty = varMaxQty;
			
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
		public static void Update(int varSpecialOfferID,string varDescription,decimal varDiscountPct,string varType,string varCategory,DateTime varStartDate,DateTime varEndDate,int varMinQty,int? varMaxQty,Guid varRowguid,DateTime varModifiedDate)
		{
			SpecialOffer item = new SpecialOffer();
			
				item.SpecialOfferID = varSpecialOfferID;
			
				item.Description = varDescription;
			
				item.DiscountPct = varDiscountPct;
			
				item.Type = varType;
			
				item.Category = varCategory;
			
				item.StartDate = varStartDate;
			
				item.EndDate = varEndDate;
			
				item.MinQty = varMinQty;
			
				item.MaxQty = varMaxQty;
			
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
        
        
        public static TableSchema.TableColumn SpecialOfferIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn DescriptionColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DiscountPctColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn TypeColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn CategoryColumn
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
        
        
        
        public static TableSchema.TableColumn MinQtyColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn MaxQtyColumn
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
			 public static string SpecialOfferID = @"SpecialOfferID";
			 public static string Description = @"Description";
			 public static string DiscountPct = @"DiscountPct";
			 public static string Type = @"Type";
			 public static string Category = @"Category";
			 public static string StartDate = @"StartDate";
			 public static string EndDate = @"EndDate";
			 public static string MinQty = @"MinQty";
			 public static string MaxQty = @"MaxQty";
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
