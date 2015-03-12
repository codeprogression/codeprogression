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
    /// Controller class for PurchaseOrderDetail
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PurchaseOrderDetailController
    {
        // Preload our schema..
        PurchaseOrderDetail thisSchemaLoad = new PurchaseOrderDetail();
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
        public PurchaseOrderDetailCollection FetchAll()
        {
            PurchaseOrderDetailCollection coll = new PurchaseOrderDetailCollection();
            Query qry = new Query(PurchaseOrderDetail.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PurchaseOrderDetailCollection FetchByID(object PurchaseOrderID)
        {
            PurchaseOrderDetailCollection coll = new PurchaseOrderDetailCollection().Where("PurchaseOrderID", PurchaseOrderID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PurchaseOrderDetailCollection FetchByQuery(Query qry)
        {
            PurchaseOrderDetailCollection coll = new PurchaseOrderDetailCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object PurchaseOrderID)
        {
            return (PurchaseOrderDetail.Delete(PurchaseOrderID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object PurchaseOrderID)
        {
            return (PurchaseOrderDetail.Destroy(PurchaseOrderID) == 1);
        }
        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int PurchaseOrderID,int PurchaseOrderDetailID)
        {
            Query qry = new Query(PurchaseOrderDetail.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("PurchaseOrderID", PurchaseOrderID).AND("PurchaseOrderDetailID", PurchaseOrderDetailID);
            qry.Execute();
            return (true);
        }        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int PurchaseOrderID,DateTime DueDate,short OrderQty,int ProductID,decimal UnitPrice,decimal LineTotal,decimal ReceivedQty,decimal RejectedQty,decimal StockedQty,DateTime ModifiedDate)
	    {
		    PurchaseOrderDetail item = new PurchaseOrderDetail();
		    
            item.PurchaseOrderID = PurchaseOrderID;
            
            item.DueDate = DueDate;
            
            item.OrderQty = OrderQty;
            
            item.ProductID = ProductID;
            
            item.UnitPrice = UnitPrice;
            
            item.LineTotal = LineTotal;
            
            item.ReceivedQty = ReceivedQty;
            
            item.RejectedQty = RejectedQty;
            
            item.StockedQty = StockedQty;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int PurchaseOrderID,int PurchaseOrderDetailID,DateTime DueDate,short OrderQty,int ProductID,decimal UnitPrice,decimal LineTotal,decimal ReceivedQty,decimal RejectedQty,decimal StockedQty,DateTime ModifiedDate)
	    {
		    PurchaseOrderDetail item = new PurchaseOrderDetail();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.PurchaseOrderID = PurchaseOrderID;
				
			item.PurchaseOrderDetailID = PurchaseOrderDetailID;
				
			item.DueDate = DueDate;
				
			item.OrderQty = OrderQty;
				
			item.ProductID = ProductID;
				
			item.UnitPrice = UnitPrice;
				
			item.LineTotal = LineTotal;
				
			item.ReceivedQty = ReceivedQty;
				
			item.RejectedQty = RejectedQty;
				
			item.StockedQty = StockedQty;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
