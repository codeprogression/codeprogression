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
    /// Controller class for AWBuildVersion
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AWBuildVersionController
    {
        // Preload our schema..
        AWBuildVersion thisSchemaLoad = new AWBuildVersion();
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
        public AWBuildVersionCollection FetchAll()
        {
            AWBuildVersionCollection coll = new AWBuildVersionCollection();
            Query qry = new Query(AWBuildVersion.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AWBuildVersionCollection FetchByID(object SystemInformationID)
        {
            AWBuildVersionCollection coll = new AWBuildVersionCollection().Where("SystemInformationID", SystemInformationID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AWBuildVersionCollection FetchByQuery(Query qry)
        {
            AWBuildVersionCollection coll = new AWBuildVersionCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object SystemInformationID)
        {
            return (AWBuildVersion.Delete(SystemInformationID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object SystemInformationID)
        {
            return (AWBuildVersion.Destroy(SystemInformationID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string DatabaseVersion,DateTime VersionDate,DateTime ModifiedDate)
	    {
		    AWBuildVersion item = new AWBuildVersion();
		    
            item.DatabaseVersion = DatabaseVersion;
            
            item.VersionDate = VersionDate;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(byte SystemInformationID,string DatabaseVersion,DateTime VersionDate,DateTime ModifiedDate)
	    {
		    AWBuildVersion item = new AWBuildVersion();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.SystemInformationID = SystemInformationID;
				
			item.DatabaseVersion = DatabaseVersion;
				
			item.VersionDate = VersionDate;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
