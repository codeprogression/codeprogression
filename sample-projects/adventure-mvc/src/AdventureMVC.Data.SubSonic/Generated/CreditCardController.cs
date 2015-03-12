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
    /// Controller class for CreditCard
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class CreditCardController
    {
        // Preload our schema..
        CreditCard thisSchemaLoad = new CreditCard();
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
        public CreditCardCollection FetchAll()
        {
            CreditCardCollection coll = new CreditCardCollection();
            Query qry = new Query(CreditCard.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CreditCardCollection FetchByID(object CreditCardID)
        {
            CreditCardCollection coll = new CreditCardCollection().Where("CreditCardID", CreditCardID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public CreditCardCollection FetchByQuery(Query qry)
        {
            CreditCardCollection coll = new CreditCardCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object CreditCardID)
        {
            return (CreditCard.Delete(CreditCardID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object CreditCardID)
        {
            return (CreditCard.Destroy(CreditCardID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string CardType,string CardNumber,byte ExpMonth,short ExpYear,DateTime ModifiedDate)
	    {
		    CreditCard item = new CreditCard();
		    
            item.CardType = CardType;
            
            item.CardNumber = CardNumber;
            
            item.ExpMonth = ExpMonth;
            
            item.ExpYear = ExpYear;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int CreditCardID,string CardType,string CardNumber,byte ExpMonth,short ExpYear,DateTime ModifiedDate)
	    {
		    CreditCard item = new CreditCard();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.CreditCardID = CreditCardID;
				
			item.CardType = CardType;
				
			item.CardNumber = CardNumber;
				
			item.ExpMonth = ExpMonth;
				
			item.ExpYear = ExpYear;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
