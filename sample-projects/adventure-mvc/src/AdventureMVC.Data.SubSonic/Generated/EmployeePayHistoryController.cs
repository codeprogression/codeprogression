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
    /// Controller class for EmployeePayHistory
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class EmployeePayHistoryController
    {
        // Preload our schema..
        EmployeePayHistory thisSchemaLoad = new EmployeePayHistory();
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
        public EmployeePayHistoryCollection FetchAll()
        {
            EmployeePayHistoryCollection coll = new EmployeePayHistoryCollection();
            Query qry = new Query(EmployeePayHistory.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public EmployeePayHistoryCollection FetchByID(object EmployeeID)
        {
            EmployeePayHistoryCollection coll = new EmployeePayHistoryCollection().Where("EmployeeID", EmployeeID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public EmployeePayHistoryCollection FetchByQuery(Query qry)
        {
            EmployeePayHistoryCollection coll = new EmployeePayHistoryCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object EmployeeID)
        {
            return (EmployeePayHistory.Delete(EmployeeID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object EmployeeID)
        {
            return (EmployeePayHistory.Destroy(EmployeeID) == 1);
        }
        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int EmployeeID,DateTime RateChangeDate)
        {
            Query qry = new Query(EmployeePayHistory.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("EmployeeID", EmployeeID).AND("RateChangeDate", RateChangeDate);
            qry.Execute();
            return (true);
        }        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int EmployeeID,DateTime RateChangeDate,decimal Rate,byte PayFrequency,DateTime ModifiedDate)
	    {
		    EmployeePayHistory item = new EmployeePayHistory();
		    
            item.EmployeeID = EmployeeID;
            
            item.RateChangeDate = RateChangeDate;
            
            item.Rate = Rate;
            
            item.PayFrequency = PayFrequency;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int EmployeeID,DateTime RateChangeDate,decimal Rate,byte PayFrequency,DateTime ModifiedDate)
	    {
		    EmployeePayHistory item = new EmployeePayHistory();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.EmployeeID = EmployeeID;
				
			item.RateChangeDate = RateChangeDate;
				
			item.Rate = Rate;
				
			item.PayFrequency = PayFrequency;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
