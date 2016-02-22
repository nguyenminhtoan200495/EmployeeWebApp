using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string NameDepartment { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
