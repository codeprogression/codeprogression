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
    /// Controller class for SpecialOfferProduct
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SpecialOfferProductController
    {
        // Preload our schema..
        SpecialOfferProduct thisSchemaLoad = new SpecialOfferProduct();
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
        public SpecialOfferProductCollection FetchAll()
        {
            SpecialOfferProductCollection coll = new SpecialOfferProductCollection();
            Query qry = new Query(SpecialOfferProduct.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SpecialOfferProductCollection FetchByID(object SpecialOfferID)
        {
            SpecialOfferProductCollection coll = new SpecialOfferProductCollection().Where("SpecialOfferID", SpecialOfferID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SpecialOfferProductCollection FetchByQuery(Query qry)
        {
            SpecialOfferProductCollection coll = new SpecialOfferProductCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object SpecialOfferID)
        {
            return (SpecialOfferProduct.Delete(SpecialOfferID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object SpecialOfferID)
        {
            return (SpecialOfferProduct.Destroy(SpecialOfferID) == 1);
        }
        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int SpecialOfferID,int ProductID)
        {
            Query qry = new Query(SpecialOfferProduct.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("SpecialOfferID", SpecialOfferID).AND("ProductID", ProductID);
            qry.Execute();
            return (true);
        }        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int SpecialOfferID,int ProductID,Guid Rowguid,DateTime ModifiedDate)
	    {
		    SpecialOfferProduct item = new SpecialOfferProduct();
		    
            item.SpecialOfferID = SpecialOfferID;
            
            item.ProductID = ProductID;
            
            item.Rowguid = Rowguid;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int SpecialOfferID,int ProductID,Guid Rowguid,DateTime ModifiedDate)
	    {
		    SpecialOfferProduct item = new SpecialOfferProduct();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.SpecialOfferID = SpecialOfferID;
				
			item.ProductID = ProductID;
				
			item.Rowguid = Rowguid;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
