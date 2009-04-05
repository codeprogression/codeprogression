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
    /// Controller class for ProductSubcategory
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ProductSubcategoryController
    {
        // Preload our schema..
        ProductSubcategory thisSchemaLoad = new ProductSubcategory();
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
        public ProductSubcategoryCollection FetchAll()
        {
            ProductSubcategoryCollection coll = new ProductSubcategoryCollection();
            Query qry = new Query(ProductSubcategory.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductSubcategoryCollection FetchByID(object ProductSubcategoryID)
        {
            ProductSubcategoryCollection coll = new ProductSubcategoryCollection().Where("ProductSubcategoryID", ProductSubcategoryID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductSubcategoryCollection FetchByQuery(Query qry)
        {
            ProductSubcategoryCollection coll = new ProductSubcategoryCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ProductSubcategoryID)
        {
            return (ProductSubcategory.Delete(ProductSubcategoryID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ProductSubcategoryID)
        {
            return (ProductSubcategory.Destroy(ProductSubcategoryID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int ProductCategoryID,string Name,Guid Rowguid,DateTime ModifiedDate)
	    {
		    ProductSubcategory item = new ProductSubcategory();
		    
            item.ProductCategoryID = ProductCategoryID;
            
            item.Name = Name;
            
            item.Rowguid = Rowguid;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int ProductSubcategoryID,int ProductCategoryID,string Name,Guid Rowguid,DateTime ModifiedDate)
	    {
		    ProductSubcategory item = new ProductSubcategory();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.ProductSubcategoryID = ProductSubcategoryID;
				
			item.ProductCategoryID = ProductCategoryID;
				
			item.Name = Name;
				
			item.Rowguid = Rowguid;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
