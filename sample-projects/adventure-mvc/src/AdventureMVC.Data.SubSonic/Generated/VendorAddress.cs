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
	/// Strongly-typed collection for the VendorAddress class.
	/// </summary>
    [Serializable]
	public partial class VendorAddressCollection : ActiveList<VendorAddress, VendorAddressCollection>
	{	   
		public VendorAddressCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>VendorAddressCollection</returns>
		public VendorAddressCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                VendorAddress o = this[i];
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
	/// This is an ActiveRecord class which wraps the VendorAddress table.
	/// </summary>
	[Serializable]
	public partial class VendorAddress : ActiveRecord<VendorAddress>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public VendorAddress()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public VendorAddress(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public VendorAddress(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public VendorAddress(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("VendorAddress", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Purchasing";
				//columns
				
				TableSchema.TableColumn colvarVendorID = new TableSchema.TableColumn(schema);
				colvarVendorID.ColumnName = "VendorID";
				colvarVendorID.DataType = DbType.Int32;
				colvarVendorID.MaxLength = 0;
				colvarVendorID.AutoIncrement = false;
				colvarVendorID.IsNullable = false;
				colvarVendorID.IsPrimaryKey = true;
				colvarVendorID.IsForeignKey = true;
				colvarVendorID.IsReadOnly = false;
				colvarVendorID.DefaultSetting = @"";
				
					colvarVendorID.ForeignKeyTableName = "Vendor";
				schema.Columns.Add(colvarVendorID);
				
				TableSchema.TableColumn colvarAddressID = new TableSchema.TableColumn(schema);
				colvarAddressID.ColumnName = "AddressID";
				colvarAddressID.DataType = DbType.Int32;
				colvarAddressID.MaxLength = 0;
				colvarAddressID.AutoIncrement = false;
				colvarAddressID.IsNullable = false;
				colvarAddressID.IsPrimaryKey = true;
				colvarAddressID.IsForeignKey = true;
				colvarAddressID.IsReadOnly = false;
				colvarAddressID.DefaultSetting = @"";
				
					colvarAddressID.ForeignKeyTableName = "Address";
				schema.Columns.Add(colvarAddressID);
				
				TableSchema.TableColumn colvarAddressTypeID = new TableSchema.TableColumn(schema);
				colvarAddressTypeID.ColumnName = "AddressTypeID";
				colvarAddressTypeID.DataType = DbType.Int32;
				colvarAddressTypeID.MaxLength = 0;
				colvarAddressTypeID.AutoIncrement = false;
				colvarAddressTypeID.IsNullable = false;
				colvarAddressTypeID.IsPrimaryKey = false;
				colvarAddressTypeID.IsForeignKey = true;
				colvarAddressTypeID.IsReadOnly = false;
				colvarAddressTypeID.DefaultSetting = @"";
				
					colvarAddressTypeID.ForeignKeyTableName = "AddressType";
				schema.Columns.Add(colvarAddressTypeID);
				
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
				DataService.Providers["AdventureWorks"].AddSchema("VendorAddress",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("VendorID")]
		[Bindable(true)]
		public int VendorID 
		{
			get { return GetColumnValue<int>(Columns.VendorID); }
			set { SetColumnValue(Columns.VendorID, value); }
		}
		  
		[XmlAttribute("AddressID")]
		[Bindable(true)]
		public int AddressID 
		{
			get { return GetColumnValue<int>(Columns.AddressID); }
			set { SetColumnValue(Columns.AddressID, value); }
		}
		  
		[XmlAttribute("AddressTypeID")]
		[Bindable(true)]
		public int AddressTypeID 
		{
			get { return GetColumnValue<int>(Columns.AddressTypeID); }
			set { SetColumnValue(Columns.AddressTypeID, value); }
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
		/// Returns a Address ActiveRecord object related to this VendorAddress
		/// 
		/// </summary>
		public AdventureWorks.Address Address
		{
			get { return AdventureWorks.Address.FetchByID(this.AddressID); }
			set { SetColumnValue("AddressID", value.AddressID); }
		}
		
		
		/// <summary>
		/// Returns a AddressType ActiveRecord object related to this VendorAddress
		/// 
		/// </summary>
		public AdventureWorks.AddressType AddressType
		{
			get { return AdventureWorks.AddressType.FetchByID(this.AddressTypeID); }
			set { SetColumnValue("AddressTypeID", value.AddressTypeID); }
		}
		
		
		/// <summary>
		/// Returns a Vendor ActiveRecord object related to this VendorAddress
		/// 
		/// </summary>
		public AdventureWorks.Vendor Vendor
		{
			get { return AdventureWorks.Vendor.FetchByID(this.VendorID); }
			set { SetColumnValue("VendorID", value.VendorID); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varVendorID,int varAddressID,int varAddressTypeID,DateTime varModifiedDate)
		{
			VendorAddress item = new VendorAddress();
			
			item.VendorID = varVendorID;
			
			item.AddressID = varAddressID;
			
			item.AddressTypeID = varAddressTypeID;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varVendorID,int varAddressID,int varAddressTypeID,DateTime varModifiedDate)
		{
			VendorAddress item = new VendorAddress();
			
				item.VendorID = varVendorID;
			
				item.AddressID = varAddressID;
			
				item.AddressTypeID = varAddressTypeID;
			
				item.ModifiedDate = varModifiedDate;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn VendorIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn AddressIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn AddressTypeIDColumn
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
			 public static string VendorID = @"VendorID";
			 public static string AddressID = @"AddressID";
			 public static string AddressTypeID = @"AddressTypeID";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
