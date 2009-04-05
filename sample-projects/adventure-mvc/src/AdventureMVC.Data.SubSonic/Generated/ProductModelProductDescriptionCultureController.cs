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
    /// Controller class for ProductModelProductDescriptionCulture
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ProductModelProductDescriptionCultureController
    {
        // Preload our schema..
        ProductModelProductDescriptionCulture thisSchemaLoad = new ProductModelProductDescriptionCulture();
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
        public ProductModelProductDescriptionCultureCollection FetchAll()
        {
            ProductModelProductDescriptionCultureCollection coll = new ProductModelProductDescriptionCultureCollection();
            Query qry = new Query(ProductModelProductDescriptionCulture.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductModelProductDescriptionCultureCollection FetchByID(object ProductModelID)
        {
            ProductModelProductDescriptionCultureCollection coll = new ProductModelProductDescriptionCultureCollection().Where("ProductModelID", ProductModelID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductModelProductDescriptionCultureCollection FetchByQuery(Query qry)
        {
            ProductModelProductDescriptionCultureCollection coll = new ProductModelProductDescriptionCultureCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ProductModelID)
        {
            return (ProductModelProductDescriptionCulture.Delete(ProductModelID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ProductModelID)
        {
            return (ProductModelProductDescriptionCulture.Destroy(ProductModelID) == 1);
        }
        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int ProductModelID,int ProductDescriptionID,string CultureID)
        {
            Query qry = new Query(ProductModelProductDescriptionCulture.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("ProductModelID", ProductModelID).AND("ProductDescriptionID", ProductDescriptionID).AND("CultureID", CultureID);
            qry.Execute();
            return (true);
        }        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int ProductModelID,int ProductDescriptionID,string CultureID,DateTime ModifiedDate)
	    {
		    ProductModelProductDescriptionCulture item = new ProductModelProductDescriptionCulture();
		    
            item.ProductModelID = ProductModelID;
            
            item.ProductDescriptionID = ProductDescriptionID;
            
            item.CultureID = CultureID;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int ProductModelID,int ProductDescriptionID,string CultureID,DateTime ModifiedDate)
	    {
		    ProductModelProductDescriptionCulture item = new ProductModelProductDescriptionCulture();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.ProductModelID = ProductModelID;
				
			item.ProductDescriptionID = ProductDescriptionID;
				
			item.CultureID = CultureID;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
