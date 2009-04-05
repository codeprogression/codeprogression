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
    /// Controller class for VendorAddress
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class VendorAddressController
    {
        // Preload our schema..
        VendorAddress thisSchemaLoad = new VendorAddress();
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
        public VendorAddressCollection FetchAll()
        {
            VendorAddressCollection coll = new VendorAddressCollection();
            Query qry = new Query(VendorAddress.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public VendorAddressCollection FetchByID(object VendorID)
        {
            VendorAddressCollection coll = new VendorAddressCollection().Where("VendorID", VendorID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public VendorAddressCollection FetchByQuery(Query qry)
        {
            VendorAddressCollection coll = new VendorAddressCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object VendorID)
        {
            return (VendorAddress.Delete(VendorID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object VendorID)
        {
            return (VendorAddress.Destroy(VendorID) == 1);
        }
        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int VendorID,int AddressID)
        {
            Query qry = new Query(VendorAddress.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("VendorID", VendorID).AND("AddressID", AddressID);
            qry.Execute();
            return (true);
        }        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int VendorID,int AddressID,int AddressTypeID,DateTime ModifiedDate)
	    {
		    VendorAddress item = new VendorAddress();
		    
            item.VendorID = VendorID;
            
            item.AddressID = AddressID;
            
            item.AddressTypeID = AddressTypeID;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int VendorID,int AddressID,int AddressTypeID,DateTime ModifiedDate)
	    {
		    VendorAddress item = new VendorAddress();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.VendorID = VendorID;
				
			item.AddressID = AddressID;
				
			item.AddressTypeID = AddressTypeID;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
