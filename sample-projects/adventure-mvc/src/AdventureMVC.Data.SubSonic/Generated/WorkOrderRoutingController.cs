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
    /// Controller class for WorkOrderRouting
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class WorkOrderRoutingController
    {
        // Preload our schema..
        WorkOrderRouting thisSchemaLoad = new WorkOrderRouting();
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
        public WorkOrderRoutingCollection FetchAll()
        {
            WorkOrderRoutingCollection coll = new WorkOrderRoutingCollection();
            Query qry = new Query(WorkOrderRouting.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public WorkOrderRoutingCollection FetchByID(object WorkOrderID)
        {
            WorkOrderRoutingCollection coll = new WorkOrderRoutingCollection().Where("WorkOrderID", WorkOrderID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public WorkOrderRoutingCollection FetchByQuery(Query qry)
        {
            WorkOrderRoutingCollection coll = new WorkOrderRoutingCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object WorkOrderID)
        {
            return (WorkOrderRouting.Delete(WorkOrderID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object WorkOrderID)
        {
            return (WorkOrderRouting.Destroy(WorkOrderID) == 1);
        }
        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int WorkOrderID,int ProductID,short OperationSequence)
        {
            Query qry = new Query(WorkOrderRouting.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("WorkOrderID", WorkOrderID).AND("ProductID", ProductID).AND("OperationSequence", OperationSequence);
            qry.Execute();
            return (true);
        }        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int WorkOrderID,int ProductID,short OperationSequence,short LocationID,DateTime ScheduledStartDate,DateTime ScheduledEndDate,DateTime? ActualStartDate,DateTime? ActualEndDate,decimal? ActualResourceHrs,decimal PlannedCost,decimal? ActualCost,DateTime ModifiedDate)
	    {
		    WorkOrderRouting item = new WorkOrderRouting();
		    
            item.WorkOrderID = WorkOrderID;
            
            item.ProductID = ProductID;
            
            item.OperationSequence = OperationSequence;
            
            item.LocationID = LocationID;
            
            item.ScheduledStartDate = ScheduledStartDate;
            
            item.ScheduledEndDate = ScheduledEndDate;
            
            item.ActualStartDate = ActualStartDate;
            
            item.ActualEndDate = ActualEndDate;
            
            item.ActualResourceHrs = ActualResourceHrs;
            
            item.PlannedCost = PlannedCost;
            
            item.ActualCost = ActualCost;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int WorkOrderID,int ProductID,short OperationSequence,short LocationID,DateTime ScheduledStartDate,DateTime ScheduledEndDate,DateTime? ActualStartDate,DateTime? ActualEndDate,decimal? ActualResourceHrs,decimal PlannedCost,decimal? ActualCost,DateTime ModifiedDate)
	    {
		    WorkOrderRouting item = new WorkOrderRouting();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.WorkOrderID = WorkOrderID;
				
			item.ProductID = ProductID;
				
			item.OperationSequence = OperationSequence;
				
			item.LocationID = LocationID;
				
			item.ScheduledStartDate = ScheduledStartDate;
				
			item.ScheduledEndDate = ScheduledEndDate;
				
			item.ActualStartDate = ActualStartDate;
				
			item.ActualEndDate = ActualEndDate;
				
			item.ActualResourceHrs = ActualResourceHrs;
				
			item.PlannedCost = PlannedCost;
				
			item.ActualCost = ActualCost;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
