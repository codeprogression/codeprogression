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
    /// Controller class for SalesReason
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SalesReasonController
    {
        // Preload our schema..
        SalesReason thisSchemaLoad = new SalesReason();
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
        public SalesReasonCollection FetchAll()
        {
            SalesReasonCollection coll = new SalesReasonCollection();
            Query qry = new Query(SalesReason.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SalesReasonCollection FetchByID(object SalesReasonID)
        {
            SalesReasonCollection coll = new SalesReasonCollection().Where("SalesReasonID", SalesReasonID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SalesReasonCollection FetchByQuery(Query qry)
        {
            SalesReasonCollection coll = new SalesReasonCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object SalesReasonID)
        {
            return (SalesReason.Delete(SalesReasonID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object SalesReasonID)
        {
            return (SalesReason.Destroy(SalesReasonID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Name,string ReasonType,DateTime ModifiedDate)
	    {
		    SalesReason item = new SalesReason();
		    
            item.Name = Name;
            
            item.ReasonType = ReasonType;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int SalesReasonID,string Name,string ReasonType,DateTime ModifiedDate)
	    {
		    SalesReason item = new SalesReason();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.SalesReasonID = SalesReasonID;
				
			item.Name = Name;
				
			item.ReasonType = ReasonType;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
