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
    /// Controller class for ShipMethod
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ShipMethodController
    {
        // Preload our schema..
        ShipMethod thisSchemaLoad = new ShipMethod();
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
        public ShipMethodCollection FetchAll()
        {
            ShipMethodCollection coll = new ShipMethodCollection();
            Query qry = new Query(ShipMethod.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ShipMethodCollection FetchByID(object ShipMethodID)
        {
            ShipMethodCollection coll = new ShipMethodCollection().Where("ShipMethodID", ShipMethodID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ShipMethodCollection FetchByQuery(Query qry)
        {
            ShipMethodCollection coll = new ShipMethodCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ShipMethodID)
        {
            return (ShipMethod.Delete(ShipMethodID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ShipMethodID)
        {
            return (ShipMethod.Destroy(ShipMethodID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Name,decimal ShipBase,decimal ShipRate,Guid Rowguid,DateTime ModifiedDate)
	    {
		    ShipMethod item = new ShipMethod();
		    
            item.Name = Name;
            
            item.ShipBase = ShipBase;
            
            item.ShipRate = ShipRate;
            
            item.Rowguid = Rowguid;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int ShipMethodID,string Name,decimal ShipBase,decimal ShipRate,Guid Rowguid,DateTime ModifiedDate)
	    {
		    ShipMethod item = new ShipMethod();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.ShipMethodID = ShipMethodID;
				
			item.Name = Name;
				
			item.ShipBase = ShipBase;
				
			item.ShipRate = ShipRate;
				
			item.Rowguid = Rowguid;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
