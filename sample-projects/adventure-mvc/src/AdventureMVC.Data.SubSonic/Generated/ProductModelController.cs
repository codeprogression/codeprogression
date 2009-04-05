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
    /// Controller class for ProductModel
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ProductModelController
    {
        // Preload our schema..
        ProductModel thisSchemaLoad = new ProductModel();
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
        public ProductModelCollection FetchAll()
        {
            ProductModelCollection coll = new ProductModelCollection();
            Query qry = new Query(ProductModel.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductModelCollection FetchByID(object ProductModelID)
        {
            ProductModelCollection coll = new ProductModelCollection().Where("ProductModelID", ProductModelID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductModelCollection FetchByQuery(Query qry)
        {
            ProductModelCollection coll = new ProductModelCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ProductModelID)
        {
            return (ProductModel.Delete(ProductModelID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ProductModelID)
        {
            return (ProductModel.Destroy(ProductModelID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Name,string CatalogDescription,string Instructions,Guid Rowguid,DateTime ModifiedDate)
	    {
		    ProductModel item = new ProductModel();
		    
            item.Name = Name;
            
            item.CatalogDescription = CatalogDescription;
            
            item.Instructions = Instructions;
            
            item.Rowguid = Rowguid;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int ProductModelID,string Name,string CatalogDescription,string Instructions,Guid Rowguid,DateTime ModifiedDate)
	    {
		    ProductModel item = new ProductModel();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.ProductModelID = ProductModelID;
				
			item.Name = Name;
				
			item.CatalogDescription = CatalogDescription;
				
			item.Instructions = Instructions;
				
			item.Rowguid = Rowguid;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
