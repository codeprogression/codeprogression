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
    /// Controller class for SalesOrderDetail
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SalesOrderDetailController
    {
        // Preload our schema..
        SalesOrderDetail thisSchemaLoad = new SalesOrderDetail();
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
        public SalesOrderDetailCollection FetchAll()
        {
            SalesOrderDetailCollection coll = new SalesOrderDetailCollection();
            Query qry = new Query(SalesOrderDetail.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SalesOrderDetailCollection FetchByID(object SalesOrderID)
        {
            SalesOrderDetailCollection coll = new SalesOrderDetailCollection().Where("SalesOrderID", SalesOrderID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SalesOrderDetailCollection FetchByQuery(Query qry)
        {
            SalesOrderDetailCollection coll = new SalesOrderDetailCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object SalesOrderID)
        {
            return (SalesOrderDetail.Delete(SalesOrderID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object SalesOrderID)
        {
            return (SalesOrderDetail.Destroy(SalesOrderID) == 1);
        }
        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(int SalesOrderID,int SalesOrderDetailID)
        {
            Query qry = new Query(SalesOrderDetail.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("SalesOrderID", SalesOrderID).AND("SalesOrderDetailID", SalesOrderDetailID);
            qry.Execute();
            return (true);
        }        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int SalesOrderID,string CarrierTrackingNumber,short OrderQty,int ProductID,int SpecialOfferID,decimal UnitPrice,decimal UnitPriceDiscount,decimal LineTotal,Guid Rowguid,DateTime ModifiedDate)
	    {
		    SalesOrderDetail item = new SalesOrderDetail();
		    
            item.SalesOrderID = SalesOrderID;
            
            item.CarrierTrackingNumber = CarrierTrackingNumber;
            
            item.OrderQty = OrderQty;
            
            item.ProductID = ProductID;
            
            item.SpecialOfferID = SpecialOfferID;
            
            item.UnitPrice = UnitPrice;
            
            item.UnitPriceDiscount = UnitPriceDiscount;
            
            item.LineTotal = LineTotal;
            
            item.Rowguid = Rowguid;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int SalesOrderID,int SalesOrderDetailID,string CarrierTrackingNumber,short OrderQty,int ProductID,int SpecialOfferID,decimal UnitPrice,decimal UnitPriceDiscount,decimal LineTotal,Guid Rowguid,DateTime ModifiedDate)
	    {
		    SalesOrderDetail item = new SalesOrderDetail();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.SalesOrderID = SalesOrderID;
				
			item.SalesOrderDetailID = SalesOrderDetailID;
				
			item.CarrierTrackingNumber = CarrierTrackingNumber;
				
			item.OrderQty = OrderQty;
				
			item.ProductID = ProductID;
				
			item.SpecialOfferID = SpecialOfferID;
				
			item.UnitPrice = UnitPrice;
				
			item.UnitPriceDiscount = UnitPriceDiscount;
				
			item.LineTotal = LineTotal;
				
			item.Rowguid = Rowguid;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
