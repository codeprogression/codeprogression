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
	/// Strongly-typed collection for the BillOfMaterial class.
	/// </summary>
    [Serializable]
	public partial class BillOfMaterialCollection : ActiveList<BillOfMaterial, BillOfMaterialCollection>
	{	   
		public BillOfMaterialCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>BillOfMaterialCollection</returns>
		public BillOfMaterialCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                BillOfMaterial o = this[i];
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
	/// This is an ActiveRecord class which wraps the BillOfMaterials table.
	/// </summary>
	[Serializable]
	public partial class BillOfMaterial : ActiveRecord<BillOfMaterial>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public BillOfMaterial()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public BillOfMaterial(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public BillOfMaterial(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public BillOfMaterial(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("BillOfMaterials", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Production";
				//columns
				
				TableSchema.TableColumn colvarBillOfMaterialsID = new TableSchema.TableColumn(schema);
				colvarBillOfMaterialsID.ColumnName = "BillOfMaterialsID";
				colvarBillOfMaterialsID.DataType = DbType.Int32;
				colvarBillOfMaterialsID.MaxLength = 0;
				colvarBillOfMaterialsID.AutoIncrement = true;
				colvarBillOfMaterialsID.IsNullable = false;
				colvarBillOfMaterialsID.IsPrimaryKey = true;
				colvarBillOfMaterialsID.IsForeignKey = false;
				colvarBillOfMaterialsID.IsReadOnly = false;
				colvarBillOfMaterialsID.DefaultSetting = @"";
				colvarBillOfMaterialsID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBillOfMaterialsID);
				
				TableSchema.TableColumn colvarProductAssemblyID = new TableSchema.TableColumn(schema);
				colvarProductAssemblyID.ColumnName = "ProductAssemblyID";
				colvarProductAssemblyID.DataType = DbType.Int32;
				colvarProductAssemblyID.MaxLength = 0;
				colvarProductAssemblyID.AutoIncrement = false;
				colvarProductAssemblyID.IsNullable = true;
				colvarProductAssemblyID.IsPrimaryKey = false;
				colvarProductAssemblyID.IsForeignKey = true;
				colvarProductAssemblyID.IsReadOnly = false;
				colvarProductAssemblyID.DefaultSetting = @"";
				
					colvarProductAssemblyID.ForeignKeyTableName = "Product";
				schema.Columns.Add(colvarProductAssemblyID);
				
				TableSchema.TableColumn colvarComponentID = new TableSchema.TableColumn(schema);
				colvarComponentID.ColumnName = "ComponentID";
				colvarComponentID.DataType = DbType.Int32;
				colvarComponentID.MaxLength = 0;
				colvarComponentID.AutoIncrement = false;
				colvarComponentID.IsNullable = false;
				colvarComponentID.IsPrimaryKey = false;
				colvarComponentID.IsForeignKey = true;
				colvarComponentID.IsReadOnly = false;
				colvarComponentID.DefaultSetting = @"";
				
					colvarComponentID.ForeignKeyTableName = "Product";
				schema.Columns.Add(colvarComponentID);
				
				TableSchema.TableColumn colvarStartDate = new TableSchema.TableColumn(schema);
				colvarStartDate.ColumnName = "StartDate";
				colvarStartDate.DataType = DbType.DateTime;
				colvarStartDate.MaxLength = 0;
				colvarStartDate.AutoIncrement = false;
				colvarStartDate.IsNullable = false;
				colvarStartDate.IsPrimaryKey = false;
				colvarStartDate.IsForeignKey = false;
				colvarStartDate.IsReadOnly = false;
				
						colvarStartDate.DefaultSetting = @"(getdate())";
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
				
				TableSchema.TableColumn colvarUnitMeasureCode = new TableSchema.TableColumn(schema);
				colvarUnitMeasureCode.ColumnName = "UnitMeasureCode";
				colvarUnitMeasureCode.DataType = DbType.String;
				colvarUnitMeasureCode.MaxLength = 3;
				colvarUnitMeasureCode.AutoIncrement = false;
				colvarUnitMeasureCode.IsNullable = false;
				colvarUnitMeasureCode.IsPrimaryKey = false;
				colvarUnitMeasureCode.IsForeignKey = true;
				colvarUnitMeasureCode.IsReadOnly = false;
				colvarUnitMeasureCode.DefaultSetting = @"";
				
					colvarUnitMeasureCode.ForeignKeyTableName = "UnitMeasure";
				schema.Columns.Add(colvarUnitMeasureCode);
				
				TableSchema.TableColumn colvarBOMLevel = new TableSchema.TableColumn(schema);
				colvarBOMLevel.ColumnName = "BOMLevel";
				colvarBOMLevel.DataType = DbType.Int16;
				colvarBOMLevel.MaxLength = 0;
				colvarBOMLevel.AutoIncrement = false;
				colvarBOMLevel.IsNullable = false;
				colvarBOMLevel.IsPrimaryKey = false;
				colvarBOMLevel.IsForeignKey = false;
				colvarBOMLevel.IsReadOnly = false;
				colvarBOMLevel.DefaultSetting = @"";
				colvarBOMLevel.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBOMLevel);
				
				TableSchema.TableColumn colvarPerAssemblyQty = new TableSchema.TableColumn(schema);
				colvarPerAssemblyQty.ColumnName = "PerAssemblyQty";
				colvarPerAssemblyQty.DataType = DbType.Decimal;
				colvarPerAssemblyQty.MaxLength = 0;
				colvarPerAssemblyQty.AutoIncrement = false;
				colvarPerAssemblyQty.IsNullable = false;
				colvarPerAssemblyQty.IsPrimaryKey = false;
				colvarPerAssemblyQty.IsForeignKey = false;
				colvarPerAssemblyQty.IsReadOnly = false;
				
						colvarPerAssemblyQty.DefaultSetting = @"((1.00))";
				colvarPerAssemblyQty.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPerAssemblyQty);
				
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
				DataService.Providers["AdventureWorks"].AddSchema("BillOfMaterials",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("BillOfMaterialsID")]
		[Bindable(true)]
		public int BillOfMaterialsID 
		{
			get { return GetColumnValue<int>(Columns.BillOfMaterialsID); }
			set { SetColumnValue(Columns.BillOfMaterialsID, value); }
		}
		  
		[XmlAttribute("ProductAssemblyID")]
		[Bindable(true)]
		public int? ProductAssemblyID 
		{
			get { return GetColumnValue<int?>(Columns.ProductAssemblyID); }
			set { SetColumnValue(Columns.ProductAssemblyID, value); }
		}
		  
		[XmlAttribute("ComponentID")]
		[Bindable(true)]
		public int ComponentID 
		{
			get { return GetColumnValue<int>(Columns.ComponentID); }
			set { SetColumnValue(Columns.ComponentID, value); }
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
		  
		[XmlAttribute("UnitMeasureCode")]
		[Bindable(true)]
		public string UnitMeasureCode 
		{
			get { return GetColumnValue<string>(Columns.UnitMeasureCode); }
			set { SetColumnValue(Columns.UnitMeasureCode, value); }
		}
		  
		[XmlAttribute("BOMLevel")]
		[Bindable(true)]
		public short BOMLevel 
		{
			get { return GetColumnValue<short>(Columns.BOMLevel); }
			set { SetColumnValue(Columns.BOMLevel, value); }
		}
		  
		[XmlAttribute("PerAssemblyQty")]
		[Bindable(true)]
		public decimal PerAssemblyQty 
		{
			get { return GetColumnValue<decimal>(Columns.PerAssemblyQty); }
			set { SetColumnValue(Columns.PerAssemblyQty, value); }
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
		/// Returns a Product ActiveRecord object related to this BillOfMaterial
		/// 
		/// </summary>
		public AdventureWorks.Product Product
		{
			get { return AdventureWorks.Product.FetchByID(this.ComponentID); }
			set { SetColumnValue("ComponentID", value.ProductID); }
		}
		
		
		/// <summary>
		/// Returns a Product ActiveRecord object related to this BillOfMaterial
		/// 
		/// </summary>
		public AdventureWorks.Product ProductToProductAssemblyID
		{
			get { return AdventureWorks.Product.FetchByID(this.ProductAssemblyID); }
			set { SetColumnValue("ProductAssemblyID", value.ProductID); }
		}
		
		
		/// <summary>
		/// Returns a UnitMeasure ActiveRecord object related to this BillOfMaterial
		/// 
		/// </summary>
		public AdventureWorks.UnitMeasure UnitMeasure
		{
			get { return AdventureWorks.UnitMeasure.FetchByID(this.UnitMeasureCode); }
			set { SetColumnValue("UnitMeasureCode", value.UnitMeasureCode); }
		}
		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varProductAssemblyID,int varComponentID,DateTime varStartDate,DateTime? varEndDate,string varUnitMeasureCode,short varBOMLevel,decimal varPerAssemblyQty,DateTime varModifiedDate)
		{
			BillOfMaterial item = new BillOfMaterial();
			
			item.ProductAssemblyID = varProductAssemblyID;
			
			item.ComponentID = varComponentID;
			
			item.StartDate = varStartDate;
			
			item.EndDate = varEndDate;
			
			item.UnitMeasureCode = varUnitMeasureCode;
			
			item.BOMLevel = varBOMLevel;
			
			item.PerAssemblyQty = varPerAssemblyQty;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varBillOfMaterialsID,int? varProductAssemblyID,int varComponentID,DateTime varStartDate,DateTime? varEndDate,string varUnitMeasureCode,short varBOMLevel,decimal varPerAssemblyQty,DateTime varModifiedDate)
		{
			BillOfMaterial item = new BillOfMaterial();
			
				item.BillOfMaterialsID = varBillOfMaterialsID;
			
				item.ProductAssemblyID = varProductAssemblyID;
			
				item.ComponentID = varComponentID;
			
				item.StartDate = varStartDate;
			
				item.EndDate = varEndDate;
			
				item.UnitMeasureCode = varUnitMeasureCode;
			
				item.BOMLevel = varBOMLevel;
			
				item.PerAssemblyQty = varPerAssemblyQty;
			
				item.ModifiedDate = varModifiedDate;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn BillOfMaterialsIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn ProductAssemblyIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ComponentIDColumn
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
        
        
        
        public static TableSchema.TableColumn UnitMeasureCodeColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn BOMLevelColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn PerAssemblyQtyColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedDateColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string BillOfMaterialsID = @"BillOfMaterialsID";
			 public static string ProductAssemblyID = @"ProductAssemblyID";
			 public static string ComponentID = @"ComponentID";
			 public static string StartDate = @"StartDate";
			 public static string EndDate = @"EndDate";
			 public static string UnitMeasureCode = @"UnitMeasureCode";
			 public static string BOMLevel = @"BOMLevel";
			 public static string PerAssemblyQty = @"PerAssemblyQty";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
