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
    /// Controller class for ProductDocument
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ProductDocumentController
    {
        // Preload our schema..
        ProductDocument thisSchemaLoad = new ProductDocument();
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
        public ProductDocumentCollection FetchAll()
        {
            ProductDocumentCollection coll = new ProductDocumentCollection();
            Query qry = new Query(ProductDocument.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductDocumentCollection FetchByID(object ProductID)
        {
            ProductDocumentCollection coll = new ProductDocumentCollection().Where("ProductID", ProductID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ProductDocumentCollection FetchByQuery(Query qry)
        {
            ProductDocumentCollection coll = new ProductDocumentCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ProductID)
        {
            return (ProductDocument.Delete(ProductID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ProductID)
        {
            return (ProductDocument.Destroy(ProductID) == 1);
        }
        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int ProductID,int DocumentID)
        {
            Query qry = new Query(ProductDocument.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("ProductID", ProductID).AND("DocumentID", DocumentID);
            qry.Execute();
            return (true);
        }        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int ProductID,int DocumentID,DateTime ModifiedDate)
	    {
		    ProductDocument item = new ProductDocument();
		    
            item.ProductID = ProductID;
            
            item.DocumentID = DocumentID;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int ProductID,int DocumentID,DateTime ModifiedDate)
	    {
		    ProductDocument item = new ProductDocument();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.ProductID = ProductID;
				
			item.DocumentID = DocumentID;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
