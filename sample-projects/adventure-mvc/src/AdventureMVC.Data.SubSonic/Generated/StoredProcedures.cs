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
namespace AdventureWorks{
    public partial class SPs{
        
        /// <summary>
        /// Creates an object wrapper for the uspGetBillOfMaterials Procedure
        /// </summary>
        public static StoredProcedure UspGetBillOfMaterials(int? StartProductID, DateTime? CheckDate)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("uspGetBillOfMaterials", DataService.GetInstance("AdventureWorks"), "dbo");
        	
            sp.Command.AddParameter("@StartProductID", StartProductID, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@CheckDate", CheckDate, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the uspGetEmployeeManagers Procedure
        /// </summary>
        public static StoredProcedure UspGetEmployeeManagers(int? EmployeeID)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("uspGetEmployeeManagers", DataService.GetInstance("AdventureWorks"), "dbo");
        	
            sp.Command.AddParameter("@EmployeeID", EmployeeID, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the uspGetManagerEmployees Procedure
        /// </summary>
        public static StoredProcedure UspGetManagerEmployees(int? ManagerID)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("uspGetManagerEmployees", DataService.GetInstance("AdventureWorks"), "dbo");
        	
            sp.Command.AddParameter("@ManagerID", ManagerID, DbType.Int32, 0, 10);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the uspGetWhereUsedProductID Procedure
        /// </summary>
        public static StoredProcedure UspGetWhereUsedProductID(int? StartProductID, DateTime? CheckDate)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("uspGetWhereUsedProductID", DataService.GetInstance("AdventureWorks"), "dbo");
        	
            sp.Command.AddParameter("@StartProductID", StartProductID, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@CheckDate", CheckDate, DbType.DateTime, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the uspLogError Procedure
        /// </summary>
        public static StoredProcedure UspLogError(int? ErrorLogID)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("uspLogError", DataService.GetInstance("AdventureWorks"), "dbo");
        	
            sp.Command.AddOutputParameter("@ErrorLogID", DbType.Int32, 0, 10);
            
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the uspPrintError Procedure
        /// </summary>
        public static StoredProcedure UspPrintError()
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("uspPrintError", DataService.GetInstance("AdventureWorks"), "");
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the uspUpdateEmployeeHireInfo Procedure
        /// </summary>
        public static StoredProcedure UspUpdateEmployeeHireInfo(int? EmployeeID, string Title, DateTime? HireDate, DateTime? RateChangeDate, decimal? Rate, byte? PayFrequency, bool? CurrentFlag)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("uspUpdateEmployeeHireInfo", DataService.GetInstance("AdventureWorks"), "HumanResources");
        	
            sp.Command.AddParameter("@EmployeeID", EmployeeID, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@Title", Title, DbType.String, null, null);
        	
            sp.Command.AddParameter("@HireDate", HireDate, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@RateChangeDate", RateChangeDate, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@Rate", Rate, DbType.Currency, 4, 19);
        	
            sp.Command.AddParameter("@PayFrequency", PayFrequency, DbType.Byte, 0, 3);
        	
            sp.Command.AddParameter("@CurrentFlag", CurrentFlag, DbType.Boolean, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the uspUpdateEmployeeLogin Procedure
        /// </summary>
        public static StoredProcedure UspUpdateEmployeeLogin(int? EmployeeID, int? ManagerID, string LoginID, string Title, DateTime? HireDate, bool? CurrentFlag)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("uspUpdateEmployeeLogin", DataService.GetInstance("AdventureWorks"), "HumanResources");
        	
            sp.Command.AddParameter("@EmployeeID", EmployeeID, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@ManagerID", ManagerID, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@LoginID", LoginID, DbType.String, null, null);
        	
            sp.Command.AddParameter("@Title", Title, DbType.String, null, null);
        	
            sp.Command.AddParameter("@HireDate", HireDate, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@CurrentFlag", CurrentFlag, DbType.Boolean, null, null);
        	
            return sp;
        }
        
        /// <summary>
        /// Creates an object wrapper for the uspUpdateEmployeePersonalInfo Procedure
        /// </summary>
        public static StoredProcedure UspUpdateEmployeePersonalInfo(int? EmployeeID, string NationalIDNumber, DateTime? BirthDate, string MaritalStatus, string Gender)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("uspUpdateEmployeePersonalInfo", DataService.GetInstance("AdventureWorks"), "HumanResources");
        	
            sp.Command.AddParameter("@EmployeeID", EmployeeID, DbType.Int32, 0, 10);
        	
            sp.Command.AddParameter("@NationalIDNumber", NationalIDNumber, DbType.String, null, null);
        	
            sp.Command.AddParameter("@BirthDate", BirthDate, DbType.DateTime, null, null);
        	
            sp.Command.AddParameter("@MaritalStatus", MaritalStatus, DbType.String, null, null);
        	
            sp.Command.AddParameter("@Gender", Gender, DbType.String, null, null);
        	
            return sp;
        }
        
    }
    
}
