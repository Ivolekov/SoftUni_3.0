using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SoftUniEntities();
            //var employeeName = context.Employees
            //    .Where(e => e.Department.Name == "Research and Development")
            //    .OrderBy(e=>e.Salary)
            //    .ThenByDescending(e=>e.FirstName)
            //    .Select(e=>new
            //    {
            //        Firstname = e.FirstName,
            //        Lastname = e.LastName,
            //        DepartmentName = e.Department.Name,
            //        Salary = e.Salary
            //    });

            //foreach (var employee in employeeName)
            //{
            //    Console.WriteLine($"{employee.Firstname} {employee.Lastname} from {employee.DepartmentName} - ${employee.Salary:F2}");
            //}
            ////02
            //var address = new Address()
            //{
            //    AddressText = "Vitoska 15",
            //    TownID = 4
            //};

            //context.Addresses.Add(address);

            //Employee employee = context.Employees
            //    .FirstOrDefault(e => e.LastName == "Nakov");
            //employee.Address.AddressText = "Vitoska 15";
            //employee.Address.TownID = 4;
            //Console.WriteLine(employee.Address.AddressText);

            //context.SaveChanges();

            //05
            var project = context.Projects.Find(2);
            var employWithProject = project.Employees;
            foreach (var employee in employWithProject)
            {
                employee.Projects.Remove(project);
            }

            context.Projects.Remove(project);
            context.SaveChanges();
        }
    }
}
