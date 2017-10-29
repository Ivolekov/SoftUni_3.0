USE SoftUni
GO

CREATE TABLE Towns (
Id INT PRIMARY KEY IDENTITY, 
Name VARCHAR(20))

CREATE TABLE Addresses (
Id INT PRIMARY KEY IDENTITY,
AddressText VARCHAR(50),
TownId INT NOT NULL,
FOREIGN KEY (TownId) REFERENCES [dbo].[Towns](Id))

CREATE TABLE Departments (
Id INT PRIMARY KEY IDENTITY,
Name VARCHAR(50))

CREATE TABLE Employees (
Id INT PRIMARY KEY IDENTITY, 
FirstName VARCHAR(20), 
MiddleName VARCHAR(20), 
LastName VARCHAR(20), 
JobTitle VARCHAR(50), 
DepartmentId INT NOT NULL,
HireDate DATE, 
Salary FLOAT, 
AddressId INT NOT NULL,
FOREIGN KEY (DepartmentId) REFERENCES [dbo].[Departments](Id),
FOREIGN KEY (AddressId) REFERENCES [dbo].[Addresses](Id))

INSERT INTO Towns(Name)
VALUES('Sofia'), ('Plovdiv'), ('Varna'), ('Burgas')

INSERT INTO Addresses(AddressText, TownId)
VALUES('Nedko Voivoda str.', 1),
('Bulgaria bul.', 2),
(NULL, 3),
(NULL, 4)

INSERT INTO Departments(Name)
VALUES('Software Development'),
('Engineering'),
('Quality Assurance'),
('Sales'),
('Marketing')

INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)
VALUES('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 1, '2013-02-01', 3500.00, 1),
('Peter', 'Petrov', 'Petrov', 'Senior Engineer', 2, '2004-03-02', 4000.00, 2),
('Maria', 'Petrova', 'Ivanova', 'Intern', 3, '2016-08-28', 525.25, 3),
('Georgi', 'Teziev ', 'Ivanov', 'CEO', 4, '2007-12-09', 3000.00, 4),
('Peter', 'Pan', 'Pan', 'Intern', 5, '2016-08-28', 3500.00, 1)

SELECT [Name] FROM Towns
ORDER BY [Name]
SELECT [Name] FROM Departments
ORDER BY [Name]
SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC

UPDATE Employees
SET Salary = (Salary*0.1) + Salary
SELECT Salary FROM Employees