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
    /// Controller class for ProductReview
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ProductReviewController
    {
        // Preload our schema..
        ProductReview thisSchemaLoad = new ProductReview();
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
        public ProductReviewCollection FetchAll()
        {
            ProductReviewCollection coll = new ProductReviewCollection();
            Query qry = new Query(ProductReview.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductReviewCollection FetchByID(object ProductReviewID)
        {
            ProductReviewCollection coll = new ProductReviewCollection().Where("ProductReviewID", ProductReviewID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductReviewCollection FetchByQuery(Query qry)
        {
            ProductReviewCollection coll = new ProductReviewCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ProductReviewID)
        {
            return (ProductReview.Delete(ProductReviewID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ProductReviewID)
        {
            return (ProductReview.Destroy(ProductReviewID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int ProductID,string ReviewerName,DateTime ReviewDate,string EmailAddress,int Rating,string Comments,DateTime ModifiedDate)
	    {
		    ProductReview item = new ProductReview();
		    
            item.ProductID = ProductID;
            
            item.ReviewerName = ReviewerName;
            
            item.ReviewDate = ReviewDate;
            
            item.EmailAddress = EmailAddress;
            
            item.Rating = Rating;
            
            item.Comments = Comments;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int ProductReviewID,int ProductID,string ReviewerName,DateTime ReviewDate,string EmailAddress,int Rating,string Comments,DateTime ModifiedDate)
	    {
		    ProductReview item = new ProductReview();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.ProductReviewID = ProductReviewID;
				
			item.ProductID = ProductID;
				
			item.ReviewerName = ReviewerName;
				
			item.ReviewDate = ReviewDate;
				
			item.EmailAddress = EmailAddress;
				
			item.Rating = Rating;
				
			item.Comments = Comments;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
