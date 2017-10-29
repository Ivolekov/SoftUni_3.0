--Problem 1.	Find Names of All Employees by First Name
--SELECT e.FirstName, e.LastName
--  FROM [dbo].[Employees] AS e
-- WHERE LEFT(e.FirstName, 2)='SA'

--Find Names of All employees by Last Name 
--SELECT e.FirstName, e.LastName 
--  FROM [dbo].[Employees] AS e
-- WHERE CHARINDEX('EI', e.LastName, 1)>0

--Problem 3.	Find First Names of All Employees
--SELECT e.FirstName
--  FROM [dbo].[Employees] AS e
-- WHERE e.DepartmentID IN(3,10)
--   AND 
--	YEAR(e.HireDate) >= '1995' AND YEAR(e.HireDate) <= '2005'

--Problem 4.	Find All Employees Except Engineers
--SELECT e.FirstName, e.LastName
--  FROM [dbo].[Employees] AS e
-- WHERE CHARINDEX('engineer', e.JobTitle, 1) = 0

--Problem 5.	Find Towns with Name Length
--SELECT t.[Name]
--  FROM [dbo].[Towns] AS t
-- WHERE LEN(t.Name) = 6 OR LEN(t.Name) = 5
-- ORDER BY t.Name ASC

--Problem 6.	 Find Towns Starting With
--SELECT *
--  FROM [dbo].[Towns] AS t
-- WHERE LEFT(t.[Name], 1) = 'M'
--    OR SUBSTRING(t.[Name],1,1) = 'K'
--	OR SUBSTRING(t.[Name],1,1) = 'B'
--	OR SUBSTRING(t.[Name],1,1) = 'E'
-- ORDER BY t.[Name] ASC

--Problem 7.	 Find Towns Not Starting With
--SELECT *
--  FROM [dbo].[Towns] AS t
-- WHERE SUBSTRING(t.[Name],1,1) <> 'R'
--	AND SUBSTRING(t.[Name],1,1) <> 'B'
--	AND SUBSTRING(t.[Name],1,1) <> 'D'
-- ORDER BY t.[Name] ASC

--Problem 8.	Create View Employees Hired After 2000 Year
--CREATE VIEW V_EmployeesHiredAfter2000 AS
--SELECT e.FirstName, e.LastName
--  FROM [dbo].[Employees] AS e
-- WHERE YEAR(e.HireDate) > '2000'

--Problem 9.	Length of Last Name
--SELECT e.FirstName, e.LastName 
--  FROM [dbo].[Employees] AS e
-- WHERE LEN(e.LastName) = 5

--Part II – Queries for Geography Database 
--Problem 10.	Countries Holding ‘A’ 3 or More Times
--SELECT c.CountryName, c.IsoCode
--  FROM [dbo].[Countries] AS c
-- WHERE LEN(c.CountryName) >= LEN(REPLACE(c.CountryName, 'a', ''))+3
-- ORDER BY c.IsoCode

--Mix of Peak and River Names
--SELECT p.PeakName, r.RiverName,
--	LOWER(p.PeakName + SUBSTRING(r.RiverName, 2, LEN(r.RiverName)-1)) AS MIX
--  FROM [dbo].[Peaks] AS p, 
--	   [dbo].[Rivers] AS r
-- WHERE RIGHT(p.PeakName,1)=LEFT(r.RiverName,1)
-- ORDER BY MIX 

--Part III – Queries for Diablo Database
--Problem 12.	Games from 2011 and 2012 year
--SELECT TOP 50 g.[Name], CONVERT(CHAR(10), g.[Start],126) AS Start
--  FROM [dbo].[Games] AS g
-- WHERE YEAR(g.Start)='2011' OR YEAR(g.Start)='2012'
-- ORDER BY g.[Start], g.[Name]

-- Problem 13.  User Email Providers
--SELECT u.Username, SUBSTRING(u.Email, CHARINDEX('@', u.Email, 1)+1, LEN(u.Email)-CHARINDEX(u.Email,'@',1)) AS "Email Provider"
--  FROM [dbo].[Users] AS u
-- ORDER BY [Email Provider] ASC, u.Username ASC

--Problem 14.	 Get Users with IPAdress Like Pattern
 --SELECT u.Username, u.IpAddress
 --  FROM [dbo].[Users] AS u
 -- WHERE u.IpAddress LIKE '___.1%.%.___'
 -- ORDER BY u.Username

 --Show All Games with Duration and Part of the Day
