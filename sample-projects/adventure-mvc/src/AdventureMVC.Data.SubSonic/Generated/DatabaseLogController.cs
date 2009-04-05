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
    /// Controller class for DatabaseLog
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class DatabaseLogController
    {
        // Preload our schema..
        DatabaseLog thisSchemaLoad = new DatabaseLog();
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
        public DatabaseLogCollection FetchAll()
        {
            DatabaseLogCollection coll = new DatabaseLogCollection();
            Query qry = new Query(DatabaseLog.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public DatabaseLogCollection FetchByID(object DatabaseLogID)
        {
            DatabaseLogCollection coll = new DatabaseLogCollection().Where("DatabaseLogID", DatabaseLogID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public DatabaseLogCollection FetchByQuery(Query qry)
        {
            DatabaseLogCollection coll = new DatabaseLogCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object DatabaseLogID)
        {
            return (DatabaseLog.Delete(DatabaseLogID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object DatabaseLogID)
        {
            return (DatabaseLog.Destroy(DatabaseLogID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(DateTime PostTime,string DatabaseUser,string EventX,string SchemaX,string ObjectX,string Tsql,string XmlEvent)
	    {
		    DatabaseLog item = new DatabaseLog();
		    
            item.PostTime = PostTime;
            
            item.DatabaseUser = DatabaseUser;
            
            item.EventX = EventX;
            
            item.SchemaX = SchemaX;
            
            item.ObjectX = ObjectX;
            
            item.Tsql = Tsql;
            
            item.XmlEvent = XmlEvent;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int DatabaseLogID,DateTime PostTime,string DatabaseUser,string EventX,string SchemaX,string ObjectX,string Tsql,string XmlEvent)
	    {
		    DatabaseLog item = new DatabaseLog();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.DatabaseLogID = DatabaseLogID;
				
			item.PostTime = PostTime;
				
			item.DatabaseUser = DatabaseUser;
				
			item.EventX = EventX;
				
			item.SchemaX = SchemaX;
				
			item.ObjectX = ObjectX;
				
			item.Tsql = Tsql;
				
			item.XmlEvent = XmlEvent;
				
	        item.Save(UserName);
	    }
    }
}
