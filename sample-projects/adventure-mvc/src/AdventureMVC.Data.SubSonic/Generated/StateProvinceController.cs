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
    /// Controller class for StateProvince
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class StateProvinceController
    {
        // Preload our schema..
        StateProvince thisSchemaLoad = new StateProvince();
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
        public StateProvinceCollection FetchAll()
        {
            StateProvinceCollection coll = new StateProvinceCollection();
            Query qry = new Query(StateProvince.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public StateProvinceCollection FetchByID(object StateProvinceID)
        {
            StateProvinceCollection coll = new StateProvinceCollection().Where("StateProvinceID", StateProvinceID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public StateProvinceCollection FetchByQuery(Query qry)
        {
            StateProvinceCollection coll = new StateProvinceCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object StateProvinceID)
        {
            return (StateProvince.Delete(StateProvinceID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object StateProvinceID)
        {
            return (StateProvince.Destroy(StateProvinceID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string StateProvinceCode,string CountryRegionCode,bool IsOnlyStateProvinceFlag,string Name,int TerritoryID,Guid Rowguid,DateTime ModifiedDate)
	    {
		    StateProvince item = new StateProvince();
		    
            item.StateProvinceCode = StateProvinceCode;
            
            item.CountryRegionCode = CountryRegionCode;
            
            item.IsOnlyStateProvinceFlag = IsOnlyStateProvinceFlag;
            
            item.Name = Name;
            
            item.TerritoryID = TerritoryID;
            
            item.Rowguid = Rowguid;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int StateProvinceID,string StateProvinceCode,string CountryRegionCode,bool IsOnlyStateProvinceFlag,string Name,int TerritoryID,Guid Rowguid,DateTime ModifiedDate)
	    {
		    StateProvince item = new StateProvince();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.StateProvinceID = StateProvinceID;
				
			item.StateProvinceCode = StateProvinceCode;
				
			item.CountryRegionCode = CountryRegionCode;
				
			item.IsOnlyStateProvinceFlag = IsOnlyStateProvinceFlag;
				
			item.Name = Name;
				
			item.TerritoryID = TerritoryID;
				
			item.Rowguid = Rowguid;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
