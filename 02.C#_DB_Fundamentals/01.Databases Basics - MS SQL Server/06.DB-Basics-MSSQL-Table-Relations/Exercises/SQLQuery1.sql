--Problem 1.	One-To-One Relationship

CREATE TABLE Passports(
PassportID INT PRIMARY KEY,
PassportNumber VARCHAR(30) UNIQUE
)

CREATE TABLE Persons(
PersonID INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(50),
Salary FLOAT,
PassportID INT,
CONSTRAINT FK_Persons_Passports FOREIGN KEY(PassportID) 
REFERENCES Passports(PassportID)
)

INSERT INTO [dbo].[Passports](PassportID, PassportNumber)
VALUES(101, 'N34FG21B'), (102, 'K65LO4R7'), (103, 'ZE657QP2')

INSERT INTO [dbo].[Persons](FirstName, Salary, PassportID)
VALUES('Roberto', 43300.00, 102),
('Tom',	56100.00, 103),
('Yana', 60200.00, 101)

--Problem 2.	One-To-Many Relationship

CREATE TABLE Manufacturers(
ManufacturerID INT PRIMARY KEY,
Name VARCHAR(50),
EstablishedOn DATE
)

CREATE TABLE Models(
ModelID INT PRIMARY KEY,
Name VARCHAR(50),
ManufacturerID INT,
CONSTRAINT FK_Models_Manufacturers FOREIGN KEY(ManufacturerID)
REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers(ManufacturerID, Name, EstablishedOn)
VALUES(1, 'BMW', '07/03/1916'),
(2, 'Tesla', '01/01/2003'),
(3, 'Lada', '01/05/1966')

INSERT INTO Models(ModelID, Name, ManufacturerID)
VALUES(101, 'X1', 1),
(102, 'i6', 1),
(103, 'Model S', 2),
(104, 'Model X', 2),
(105, 'Model 3', 2),
(106, 'Nova', 3)

--Problem 3.	Many-To-Many Relationship

CREATE TABLE Students(
StudentID INT PRIMARY KEY,
Name VARCHAR(30)
)

CREATE TABLE Exams(
ExamID INT PRIMARY KEY,
Name VARCHAR(30)
)

CREATE TABLE StudentsExams(
StudentID INT,
ExamID INT,
CONSTRAINT PK_StudentsExams PRIMARY KEY(StudentID, ExamID),
CONSTRAINT FK_StudentsExams_Students FOREIGN KEY(StudentID) REFERENCES Students(StudentID),
CONSTRAINT FK_StudentsExams_Exams FOREIGN KEY(ExamID) REFERENCES Exams(ExamID)
)

INSERT INTO Students(StudentID, Name)
VALUES(1,'Mila'),
(2, 'Toni'),
(3, 'Ron')

INSERT INTO Exams(ExamID, Name)
VALUES(101, 'Spring MVC'),
(102, 'Neo4j'),
(103, 'Oracle 11g')

INSERT INTO StudentsExams(StudentID, ExamID)
VALUES(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)

--Problem 4.	Self-Referencing 
CREATE TABLE Teachers(
TeacherID INT PRIMARY KEY IDENTITY(101, 1),
Name VARCHAR(30),
ManagerID INT CONSTRAINT FK_Teachers_ManagerID_TeacherID 
FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers(Name, ManagerID)
VALUES('John', NULL),	
('Maya', 106),
('Silvia', 106),
('Ted', 105),
('Mark', 101),
('Greta', 101)

--Problem 5.	Online Store Database
CREATE TABLE Cities(
CityID INT PRIMARY KEY,
Name VARCHAR(50)
)

CREATE TABLE Customers(
CustomerID INT PRIMARY KEY,
Name VARCHAR(50),
Birthday DATE,
CityID INT,
CONSTRAINT FK_Customers_Cities FOREIGN KEY(CityID) REFERENCES Cities(CityID)
)

CREATE TABLE Orders(
OrderID INT PRIMARY KEY,
CustomerID INT,
CONSTRAINT FK_Orders_Customers FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID)
)

CREATE TABLE ItemTypes(
ItemTypeID INT PRIMARY KEY,
Name VARCHAR(50)
)

CREATE TABLE Items(
ItemID INT PRIMARY KEY,
Name VARCHAR(50),
ItemTypeID INT,
CONSTRAINT FK_Items_ItemTypes FOREIGN KEY(ItemTypeID) REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE OrderItems(
OrderID INT,
ItemID INT,
CONSTRAINT PK_OrderItems PRIMARY KEY(OrderID, ItemID),
CONSTRAINT FK_OrderItems_Items FOREIGN KEY(ItemID) REFERENCES Items(ItemID),
CONSTRAINT FK_OrderItems_Orders FOREIGN KEY(OrderID) REFERENCES Orders(OrderID)
)

--Problem 6.	University Database
CREATE TABLE Majors(
MajorID INT PRIMARY KEY,
Name VARCHAR(50)
)

CREATE TABLE Students(
StudentID INT PRIMARY KEY,
StudentNumber VARCHAR(30),
StudentName VARCHAR(50),
MajorID INT,
CONSTRAINT FK_Students_Majors FOREIGN KEY(MajorID) REFERENCES Majors(MajorID)
)
 
CREATE TABLE Payments(
PaymentID INT PRIMARY KEY,
PaymentDate DATE,
PaymentAmount FLOAT,
StudentID INT,
CONSTRAINT FK_Payments_Students FOREIGN KEY(StudentID) REFERENCES Students(StudentID)
)

CREATE TABLE Subjects(
SubjectID INT PRIMARY KEY,
SubjectName VARCHAR(50)
)

CREATE TABLE Agenda(
StudentID INT,
SubjectID INT,
CONSTRAINT PK_Agenda PRIMARY KEY(StudentID, SubjectID),
CONSTRAINT FK_Agenda_Students FOREIGN KEY(StudentID) REFERENCES Students(StudentID),
CONSTRAINT FK_Agenda_Subjects FOREIGN KEY(SubjectID) REFERENCES Subjects(SubjectID)
)

--Problem 9.	Employee Address
SELECT TOP 5 e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText 
  FROM [dbo].[Employees] AS e
 INNER JOIN [dbo].[Addresses] AS a
    ON e.AddressID = a.AddressID
 ORDER BY e.AddressID

--Problem 10.	Employee Departments
SELECT TOP 5 e.EmployeeID, e.FirstName, e.Salary, d.Name
  FROM [dbo].[Employees] AS e
 INNER JOIN [dbo].[Departments] AS d
    ON e.DepartmentID = d.DepartmentID
 WHERE e.Salary > 15000
 ORDER BY e.DepartmentID ASC

 --Problem 11.	Employees Without Project
 SELECT TOP 3 e.EmployeeID, e.FirstName 
   FROM [dbo].[Employees] AS e
   LEFT JOIN [dbo].[EmployeesProjects] AS ep
     ON e.EmployeeID = ep.EmployeeID
  WHERE ep.ProjectID IS NULL
  ORDER BY e.EmployeeID ASC

  --Problem 12.	Employees with Project
SELECT  TOP 5 e.EmployeeID, e.FirstName, p.Name AS ProjectName
  FROM [dbo].[Employees] AS e
 RIGHT JOIN [dbo].[EmployeesProjects] AS ep
    ON e.EmployeeID = ep.EmployeeID
 INNER JOIN [dbo].[Projects] AS p
    ON p.ProjectID = ep.ProjectID
 WHERE p.StartDate > '2002-08-13'
   AND p.EndDate IS NULL
 ORDER BY ep.EmployeeID ASC 

 --Problem 13.	Employee 24
 SELECT e.EmployeeID, e.FirstName, p.Name AS ProjectName  
   FROM [dbo].[Employees] AS e
  INNER JOIN [dbo].[EmployeesProjects] ep
     ON e.EmployeeID = ep.EmployeeID
   LEFT JOIN [dbo].[Projects] AS p
     ON p.ProjectID = ep.ProjectID
	AND p.StartDate < '2005-01-01'
  WHERE e.EmployeeID = 24

  --Problem 14.	Employee Manager
SELECT e.EmployeeID, e.FirstName, e.ManagerID, m.FirstName AS K
  FROM [dbo].[Employees] AS e
  LEFT JOIN [dbo].[Employees] AS m
    ON e.ManagerID = m.EmployeeID 
 WHERE e.ManagerID IN (3,7)
 ORDER BY e.EmployeeID ASC

 --Problem 15.	Highest peak in Bulgaria
SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation
  FROM [dbo].[MountainsCountries] AS mc
  LEFT JOIN [dbo].[Mountains] AS m
    ON m.Id = mc.MountainId
  LEFT JOIN [dbo].[Peaks] AS p
    ON p.MountainId = m.Id
 WHERE mc.CountryCode ='BG'
   AND p.Elevation > 2835
 ORDER BY p.Elevation DESC

 --Problem 16.	Count Mountain Ranges
 SELECT mc.CountryCode, COUNT(m.MountainRange) AS MountainRange
   FROM [dbo].[MountainsCountries] AS mc
   LEFT JOIN [dbo].[Mountains] AS m
     ON m.Id = mc.MountainId
  WHERE mc.CountryCode IN ('BG','US','RU')
  GROUP BY mc.CountryCode

  --Problem 17.	Countries with rivers
 SELECT TOP 5 c.CountryName, r.RiverName
   FROM [dbo].[Continents] AS co
   LEFT JOIN [dbo].[Countries] AS c
     ON c.ContinentCode = co.ContinentCode
   LEFT JOIN [dbo].[CountriesRivers] AS vr
    ON c.CountryCode = vr.CountryCode
  LEFT JOIN  [dbo].[Rivers] AS r
    ON r.Id = vr.RiverId
 WHERE co.ContinentCode = 'AF'
 ORDER BY c.CountryName ASC

 --Problem 18.   *Continents and Currencies
 SELECT
  sel.ContinentCode,
  sel.CurrencyCode AS CurrencyCode,
  sel.CurrencyUs AS CurrencyUsage
     FROM (SELECT c.ContinentCode,
                  cr.CurrencyCode,
                  COUNT(cr.Description) AS CurrencyUs,
                  DENSE_RANK() over (partition by c.ContinentCode order by COUNT(cr.CurrencyCode) desc) as rankk
             FROM  Currencies cr
             JOIN Countries c ON cr.CurrencyCode = c.CurrencyCode
             GROUP BY c.ContinentCode, cr.CurrencyCode
             HAVING  COUNT(cr.Description) > 1) as sel
where sel.rankk = 1 
ORDER BY ContinentCode

 --Problem 19.	Countries Without any Mountains
SELECT COUNT(cn.Initial) AS CountryCode FROM 
(SELECT c.CountryCode, COUNT(mc.MountainId) AS Initial
  FROM [dbo].[Countries] AS c
  LEFT JOIN [dbo].[MountainsCountries] AS mc
    ON c.CountryCode = mc.CountryCode
  GROUP BY c.CountryCode
  HAVING COUNT(mc.MountainId) = 0) AS cn

   --Problem 20.	Highest Peak and Longest River by Country
   SELECT TOP 5 c.CountryName, 
   MAX(p.Elevation) AS HighestPeakElevation, 
   MAX(r.Length) AS LongestRiverLength
     FROM [dbo].[Countries] AS c
	 LEFT JOIN [dbo].[MountainsCountries] AS mc
	   ON mc.CountryCode = c.CountryCode
	 LEFT JOIN [dbo].[Peaks] AS p
	   ON p.MountainId = mc.MountainId
	 LEFT JOIN [dbo].[CountriesRivers] AS cr
	   ON cr.CountryCode = c.CountryCode
	 LEFT JOIN [dbo].[Rivers] AS r
	   ON r.Id = cr.RiverId
	 GROUP BY c.CountryName
	 ORDER BY MAX(p.Elevation) DESC

	 --Problem 21.	**Highest Peak Name and Elevation by Country
	 SELECT   s.CountryName,
CASE 
   WHEN S.HighestPeakElevation IS  NULL THEN '(no highest peak)'
   ELSE p.PeakName
 END AS HighestPeakName, 
CASE 
   WHEN S.HighestPeakElevation IS  NULL THEN 0
   ELSE S.HighestPeakElevation
 END AS HighestPeakElevation,  
   CASE 
		WHEN m.MountainRange IS NULL THEN '(no mountain)'
	    ELSE m.MountainRange
		END AS MountainRange
    FROM
(SELECT  fin.CountryName, MAX(fin.Elevation) AS HighestPeakElevation  FROM 
   (SELECT  c.CountryName, p.Elevation  FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc
		   ON c.CountryCode=mc.CountryCode
	LEFT JOIN Peaks AS p
		   ON mc.MountainId=p.MountainId
	LEFT JOIN Mountains AS m
	       ON p.MountainId=m.Id 
	) AS fin
	GROUP BY fin.CountryName
	)AS S
  INNER JOIN Countries AS c
         ON s.CountryName=c.CountryName
  LEFT JOIN MountainsCountries AS mc
         ON c.CountryCode=mc.CountryCode
  LEFT JOIN Mountains AS m
		 ON mc.MountainId=m.Id
  LEFT JOIN Peaks AS p
         ON mc.MountainId=p.MountainId
ORDER BY c.CountryName, p.PeakName