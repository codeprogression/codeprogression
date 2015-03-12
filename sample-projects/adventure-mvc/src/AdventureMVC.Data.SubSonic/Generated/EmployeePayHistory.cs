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
	/// Strongly-typed collection for the EmployeePayHistory class.
	/// </summary>
    [Serializable]
	public partial class EmployeePayHistoryCollection : ActiveList<EmployeePayHistory, EmployeePayHistoryCollection>
	{	   
		public EmployeePayHistoryCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>EmployeePayHistoryCollection</returns>
		public EmployeePayHistoryCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                EmployeePayHistory o = this[i];
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
	/// This is an ActiveRecord class which wraps the EmployeePayHistory table.
	/// </summary>
	[Serializable]
	public partial class EmployeePayHistory : ActiveRecord<EmployeePayHistory>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public EmployeePayHistory()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public EmployeePayHistory(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public EmployeePayHistory(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public EmployeePayHistory(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("EmployeePayHistory", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"HumanResources";
				//columns
				
				TableSchema.TableColumn colvarEmployeeID = new TableSchema.TableColumn(schema);
				colvarEmployeeID.ColumnName = "EmployeeID";
				colvarEmployeeID.DataType = DbType.Int32;
				colvarEmployeeID.MaxLength = 0;
				colvarEmployeeID.AutoIncrement = false;
				colvarEmployeeID.IsNullable = false;
				colvarEmployeeID.IsPrimaryKey = true;
				colvarEmployeeID.IsForeignKey = true;
				colvarEmployeeID.IsReadOnly = false;
				colvarEmployeeID.DefaultSetting = @"";
				
					colvarEmployeeID.ForeignKeyTableName = "Employee";
				schema.Columns.Add(colvarEmployeeID);
				
				TableSchema.TableColumn colvarRateChangeDate = new TableSchema.TableColumn(schema);
				colvarRateChangeDate.ColumnName = "RateChangeDate";
				colvarRateChangeDate.DataType = DbType.DateTime;
				colvarRateChangeDate.MaxLength = 0;
				colvarRateChangeDate.AutoIncrement = false;
				colvarRateChangeDate.IsNullable = false;
				colvarRateChangeDate.IsPrimaryKey = true;
				colvarRateChangeDate.IsForeignKey = false;
				colvarRateChangeDate.IsReadOnly = false;
				colvarRateChangeDate.DefaultSetting = @"";
				colvarRateChangeDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRateChangeDate);
				
				TableSchema.TableColumn colvarRate = new TableSchema.TableColumn(schema);
				colvarRate.ColumnName = "Rate";
				colvarRate.DataType = DbType.Currency;
				colvarRate.MaxLength = 0;
				colvarRate.AutoIncrement = false;
				colvarRate.IsNullable = false;
				colvarRate.IsPrimaryKey = false;
				colvarRate.IsForeignKey = false;
				colvarRate.IsReadOnly = false;
				colvarRate.DefaultSetting = @"";
				colvarRate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRate);
				
				TableSchema.TableColumn colvarPayFrequency = new TableSchema.TableColumn(schema);
				colvarPayFrequency.ColumnName = "PayFrequency";
				colvarPayFrequency.DataType = DbType.Byte;
				colvarPayFrequency.MaxLength = 0;
				colvarPayFrequency.AutoIncrement = false;
				colvarPayFrequency.IsNullable = false;
				colvarPayFrequency.IsPrimaryKey = false;
				colvarPayFrequency.IsForeignKey = false;
				colvarPayFrequency.IsReadOnly = false;
				colvarPayFrequency.DefaultSetting = @"";
				colvarPayFrequency.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPayFrequency);
				
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
				DataService.Providers["AdventureWorks"].AddSchema("EmployeePayHistory",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("EmployeeID")]
		[Bindable(true)]
		public int EmployeeID 
		{
			get { return GetColumnValue<int>(Columns.EmployeeID); }
			set { SetColumnValue(Columns.EmployeeID, value); }
		}
		  
		[XmlAttribute("RateChangeDate")]
		[Bindable(true)]
		public DateTime RateChangeDate 
		{
			get { return GetColumnValue<DateTime>(Columns.RateChangeDate); }
			set { SetColumnValue(Columns.RateChangeDate, value); }
		}
		  
		[XmlAttribute("Rate")]
		[Bindable(true)]
		public decimal Rate 
		{
			get { return GetColumnValue<decimal>(Columns.Rate); }
			set { SetColumnValue(Columns.Rate, value); }
		}
		  
		[XmlAttribute("PayFrequency")]
		[Bindable(true)]
		public byte PayFrequency 
		{
			get { return GetColumnValue<byte>(Columns.PayFrequency); }
			set { SetColumnValue(Columns.PayFrequency, value); }
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
		/// Returns a Employee ActiveRecord object related to this EmployeePayHistory
		/// 
		/// </summary>
		public AdventureWorks.Employee Employee
		{
			get { return AdventureWorks.Employee.FetchByID(this.EmployeeID); }
			set { SetColumnValue("EmployeeID", value.EmployeeID); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varEmployeeID,DateTime varRateChangeDate,decimal varRate,byte varPayFrequency,DateTime varModifiedDate)
		{
			EmployeePayHistory item = new EmployeePayHistory();
			
			item.EmployeeID = varEmployeeID;
			
			item.RateChangeDate = varRateChangeDate;
			
			item.Rate = varRate;
			
			item.PayFrequency = varPayFrequency;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varEmployeeID,DateTime varRateChangeDate,decimal varRate,byte varPayFrequency,DateTime varModifiedDate)
		{
			EmployeePayHistory item = new EmployeePayHistory();
			
				item.EmployeeID = varEmployeeID;
			
				item.RateChangeDate = varRateChangeDate;
			
				item.Rate = varRate;
			
				item.PayFrequency = varPayFrequency;
			
				item.ModifiedDate = varModifiedDate;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn EmployeeIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn RateChangeDateColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn RateColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn PayFrequencyColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedDateColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string EmployeeID = @"EmployeeID";
			 public static string RateChangeDate = @"RateChangeDate";
			 public static string Rate = @"Rate";
			 public static string PayFrequency = @"PayFrequency";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
