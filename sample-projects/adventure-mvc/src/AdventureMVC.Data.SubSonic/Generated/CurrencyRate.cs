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
	/// Strongly-typed collection for the CurrencyRate class.
	/// </summary>
    [Serializable]
	public partial class CurrencyRateCollection : ActiveList<CurrencyRate, CurrencyRateCollection>
	{	   
		public CurrencyRateCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>CurrencyRateCollection</returns>
		public CurrencyRateCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                CurrencyRate o = this[i];
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
	/// This is an ActiveRecord class which wraps the CurrencyRate table.
	/// </summary>
	[Serializable]
	public partial class CurrencyRate : ActiveRecord<CurrencyRate>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public CurrencyRate()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public CurrencyRate(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public CurrencyRate(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public CurrencyRate(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CurrencyRate", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Sales";
				//columns
				
				TableSchema.TableColumn colvarCurrencyRateID = new TableSchema.TableColumn(schema);
				colvarCurrencyRateID.ColumnName = "CurrencyRateID";
				colvarCurrencyRateID.DataType = DbType.Int32;
				colvarCurrencyRateID.MaxLength = 0;
				colvarCurrencyRateID.AutoIncrement = true;
				colvarCurrencyRateID.IsNullable = false;
				colvarCurrencyRateID.IsPrimaryKey = true;
				colvarCurrencyRateID.IsForeignKey = false;
				colvarCurrencyRateID.IsReadOnly = false;
				colvarCurrencyRateID.DefaultSetting = @"";
				colvarCurrencyRateID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCurrencyRateID);
				
				TableSchema.TableColumn colvarCurrencyRateDate = new TableSchema.TableColumn(schema);
				colvarCurrencyRateDate.ColumnName = "CurrencyRateDate";
				colvarCurrencyRateDate.DataType = DbType.DateTime;
				colvarCurrencyRateDate.MaxLength = 0;
				colvarCurrencyRateDate.AutoIncrement = false;
				colvarCurrencyRateDate.IsNullable = false;
				colvarCurrencyRateDate.IsPrimaryKey = false;
				colvarCurrencyRateDate.IsForeignKey = false;
				colvarCurrencyRateDate.IsReadOnly = false;
				colvarCurrencyRateDate.DefaultSetting = @"";
				colvarCurrencyRateDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCurrencyRateDate);
				
				TableSchema.TableColumn colvarFromCurrencyCode = new TableSchema.TableColumn(schema);
				colvarFromCurrencyCode.ColumnName = "FromCurrencyCode";
				colvarFromCurrencyCode.DataType = DbType.String;
				colvarFromCurrencyCode.MaxLength = 3;
				colvarFromCurrencyCode.AutoIncrement = false;
				colvarFromCurrencyCode.IsNullable = false;
				colvarFromCurrencyCode.IsPrimaryKey = false;
				colvarFromCurrencyCode.IsForeignKey = true;
				colvarFromCurrencyCode.IsReadOnly = false;
				colvarFromCurrencyCode.DefaultSetting = @"";
				
					colvarFromCurrencyCode.ForeignKeyTableName = "Currency";
				schema.Columns.Add(colvarFromCurrencyCode);
				
				TableSchema.TableColumn colvarToCurrencyCode = new TableSchema.TableColumn(schema);
				colvarToCurrencyCode.ColumnName = "ToCurrencyCode";
				colvarToCurrencyCode.DataType = DbType.String;
				colvarToCurrencyCode.MaxLength = 3;
				colvarToCurrencyCode.AutoIncrement = false;
				colvarToCurrencyCode.IsNullable = false;
				colvarToCurrencyCode.IsPrimaryKey = false;
				colvarToCurrencyCode.IsForeignKey = true;
				colvarToCurrencyCode.IsReadOnly = false;
				colvarToCurrencyCode.DefaultSetting = @"";
				
					colvarToCurrencyCode.ForeignKeyTableName = "Currency";
				schema.Columns.Add(colvarToCurrencyCode);
				
				TableSchema.TableColumn colvarAverageRate = new TableSchema.TableColumn(schema);
				colvarAverageRate.ColumnName = "AverageRate";
				colvarAverageRate.DataType = DbType.Currency;
				colvarAverageRate.MaxLength = 0;
				colvarAverageRate.AutoIncrement = false;
				colvarAverageRate.IsNullable = false;
				colvarAverageRate.IsPrimaryKey = false;
				colvarAverageRate.IsForeignKey = false;
				colvarAverageRate.IsReadOnly = false;
				colvarAverageRate.DefaultSetting = @"";
				colvarAverageRate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAverageRate);
				
				TableSchema.TableColumn colvarEndOfDayRate = new TableSchema.TableColumn(schema);
				colvarEndOfDayRate.ColumnName = "EndOfDayRate";
				colvarEndOfDayRate.DataType = DbType.Currency;
				colvarEndOfDayRate.MaxLength = 0;
				colvarEndOfDayRate.AutoIncrement = false;
				colvarEndOfDayRate.IsNullable = false;
				colvarEndOfDayRate.IsPrimaryKey = false;
				colvarEndOfDayRate.IsForeignKey = false;
				colvarEndOfDayRate.IsReadOnly = false;
				colvarEndOfDayRate.DefaultSetting = @"";
				colvarEndOfDayRate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEndOfDayRate);
				
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
				DataService.Providers["AdventureWorks"].AddSchema("CurrencyRate",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("CurrencyRateID")]
		[Bindable(true)]
		public int CurrencyRateID 
		{
			get { return GetColumnValue<int>(Columns.CurrencyRateID); }
			set { SetColumnValue(Columns.CurrencyRateID, value); }
		}
		  
		[XmlAttribute("CurrencyRateDate")]
		[Bindable(true)]
		public DateTime CurrencyRateDate 
		{
			get { return GetColumnValue<DateTime>(Columns.CurrencyRateDate); }
			set { SetColumnValue(Columns.CurrencyRateDate, value); }
		}
		  
		[XmlAttribute("FromCurrencyCode")]
		[Bindable(true)]
		public string FromCurrencyCode 
		{
			get { return GetColumnValue<string>(Columns.FromCurrencyCode); }
			set { SetColumnValue(Columns.FromCurrencyCode, value); }
		}
		  
		[XmlAttribute("ToCurrencyCode")]
		[Bindable(true)]
		public string ToCurrencyCode 
		{
			get { return GetColumnValue<string>(Columns.ToCurrencyCode); }
			set { SetColumnValue(Columns.ToCurrencyCode, value); }
		}
		  
		[XmlAttribute("AverageRate")]
		[Bindable(true)]
		public decimal AverageRate 
		{
			get { return GetColumnValue<decimal>(Columns.AverageRate); }
			set { SetColumnValue(Columns.AverageRate, value); }
		}
		  
		[XmlAttribute("EndOfDayRate")]
		[Bindable(true)]
		public decimal EndOfDayRate 
		{
			get { return GetColumnValue<decimal>(Columns.EndOfDayRate); }
			set { SetColumnValue(Columns.EndOfDayRate, value); }
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
        
		
		public AdventureWorks.SalesOrderHeaderCollection SalesOrderHeaderRecords()
		{
			return new AdventureWorks.SalesOrderHeaderCollection().Where(SalesOrderHeader.Columns.CurrencyRateID, CurrencyRateID).Load();
		}
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Currency ActiveRecord object related to this CurrencyRate
		/// 
		/// </summary>
		public AdventureWorks.Currency Currency
		{
			get { return AdventureWorks.Currency.FetchByID(this.FromCurrencyCode); }
			set { SetColumnValue("FromCurrencyCode", value.CurrencyCode); }
		}
		
		
		/// <summary>
		/// Returns a Currency ActiveRecord object related to this CurrencyRate
		/// 
		/// </summary>
		public AdventureWorks.Currency CurrencyToToCurrencyCode
		{
			get { return AdventureWorks.Currency.FetchByID(this.ToCurrencyCode); }
			set { SetColumnValue("ToCurrencyCode", value.CurrencyCode); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(DateTime varCurrencyRateDate,string varFromCurrencyCode,string varToCurrencyCode,decimal varAverageRate,decimal varEndOfDayRate,DateTime varModifiedDate)
		{
			CurrencyRate item = new CurrencyRate();
			
			item.CurrencyRateDate = varCurrencyRateDate;
			
			item.FromCurrencyCode = varFromCurrencyCode;
			
			item.ToCurrencyCode = varToCurrencyCode;
			
			item.AverageRate = varAverageRate;
			
			item.EndOfDayRate = varEndOfDayRate;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varCurrencyRateID,DateTime varCurrencyRateDate,string varFromCurrencyCode,string varToCurrencyCode,decimal varAverageRate,decimal varEndOfDayRate,DateTime varModifiedDate)
		{
			CurrencyRate item = new CurrencyRate();
			
				item.CurrencyRateID = varCurrencyRateID;
			
				item.CurrencyRateDate = varCurrencyRateDate;
			
				item.FromCurrencyCode = varFromCurrencyCode;
			
				item.ToCurrencyCode = varToCurrencyCode;
			
				item.AverageRate = varAverageRate;
			
				item.EndOfDayRate = varEndOfDayRate;
			
				item.ModifiedDate = varModifiedDate;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn CurrencyRateIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn CurrencyRateDateColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn FromCurrencyCodeColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ToCurrencyCodeColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn AverageRateColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn EndOfDayRateColumn
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
			 public static string CurrencyRateID = @"CurrencyRateID";
			 public static string CurrencyRateDate = @"CurrencyRateDate";
			 public static string FromCurrencyCode = @"FromCurrencyCode";
			 public static string ToCurrencyCode = @"ToCurrencyCode";
			 public static string AverageRate = @"AverageRate";
			 public static string EndOfDayRate = @"EndOfDayRate";
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
