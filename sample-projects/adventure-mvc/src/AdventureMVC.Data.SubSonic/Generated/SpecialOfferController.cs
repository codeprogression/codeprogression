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
    /// Controller class for SpecialOffer
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SpecialOfferController
    {
        // Preload our schema..
        SpecialOffer thisSchemaLoad = new SpecialOffer();
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
        public SpecialOfferCollection FetchAll()
        {
            SpecialOfferCollection coll = new SpecialOfferCollection();
            Query qry = new Query(SpecialOffer.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SpecialOfferCollection FetchByID(object SpecialOfferID)
        {
            SpecialOfferCollection coll = new SpecialOfferCollection().Where("SpecialOfferID", SpecialOfferID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SpecialOfferCollection FetchByQuery(Query qry)
        {
            SpecialOfferCollection coll = new SpecialOfferCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object SpecialOfferID)
        {
            return (SpecialOffer.Delete(SpecialOfferID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object SpecialOfferID)
        {
            return (SpecialOffer.Destroy(SpecialOfferID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Description,decimal DiscountPct,string Type,string Category,DateTime StartDate,DateTime EndDate,int MinQty,int? MaxQty,Guid Rowguid,DateTime ModifiedDate)
	    {
		    SpecialOffer item = new SpecialOffer();
		    
            item.Description = Description;
            
            item.DiscountPct = DiscountPct;
            
            item.Type = Type;
            
            item.Category = Category;
            
            item.StartDate = StartDate;
            
            item.EndDate = EndDate;
            
            item.MinQty = MinQty;
            
            item.MaxQty = MaxQty;
            
            item.Rowguid = Rowguid;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int SpecialOfferID,string Description,decimal DiscountPct,string Type,string Category,DateTime StartDate,DateTime EndDate,int MinQty,int? MaxQty,Guid Rowguid,DateTime ModifiedDate)
	    {
		    SpecialOffer item = new SpecialOffer();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.SpecialOfferID = SpecialOfferID;
				
			item.Description = Description;
				
			item.DiscountPct = DiscountPct;
				
			item.Type = Type;
				
			item.Category = Category;
				
			item.StartDate = StartDate;
				
			item.EndDate = EndDate;
				
			item.MinQty = MinQty;
				
			item.MaxQty = MaxQty;
				
			item.Rowguid = Rowguid;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
