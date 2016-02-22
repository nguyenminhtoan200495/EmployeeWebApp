using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using DataAccess.Entities;

namespace DataAccess.Services
{
    public class EmployeeService
    {
        private readonly EmployeeContext employeeContext;

        public EmployeeService()
        {
            employeeContext = new EmployeeContext();
        }

        public void AddEmloyee(Employee employee)
        {
            employeeContext.Employees.Add(employee);
            employeeContext.SaveChanges();
        }
        public List<Employee> GetAllEmployees()
        {
            return employeeContext.Employees.ToList();
        }

        public List<SelectListItem> GetDepartment()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var department  in employeeContext.Departments.ToList())
            {
                SelectListItem newDepartment = new SelectListItem();
                newDepartment.Value = department.Id.ToString();
                newDepartment.Text = department.NameDepartment;
                list.Add(newDepartment);
            }
            return list;
        }
        public Employee GetById(int Id)
        {
            var employee = employeeContext.Employees.FirstOrDefault(d => d.Id == Id);
            return employee;
        }
        public void UpdateDepartment(Employee employee)
        {
            var newEmployee = employeeContext.Employees.FirstOrDefault(d => d.Id == employee.Id);
            if (newEmployee != null)
            {
                newEmployee.Name = employee.Name;
                newEmployee.Address = employee.Address;
                newEmployee.Email = employee.Email;
                newEmployee.DateOfBirth = employee.DateOfBirth;
                newEmployee.DepartmentId = employee.DepartmentId;
            }
            employeeContext.Entry(newEmployee).State = EntityState.Modified;
            employeeContext.SaveChanges();
        }
        public void DeleteEmployee(int Id)
        {
            var employee = employeeContext.Employees.FirstOrDefault(d => d.Id == Id);
            employeeContext.Entry(employee).State = EntityState.Deleted;
            employeeContext.SaveChanges();
        }
    }
}
