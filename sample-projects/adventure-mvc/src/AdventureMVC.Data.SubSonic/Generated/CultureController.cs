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
    /// Controller class for Culture
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class CultureController
    {
        // Preload our schema..
        Culture thisSchemaLoad = new Culture();
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
        public CultureCollection FetchAll()
        {
            CultureCollection coll = new CultureCollection();
            Query qry = new Query(Culture.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CultureCollection FetchByID(object CultureID)
        {
            CultureCollection coll = new CultureCollection().Where("CultureID", CultureID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public CultureCollection FetchByQuery(Query qry)
        {
            CultureCollection coll = new CultureCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object CultureID)
        {
            return (Culture.Delete(CultureID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object CultureID)
        {
            return (Culture.Destroy(CultureID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string CultureID,string Name,DateTime ModifiedDate)
	    {
		    Culture item = new Culture();
		    
            item.CultureID = CultureID;
            
            item.Name = Name;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(string CultureID,string Name,DateTime ModifiedDate)
	    {
		    Culture item = new Culture();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.CultureID = CultureID;
				
			item.Name = Name;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
