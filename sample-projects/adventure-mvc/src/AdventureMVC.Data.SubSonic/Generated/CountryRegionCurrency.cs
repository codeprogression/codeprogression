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
	/// Strongly-typed collection for the CountryRegionCurrency class.
	/// </summary>
    [Serializable]
	public partial class CountryRegionCurrencyCollection : ActiveList<CountryRegionCurrency, CountryRegionCurrencyCollection>
	{	   
		public CountryRegionCurrencyCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>CountryRegionCurrencyCollection</returns>
		public CountryRegionCurrencyCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                CountryRegionCurrency o = this[i];
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
	/// This is an ActiveRecord class which wraps the CountryRegionCurrency table.
	/// </summary>
	[Serializable]
	public partial class CountryRegionCurrency : ActiveRecord<CountryRegionCurrency>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public CountryRegionCurrency()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public CountryRegionCurrency(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public CountryRegionCurrency(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public CountryRegionCurrency(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CountryRegionCurrency", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Sales";
				//columns
				
				TableSchema.TableColumn colvarCountryRegionCode = new TableSchema.TableColumn(schema);
				colvarCountryRegionCode.ColumnName = "CountryRegionCode";
				colvarCountryRegionCode.DataType = DbType.String;
				colvarCountryRegionCode.MaxLength = 3;
				colvarCountryRegionCode.AutoIncrement = false;
				colvarCountryRegionCode.IsNullable = false;
				colvarCountryRegionCode.IsPrimaryKey = true;
				colvarCountryRegionCode.IsForeignKey = true;
				colvarCountryRegionCode.IsReadOnly = false;
				colvarCountryRegionCode.DefaultSetting = @"";
				
					colvarCountryRegionCode.ForeignKeyTableName = "CountryRegion";
				schema.Columns.Add(colvarCountryRegionCode);
				
				TableSchema.TableColumn colvarCurrencyCode = new TableSchema.TableColumn(schema);
				colvarCurrencyCode.ColumnName = "CurrencyCode";
				colvarCurrencyCode.DataType = DbType.String;
				colvarCurrencyCode.MaxLength = 3;
				colvarCurrencyCode.AutoIncrement = false;
				colvarCurrencyCode.IsNullable = false;
				colvarCurrencyCode.IsPrimaryKey = true;
				colvarCurrencyCode.IsForeignKey = true;
				colvarCurrencyCode.IsReadOnly = false;
				colvarCurrencyCode.DefaultSetting = @"";
				
					colvarCurrencyCode.ForeignKeyTableName = "Currency";
				schema.Columns.Add(colvarCurrencyCode);
				
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
				DataService.Providers["AdventureWorks"].AddSchema("CountryRegionCurrency",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("CountryRegionCode")]
		[Bindable(true)]
		public string CountryRegionCode 
		{
			get { return GetColumnValue<string>(Columns.CountryRegionCode); }
			set { SetColumnValue(Columns.CountryRegionCode, value); }
		}
		  
		[XmlAttribute("CurrencyCode")]
		[Bindable(true)]
		public string CurrencyCode 
		{
			get { return GetColumnValue<string>(Columns.CurrencyCode); }
			set { SetColumnValue(Columns.CurrencyCode, value); }
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
		/// Returns a CountryRegion ActiveRecord object related to this CountryRegionCurrency
		/// 
		/// </summary>
		public AdventureWorks.CountryRegion CountryRegion
		{
			get { return AdventureWorks.CountryRegion.FetchByID(this.CountryRegionCode); }
			set { SetColumnValue("CountryRegionCode", value.CountryRegionCode); }
		}
		
		
		/// <summary>
		/// Returns a Currency ActiveRecord object related to this CountryRegionCurrency
		/// 
		/// </summary>
		public AdventureWorks.Currency Currency
		{
			get { return AdventureWorks.Currency.FetchByID(this.CurrencyCode); }
			set { SetColumnValue("CurrencyCode", value.CurrencyCode); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varCountryRegionCode,string varCurrencyCode,DateTime varModifiedDate)
		{
			CountryRegionCurrency item = new CountryRegionCurrency();
			
			item.CountryRegionCode = varCountryRegionCode;
			
			item.CurrencyCode = varCurrencyCode;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(string varCountryRegionCode,string varCurrencyCode,DateTime varModifiedDate)
		{
			CountryRegionCurrency item = new CountryRegionCurrency();
			
				item.CountryRegionCode = varCountryRegionCode;
			
				item.CurrencyCode = varCurrencyCode;
			
				item.ModifiedDate = varModifiedDate;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn CountryRegionCodeColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn CurrencyCodeColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedDateColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string CountryRegionCode = @"CountryRegionCode";
			 public static string CurrencyCode = @"CurrencyCode";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
