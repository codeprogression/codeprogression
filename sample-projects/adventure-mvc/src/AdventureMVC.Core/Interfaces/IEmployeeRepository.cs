using System.Collections.Generic;
using AdventureMVC.Core.Model;

namespace AdventureMVC.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        IPagedList<Employee> GetEmployees(int pageSize, int pageIndex);
        IList<Employee> GetAllEmployees();
        Employee GetEmployee(int employeeID);
        void SaveEmployee(Employee employee);
    }
}