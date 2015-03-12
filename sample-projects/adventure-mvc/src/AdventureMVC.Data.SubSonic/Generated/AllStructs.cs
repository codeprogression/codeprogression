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
	#region Tables Struct
	public partial struct Tables
	{
		
		public static string Address = @"Address";
        
		public static string AddressType = @"AddressType";
        
		public static string AWBuildVersion = @"AWBuildVersion";
        
		public static string BillOfMaterial = @"BillOfMaterials";
        
		public static string Contact = @"Contact";
        
		public static string ContactCreditCard = @"ContactCreditCard";
        
		public static string ContactType = @"ContactType";
        
		public static string CountryRegion = @"CountryRegion";
        
		public static string CountryRegionCurrency = @"CountryRegionCurrency";
        
		public static string CreditCard = @"CreditCard";
        
		public static string Culture = @"Culture";
        
		public static string Currency = @"Currency";
        
		public static string CurrencyRate = @"CurrencyRate";
        
		public static string Customer = @"Customer";
        
		public static string CustomerAddress = @"CustomerAddress";
        
		public static string DatabaseLog = @"DatabaseLog";
        
		public static string Department = @"Department";
        
		public static string Document = @"Document";
        
		public static string Employee = @"Employee";
        
		public static string EmployeeAddress = @"EmployeeAddress";
        
		public static string EmployeeDepartmentHistory = @"EmployeeDepartmentHistory";
        
		public static string EmployeePayHistory = @"EmployeePayHistory";
        
		public static string ErrorLog = @"ErrorLog";
        
		public static string Illustration = @"Illustration";
        
		public static string Individual = @"Individual";
        
		public static string JobCandidate = @"JobCandidate";
        
		public static string Location = @"Location";
        
		public static string Product = @"Product";
        
		public static string ProductCategory = @"ProductCategory";
        
		public static string ProductCostHistory = @"ProductCostHistory";
        
		public static string ProductDescription = @"ProductDescription";
        
		public static string ProductDocument = @"ProductDocument";
        
		public static string ProductInventory = @"ProductInventory";
        
		public static string ProductListPriceHistory = @"ProductListPriceHistory";
        
		public static string ProductModel = @"ProductModel";
        
		public static string ProductModelIllustration = @"ProductModelIllustration";
        
		public static string ProductModelProductDescriptionCulture = @"ProductModelProductDescriptionCulture";
        
		public static string ProductPhoto = @"ProductPhoto";
        
		public static string ProductProductPhoto = @"ProductProductPhoto";
        
		public static string ProductReview = @"ProductReview";
        
		public static string ProductSubcategory = @"ProductSubcategory";
        
		public static string ProductVendor = @"ProductVendor";
        
		public static string PurchaseOrderDetail = @"PurchaseOrderDetail";
        
		public static string PurchaseOrderHeader = @"PurchaseOrderHeader";
        
		public static string SalesOrderDetail = @"SalesOrderDetail";
        
		public static string SalesOrderHeader = @"SalesOrderHeader";
        
		public static string SalesOrderHeaderSalesReason = @"SalesOrderHeaderSalesReason";
        
		public static string SalesPerson = @"SalesPerson";
        
		public static string SalesPersonQuotaHistory = @"SalesPersonQuotaHistory";
        
		public static string SalesReason = @"SalesReason";
        
		public static string SalesTaxRate = @"SalesTaxRate";
        
		public static string SalesTerritory = @"SalesTerritory";
        
		public static string SalesTerritoryHistory = @"SalesTerritoryHistory";
        
		public static string ScrapReason = @"ScrapReason";
        
		public static string Shift = @"Shift";
        
		public static string ShipMethod = @"ShipMethod";
        
		public static string ShoppingCartItem = @"ShoppingCartItem";
        
		public static string SpecialOffer = @"SpecialOffer";
        
		public static string SpecialOfferProduct = @"SpecialOfferProduct";
        
		public static string StateProvince = @"StateProvince";
        
		public static string Store = @"Store";
        
		public static string StoreContact = @"StoreContact";
        
		public static string TransactionHistory = @"TransactionHistory";
        
		public static string TransactionHistoryArchive = @"TransactionHistoryArchive";
        
		public static string UnitMeasure = @"UnitMeasure";
        
		public static string Vendor = @"Vendor";
        
		public static string VendorAddress = @"VendorAddress";
        
		public static string VendorContact = @"VendorContact";
        
		public static string WorkOrder = @"WorkOrder";
        
		public static string WorkOrderRouting = @"WorkOrderRouting";
        
	}
	#endregion
    #region Schemas
    public partial class Schemas {
		
		public static TableSchema.Table Address{
            get { return DataService.GetSchema("Address","AdventureWorks"); }
		}
        
		public static TableSchema.Table AddressType{
            get { return DataService.GetSchema("AddressType","AdventureWorks"); }
		}
        
		public static TableSchema.Table AWBuildVersion{
            get { return DataService.GetSchema("AWBuildVersion","AdventureWorks"); }
		}
        
		public static TableSchema.Table BillOfMaterial{
            get { return DataService.GetSchema("BillOfMaterials","AdventureWorks"); }
		}
        
		public static TableSchema.Table Contact{
            get { return DataService.GetSchema("Contact","AdventureWorks"); }
		}
        
		public static TableSchema.Table ContactCreditCard{
            get { return DataService.GetSchema("ContactCreditCard","AdventureWorks"); }
		}
        
		public static TableSchema.Table ContactType{
            get { return DataService.GetSchema("ContactType","AdventureWorks"); }
		}
        
		public static TableSchema.Table CountryRegion{
            get { return DataService.GetSchema("CountryRegion","AdventureWorks"); }
		}
        
		public static TableSchema.Table CountryRegionCurrency{
            get { return DataService.GetSchema("CountryRegionCurrency","AdventureWorks"); }
		}
        
		public static TableSchema.Table CreditCard{
            get { return DataService.GetSchema("CreditCard","AdventureWorks"); }
		}
        
		public static TableSchema.Table Culture{
            get { return DataService.GetSchema("Culture","AdventureWorks"); }
		}
        
		public static TableSchema.Table Currency{
            get { return DataService.GetSchema("Currency","AdventureWorks"); }
		}
        
		public static TableSchema.Table CurrencyRate{
            get { return DataService.GetSchema("CurrencyRate","AdventureWorks"); }
		}
        
		public static TableSchema.Table Customer{
            get { return DataService.GetSchema("Customer","AdventureWorks"); }
		}
        
		public static TableSchema.Table CustomerAddress{
            get { return DataService.GetSchema("CustomerAddress","AdventureWorks"); }
		}
        
		public static TableSchema.Table DatabaseLog{
            get { return DataService.GetSchema("DatabaseLog","AdventureWorks"); }
		}
        
		public static TableSchema.Table Department{
            get { return DataService.GetSchema("Department","AdventureWorks"); }
		}
        
		public static TableSchema.Table Document{
            get { return DataService.GetSchema("Document","AdventureWorks"); }
		}
        
		public static TableSchema.Table Employee{
            get { return DataService.GetSchema("Employee","AdventureWorks"); }
		}
        
		public static TableSchema.Table EmployeeAddress{
            get { return DataService.GetSchema("EmployeeAddress","AdventureWorks"); }
		}
        
		public static TableSchema.Table EmployeeDepartmentHistory{
            get { return DataService.GetSchema("EmployeeDepartmentHistory","AdventureWorks"); }
		}
        
		public static TableSchema.Table EmployeePayHistory{
            get { return DataService.GetSchema("EmployeePayHistory","AdventureWorks"); }
		}
        
		public static TableSchema.Table ErrorLog{
            get { return DataService.GetSchema("ErrorLog","AdventureWorks"); }
		}
        
		public static TableSchema.Table Illustration{
            get { return DataService.GetSchema("Illustration","AdventureWorks"); }
		}
        
		public static TableSchema.Table Individual{
            get { return DataService.GetSchema("Individual","AdventureWorks"); }
		}
        
		public static TableSchema.Table JobCandidate{
            get { return DataService.GetSchema("JobCandidate","AdventureWorks"); }
		}
        
		public static TableSchema.Table Location{
            get { return DataService.GetSchema("Location","AdventureWorks"); }
		}
        
		public static TableSchema.Table Product{
            get { return DataService.GetSchema("Product","AdventureWorks"); }
		}
        
		public static TableSchema.Table ProductCategory{
            get { return DataService.GetSchema("ProductCategory","AdventureWorks"); }
		}
        
		public static TableSchema.Table ProductCostHistory{
            get { return DataService.GetSchema("ProductCostHistory","AdventureWorks"); }
		}
        
		public static TableSchema.Table ProductDescription{
            get { return DataService.GetSchema("ProductDescription","AdventureWorks"); }
		}
        
		public static TableSchema.Table ProductDocument{
            get { return DataService.GetSchema("ProductDocument","AdventureWorks"); }
		}
        
		public static TableSchema.Table ProductInventory{
            get { return DataService.GetSchema("ProductInventory","AdventureWorks"); }
		}
        
		public static TableSchema.Table ProductListPriceHistory{
            get { return DataService.GetSchema("ProductListPriceHistory","AdventureWorks"); }
		}
        
		public static TableSchema.Table ProductModel{
            get { return DataService.GetSchema("ProductModel","AdventureWorks"); }
		}
        
		public static TableSchema.Table ProductModelIllustration{
            get { return DataService.GetSchema("ProductModelIllustration","AdventureWorks"); }
		}
        
		public static TableSchema.Table ProductModelProductDescriptionCulture{
            get { return DataService.GetSchema("ProductModelProductDescriptionCulture","AdventureWorks"); }
		}
        
		public static TableSchema.Table ProductPhoto{
            get { return DataService.GetSchema("ProductPhoto","AdventureWorks"); }
		}
        
		public static TableSchema.Table ProductProductPhoto{
            get { return DataService.GetSchema("ProductProductPhoto","AdventureWorks"); }
		}
        
		public static TableSchema.Table ProductReview{
            get { return DataService.GetSchema("ProductReview","AdventureWorks"); }
		}
        
		public static TableSchema.Table ProductSubcategory{
            get { return DataService.GetSchema("ProductSubcategory","AdventureWorks"); }
		}
        
		public static TableSchema.Table ProductVendor{
            get { return DataService.GetSchema("ProductVendor","AdventureWorks"); }
		}
        
		public static TableSchema.Table PurchaseOrderDetail{
            get { return DataService.GetSchema("PurchaseOrderDetail","AdventureWorks"); }
		}
        
		public static TableSchema.Table PurchaseOrderHeader{
            get { return DataService.GetSchema("PurchaseOrderHeader","AdventureWorks"); }
		}
        
		public static TableSchema.Table SalesOrderDetail{
            get { return DataService.GetSchema("SalesOrderDetail","AdventureWorks"); }
		}
        
		public static TableSchema.Table SalesOrderHeader{
            get { return DataService.GetSchema("SalesOrderHeader","AdventureWorks"); }
		}
        
		public static TableSchema.Table SalesOrderHeaderSalesReason{
            get { return DataService.GetSchema("SalesOrderHeaderSalesReason","AdventureWorks"); }
		}
        
		public static TableSchema.Table SalesPerson{
            get { return DataService.GetSchema("SalesPerson","AdventureWorks"); }
		}
        
		public static TableSchema.Table SalesPersonQuotaHistory{
            get { return DataService.GetSchema("SalesPersonQuotaHistory","AdventureWorks"); }
		}
        
		public static TableSchema.Table SalesReason{
            get { return DataService.GetSchema("SalesReason","AdventureWorks"); }
		}
        
		public static TableSchema.Table SalesTaxRate{
            get { return DataService.GetSchema("SalesTaxRate","AdventureWorks"); }
		}
        
		public static TableSchema.Table SalesTerritory{
            get { return DataService.GetSchema("SalesTerritory","AdventureWorks"); }
		}
        
		public static TableSchema.Table SalesTerritoryHistory{
            get { return DataService.GetSchema("SalesTerritoryHistory","AdventureWorks"); }
		}
        
		public static TableSchema.Table ScrapReason{
            get { return DataService.GetSchema("ScrapReason","AdventureWorks"); }
		}
        
		public static TableSchema.Table Shift{
            get { return DataService.GetSchema("Shift","AdventureWorks"); }
		}
        
		public static TableSchema.Table ShipMethod{
            get { return DataService.GetSchema("ShipMethod","AdventureWorks"); }
		}
        
		public static TableSchema.Table ShoppingCartItem{
            get { return DataService.GetSchema("ShoppingCartItem","AdventureWorks"); }
		}
        
		public static TableSchema.Table SpecialOffer{
            get { return DataService.GetSchema("SpecialOffer","AdventureWorks"); }
		}
        
		public static TableSchema.Table SpecialOfferProduct{
            get { return DataService.GetSchema("SpecialOfferProduct","AdventureWorks"); }
		}
        
		public static TableSchema.Table StateProvince{
            get { return DataService.GetSchema("StateProvince","AdventureWorks"); }
		}
        
		public static TableSchema.Table Store{
            get { return DataService.GetSchema("Store","AdventureWorks"); }
		}
        
		public static TableSchema.Table StoreContact{
            get { return DataService.GetSchema("StoreContact","AdventureWorks"); }
		}
        
		public static TableSchema.Table TransactionHistory{
            get { return DataService.GetSchema("TransactionHistory","AdventureWorks"); }
		}
        
		public static TableSchema.Table TransactionHistoryArchive{
            get { return DataService.GetSchema("TransactionHistoryArchive","AdventureWorks"); }
		}
        
		public static TableSchema.Table UnitMeasure{
            get { return DataService.GetSchema("UnitMeasure","AdventureWorks"); }
		}
        
		public static TableSchema.Table Vendor{
            get { return DataService.GetSchema("Vendor","AdventureWorks"); }
		}
        
		public static TableSchema.Table VendorAddress{
            get { return DataService.GetSchema("VendorAddress","AdventureWorks"); }
		}
        
		public static TableSchema.Table VendorContact{
            get { return DataService.GetSchema("VendorContact","AdventureWorks"); }
		}
        
		public static TableSchema.Table WorkOrder{
            get { return DataService.GetSchema("WorkOrder","AdventureWorks"); }
		}
        
		public static TableSchema.Table WorkOrderRouting{
            get { return DataService.GetSchema("WorkOrderRouting","AdventureWorks"); }
		}
        
	
    }
    #endregion
    #region View Struct
    public partial struct Views 
    {
		
		public static string VAdditionalContactInfo = @"vAdditionalContactInfo";
        
		public static string VEmployee = @"vEmployee";
        
		public static string VEmployeeDepartment = @"vEmployeeDepartment";
        
		public static string VEmployeeDepartmentHistory = @"vEmployeeDepartmentHistory";
        
		public static string VIndividualCustomer = @"vIndividualCustomer";
        
		public static string VIndividualDemographic = @"vIndividualDemographics";
        
		public static string VJobCandidate = @"vJobCandidate";
        
		public static string VJobCandidateEducation = @"vJobCandidateEducation";
        
		public static string VJobCandidateEmployment = @"vJobCandidateEmployment";
        
		public static string VProductAndDescription = @"vProductAndDescription";
        
		public static string VProductModelCatalogDescription = @"vProductModelCatalogDescription";
        
		public static string VProductModelInstruction = @"vProductModelInstructions";
        
		public static string VSalesPerson = @"vSalesPerson";
        
		public static string VSalesPersonSalesByFiscalYear = @"vSalesPersonSalesByFiscalYears";
        
		public static string VStateProvinceCountryRegion = @"vStateProvinceCountryRegion";
        
		public static string VStoreWithDemographic = @"vStoreWithDemographics";
        
		public static string VVendor = @"vVendor";
        
    }
    #endregion
    
    #region Query Factories
	public static partial class DB
	{
        public static DataProvider _provider = DataService.Providers["AdventureWorks"];
        static ISubSonicRepository _repository;
        public static ISubSonicRepository Repository {
            get {
                if (_repository == null)
                    return new SubSonicRepository(_provider);
                return _repository; 
            }
            set { _repository = value; }
        }
	
        public static Select SelectAllColumnsFrom<T>() where T : RecordBase<T>, new()
	    {
            return Repository.SelectAllColumnsFrom<T>();
            
	    }
	    public static Select Select()
	    {
            return Repository.Select();
	    }
	    
		public static Select Select(params string[] columns)
		{
            return Repository.Select(columns);
        }
	    
		public static Select Select(params Aggregate[] aggregates)
		{
            return Repository.Select(aggregates);
        }
   
	    public static Update Update<T>() where T : RecordBase<T>, new()
	    {
            return Repository.Update<T>();
	    }
     
	    
	    public static Insert Insert()
	    {
            return Repository.Insert();
	    }
	    
	    public static Delete Delete()
	    {
            
            return Repository.Delete();
	    }
	    
	    public static InlineQuery Query()
	    {
            
            return Repository.Query();
	    }
	    	    
	    
	}
    #endregion
    
}
#region Databases
public partial struct Databases 
{
	
	public static string AdventureWorks = @"AdventureWorks";
    
}
#endregion