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
    /// Controller class for SalesOrderHeader
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SalesOrderHeaderController
    {
        // Preload our schema..
        SalesOrderHeader thisSchemaLoad = new SalesOrderHeader();
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
        public SalesOrderHeaderCollection FetchAll()
        {
            SalesOrderHeaderCollection coll = new SalesOrderHeaderCollection();
            Query qry = new Query(SalesOrderHeader.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SalesOrderHeaderCollection FetchByID(object SalesOrderID)
        {
            SalesOrderHeaderCollection coll = new SalesOrderHeaderCollection().Where("SalesOrderID", SalesOrderID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SalesOrderHeaderCollection FetchByQuery(Query qry)
        {
            SalesOrderHeaderCollection coll = new SalesOrderHeaderCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object SalesOrderID)
        {
            return (SalesOrderHeader.Delete(SalesOrderID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object SalesOrderID)
        {
            return (SalesOrderHeader.Destroy(SalesOrderID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(byte RevisionNumber,DateTime OrderDate,DateTime DueDate,DateTime? ShipDate,byte Status,bool OnlineOrderFlag,string SalesOrderNumber,string PurchaseOrderNumber,string AccountNumber,int CustomerID,int ContactID,int? SalesPersonID,int? TerritoryID,int BillToAddressID,int ShipToAddressID,int ShipMethodID,int? CreditCardID,string CreditCardApprovalCode,int? CurrencyRateID,decimal SubTotal,decimal TaxAmt,decimal Freight,decimal TotalDue,string Comment,Guid Rowguid,DateTime ModifiedDate)
	    {
		    SalesOrderHeader item = new SalesOrderHeader();
		    
            item.RevisionNumber = RevisionNumber;
            
            item.OrderDate = OrderDate;
            
            item.DueDate = DueDate;
            
            item.ShipDate = ShipDate;
            
            item.Status = Status;
            
            item.OnlineOrderFlag = OnlineOrderFlag;
            
            item.SalesOrderNumber = SalesOrderNumber;
            
            item.PurchaseOrderNumber = PurchaseOrderNumber;
            
            item.AccountNumber = AccountNumber;
            
            item.CustomerID = CustomerID;
            
            item.ContactID = ContactID;
            
            item.SalesPersonID = SalesPersonID;
            
            item.TerritoryID = TerritoryID;
            
            item.BillToAddressID = BillToAddressID;
            
            item.ShipToAddressID = ShipToAddressID;
            
            item.ShipMethodID = ShipMethodID;
            
            item.CreditCardID = CreditCardID;
            
            item.CreditCardApprovalCode = CreditCardApprovalCode;
            
            item.CurrencyRateID = CurrencyRateID;
            
            item.SubTotal = SubTotal;
            
            item.TaxAmt = TaxAmt;
            
            item.Freight = Freight;
            
            item.TotalDue = TotalDue;
            
            item.Comment = Comment;
            
            item.Rowguid = Rowguid;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int SalesOrderID,byte RevisionNumber,DateTime OrderDate,DateTime DueDate,DateTime? ShipDate,byte Status,bool OnlineOrderFlag,string SalesOrderNumber,string PurchaseOrderNumber,string AccountNumber,int CustomerID,int ContactID,int? SalesPersonID,int? TerritoryID,int BillToAddressID,int ShipToAddressID,int ShipMethodID,int? CreditCardID,string CreditCardApprovalCode,int? CurrencyRateID,decimal SubTotal,decimal TaxAmt,decimal Freight,decimal TotalDue,string Comment,Guid Rowguid,DateTime ModifiedDate)
	    {
		    SalesOrderHeader item = new SalesOrderHeader();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.SalesOrderID = SalesOrderID;
				
			item.RevisionNumber = RevisionNumber;
				
			item.OrderDate = OrderDate;
				
			item.DueDate = DueDate;
				
			item.ShipDate = ShipDate;
				
			item.Status = Status;
				
			item.OnlineOrderFlag = OnlineOrderFlag;
				
			item.SalesOrderNumber = SalesOrderNumber;
				
			item.PurchaseOrderNumber = PurchaseOrderNumber;
				
			item.AccountNumber = AccountNumber;
				
			item.CustomerID = CustomerID;
				
			item.ContactID = ContactID;
				
			item.SalesPersonID = SalesPersonID;
				
			item.TerritoryID = TerritoryID;
				
			item.BillToAddressID = BillToAddressID;
				
			item.ShipToAddressID = ShipToAddressID;
				
			item.ShipMethodID = ShipMethodID;
				
			item.CreditCardID = CreditCardID;
				
			item.CreditCardApprovalCode = CreditCardApprovalCode;
				
			item.CurrencyRateID = CurrencyRateID;
				
			item.SubTotal = SubTotal;
				
			item.TaxAmt = TaxAmt;
				
			item.Freight = Freight;
				
			item.TotalDue = TotalDue;
				
			item.Comment = Comment;
				
			item.Rowguid = Rowguid;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
