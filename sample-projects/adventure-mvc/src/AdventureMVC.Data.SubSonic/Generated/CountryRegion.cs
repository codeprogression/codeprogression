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
	/// Strongly-typed collection for the CountryRegion class.
	/// </summary>
    [Serializable]
	public partial class CountryRegionCollection : ActiveList<CountryRegion, CountryRegionCollection>
	{	   
		public CountryRegionCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>CountryRegionCollection</returns>
		public CountryRegionCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                CountryRegion o = this[i];
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
	/// This is an ActiveRecord class which wraps the CountryRegion table.
	/// </summary>
	[Serializable]
	public partial class CountryRegion : ActiveRecord<CountryRegion>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public CountryRegion()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public CountryRegion(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public CountryRegion(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public CountryRegion(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CountryRegion", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Person";
				//columns
				
				TableSchema.TableColumn colvarCountryRegionCode = new TableSchema.TableColumn(schema);
				colvarCountryRegionCode.ColumnName = "CountryRegionCode";
				colvarCountryRegionCode.DataType = DbType.String;
				colvarCountryRegionCode.MaxLength = 3;
				colvarCountryRegionCode.AutoIncrement = false;
				colvarCountryRegionCode.IsNullable = false;
				colvarCountryRegionCode.IsPrimaryKey = true;
				colvarCountryRegionCode.IsForeignKey = false;
				colvarCountryRegionCode.IsReadOnly = false;
				colvarCountryRegionCode.DefaultSetting = @"";
				colvarCountryRegionCode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCountryRegionCode);
				
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
				DataService.Providers["AdventureWorks"].AddSchema("CountryRegion",schema);
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
        
		
		public AdventureWorks.StateProvinceCollection StateProvinceRecords()
		{
			return new AdventureWorks.StateProvinceCollection().Where(StateProvince.Columns.CountryRegionCode, CountryRegionCode).Load();
		}
		public AdventureWorks.CountryRegionCurrencyCollection CountryRegionCurrencyRecords()
		{
			return new AdventureWorks.CountryRegionCurrencyCollection().Where(CountryRegionCurrency.Columns.CountryRegionCode, CountryRegionCode).Load();
		}
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		#region Many To Many Helpers
		
		 
		public AdventureWorks.CurrencyCollection GetCurrencyCollection() { return CountryRegion.GetCurrencyCollection(this.CountryRegionCode); }
		public static AdventureWorks.CurrencyCollection GetCurrencyCollection(string varCountryRegionCode)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [Sales].[Currency] INNER JOIN [CountryRegionCurrency] ON [Currency].[CurrencyCode] = [CountryRegionCurrency].[CurrencyCode] WHERE [CountryRegionCurrency].[CountryRegionCode] = @CountryRegionCode", CountryRegion.Schema.Provider.Name);
			cmd.AddParameter("@CountryRegionCode", varCountryRegionCode, DbType.String);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			CurrencyCollection coll = new CurrencyCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveCurrencyMap(string varCountryRegionCode, CurrencyCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [CountryRegionCurrency] WHERE [CountryRegionCurrency].[CountryRegionCode] = @CountryRegionCode", CountryRegion.Schema.Provider.Name);
			cmdDel.AddParameter("@CountryRegionCode", varCountryRegionCode, DbType.String);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Currency item in items)
			{
				CountryRegionCurrency varCountryRegionCurrency = new CountryRegionCurrency();
				varCountryRegionCurrency.SetColumnValue("CountryRegionCode", varCountryRegionCode);
				varCountryRegionCurrency.SetColumnValue("CurrencyCode", item.GetPrimaryKeyValue());
				varCountryRegionCurrency.Save();
			}
		}
		public static void SaveCurrencyMap(string varCountryRegionCode, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [CountryRegionCurrency] WHERE [CountryRegionCurrency].[CountryRegionCode] = @CountryRegionCode", CountryRegion.Schema.Provider.Name);
			cmdDel.AddParameter("@CountryRegionCode", varCountryRegionCode, DbType.String);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					CountryRegionCurrency varCountryRegionCurrency = new CountryRegionCurrency();
					varCountryRegionCurrency.SetColumnValue("CountryRegionCode", varCountryRegionCode);
					varCountryRegionCurrency.SetColumnValue("CurrencyCode", l.Value);
					varCountryRegionCurrency.Save();
				}
			}
		}
		public static void SaveCurrencyMap(string varCountryRegionCode , string[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [CountryRegionCurrency] WHERE [CountryRegionCurrency].[CountryRegionCode] = @CountryRegionCode", CountryRegion.Schema.Provider.Name);
			cmdDel.AddParameter("@CountryRegionCode", varCountryRegionCode, DbType.String);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (string item in itemList) 
			{
				CountryRegionCurrency varCountryRegionCurrency = new CountryRegionCurrency();
				varCountryRegionCurrency.SetColumnValue("CountryRegionCode", varCountryRegionCode);
				varCountryRegionCurrency.SetColumnValue("CurrencyCode", item);
				varCountryRegionCurrency.Save();
			}
		}
		
		public static void DeleteCurrencyMap(string varCountryRegionCode) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [CountryRegionCurrency] WHERE [CountryRegionCurrency].[CountryRegionCode] = @CountryRegionCode", CountryRegion.Schema.Provider.Name);
			cmdDel.AddParameter("@CountryRegionCode", varCountryRegionCode, DbType.String);
			DataService.ExecuteQuery(cmdDel);
		}
		
		#endregion
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varCountryRegionCode,string varName,DateTime varModifiedDate)
		{
			CountryRegion item = new CountryRegion();
			
			item.CountryRegionCode = varCountryRegionCode;
			
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
		public static void Update(string varCountryRegionCode,string varName,DateTime varModifiedDate)
		{
			CountryRegion item = new CountryRegion();
			
				item.CountryRegionCode = varCountryRegionCode;
			
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
        
        
        public static TableSchema.TableColumn CountryRegionCodeColumn
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
			 public static string CountryRegionCode = @"CountryRegionCode";
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
