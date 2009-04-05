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
    /// Controller class for CountryRegion
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class CountryRegionController
    {
        // Preload our schema..
        CountryRegion thisSchemaLoad = new CountryRegion();
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
        public CountryRegionCollection FetchAll()
        {
            CountryRegionCollection coll = new CountryRegionCollection();
            Query qry = new Query(CountryRegion.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CountryRegionCollection FetchByID(object CountryRegionCode)
        {
            CountryRegionCollection coll = new CountryRegionCollection().Where("CountryRegionCode", CountryRegionCode).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public CountryRegionCollection FetchByQuery(Query qry)
        {
            CountryRegionCollection coll = new CountryRegionCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object CountryRegionCode)
        {
            return (CountryRegion.Delete(CountryRegionCode) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object CountryRegionCode)
        {
            return (CountryRegion.Destroy(CountryRegionCode) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string CountryRegionCode,string Name,DateTime ModifiedDate)
	    {
		    CountryRegion item = new CountryRegion();
		    
            item.CountryRegionCode = CountryRegionCode;
            
            item.Name = Name;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(string CountryRegionCode,string Name,DateTime ModifiedDate)
	    {
		    CountryRegion item = new CountryRegion();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.CountryRegionCode = CountryRegionCode;
				
			item.Name = Name;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
