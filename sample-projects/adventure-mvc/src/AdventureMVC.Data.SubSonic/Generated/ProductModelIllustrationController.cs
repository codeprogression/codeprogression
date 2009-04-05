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
    /// Controller class for ProductModelIllustration
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ProductModelIllustrationController
    {
        // Preload our schema..
        ProductModelIllustration thisSchemaLoad = new ProductModelIllustration();
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
        public ProductModelIllustrationCollection FetchAll()
        {
            ProductModelIllustrationCollection coll = new ProductModelIllustrationCollection();
            Query qry = new Query(ProductModelIllustration.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductModelIllustrationCollection FetchByID(object ProductModelID)
        {
            ProductModelIllustrationCollection coll = new ProductModelIllustrationCollection().Where("ProductModelID", ProductModelID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductModelIllustrationCollection FetchByQuery(Query qry)
        {
            ProductModelIllustrationCollection coll = new ProductModelIllustrationCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ProductModelID)
        {
            return (ProductModelIllustration.Delete(ProductModelID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ProductModelID)
        {
            return (ProductModelIllustration.Destroy(ProductModelID) == 1);
        }
        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int ProductModelID,int IllustrationID)
        {
            Query qry = new Query(ProductModelIllustration.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("ProductModelID", ProductModelID).AND("IllustrationID", IllustrationID);
            qry.Execute();
            return (true);
        }        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int ProductModelID,int IllustrationID,DateTime ModifiedDate)
	    {
		    ProductModelIllustration item = new ProductModelIllustration();
		    
            item.ProductModelID = ProductModelID;
            
            item.IllustrationID = IllustrationID;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int ProductModelID,int IllustrationID,DateTime ModifiedDate)
	    {
		    ProductModelIllustration item = new ProductModelIllustration();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.ProductModelID = ProductModelID;
				
			item.IllustrationID = IllustrationID;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
