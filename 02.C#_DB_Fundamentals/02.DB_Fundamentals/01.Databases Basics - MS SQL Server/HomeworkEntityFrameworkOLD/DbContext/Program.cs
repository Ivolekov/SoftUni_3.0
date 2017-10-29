using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbContext
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SoftUniEntities();
            Add(new Employee());
        }

        public static void Add(Employee employee)
        {
            var context = new SoftUniEntities();
            context.Employees.Add(employee);
            employee.FirstName = "Ivo";
            employee.LastName = "Lekov";
            employee.JobTitle = "SMD";
            employee.DepartmentID = 2;
            employee.HireDate = DateTime.Now;
            employee.Salary = 60000;
            context.SaveChanges();
            Console.WriteLine($"Employee added: {employee.LastName}, {employee.FirstName}");
        }
    }
}
