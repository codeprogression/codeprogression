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
	/// Strongly-typed collection for the DatabaseLog class.
	/// </summary>
    [Serializable]
	public partial class DatabaseLogCollection : ActiveList<DatabaseLog, DatabaseLogCollection>
	{	   
		public DatabaseLogCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>DatabaseLogCollection</returns>
		public DatabaseLogCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                DatabaseLog o = this[i];
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
	/// This is an ActiveRecord class which wraps the DatabaseLog table.
	/// </summary>
	[Serializable]
	public partial class DatabaseLog : ActiveRecord<DatabaseLog>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public DatabaseLog()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public DatabaseLog(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public DatabaseLog(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public DatabaseLog(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("DatabaseLog", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarDatabaseLogID = new TableSchema.TableColumn(schema);
				colvarDatabaseLogID.ColumnName = "DatabaseLogID";
				colvarDatabaseLogID.DataType = DbType.Int32;
				colvarDatabaseLogID.MaxLength = 0;
				colvarDatabaseLogID.AutoIncrement = true;
				colvarDatabaseLogID.IsNullable = false;
				colvarDatabaseLogID.IsPrimaryKey = true;
				colvarDatabaseLogID.IsForeignKey = false;
				colvarDatabaseLogID.IsReadOnly = false;
				colvarDatabaseLogID.DefaultSetting = @"";
				colvarDatabaseLogID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDatabaseLogID);
				
				TableSchema.TableColumn colvarPostTime = new TableSchema.TableColumn(schema);
				colvarPostTime.ColumnName = "PostTime";
				colvarPostTime.DataType = DbType.DateTime;
				colvarPostTime.MaxLength = 0;
				colvarPostTime.AutoIncrement = false;
				colvarPostTime.IsNullable = false;
				colvarPostTime.IsPrimaryKey = false;
				colvarPostTime.IsForeignKey = false;
				colvarPostTime.IsReadOnly = false;
				colvarPostTime.DefaultSetting = @"";
				colvarPostTime.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPostTime);
				
				TableSchema.TableColumn colvarDatabaseUser = new TableSchema.TableColumn(schema);
				colvarDatabaseUser.ColumnName = "DatabaseUser";
				colvarDatabaseUser.DataType = DbType.String;
				colvarDatabaseUser.MaxLength = 128;
				colvarDatabaseUser.AutoIncrement = false;
				colvarDatabaseUser.IsNullable = false;
				colvarDatabaseUser.IsPrimaryKey = false;
				colvarDatabaseUser.IsForeignKey = false;
				colvarDatabaseUser.IsReadOnly = false;
				colvarDatabaseUser.DefaultSetting = @"";
				colvarDatabaseUser.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDatabaseUser);
				
				TableSchema.TableColumn colvarEventX = new TableSchema.TableColumn(schema);
				colvarEventX.ColumnName = "Event";
				colvarEventX.DataType = DbType.String;
				colvarEventX.MaxLength = 128;
				colvarEventX.AutoIncrement = false;
				colvarEventX.IsNullable = false;
				colvarEventX.IsPrimaryKey = false;
				colvarEventX.IsForeignKey = false;
				colvarEventX.IsReadOnly = false;
				colvarEventX.DefaultSetting = @"";
				colvarEventX.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEventX);
				
				TableSchema.TableColumn colvarSchemaX = new TableSchema.TableColumn(schema);
				colvarSchemaX.ColumnName = "Schema";
				colvarSchemaX.DataType = DbType.String;
				colvarSchemaX.MaxLength = 128;
				colvarSchemaX.AutoIncrement = false;
				colvarSchemaX.IsNullable = true;
				colvarSchemaX.IsPrimaryKey = false;
				colvarSchemaX.IsForeignKey = false;
				colvarSchemaX.IsReadOnly = false;
				colvarSchemaX.DefaultSetting = @"";
				colvarSchemaX.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSchemaX);
				
				TableSchema.TableColumn colvarObjectX = new TableSchema.TableColumn(schema);
				colvarObjectX.ColumnName = "Object";
				colvarObjectX.DataType = DbType.String;
				colvarObjectX.MaxLength = 128;
				colvarObjectX.AutoIncrement = false;
				colvarObjectX.IsNullable = true;
				colvarObjectX.IsPrimaryKey = false;
				colvarObjectX.IsForeignKey = false;
				colvarObjectX.IsReadOnly = false;
				colvarObjectX.DefaultSetting = @"";
				colvarObjectX.ForeignKeyTableName = "";
				schema.Columns.Add(colvarObjectX);
				
				TableSchema.TableColumn colvarTsql = new TableSchema.TableColumn(schema);
				colvarTsql.ColumnName = "TSQL";
				colvarTsql.DataType = DbType.String;
				colvarTsql.MaxLength = -1;
				colvarTsql.AutoIncrement = false;
				colvarTsql.IsNullable = false;
				colvarTsql.IsPrimaryKey = false;
				colvarTsql.IsForeignKey = false;
				colvarTsql.IsReadOnly = false;
				colvarTsql.DefaultSetting = @"";
				colvarTsql.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTsql);
				
				TableSchema.TableColumn colvarXmlEvent = new TableSchema.TableColumn(schema);
				colvarXmlEvent.ColumnName = "XmlEvent";
				colvarXmlEvent.DataType = DbType.AnsiString;
				colvarXmlEvent.MaxLength = -1;
				colvarXmlEvent.AutoIncrement = false;
				colvarXmlEvent.IsNullable = false;
				colvarXmlEvent.IsPrimaryKey = false;
				colvarXmlEvent.IsForeignKey = false;
				colvarXmlEvent.IsReadOnly = false;
				colvarXmlEvent.DefaultSetting = @"";
				colvarXmlEvent.ForeignKeyTableName = "";
				schema.Columns.Add(colvarXmlEvent);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["AdventureWorks"].AddSchema("DatabaseLog",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("DatabaseLogID")]
		[Bindable(true)]
		public int DatabaseLogID 
		{
			get { return GetColumnValue<int>(Columns.DatabaseLogID); }
			set { SetColumnValue(Columns.DatabaseLogID, value); }
		}
		  
		[XmlAttribute("PostTime")]
		[Bindable(true)]
		public DateTime PostTime 
		{
			get { return GetColumnValue<DateTime>(Columns.PostTime); }
			set { SetColumnValue(Columns.PostTime, value); }
		}
		  
		[XmlAttribute("DatabaseUser")]
		[Bindable(true)]
		public string DatabaseUser 
		{
			get { return GetColumnValue<string>(Columns.DatabaseUser); }
			set { SetColumnValue(Columns.DatabaseUser, value); }
		}
		  
		[XmlAttribute("EventX")]
		[Bindable(true)]
		public string EventX 
		{
			get { return GetColumnValue<string>(Columns.EventX); }
			set { SetColumnValue(Columns.EventX, value); }
		}
		  
		[XmlAttribute("SchemaX")]
		[Bindable(true)]
		public string SchemaX 
		{
			get { return GetColumnValue<string>(Columns.SchemaX); }
			set { SetColumnValue(Columns.SchemaX, value); }
		}
		  
		[XmlAttribute("ObjectX")]
		[Bindable(true)]
		public string ObjectX 
		{
			get { return GetColumnValue<string>(Columns.ObjectX); }
			set { SetColumnValue(Columns.ObjectX, value); }
		}
		  
		[XmlAttribute("Tsql")]
		[Bindable(true)]
		public string Tsql 
		{
			get { return GetColumnValue<string>(Columns.Tsql); }
			set { SetColumnValue(Columns.Tsql, value); }
		}
		  
		[XmlAttribute("XmlEvent")]
		[Bindable(true)]
		public string XmlEvent 
		{
			get { return GetColumnValue<string>(Columns.XmlEvent); }
			set { SetColumnValue(Columns.XmlEvent, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(DateTime varPostTime,string varDatabaseUser,string varEventX,string varSchemaX,string varObjectX,string varTsql,string varXmlEvent)
		{
			DatabaseLog item = new DatabaseLog();
			
			item.PostTime = varPostTime;
			
			item.DatabaseUser = varDatabaseUser;
			
			item.EventX = varEventX;
			
			item.SchemaX = varSchemaX;
			
			item.ObjectX = varObjectX;
			
			item.Tsql = varTsql;
			
			item.XmlEvent = varXmlEvent;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varDatabaseLogID,DateTime varPostTime,string varDatabaseUser,string varEventX,string varSchemaX,string varObjectX,string varTsql,string varXmlEvent)
		{
			DatabaseLog item = new DatabaseLog();
			
				item.DatabaseLogID = varDatabaseLogID;
			
				item.PostTime = varPostTime;
			
				item.DatabaseUser = varDatabaseUser;
			
				item.EventX = varEventX;
			
				item.SchemaX = varSchemaX;
			
				item.ObjectX = varObjectX;
			
				item.Tsql = varTsql;
			
				item.XmlEvent = varXmlEvent;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn DatabaseLogIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn PostTimeColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DatabaseUserColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn EventXColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn SchemaXColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ObjectXColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn TsqlColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn XmlEventColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string DatabaseLogID = @"DatabaseLogID";
			 public static string PostTime = @"PostTime";
			 public static string DatabaseUser = @"DatabaseUser";
			 public static string EventX = @"Event";
			 public static string SchemaX = @"Schema";
			 public static string ObjectX = @"Object";
			 public static string Tsql = @"TSQL";
			 public static string XmlEvent = @"XmlEvent";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
