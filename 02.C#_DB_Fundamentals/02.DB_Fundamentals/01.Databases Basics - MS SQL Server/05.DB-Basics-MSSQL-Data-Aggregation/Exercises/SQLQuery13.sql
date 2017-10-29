--Problem 1.	Records’ Count
--SELECT COUNT(w.Id) AS [COUNT]
--  FROM [dbo].[WizzardDeposits] AS w

--Problem 2.	Longest Magic Wand
--SELECT w.MagicWandSize AS LongestMagicWand
--  FROM [dbo].[WizzardDeposits] AS w
-- GROUP BY w.MagicWandSize
--HAVING MAX(w.MagicWandSize) = 31

--Problem 3.	Longest Magic Wand per Deposit Groups
--SELECT w.DepositGroup, w.MagicWandSize
--  FROM [dbo].[WizzardDeposits] AS w
-- GROUP BY w.DepositGroup, w.MagicWandSize
-- order by w.MagicWandSize desc

--Problem 5.	Deposits Sum
--SELECT w.DepositGroup, SUM(w.DepositAmount) AS TotalSum
--  FROM [dbo].[WizzardDeposits] AS w
-- GROUP BY w.DepositGroup

--Problem 6.	Deposits Sum for Ollivander Family
--SELECT w.DepositGroup, SUM(w.DepositAmount) AS TotalSum
--  FROM [dbo].[WizzardDeposits] AS w
-- WHERE w.MagicWandCreator = 'Ollivander family'
-- GROUP BY w.DepositGroup

--Problem 7.	Deposits Filter
--SELECT w.DepositGroup, SUM(w.DepositAmount) AS TotalSum
--  FROM [dbo].[WizzardDeposits] AS w
-- WHERE w.MagicWandCreator = 'Ollivander family'
-- GROUP BY w.DepositGroup
--HAVING SUM(w.DepositAmount) < 150000
-- ORDER BY TotalSum DESC

--Problem 8.	 Deposit charge
--SELECT w.DepositGroup, w.MagicWandCreator, MIN(w.DepositCharge) AS MinDepositCharge
--  FROM [dbo].[WizzardDeposits] AS w
-- GROUP BY  w.DepositGroup, w.MagicWandCreator

--Problem 9.	Age Groups
--SELECT CASE
--			WHEN w.Age <= 10 THEN '[0-10]'
--			WHEN w.Age <= 20 THEN '[11-20]'
--			WHEN w.Age <= 30 THEN '[21-30]'
--			WHEN w.Age <= 40 THEN '[31-40]'
--			WHEN w.Age <= 50 THEN '[41-50]'
--			WHEN w.Age <= 60 THEN '[51-60]'
--			ELSE '[61+]'
--		END AS AgeGroup,
--		COUNT(*) AS WizardCount
-- FROM [dbo].[WizzardDeposits] AS w
--GROUP BY CASE
--			WHEN w.Age <= 10 THEN '[0-10]'
--			WHEN w.Age <= 20 THEN '[11-20]'
--			WHEN w.Age <= 30 THEN '[21-30]'
--			WHEN w.Age <= 40 THEN '[31-40]'
--			WHEN w.Age <= 50 THEN '[41-50]'
--			WHEN w.Age <= 60 THEN '[51-60]'
--			ELSE '[61+]'
--		END

--Problem 10.	First Letter
--SELECT SUBSTRING(w.FirstName,1,1) AS first_letter
--  FROM [dbo].[WizzardDeposits] AS w
-- WHERE w.DepositGroup = 'Troll Chest'
-- GROUP BY SUBSTRING(w.FirstName,1,1)

--Problem 11.	Average Interest 
--SELECT w.DepositGroup, w.IsDepositExpired, AVG(w.DepositInterest) AS AverageInterest
--  FROM [dbo].[WizzardDeposits] AS w
-- WHERE w.DepositStartDate > '1985-01-01'
-- GROUP BY  w.DepositGroup, w.IsDepositExpired
-- ORDER BY w.DepositGroup DESC, w.IsDepositExpired ASC

--Problem 13.	Employees Minimum Salaries
--USE SoftUni
--GO
--SELECT e.DepartmentID, MIN(e.Salary) AS MinimumSalary
--  FROM [dbo].[Employees] AS e
-- WHERE e.DepartmentID LIKE '[257]'
--	 AND e.HireDate > '2000-01-01'
-- GROUP BY e.DepartmentID

--Problem 14.	Employees Average Salaries
--SELECT * INTO NewTable
--  FROM [dbo].[Employees] AS e
-- WHERE e.Salary > 30000

--DELETE FROM NewTable
-- WHERE ManagerID = 42

--UPDATE NewTable
--   SET Salary += 5000
-- WHERE DepartmentID = 1

--SELECT n.DepartmentID, AVG(n.Salary) AS AverageSalary
--  FROM [dbo].[NewTable] AS n
-- GROUP BY n.DepartmentID

--Problem 15.	Employees Maximum Salaries
--SELECT e.DepartmentID, MAX(e.Salary) AS MaxSalary
--  FROM [dbo].[Employees] AS e
-- GROUP BY e.DepartmentID
--HAVING MAX(e.Salary) NOT BETWEEN 30000 AND 70000

--Problem 16.	Employees Count Salaries
--SELECT  COUNT(*) AS [Count]
--  FROM  [dbo].[Employees] AS e
-- WHERE e.ManagerID IS NULL
-- GROUP BY e.ManagerID