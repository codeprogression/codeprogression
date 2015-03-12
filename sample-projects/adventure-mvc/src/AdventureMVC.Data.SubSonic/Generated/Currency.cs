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
	/// Strongly-typed collection for the Currency class.
	/// </summary>
    [Serializable]
	public partial class CurrencyCollection : ActiveList<Currency, CurrencyCollection>
	{	   
		public CurrencyCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>CurrencyCollection</returns>
		public CurrencyCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Currency o = this[i];
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
	/// This is an ActiveRecord class which wraps the Currency table.
	/// </summary>
	[Serializable]
	public partial class Currency : ActiveRecord<Currency>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Currency()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Currency(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Currency(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Currency(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Currency", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Sales";
				//columns
				
				TableSchema.TableColumn colvarCurrencyCode = new TableSchema.TableColumn(schema);
				colvarCurrencyCode.ColumnName = "CurrencyCode";
				colvarCurrencyCode.DataType = DbType.String;
				colvarCurrencyCode.MaxLength = 3;
				colvarCurrencyCode.AutoIncrement = false;
				colvarCurrencyCode.IsNullable = false;
				colvarCurrencyCode.IsPrimaryKey = true;
				colvarCurrencyCode.IsForeignKey = false;
				colvarCurrencyCode.IsReadOnly = false;
				colvarCurrencyCode.DefaultSetting = @"";
				colvarCurrencyCode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCurrencyCode);
				
				TableSchema.TableColumn colvarName = new TableSchema.TableColumn(schema);
				colvarName.ColumnName = "Name";
				colvarName.DataType = DbType.String;
				colvarName.MaxLength = 50;
				colvarName.AutoIncrement = false;
				colvarName.IsNullable = false;
				colvarName.IsPrimaryKey = false;
				colvarName.IsForeignKey = false;
				colvarName.IsReadOnly = false;
				colvarName.DefaultSetting = @"";
				colvarName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarName);
				
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
				DataService.Providers["AdventureWorks"].AddSchema("Currency",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("CurrencyCode")]
		[Bindable(true)]
		public string CurrencyCode 
		{
			get { return GetColumnValue<string>(Columns.CurrencyCode); }
			set { SetColumnValue(Columns.CurrencyCode, value); }
		}
		  
		[XmlAttribute("Name")]
		[Bindable(true)]
		public string Name 
		{
			get { return GetColumnValue<string>(Columns.Name); }
			set { SetColumnValue(Columns.Name, value); }
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
        
		
		public AdventureWorks.CountryRegionCurrencyCollection CountryRegionCurrencyRecords()
		{
			return new AdventureWorks.CountryRegionCurrencyCollection().Where(CountryRegionCurrency.Columns.CurrencyCode, CurrencyCode).Load();
		}
		public AdventureWorks.CurrencyRateCollection CurrencyRateRecords()
		{
			return new AdventureWorks.CurrencyRateCollection().Where(CurrencyRate.Columns.FromCurrencyCode, CurrencyCode).Load();
		}
		public AdventureWorks.CurrencyRateCollection CurrencyRateRecordsFromCurrency()
		{
			return new AdventureWorks.CurrencyRateCollection().Where(CurrencyRate.Columns.ToCurrencyCode, CurrencyCode).Load();
		}
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		#region Many To Many Helpers
		
		 
		public AdventureWorks.CountryRegionCollection GetCountryRegionCollection() { return Currency.GetCountryRegionCollection(this.CurrencyCode); }
		public static AdventureWorks.CountryRegionCollection GetCountryRegionCollection(string varCurrencyCode)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [Person].[CountryRegion] INNER JOIN [CountryRegionCurrency] ON [CountryRegion].[CountryRegionCode] = [CountryRegionCurrency].[CountryRegionCode] WHERE [CountryRegionCurrency].[CurrencyCode] = @CurrencyCode", Currency.Schema.Provider.Name);
			cmd.AddParameter("@CurrencyCode", varCurrencyCode, DbType.String);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			CountryRegionCollection coll = new CountryRegionCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveCountryRegionMap(string varCurrencyCode, CountryRegionCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [CountryRegionCurrency] WHERE [CountryRegionCurrency].[CurrencyCode] = @CurrencyCode", Currency.Schema.Provider.Name);
			cmdDel.AddParameter("@CurrencyCode", varCurrencyCode, DbType.String);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (CountryRegion item in items)
			{
				CountryRegionCurrency varCountryRegionCurrency = new CountryRegionCurrency();
				varCountryRegionCurrency.SetColumnValue("CurrencyCode", varCurrencyCode);
				varCountryRegionCurrency.SetColumnValue("CountryRegionCode", item.GetPrimaryKeyValue());
				varCountryRegionCurrency.Save();
			}
		}
		public static void SaveCountryRegionMap(string varCurrencyCode, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [CountryRegionCurrency] WHERE [CountryRegionCurrency].[CurrencyCode] = @CurrencyCode", Currency.Schema.Provider.Name);
			cmdDel.AddParameter("@CurrencyCode", varCurrencyCode, DbType.String);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					CountryRegionCurrency varCountryRegionCurrency = new CountryRegionCurrency();
					varCountryRegionCurrency.SetColumnValue("CurrencyCode", varCurrencyCode);
					varCountryRegionCurrency.SetColumnValue("CountryRegionCode", l.Value);
					varCountryRegionCurrency.Save();
				}
			}
		}
		public static void SaveCountryRegionMap(string varCurrencyCode , string[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [CountryRegionCurrency] WHERE [CountryRegionCurrency].[CurrencyCode] = @CurrencyCode", Currency.Schema.Provider.Name);
			cmdDel.AddParameter("@CurrencyCode", varCurrencyCode, DbType.String);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (string item in itemList) 
			{
				CountryRegionCurrency varCountryRegionCurrency = new CountryRegionCurrency();
				varCountryRegionCurrency.SetColumnValue("CurrencyCode", varCurrencyCode);
				varCountryRegionCurrency.SetColumnValue("CountryRegionCode", item);
				varCountryRegionCurrency.Save();
			}
		}
		
		public static void DeleteCountryRegionMap(string varCurrencyCode) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [CountryRegionCurrency] WHERE [CountryRegionCurrency].[CurrencyCode] = @CurrencyCode", Currency.Schema.Provider.Name);
			cmdDel.AddParameter("@CurrencyCode", varCurrencyCode, DbType.String);
			DataService.ExecuteQuery(cmdDel);
		}
		
		#endregion
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varCurrencyCode,string varName,DateTime varModifiedDate)
		{
			Currency item = new Currency();
			
			item.CurrencyCode = varCurrencyCode;
			
			item.Name = varName;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(string varCurrencyCode,string varName,DateTime varModifiedDate)
		{
			Currency item = new Currency();
			
				item.CurrencyCode = varCurrencyCode;
			
				item.Name = varName;
			
				item.ModifiedDate = varModifiedDate;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn CurrencyCodeColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NameColumn
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
			 public static string CurrencyCode = @"CurrencyCode";
			 public static string Name = @"Name";
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
