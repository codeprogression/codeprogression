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
    /// Controller class for VendorContact
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class VendorContactController
    {
        // Preload our schema..
        VendorContact thisSchemaLoad = new VendorContact();
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
        public VendorContactCollection FetchAll()
        {
            VendorContactCollection coll = new VendorContactCollection();
            Query qry = new Query(VendorContact.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public VendorContactCollection FetchByID(object VendorID)
        {
            VendorContactCollection coll = new VendorContactCollection().Where("VendorID", VendorID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public VendorContactCollection FetchByQuery(Query qry)
        {
            VendorContactCollection coll = new VendorContactCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object VendorID)
        {
            return (VendorContact.Delete(VendorID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object VendorID)
        {
            return (VendorContact.Destroy(VendorID) == 1);
        }
        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int VendorID,int ContactID)
        {
            Query qry = new Query(VendorContact.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("VendorID", VendorID).AND("ContactID", ContactID);
            qry.Execute();
            return (true);
        }        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int VendorID,int ContactID,int ContactTypeID,DateTime ModifiedDate)
	    {
		    VendorContact item = new VendorContact();
		    
            item.VendorID = VendorID;
            
            item.ContactID = ContactID;
            
            item.ContactTypeID = ContactTypeID;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int VendorID,int ContactID,int ContactTypeID,DateTime ModifiedDate)
	    {
		    VendorContact item = new VendorContact();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.VendorID = VendorID;
				
			item.ContactID = ContactID;
				
			item.ContactTypeID = ContactTypeID;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
