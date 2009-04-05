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
    /// Controller class for ContactCreditCard
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ContactCreditCardController
    {
        // Preload our schema..
        ContactCreditCard thisSchemaLoad = new ContactCreditCard();
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
        public ContactCreditCardCollection FetchAll()
        {
            ContactCreditCardCollection coll = new ContactCreditCardCollection();
            Query qry = new Query(ContactCreditCard.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ContactCreditCardCollection FetchByID(object ContactID)
        {
            ContactCreditCardCollection coll = new ContactCreditCardCollection().Where("ContactID", ContactID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ContactCreditCardCollection FetchByQuery(Query qry)
        {
            ContactCreditCardCollection coll = new ContactCreditCardCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ContactID)
        {
            return (ContactCreditCard.Delete(ContactID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ContactID)
        {
            return (ContactCreditCard.Destroy(ContactID) == 1);
        }
        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int ContactID,int CreditCardID)
        {
            Query qry = new Query(ContactCreditCard.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("ContactID", ContactID).AND("CreditCardID", CreditCardID);
            qry.Execute();
            return (true);
        }        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int ContactID,int CreditCardID,DateTime ModifiedDate)
	    {
		    ContactCreditCard item = new ContactCreditCard();
		    
            item.ContactID = ContactID;
            
            item.CreditCardID = CreditCardID;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int ContactID,int CreditCardID,DateTime ModifiedDate)
	    {
		    ContactCreditCard item = new ContactCreditCard();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.ContactID = ContactID;
				
			item.CreditCardID = CreditCardID;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
