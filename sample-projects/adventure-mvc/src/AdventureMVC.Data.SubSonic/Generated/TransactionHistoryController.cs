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
    /// Controller class for TransactionHistory
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class TransactionHistoryController
    {
        // Preload our schema..
        TransactionHistory thisSchemaLoad = new TransactionHistory();
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
        public TransactionHistoryCollection FetchAll()
        {
            TransactionHistoryCollection coll = new TransactionHistoryCollection();
            Query qry = new Query(TransactionHistory.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TransactionHistoryCollection FetchByID(object TransactionID)
        {
            TransactionHistoryCollection coll = new TransactionHistoryCollection().Where("TransactionID", TransactionID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public TransactionHistoryCollection FetchByQuery(Query qry)
        {
            TransactionHistoryCollection coll = new TransactionHistoryCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object TransactionID)
        {
            return (TransactionHistory.Delete(TransactionID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object TransactionID)
        {
            return (TransactionHistory.Destroy(TransactionID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int ProductID,int ReferenceOrderID,int ReferenceOrderLineID,DateTime TransactionDate,string TransactionType,int Quantity,decimal ActualCost,DateTime ModifiedDate)
	    {
		    TransactionHistory item = new TransactionHistory();
		    
            item.ProductID = ProductID;
            
            item.ReferenceOrderID = ReferenceOrderID;
            
            item.ReferenceOrderLineID = ReferenceOrderLineID;
            
            item.TransactionDate = TransactionDate;
            
            item.TransactionType = TransactionType;
            
            item.Quantity = Quantity;
            
            item.ActualCost = ActualCost;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int TransactionID,int ProductID,int ReferenceOrderID,int ReferenceOrderLineID,DateTime TransactionDate,string TransactionType,int Quantity,decimal ActualCost,DateTime ModifiedDate)
	    {
		    TransactionHistory item = new TransactionHistory();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.TransactionID = TransactionID;
				
			item.ProductID = ProductID;
				
			item.ReferenceOrderID = ReferenceOrderID;
				
			item.ReferenceOrderLineID = ReferenceOrderLineID;
				
			item.TransactionDate = TransactionDate;
				
			item.TransactionType = TransactionType;
				
			item.Quantity = Quantity;
				
			item.ActualCost = ActualCost;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
