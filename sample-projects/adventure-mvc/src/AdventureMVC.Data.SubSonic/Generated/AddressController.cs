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
    /// Controller class for Address
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AddressController
    {
        // Preload our schema..
        Address thisSchemaLoad = new Address();
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
        public AddressCollection FetchAll()
        {
            AddressCollection coll = new AddressCollection();
            Query qry = new Query(Address.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AddressCollection FetchByID(object AddressID)
        {
            AddressCollection coll = new AddressCollection().Where("AddressID", AddressID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AddressCollection FetchByQuery(Query qry)
        {
            AddressCollection coll = new AddressCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object AddressID)
        {
            return (Address.Delete(AddressID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object AddressID)
        {
            return (Address.Destroy(AddressID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string AddressLine1,string AddressLine2,string City,int StateProvinceID,string PostalCode,Guid Rowguid,DateTime ModifiedDate)
	    {
		    Address item = new Address();
		    
            item.AddressLine1 = AddressLine1;
            
            item.AddressLine2 = AddressLine2;
            
            item.City = City;
            
            item.StateProvinceID = StateProvinceID;
            
            item.PostalCode = PostalCode;
            
            item.Rowguid = Rowguid;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int AddressID,string AddressLine1,string AddressLine2,string City,int StateProvinceID,string PostalCode,Guid Rowguid,DateTime ModifiedDate)
	    {
		    Address item = new Address();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.AddressID = AddressID;
				
			item.AddressLine1 = AddressLine1;
				
			item.AddressLine2 = AddressLine2;
				
			item.City = City;
				
			item.StateProvinceID = StateProvinceID;
				
			item.PostalCode = PostalCode;
				
			item.Rowguid = Rowguid;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
