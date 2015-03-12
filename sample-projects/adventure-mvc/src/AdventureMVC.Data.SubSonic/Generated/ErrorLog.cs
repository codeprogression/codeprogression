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
	/// Strongly-typed collection for the ErrorLog class.
	/// </summary>
    [Serializable]
	public partial class ErrorLogCollection : ActiveList<ErrorLog, ErrorLogCollection>
	{	   
		public ErrorLogCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ErrorLogCollection</returns>
		public ErrorLogCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                ErrorLog o = this[i];
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
	/// This is an ActiveRecord class which wraps the ErrorLog table.
	/// </summary>
	[Serializable]
	public partial class ErrorLog : ActiveRecord<ErrorLog>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public ErrorLog()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public ErrorLog(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public ErrorLog(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public ErrorLog(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ErrorLog", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarErrorLogID = new TableSchema.TableColumn(schema);
				colvarErrorLogID.ColumnName = "ErrorLogID";
				colvarErrorLogID.DataType = DbType.Int32;
				colvarErrorLogID.MaxLength = 0;
				colvarErrorLogID.AutoIncrement = true;
				colvarErrorLogID.IsNullable = false;
				colvarErrorLogID.IsPrimaryKey = true;
				colvarErrorLogID.IsForeignKey = false;
				colvarErrorLogID.IsReadOnly = false;
				colvarErrorLogID.DefaultSetting = @"";
				colvarErrorLogID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarErrorLogID);
				
				TableSchema.TableColumn colvarErrorTime = new TableSchema.TableColumn(schema);
				colvarErrorTime.ColumnName = "ErrorTime";
				colvarErrorTime.DataType = DbType.DateTime;
				colvarErrorTime.MaxLength = 0;
				colvarErrorTime.AutoIncrement = false;
				colvarErrorTime.IsNullable = false;
				colvarErrorTime.IsPrimaryKey = false;
				colvarErrorTime.IsForeignKey = false;
				colvarErrorTime.IsReadOnly = false;
				
						colvarErrorTime.DefaultSetting = @"(getdate())";
				colvarErrorTime.ForeignKeyTableName = "";
				schema.Columns.Add(colvarErrorTime);
				
				TableSchema.TableColumn colvarUserName = new TableSchema.TableColumn(schema);
				colvarUserName.ColumnName = "UserName";
				colvarUserName.DataType = DbType.String;
				colvarUserName.MaxLength = 128;
				colvarUserName.AutoIncrement = false;
				colvarUserName.IsNullable = false;
				colvarUserName.IsPrimaryKey = false;
				colvarUserName.IsForeignKey = false;
				colvarUserName.IsReadOnly = false;
				colvarUserName.DefaultSetting = @"";
				colvarUserName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUserName);
				
				TableSchema.TableColumn colvarErrorNumber = new TableSchema.TableColumn(schema);
				colvarErrorNumber.ColumnName = "ErrorNumber";
				colvarErrorNumber.DataType = DbType.Int32;
				colvarErrorNumber.MaxLength = 0;
				colvarErrorNumber.AutoIncrement = false;
				colvarErrorNumber.IsNullable = false;
				colvarErrorNumber.IsPrimaryKey = false;
				colvarErrorNumber.IsForeignKey = false;
				colvarErrorNumber.IsReadOnly = false;
				colvarErrorNumber.DefaultSetting = @"";
				colvarErrorNumber.ForeignKeyTableName = "";
				schema.Columns.Add(colvarErrorNumber);
				
				TableSchema.TableColumn colvarErrorSeverity = new TableSchema.TableColumn(schema);
				colvarErrorSeverity.ColumnName = "ErrorSeverity";
				colvarErrorSeverity.DataType = DbType.Int32;
				colvarErrorSeverity.MaxLength = 0;
				colvarErrorSeverity.AutoIncrement = false;
				colvarErrorSeverity.IsNullable = true;
				colvarErrorSeverity.IsPrimaryKey = false;
				colvarErrorSeverity.IsForeignKey = false;
				colvarErrorSeverity.IsReadOnly = false;
				colvarErrorSeverity.DefaultSetting = @"";
				colvarErrorSeverity.ForeignKeyTableName = "";
				schema.Columns.Add(colvarErrorSeverity);
				
				TableSchema.TableColumn colvarErrorState = new TableSchema.TableColumn(schema);
				colvarErrorState.ColumnName = "ErrorState";
				colvarErrorState.DataType = DbType.Int32;
				colvarErrorState.MaxLength = 0;
				colvarErrorState.AutoIncrement = false;
				colvarErrorState.IsNullable = true;
				colvarErrorState.IsPrimaryKey = false;
				colvarErrorState.IsForeignKey = false;
				colvarErrorState.IsReadOnly = false;
				colvarErrorState.DefaultSetting = @"";
				colvarErrorState.ForeignKeyTableName = "";
				schema.Columns.Add(colvarErrorState);
				
				TableSchema.TableColumn colvarErrorProcedure = new TableSchema.TableColumn(schema);
				colvarErrorProcedure.ColumnName = "ErrorProcedure";
				colvarErrorProcedure.DataType = DbType.String;
				colvarErrorProcedure.MaxLength = 126;
				colvarErrorProcedure.AutoIncrement = false;
				colvarErrorProcedure.IsNullable = true;
				colvarErrorProcedure.IsPrimaryKey = false;
				colvarErrorProcedure.IsForeignKey = false;
				colvarErrorProcedure.IsReadOnly = false;
				colvarErrorProcedure.DefaultSetting = @"";
				colvarErrorProcedure.ForeignKeyTableName = "";
				schema.Columns.Add(colvarErrorProcedure);
				
				TableSchema.TableColumn colvarErrorLine = new TableSchema.TableColumn(schema);
				colvarErrorLine.ColumnName = "ErrorLine";
				colvarErrorLine.DataType = DbType.Int32;
				colvarErrorLine.MaxLength = 0;
				colvarErrorLine.AutoIncrement = false;
				colvarErrorLine.IsNullable = true;
				colvarErrorLine.IsPrimaryKey = false;
				colvarErrorLine.IsForeignKey = false;
				colvarErrorLine.IsReadOnly = false;
				colvarErrorLine.DefaultSetting = @"";
				colvarErrorLine.ForeignKeyTableName = "";
				schema.Columns.Add(colvarErrorLine);
				
				TableSchema.TableColumn colvarErrorMessage = new TableSchema.TableColumn(schema);
				colvarErrorMessage.ColumnName = "ErrorMessage";
				colvarErrorMessage.DataType = DbType.String;
				colvarErrorMessage.MaxLength = 4000;
				colvarErrorMessage.AutoIncrement = false;
				colvarErrorMessage.IsNullable = false;
				colvarErrorMessage.IsPrimaryKey = false;
				colvarErrorMessage.IsForeignKey = false;
				colvarErrorMessage.IsReadOnly = false;
				colvarErrorMessage.DefaultSetting = @"";
				colvarErrorMessage.ForeignKeyTableName = "";
				schema.Columns.Add(colvarErrorMessage);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["AdventureWorks"].AddSchema("ErrorLog",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("ErrorLogID")]
		[Bindable(true)]
		public int ErrorLogID 
		{
			get { return GetColumnValue<int>(Columns.ErrorLogID); }
			set { SetColumnValue(Columns.ErrorLogID, value); }
		}
		  
		[XmlAttribute("ErrorTime")]
		[Bindable(true)]
		public DateTime ErrorTime 
		{
			get { return GetColumnValue<DateTime>(Columns.ErrorTime); }
			set { SetColumnValue(Columns.ErrorTime, value); }
		}
		  
		[XmlAttribute("UserName")]
		[Bindable(true)]
		public string UserName 
		{
			get { return GetColumnValue<string>(Columns.UserName); }
			set { SetColumnValue(Columns.UserName, value); }
		}
		  
		[XmlAttribute("ErrorNumber")]
		[Bindable(true)]
		public int ErrorNumber 
		{
			get { return GetColumnValue<int>(Columns.ErrorNumber); }
			set { SetColumnValue(Columns.ErrorNumber, value); }
		}
		  
		[XmlAttribute("ErrorSeverity")]
		[Bindable(true)]
		public int? ErrorSeverity 
		{
			get { return GetColumnValue<int?>(Columns.ErrorSeverity); }
			set { SetColumnValue(Columns.ErrorSeverity, value); }
		}
		  
		[XmlAttribute("ErrorState")]
		[Bindable(true)]
		public int? ErrorState 
		{
			get { return GetColumnValue<int?>(Columns.ErrorState); }
			set { SetColumnValue(Columns.ErrorState, value); }
		}
		  
		[XmlAttribute("ErrorProcedure")]
		[Bindable(true)]
		public string ErrorProcedure 
		{
			get { return GetColumnValue<string>(Columns.ErrorProcedure); }
			set { SetColumnValue(Columns.ErrorProcedure, value); }
		}
		  
		[XmlAttribute("ErrorLine")]
		[Bindable(true)]
		public int? ErrorLine 
		{
			get { return GetColumnValue<int?>(Columns.ErrorLine); }
			set { SetColumnValue(Columns.ErrorLine, value); }
		}
		  
		[XmlAttribute("ErrorMessage")]
		[Bindable(true)]
		public string ErrorMessage 
		{
			get { return GetColumnValue<string>(Columns.ErrorMessage); }
			set { SetColumnValue(Columns.ErrorMessage, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(DateTime varErrorTime,string varUserName,int varErrorNumber,int? varErrorSeverity,int? varErrorState,string varErrorProcedure,int? varErrorLine,string varErrorMessage)
		{
			ErrorLog item = new ErrorLog();
			
			item.ErrorTime = varErrorTime;
			
			item.UserName = varUserName;
			
			item.ErrorNumber = varErrorNumber;
			
			item.ErrorSeverity = varErrorSeverity;
			
			item.ErrorState = varErrorState;
			
			item.ErrorProcedure = varErrorProcedure;
			
			item.ErrorLine = varErrorLine;
			
			item.ErrorMessage = varErrorMessage;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varErrorLogID,DateTime varErrorTime,string varUserName,int varErrorNumber,int? varErrorSeverity,int? varErrorState,string varErrorProcedure,int? varErrorLine,string varErrorMessage)
		{
			ErrorLog item = new ErrorLog();
			
				item.ErrorLogID = varErrorLogID;
			
				item.ErrorTime = varErrorTime;
			
				item.UserName = varUserName;
			
				item.ErrorNumber = varErrorNumber;
			
				item.ErrorSeverity = varErrorSeverity;
			
				item.ErrorState = varErrorState;
			
				item.ErrorProcedure = varErrorProcedure;
			
				item.ErrorLine = varErrorLine;
			
				item.ErrorMessage = varErrorMessage;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn ErrorLogIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ErrorTimeColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn UserNameColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn ErrorNumberColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ErrorSeverityColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ErrorStateColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn ErrorProcedureColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn ErrorLineColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn ErrorMessageColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string ErrorLogID = @"ErrorLogID";
			 public static string ErrorTime = @"ErrorTime";
			 public static string UserName = @"UserName";
			 public static string ErrorNumber = @"ErrorNumber";
			 public static string ErrorSeverity = @"ErrorSeverity";
			 public static string ErrorState = @"ErrorState";
			 public static string ErrorProcedure = @"ErrorProcedure";
			 public static string ErrorLine = @"ErrorLine";
			 public static string ErrorMessage = @"ErrorMessage";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
