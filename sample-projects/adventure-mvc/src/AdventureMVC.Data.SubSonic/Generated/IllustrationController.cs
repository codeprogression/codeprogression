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
    /// Controller class for Illustration
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class IllustrationController
    {
        // Preload our schema..
        Illustration thisSchemaLoad = new Illustration();
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
        public IllustrationCollection FetchAll()
        {
            IllustrationCollection coll = new IllustrationCollection();
            Query qry = new Query(Illustration.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IllustrationCollection FetchByID(object IllustrationID)
        {
            IllustrationCollection coll = new IllustrationCollection().Where("IllustrationID", IllustrationID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public IllustrationCollection FetchByQuery(Query qry)
        {
            IllustrationCollection coll = new IllustrationCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IllustrationID)
        {
            return (Illustration.Delete(IllustrationID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IllustrationID)
        {
            return (Illustration.Destroy(IllustrationID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Diagram,DateTime ModifiedDate)
	    {
		    Illustration item = new Illustration();
		    
            item.Diagram = Diagram;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int IllustrationID,string Diagram,DateTime ModifiedDate)
	    {
		    Illustration item = new Illustration();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IllustrationID = IllustrationID;
				
			item.Diagram = Diagram;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
