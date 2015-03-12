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
    /// Controller class for WorkOrder
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class WorkOrderController
    {
        // Preload our schema..
        WorkOrder thisSchemaLoad = new WorkOrder();
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
        public WorkOrderCollection FetchAll()
        {
            WorkOrderCollection coll = new WorkOrderCollection();
            Query qry = new Query(WorkOrder.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public WorkOrderCollection FetchByID(object WorkOrderID)
        {
            WorkOrderCollection coll = new WorkOrderCollection().Where("WorkOrderID", WorkOrderID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public WorkOrderCollection FetchByQuery(Query qry)
        {
            WorkOrderCollection coll = new WorkOrderCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object WorkOrderID)
        {
            return (WorkOrder.Delete(WorkOrderID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object WorkOrderID)
        {
            return (WorkOrder.Destroy(WorkOrderID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int ProductID,int OrderQty,int StockedQty,short ScrappedQty,DateTime StartDate,DateTime? EndDate,DateTime DueDate,short? ScrapReasonID,DateTime ModifiedDate)
	    {
		    WorkOrder item = new WorkOrder();
		    
            item.ProductID = ProductID;
            
            item.OrderQty = OrderQty;
            
            item.StockedQty = StockedQty;
            
            item.ScrappedQty = ScrappedQty;
            
            item.StartDate = StartDate;
            
            item.EndDate = EndDate;
            
            item.DueDate = DueDate;
            
            item.ScrapReasonID = ScrapReasonID;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int WorkOrderID,int ProductID,int OrderQty,int StockedQty,short ScrappedQty,DateTime StartDate,DateTime? EndDate,DateTime DueDate,short? ScrapReasonID,DateTime ModifiedDate)
	    {
		    WorkOrder item = new WorkOrder();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.WorkOrderID = WorkOrderID;
				
			item.ProductID = ProductID;
				
			item.OrderQty = OrderQty;
				
			item.StockedQty = StockedQty;
				
			item.ScrappedQty = ScrappedQty;
				
			item.StartDate = StartDate;
				
			item.EndDate = EndDate;
				
			item.DueDate = DueDate;
				
			item.ScrapReasonID = ScrapReasonID;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
