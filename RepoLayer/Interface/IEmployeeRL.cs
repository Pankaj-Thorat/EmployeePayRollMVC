using CommonLayer;
using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface IEmployeeRL
    {
        public IEnumerable<Employee> GetAllEmployee();
        public void AddEmployee(Employee employee);

        public void UpdateEmployee(Employee employee);

        public void DeleteEmployee(int? id);

        public Employee GetEmployeeData(int? id);

        public Employee LoginEmployee(EmployeeLogin employeeAccount);
    }
}
