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
    /// Controller class for Customer
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class CustomerController
    {
        // Preload our schema..
        Customer thisSchemaLoad = new Customer();
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
        public CustomerCollection FetchAll()
        {
            CustomerCollection coll = new CustomerCollection();
            Query qry = new Query(Customer.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CustomerCollection FetchByID(object CustomerID)
        {
            CustomerCollection coll = new CustomerCollection().Where("CustomerID", CustomerID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public CustomerCollection FetchByQuery(Query qry)
        {
            CustomerCollection coll = new CustomerCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object CustomerID)
        {
            return (Customer.Delete(CustomerID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object CustomerID)
        {
            return (Customer.Destroy(CustomerID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? TerritoryID,string AccountNumber,string CustomerType,Guid Rowguid,DateTime ModifiedDate)
	    {
		    Customer item = new Customer();
		    
            item.TerritoryID = TerritoryID;
            
            item.AccountNumber = AccountNumber;
            
            item.CustomerType = CustomerType;
            
            item.Rowguid = Rowguid;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int CustomerID,int? TerritoryID,string AccountNumber,string CustomerType,Guid Rowguid,DateTime ModifiedDate)
	    {
		    Customer item = new Customer();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.CustomerID = CustomerID;
				
			item.TerritoryID = TerritoryID;
				
			item.AccountNumber = AccountNumber;
				
			item.CustomerType = CustomerType;
				
			item.Rowguid = Rowguid;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
