using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace DAL
{
    public class Employee
    {
        [Key]
        public int Empid { get; set; }
        public string Empname { get; set; }
        public string Age { get; set; }


    }


    public class EmployeeDBContext : DbContext
    {


        public EmployeeDBContext() : base("empdb")
        {
            //DropCreateDatabaseIfModelChanges<ContextClass>
        }


        public DbSet<Employee> Employees { get; set; }

    }

}
