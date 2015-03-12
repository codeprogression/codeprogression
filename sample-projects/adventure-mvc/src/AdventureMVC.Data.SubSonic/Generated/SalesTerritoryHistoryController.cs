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
    /// Controller class for SalesTerritoryHistory
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SalesTerritoryHistoryController
    {
        // Preload our schema..
        SalesTerritoryHistory thisSchemaLoad = new SalesTerritoryHistory();
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
        public SalesTerritoryHistoryCollection FetchAll()
        {
            SalesTerritoryHistoryCollection coll = new SalesTerritoryHistoryCollection();
            Query qry = new Query(SalesTerritoryHistory.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SalesTerritoryHistoryCollection FetchByID(object SalesPersonID)
        {
            SalesTerritoryHistoryCollection coll = new SalesTerritoryHistoryCollection().Where("SalesPersonID", SalesPersonID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SalesTerritoryHistoryCollection FetchByQuery(Query qry)
        {
            SalesTerritoryHistoryCollection coll = new SalesTerritoryHistoryCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object SalesPersonID)
        {
            return (SalesTerritoryHistory.Delete(SalesPersonID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object SalesPersonID)
        {
            return (SalesTerritoryHistory.Destroy(SalesPersonID) == 1);
        }
        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int SalesPersonID,int TerritoryID,DateTime StartDate)
        {
            Query qry = new Query(SalesTerritoryHistory.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("SalesPersonID", SalesPersonID).AND("TerritoryID", TerritoryID).AND("StartDate", StartDate);
            qry.Execute();
            return (true);
        }        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int SalesPersonID,int TerritoryID,DateTime StartDate,DateTime? EndDate,Guid Rowguid,DateTime ModifiedDate)
	    {
		    SalesTerritoryHistory item = new SalesTerritoryHistory();
		    
            item.SalesPersonID = SalesPersonID;
            
            item.TerritoryID = TerritoryID;
            
            item.StartDate = StartDate;
            
            item.EndDate = EndDate;
            
            item.Rowguid = Rowguid;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int SalesPersonID,int TerritoryID,DateTime StartDate,DateTime? EndDate,Guid Rowguid,DateTime ModifiedDate)
	    {
		    SalesTerritoryHistory item = new SalesTerritoryHistory();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.SalesPersonID = SalesPersonID;
				
			item.TerritoryID = TerritoryID;
				
			item.StartDate = StartDate;
				
			item.EndDate = EndDate;
				
			item.Rowguid = Rowguid;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
