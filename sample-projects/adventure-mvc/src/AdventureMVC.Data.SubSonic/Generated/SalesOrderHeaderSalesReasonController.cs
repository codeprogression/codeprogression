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
    /// Controller class for SalesOrderHeaderSalesReason
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SalesOrderHeaderSalesReasonController
    {
        // Preload our schema..
        SalesOrderHeaderSalesReason thisSchemaLoad = new SalesOrderHeaderSalesReason();
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
        public SalesOrderHeaderSalesReasonCollection FetchAll()
        {
            SalesOrderHeaderSalesReasonCollection coll = new SalesOrderHeaderSalesReasonCollection();
            Query qry = new Query(SalesOrderHeaderSalesReason.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SalesOrderHeaderSalesReasonCollection FetchByID(object SalesOrderID)
        {
            SalesOrderHeaderSalesReasonCollection coll = new SalesOrderHeaderSalesReasonCollection().Where("SalesOrderID", SalesOrderID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SalesOrderHeaderSalesReasonCollection FetchByQuery(Query qry)
        {
            SalesOrderHeaderSalesReasonCollection coll = new SalesOrderHeaderSalesReasonCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object SalesOrderID)
        {
            return (SalesOrderHeaderSalesReason.Delete(SalesOrderID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object SalesOrderID)
        {
            return (SalesOrderHeaderSalesReason.Destroy(SalesOrderID) == 1);
        }
        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int SalesOrderID,int SalesReasonID)
        {
            Query qry = new Query(SalesOrderHeaderSalesReason.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("SalesOrderID", SalesOrderID).AND("SalesReasonID", SalesReasonID);
            qry.Execute();
            return (true);
        }        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int SalesOrderID,int SalesReasonID,DateTime ModifiedDate)
	    {
		    SalesOrderHeaderSalesReason item = new SalesOrderHeaderSalesReason();
		    
            item.SalesOrderID = SalesOrderID;
            
            item.SalesReasonID = SalesReasonID;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int SalesOrderID,int SalesReasonID,DateTime ModifiedDate)
	    {
		    SalesOrderHeaderSalesReason item = new SalesOrderHeaderSalesReason();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.SalesOrderID = SalesOrderID;
				
			item.SalesReasonID = SalesReasonID;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
