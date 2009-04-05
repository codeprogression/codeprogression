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
    /// Controller class for Location
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class LocationController
    {
        // Preload our schema..
        Location thisSchemaLoad = new Location();
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
        public LocationCollection FetchAll()
        {
            LocationCollection coll = new LocationCollection();
            Query qry = new Query(Location.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public LocationCollection FetchByID(object LocationID)
        {
            LocationCollection coll = new LocationCollection().Where("LocationID", LocationID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public LocationCollection FetchByQuery(Query qry)
        {
            LocationCollection coll = new LocationCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object LocationID)
        {
            return (Location.Delete(LocationID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object LocationID)
        {
            return (Location.Destroy(LocationID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Name,decimal CostRate,decimal Availability,DateTime ModifiedDate)
	    {
		    Location item = new Location();
		    
            item.Name = Name;
            
            item.CostRate = CostRate;
            
            item.Availability = Availability;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(short LocationID,string Name,decimal CostRate,decimal Availability,DateTime ModifiedDate)
	    {
		    Location item = new Location();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.LocationID = LocationID;
				
			item.Name = Name;
				
			item.CostRate = CostRate;
				
			item.Availability = Availability;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
