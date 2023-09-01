using CommonLayer;
using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IEmployeeBL
    {
        public IEnumerable<Employee> GetAllEmployee();
        public void AddEmployee(Employee employee);

        public void UpdateEmployee(Employee employee);

        public void DeleteEmployee(int? id);

        public Employee GetEmployeeData(int? empId);

        public Employee LoginEmployee(EmployeeLogin employeeAccount);

    }
}
