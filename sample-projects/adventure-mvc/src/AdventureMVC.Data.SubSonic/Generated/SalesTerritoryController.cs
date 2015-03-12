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
    /// Controller class for SalesTerritory
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SalesTerritoryController
    {
        // Preload our schema..
        SalesTerritory thisSchemaLoad = new SalesTerritory();
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
        public SalesTerritoryCollection FetchAll()
        {
            SalesTerritoryCollection coll = new SalesTerritoryCollection();
            Query qry = new Query(SalesTerritory.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SalesTerritoryCollection FetchByID(object TerritoryID)
        {
            SalesTerritoryCollection coll = new SalesTerritoryCollection().Where("TerritoryID", TerritoryID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SalesTerritoryCollection FetchByQuery(Query qry)
        {
            SalesTerritoryCollection coll = new SalesTerritoryCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object TerritoryID)
        {
            return (SalesTerritory.Delete(TerritoryID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object TerritoryID)
        {
            return (SalesTerritory.Destroy(TerritoryID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Name,string CountryRegionCode,string Group,decimal SalesYTD,decimal SalesLastYear,decimal CostYTD,decimal CostLastYear,Guid Rowguid,DateTime ModifiedDate)
	    {
		    SalesTerritory item = new SalesTerritory();
		    
            item.Name = Name;
            
            item.CountryRegionCode = CountryRegionCode;
            
            item.Group = Group;
            
            item.SalesYTD = SalesYTD;
            
            item.SalesLastYear = SalesLastYear;
            
            item.CostYTD = CostYTD;
            
            item.CostLastYear = CostLastYear;
            
            item.Rowguid = Rowguid;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int TerritoryID,string Name,string CountryRegionCode,string Group,decimal SalesYTD,decimal SalesLastYear,decimal CostYTD,decimal CostLastYear,Guid Rowguid,DateTime ModifiedDate)
	    {
		    SalesTerritory item = new SalesTerritory();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.TerritoryID = TerritoryID;
				
			item.Name = Name;
				
			item.CountryRegionCode = CountryRegionCode;
				
			item.Group = Group;
				
			item.SalesYTD = SalesYTD;
				
			item.SalesLastYear = SalesLastYear;
				
			item.CostYTD = CostYTD;
				
			item.CostLastYear = CostLastYear;
				
			item.Rowguid = Rowguid;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
