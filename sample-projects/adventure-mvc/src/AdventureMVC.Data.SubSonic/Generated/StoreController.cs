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
    /// Controller class for Store
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class StoreController
    {
        // Preload our schema..
        Store thisSchemaLoad = new Store();
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
        public StoreCollection FetchAll()
        {
            StoreCollection coll = new StoreCollection();
            Query qry = new Query(Store.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public StoreCollection FetchByID(object CustomerID)
        {
            StoreCollection coll = new StoreCollection().Where("CustomerID", CustomerID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public StoreCollection FetchByQuery(Query qry)
        {
            StoreCollection coll = new StoreCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object CustomerID)
        {
            return (Store.Delete(CustomerID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object CustomerID)
        {
            return (Store.Destroy(CustomerID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int CustomerID,string Name,int? SalesPersonID,string Demographics,Guid Rowguid,DateTime ModifiedDate)
	    {
		    Store item = new Store();
		    
            item.CustomerID = CustomerID;
            
            item.Name = Name;
            
            item.SalesPersonID = SalesPersonID;
            
            item.Demographics = Demographics;
            
            item.Rowguid = Rowguid;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int CustomerID,string Name,int? SalesPersonID,string Demographics,Guid Rowguid,DateTime ModifiedDate)
	    {
		    Store item = new Store();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.CustomerID = CustomerID;
				
			item.Name = Name;
				
			item.SalesPersonID = SalesPersonID;
				
			item.Demographics = Demographics;
				
			item.Rowguid = Rowguid;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
