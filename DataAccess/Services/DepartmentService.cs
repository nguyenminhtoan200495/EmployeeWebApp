using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Services
{
    public class DepartmentService
    {
        private readonly EmployeeContext employeeContext;
        public DepartmentService()
        {
            employeeContext = new EmployeeContext();
        }
        public void AddDepartment(Department department)
        {
            employeeContext.Departments.Add(department);
            employeeContext.SaveChanges();
        }
        public List<Department> GetAllDepartments()
        {
            return employeeContext.Departments.ToList();
        }
        public void UpdateDepartment(Department department)
        {
            var newDepartment = employeeContext.Departments.FirstOrDefault(d => d.Id == department.Id);
            if (newDepartment != null)
            {
                newDepartment.NameDepartment = department.NameDepartment;
            }
            employeeContext.Entry(newDepartment).State = EntityState.Modified;
            employeeContext.SaveChanges();
        }
        public void DeleteDepartment(int Id)
        {
            var department = employeeContext.Departments.FirstOrDefault(d => d.Id == Id);
            employeeContext.Entry(department).State = EntityState.Deleted;
            employeeContext.SaveChanges();
        }

        public Department GetById(int Id)
        {
            var department = employeeContext.Departments.FirstOrDefault(d => d.Id == Id);
            return department;
        }
    }
}
