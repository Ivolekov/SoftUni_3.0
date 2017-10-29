namespace _03.EmployeesFull
{
    using SoftuniDatabase;
    using System.Linq;
    using System;
    using SoftuniDatabase.Models;
    using System.Collections.Generic;
    using System.Diagnostics;
    using GringottsDb;

    class Program
    {
        static void Main(string[] args)
        {
            //03.
            var context = new SoftuniContext();
            var grContext = new GringottsContext();
            //var employees = context.Employees;

            //foreach (var e in employees)
            //{
            //    System.Console.WriteLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary}");
            //}

            //04
            //var employeesNames = context.Employees
            //    .Where(e => e.Salary > 50000)
            //    .Select(e => e.FirstName);

            //foreach (var empl in employeesNames)
            //{
            //    Console.WriteLine(empl);
            //}

            //05
            //var employee = context.Employees
            //    .Where(e => e.Department.Name == "Research and Development")
            //    .OrderBy(e => e.Salary)
            //    .ThenByDescending(e => e.FirstName);

            //foreach (var e in employee)
            //{
            //    Console.WriteLine($"{e.FirstName} {e.LastName} from {e.Department.Name} - ${e.Salary:F2}");
            //}

            //06
            //var address = new Address()
            //{
            //    AddressText = "Vitoshka 15",
            //    TownID = 4
            //};

            //context.Addresses.Add(address);

            //Employee employee = context.Employees
            //    .FirstOrDefault(e => e.LastName == "Nakov");
            //employee.Address = address;

            //context.SaveChanges();

            //var employeeAddress = context.Employees
            //    .OrderByDescending(e => e.AddressID)
            //    .Take(10)
            //    .Select(e=>e.Address.AddressText);

            //foreach (var e in employeeAddress)
            //{
            //    Console.WriteLine(e);
            //}
            //07
            //var project = context.Projects.Find(2);
            //var employWithProject = project.Employees;
            //foreach (var employee in employWithProject)
            //{
            //    employee.Projects.Remove(project);
            //}

            //context.Projects.Remove(project);
            //context.SaveChanges();

            //var tenProject = context.Projects.Select(e => e.Name).Take(10);
            //foreach (var p in tenProject)
            //{
            //    Console.WriteLine(p);
            //}

            //08 TODO:
            //Find the first 30 employees who have projects started in the 
            //time period 2001 - 2003(inclusive).Print each employee's first name, last name 
            //and manager’s first name and each of their projects' name, start date, end date.
            //Here is the format:
            //“first Name lastName managerFirstName”
            //“—projectName projectStart projectEnd”

            //var employees = context.Employees
            //    .Where(e => e.Projects.Count(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003) > 0).Take(30);

            //foreach (var employee in employees)
            //{
            //    Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.Manager.FirstName}");
            //    foreach (var project in employee.Projects)
            //    {
            //        Console.WriteLine($"--{project.Name} {project.StartDate} {project.EndDate}");
            //    }
            //}

            //09
            //var addresses = context.Addresses
            //    .OrderByDescending(e => e.Employees.Count)
            //    .ThenBy(t => t.Town.Name)
            //    .Select(a => new
            //    {
            //        addressText = a.AddressText,
            //        townName = a.Town.Name,
            //        numberOfEmployyes = a.Employees.Count
            //    }).Take(10);

            //foreach (var a in addresses)
            //{
            //    Console.WriteLine($"{a.addressText}, {a.townName} - {a.numberOfEmployyes} employees");
            //}

            //10
            //var employee = context.Employees
            //    .Where(e => e.EmployeeID == 147)
            //    .Select(e => new
            //    {
            //        firstName = e.FirstName,
            //        lastName = e.LastName,
            //        jobTitle = e.JobTitle,
            //        projects = e.Projects
            //                    .Select(p => new
            //                    {
            //                        projectName = p.Name
            //                    }).OrderBy(pr => pr.projectName)
            //    });

            //foreach (var e in employee)
            //{
            //    Console.WriteLine($"{e.firstName} {e.lastName} {e.jobTitle}");
            //    foreach (var item in e.projects)
            //    {
            //        Console.WriteLine(string.Join(", ", item.projectName));
            //    }
            //}

            //11 
            //IEnumerable<Department> departmets = context.Departments
            //    .Where(d => d.Employees.Count > 5)
            //    .OrderBy(d => d.Employees.Count);

            //foreach (Department department in departmets)
            //{
            //    Console.WriteLine($"{department.Name} {department.Employee.FirstName}");
            //    foreach (Employee employee in department.Employees)
            //    {
            //        Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.JobTitle}");
            //    }
            //}

            //12
            //var timer = new Stopwatch();
            //timer.Start();
            //PrintNamesWithNativeQuery(context);
            //timer.Stop();
            //Console.WriteLine($"Native: {timer.Elapsed}");

            //timer.Restart();
            //PrimtNamesWithLinq(context);
            //timer.Stop();
            //Console.WriteLine($"LINQ: {timer.Elapsed}");


            //15
            //var projects = context.Projects.OrderByDescending(p => p.StartDate)
            //    .Take(10)
            //    .OrderBy(p => p.Name);

            //foreach (var project in projects)
            //{
            //    Console.WriteLine($"{project.Name} {project.Description} {project.StartDate} {project.EndDate}");
            //}

            //16
            //var employees = context.Employees
            //    .Where(e => e.Department.Name == "Engineering"
            //                || e.Department.Name == "Tool Design"
            //                || e.Department.Name == "Marketing"
            //                || e.Department.Name == "Information Services");

            //foreach (var employee in employees)
            //{
            //    employee.Salary *= 1.12m;
            //    Console.WriteLine($"{employee.FirstName} {employee.LastName} (${employee.Salary})");
            //}
            //context.SaveChanges();

            //17
            //string townForDelete = Console.ReadLine();
            //var wantedTown = context.Towns.FirstOrDefault(t => t.Name == townForDelete);
            //var townAddresses = wantedTown.Addresses.ToArray();
            //foreach (Address townAddress in townAddresses)
            //{
            //    var emploees = townAddress.Employees.ToArray();
            //    foreach (var employee in emploees)
            //    {
            //        employee.AddressID = null;
            //    }
            //}
            //context.Addresses.RemoveRange(townAddresses);
            //context.Towns.Remove(wantedTown);
            //context.SaveChanges();
            //Console.WriteLine($"{townAddresses.Length} address in {townForDelete} was deleted");

            //18
            //var employees = context.Employees
            //    .Where(e => e.FirstName.Substring(0, 2) == "SA")
            //    .Select(e => new
            //    {
            //        firstname = e.FirstName,
            //        lastname = e.LastName,
            //        jobTitle = e.JobTitle,
            //        salary = e.Salary
            //    });

            //foreach (var e in employees)
            //{
            //    Console.WriteLine($"{e.firstname} {e.lastname} – {e.jobTitle} - (${e.salary})");
            //}

            //19
            //var wizzards = grContext.WizzardDeposits
                
            //    .Where(w => w.DepositGroup == "Troll Chest")
            //    .Select(w => w.FirstName.Substring(0, 1))
            //    .Distinct()
            //    .OrderBy(w=>w);

            //foreach (var wizzard in wizzards)
            //{
            //    Console.WriteLine(wizzard);
            //}
        }

        private static void PrimtNamesWithLinq(SoftuniContext context)
        {
            var employees = context.Employees
                 .Where(e => e.Projects.Count(p => p.StartDate.Year == 2012) != 0);//.GroupBy(s=>s);
            foreach (var employee in employees)
            {
                //Console.WriteLine(employee.FirstName);
            }
        }

        private static void PrintNamesWithNativeQuery(SoftuniContext context)
        {
            string query = "SELECT  DISTINCT e.FirstName" +
                           "FROM [dbo].[EmployeesProjects] AS ep" +
                           "INNER JOIN [dbo].[Projects] AS p" +
                           "ON p.ProjectID = ep.ProjectID" +
                           "INNER JOIN[dbo].[Employees] AS e" +
                           "ON e.EmployeeID = ep.EmployeeID" +
                           "WHERE YEAR(p.StartDate) = 2002";

            var a = context.Database.SqlQuery<SoftuniContext>(query);
            a.ToListAsync();
        }
    }
}
