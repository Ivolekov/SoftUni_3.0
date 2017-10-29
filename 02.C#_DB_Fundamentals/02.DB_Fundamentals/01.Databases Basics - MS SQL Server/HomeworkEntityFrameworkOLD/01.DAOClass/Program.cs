using System;
using System.Linq;
using DbContext;

namespace _01.DAOClass
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SoftUniEntities();
            Add(new Employee());
            FindByKey(29);
            Modify(new Employee());
            Delete(new Employee());
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

        public static Employee FindByKey(int key)
        {
            var context = new SoftUniEntities();
            var employee = context.Employees
                .FirstOrDefault(e => e.EmployeeID == key);
            Console.WriteLine($"{employee.FirstName} {employee.LastName}");
            return employee;
        }

        public static void Modify(Employee employee)
        {
            var context = new SoftUniEntities();
            var employeeForModify = context.Employees.FirstOrDefault(e => e.LastName == "Lekov");
            employeeForModify.FirstName = "DR...";
            context.SaveChanges();
            Console.WriteLine($"Employee: {employeeForModify.FirstName} {employeeForModify.LastName}");
        }

        public static void Delete(Employee employee)
        {
            var context = new SoftUniEntities();
            var deleteEmployee = context.Employees.FirstOrDefault(e => e.LastName == "Lekov");
            context.Employees.Remove(deleteEmployee);
            context.SaveChanges();
            Console.WriteLine($"{deleteEmployee.FirstName} {deleteEmployee.LastName} has been terminated!!!");
        }
    }
}
