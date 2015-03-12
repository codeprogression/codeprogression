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
    /// Controller class for SalesPerson
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SalesPersonController
    {
        // Preload our schema..
        SalesPerson thisSchemaLoad = new SalesPerson();
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
        public SalesPersonCollection FetchAll()
        {
            SalesPersonCollection coll = new SalesPersonCollection();
            Query qry = new Query(SalesPerson.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SalesPersonCollection FetchByID(object SalesPersonID)
        {
            SalesPersonCollection coll = new SalesPersonCollection().Where("SalesPersonID", SalesPersonID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SalesPersonCollection FetchByQuery(Query qry)
        {
            SalesPersonCollection coll = new SalesPersonCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object SalesPersonID)
        {
            return (SalesPerson.Delete(SalesPersonID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object SalesPersonID)
        {
            return (SalesPerson.Destroy(SalesPersonID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int SalesPersonID,int? TerritoryID,decimal? SalesQuota,decimal Bonus,decimal CommissionPct,decimal SalesYTD,decimal SalesLastYear,Guid Rowguid,DateTime ModifiedDate)
	    {
		    SalesPerson item = new SalesPerson();
		    
            item.SalesPersonID = SalesPersonID;
            
            item.TerritoryID = TerritoryID;
            
            item.SalesQuota = SalesQuota;
            
            item.Bonus = Bonus;
            
            item.CommissionPct = CommissionPct;
            
            item.SalesYTD = SalesYTD;
            
            item.SalesLastYear = SalesLastYear;
            
            item.Rowguid = Rowguid;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int SalesPersonID,int? TerritoryID,decimal? SalesQuota,decimal Bonus,decimal CommissionPct,decimal SalesYTD,decimal SalesLastYear,Guid Rowguid,DateTime ModifiedDate)
	    {
		    SalesPerson item = new SalesPerson();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.SalesPersonID = SalesPersonID;
				
			item.TerritoryID = TerritoryID;
				
			item.SalesQuota = SalesQuota;
				
			item.Bonus = Bonus;
				
			item.CommissionPct = CommissionPct;
				
			item.SalesYTD = SalesYTD;
				
			item.SalesLastYear = SalesLastYear;
				
			item.Rowguid = Rowguid;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
