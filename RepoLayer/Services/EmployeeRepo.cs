using CommonLayer;
using CommonLayer.Model;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepoLayer.Services
{
    public class EmployeeRepo : IEmployeeRL
    {
        string connectionString = "Data Source=PANKAJ\\SQLEXPRESS;Initial Catalog=Employee; Integrated Security = True ;";

        //To View all employees details      
        public IEnumerable<Employee> GetAllEmployee()
        {
            List<Employee> lstemployee = new List<Employee>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Employee employee = new Employee();
                    employee.EmpId = Convert.ToInt32(rdr["EmpId"]);
                    employee.EmpName = rdr["EmpName"].ToString();
                    employee.ProfileImg = rdr["ProfileImg"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Salary = Convert.ToInt32(rdr["Salary"]);
                    employee.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                    employee.Notes = rdr["Notes"].ToString();

                    lstemployee.Add(employee);
                }
                con.Close();
            }
            return lstemployee;
        }

        //To Add new employee record      
        public void AddEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpName", employee.EmpName);
                cmd.Parameters.AddWithValue("@ProfileImg", employee.ProfileImg);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.Parameters.AddWithValue("@StartDate", employee.StartDate);
                cmd.Parameters.AddWithValue("@Notes", employee.Notes);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //To Update the records of a particluar employee    
        public void UpdateEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@EmpId", employee.EmpId);
                cmd.Parameters.AddWithValue("@EmpName", employee.EmpName);
                cmd.Parameters.AddWithValue("@ProfileImg", employee.ProfileImg);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.Parameters.AddWithValue("@StartDate", employee.StartDate);
                cmd.Parameters.AddWithValue("@Notes", employee.Notes);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //Get the details of a particular employee    
        public Employee GetEmployeeData(int? id)
        {
            Employee employee = new Employee();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM EmployeeMVC WHERE EmpId= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);


                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    employee.EmpId = Convert.ToInt32(rdr["EmpId"]);
                    employee.EmpName = rdr["EmpName"].ToString();
                    employee.ProfileImg = rdr["ProfileImg"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Salary = Convert.ToInt32(rdr["Salary"]);
                    employee.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                    employee.Notes = rdr["Notes"].ToString();
                }
            }
            return employee;
        }

        //To Delete the record on a particular employee    
        public void DeleteEmployee(int? id)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Employee LoginEmployee(EmployeeLogin employeeAccount)
        {
            Employee employee = null;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("spLoginEmployee", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpId", employeeAccount.EmpId); 

                    var returnParameter = cmd.Parameters.Add("@Result", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        var result = returnParameter.Value;

                        if (result != null && result.Equals(2))
                        {
                            throw new Exception("Employee not present");
                        }

                        if (rdr.Read())
                        {
                            employee = new Employee();
                            employee.EmpId = Convert.ToInt32(rdr["EmpId"]);
                            employee.EmpName = rdr["EmpName"].ToString();
                            employee.ProfileImg = rdr["ProfileImg"].ToString();
                            employee.Department = rdr["Department"].ToString();
                            employee.Gender = rdr["Gender"].ToString();
                            employee.Salary = Convert.ToInt32(rdr["Salary"]);
                            employee.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                            employee.Notes = rdr["Notes"].ToString();
                        }
                    }
                }
            }
            return employee;
        }


    }
}
