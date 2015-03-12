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
    /// Controller class for BillOfMaterials
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class BillOfMaterialController
    {
        // Preload our schema..
        BillOfMaterial thisSchemaLoad = new BillOfMaterial();
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
        public BillOfMaterialCollection FetchAll()
        {
            BillOfMaterialCollection coll = new BillOfMaterialCollection();
            Query qry = new Query(BillOfMaterial.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public BillOfMaterialCollection FetchByID(object BillOfMaterialsID)
        {
            BillOfMaterialCollection coll = new BillOfMaterialCollection().Where("BillOfMaterialsID", BillOfMaterialsID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public BillOfMaterialCollection FetchByQuery(Query qry)
        {
            BillOfMaterialCollection coll = new BillOfMaterialCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object BillOfMaterialsID)
        {
            return (BillOfMaterial.Delete(BillOfMaterialsID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object BillOfMaterialsID)
        {
            return (BillOfMaterial.Destroy(BillOfMaterialsID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? ProductAssemblyID,int ComponentID,DateTime StartDate,DateTime? EndDate,string UnitMeasureCode,short BOMLevel,decimal PerAssemblyQty,DateTime ModifiedDate)
	    {
		    BillOfMaterial item = new BillOfMaterial();
		    
            item.ProductAssemblyID = ProductAssemblyID;
            
            item.ComponentID = ComponentID;
            
            item.StartDate = StartDate;
            
            item.EndDate = EndDate;
            
            item.UnitMeasureCode = UnitMeasureCode;
            
            item.BOMLevel = BOMLevel;
            
            item.PerAssemblyQty = PerAssemblyQty;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int BillOfMaterialsID,int? ProductAssemblyID,int ComponentID,DateTime StartDate,DateTime? EndDate,string UnitMeasureCode,short BOMLevel,decimal PerAssemblyQty,DateTime ModifiedDate)
	    {
		    BillOfMaterial item = new BillOfMaterial();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.BillOfMaterialsID = BillOfMaterialsID;
				
			item.ProductAssemblyID = ProductAssemblyID;
				
			item.ComponentID = ComponentID;
				
			item.StartDate = StartDate;
				
			item.EndDate = EndDate;
				
			item.UnitMeasureCode = UnitMeasureCode;
				
			item.BOMLevel = BOMLevel;
				
			item.PerAssemblyQty = PerAssemblyQty;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
