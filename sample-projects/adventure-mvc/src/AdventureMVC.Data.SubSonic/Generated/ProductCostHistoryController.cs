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
    /// Controller class for ProductCostHistory
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ProductCostHistoryController
    {
        // Preload our schema..
        ProductCostHistory thisSchemaLoad = new ProductCostHistory();
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
        public ProductCostHistoryCollection FetchAll()
        {
            ProductCostHistoryCollection coll = new ProductCostHistoryCollection();
            Query qry = new Query(ProductCostHistory.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductCostHistoryCollection FetchByID(object ProductID)
        {
            ProductCostHistoryCollection coll = new ProductCostHistoryCollection().Where("ProductID", ProductID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductCostHistoryCollection FetchByQuery(Query qry)
        {
            ProductCostHistoryCollection coll = new ProductCostHistoryCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ProductID)
        {
            return (ProductCostHistory.Delete(ProductID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ProductID)
        {
            return (ProductCostHistory.Destroy(ProductID) == 1);
        }
        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int ProductID,DateTime StartDate)
        {
            Query qry = new Query(ProductCostHistory.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("ProductID", ProductID).AND("StartDate", StartDate);
            qry.Execute();
            return (true);
        }        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int ProductID,DateTime StartDate,DateTime? EndDate,decimal StandardCost,DateTime ModifiedDate)
	    {
		    ProductCostHistory item = new ProductCostHistory();
		    
            item.ProductID = ProductID;
            
            item.StartDate = StartDate;
            
            item.EndDate = EndDate;
            
            item.StandardCost = StandardCost;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int ProductID,DateTime StartDate,DateTime? EndDate,decimal StandardCost,DateTime ModifiedDate)
	    {
		    ProductCostHistory item = new ProductCostHistory();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.ProductID = ProductID;
				
			item.StartDate = StartDate;
				
			item.EndDate = EndDate;
				
			item.StandardCost = StandardCost;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
