using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.CompanyRoster
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Emploee> emploees = new List<Emploee>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries);

                Emploee emploee = new Emploee(input[0], double.Parse(input[1]),
                    input[2], input[3]);

                if (input.Length > 5)
                {
                    emploee.age = int.Parse(input[5]);
                }
                if (input.Length > 4)
                {
                    if (input[4].Contains("@"))
                    {
                        emploee.email = input[4];
                    }
                    else
                    {
                        emploee.age = int.Parse(input[4]);
                    }
                }
                emploees.Add(emploee);
            }

            var groupByDepartment = emploees.GroupBy(e => e.department)
                .Select(e => new
                {
                    Department = e.Key,
                    AverageSalary = e.Average(emp => emp.salary),
                });
            var maxAvgDepartment = groupByDepartment
                .OrderByDescending(g => g.AverageSalary)
                .Select(g => g.Department)
                .First();

            var employeesToPrint = emploees
                            .Where(e => e.Department == maxAvgDepartment)
                            .OrderByDescending(e => e.Salary)
                            .ToList();
            Console.WriteLine($"Highest Average Salary: {maxAvgDepartment}");
            foreach (var item in employeesToPrint)
            {
                Console.WriteLine($"{item.name} {item.salary:F2} {item.email} {item.age}");
            }
        }
    }

    public class Emploee
    {
        public string name;
        public double salary;
        public string position;
        public string department;
        public string email;
        public int age;



        public Emploee(string name, double salary, string position,
            string department, string email, int age)
        {
            this.name = name;
            this.salary = salary;
            this.position = position;
            this.department = department;
            this.email = email;
            this.age = age;
        }



        public Emploee(string name, double salary, string position,
            string department) : this(name, salary, position, department, "n/a", -1)
        {
            this.name = name;
            this.salary = salary;
            this.position = position;
            this.department = department;
        }

        public string Name { get { return this.name; } }

        public double Salary { get { return this.salary; } }

        public string Position { get { return this.position; } }

        public string Department { get { return this.department; } }

        public string Email { get { return this.email; } }

        public int Age { get { return this.age; } }
    }
}
