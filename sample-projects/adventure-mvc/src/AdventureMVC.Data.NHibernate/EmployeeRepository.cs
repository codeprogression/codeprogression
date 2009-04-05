using System.Collections.Generic;
using AdventureMVC.Core.Interfaces;
using AdventureMVC.Core.Model;

namespace AdventureMVC.Data.NHibernate
{
    public class EmployeeRepository : RepositoryBase, IEmployeeRepository
    {
        public EmployeeRepository(ISessionBuilder sessionFactory) : base(sessionFactory)
        {
        }

        #region IEmployeeRepository Members


        public IPagedList<Employee> GetEmployees(int pageSize, int pageIndex)
        {
            return GetAllEmployees().ToPagedList(pageIndex, pageSize);
        }

        public IList<Employee> GetAllEmployees()
        {
            return getSession().CreateQuery("from Employee").List<Employee>();
        }

        public Employee GetEmployee(int employeeID)
        {
            throw new System.NotImplementedException();
        }

        public void SaveEmployee(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}