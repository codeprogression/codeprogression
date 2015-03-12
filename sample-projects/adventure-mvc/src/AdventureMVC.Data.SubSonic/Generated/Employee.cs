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
	/// Strongly-typed collection for the Employee class.
	/// </summary>
    [Serializable]
	public partial class EmployeeCollection : ActiveList<Employee, EmployeeCollection>
	{	   
		public EmployeeCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>EmployeeCollection</returns>
		public EmployeeCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Employee o = this[i];
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
	/// This is an ActiveRecord class which wraps the Employee table.
	/// </summary>
	[Serializable]
	public partial class Employee : ActiveRecord<Employee>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Employee()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Employee(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Employee(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Employee(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Employee", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"HumanResources";
				//columns
				
				TableSchema.TableColumn colvarEmployeeID = new TableSchema.TableColumn(schema);
				colvarEmployeeID.ColumnName = "EmployeeID";
				colvarEmployeeID.DataType = DbType.Int32;
				colvarEmployeeID.MaxLength = 0;
				colvarEmployeeID.AutoIncrement = true;
				colvarEmployeeID.IsNullable = false;
				colvarEmployeeID.IsPrimaryKey = true;
				colvarEmployeeID.IsForeignKey = false;
				colvarEmployeeID.IsReadOnly = false;
				colvarEmployeeID.DefaultSetting = @"";
				colvarEmployeeID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEmployeeID);
				
				TableSchema.TableColumn colvarNationalIDNumber = new TableSchema.TableColumn(schema);
				colvarNationalIDNumber.ColumnName = "NationalIDNumber";
				colvarNationalIDNumber.DataType = DbType.String;
				colvarNationalIDNumber.MaxLength = 15;
				colvarNationalIDNumber.AutoIncrement = false;
				colvarNationalIDNumber.IsNullable = false;
				colvarNationalIDNumber.IsPrimaryKey = false;
				colvarNationalIDNumber.IsForeignKey = false;
				colvarNationalIDNumber.IsReadOnly = false;
				colvarNationalIDNumber.DefaultSetting = @"";
				colvarNationalIDNumber.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNationalIDNumber);
				
				TableSchema.TableColumn colvarContactID = new TableSchema.TableColumn(schema);
				colvarContactID.ColumnName = "ContactID";
				colvarContactID.DataType = DbType.Int32;
				colvarContactID.MaxLength = 0;
				colvarContactID.AutoIncrement = false;
				colvarContactID.IsNullable = false;
				colvarContactID.IsPrimaryKey = false;
				colvarContactID.IsForeignKey = true;
				colvarContactID.IsReadOnly = false;
				colvarContactID.DefaultSetting = @"";
				
					colvarContactID.ForeignKeyTableName = "Contact";
				schema.Columns.Add(colvarContactID);
				
				TableSchema.TableColumn colvarLoginID = new TableSchema.TableColumn(schema);
				colvarLoginID.ColumnName = "LoginID";
				colvarLoginID.DataType = DbType.String;
				colvarLoginID.MaxLength = 256;
				colvarLoginID.AutoIncrement = false;
				colvarLoginID.IsNullable = false;
				colvarLoginID.IsPrimaryKey = false;
				colvarLoginID.IsForeignKey = false;
				colvarLoginID.IsReadOnly = false;
				colvarLoginID.DefaultSetting = @"";
				colvarLoginID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLoginID);
				
				TableSchema.TableColumn colvarManagerID = new TableSchema.TableColumn(schema);
				colvarManagerID.ColumnName = "ManagerID";
				colvarManagerID.DataType = DbType.Int32;
				colvarManagerID.MaxLength = 0;
				colvarManagerID.AutoIncrement = false;
				colvarManagerID.IsNullable = true;
				colvarManagerID.IsPrimaryKey = false;
				colvarManagerID.IsForeignKey = true;
				colvarManagerID.IsReadOnly = false;
				colvarManagerID.DefaultSetting = @"";
				
					colvarManagerID.ForeignKeyTableName = "Employee";
				schema.Columns.Add(colvarManagerID);
				
				TableSchema.TableColumn colvarTitle = new TableSchema.TableColumn(schema);
				colvarTitle.ColumnName = "Title";
				colvarTitle.DataType = DbType.String;
				colvarTitle.MaxLength = 50;
				colvarTitle.AutoIncrement = false;
				colvarTitle.IsNullable = false;
				colvarTitle.IsPrimaryKey = false;
				colvarTitle.IsForeignKey = false;
				colvarTitle.IsReadOnly = false;
				colvarTitle.DefaultSetting = @"";
				colvarTitle.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTitle);
				
				TableSchema.TableColumn colvarBirthDate = new TableSchema.TableColumn(schema);
				colvarBirthDate.ColumnName = "BirthDate";
				colvarBirthDate.DataType = DbType.DateTime;
				colvarBirthDate.MaxLength = 0;
				colvarBirthDate.AutoIncrement = false;
				colvarBirthDate.IsNullable = false;
				colvarBirthDate.IsPrimaryKey = false;
				colvarBirthDate.IsForeignKey = false;
				colvarBirthDate.IsReadOnly = false;
				colvarBirthDate.DefaultSetting = @"";
				colvarBirthDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBirthDate);
				
				TableSchema.TableColumn colvarMaritalStatus = new TableSchema.TableColumn(schema);
				colvarMaritalStatus.ColumnName = "MaritalStatus";
				colvarMaritalStatus.DataType = DbType.String;
				colvarMaritalStatus.MaxLength = 1;
				colvarMaritalStatus.AutoIncrement = false;
				colvarMaritalStatus.IsNullable = false;
				colvarMaritalStatus.IsPrimaryKey = false;
				colvarMaritalStatus.IsForeignKey = false;
				colvarMaritalStatus.IsReadOnly = false;
				colvarMaritalStatus.DefaultSetting = @"";
				colvarMaritalStatus.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMaritalStatus);
				
				TableSchema.TableColumn colvarGender = new TableSchema.TableColumn(schema);
				colvarGender.ColumnName = "Gender";
				colvarGender.DataType = DbType.String;
				colvarGender.MaxLength = 1;
				colvarGender.AutoIncrement = false;
				colvarGender.IsNullable = false;
				colvarGender.IsPrimaryKey = false;
				colvarGender.IsForeignKey = false;
				colvarGender.IsReadOnly = false;
				colvarGender.DefaultSetting = @"";
				colvarGender.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGender);
				
				TableSchema.TableColumn colvarHireDate = new TableSchema.TableColumn(schema);
				colvarHireDate.ColumnName = "HireDate";
				colvarHireDate.DataType = DbType.DateTime;
				colvarHireDate.MaxLength = 0;
				colvarHireDate.AutoIncrement = false;
				colvarHireDate.IsNullable = false;
				colvarHireDate.IsPrimaryKey = false;
				colvarHireDate.IsForeignKey = false;
				colvarHireDate.IsReadOnly = false;
				colvarHireDate.DefaultSetting = @"";
				colvarHireDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHireDate);
				
				TableSchema.TableColumn colvarSalariedFlag = new TableSchema.TableColumn(schema);
				colvarSalariedFlag.ColumnName = "SalariedFlag";
				colvarSalariedFlag.DataType = DbType.Boolean;
				colvarSalariedFlag.MaxLength = 0;
				colvarSalariedFlag.AutoIncrement = false;
				colvarSalariedFlag.IsNullable = false;
				colvarSalariedFlag.IsPrimaryKey = false;
				colvarSalariedFlag.IsForeignKey = false;
				colvarSalariedFlag.IsReadOnly = false;
				
						colvarSalariedFlag.DefaultSetting = @"((1))";
				colvarSalariedFlag.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSalariedFlag);
				
				TableSchema.TableColumn colvarVacationHours = new TableSchema.TableColumn(schema);
				colvarVacationHours.ColumnName = "VacationHours";
				colvarVacationHours.DataType = DbType.Int16;
				colvarVacationHours.MaxLength = 0;
				colvarVacationHours.AutoIncrement = false;
				colvarVacationHours.IsNullable = false;
				colvarVacationHours.IsPrimaryKey = false;
				colvarVacationHours.IsForeignKey = false;
				colvarVacationHours.IsReadOnly = false;
				
						colvarVacationHours.DefaultSetting = @"((0))";
				colvarVacationHours.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVacationHours);
				
				TableSchema.TableColumn colvarSickLeaveHours = new TableSchema.TableColumn(schema);
				colvarSickLeaveHours.ColumnName = "SickLeaveHours";
				colvarSickLeaveHours.DataType = DbType.Int16;
				colvarSickLeaveHours.MaxLength = 0;
				colvarSickLeaveHours.AutoIncrement = false;
				colvarSickLeaveHours.IsNullable = false;
				colvarSickLeaveHours.IsPrimaryKey = false;
				colvarSickLeaveHours.IsForeignKey = false;
				colvarSickLeaveHours.IsReadOnly = false;
				
						colvarSickLeaveHours.DefaultSetting = @"((0))";
				colvarSickLeaveHours.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSickLeaveHours);
				
				TableSchema.TableColumn colvarCurrentFlag = new TableSchema.TableColumn(schema);
				colvarCurrentFlag.ColumnName = "CurrentFlag";
				colvarCurrentFlag.DataType = DbType.Boolean;
				colvarCurrentFlag.MaxLength = 0;
				colvarCurrentFlag.AutoIncrement = false;
				colvarCurrentFlag.IsNullable = false;
				colvarCurrentFlag.IsPrimaryKey = false;
				colvarCurrentFlag.IsForeignKey = false;
				colvarCurrentFlag.IsReadOnly = false;
				
						colvarCurrentFlag.DefaultSetting = @"((1))";
				colvarCurrentFlag.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCurrentFlag);
				
				TableSchema.TableColumn colvarRowguid = new TableSchema.TableColumn(schema);
				colvarRowguid.ColumnName = "rowguid";
				colvarRowguid.DataType = DbType.Guid;
				colvarRowguid.MaxLength = 0;
				colvarRowguid.AutoIncrement = false;
				colvarRowguid.IsNullable = false;
				colvarRowguid.IsPrimaryKey = false;
				colvarRowguid.IsForeignKey = false;
				colvarRowguid.IsReadOnly = false;
				
						colvarRowguid.DefaultSetting = @"(newid())";
				colvarRowguid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRowguid);
				
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
				DataService.Providers["AdventureWorks"].AddSchema("Employee",schema);
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
		  
		[XmlAttribute("NationalIDNumber")]
		[Bindable(true)]
		public string NationalIDNumber 
		{
			get { return GetColumnValue<string>(Columns.NationalIDNumber); }
			set { SetColumnValue(Columns.NationalIDNumber, value); }
		}
		  
		[XmlAttribute("ContactID")]
		[Bindable(true)]
		public int ContactID 
		{
			get { return GetColumnValue<int>(Columns.ContactID); }
			set { SetColumnValue(Columns.ContactID, value); }
		}
		  
		[XmlAttribute("LoginID")]
		[Bindable(true)]
		public string LoginID 
		{
			get { return GetColumnValue<string>(Columns.LoginID); }
			set { SetColumnValue(Columns.LoginID, value); }
		}
		  
		[XmlAttribute("ManagerID")]
		[Bindable(true)]
		public int? ManagerID 
		{
			get { return GetColumnValue<int?>(Columns.ManagerID); }
			set { SetColumnValue(Columns.ManagerID, value); }
		}
		  
		[XmlAttribute("Title")]
		[Bindable(true)]
		public string Title 
		{
			get { return GetColumnValue<string>(Columns.Title); }
			set { SetColumnValue(Columns.Title, value); }
		}
		  
		[XmlAttribute("BirthDate")]
		[Bindable(true)]
		public DateTime BirthDate 
		{
			get { return GetColumnValue<DateTime>(Columns.BirthDate); }
			set { SetColumnValue(Columns.BirthDate, value); }
		}
		  
		[XmlAttribute("MaritalStatus")]
		[Bindable(true)]
		public string MaritalStatus 
		{
			get { return GetColumnValue<string>(Columns.MaritalStatus); }
			set { SetColumnValue(Columns.MaritalStatus, value); }
		}
		  
		[XmlAttribute("Gender")]
		[Bindable(true)]
		public string Gender 
		{
			get { return GetColumnValue<string>(Columns.Gender); }
			set { SetColumnValue(Columns.Gender, value); }
		}
		  
		[XmlAttribute("HireDate")]
		[Bindable(true)]
		public DateTime HireDate 
		{
			get { return GetColumnValue<DateTime>(Columns.HireDate); }
			set { SetColumnValue(Columns.HireDate, value); }
		}
		  
		[XmlAttribute("SalariedFlag")]
		[Bindable(true)]
		public bool SalariedFlag 
		{
			get { return GetColumnValue<bool>(Columns.SalariedFlag); }
			set { SetColumnValue(Columns.SalariedFlag, value); }
		}
		  
		[XmlAttribute("VacationHours")]
		[Bindable(true)]
		public short VacationHours 
		{
			get { return GetColumnValue<short>(Columns.VacationHours); }
			set { SetColumnValue(Columns.VacationHours, value); }
		}
		  
		[XmlAttribute("SickLeaveHours")]
		[Bindable(true)]
		public short SickLeaveHours 
		{
			get { return GetColumnValue<short>(Columns.SickLeaveHours); }
			set { SetColumnValue(Columns.SickLeaveHours, value); }
		}
		  
		[XmlAttribute("CurrentFlag")]
		[Bindable(true)]
		public bool CurrentFlag 
		{
			get { return GetColumnValue<bool>(Columns.CurrentFlag); }
			set { SetColumnValue(Columns.CurrentFlag, value); }
		}
		  
		[XmlAttribute("Rowguid")]
		[Bindable(true)]
		public Guid Rowguid 
		{
			get { return GetColumnValue<Guid>(Columns.Rowguid); }
			set { SetColumnValue(Columns.Rowguid, value); }
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
        
		
		public AdventureWorks.EmployeeCollection ChildEmployeeRecords()
		{
			return new AdventureWorks.EmployeeCollection().Where(Employee.Columns.ManagerID, EmployeeID).Load();
		}
		public AdventureWorks.EmployeeAddressCollection EmployeeAddressRecords()
		{
			return new AdventureWorks.EmployeeAddressCollection().Where(EmployeeAddress.Columns.EmployeeID, EmployeeID).Load();
		}
		public AdventureWorks.EmployeeDepartmentHistoryCollection EmployeeDepartmentHistoryRecords()
		{
			return new AdventureWorks.EmployeeDepartmentHistoryCollection().Where(EmployeeDepartmentHistory.Columns.EmployeeID, EmployeeID).Load();
		}
		public AdventureWorks.EmployeePayHistoryCollection EmployeePayHistoryRecords()
		{
			return new AdventureWorks.EmployeePayHistoryCollection().Where(EmployeePayHistory.Columns.EmployeeID, EmployeeID).Load();
		}
		public AdventureWorks.JobCandidateCollection JobCandidateRecords()
		{
			return new AdventureWorks.JobCandidateCollection().Where(JobCandidate.Columns.EmployeeID, EmployeeID).Load();
		}
		public AdventureWorks.PurchaseOrderHeaderCollection PurchaseOrderHeaderRecords()
		{
			return new AdventureWorks.PurchaseOrderHeaderCollection().Where(PurchaseOrderHeader.Columns.EmployeeID, EmployeeID).Load();
		}
		public AdventureWorks.SalesPersonCollection SalesPersonRecords()
		{
			return new AdventureWorks.SalesPersonCollection().Where(SalesPerson.Columns.SalesPersonID, EmployeeID).Load();
		}
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Contact ActiveRecord object related to this Employee
		/// 
		/// </summary>
		public AdventureWorks.Contact Contact
		{
			get { return AdventureWorks.Contact.FetchByID(this.ContactID); }
			set { SetColumnValue("ContactID", value.ContactID); }
		}
		
		
		/// <summary>
		/// Returns a Employee ActiveRecord object related to this Employee
		/// 
		/// </summary>
		public AdventureWorks.Employee ParentEmployee
		{
			get { return AdventureWorks.Employee.FetchByID(this.ManagerID); }
			set { SetColumnValue("ManagerID", value.EmployeeID); }
		}
		
		
		#endregion
		
		
		
		#region Many To Many Helpers
		
		 
		public AdventureWorks.AddressCollection GetAddressCollection() { return Employee.GetAddressCollection(this.EmployeeID); }
		public static AdventureWorks.AddressCollection GetAddressCollection(int varEmployeeID)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [Person].[Address] INNER JOIN [EmployeeAddress] ON [Address].[AddressID] = [EmployeeAddress].[AddressID] WHERE [EmployeeAddress].[EmployeeID] = @EmployeeID", Employee.Schema.Provider.Name);
			cmd.AddParameter("@EmployeeID", varEmployeeID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			AddressCollection coll = new AddressCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveAddressMap(int varEmployeeID, AddressCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [EmployeeAddress] WHERE [EmployeeAddress].[EmployeeID] = @EmployeeID", Employee.Schema.Provider.Name);
			cmdDel.AddParameter("@EmployeeID", varEmployeeID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Address item in items)
			{
				EmployeeAddress varEmployeeAddress = new EmployeeAddress();
				varEmployeeAddress.SetColumnValue("EmployeeID", varEmployeeID);
				varEmployeeAddress.SetColumnValue("AddressID", item.GetPrimaryKeyValue());
				varEmployeeAddress.Save();
			}
		}
		public static void SaveAddressMap(int varEmployeeID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [EmployeeAddress] WHERE [EmployeeAddress].[EmployeeID] = @EmployeeID", Employee.Schema.Provider.Name);
			cmdDel.AddParameter("@EmployeeID", varEmployeeID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					EmployeeAddress varEmployeeAddress = new EmployeeAddress();
					varEmployeeAddress.SetColumnValue("EmployeeID", varEmployeeID);
					varEmployeeAddress.SetColumnValue("AddressID", l.Value);
					varEmployeeAddress.Save();
				}
			}
		}
		public static void SaveAddressMap(int varEmployeeID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [EmployeeAddress] WHERE [EmployeeAddress].[EmployeeID] = @EmployeeID", Employee.Schema.Provider.Name);
			cmdDel.AddParameter("@EmployeeID", varEmployeeID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				EmployeeAddress varEmployeeAddress = new EmployeeAddress();
				varEmployeeAddress.SetColumnValue("EmployeeID", varEmployeeID);
				varEmployeeAddress.SetColumnValue("AddressID", item);
				varEmployeeAddress.Save();
			}
		}
		
		public static void DeleteAddressMap(int varEmployeeID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [EmployeeAddress] WHERE [EmployeeAddress].[EmployeeID] = @EmployeeID", Employee.Schema.Provider.Name);
			cmdDel.AddParameter("@EmployeeID", varEmployeeID, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		 
		public AdventureWorks.DepartmentCollection GetDepartmentCollection() { return Employee.GetDepartmentCollection(this.EmployeeID); }
		public static AdventureWorks.DepartmentCollection GetDepartmentCollection(int varEmployeeID)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [HumanResources].[Department] INNER JOIN [EmployeeDepartmentHistory] ON [Department].[DepartmentID] = [EmployeeDepartmentHistory].[DepartmentID] WHERE [EmployeeDepartmentHistory].[EmployeeID] = @EmployeeID", Employee.Schema.Provider.Name);
			cmd.AddParameter("@EmployeeID", varEmployeeID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			DepartmentCollection coll = new DepartmentCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveDepartmentMap(int varEmployeeID, DepartmentCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [EmployeeDepartmentHistory] WHERE [EmployeeDepartmentHistory].[EmployeeID] = @EmployeeID", Employee.Schema.Provider.Name);
			cmdDel.AddParameter("@EmployeeID", varEmployeeID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Department item in items)
			{
				EmployeeDepartmentHistory varEmployeeDepartmentHistory = new EmployeeDepartmentHistory();
				varEmployeeDepartmentHistory.SetColumnValue("EmployeeID", varEmployeeID);
				varEmployeeDepartmentHistory.SetColumnValue("DepartmentID", item.GetPrimaryKeyValue());
				varEmployeeDepartmentHistory.Save();
			}
		}
		public static void SaveDepartmentMap(int varEmployeeID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [EmployeeDepartmentHistory] WHERE [EmployeeDepartmentHistory].[EmployeeID] = @EmployeeID", Employee.Schema.Provider.Name);
			cmdDel.AddParameter("@EmployeeID", varEmployeeID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					EmployeeDepartmentHistory varEmployeeDepartmentHistory = new EmployeeDepartmentHistory();
					varEmployeeDepartmentHistory.SetColumnValue("EmployeeID", varEmployeeID);
					varEmployeeDepartmentHistory.SetColumnValue("DepartmentID", l.Value);
					varEmployeeDepartmentHistory.Save();
				}
			}
		}
		public static void SaveDepartmentMap(int varEmployeeID , short[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [EmployeeDepartmentHistory] WHERE [EmployeeDepartmentHistory].[EmployeeID] = @EmployeeID", Employee.Schema.Provider.Name);
			cmdDel.AddParameter("@EmployeeID", varEmployeeID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (short item in itemList) 
			{
				EmployeeDepartmentHistory varEmployeeDepartmentHistory = new EmployeeDepartmentHistory();
				varEmployeeDepartmentHistory.SetColumnValue("EmployeeID", varEmployeeID);
				varEmployeeDepartmentHistory.SetColumnValue("DepartmentID", item);
				varEmployeeDepartmentHistory.Save();
			}
		}
		
		public static void DeleteDepartmentMap(int varEmployeeID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [EmployeeDepartmentHistory] WHERE [EmployeeDepartmentHistory].[EmployeeID] = @EmployeeID", Employee.Schema.Provider.Name);
			cmdDel.AddParameter("@EmployeeID", varEmployeeID, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		 
		public AdventureWorks.ShiftCollection GetShiftCollection() { return Employee.GetShiftCollection(this.EmployeeID); }
		public static AdventureWorks.ShiftCollection GetShiftCollection(int varEmployeeID)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [HumanResources].[Shift] INNER JOIN [EmployeeDepartmentHistory] ON [Shift].[ShiftID] = [EmployeeDepartmentHistory].[ShiftID] WHERE [EmployeeDepartmentHistory].[EmployeeID] = @EmployeeID", Employee.Schema.Provider.Name);
			cmd.AddParameter("@EmployeeID", varEmployeeID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			ShiftCollection coll = new ShiftCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveShiftMap(int varEmployeeID, ShiftCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [EmployeeDepartmentHistory] WHERE [EmployeeDepartmentHistory].[EmployeeID] = @EmployeeID", Employee.Schema.Provider.Name);
			cmdDel.AddParameter("@EmployeeID", varEmployeeID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Shift item in items)
			{
				EmployeeDepartmentHistory varEmployeeDepartmentHistory = new EmployeeDepartmentHistory();
				varEmployeeDepartmentHistory.SetColumnValue("EmployeeID", varEmployeeID);
				varEmployeeDepartmentHistory.SetColumnValue("ShiftID", item.GetPrimaryKeyValue());
				varEmployeeDepartmentHistory.Save();
			}
		}
		public static void SaveShiftMap(int varEmployeeID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [EmployeeDepartmentHistory] WHERE [EmployeeDepartmentHistory].[EmployeeID] = @EmployeeID", Employee.Schema.Provider.Name);
			cmdDel.AddParameter("@EmployeeID", varEmployeeID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					EmployeeDepartmentHistory varEmployeeDepartmentHistory = new EmployeeDepartmentHistory();
					varEmployeeDepartmentHistory.SetColumnValue("EmployeeID", varEmployeeID);
					varEmployeeDepartmentHistory.SetColumnValue("ShiftID", l.Value);
					varEmployeeDepartmentHistory.Save();
				}
			}
		}
		public static void SaveShiftMap(int varEmployeeID , byte[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [EmployeeDepartmentHistory] WHERE [EmployeeDepartmentHistory].[EmployeeID] = @EmployeeID", Employee.Schema.Provider.Name);
			cmdDel.AddParameter("@EmployeeID", varEmployeeID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (byte item in itemList) 
			{
				EmployeeDepartmentHistory varEmployeeDepartmentHistory = new EmployeeDepartmentHistory();
				varEmployeeDepartmentHistory.SetColumnValue("EmployeeID", varEmployeeID);
				varEmployeeDepartmentHistory.SetColumnValue("ShiftID", item);
				varEmployeeDepartmentHistory.Save();
			}
		}
		
		public static void DeleteShiftMap(int varEmployeeID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [EmployeeDepartmentHistory] WHERE [EmployeeDepartmentHistory].[EmployeeID] = @EmployeeID", Employee.Schema.Provider.Name);
			cmdDel.AddParameter("@EmployeeID", varEmployeeID, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		#endregion
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNationalIDNumber,int varContactID,string varLoginID,int? varManagerID,string varTitle,DateTime varBirthDate,string varMaritalStatus,string varGender,DateTime varHireDate,bool varSalariedFlag,short varVacationHours,short varSickLeaveHours,bool varCurrentFlag,Guid varRowguid,DateTime varModifiedDate)
		{
			Employee item = new Employee();
			
			item.NationalIDNumber = varNationalIDNumber;
			
			item.ContactID = varContactID;
			
			item.LoginID = varLoginID;
			
			item.ManagerID = varManagerID;
			
			item.Title = varTitle;
			
			item.BirthDate = varBirthDate;
			
			item.MaritalStatus = varMaritalStatus;
			
			item.Gender = varGender;
			
			item.HireDate = varHireDate;
			
			item.SalariedFlag = varSalariedFlag;
			
			item.VacationHours = varVacationHours;
			
			item.SickLeaveHours = varSickLeaveHours;
			
			item.CurrentFlag = varCurrentFlag;
			
			item.Rowguid = varRowguid;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varEmployeeID,string varNationalIDNumber,int varContactID,string varLoginID,int? varManagerID,string varTitle,DateTime varBirthDate,string varMaritalStatus,string varGender,DateTime varHireDate,bool varSalariedFlag,short varVacationHours,short varSickLeaveHours,bool varCurrentFlag,Guid varRowguid,DateTime varModifiedDate)
		{
			Employee item = new Employee();
			
				item.EmployeeID = varEmployeeID;
			
				item.NationalIDNumber = varNationalIDNumber;
			
				item.ContactID = varContactID;
			
				item.LoginID = varLoginID;
			
				item.ManagerID = varManagerID;
			
				item.Title = varTitle;
			
				item.BirthDate = varBirthDate;
			
				item.MaritalStatus = varMaritalStatus;
			
				item.Gender = varGender;
			
				item.HireDate = varHireDate;
			
				item.SalariedFlag = varSalariedFlag;
			
				item.VacationHours = varVacationHours;
			
				item.SickLeaveHours = varSickLeaveHours;
			
				item.CurrentFlag = varCurrentFlag;
			
				item.Rowguid = varRowguid;
			
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
        
        
        
        public static TableSchema.TableColumn NationalIDNumberColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ContactIDColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn LoginIDColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn ManagerIDColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn TitleColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn BirthDateColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn MaritalStatusColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn GenderColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn HireDateColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn SalariedFlagColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn VacationHoursColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn SickLeaveHoursColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn CurrentFlagColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn RowguidColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedDateColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string EmployeeID = @"EmployeeID";
			 public static string NationalIDNumber = @"NationalIDNumber";
			 public static string ContactID = @"ContactID";
			 public static string LoginID = @"LoginID";
			 public static string ManagerID = @"ManagerID";
			 public static string Title = @"Title";
			 public static string BirthDate = @"BirthDate";
			 public static string MaritalStatus = @"MaritalStatus";
			 public static string Gender = @"Gender";
			 public static string HireDate = @"HireDate";
			 public static string SalariedFlag = @"SalariedFlag";
			 public static string VacationHours = @"VacationHours";
			 public static string SickLeaveHours = @"SickLeaveHours";
			 public static string CurrentFlag = @"CurrentFlag";
			 public static string Rowguid = @"rowguid";
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
