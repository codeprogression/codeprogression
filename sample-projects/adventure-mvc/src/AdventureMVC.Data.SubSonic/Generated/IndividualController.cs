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
    /// Controller class for Individual
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class IndividualController
    {
        // Preload our schema..
        Individual thisSchemaLoad = new Individual();
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
        public IndividualCollection FetchAll()
        {
            IndividualCollection coll = new IndividualCollection();
            Query qry = new Query(Individual.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public IndividualCollection FetchByID(object CustomerID)
        {
            IndividualCollection coll = new IndividualCollection().Where("CustomerID", CustomerID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public IndividualCollection FetchByQuery(Query qry)
        {
            IndividualCollection coll = new IndividualCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object CustomerID)
        {
            return (Individual.Delete(CustomerID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object CustomerID)
        {
            return (Individual.Destroy(CustomerID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int CustomerID,int ContactID,string Demographics,DateTime ModifiedDate)
	    {
		    Individual item = new Individual();
		    
            item.CustomerID = CustomerID;
            
            item.ContactID = ContactID;
            
            item.Demographics = Demographics;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int CustomerID,int ContactID,string Demographics,DateTime ModifiedDate)
	    {
		    Individual item = new Individual();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.CustomerID = CustomerID;
				
			item.ContactID = ContactID;
				
			item.Demographics = Demographics;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
