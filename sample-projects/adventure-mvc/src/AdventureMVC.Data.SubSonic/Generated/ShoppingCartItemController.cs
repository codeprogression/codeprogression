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
    /// Controller class for ShoppingCartItem
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ShoppingCartItemController
    {
        // Preload our schema..
        ShoppingCartItem thisSchemaLoad = new ShoppingCartItem();
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
        public ShoppingCartItemCollection FetchAll()
        {
            ShoppingCartItemCollection coll = new ShoppingCartItemCollection();
            Query qry = new Query(ShoppingCartItem.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ShoppingCartItemCollection FetchByID(object ShoppingCartItemID)
        {
            ShoppingCartItemCollection coll = new ShoppingCartItemCollection().Where("ShoppingCartItemID", ShoppingCartItemID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ShoppingCartItemCollection FetchByQuery(Query qry)
        {
            ShoppingCartItemCollection coll = new ShoppingCartItemCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ShoppingCartItemID)
        {
            return (ShoppingCartItem.Delete(ShoppingCartItemID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ShoppingCartItemID)
        {
            return (ShoppingCartItem.Destroy(ShoppingCartItemID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string ShoppingCartID,int Quantity,int ProductID,DateTime DateCreated,DateTime ModifiedDate)
	    {
		    ShoppingCartItem item = new ShoppingCartItem();
		    
            item.ShoppingCartID = ShoppingCartID;
            
            item.Quantity = Quantity;
            
            item.ProductID = ProductID;
            
            item.DateCreated = DateCreated;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int ShoppingCartItemID,string ShoppingCartID,int Quantity,int ProductID,DateTime DateCreated,DateTime ModifiedDate)
	    {
		    ShoppingCartItem item = new ShoppingCartItem();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.ShoppingCartItemID = ShoppingCartItemID;
				
			item.ShoppingCartID = ShoppingCartID;
				
			item.Quantity = Quantity;
				
			item.ProductID = ProductID;
				
			item.DateCreated = DateCreated;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
