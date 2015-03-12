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
    /// Controller class for SalesPersonQuotaHistory
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SalesPersonQuotaHistoryController
    {
        // Preload our schema..
        SalesPersonQuotaHistory thisSchemaLoad = new SalesPersonQuotaHistory();
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
        public SalesPersonQuotaHistoryCollection FetchAll()
        {
            SalesPersonQuotaHistoryCollection coll = new SalesPersonQuotaHistoryCollection();
            Query qry = new Query(SalesPersonQuotaHistory.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SalesPersonQuotaHistoryCollection FetchByID(object SalesPersonID)
        {
            SalesPersonQuotaHistoryCollection coll = new SalesPersonQuotaHistoryCollection().Where("SalesPersonID", SalesPersonID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SalesPersonQuotaHistoryCollection FetchByQuery(Query qry)
        {
            SalesPersonQuotaHistoryCollection coll = new SalesPersonQuotaHistoryCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object SalesPersonID)
        {
            return (SalesPersonQuotaHistory.Delete(SalesPersonID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object SalesPersonID)
        {
            return (SalesPersonQuotaHistory.Destroy(SalesPersonID) == 1);
        }
        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int SalesPersonID,DateTime QuotaDate)
        {
            Query qry = new Query(SalesPersonQuotaHistory.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("SalesPersonID", SalesPersonID).AND("QuotaDate", QuotaDate);
            qry.Execute();
            return (true);
        }        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int SalesPersonID,DateTime QuotaDate,decimal SalesQuota,Guid Rowguid,DateTime ModifiedDate)
	    {
		    SalesPersonQuotaHistory item = new SalesPersonQuotaHistory();
		    
            item.SalesPersonID = SalesPersonID;
            
            item.QuotaDate = QuotaDate;
            
            item.SalesQuota = SalesQuota;
            
            item.Rowguid = Rowguid;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int SalesPersonID,DateTime QuotaDate,decimal SalesQuota,Guid Rowguid,DateTime ModifiedDate)
	    {
		    SalesPersonQuotaHistory item = new SalesPersonQuotaHistory();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.SalesPersonID = SalesPersonID;
				
			item.QuotaDate = QuotaDate;
				
			item.SalesQuota = SalesQuota;
				
			item.Rowguid = Rowguid;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
