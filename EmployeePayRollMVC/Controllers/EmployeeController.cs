using BusinessLayer.Interface;
using CommonLayer;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePayRollMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeBL employeeBL;

        public EmployeeController(IEmployeeBL employeeBL)
        {
            this.employeeBL = employeeBL;
        }
        public IActionResult Index()
        {
            List<Employee> lstEmployee = new List<Employee>();
            lstEmployee = employeeBL.GetAllEmployee().ToList();

            return View(lstEmployee);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeBL.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee employee = employeeBL.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Employee employee)
        {
            if (id != employee.EmpId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                employeeBL.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Details()
        {
            int empId = (int)HttpContext.Session.GetInt32("EmpId");
            string empName = HttpContext.Session.GetString("EmpName");
            if (empId  != 0 && empName != null) 
            {
                if (empId == 8 && empName == "Pankaj")
                {
                    return RedirectToAction("Index");
                }
                Employee employee = employeeBL.GetEmployeeData(empId);
               
                if (employee == null)
                {
                    return NotFound();
                }
                return View(employee);
                
            }
            else
            {
                return RedirectToAction("Login");
            }
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee employee = employeeBL.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            employeeBL.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Login()
        {
            var employeeLoginModel = new EmployeeLogin();
            return View(employeeLoginModel);
        }


        [HttpPost]
        public IActionResult Login([Bind] EmployeeLogin login)
        {
            if (ModelState.IsValid)
            {
                var result = employeeBL.LoginEmployee(login);
                if (result != null)
                {
                    HttpContext.Session.SetInt32("EmpId", result.EmpId);
                    HttpContext.Session.SetString("EmpName", result.EmpName);
                    ViewBag.Message = "Login successful!";
                    return RedirectToAction("Details");
                }
                else
                {
                    return View(login);
                }
            }
            return View(login);
        }


    }
}
