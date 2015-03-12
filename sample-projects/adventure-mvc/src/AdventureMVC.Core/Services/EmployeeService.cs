using System;
using System.Collections.Generic;
using AdventureMVC.Core.Interfaces;
using AdventureMVC.Core.Model;

namespace AdventureMVC.Core.Services
{
    public class EmployeeService
    {
        IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public IList<Employee> GetEmployees(int pageSize, int pageIndex)
        {
            return _repository.GetEmployees(pageSize, pageIndex);
        }
        public IList<Employee> GetAllEmployees()
        {
            return _repository.GetAllEmployees();
        }
        public void SaveEmployee(Employee employee)
        {
            //?Should optimistic locking be used here or at each repository implementation?
            _repository.SaveEmployee(employee);
        }
        public Employee GetEmployee(int employeeID)
        {
            return _repository.GetEmployee(employeeID);
        }
    }
}