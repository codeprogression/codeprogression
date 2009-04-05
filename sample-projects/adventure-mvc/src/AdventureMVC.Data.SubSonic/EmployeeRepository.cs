using System.Collections.Generic;
using AdventureMVC.Core.Interfaces;
using AdventureMVC.Core.Model;

namespace AdventureMVC.Data.SubSonic
{
    public class EmployeeRepository : IEmployeeRepository
    {
        #region IEmployeeRepository Members

        public IPagedList<Employee> GetEmployees(int pageSize, int pageIndex)
        {
            return
                (IPagedList<Employee>)
                AdventureWorks.DB.Select(AdventureWorks.Employee.Columns.EmployeeID,
                                         AdventureWorks.Employee.Columns.VacationHours,
                                         AdventureWorks.Employee.Columns.SickLeaveHours,
                                         AdventureWorks.Contact.Columns.FirstName,
                                         AdventureWorks.Contact.Columns.LastName).From<AdventureWorks.Contact>().Paged(
                    pageIndex, pageSize).InnerJoin<AdventureWorks.Employee>().ExecuteTypedList<Employee>();
        }

        public IList<Employee> GetAllEmployees()
        {
            return
                AdventureWorks.DB.Select(AdventureWorks.Employee.Columns.EmployeeID,
                                         AdventureWorks.Employee.Columns.VacationHours,
                                         AdventureWorks.Employee.Columns.SickLeaveHours,
                                         AdventureWorks.Contact.Columns.FirstName,
                                         AdventureWorks.Contact.Columns.LastName)
                                         .From<AdventureWorks.Contact>()
                                         .InnerJoin<AdventureWorks.Employee>().ExecuteTypedList<Employee>();
        }

        public Employee GetEmployee(int employeeID)
        {
            return AdventureWorks.DB.Select(AdventureWorks.Employee.Columns.EmployeeID,
                                         AdventureWorks.Employee.Columns.VacationHours,
                                         AdventureWorks.Employee.Columns.SickLeaveHours,
                                         AdventureWorks.Contact.Columns.FirstName,
                                         AdventureWorks.Contact.Columns.LastName)
                    .From<AdventureWorks.Contact>()
                    .InnerJoin<AdventureWorks.Employee>()
                    .Where(AdventureWorks.Employee.Columns.EmployeeID).IsEqualTo(employeeID)
                    .ExecuteSingle<Employee>();
            
        }

        public void SaveEmployee(Employee employee)
        {
            AdventureWorks.Employee ssEmployee = AdventureWorks.Employee.FetchByID(employee.EmployeeID);
            ssEmployee.Contact.FirstName = employee.FirstName;
            ssEmployee.Contact.LastName = employee.LastName;
            ssEmployee.SickLeaveHours = (short)employee.SickLeaveHours;
            ssEmployee.VacationHours = (short)employee.VacationHours;
            ssEmployee.Save();
        }

        #endregion
    }
}