using System.Web.Mvc;
using DataAccess.Entities;
using DataAccess.Services;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        private readonly EmployeeService employeeService = new EmployeeService();
        private readonly DepartmentService departmentService = new DepartmentService();
        public ActionResult Index()
        {
            return View(employeeService.GetAllEmployees());
        }
        public ActionResult Create()
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            employeeViewModel.ListDepartment = employeeService.GetDepartment();
            return View(employeeViewModel);
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            employeeService.AddEmloyee(employee);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int Id)
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            employeeViewModel.ListDepartment = employeeService.GetDepartment();
            employeeViewModel.Id = employeeService.GetById(Id).Id;
            employeeViewModel.Name = employeeService.GetById(Id).Name;
            employeeViewModel.Address = employeeService.GetById(Id).Address;
            employeeViewModel.Email = employeeService.GetById(Id).Email;
            employeeViewModel.DateOfBirth = employeeService.GetById(Id).DateOfBirth;
            employeeViewModel.DepartmentId = employeeService.GetById(Id).DepartmentId;
            return View(employeeViewModel);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            employeeService.UpdateDepartment(employee);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Id)
        {
            return View(employeeService.GetById(Id));
        }
        [HttpPost]
        public ActionResult DeleteEmployee(int Id)
        {
            employeeService.DeleteEmployee(Id);
            return RedirectToAction("Index");
        }
    }
}