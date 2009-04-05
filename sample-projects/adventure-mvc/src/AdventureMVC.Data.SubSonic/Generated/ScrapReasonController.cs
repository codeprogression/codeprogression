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
    /// Controller class for ScrapReason
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ScrapReasonController
    {
        // Preload our schema..
        ScrapReason thisSchemaLoad = new ScrapReason();
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
        public ScrapReasonCollection FetchAll()
        {
            ScrapReasonCollection coll = new ScrapReasonCollection();
            Query qry = new Query(ScrapReason.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ScrapReasonCollection FetchByID(object ScrapReasonID)
        {
            ScrapReasonCollection coll = new ScrapReasonCollection().Where("ScrapReasonID", ScrapReasonID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ScrapReasonCollection FetchByQuery(Query qry)
        {
            ScrapReasonCollection coll = new ScrapReasonCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ScrapReasonID)
        {
            return (ScrapReason.Delete(ScrapReasonID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ScrapReasonID)
        {
            return (ScrapReason.Destroy(ScrapReasonID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Name,DateTime ModifiedDate)
	    {
		    ScrapReason item = new ScrapReason();
		    
            item.Name = Name;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(short ScrapReasonID,string Name,DateTime ModifiedDate)
	    {
		    ScrapReason item = new ScrapReason();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.ScrapReasonID = ScrapReasonID;
				
			item.Name = Name;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
