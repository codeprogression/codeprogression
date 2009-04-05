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
    /// Controller class for Product
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ProductController
    {
        // Preload our schema..
        Product thisSchemaLoad = new Product();
        private string userName = String.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}
					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}
				}
				return userName;
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public ProductCollection FetchAll()
        {
            ProductCollection coll = new ProductCollection();
            Query qry = new Query(Product.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductCollection FetchByID(object ProductID)
        {
            ProductCollection coll = new ProductCollection().Where("ProductID", ProductID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductCollection FetchByQuery(Query qry)
        {
            ProductCollection coll = new ProductCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ProductID)
        {
            return (Product.Delete(ProductID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ProductID)
        {
            return (Product.Destroy(ProductID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Name,string ProductNumber,bool MakeFlag,bool FinishedGoodsFlag,string Color,short SafetyStockLevel,short ReorderPoint,decimal StandardCost,decimal ListPrice,string Size,string SizeUnitMeasureCode,string WeightUnitMeasureCode,decimal? Weight,int DaysToManufacture,string ProductLine,string ClassX,string Style,int? ProductSubcategoryID,int? ProductModelID,DateTime SellStartDate,DateTime? SellEndDate,DateTime? DiscontinuedDate,Guid Rowguid,DateTime ModifiedDate)
	    {
		    Product item = new Product();
		    
            item.Name = Name;
            
            item.ProductNumber = ProductNumber;
            
            item.MakeFlag = MakeFlag;
            
            item.FinishedGoodsFlag = FinishedGoodsFlag;
            
            item.Color = Color;
            
            item.SafetyStockLevel = SafetyStockLevel;
            
            item.ReorderPoint = ReorderPoint;
            
            item.StandardCost = StandardCost;
            
            item.ListPrice = ListPrice;
            
            item.Size = Size;
            
            item.SizeUnitMeasureCode = SizeUnitMeasureCode;
            
            item.WeightUnitMeasureCode = WeightUnitMeasureCode;
            
            item.Weight = Weight;
            
            item.DaysToManufacture = DaysToManufacture;
            
            item.ProductLine = ProductLine;
            
            item.ClassX = ClassX;
            
            item.Style = Style;
            
            item.ProductSubcategoryID = ProductSubcategoryID;
            
            item.ProductModelID = ProductModelID;
            
            item.SellStartDate = SellStartDate;
            
            item.SellEndDate = SellEndDate;
            
            item.DiscontinuedDate = DiscontinuedDate;
            
            item.Rowguid = Rowguid;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int ProductID,string Name,string ProductNumber,bool MakeFlag,bool FinishedGoodsFlag,string Color,short SafetyStockLevel,short ReorderPoint,decimal StandardCost,decimal ListPrice,string Size,string SizeUnitMeasureCode,string WeightUnitMeasureCode,decimal? Weight,int DaysToManufacture,string ProductLine,string ClassX,string Style,int? ProductSubcategoryID,int? ProductModelID,DateTime SellStartDate,DateTime? SellEndDate,DateTime? DiscontinuedDate,Guid Rowguid,DateTime ModifiedDate)
	    {
		    Product item = new Product();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.ProductID = ProductID;
				
			item.Name = Name;
				
			item.ProductNumber = ProductNumber;
				
			item.MakeFlag = MakeFlag;
				
			item.FinishedGoodsFlag = FinishedGoodsFlag;
				
			item.Color = Color;
				
			item.SafetyStockLevel = SafetyStockLevel;
				
			item.ReorderPoint = ReorderPoint;
				
			item.StandardCost = StandardCost;
				
			item.ListPrice = ListPrice;
				
			item.Size = Size;
				
			item.SizeUnitMeasureCode = SizeUnitMeasureCode;
				
			item.WeightUnitMeasureCode = WeightUnitMeasureCode;
				
			item.Weight = Weight;
				
			item.DaysToManufacture = DaysToManufacture;
				
			item.ProductLine = ProductLine;
				
			item.ClassX = ClassX;
				
			item.Style = Style;
				
			item.ProductSubcategoryID = ProductSubcategoryID;
				
			item.ProductModelID = ProductModelID;
				
			item.SellStartDate = SellStartDate;
				
			item.SellEndDate = SellEndDate;
				
			item.DiscontinuedDate = DiscontinuedDate;
				
			item.Rowguid = Rowguid;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
