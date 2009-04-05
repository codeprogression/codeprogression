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
    /// Controller class for CurrencyRate
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class CurrencyRateController
    {
        // Preload our schema..
        CurrencyRate thisSchemaLoad = new CurrencyRate();
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
        public CurrencyRateCollection FetchAll()
        {
            CurrencyRateCollection coll = new CurrencyRateCollection();
            Query qry = new Query(CurrencyRate.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CurrencyRateCollection FetchByID(object CurrencyRateID)
        {
            CurrencyRateCollection coll = new CurrencyRateCollection().Where("CurrencyRateID", CurrencyRateID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public CurrencyRateCollection FetchByQuery(Query qry)
        {
            CurrencyRateCollection coll = new CurrencyRateCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object CurrencyRateID)
        {
            return (CurrencyRate.Delete(CurrencyRateID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object CurrencyRateID)
        {
            return (CurrencyRate.Destroy(CurrencyRateID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(DateTime CurrencyRateDate,string FromCurrencyCode,string ToCurrencyCode,decimal AverageRate,decimal EndOfDayRate,DateTime ModifiedDate)
	    {
		    CurrencyRate item = new CurrencyRate();
		    
            item.CurrencyRateDate = CurrencyRateDate;
            
            item.FromCurrencyCode = FromCurrencyCode;
            
            item.ToCurrencyCode = ToCurrencyCode;
            
            item.AverageRate = AverageRate;
            
            item.EndOfDayRate = EndOfDayRate;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int CurrencyRateID,DateTime CurrencyRateDate,string FromCurrencyCode,string ToCurrencyCode,decimal AverageRate,decimal EndOfDayRate,DateTime ModifiedDate)
	    {
		    CurrencyRate item = new CurrencyRate();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.CurrencyRateID = CurrencyRateID;
				
			item.CurrencyRateDate = CurrencyRateDate;
				
			item.FromCurrencyCode = FromCurrencyCode;
				
			item.ToCurrencyCode = ToCurrencyCode;
				
			item.AverageRate = AverageRate;
				
			item.EndOfDayRate = EndOfDayRate;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
