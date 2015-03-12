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
    /// Controller class for SalesTaxRate
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SalesTaxRateController
    {
        // Preload our schema..
        SalesTaxRate thisSchemaLoad = new SalesTaxRate();
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
        public SalesTaxRateCollection FetchAll()
        {
            SalesTaxRateCollection coll = new SalesTaxRateCollection();
            Query qry = new Query(SalesTaxRate.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SalesTaxRateCollection FetchByID(object SalesTaxRateID)
        {
            SalesTaxRateCollection coll = new SalesTaxRateCollection().Where("SalesTaxRateID", SalesTaxRateID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SalesTaxRateCollection FetchByQuery(Query qry)
        {
            SalesTaxRateCollection coll = new SalesTaxRateCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object SalesTaxRateID)
        {
            return (SalesTaxRate.Delete(SalesTaxRateID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object SalesTaxRateID)
        {
            return (SalesTaxRate.Destroy(SalesTaxRateID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int StateProvinceID,byte TaxType,decimal TaxRate,string Name,Guid Rowguid,DateTime ModifiedDate)
	    {
		    SalesTaxRate item = new SalesTaxRate();
		    
            item.StateProvinceID = StateProvinceID;
            
            item.TaxType = TaxType;
            
            item.TaxRate = TaxRate;
            
            item.Name = Name;
            
            item.Rowguid = Rowguid;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int SalesTaxRateID,int StateProvinceID,byte TaxType,decimal TaxRate,string Name,Guid Rowguid,DateTime ModifiedDate)
	    {
		    SalesTaxRate item = new SalesTaxRate();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.SalesTaxRateID = SalesTaxRateID;
				
			item.StateProvinceID = StateProvinceID;
				
			item.TaxType = TaxType;
				
			item.TaxRate = TaxRate;
				
			item.Name = Name;
				
			item.Rowguid = Rowguid;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
