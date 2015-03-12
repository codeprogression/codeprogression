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
    /// Controller class for EmployeeDepartmentHistory
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class EmployeeDepartmentHistoryController
    {
        // Preload our schema..
        EmployeeDepartmentHistory thisSchemaLoad = new EmployeeDepartmentHistory();
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
        public EmployeeDepartmentHistoryCollection FetchAll()
        {
            EmployeeDepartmentHistoryCollection coll = new EmployeeDepartmentHistoryCollection();
            Query qry = new Query(EmployeeDepartmentHistory.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public EmployeeDepartmentHistoryCollection FetchByID(object EmployeeID)
        {
            EmployeeDepartmentHistoryCollection coll = new EmployeeDepartmentHistoryCollection().Where("EmployeeID", EmployeeID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public EmployeeDepartmentHistoryCollection FetchByQuery(Query qry)
        {
            EmployeeDepartmentHistoryCollection coll = new EmployeeDepartmentHistoryCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object EmployeeID)
        {
            return (EmployeeDepartmentHistory.Delete(EmployeeID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object EmployeeID)
        {
            return (EmployeeDepartmentHistory.Destroy(EmployeeID) == 1);
        }
        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int EmployeeID,short DepartmentID,byte ShiftID,DateTime StartDate)
        {
            Query qry = new Query(EmployeeDepartmentHistory.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("EmployeeID", EmployeeID).AND("DepartmentID", DepartmentID).AND("ShiftID", ShiftID).AND("StartDate", StartDate);
            qry.Execute();
            return (true);
        }        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int EmployeeID,short DepartmentID,byte ShiftID,DateTime StartDate,DateTime? EndDate,DateTime ModifiedDate)
	    {
		    EmployeeDepartmentHistory item = new EmployeeDepartmentHistory();
		    
            item.EmployeeID = EmployeeID;
            
            item.DepartmentID = DepartmentID;
            
            item.ShiftID = ShiftID;
            
            item.StartDate = StartDate;
            
            item.EndDate = EndDate;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int EmployeeID,short DepartmentID,byte ShiftID,DateTime StartDate,DateTime? EndDate,DateTime ModifiedDate)
	    {
		    EmployeeDepartmentHistory item = new EmployeeDepartmentHistory();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.EmployeeID = EmployeeID;
				
			item.DepartmentID = DepartmentID;
				
			item.ShiftID = ShiftID;
				
			item.StartDate = StartDate;
				
			item.EndDate = EndDate;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
