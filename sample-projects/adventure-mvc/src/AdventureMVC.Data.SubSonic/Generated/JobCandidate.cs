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
	/// Strongly-typed collection for the JobCandidate class.
	/// </summary>
    [Serializable]
	public partial class JobCandidateCollection : ActiveList<JobCandidate, JobCandidateCollection>
	{	   
		public JobCandidateCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>JobCandidateCollection</returns>
		public JobCandidateCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                JobCandidate o = this[i];
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
	/// This is an ActiveRecord class which wraps the JobCandidate table.
	/// </summary>
	[Serializable]
	public partial class JobCandidate : ActiveRecord<JobCandidate>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public JobCandidate()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public JobCandidate(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public JobCandidate(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public JobCandidate(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("JobCandidate", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"HumanResources";
				//columns
				
				TableSchema.TableColumn colvarJobCandidateID = new TableSchema.TableColumn(schema);
				colvarJobCandidateID.ColumnName = "JobCandidateID";
				colvarJobCandidateID.DataType = DbType.Int32;
				colvarJobCandidateID.MaxLength = 0;
				colvarJobCandidateID.AutoIncrement = true;
				colvarJobCandidateID.IsNullable = false;
				colvarJobCandidateID.IsPrimaryKey = true;
				colvarJobCandidateID.IsForeignKey = false;
				colvarJobCandidateID.IsReadOnly = false;
				colvarJobCandidateID.DefaultSetting = @"";
				colvarJobCandidateID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarJobCandidateID);
				
				TableSchema.TableColumn colvarEmployeeID = new TableSchema.TableColumn(schema);
				colvarEmployeeID.ColumnName = "EmployeeID";
				colvarEmployeeID.DataType = DbType.Int32;
				colvarEmployeeID.MaxLength = 0;
				colvarEmployeeID.AutoIncrement = false;
				colvarEmployeeID.IsNullable = true;
				colvarEmployeeID.IsPrimaryKey = false;
				colvarEmployeeID.IsForeignKey = true;
				colvarEmployeeID.IsReadOnly = false;
				colvarEmployeeID.DefaultSetting = @"";
				
					colvarEmployeeID.ForeignKeyTableName = "Employee";
				schema.Columns.Add(colvarEmployeeID);
				
				TableSchema.TableColumn colvarResumeX = new TableSchema.TableColumn(schema);
				colvarResumeX.ColumnName = "Resume";
				colvarResumeX.DataType = DbType.AnsiString;
				colvarResumeX.MaxLength = -1;
				colvarResumeX.AutoIncrement = false;
				colvarResumeX.IsNullable = true;
				colvarResumeX.IsPrimaryKey = false;
				colvarResumeX.IsForeignKey = false;
				colvarResumeX.IsReadOnly = false;
				colvarResumeX.DefaultSetting = @"";
				colvarResumeX.ForeignKeyTableName = "";
				schema.Columns.Add(colvarResumeX);
				
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
				DataService.Providers["AdventureWorks"].AddSchema("JobCandidate",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("JobCandidateID")]
		[Bindable(true)]
		public int JobCandidateID 
		{
			get { return GetColumnValue<int>(Columns.JobCandidateID); }
			set { SetColumnValue(Columns.JobCandidateID, value); }
		}
		  
		[XmlAttribute("EmployeeID")]
		[Bindable(true)]
		public int? EmployeeID 
		{
			get { return GetColumnValue<int?>(Columns.EmployeeID); }
			set { SetColumnValue(Columns.EmployeeID, value); }
		}
		  
		[XmlAttribute("ResumeX")]
		[Bindable(true)]
		public string ResumeX 
		{
			get { return GetColumnValue<string>(Columns.ResumeX); }
			set { SetColumnValue(Columns.ResumeX, value); }
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
		/// Returns a Employee ActiveRecord object related to this JobCandidate
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
		public static void Insert(int? varEmployeeID,string varResumeX,DateTime varModifiedDate)
		{
			JobCandidate item = new JobCandidate();
			
			item.EmployeeID = varEmployeeID;
			
			item.ResumeX = varResumeX;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varJobCandidateID,int? varEmployeeID,string varResumeX,DateTime varModifiedDate)
		{
			JobCandidate item = new JobCandidate();
			
				item.JobCandidateID = varJobCandidateID;
			
				item.EmployeeID = varEmployeeID;
			
				item.ResumeX = varResumeX;
			
				item.ModifiedDate = varModifiedDate;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn JobCandidateIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn EmployeeIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ResumeXColumn
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
			 public static string JobCandidateID = @"JobCandidateID";
			 public static string EmployeeID = @"EmployeeID";
			 public static string ResumeX = @"Resume";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
