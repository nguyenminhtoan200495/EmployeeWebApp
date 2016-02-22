using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.ViewModels
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {
            ListDepartment = new List<SelectListItem>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int DepartmentId { get; set; }
        public List<SelectListItem> ListDepartment { get; set; }
    }
}