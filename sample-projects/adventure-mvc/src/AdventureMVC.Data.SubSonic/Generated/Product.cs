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
	/// Strongly-typed collection for the Product class.
	/// </summary>
    [Serializable]
	public partial class ProductCollection : ActiveList<Product, ProductCollection>
	{	   
		public ProductCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>ProductCollection</returns>
		public ProductCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                Product o = this[i];
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
	/// This is an ActiveRecord class which wraps the Product table.
	/// </summary>
	[Serializable]
	public partial class Product : ActiveRecord<Product>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public Product()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public Product(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public Product(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public Product(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Product", TableType.Table, DataService.GetInstance("AdventureWorks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Production";
				//columns
				
				TableSchema.TableColumn colvarProductID = new TableSchema.TableColumn(schema);
				colvarProductID.ColumnName = "ProductID";
				colvarProductID.DataType = DbType.Int32;
				colvarProductID.MaxLength = 0;
				colvarProductID.AutoIncrement = true;
				colvarProductID.IsNullable = false;
				colvarProductID.IsPrimaryKey = true;
				colvarProductID.IsForeignKey = false;
				colvarProductID.IsReadOnly = false;
				colvarProductID.DefaultSetting = @"";
				colvarProductID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProductID);
				
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
				
				TableSchema.TableColumn colvarProductNumber = new TableSchema.TableColumn(schema);
				colvarProductNumber.ColumnName = "ProductNumber";
				colvarProductNumber.DataType = DbType.String;
				colvarProductNumber.MaxLength = 25;
				colvarProductNumber.AutoIncrement = false;
				colvarProductNumber.IsNullable = false;
				colvarProductNumber.IsPrimaryKey = false;
				colvarProductNumber.IsForeignKey = false;
				colvarProductNumber.IsReadOnly = false;
				colvarProductNumber.DefaultSetting = @"";
				colvarProductNumber.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProductNumber);
				
				TableSchema.TableColumn colvarMakeFlag = new TableSchema.TableColumn(schema);
				colvarMakeFlag.ColumnName = "MakeFlag";
				colvarMakeFlag.DataType = DbType.Boolean;
				colvarMakeFlag.MaxLength = 0;
				colvarMakeFlag.AutoIncrement = false;
				colvarMakeFlag.IsNullable = false;
				colvarMakeFlag.IsPrimaryKey = false;
				colvarMakeFlag.IsForeignKey = false;
				colvarMakeFlag.IsReadOnly = false;
				
						colvarMakeFlag.DefaultSetting = @"((1))";
				colvarMakeFlag.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMakeFlag);
				
				TableSchema.TableColumn colvarFinishedGoodsFlag = new TableSchema.TableColumn(schema);
				colvarFinishedGoodsFlag.ColumnName = "FinishedGoodsFlag";
				colvarFinishedGoodsFlag.DataType = DbType.Boolean;
				colvarFinishedGoodsFlag.MaxLength = 0;
				colvarFinishedGoodsFlag.AutoIncrement = false;
				colvarFinishedGoodsFlag.IsNullable = false;
				colvarFinishedGoodsFlag.IsPrimaryKey = false;
				colvarFinishedGoodsFlag.IsForeignKey = false;
				colvarFinishedGoodsFlag.IsReadOnly = false;
				
						colvarFinishedGoodsFlag.DefaultSetting = @"((1))";
				colvarFinishedGoodsFlag.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFinishedGoodsFlag);
				
				TableSchema.TableColumn colvarColor = new TableSchema.TableColumn(schema);
				colvarColor.ColumnName = "Color";
				colvarColor.DataType = DbType.String;
				colvarColor.MaxLength = 15;
				colvarColor.AutoIncrement = false;
				colvarColor.IsNullable = true;
				colvarColor.IsPrimaryKey = false;
				colvarColor.IsForeignKey = false;
				colvarColor.IsReadOnly = false;
				colvarColor.DefaultSetting = @"";
				colvarColor.ForeignKeyTableName = "";
				schema.Columns.Add(colvarColor);
				
				TableSchema.TableColumn colvarSafetyStockLevel = new TableSchema.TableColumn(schema);
				colvarSafetyStockLevel.ColumnName = "SafetyStockLevel";
				colvarSafetyStockLevel.DataType = DbType.Int16;
				colvarSafetyStockLevel.MaxLength = 0;
				colvarSafetyStockLevel.AutoIncrement = false;
				colvarSafetyStockLevel.IsNullable = false;
				colvarSafetyStockLevel.IsPrimaryKey = false;
				colvarSafetyStockLevel.IsForeignKey = false;
				colvarSafetyStockLevel.IsReadOnly = false;
				colvarSafetyStockLevel.DefaultSetting = @"";
				colvarSafetyStockLevel.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSafetyStockLevel);
				
				TableSchema.TableColumn colvarReorderPoint = new TableSchema.TableColumn(schema);
				colvarReorderPoint.ColumnName = "ReorderPoint";
				colvarReorderPoint.DataType = DbType.Int16;
				colvarReorderPoint.MaxLength = 0;
				colvarReorderPoint.AutoIncrement = false;
				colvarReorderPoint.IsNullable = false;
				colvarReorderPoint.IsPrimaryKey = false;
				colvarReorderPoint.IsForeignKey = false;
				colvarReorderPoint.IsReadOnly = false;
				colvarReorderPoint.DefaultSetting = @"";
				colvarReorderPoint.ForeignKeyTableName = "";
				schema.Columns.Add(colvarReorderPoint);
				
				TableSchema.TableColumn colvarStandardCost = new TableSchema.TableColumn(schema);
				colvarStandardCost.ColumnName = "StandardCost";
				colvarStandardCost.DataType = DbType.Currency;
				colvarStandardCost.MaxLength = 0;
				colvarStandardCost.AutoIncrement = false;
				colvarStandardCost.IsNullable = false;
				colvarStandardCost.IsPrimaryKey = false;
				colvarStandardCost.IsForeignKey = false;
				colvarStandardCost.IsReadOnly = false;
				colvarStandardCost.DefaultSetting = @"";
				colvarStandardCost.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStandardCost);
				
				TableSchema.TableColumn colvarListPrice = new TableSchema.TableColumn(schema);
				colvarListPrice.ColumnName = "ListPrice";
				colvarListPrice.DataType = DbType.Currency;
				colvarListPrice.MaxLength = 0;
				colvarListPrice.AutoIncrement = false;
				colvarListPrice.IsNullable = false;
				colvarListPrice.IsPrimaryKey = false;
				colvarListPrice.IsForeignKey = false;
				colvarListPrice.IsReadOnly = false;
				colvarListPrice.DefaultSetting = @"";
				colvarListPrice.ForeignKeyTableName = "";
				schema.Columns.Add(colvarListPrice);
				
				TableSchema.TableColumn colvarSize = new TableSchema.TableColumn(schema);
				colvarSize.ColumnName = "Size";
				colvarSize.DataType = DbType.String;
				colvarSize.MaxLength = 5;
				colvarSize.AutoIncrement = false;
				colvarSize.IsNullable = true;
				colvarSize.IsPrimaryKey = false;
				colvarSize.IsForeignKey = false;
				colvarSize.IsReadOnly = false;
				colvarSize.DefaultSetting = @"";
				colvarSize.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSize);
				
				TableSchema.TableColumn colvarSizeUnitMeasureCode = new TableSchema.TableColumn(schema);
				colvarSizeUnitMeasureCode.ColumnName = "SizeUnitMeasureCode";
				colvarSizeUnitMeasureCode.DataType = DbType.String;
				colvarSizeUnitMeasureCode.MaxLength = 3;
				colvarSizeUnitMeasureCode.AutoIncrement = false;
				colvarSizeUnitMeasureCode.IsNullable = true;
				colvarSizeUnitMeasureCode.IsPrimaryKey = false;
				colvarSizeUnitMeasureCode.IsForeignKey = true;
				colvarSizeUnitMeasureCode.IsReadOnly = false;
				colvarSizeUnitMeasureCode.DefaultSetting = @"";
				
					colvarSizeUnitMeasureCode.ForeignKeyTableName = "UnitMeasure";
				schema.Columns.Add(colvarSizeUnitMeasureCode);
				
				TableSchema.TableColumn colvarWeightUnitMeasureCode = new TableSchema.TableColumn(schema);
				colvarWeightUnitMeasureCode.ColumnName = "WeightUnitMeasureCode";
				colvarWeightUnitMeasureCode.DataType = DbType.String;
				colvarWeightUnitMeasureCode.MaxLength = 3;
				colvarWeightUnitMeasureCode.AutoIncrement = false;
				colvarWeightUnitMeasureCode.IsNullable = true;
				colvarWeightUnitMeasureCode.IsPrimaryKey = false;
				colvarWeightUnitMeasureCode.IsForeignKey = true;
				colvarWeightUnitMeasureCode.IsReadOnly = false;
				colvarWeightUnitMeasureCode.DefaultSetting = @"";
				
					colvarWeightUnitMeasureCode.ForeignKeyTableName = "UnitMeasure";
				schema.Columns.Add(colvarWeightUnitMeasureCode);
				
				TableSchema.TableColumn colvarWeight = new TableSchema.TableColumn(schema);
				colvarWeight.ColumnName = "Weight";
				colvarWeight.DataType = DbType.Decimal;
				colvarWeight.MaxLength = 0;
				colvarWeight.AutoIncrement = false;
				colvarWeight.IsNullable = true;
				colvarWeight.IsPrimaryKey = false;
				colvarWeight.IsForeignKey = false;
				colvarWeight.IsReadOnly = false;
				colvarWeight.DefaultSetting = @"";
				colvarWeight.ForeignKeyTableName = "";
				schema.Columns.Add(colvarWeight);
				
				TableSchema.TableColumn colvarDaysToManufacture = new TableSchema.TableColumn(schema);
				colvarDaysToManufacture.ColumnName = "DaysToManufacture";
				colvarDaysToManufacture.DataType = DbType.Int32;
				colvarDaysToManufacture.MaxLength = 0;
				colvarDaysToManufacture.AutoIncrement = false;
				colvarDaysToManufacture.IsNullable = false;
				colvarDaysToManufacture.IsPrimaryKey = false;
				colvarDaysToManufacture.IsForeignKey = false;
				colvarDaysToManufacture.IsReadOnly = false;
				colvarDaysToManufacture.DefaultSetting = @"";
				colvarDaysToManufacture.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDaysToManufacture);
				
				TableSchema.TableColumn colvarProductLine = new TableSchema.TableColumn(schema);
				colvarProductLine.ColumnName = "ProductLine";
				colvarProductLine.DataType = DbType.String;
				colvarProductLine.MaxLength = 2;
				colvarProductLine.AutoIncrement = false;
				colvarProductLine.IsNullable = true;
				colvarProductLine.IsPrimaryKey = false;
				colvarProductLine.IsForeignKey = false;
				colvarProductLine.IsReadOnly = false;
				colvarProductLine.DefaultSetting = @"";
				colvarProductLine.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProductLine);
				
				TableSchema.TableColumn colvarClassX = new TableSchema.TableColumn(schema);
				colvarClassX.ColumnName = "Class";
				colvarClassX.DataType = DbType.String;
				colvarClassX.MaxLength = 2;
				colvarClassX.AutoIncrement = false;
				colvarClassX.IsNullable = true;
				colvarClassX.IsPrimaryKey = false;
				colvarClassX.IsForeignKey = false;
				colvarClassX.IsReadOnly = false;
				colvarClassX.DefaultSetting = @"";
				colvarClassX.ForeignKeyTableName = "";
				schema.Columns.Add(colvarClassX);
				
				TableSchema.TableColumn colvarStyle = new TableSchema.TableColumn(schema);
				colvarStyle.ColumnName = "Style";
				colvarStyle.DataType = DbType.String;
				colvarStyle.MaxLength = 2;
				colvarStyle.AutoIncrement = false;
				colvarStyle.IsNullable = true;
				colvarStyle.IsPrimaryKey = false;
				colvarStyle.IsForeignKey = false;
				colvarStyle.IsReadOnly = false;
				colvarStyle.DefaultSetting = @"";
				colvarStyle.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStyle);
				
				TableSchema.TableColumn colvarProductSubcategoryID = new TableSchema.TableColumn(schema);
				colvarProductSubcategoryID.ColumnName = "ProductSubcategoryID";
				colvarProductSubcategoryID.DataType = DbType.Int32;
				colvarProductSubcategoryID.MaxLength = 0;
				colvarProductSubcategoryID.AutoIncrement = false;
				colvarProductSubcategoryID.IsNullable = true;
				colvarProductSubcategoryID.IsPrimaryKey = false;
				colvarProductSubcategoryID.IsForeignKey = true;
				colvarProductSubcategoryID.IsReadOnly = false;
				colvarProductSubcategoryID.DefaultSetting = @"";
				
					colvarProductSubcategoryID.ForeignKeyTableName = "ProductSubcategory";
				schema.Columns.Add(colvarProductSubcategoryID);
				
				TableSchema.TableColumn colvarProductModelID = new TableSchema.TableColumn(schema);
				colvarProductModelID.ColumnName = "ProductModelID";
				colvarProductModelID.DataType = DbType.Int32;
				colvarProductModelID.MaxLength = 0;
				colvarProductModelID.AutoIncrement = false;
				colvarProductModelID.IsNullable = true;
				colvarProductModelID.IsPrimaryKey = false;
				colvarProductModelID.IsForeignKey = true;
				colvarProductModelID.IsReadOnly = false;
				colvarProductModelID.DefaultSetting = @"";
				
					colvarProductModelID.ForeignKeyTableName = "ProductModel";
				schema.Columns.Add(colvarProductModelID);
				
				TableSchema.TableColumn colvarSellStartDate = new TableSchema.TableColumn(schema);
				colvarSellStartDate.ColumnName = "SellStartDate";
				colvarSellStartDate.DataType = DbType.DateTime;
				colvarSellStartDate.MaxLength = 0;
				colvarSellStartDate.AutoIncrement = false;
				colvarSellStartDate.IsNullable = false;
				colvarSellStartDate.IsPrimaryKey = false;
				colvarSellStartDate.IsForeignKey = false;
				colvarSellStartDate.IsReadOnly = false;
				colvarSellStartDate.DefaultSetting = @"";
				colvarSellStartDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSellStartDate);
				
				TableSchema.TableColumn colvarSellEndDate = new TableSchema.TableColumn(schema);
				colvarSellEndDate.ColumnName = "SellEndDate";
				colvarSellEndDate.DataType = DbType.DateTime;
				colvarSellEndDate.MaxLength = 0;
				colvarSellEndDate.AutoIncrement = false;
				colvarSellEndDate.IsNullable = true;
				colvarSellEndDate.IsPrimaryKey = false;
				colvarSellEndDate.IsForeignKey = false;
				colvarSellEndDate.IsReadOnly = false;
				colvarSellEndDate.DefaultSetting = @"";
				colvarSellEndDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSellEndDate);
				
				TableSchema.TableColumn colvarDiscontinuedDate = new TableSchema.TableColumn(schema);
				colvarDiscontinuedDate.ColumnName = "DiscontinuedDate";
				colvarDiscontinuedDate.DataType = DbType.DateTime;
				colvarDiscontinuedDate.MaxLength = 0;
				colvarDiscontinuedDate.AutoIncrement = false;
				colvarDiscontinuedDate.IsNullable = true;
				colvarDiscontinuedDate.IsPrimaryKey = false;
				colvarDiscontinuedDate.IsForeignKey = false;
				colvarDiscontinuedDate.IsReadOnly = false;
				colvarDiscontinuedDate.DefaultSetting = @"";
				colvarDiscontinuedDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiscontinuedDate);
				
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
				DataService.Providers["AdventureWorks"].AddSchema("Product",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("ProductID")]
		[Bindable(true)]
		public int ProductID 
		{
			get { return GetColumnValue<int>(Columns.ProductID); }
			set { SetColumnValue(Columns.ProductID, value); }
		}
		  
		[XmlAttribute("Name")]
		[Bindable(true)]
		public string Name 
		{
			get { return GetColumnValue<string>(Columns.Name); }
			set { SetColumnValue(Columns.Name, value); }
		}
		  
		[XmlAttribute("ProductNumber")]
		[Bindable(true)]
		public string ProductNumber 
		{
			get { return GetColumnValue<string>(Columns.ProductNumber); }
			set { SetColumnValue(Columns.ProductNumber, value); }
		}
		  
		[XmlAttribute("MakeFlag")]
		[Bindable(true)]
		public bool MakeFlag 
		{
			get { return GetColumnValue<bool>(Columns.MakeFlag); }
			set { SetColumnValue(Columns.MakeFlag, value); }
		}
		  
		[XmlAttribute("FinishedGoodsFlag")]
		[Bindable(true)]
		public bool FinishedGoodsFlag 
		{
			get { return GetColumnValue<bool>(Columns.FinishedGoodsFlag); }
			set { SetColumnValue(Columns.FinishedGoodsFlag, value); }
		}
		  
		[XmlAttribute("Color")]
		[Bindable(true)]
		public string Color 
		{
			get { return GetColumnValue<string>(Columns.Color); }
			set { SetColumnValue(Columns.Color, value); }
		}
		  
		[XmlAttribute("SafetyStockLevel")]
		[Bindable(true)]
		public short SafetyStockLevel 
		{
			get { return GetColumnValue<short>(Columns.SafetyStockLevel); }
			set { SetColumnValue(Columns.SafetyStockLevel, value); }
		}
		  
		[XmlAttribute("ReorderPoint")]
		[Bindable(true)]
		public short ReorderPoint 
		{
			get { return GetColumnValue<short>(Columns.ReorderPoint); }
			set { SetColumnValue(Columns.ReorderPoint, value); }
		}
		  
		[XmlAttribute("StandardCost")]
		[Bindable(true)]
		public decimal StandardCost 
		{
			get { return GetColumnValue<decimal>(Columns.StandardCost); }
			set { SetColumnValue(Columns.StandardCost, value); }
		}
		  
		[XmlAttribute("ListPrice")]
		[Bindable(true)]
		public decimal ListPrice 
		{
			get { return GetColumnValue<decimal>(Columns.ListPrice); }
			set { SetColumnValue(Columns.ListPrice, value); }
		}
		  
		[XmlAttribute("Size")]
		[Bindable(true)]
		public string Size 
		{
			get { return GetColumnValue<string>(Columns.Size); }
			set { SetColumnValue(Columns.Size, value); }
		}
		  
		[XmlAttribute("SizeUnitMeasureCode")]
		[Bindable(true)]
		public string SizeUnitMeasureCode 
		{
			get { return GetColumnValue<string>(Columns.SizeUnitMeasureCode); }
			set { SetColumnValue(Columns.SizeUnitMeasureCode, value); }
		}
		  
		[XmlAttribute("WeightUnitMeasureCode")]
		[Bindable(true)]
		public string WeightUnitMeasureCode 
		{
			get { return GetColumnValue<string>(Columns.WeightUnitMeasureCode); }
			set { SetColumnValue(Columns.WeightUnitMeasureCode, value); }
		}
		  
		[XmlAttribute("Weight")]
		[Bindable(true)]
		public decimal? Weight 
		{
			get { return GetColumnValue<decimal?>(Columns.Weight); }
			set { SetColumnValue(Columns.Weight, value); }
		}
		  
		[XmlAttribute("DaysToManufacture")]
		[Bindable(true)]
		public int DaysToManufacture 
		{
			get { return GetColumnValue<int>(Columns.DaysToManufacture); }
			set { SetColumnValue(Columns.DaysToManufacture, value); }
		}
		  
		[XmlAttribute("ProductLine")]
		[Bindable(true)]
		public string ProductLine 
		{
			get { return GetColumnValue<string>(Columns.ProductLine); }
			set { SetColumnValue(Columns.ProductLine, value); }
		}
		  
		[XmlAttribute("ClassX")]
		[Bindable(true)]
		public string ClassX 
		{
			get { return GetColumnValue<string>(Columns.ClassX); }
			set { SetColumnValue(Columns.ClassX, value); }
		}
		  
		[XmlAttribute("Style")]
		[Bindable(true)]
		public string Style 
		{
			get { return GetColumnValue<string>(Columns.Style); }
			set { SetColumnValue(Columns.Style, value); }
		}
		  
		[XmlAttribute("ProductSubcategoryID")]
		[Bindable(true)]
		public int? ProductSubcategoryID 
		{
			get { return GetColumnValue<int?>(Columns.ProductSubcategoryID); }
			set { SetColumnValue(Columns.ProductSubcategoryID, value); }
		}
		  
		[XmlAttribute("ProductModelID")]
		[Bindable(true)]
		public int? ProductModelID 
		{
			get { return GetColumnValue<int?>(Columns.ProductModelID); }
			set { SetColumnValue(Columns.ProductModelID, value); }
		}
		  
		[XmlAttribute("SellStartDate")]
		[Bindable(true)]
		public DateTime SellStartDate 
		{
			get { return GetColumnValue<DateTime>(Columns.SellStartDate); }
			set { SetColumnValue(Columns.SellStartDate, value); }
		}
		  
		[XmlAttribute("SellEndDate")]
		[Bindable(true)]
		public DateTime? SellEndDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.SellEndDate); }
			set { SetColumnValue(Columns.SellEndDate, value); }
		}
		  
		[XmlAttribute("DiscontinuedDate")]
		[Bindable(true)]
		public DateTime? DiscontinuedDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.DiscontinuedDate); }
			set { SetColumnValue(Columns.DiscontinuedDate, value); }
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
        
		
		public AdventureWorks.BillOfMaterialCollection BillOfMaterials()
		{
			return new AdventureWorks.BillOfMaterialCollection().Where(BillOfMaterial.Columns.ComponentID, ProductID).Load();
		}
		public AdventureWorks.BillOfMaterialCollection BillOfMaterialsFromProduct()
		{
			return new AdventureWorks.BillOfMaterialCollection().Where(BillOfMaterial.Columns.ProductAssemblyID, ProductID).Load();
		}
		public AdventureWorks.ProductCostHistoryCollection ProductCostHistoryRecords()
		{
			return new AdventureWorks.ProductCostHistoryCollection().Where(ProductCostHistory.Columns.ProductID, ProductID).Load();
		}
		public AdventureWorks.ProductDocumentCollection ProductDocumentRecords()
		{
			return new AdventureWorks.ProductDocumentCollection().Where(ProductDocument.Columns.ProductID, ProductID).Load();
		}
		public AdventureWorks.ProductInventoryCollection ProductInventoryRecords()
		{
			return new AdventureWorks.ProductInventoryCollection().Where(ProductInventory.Columns.ProductID, ProductID).Load();
		}
		public AdventureWorks.ProductListPriceHistoryCollection ProductListPriceHistoryRecords()
		{
			return new AdventureWorks.ProductListPriceHistoryCollection().Where(ProductListPriceHistory.Columns.ProductID, ProductID).Load();
		}
		public AdventureWorks.ProductProductPhotoCollection ProductProductPhotoRecords()
		{
			return new AdventureWorks.ProductProductPhotoCollection().Where(ProductProductPhoto.Columns.ProductID, ProductID).Load();
		}
		public AdventureWorks.ProductReviewCollection ProductReviewRecords()
		{
			return new AdventureWorks.ProductReviewCollection().Where(ProductReview.Columns.ProductID, ProductID).Load();
		}
		public AdventureWorks.TransactionHistoryCollection TransactionHistoryRecords()
		{
			return new AdventureWorks.TransactionHistoryCollection().Where(TransactionHistory.Columns.ProductID, ProductID).Load();
		}
		public AdventureWorks.WorkOrderCollection WorkOrderRecords()
		{
			return new AdventureWorks.WorkOrderCollection().Where(WorkOrder.Columns.ProductID, ProductID).Load();
		}
		public AdventureWorks.ProductVendorCollection ProductVendorRecords()
		{
			return new AdventureWorks.ProductVendorCollection().Where(ProductVendor.Columns.ProductID, ProductID).Load();
		}
		public AdventureWorks.PurchaseOrderDetailCollection PurchaseOrderDetailRecords()
		{
			return new AdventureWorks.PurchaseOrderDetailCollection().Where(PurchaseOrderDetail.Columns.ProductID, ProductID).Load();
		}
		public AdventureWorks.ShoppingCartItemCollection ShoppingCartItemRecords()
		{
			return new AdventureWorks.ShoppingCartItemCollection().Where(ShoppingCartItem.Columns.ProductID, ProductID).Load();
		}
		public AdventureWorks.SpecialOfferProductCollection SpecialOfferProductRecords()
		{
			return new AdventureWorks.SpecialOfferProductCollection().Where(SpecialOfferProduct.Columns.ProductID, ProductID).Load();
		}
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a ProductModel ActiveRecord object related to this Product
		/// 
		/// </summary>
		public AdventureWorks.ProductModel ProductModel
		{
			get { return AdventureWorks.ProductModel.FetchByID(this.ProductModelID); }
			set { SetColumnValue("ProductModelID", value.ProductModelID); }
		}
		
		
		/// <summary>
		/// Returns a ProductSubcategory ActiveRecord object related to this Product
		/// 
		/// </summary>
		public AdventureWorks.ProductSubcategory ProductSubcategory
		{
			get { return AdventureWorks.ProductSubcategory.FetchByID(this.ProductSubcategoryID); }
			set { SetColumnValue("ProductSubcategoryID", value.ProductSubcategoryID); }
		}
		
		
		/// <summary>
		/// Returns a UnitMeasure ActiveRecord object related to this Product
		/// 
		/// </summary>
		public AdventureWorks.UnitMeasure UnitMeasure
		{
			get { return AdventureWorks.UnitMeasure.FetchByID(this.SizeUnitMeasureCode); }
			set { SetColumnValue("SizeUnitMeasureCode", value.UnitMeasureCode); }
		}
		
		
		/// <summary>
		/// Returns a UnitMeasure ActiveRecord object related to this Product
		/// 
		/// </summary>
		public AdventureWorks.UnitMeasure UnitMeasureToWeightUnitMeasureCode
		{
			get { return AdventureWorks.UnitMeasure.FetchByID(this.WeightUnitMeasureCode); }
			set { SetColumnValue("WeightUnitMeasureCode", value.UnitMeasureCode); }
		}
		
		
		#endregion
		
		
		
		#region Many To Many Helpers
		
		 
		public AdventureWorks.DocumentCollection GetDocumentCollection() { return Product.GetDocumentCollection(this.ProductID); }
		public static AdventureWorks.DocumentCollection GetDocumentCollection(int varProductID)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [Production].[Document] INNER JOIN [ProductDocument] ON [Document].[DocumentID] = [ProductDocument].[DocumentID] WHERE [ProductDocument].[ProductID] = @ProductID", Product.Schema.Provider.Name);
			cmd.AddParameter("@ProductID", varProductID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			DocumentCollection coll = new DocumentCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveDocumentMap(int varProductID, DocumentCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductDocument] WHERE [ProductDocument].[ProductID] = @ProductID", Product.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductID", varProductID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Document item in items)
			{
				ProductDocument varProductDocument = new ProductDocument();
				varProductDocument.SetColumnValue("ProductID", varProductID);
				varProductDocument.SetColumnValue("DocumentID", item.GetPrimaryKeyValue());
				varProductDocument.Save();
			}
		}
		public static void SaveDocumentMap(int varProductID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductDocument] WHERE [ProductDocument].[ProductID] = @ProductID", Product.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductID", varProductID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					ProductDocument varProductDocument = new ProductDocument();
					varProductDocument.SetColumnValue("ProductID", varProductID);
					varProductDocument.SetColumnValue("DocumentID", l.Value);
					varProductDocument.Save();
				}
			}
		}
		public static void SaveDocumentMap(int varProductID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductDocument] WHERE [ProductDocument].[ProductID] = @ProductID", Product.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductID", varProductID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				ProductDocument varProductDocument = new ProductDocument();
				varProductDocument.SetColumnValue("ProductID", varProductID);
				varProductDocument.SetColumnValue("DocumentID", item);
				varProductDocument.Save();
			}
		}
		
		public static void DeleteDocumentMap(int varProductID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductDocument] WHERE [ProductDocument].[ProductID] = @ProductID", Product.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductID", varProductID, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		 
		public AdventureWorks.LocationCollection GetLocationCollection() { return Product.GetLocationCollection(this.ProductID); }
		public static AdventureWorks.LocationCollection GetLocationCollection(int varProductID)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [Production].[Location] INNER JOIN [ProductInventory] ON [Location].[LocationID] = [ProductInventory].[LocationID] WHERE [ProductInventory].[ProductID] = @ProductID", Product.Schema.Provider.Name);
			cmd.AddParameter("@ProductID", varProductID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			LocationCollection coll = new LocationCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveLocationMap(int varProductID, LocationCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductInventory] WHERE [ProductInventory].[ProductID] = @ProductID", Product.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductID", varProductID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Location item in items)
			{
				ProductInventory varProductInventory = new ProductInventory();
				varProductInventory.SetColumnValue("ProductID", varProductID);
				varProductInventory.SetColumnValue("LocationID", item.GetPrimaryKeyValue());
				varProductInventory.Save();
			}
		}
		public static void SaveLocationMap(int varProductID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductInventory] WHERE [ProductInventory].[ProductID] = @ProductID", Product.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductID", varProductID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					ProductInventory varProductInventory = new ProductInventory();
					varProductInventory.SetColumnValue("ProductID", varProductID);
					varProductInventory.SetColumnValue("LocationID", l.Value);
					varProductInventory.Save();
				}
			}
		}
		public static void SaveLocationMap(int varProductID , short[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductInventory] WHERE [ProductInventory].[ProductID] = @ProductID", Product.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductID", varProductID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (short item in itemList) 
			{
				ProductInventory varProductInventory = new ProductInventory();
				varProductInventory.SetColumnValue("ProductID", varProductID);
				varProductInventory.SetColumnValue("LocationID", item);
				varProductInventory.Save();
			}
		}
		
		public static void DeleteLocationMap(int varProductID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductInventory] WHERE [ProductInventory].[ProductID] = @ProductID", Product.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductID", varProductID, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		 
		public AdventureWorks.ProductPhotoCollection GetProductPhotoCollection() { return Product.GetProductPhotoCollection(this.ProductID); }
		public static AdventureWorks.ProductPhotoCollection GetProductPhotoCollection(int varProductID)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [Production].[ProductPhoto] INNER JOIN [ProductProductPhoto] ON [ProductPhoto].[ProductPhotoID] = [ProductProductPhoto].[ProductPhotoID] WHERE [ProductProductPhoto].[ProductID] = @ProductID", Product.Schema.Provider.Name);
			cmd.AddParameter("@ProductID", varProductID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			ProductPhotoCollection coll = new ProductPhotoCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveProductPhotoMap(int varProductID, ProductPhotoCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductProductPhoto] WHERE [ProductProductPhoto].[ProductID] = @ProductID", Product.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductID", varProductID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (ProductPhoto item in items)
			{
				ProductProductPhoto varProductProductPhoto = new ProductProductPhoto();
				varProductProductPhoto.SetColumnValue("ProductID", varProductID);
				varProductProductPhoto.SetColumnValue("ProductPhotoID", item.GetPrimaryKeyValue());
				varProductProductPhoto.Save();
			}
		}
		public static void SaveProductPhotoMap(int varProductID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductProductPhoto] WHERE [ProductProductPhoto].[ProductID] = @ProductID", Product.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductID", varProductID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					ProductProductPhoto varProductProductPhoto = new ProductProductPhoto();
					varProductProductPhoto.SetColumnValue("ProductID", varProductID);
					varProductProductPhoto.SetColumnValue("ProductPhotoID", l.Value);
					varProductProductPhoto.Save();
				}
			}
		}
		public static void SaveProductPhotoMap(int varProductID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductProductPhoto] WHERE [ProductProductPhoto].[ProductID] = @ProductID", Product.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductID", varProductID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				ProductProductPhoto varProductProductPhoto = new ProductProductPhoto();
				varProductProductPhoto.SetColumnValue("ProductID", varProductID);
				varProductProductPhoto.SetColumnValue("ProductPhotoID", item);
				varProductProductPhoto.Save();
			}
		}
		
		public static void DeleteProductPhotoMap(int varProductID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductProductPhoto] WHERE [ProductProductPhoto].[ProductID] = @ProductID", Product.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductID", varProductID, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		 
		public AdventureWorks.UnitMeasureCollection GetUnitMeasureCollection() { return Product.GetUnitMeasureCollection(this.ProductID); }
		public static AdventureWorks.UnitMeasureCollection GetUnitMeasureCollection(int varProductID)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [Production].[UnitMeasure] INNER JOIN [ProductVendor] ON [UnitMeasure].[UnitMeasureCode] = [ProductVendor].[UnitMeasureCode] WHERE [ProductVendor].[ProductID] = @ProductID", Product.Schema.Provider.Name);
			cmd.AddParameter("@ProductID", varProductID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			UnitMeasureCollection coll = new UnitMeasureCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveUnitMeasureMap(int varProductID, UnitMeasureCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductVendor] WHERE [ProductVendor].[ProductID] = @ProductID", Product.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductID", varProductID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (UnitMeasure item in items)
			{
				ProductVendor varProductVendor = new ProductVendor();
				varProductVendor.SetColumnValue("ProductID", varProductID);
				varProductVendor.SetColumnValue("UnitMeasureCode", item.GetPrimaryKeyValue());
				varProductVendor.Save();
			}
		}
		public static void SaveUnitMeasureMap(int varProductID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductVendor] WHERE [ProductVendor].[ProductID] = @ProductID", Product.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductID", varProductID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					ProductVendor varProductVendor = new ProductVendor();
					varProductVendor.SetColumnValue("ProductID", varProductID);
					varProductVendor.SetColumnValue("UnitMeasureCode", l.Value);
					varProductVendor.Save();
				}
			}
		}
		public static void SaveUnitMeasureMap(int varProductID , string[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductVendor] WHERE [ProductVendor].[ProductID] = @ProductID", Product.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductID", varProductID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (string item in itemList) 
			{
				ProductVendor varProductVendor = new ProductVendor();
				varProductVendor.SetColumnValue("ProductID", varProductID);
				varProductVendor.SetColumnValue("UnitMeasureCode", item);
				varProductVendor.Save();
			}
		}
		
		public static void DeleteUnitMeasureMap(int varProductID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductVendor] WHERE [ProductVendor].[ProductID] = @ProductID", Product.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductID", varProductID, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		 
		public AdventureWorks.VendorCollection GetVendorCollection() { return Product.GetVendorCollection(this.ProductID); }
		public static AdventureWorks.VendorCollection GetVendorCollection(int varProductID)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [Purchasing].[Vendor] INNER JOIN [ProductVendor] ON [Vendor].[VendorID] = [ProductVendor].[VendorID] WHERE [ProductVendor].[ProductID] = @ProductID", Product.Schema.Provider.Name);
			cmd.AddParameter("@ProductID", varProductID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			VendorCollection coll = new VendorCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveVendorMap(int varProductID, VendorCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductVendor] WHERE [ProductVendor].[ProductID] = @ProductID", Product.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductID", varProductID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Vendor item in items)
			{
				ProductVendor varProductVendor = new ProductVendor();
				varProductVendor.SetColumnValue("ProductID", varProductID);
				varProductVendor.SetColumnValue("VendorID", item.GetPrimaryKeyValue());
				varProductVendor.Save();
			}
		}
		public static void SaveVendorMap(int varProductID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductVendor] WHERE [ProductVendor].[ProductID] = @ProductID", Product.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductID", varProductID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					ProductVendor varProductVendor = new ProductVendor();
					varProductVendor.SetColumnValue("ProductID", varProductID);
					varProductVendor.SetColumnValue("VendorID", l.Value);
					varProductVendor.Save();
				}
			}
		}
		public static void SaveVendorMap(int varProductID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductVendor] WHERE [ProductVendor].[ProductID] = @ProductID", Product.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductID", varProductID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				ProductVendor varProductVendor = new ProductVendor();
				varProductVendor.SetColumnValue("ProductID", varProductID);
				varProductVendor.SetColumnValue("VendorID", item);
				varProductVendor.Save();
			}
		}
		
		public static void DeleteVendorMap(int varProductID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [ProductVendor] WHERE [ProductVendor].[ProductID] = @ProductID", Product.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductID", varProductID, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		 
		public AdventureWorks.SpecialOfferCollection GetSpecialOfferCollection() { return Product.GetSpecialOfferCollection(this.ProductID); }
		public static AdventureWorks.SpecialOfferCollection GetSpecialOfferCollection(int varProductID)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [Sales].[SpecialOffer] INNER JOIN [SpecialOfferProduct] ON [SpecialOffer].[SpecialOfferID] = [SpecialOfferProduct].[SpecialOfferID] WHERE [SpecialOfferProduct].[ProductID] = @ProductID", Product.Schema.Provider.Name);
			cmd.AddParameter("@ProductID", varProductID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			SpecialOfferCollection coll = new SpecialOfferCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveSpecialOfferMap(int varProductID, SpecialOfferCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [SpecialOfferProduct] WHERE [SpecialOfferProduct].[ProductID] = @ProductID", Product.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductID", varProductID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (SpecialOffer item in items)
			{
				SpecialOfferProduct varSpecialOfferProduct = new SpecialOfferProduct();
				varSpecialOfferProduct.SetColumnValue("ProductID", varProductID);
				varSpecialOfferProduct.SetColumnValue("SpecialOfferID", item.GetPrimaryKeyValue());
				varSpecialOfferProduct.Save();
			}
		}
		public static void SaveSpecialOfferMap(int varProductID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [SpecialOfferProduct] WHERE [SpecialOfferProduct].[ProductID] = @ProductID", Product.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductID", varProductID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					SpecialOfferProduct varSpecialOfferProduct = new SpecialOfferProduct();
					varSpecialOfferProduct.SetColumnValue("ProductID", varProductID);
					varSpecialOfferProduct.SetColumnValue("SpecialOfferID", l.Value);
					varSpecialOfferProduct.Save();
				}
			}
		}
		public static void SaveSpecialOfferMap(int varProductID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [SpecialOfferProduct] WHERE [SpecialOfferProduct].[ProductID] = @ProductID", Product.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductID", varProductID, DbType.Int32);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				SpecialOfferProduct varSpecialOfferProduct = new SpecialOfferProduct();
				varSpecialOfferProduct.SetColumnValue("ProductID", varProductID);
				varSpecialOfferProduct.SetColumnValue("SpecialOfferID", item);
				varSpecialOfferProduct.Save();
			}
		}
		
		public static void DeleteSpecialOfferMap(int varProductID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [SpecialOfferProduct] WHERE [SpecialOfferProduct].[ProductID] = @ProductID", Product.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductID", varProductID, DbType.Int32);
			DataService.ExecuteQuery(cmdDel);
		}
		
		#endregion
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varName,string varProductNumber,bool varMakeFlag,bool varFinishedGoodsFlag,string varColor,short varSafetyStockLevel,short varReorderPoint,decimal varStandardCost,decimal varListPrice,string varSize,string varSizeUnitMeasureCode,string varWeightUnitMeasureCode,decimal? varWeight,int varDaysToManufacture,string varProductLine,string varClassX,string varStyle,int? varProductSubcategoryID,int? varProductModelID,DateTime varSellStartDate,DateTime? varSellEndDate,DateTime? varDiscontinuedDate,Guid varRowguid,DateTime varModifiedDate)
		{
			Product item = new Product();
			
			item.Name = varName;
			
			item.ProductNumber = varProductNumber;
			
			item.MakeFlag = varMakeFlag;
			
			item.FinishedGoodsFlag = varFinishedGoodsFlag;
			
			item.Color = varColor;
			
			item.SafetyStockLevel = varSafetyStockLevel;
			
			item.ReorderPoint = varReorderPoint;
			
			item.StandardCost = varStandardCost;
			
			item.ListPrice = varListPrice;
			
			item.Size = varSize;
			
			item.SizeUnitMeasureCode = varSizeUnitMeasureCode;
			
			item.WeightUnitMeasureCode = varWeightUnitMeasureCode;
			
			item.Weight = varWeight;
			
			item.DaysToManufacture = varDaysToManufacture;
			
			item.ProductLine = varProductLine;
			
			item.ClassX = varClassX;
			
			item.Style = varStyle;
			
			item.ProductSubcategoryID = varProductSubcategoryID;
			
			item.ProductModelID = varProductModelID;
			
			item.SellStartDate = varSellStartDate;
			
			item.SellEndDate = varSellEndDate;
			
			item.DiscontinuedDate = varDiscontinuedDate;
			
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
		public static void Update(int varProductID,string varName,string varProductNumber,bool varMakeFlag,bool varFinishedGoodsFlag,string varColor,short varSafetyStockLevel,short varReorderPoint,decimal varStandardCost,decimal varListPrice,string varSize,string varSizeUnitMeasureCode,string varWeightUnitMeasureCode,decimal? varWeight,int varDaysToManufacture,string varProductLine,string varClassX,string varStyle,int? varProductSubcategoryID,int? varProductModelID,DateTime varSellStartDate,DateTime? varSellEndDate,DateTime? varDiscontinuedDate,Guid varRowguid,DateTime varModifiedDate)
		{
			Product item = new Product();
			
				item.ProductID = varProductID;
			
				item.Name = varName;
			
				item.ProductNumber = varProductNumber;
			
				item.MakeFlag = varMakeFlag;
			
				item.FinishedGoodsFlag = varFinishedGoodsFlag;
			
				item.Color = varColor;
			
				item.SafetyStockLevel = varSafetyStockLevel;
			
				item.ReorderPoint = varReorderPoint;
			
				item.StandardCost = varStandardCost;
			
				item.ListPrice = varListPrice;
			
				item.Size = varSize;
			
				item.SizeUnitMeasureCode = varSizeUnitMeasureCode;
			
				item.WeightUnitMeasureCode = varWeightUnitMeasureCode;
			
				item.Weight = varWeight;
			
				item.DaysToManufacture = varDaysToManufacture;
			
				item.ProductLine = varProductLine;
			
				item.ClassX = varClassX;
			
				item.Style = varStyle;
			
				item.ProductSubcategoryID = varProductSubcategoryID;
			
				item.ProductModelID = varProductModelID;
			
				item.SellStartDate = varSellStartDate;
			
				item.SellEndDate = varSellEndDate;
			
				item.DiscontinuedDate = varDiscontinuedDate;
			
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
        
        
        public static TableSchema.TableColumn ProductIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn NameColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn ProductNumberColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn MakeFlagColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn FinishedGoodsFlagColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn ColorColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn SafetyStockLevelColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn ReorderPointColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn StandardCostColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        public static TableSchema.TableColumn ListPriceColumn
        {
            get { return Schema.Columns[9]; }
        }
        
        
        
        public static TableSchema.TableColumn SizeColumn
        {
            get { return Schema.Columns[10]; }
        }
        
        
        
        public static TableSchema.TableColumn SizeUnitMeasureCodeColumn
        {
            get { return Schema.Columns[11]; }
        }
        
        
        
        public static TableSchema.TableColumn WeightUnitMeasureCodeColumn
        {
            get { return Schema.Columns[12]; }
        }
        
        
        
        public static TableSchema.TableColumn WeightColumn
        {
            get { return Schema.Columns[13]; }
        }
        
        
        
        public static TableSchema.TableColumn DaysToManufactureColumn
        {
            get { return Schema.Columns[14]; }
        }
        
        
        
        public static TableSchema.TableColumn ProductLineColumn
        {
            get { return Schema.Columns[15]; }
        }
        
        
        
        public static TableSchema.TableColumn ClassXColumn
        {
            get { return Schema.Columns[16]; }
        }
        
        
        
        public static TableSchema.TableColumn StyleColumn
        {
            get { return Schema.Columns[17]; }
        }
        
        
        
        public static TableSchema.TableColumn ProductSubcategoryIDColumn
        {
            get { return Schema.Columns[18]; }
        }
        
        
        
        public static TableSchema.TableColumn ProductModelIDColumn
        {
            get { return Schema.Columns[19]; }
        }
        
        
        
        public static TableSchema.TableColumn SellStartDateColumn
        {
            get { return Schema.Columns[20]; }
        }
        
        
        
        public static TableSchema.TableColumn SellEndDateColumn
        {
            get { return Schema.Columns[21]; }
        }
        
        
        
        public static TableSchema.TableColumn DiscontinuedDateColumn
        {
            get { return Schema.Columns[22]; }
        }
        
        
        
        public static TableSchema.TableColumn RowguidColumn
        {
            get { return Schema.Columns[23]; }
        }
        
        
        
        public static TableSchema.TableColumn ModifiedDateColumn
        {
            get { return Schema.Columns[24]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string ProductID = @"ProductID";
			 public static string Name = @"Name";
			 public static string ProductNumber = @"ProductNumber";
			 public static string MakeFlag = @"MakeFlag";
			 public static string FinishedGoodsFlag = @"FinishedGoodsFlag";
			 public static string Color = @"Color";
			 public static string SafetyStockLevel = @"SafetyStockLevel";
			 public static string ReorderPoint = @"ReorderPoint";
			 public static string StandardCost = @"StandardCost";
			 public static string ListPrice = @"ListPrice";
			 public static string Size = @"Size";
			 public static string SizeUnitMeasureCode = @"SizeUnitMeasureCode";
			 public static string WeightUnitMeasureCode = @"WeightUnitMeasureCode";
			 public static string Weight = @"Weight";
			 public static string DaysToManufacture = @"DaysToManufacture";
			 public static string ProductLine = @"ProductLine";
			 public static string ClassX = @"Class";
			 public static string Style = @"Style";
			 public static string ProductSubcategoryID = @"ProductSubcategoryID";
			 public static string ProductModelID = @"ProductModelID";
			 public static string SellStartDate = @"SellStartDate";
			 public static string SellEndDate = @"SellEndDate";
			 public static string DiscontinuedDate = @"DiscontinuedDate";
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
