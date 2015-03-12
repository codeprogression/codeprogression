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
    /// Controller class for Shift
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ShiftController
    {
        // Preload our schema..
        Shift thisSchemaLoad = new Shift();
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
        public ShiftCollection FetchAll()
        {
            ShiftCollection coll = new ShiftCollection();
            Query qry = new Query(Shift.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ShiftCollection FetchByID(object ShiftID)
        {
            ShiftCollection coll = new ShiftCollection().Where("ShiftID", ShiftID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ShiftCollection FetchByQuery(Query qry)
        {
            ShiftCollection coll = new ShiftCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ShiftID)
        {
            return (Shift.Delete(ShiftID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ShiftID)
        {
            return (Shift.Destroy(ShiftID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Name,DateTime StartTime,DateTime EndTime,DateTime ModifiedDate)
	    {
		    Shift item = new Shift();
		    
            item.Name = Name;
            
            item.StartTime = StartTime;
            
            item.EndTime = EndTime;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(byte ShiftID,string Name,DateTime StartTime,DateTime EndTime,DateTime ModifiedDate)
	    {
		    Shift item = new Shift();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.ShiftID = ShiftID;
				
			item.Name = Name;
				
			item.StartTime = StartTime;
				
			item.EndTime = EndTime;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
