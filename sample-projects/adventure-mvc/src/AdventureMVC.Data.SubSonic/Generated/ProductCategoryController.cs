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
    /// Controller class for ProductCategory
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ProductCategoryController
    {
        // Preload our schema..
        ProductCategory thisSchemaLoad = new ProductCategory();
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
        public ProductCategoryCollection FetchAll()
        {
            ProductCategoryCollection coll = new ProductCategoryCollection();
            Query qry = new Query(ProductCategory.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductCategoryCollection FetchByID(object ProductCategoryID)
        {
            ProductCategoryCollection coll = new ProductCategoryCollection().Where("ProductCategoryID", ProductCategoryID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductCategoryCollection FetchByQuery(Query qry)
        {
            ProductCategoryCollection coll = new ProductCategoryCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ProductCategoryID)
        {
            return (ProductCategory.Delete(ProductCategoryID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ProductCategoryID)
        {
            return (ProductCategory.Destroy(ProductCategoryID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Name,Guid Rowguid,DateTime ModifiedDate)
	    {
		    ProductCategory item = new ProductCategory();
		    
            item.Name = Name;
            
            item.Rowguid = Rowguid;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int ProductCategoryID,string Name,Guid Rowguid,DateTime ModifiedDate)
	    {
		    ProductCategory item = new ProductCategory();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.ProductCategoryID = ProductCategoryID;
				
			item.Name = Name;
				
			item.Rowguid = Rowguid;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
