using System.Collections.Generic;
using AdventureMVC.Core.Interfaces;
using AdventureMVC.Core.Model;
using IBatisNet.DataMapper;

namespace AdventureMVC.Data.IBatis
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private ISqlMapper sqlMapper = Mapper.Instance();

        #region IEmployeeRepository Members
        public IPagedList<Employee> GetEmployees(int pageSize, int pageIndex)
        {
            var list = (IPagedList<Employee>)sqlMapper.QueryForList<Employee>("SelectEmployeesPaged", new PagingParameter(pageSize, pageIndex));

            return list;
        }

        public IList<Employee> GetAllEmployees()
        {
            return sqlMapper.QueryForList<Employee>("SelectEmployees",null);
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