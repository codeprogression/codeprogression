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
    /// Controller class for ProductInventory
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ProductInventoryController
    {
        // Preload our schema..
        ProductInventory thisSchemaLoad = new ProductInventory();
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
        public ProductInventoryCollection FetchAll()
        {
            ProductInventoryCollection coll = new ProductInventoryCollection();
            Query qry = new Query(ProductInventory.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductInventoryCollection FetchByID(object ProductID)
        {
            ProductInventoryCollection coll = new ProductInventoryCollection().Where("ProductID", ProductID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductInventoryCollection FetchByQuery(Query qry)
        {
            ProductInventoryCollection coll = new ProductInventoryCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ProductID)
        {
            return (ProductInventory.Delete(ProductID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ProductID)
        {
            return (ProductInventory.Destroy(ProductID) == 1);
        }
        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int ProductID,short LocationID)
        {
            Query qry = new Query(ProductInventory.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("ProductID", ProductID).AND("LocationID", LocationID);
            qry.Execute();
            return (true);
        }        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int ProductID,short LocationID,string Shelf,byte Bin,short Quantity,Guid Rowguid,DateTime ModifiedDate)
	    {
		    ProductInventory item = new ProductInventory();
		    
            item.ProductID = ProductID;
            
            item.LocationID = LocationID;
            
            item.Shelf = Shelf;
            
            item.Bin = Bin;
            
            item.Quantity = Quantity;
            
            item.Rowguid = Rowguid;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int ProductID,short LocationID,string Shelf,byte Bin,short Quantity,Guid Rowguid,DateTime ModifiedDate)
	    {
		    ProductInventory item = new ProductInventory();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.ProductID = ProductID;
				
			item.LocationID = LocationID;
				
			item.Shelf = Shelf;
				
			item.Bin = Bin;
				
			item.Quantity = Quantity;
				
			item.Rowguid = Rowguid;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
