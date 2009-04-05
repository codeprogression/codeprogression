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
	/// Strongly-typed collection for the EmployeeDepartmentHistory class.
	/// </summary>
    [Serializable]
	public partial class EmployeeDepartmentHistoryCollection : ActiveList<EmployeeDepartmentHistory, EmployeeDepartmentHistoryCollection>
	{	   
		public EmployeeDepartmentHistoryCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>EmployeeDepartmentHistoryCollection</returns>
		public EmployeeDepartmentHistoryCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                EmployeeDepartmentHistory o = this[i];
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
	/// This is an ActiveRecord class which wraps the EmployeeDepartmentHistory table.
	/// </summary>
	[Serializable]
	public partial class EmployeeDepartmentHistory : ActiveRecord<EmployeeDepartmentHistory>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public EmployeeDepartmentHistory()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public EmployeeDepartmentHistory(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public EmployeeDepartmentHistory(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public EmployeeDepartmentHistory(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("EmployeeDepartmentHistory", TableType.Table, DataService.GetInstance("AdventureWorks"));
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
				
				TableSchema.TableColumn colvarDepartmentID = new TableSchema.TableColumn(schema);
				colvarDepartmentID.ColumnName = "DepartmentID";
				colvarDepartmentID.DataType = DbType.Int16;
				colvarDepartmentID.MaxLength = 0;
				colvarDepartmentID.AutoIncrement = false;
				colvarDepartmentID.IsNullable = false;
				colvarDepartmentID.IsPrimaryKey = true;
				colvarDepartmentID.IsForeignKey = true;
				colvarDepartmentID.IsReadOnly = false;
				colvarDepartmentID.DefaultSetting = @"";
				
					colvarDepartmentID.ForeignKeyTableName = "Department";
				schema.Columns.Add(colvarDepartmentID);
				
				TableSchema.TableColumn colvarShiftID = new TableSchema.TableColumn(schema);
				colvarShiftID.ColumnName = "ShiftID";
				colvarShiftID.DataType = DbType.Byte;
				colvarShiftID.MaxLength = 0;
				colvarShiftID.AutoIncrement = false;
				colvarShiftID.IsNullable = false;
				colvarShiftID.IsPrimaryKey = true;
				colvarShiftID.IsForeignKey = true;
				colvarShiftID.IsReadOnly = false;
				colvarShiftID.DefaultSetting = @"";
				
					colvarShiftID.ForeignKeyTableName = "Shift";
				schema.Columns.Add(colvarShiftID);
				
				TableSchema.TableColumn colvarStartDate = new TableSchema.TableColumn(schema);
				colvarStartDate.ColumnName = "StartDate";
				colvarStartDate.DataType = DbType.DateTime;
				colvarStartDate.MaxLength = 0;
				colvarStartDate.AutoIncrement = false;
				colvarStartDate.IsNullable = false;
				colvarStartDate.IsPrimaryKey = true;
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
				DataService.Providers["AdventureWorks"].AddSchema("EmployeeDepartmentHistory",schema);
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
		  
		[XmlAttribute("DepartmentID")]
		[Bindable(true)]
		public short DepartmentID 
		{
			get { return GetColumnValue<short>(Columns.DepartmentID); }
			set { SetColumnValue(Columns.DepartmentID, value); }
		}
		  
		[XmlAttribute("ShiftID")]
		[Bindable(true)]
		public byte ShiftID 
		{
			get { return GetColumnValue<byte>(Columns.ShiftID); }
			set { SetColumnValue(Columns.ShiftID, value); }
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
		/// Returns a Department ActiveRecord object related to this EmployeeDepartmentHistory
		/// 
		/// </summary>
		public AdventureWorks.Department Department
		{
			get { return AdventureWorks.Department.FetchByID(this.DepartmentID); }
			set { SetColumnValue("DepartmentID", value.DepartmentID); }
		}
		
		
		/// <summary>
		/// Returns a Employee ActiveRecord object related to this EmployeeDepartmentHistory
		/// 
		/// </summary>
		public AdventureWorks.Employee Employee
		{
			get { return AdventureWorks.Employee.FetchByID(this.EmployeeID); }
			set { SetColumnValue("EmployeeID", value.EmployeeID); }
		}
		
		
		/// <summary>
		/// Returns a Shift ActiveRecord object related to this EmployeeDepartmentHistory
		/// 
		/// </summary>
		public AdventureWorks.Shift Shift
		{
			get { return AdventureWorks.Shift.FetchByID(this.ShiftID); }
			set { SetColumnValue("ShiftID", value.ShiftID); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varEmployeeID,short varDepartmentID,byte varShiftID,DateTime varStartDate,DateTime? varEndDate,DateTime varModifiedDate)
		{
			EmployeeDepartmentHistory item = new EmployeeDepartmentHistory();
			
			item.EmployeeID = varEmployeeID;
			
			item.DepartmentID = varDepartmentID;
			
			item.ShiftID = varShiftID;
			
			item.StartDate = varStartDate;
			
			item.EndDate = varEndDate;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varEmployeeID,short varDepartmentID,byte varShiftID,DateTime varStartDate,DateTime? varEndDate,DateTime varModifiedDate)
		{
			EmployeeDepartmentHistory item = new EmployeeDepartmentHistory();
			
				item.EmployeeID = varEmployeeID;
			
				item.DepartmentID = varDepartmentID;
			
				item.ShiftID = varShiftID;
			
				item.StartDate = varStartDate;
			
				item.EndDate = varEndDate;
			
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
        
        
        
        public static TableSchema.TableColumn DepartmentIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ShiftIDColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn StartDateColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn EndDateColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedDateColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string EmployeeID = @"EmployeeID";
			 public static string DepartmentID = @"DepartmentID";
			 public static string ShiftID = @"ShiftID";
			 public static string StartDate = @"StartDate";
			 public static string EndDate = @"EndDate";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
