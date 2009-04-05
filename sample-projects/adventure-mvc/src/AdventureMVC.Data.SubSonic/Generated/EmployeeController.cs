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
    /// Controller class for Employee
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class EmployeeController
    {
        // Preload our schema..
        Employee thisSchemaLoad = new Employee();
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
        public EmployeeCollection FetchAll()
        {
            EmployeeCollection coll = new EmployeeCollection();
            Query qry = new Query(Employee.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public EmployeeCollection FetchByID(object EmployeeID)
        {
            EmployeeCollection coll = new EmployeeCollection().Where("EmployeeID", EmployeeID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public EmployeeCollection FetchByQuery(Query qry)
        {
            EmployeeCollection coll = new EmployeeCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object EmployeeID)
        {
            return (Employee.Delete(EmployeeID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object EmployeeID)
        {
            return (Employee.Destroy(EmployeeID) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string NationalIDNumber,int ContactID,string LoginID,int? ManagerID,string Title,DateTime BirthDate,string MaritalStatus,string Gender,DateTime HireDate,bool SalariedFlag,short VacationHours,short SickLeaveHours,bool CurrentFlag,Guid Rowguid,DateTime ModifiedDate)
	    {
		    Employee item = new Employee();
		    
            item.NationalIDNumber = NationalIDNumber;
            
            item.ContactID = ContactID;
            
            item.LoginID = LoginID;
            
            item.ManagerID = ManagerID;
            
            item.Title = Title;
            
            item.BirthDate = BirthDate;
            
            item.MaritalStatus = MaritalStatus;
            
            item.Gender = Gender;
            
            item.HireDate = HireDate;
            
            item.SalariedFlag = SalariedFlag;
            
            item.VacationHours = VacationHours;
            
            item.SickLeaveHours = SickLeaveHours;
            
            item.CurrentFlag = CurrentFlag;
            
            item.Rowguid = Rowguid;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int EmployeeID,string NationalIDNumber,int ContactID,string LoginID,int? ManagerID,string Title,DateTime BirthDate,string MaritalStatus,string Gender,DateTime HireDate,bool SalariedFlag,short VacationHours,short SickLeaveHours,bool CurrentFlag,Guid Rowguid,DateTime ModifiedDate)
	    {
		    Employee item = new Employee();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.EmployeeID = EmployeeID;
				
			item.NationalIDNumber = NationalIDNumber;
				
			item.ContactID = ContactID;
				
			item.LoginID = LoginID;
				
			item.ManagerID = ManagerID;
				
			item.Title = Title;
				
			item.BirthDate = BirthDate;
				
			item.MaritalStatus = MaritalStatus;
				
			item.Gender = Gender;
				
			item.HireDate = HireDate;
				
			item.SalariedFlag = SalariedFlag;
				
			item.VacationHours = VacationHours;
				
			item.SickLeaveHours = SickLeaveHours;
				
			item.CurrentFlag = CurrentFlag;
				
			item.Rowguid = Rowguid;
				
			item.ModifiedDate = ModifiedDate;
				
	        item.Save(UserName);
	    }
    }
}
