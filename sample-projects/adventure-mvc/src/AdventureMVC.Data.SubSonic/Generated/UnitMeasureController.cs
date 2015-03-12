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
    /// Controller class for UnitMeasure
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class UnitMeasureController
    {
        // Preload our schema..
        UnitMeasure thisSchemaLoad = new UnitMeasure();
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
        public UnitMeasureCollection FetchAll()
        {
            UnitMeasureCollection coll = new UnitMeasureCollection();
            Query qry = new Query(UnitMeasure.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public UnitMeasureCollection FetchByID(object UnitMeasureCode)
        {
            UnitMeasureCollection coll = new UnitMeasureCollection().Where("UnitMeasureCode", UnitMeasureCode).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public UnitMeasureCollection FetchByQuery(Query qry)
        {
            UnitMeasureCollection coll = new UnitMeasureCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object UnitMeasureCode)
        {
            return (UnitMeasure.Delete(UnitMeasureCode) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object UnitMeasureCode)
        {
            return (UnitMeasure.Destroy(UnitMeasureCode) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string UnitMeasureCode,string Name,DateTime ModifiedDate)
	    {
		    UnitMeasure item = new UnitMeasure();
		    
            item.UnitMeasureCode = UnitMeasureCode;
            
            item.Name = Name;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(string UnitMeasureCode,string Name,DateTime ModifiedDate)
	    {
		    UnitMeasure item = new UnitMeasure();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.UnitMeasureCode = UnitMeasureCode;
				
			item.Name = Name;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
