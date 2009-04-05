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
    /// Controller class for Currency
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class CurrencyController
    {
        // Preload our schema..
        Currency thisSchemaLoad = new Currency();
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
        public CurrencyCollection FetchAll()
        {
            CurrencyCollection coll = new CurrencyCollection();
            Query qry = new Query(Currency.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CurrencyCollection FetchByID(object CurrencyCode)
        {
            CurrencyCollection coll = new CurrencyCollection().Where("CurrencyCode", CurrencyCode).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public CurrencyCollection FetchByQuery(Query qry)
        {
            CurrencyCollection coll = new CurrencyCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object CurrencyCode)
        {
            return (Currency.Delete(CurrencyCode) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object CurrencyCode)
        {
            return (Currency.Destroy(CurrencyCode) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string CurrencyCode,string Name,DateTime ModifiedDate)
	    {
		    Currency item = new Currency();
		    
            item.CurrencyCode = CurrencyCode;
            
            item.Name = Name;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(string CurrencyCode,string Name,DateTime ModifiedDate)
	    {
		    Currency item = new Currency();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.CurrencyCode = CurrencyCode;
				
			item.Name = Name;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
