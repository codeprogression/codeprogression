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
    /// Controller class for ProductPhoto
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ProductPhotoController
    {
        // Preload our schema..
        ProductPhoto thisSchemaLoad = new ProductPhoto();
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
        public ProductPhotoCollection FetchAll()
        {
            ProductPhotoCollection coll = new ProductPhotoCollection();
            Query qry = new Query(ProductPhoto.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductPhotoCollection FetchByID(object ProductPhotoID)
        {
            ProductPhotoCollection coll = new ProductPhotoCollection().Where("ProductPhotoID", ProductPhotoID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductPhotoCollection FetchByQuery(Query qry)
        {
            ProductPhotoCollection coll = new ProductPhotoCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ProductPhotoID)
        {
            return (ProductPhoto.Delete(ProductPhotoID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ProductPhotoID)
        {
            return (ProductPhoto.Destroy(ProductPhotoID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(byte[] ThumbNailPhoto,string ThumbnailPhotoFileName,byte[] LargePhoto,string LargePhotoFileName,DateTime ModifiedDate)
	    {
		    ProductPhoto item = new ProductPhoto();
		    
            item.ThumbNailPhoto = ThumbNailPhoto;
            
            item.ThumbnailPhotoFileName = ThumbnailPhotoFileName;
            
            item.LargePhoto = LargePhoto;
            
            item.LargePhotoFileName = LargePhotoFileName;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int ProductPhotoID,byte[] ThumbNailPhoto,string ThumbnailPhotoFileName,byte[] LargePhoto,string LargePhotoFileName,DateTime ModifiedDate)
	    {
		    ProductPhoto item = new ProductPhoto();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.ProductPhotoID = ProductPhotoID;
				
			item.ThumbNailPhoto = ThumbNailPhoto;
				
			item.ThumbnailPhotoFileName = ThumbnailPhotoFileName;
				
			item.LargePhoto = LargePhoto;
				
			item.LargePhotoFileName = LargePhotoFileName;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
