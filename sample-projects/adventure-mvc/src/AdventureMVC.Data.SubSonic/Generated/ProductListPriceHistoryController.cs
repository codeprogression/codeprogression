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
    /// Controller class for ProductListPriceHistory
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ProductListPriceHistoryController
    {
        // Preload our schema..
        ProductListPriceHistory thisSchemaLoad = new ProductListPriceHistory();
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
        public ProductListPriceHistoryCollection FetchAll()
        {
            ProductListPriceHistoryCollection coll = new ProductListPriceHistoryCollection();
            Query qry = new Query(ProductListPriceHistory.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductListPriceHistoryCollection FetchByID(object ProductID)
        {
            ProductListPriceHistoryCollection coll = new ProductListPriceHistoryCollection().Where("ProductID", ProductID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductListPriceHistoryCollection FetchByQuery(Query qry)
        {
            ProductListPriceHistoryCollection coll = new ProductListPriceHistoryCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ProductID)
        {
            return (ProductListPriceHistory.Delete(ProductID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ProductID)
        {
            return (ProductListPriceHistory.Destroy(ProductID) == 1);
        }
        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int ProductID,DateTime StartDate)
        {
            Query qry = new Query(ProductListPriceHistory.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("ProductID", ProductID).AND("StartDate", StartDate);
            qry.Execute();
            return (true);
        }        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int ProductID,DateTime StartDate,DateTime? EndDate,decimal ListPrice,DateTime ModifiedDate)
	    {
		    ProductListPriceHistory item = new ProductListPriceHistory();
		    
            item.ProductID = ProductID;
            
            item.StartDate = StartDate;
            
            item.EndDate = EndDate;
            
            item.ListPrice = ListPrice;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int ProductID,DateTime StartDate,DateTime? EndDate,decimal ListPrice,DateTime ModifiedDate)
	    {
		    ProductListPriceHistory item = new ProductListPriceHistory();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.ProductID = ProductID;
				
			item.StartDate = StartDate;
				
			item.EndDate = EndDate;
				
			item.ListPrice = ListPrice;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
