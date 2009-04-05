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
    /// Controller class for TransactionHistoryArchive
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class TransactionHistoryArchiveController
    {
        // Preload our schema..
        TransactionHistoryArchive thisSchemaLoad = new TransactionHistoryArchive();
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
        public TransactionHistoryArchiveCollection FetchAll()
        {
            TransactionHistoryArchiveCollection coll = new TransactionHistoryArchiveCollection();
            Query qry = new Query(TransactionHistoryArchive.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TransactionHistoryArchiveCollection FetchByID(object TransactionID)
        {
            TransactionHistoryArchiveCollection coll = new TransactionHistoryArchiveCollection().Where("TransactionID", TransactionID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public TransactionHistoryArchiveCollection FetchByQuery(Query qry)
        {
            TransactionHistoryArchiveCollection coll = new TransactionHistoryArchiveCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object TransactionID)
        {
            return (TransactionHistoryArchive.Delete(TransactionID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object TransactionID)
        {
            return (TransactionHistoryArchive.Destroy(TransactionID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int TransactionID,int ProductID,int ReferenceOrderID,int ReferenceOrderLineID,DateTime TransactionDate,string TransactionType,int Quantity,decimal ActualCost,DateTime ModifiedDate)
	    {
		    TransactionHistoryArchive item = new TransactionHistoryArchive();
		    
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
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int TransactionID,int ProductID,int ReferenceOrderID,int ReferenceOrderLineID,DateTime TransactionDate,string TransactionType,int Quantity,decimal ActualCost,DateTime ModifiedDate)
	    {
		    TransactionHistoryArchive item = new TransactionHistoryArchive();
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
