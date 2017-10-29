---Problem 6.	Find Email Address of Each Employee
--SELECT e.FirstName + '.' + e.LastName + '@softuni.bg' AS "Full Email Address"
--  FROM Employees AS e

  ---Problem 7.	Find All Different Employee’s Salaries
--SELECT DISTINCT Salary FROM Employees

---Problem 9.	Find Names of All Employees by Salary in Range
--SELECT e.FirstName, e.LastName, e.JobTitle
--  FROM Employees AS e
-- WHERE e.Salary BETWEEN 20000 AND 30000

---Problem 10.	 Find Names of All Employees
--SELECT e.FirstName + ' ' + e.MiddleName + ' ' + e.LastName AS "Full Name"
--  FROM Employees AS e
--WHERE e.Salary IN(25000, 14000, 12500, 23600)

---Find All Employees Without Manager
--SELECT e.FirstName, e.LastName
-- FROM Employees AS e
--WHERE e.ManagerID IS NULL

---Find All Employees with Salary More Than 50000
--SELECT e.FirstName, e.LastName, e.Salary
--  FROM Employees AS e
-- WHERE e.Salary>50000
-- ORDER BY e.Salary DESC

---Problem 13.	 Find 5 Best Paid Employees.
--SELECT TOP 5 e.FirstName, e.LastName
--  FROM Employees AS e
-- ORDER BY e.Salary DESC

---Problem 14.	Find All Employees Except Marketing
--SELECT e.FirstName, e.LastName
--  FROM Employees AS e
-- WHERE e.DepartmentId != 4

---Problem 15.	Sort Employees Table
--SELECT * 
-- FROM Employees AS e
--ORDER BY e.Salary DESC, e.FirstName ASC, e.LastName DESC, e.MiddleName ASC

--- Problem 16. Create View Employees with Salaries
--CREATE VIEW V_EmployeesSalaries AS
--SELECT e.FirstName, e.LastName, e.Salary
--  FROM [dbo].[Employees] AS e

---Problem 17.	Create View Employees with Job Titles
--CREATE VIEW V_EmployeeNameJobTitle AS
--SELECT CONCAT(e.FirstName, ' ', e.MiddleName , ' ', e.LastName) AS [Full Name], e.JobTitle
--  FROM [dbo].[Employees] AS e

---Problem 18.  Distinct Job Titles
--SELECT DISTINCT e.JobTitle 
--  FROM [dbo].[Employees] AS e

---Problem 19.	Find First 10 Started Projects
--SELECT TOP 10 *
--  FROM [dbo].[Projects] AS p
-- ORDER BY p.StartDate, p.Name

---Problem 20.	 Last 7 Hired Employees
--SELECT TOP 7 e.FirstName, e.LastName, e.HireDate
--  FROM [dbo].[Employees] AS e
-- ORDER BY e.HireDate DESC

---Problem 21.	Increase Salaries

--UPDATE [dbo].[Employees]
--   SET Salary *= 1.12
-- WHERE DepartmentId IN 
--    (SELECT DepartmentId 
--	   FROM [dbo].[Departments]
--	  WHERE [Name] IN ('Engineering', 'Tool Design', 'Marketing', 'Information Services'))

--SELECT e.Salary 
--  FROM [dbo].[Employees] AS e

----Part II – Queries for Geography Database
--Problem 22.	 All Mountain Peaks

--SELECT p.PeakName
--  FROM [dbo].[Peaks] AS p
-- ORDER BY p.PeakName

---Problem 23.	 Biggest Countries by Population
--SELECT  TOP 30 c.CountryName, c.Population
--  FROM [dbo].[Countries] AS c
-- WHERE c.ContinentCode='EU'
-- ORDER BY c.[Population] DESC, c.CountryName ASC

--Problem 24.	 Countries and Currency (Euro / Not Euro)
--SELECT c.CountryName, c.CountryCode,
--		CASE
--			WHEN c.CurrencyCode ='EUR' THEN 'Euro'
--			ELSE 'Not Euro'
--		END
--  FROM [dbo].[Countries] AS c
-- ORDER BY c.CountryName

--Part III – Queries for Diablo Database
--Problem 25.	 All Diablo Characters
--USE Diablo
--GO
--SELECT c.Name
--  FROM [dbo].[Characters] AS c
-- ORDER BY c.Name ASC 
