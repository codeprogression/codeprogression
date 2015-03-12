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
    /// Controller class for ProductProductPhoto
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ProductProductPhotoController
    {
        // Preload our schema..
        ProductProductPhoto thisSchemaLoad = new ProductProductPhoto();
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
        public ProductProductPhotoCollection FetchAll()
        {
            ProductProductPhotoCollection coll = new ProductProductPhotoCollection();
            Query qry = new Query(ProductProductPhoto.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductProductPhotoCollection FetchByID(object ProductID)
        {
            ProductProductPhotoCollection coll = new ProductProductPhotoCollection().Where("ProductID", ProductID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductProductPhotoCollection FetchByQuery(Query qry)
        {
            ProductProductPhotoCollection coll = new ProductProductPhotoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ProductID)
        {
            return (ProductProductPhoto.Delete(ProductID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ProductID)
        {
            return (ProductProductPhoto.Destroy(ProductID) == 1);
        }
        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int ProductID,int ProductPhotoID)
        {
            Query qry = new Query(ProductProductPhoto.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("ProductID", ProductID).AND("ProductPhotoID", ProductPhotoID);
            qry.Execute();
            return (true);
        }        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int ProductID,int ProductPhotoID,bool Primary,DateTime ModifiedDate)
	    {
		    ProductProductPhoto item = new ProductProductPhoto();
		    
            item.ProductID = ProductID;
            
            item.ProductPhotoID = ProductPhotoID;
            
            item.Primary = Primary;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int ProductID,int ProductPhotoID,bool Primary,DateTime ModifiedDate)
	    {
		    ProductProductPhoto item = new ProductProductPhoto();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.ProductID = ProductID;
				
			item.ProductPhotoID = ProductPhotoID;
				
			item.Primary = Primary;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
