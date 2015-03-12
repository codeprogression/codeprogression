using System.Collections.Generic;
using AdventureMVC.Core.Interfaces;
using AdventureMVC.Core.Model;
using NHibernate.Criterion;

namespace AdventureMVC.Data.FluentNHibernate
{
    public class EmployeeRepository : RepositoryBase, IEmployeeRepository
    {

        public IPagedList<Employee> GetEmployees(int pageSize, int pageIndex)
        {
            return GetAllEmployees().ToPagedList(pageIndex, pageSize);
        }

        public IList<Employee> GetAllEmployees()
        {
            return CreateQuery("from Employee").List<Employee>();
        }

        public Employee GetEmployee(int employeeId)
        {
                var queryString = "from Employee where EmployeeID=:employeeId";
                return CreateQuery(queryString)
                    .SetString("employeeId", employeeId.ToString())
                    .UniqueResult<Employee>();
        }

        public void SaveEmployee(Employee employee)
        {
                Update(employee);
                Flush(); 
        }
    }
}