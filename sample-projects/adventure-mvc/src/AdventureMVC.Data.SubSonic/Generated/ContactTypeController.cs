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
    /// Controller class for ContactType
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ContactTypeController
    {
        // Preload our schema..
        ContactType thisSchemaLoad = new ContactType();
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
        public ContactTypeCollection FetchAll()
        {
            ContactTypeCollection coll = new ContactTypeCollection();
            Query qry = new Query(ContactType.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ContactTypeCollection FetchByID(object ContactTypeID)
        {
            ContactTypeCollection coll = new ContactTypeCollection().Where("ContactTypeID", ContactTypeID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ContactTypeCollection FetchByQuery(Query qry)
        {
            ContactTypeCollection coll = new ContactTypeCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ContactTypeID)
        {
            return (ContactType.Delete(ContactTypeID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ContactTypeID)
        {
            return (ContactType.Destroy(ContactTypeID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Name,DateTime ModifiedDate)
	    {
		    ContactType item = new ContactType();
		    
            item.Name = Name;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int ContactTypeID,string Name,DateTime ModifiedDate)
	    {
		    ContactType item = new ContactType();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.ContactTypeID = ContactTypeID;
				
			item.Name = Name;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
