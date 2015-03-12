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
    /// Controller class for StoreContact
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class StoreContactController
    {
        // Preload our schema..
        StoreContact thisSchemaLoad = new StoreContact();
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
        public StoreContactCollection FetchAll()
        {
            StoreContactCollection coll = new StoreContactCollection();
            Query qry = new Query(StoreContact.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public StoreContactCollection FetchByID(object CustomerID)
        {
            StoreContactCollection coll = new StoreContactCollection().Where("CustomerID", CustomerID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public StoreContactCollection FetchByQuery(Query qry)
        {
            StoreContactCollection coll = new StoreContactCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object CustomerID)
        {
            return (StoreContact.Delete(CustomerID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object CustomerID)
        {
            return (StoreContact.Destroy(CustomerID) == 1);
        }
        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int CustomerID,int ContactID)
        {
            Query qry = new Query(StoreContact.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("CustomerID", CustomerID).AND("ContactID", ContactID);
            qry.Execute();
            return (true);
        }        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int CustomerID,int ContactID,int ContactTypeID,Guid Rowguid,DateTime ModifiedDate)
	    {
		    StoreContact item = new StoreContact();
		    
            item.CustomerID = CustomerID;
            
            item.ContactID = ContactID;
            
            item.ContactTypeID = ContactTypeID;
            
            item.Rowguid = Rowguid;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int CustomerID,int ContactID,int ContactTypeID,Guid Rowguid,DateTime ModifiedDate)
	    {
		    StoreContact item = new StoreContact();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.CustomerID = CustomerID;
				
			item.ContactID = ContactID;
				
			item.ContactTypeID = ContactTypeID;
				
			item.Rowguid = Rowguid;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
