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
	/// Strongly-typed collection for the SalesReason class.
	/// </summary>
    [Serializable]
	public partial class SalesReasonCollection : ActiveList<SalesReason, SalesReasonCollection>
	{	   
		public SalesReasonCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SalesReasonCollection</returns>
		public SalesReasonCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SalesReason o = this[i];
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
	/// This is an ActiveRecord class which wraps the SalesReason table.
	/// </summary>
	[Serializable]
	public partial class SalesReason : ActiveRecord<SalesReason>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SalesReason()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SalesReason(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SalesReason(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SalesReason(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("SalesReason", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Sales";
				//columns
				
				TableSchema.TableColumn colvarSalesReasonID = new TableSchema.TableColumn(schema);
				colvarSalesReasonID.ColumnName = "SalesReasonID";
				colvarSalesReasonID.DataType = DbType.Int32;
				colvarSalesReasonID.MaxLength = 0;
				colvarSalesReasonID.AutoIncrement = true;
				colvarSalesReasonID.IsNullable = false;
				colvarSalesReasonID.IsPrimaryKey = true;
				colvarSalesReasonID.IsForeignKey = false;
				colvarSalesReasonID.IsReadOnly = false;
				colvarSalesReasonID.DefaultSetting = @"";
				colvarSalesReasonID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSalesReasonID);
				
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
				
				TableSchema.TableColumn colvarReasonType = new TableSchema.TableColumn(schema);
				colvarReasonType.ColumnName = "ReasonType";
				colvarReasonType.DataType = DbType.String;
				colvarReasonType.MaxLength = 50;
				colvarReasonType.AutoIncrement = false;
				colvarReasonType.IsNullable = false;
				colvarReasonType.IsPrimaryKey = false;
				colvarReasonType.IsForeignKey = false;
				colvarReasonType.IsReadOnly = false;
				colvarReasonType.DefaultSetting = @"";
				colvarReasonType.ForeignKeyTableName = "";
				schema.Columns.Add(colvarReasonType);
				
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
				DataService.Providers["AdventureWorks"].AddSchema("SalesReason",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("SalesReasonID")]
		[Bindable(true)]
		public int SalesReasonID 
		{
			get { return GetColumnValue<int>(Columns.SalesReasonID); }
			set { SetColumnValue(Columns.SalesReasonID, value); }
		}
		  
		[XmlAttribute("Name")]
		[Bindable(true)]
		public string Name 
		{
			get { return GetColumnValue<string>(Columns.Name); }
			set { SetColumnValue(Columns.Name, value); }
		}
		  
		[XmlAttribute("ReasonType")]
		[Bindable(true)]
		public string ReasonType 
		{
			get { return GetColumnValue<string>(Columns.ReasonType); }
			set { SetColumnValue(Columns.ReasonType, value); }
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
        
		
		public AdventureWorks.SalesOrderHeaderSalesReasonCollection SalesOrderHeaderSalesReasonRecords()
		{
			return new AdventureWorks.SalesOrderHeaderSalesReasonCollection().Where(SalesOrderHeaderSalesReason.Columns.SalesReasonID, SalesReasonID).Load();
		}
		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		#region Many To Many Helpers
		
		 
		public AdventureWorks.SalesOrderHeaderCollection GetSalesOrderHeaderCollection() { return SalesReason.GetSalesOrderHeaderCollection(this.SalesReasonID); }
		public static AdventureWorks.SalesOrderHeaderCollection GetSalesOrderHeaderCollection(int varSalesReasonID)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [Sales].[SalesOrderHeader] INNER JOIN [SalesOrderHeaderSalesReason] ON [SalesOrderHeader].[SalesOrderID] = [SalesOrderHeaderSalesReason].[SalesOrderID] WHERE [SalesOrderHeaderSalesReason].[SalesReasonID] = @SalesReasonID", SalesReason.Schema.Provider.Name);
			cmd.AddParameter("@SalesReasonID", varSalesReasonID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			SalesOrderHeaderCollection coll = new SalesOrderHeaderCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveSalesOrderHeaderMap(int varSalesReasonID, SalesOrderHeaderCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [SalesOrderHeaderSalesReason] WHERE [SalesOrderHeaderSalesReason].[SalesReasonID] = @SalesReasonID", SalesReason.Schema.Provider.Name);
			cmdDel.AddParameter("@SalesReasonID", varSalesReasonID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (SalesOrderHeader item in items)
			{
				SalesOrderHeaderSalesReason varSalesOrderHeaderSalesReason = new SalesOrderHeaderSalesReason();
				varSalesOrderHeaderSalesReason.SetColumnValue("SalesReasonID", varSalesReasonID);
				varSalesOrderHeaderSalesReason.SetColumnValue("SalesOrderID", item.GetPrimaryKeyValue());
				varSalesOrderHeaderSalesReason.Save();
			}
		}
		public static void SaveSalesOrderHeaderMap(int varSalesReasonID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [SalesOrderHeaderSalesReason] WHERE [SalesOrderHeaderSalesReason].[SalesReasonID] = @SalesReasonID", SalesReason.Schema.Provider.Name);
			cmdDel.AddParameter("@SalesReasonID", varSalesReasonID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					SalesOrderHeaderSalesReason varSalesOrderHeaderSalesReason = new SalesOrderHeaderSalesReason();
					varSalesOrderHeaderSalesReason.SetColumnValue("SalesReasonID", varSalesReasonID);
					varSalesOrderHeaderSalesReason.SetColumnValue("SalesOrderID", l.Value);
					varSalesOrderHeaderSalesReason.Save();
				}
			}
		}
		public static void SaveSalesOrderHeaderMap(int varSalesReasonID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [SalesOrderHeaderSalesReason] WHERE [SalesOrderHeaderSalesReason].[SalesReasonID] = @SalesReasonID", SalesReason.Schema.Provider.Name);
			cmdDel.AddParameter("@SalesReasonID", varSalesReasonID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				SalesOrderHeaderSalesReason varSalesOrderHeaderSalesReason = new SalesOrderHeaderSalesReason();
				varSalesOrderHeaderSalesReason.SetColumnValue("SalesReasonID", varSalesReasonID);
				varSalesOrderHeaderSalesReason.SetColumnValue("SalesOrderID", item);
				varSalesOrderHeaderSalesReason.Save();
			}
		}
		
		public static void DeleteSalesOrderHeaderMap(int varSalesReasonID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [SalesOrderHeaderSalesReason] WHERE [SalesOrderHeaderSalesReason].[SalesReasonID] = @SalesReasonID", SalesReason.Schema.Provider.Name);
			cmdDel.AddParameter("@SalesReasonID", varSalesReasonID, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		#endregion
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varName,string varReasonType,DateTime varModifiedDate)
		{
			SalesReason item = new SalesReason();
			
			item.Name = varName;
			
			item.ReasonType = varReasonType;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varSalesReasonID,string varName,string varReasonType,DateTime varModifiedDate)
		{
			SalesReason item = new SalesReason();
			
				item.SalesReasonID = varSalesReasonID;
			
				item.Name = varName;
			
				item.ReasonType = varReasonType;
			
				item.ModifiedDate = varModifiedDate;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn SalesReasonIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NameColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ReasonTypeColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedDateColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string SalesReasonID = @"SalesReasonID";
			 public static string Name = @"Name";
			 public static string ReasonType = @"ReasonType";
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
