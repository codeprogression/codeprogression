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
    /// Controller class for Contact
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ContactController
    {
        // Preload our schema..
        Contact thisSchemaLoad = new Contact();
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
        public ContactCollection FetchAll()
        {
            ContactCollection coll = new ContactCollection();
            Query qry = new Query(Contact.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ContactCollection FetchByID(object ContactID)
        {
            ContactCollection coll = new ContactCollection().Where("ContactID", ContactID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ContactCollection FetchByQuery(Query qry)
        {
            ContactCollection coll = new ContactCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ContactID)
        {
            return (Contact.Delete(ContactID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ContactID)
        {
            return (Contact.Destroy(ContactID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(bool NameStyle,string Title,string FirstName,string MiddleName,string LastName,string Suffix,string EmailAddress,int EmailPromotion,string Phone,string PasswordHash,string PasswordSalt,string AdditionalContactInfo,Guid Rowguid,DateTime ModifiedDate)
	    {
		    Contact item = new Contact();
		    
            item.NameStyle = NameStyle;
            
            item.Title = Title;
            
            item.FirstName = FirstName;
            
            item.MiddleName = MiddleName;
            
            item.LastName = LastName;
            
            item.Suffix = Suffix;
            
            item.EmailAddress = EmailAddress;
            
            item.EmailPromotion = EmailPromotion;
            
            item.Phone = Phone;
            
            item.PasswordHash = PasswordHash;
            
            item.PasswordSalt = PasswordSalt;
            
            item.AdditionalContactInfo = AdditionalContactInfo;
            
            item.Rowguid = Rowguid;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int ContactID,bool NameStyle,string Title,string FirstName,string MiddleName,string LastName,string Suffix,string EmailAddress,int EmailPromotion,string Phone,string PasswordHash,string PasswordSalt,string AdditionalContactInfo,Guid Rowguid,DateTime ModifiedDate)
	    {
		    Contact item = new Contact();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.ContactID = ContactID;
				
			item.NameStyle = NameStyle;
				
			item.Title = Title;
				
			item.FirstName = FirstName;
				
			item.MiddleName = MiddleName;
				
			item.LastName = LastName;
				
			item.Suffix = Suffix;
				
			item.EmailAddress = EmailAddress;
				
			item.EmailPromotion = EmailPromotion;
				
			item.Phone = Phone;
				
			item.PasswordHash = PasswordHash;
				
			item.PasswordSalt = PasswordSalt;
				
			item.AdditionalContactInfo = AdditionalContactInfo;
				
			item.Rowguid = Rowguid;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
