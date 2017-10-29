--Problem 1.	Employees with Salary Above 35000
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT e.FirstName, E.LastName FROM [dbo].[Employees] AS e
	WHERE e.Salary > 35000
END
EXEC usp_GetEmployeesSalaryAbove35000

--Problem 2.	Employees with Salary Above Number
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber (@Salary MONEY)
AS
BEGIN
	DECLARE @num AS MONEY
	SET @num = @Salary
	SELECT e.FirstName, E.LastName FROM [dbo].[Employees] AS e
	WHERE e.Salary >= @num
END
EXEC usp_GetEmployeesSalaryAboveNumber 48100

--Problem 3.	Town Names Starting With
CREATE PROCEDURE usp_GetTownsStartingWith (@Name VARCHAR(40))
AS
BEGIN
	DECLARE @input VARCHAR(40)
	SET @input = @Name
	SELECT t.Name FROM [dbo].[Towns] AS t
	WHERE LOWER(LEFT(t.Name, LEN(@input))) = LOWER(@input)
END
EXEC usp_GetTownsStartingWith 'b'

--Problem 4.	Employees from Town
CREATE PROCEDURE usp_GetEmployeesFromTown (@townName VARCHAR(30))
AS
BEGIN
	DECLARE @town VARCHAR(30)
	SET @town = @townName
	SELECT e.FirstName, e.LastName
	  FROM [dbo].[Employees] AS e
	INNER JOIN [dbo].[Addresses] AS a
	   ON a.AddressID = e.AddressID
	INNER JOIN [dbo].[Towns] AS t
	   ON t.TownID = a.TownID
	WHERE t.Name = @town
END
EXEC usp_GetEmployeesFromTown 'Sofia'


--Problem 5.	Salary Level Function
CREATE FUNCTION ufn_GetSalaryLevel(@salary MONEY)
RETURNS VARCHAR(30)
AS
BEGIN
	DECLARE @employeeSalary AS MONEY
	SET @employeeSalary = @salary
	DECLARE @salaryLevel VARCHAR(30)

	IF (@salary < 30000)
	BEGIN
		SET @salaryLevel = 'Low'
	END

	IF (@salary BETWEEN 30000 AND 50000)
	BEGIN
		SET @salaryLevel = 'Average'
	END

	IF (@salary > 50000)
	BEGIN
		SET @salaryLevel = 'High'
	END
RETURN @salaryLevel
END
 
SELECT e.Salary, dbo.udf_GetSalaryLevel(e.Salary) AS "Salary Level"
  FROM [dbo].[Employees] AS e

  --Problem 6.	Employees by Salary Level
  CREATE PROCEDURE usp_EmployeesBySalaryLevel(@salaryLevel VARCHAR(20))
  AS
  BEGIN
	DECLARE @salaryFilter AS VARCHAR(20)
	SET @salaryFilter = @salaryLevel
	SELECT e.FirstName, e.LastName
	  FROM [dbo].[Employees] AS e
	 WHERE [dbo].[udf_GetSalaryLevel](e.Salary) = @salaryFilter
  END

  EXEC usp_EmployeesBySalaryLevel 'High'

  --Problem 7.	Define Function

  --Problem 9.	Find Full Name
  CREATE PROCEDURE usp_GetHoldersFullName AS
BEGIN
	SELECT h.FirstName + ' ' + ah.LastName FROM dbo.AccountHolders AS ah
END

CREATE TABLE AccountHolders(
ID INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(30),
LastName VARCHAR(30),
SSN VARCHAR(30)
)

CREATE TABLE Accounts2(
ID INT PRIMARY KEY IDENTITY,
AccountHolderId INT, 
CONSTRAINT FK_Accounts_AccountHolders FOREIGN KEY (ID) REFERENCES AccountHolders(ID)
)

INSERT INTO AccountHolders (FirstName, LastName)
VALUES
('Petar', 'Dimitrov'),
('Nikolay', 'Petkov'),
('Lidinka', 'Plamenova'),
('Svetoslav', 'Dimitrov'),
('Alexander', 'Krustev')
--Problem 10.	People with Balance Higher Than
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan (@money MONEY)
AS
BEGIN
	DECLARE @num AS MONEY
	SET @num = @money
	SELECT ah.FirstName, ah.LastName
	  FROM [dbo].[AccountHolders] AS ah
     INNER JOIN [dbo].[Accounts2] AS a
	    ON a.AccountHolderId = ah.ID
	 GROUP BY ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @num
END

--Problem 11.	Future Value Function
CREATE FUNCTION ufn_CalculateFutureValue (@sum DECIMAL(19,8), @yearlyInterestRate DECIMAL(19,8), @years INT)
RETURNS DECIMAL(19,4)
AS
BEGIN
	DECLARE @result DECIMAL(19,4)
	SET @result = @sum * (POWER(1+@yearlyInterestRate, @years))
	RETURN @result
END

SELECT [dbo].[ufn_CalculateFutureValue](1000,0.1,5)

--Problem 12.	Calculating Interest