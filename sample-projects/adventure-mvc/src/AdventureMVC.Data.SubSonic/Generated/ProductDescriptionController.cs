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
    /// Controller class for ProductDescription
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ProductDescriptionController
    {
        // Preload our schema..
        ProductDescription thisSchemaLoad = new ProductDescription();
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
        public ProductDescriptionCollection FetchAll()
        {
            ProductDescriptionCollection coll = new ProductDescriptionCollection();
            Query qry = new Query(ProductDescription.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductDescriptionCollection FetchByID(object ProductDescriptionID)
        {
            ProductDescriptionCollection coll = new ProductDescriptionCollection().Where("ProductDescriptionID", ProductDescriptionID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductDescriptionCollection FetchByQuery(Query qry)
        {
            ProductDescriptionCollection coll = new ProductDescriptionCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ProductDescriptionID)
        {
            return (ProductDescription.Delete(ProductDescriptionID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ProductDescriptionID)
        {
            return (ProductDescription.Destroy(ProductDescriptionID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Description,Guid Rowguid,DateTime ModifiedDate)
	    {
		    ProductDescription item = new ProductDescription();
		    
            item.Description = Description;
            
            item.Rowguid = Rowguid;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int ProductDescriptionID,string Description,Guid Rowguid,DateTime ModifiedDate)
	    {
		    ProductDescription item = new ProductDescription();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.ProductDescriptionID = ProductDescriptionID;
				
			item.Description = Description;
				
			item.Rowguid = Rowguid;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
