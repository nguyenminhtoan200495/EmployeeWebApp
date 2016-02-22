using System.Data.Entity;
using DataAccess.Entities;

namespace DataAccess
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("name=EmployeeDBConnectionString")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EmployeeContext>());
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
