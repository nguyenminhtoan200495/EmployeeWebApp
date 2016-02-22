using System.Web.Mvc;
using DataAccess.Entities;
using DataAccess.Services;

namespace WebApplication.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        private readonly DepartmentService departmentService  = new DepartmentService();
        public ActionResult Index()
        {
            return View(departmentService.GetAllDepartments());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Department department)
        {
            departmentService.AddDepartment(department);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int Id)
        {
            return View(departmentService.GetById(Id));
        }
        [HttpPost]
        public ActionResult Edit(Department department)
        {
            departmentService.UpdateDepartment(department);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Id)
        {
            return View(departmentService.GetById(Id));
        }
        [HttpPost]
        public ActionResult DeleteDepartment(int Id)
        {
            departmentService.DeleteDepartment(Id);
            return RedirectToAction("Index");
        }
    }
}