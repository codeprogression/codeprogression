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
    /// Controller class for CustomerAddress
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class CustomerAddressController
    {
        // Preload our schema..
        CustomerAddress thisSchemaLoad = new CustomerAddress();
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
        public CustomerAddressCollection FetchAll()
        {
            CustomerAddressCollection coll = new CustomerAddressCollection();
            Query qry = new Query(CustomerAddress.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CustomerAddressCollection FetchByID(object CustomerID)
        {
            CustomerAddressCollection coll = new CustomerAddressCollection().Where("CustomerID", CustomerID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public CustomerAddressCollection FetchByQuery(Query qry)
        {
            CustomerAddressCollection coll = new CustomerAddressCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object CustomerID)
        {
            return (CustomerAddress.Delete(CustomerID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object CustomerID)
        {
            return (CustomerAddress.Destroy(CustomerID) == 1);
        }
        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int CustomerID,int AddressID)
        {
            Query qry = new Query(CustomerAddress.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("CustomerID", CustomerID).AND("AddressID", AddressID);
            qry.Execute();
            return (true);
        }        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int CustomerID,int AddressID,int AddressTypeID,Guid Rowguid,DateTime ModifiedDate)
	    {
		    CustomerAddress item = new CustomerAddress();
		    
            item.CustomerID = CustomerID;
            
            item.AddressID = AddressID;
            
            item.AddressTypeID = AddressTypeID;
            
            item.Rowguid = Rowguid;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int CustomerID,int AddressID,int AddressTypeID,Guid Rowguid,DateTime ModifiedDate)
	    {
		    CustomerAddress item = new CustomerAddress();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.CustomerID = CustomerID;
				
			item.AddressID = AddressID;
				
			item.AddressTypeID = AddressTypeID;
				
			item.Rowguid = Rowguid;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
