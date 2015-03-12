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
    /// Controller class for PurchaseOrderHeader
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class PurchaseOrderHeaderController
    {
        // Preload our schema..
        PurchaseOrderHeader thisSchemaLoad = new PurchaseOrderHeader();
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
        public PurchaseOrderHeaderCollection FetchAll()
        {
            PurchaseOrderHeaderCollection coll = new PurchaseOrderHeaderCollection();
            Query qry = new Query(PurchaseOrderHeader.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public PurchaseOrderHeaderCollection FetchByID(object PurchaseOrderID)
        {
            PurchaseOrderHeaderCollection coll = new PurchaseOrderHeaderCollection().Where("PurchaseOrderID", PurchaseOrderID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public PurchaseOrderHeaderCollection FetchByQuery(Query qry)
        {
            PurchaseOrderHeaderCollection coll = new PurchaseOrderHeaderCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object PurchaseOrderID)
        {
            return (PurchaseOrderHeader.Delete(PurchaseOrderID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object PurchaseOrderID)
        {
            return (PurchaseOrderHeader.Destroy(PurchaseOrderID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(byte RevisionNumber,byte Status,int EmployeeID,int VendorID,int ShipMethodID,DateTime OrderDate,DateTime? ShipDate,decimal SubTotal,decimal TaxAmt,decimal Freight,decimal TotalDue,DateTime ModifiedDate)
	    {
		    PurchaseOrderHeader item = new PurchaseOrderHeader();
		    
            item.RevisionNumber = RevisionNumber;
            
            item.Status = Status;
            
            item.EmployeeID = EmployeeID;
            
            item.VendorID = VendorID;
            
            item.ShipMethodID = ShipMethodID;
            
            item.OrderDate = OrderDate;
            
            item.ShipDate = ShipDate;
            
            item.SubTotal = SubTotal;
            
            item.TaxAmt = TaxAmt;
            
            item.Freight = Freight;
            
            item.TotalDue = TotalDue;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int PurchaseOrderID,byte RevisionNumber,byte Status,int EmployeeID,int VendorID,int ShipMethodID,DateTime OrderDate,DateTime? ShipDate,decimal SubTotal,decimal TaxAmt,decimal Freight,decimal TotalDue,DateTime ModifiedDate)
	    {
		    PurchaseOrderHeader item = new PurchaseOrderHeader();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.PurchaseOrderID = PurchaseOrderID;
				
			item.RevisionNumber = RevisionNumber;
				
			item.Status = Status;
				
			item.EmployeeID = EmployeeID;
				
			item.VendorID = VendorID;
				
			item.ShipMethodID = ShipMethodID;
				
			item.OrderDate = OrderDate;
				
			item.ShipDate = ShipDate;
				
			item.SubTotal = SubTotal;
				
			item.TaxAmt = TaxAmt;
				
			item.Freight = Freight;
				
			item.TotalDue = TotalDue;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
