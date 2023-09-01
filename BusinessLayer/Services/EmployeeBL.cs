using BusinessLayer.Interface;
using CommonLayer;
using CommonLayer.Model;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class EmployeeBL: IEmployeeBL
    {
        IEmployeeRL irepo;


        public EmployeeBL (IEmployeeRL irepo)
        {
            this.irepo = irepo;
        }
        public IEnumerable<Employee> GetAllEmployee()
        {
            return this.irepo.GetAllEmployee();
        }
        public void AddEmployee(Employee employee)
        {
             this.irepo.AddEmployee(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
             this.irepo.UpdateEmployee(employee);
        }

        public void DeleteEmployee(int? id)
        {
            this.irepo.DeleteEmployee(id);
        }

        public Employee GetEmployeeData(int? empId)
        {
            return this.irepo.GetEmployeeData(empId);
        }

        public Employee LoginEmployee(EmployeeLogin employeeAccount)
        {
            return this.irepo.LoginEmployee(employeeAccount);
        }


    }
}
