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
    /// Controller class for ProductVendor
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ProductVendorController
    {
        // Preload our schema..
        ProductVendor thisSchemaLoad = new ProductVendor();
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
        public ProductVendorCollection FetchAll()
        {
            ProductVendorCollection coll = new ProductVendorCollection();
            Query qry = new Query(ProductVendor.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductVendorCollection FetchByID(object ProductID)
        {
            ProductVendorCollection coll = new ProductVendorCollection().Where("ProductID", ProductID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductVendorCollection FetchByQuery(Query qry)
        {
            ProductVendorCollection coll = new ProductVendorCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ProductID)
        {
            return (ProductVendor.Delete(ProductID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ProductID)
        {
            return (ProductVendor.Destroy(ProductID) == 1);
        }
        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int ProductID,int VendorID)
        {
            Query qry = new Query(ProductVendor.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("ProductID", ProductID).AND("VendorID", VendorID);
            qry.Execute();
            return (true);
        }        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int ProductID,int VendorID,int AverageLeadTime,decimal StandardPrice,decimal? LastReceiptCost,DateTime? LastReceiptDate,int MinOrderQty,int MaxOrderQty,int? OnOrderQty,string UnitMeasureCode,DateTime ModifiedDate)
	    {
		    ProductVendor item = new ProductVendor();
		    
            item.ProductID = ProductID;
            
            item.VendorID = VendorID;
            
            item.AverageLeadTime = AverageLeadTime;
            
            item.StandardPrice = StandardPrice;
            
            item.LastReceiptCost = LastReceiptCost;
            
            item.LastReceiptDate = LastReceiptDate;
            
            item.MinOrderQty = MinOrderQty;
            
            item.MaxOrderQty = MaxOrderQty;
            
            item.OnOrderQty = OnOrderQty;
            
            item.UnitMeasureCode = UnitMeasureCode;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int ProductID,int VendorID,int AverageLeadTime,decimal StandardPrice,decimal? LastReceiptCost,DateTime? LastReceiptDate,int MinOrderQty,int MaxOrderQty,int? OnOrderQty,string UnitMeasureCode,DateTime ModifiedDate)
	    {
		    ProductVendor item = new ProductVendor();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.ProductID = ProductID;
				
			item.VendorID = VendorID;
				
			item.AverageLeadTime = AverageLeadTime;
				
			item.StandardPrice = StandardPrice;
				
			item.LastReceiptCost = LastReceiptCost;
				
			item.LastReceiptDate = LastReceiptDate;
				
			item.MinOrderQty = MinOrderQty;
				
			item.MaxOrderQty = MaxOrderQty;
				
			item.OnOrderQty = OnOrderQty;
				
			item.UnitMeasureCode = UnitMeasureCode;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
