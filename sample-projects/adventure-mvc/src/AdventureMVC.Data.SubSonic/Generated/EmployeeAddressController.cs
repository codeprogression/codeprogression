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
    /// Controller class for EmployeeAddress
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class EmployeeAddressController
    {
        // Preload our schema..
        EmployeeAddress thisSchemaLoad = new EmployeeAddress();
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
        public EmployeeAddressCollection FetchAll()
        {
            EmployeeAddressCollection coll = new EmployeeAddressCollection();
            Query qry = new Query(EmployeeAddress.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public EmployeeAddressCollection FetchByID(object EmployeeID)
        {
            EmployeeAddressCollection coll = new EmployeeAddressCollection().Where("EmployeeID", EmployeeID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public EmployeeAddressCollection FetchByQuery(Query qry)
        {
            EmployeeAddressCollection coll = new EmployeeAddressCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object EmployeeID)
        {
            return (EmployeeAddress.Delete(EmployeeID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object EmployeeID)
        {
            return (EmployeeAddress.Destroy(EmployeeID) == 1);
        }
        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int EmployeeID,int AddressID)
        {
            Query qry = new Query(EmployeeAddress.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("EmployeeID", EmployeeID).AND("AddressID", AddressID);
            qry.Execute();
            return (true);
        }        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int EmployeeID,int AddressID,Guid Rowguid,DateTime ModifiedDate)
	    {
		    EmployeeAddress item = new EmployeeAddress();
		    
            item.EmployeeID = EmployeeID;
            
            item.AddressID = AddressID;
            
            item.Rowguid = Rowguid;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int EmployeeID,int AddressID,Guid Rowguid,DateTime ModifiedDate)
	    {
		    EmployeeAddress item = new EmployeeAddress();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.EmployeeID = EmployeeID;
				
			item.AddressID = AddressID;
				
			item.Rowguid = Rowguid;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
