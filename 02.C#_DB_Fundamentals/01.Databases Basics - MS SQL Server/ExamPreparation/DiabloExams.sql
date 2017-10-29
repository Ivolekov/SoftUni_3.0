CREATE TABLE DepositTypes(
DepositTypeID INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(20)
)

CREATE TABLE Deposits(
DepositID INT PRIMARY KEY IDENTITY,
Amount DECIMAL(10,2),
StartDate DATE,
EndDate DATE,
DepositTypeID INT,
CustomerID INT,
CONSTRAINT FK_Deposits_DepositTypes FOREIGN KEY(DepositTypeID)
REFERENCES DepositTypes(DepositTypeID),
CONSTRAINT FK_Deposits_Customers FOREIGN KEY (CustomerID)
REFERENCES Customers(CustomerID)
)

CREATE TABLE EmployeesDeposits(
EmployeeID INT,
DepositID INT,
CONSTRAINT PK_EmployeesDeposits PRIMARY KEY (EmployeeID, DepositID),
CONSTRAINT FK_EmployeesDeposits_Employees FOREIGN KEY(EmployeeID)
REFERENCES Employees(EmployeeID),
CONSTRAINT FK_EmployeesDeposits_Deposits FOREIGN KEY(DepositID)
REFERENCES Deposits(DepositID)
)

CREATE TABLE CreditHistory(
CreditHistoryID INT PRIMARY KEY IDENTITY,
Mark CHAR(1),
StartDate DATE,
EndDate DATE,
CustomerID INT,
CONSTRAINT FK_CreditHistory_Customers FOREIGN KEY (CustomerID)
REFERENCES Customers(CustomerID)
)

CREATE TABLE Payments(
PayementID INT PRIMARY KEY IDENTITY,
[Date] DATE,
Amount DECIMAL(10,2),
LoanID INT,
CONSTRAINT FK_Payments_Loans FOREIGN KEY (LoanID)
REFERENCES Loans(LoanID)
)

CREATE TABLE Users(
UserID INT PRIMARY KEY IDENTITY,
UserName VARCHAR(20),
[Password] VARCHAR(20),
CustomerID INT UNIQUE,
CONSTRAINT FK_Users_Customers FOREIGN KEY(CustomerID)
REFERENCES Customers(CustomerID)
)

ALTER TABLE Employees
ADD ManagerID INT,
CONSTRAINT FK_Employees_Employees FOREIGN KEY (ManagerID)
REFERENCES Employees(EmployeeID)


--2

INSERT INTO DepositTypes(DepositTypeID, [Name])
VALUES
(1, 'Time Deposit'),
(2, 'Call Deposit'),
(3, 'Free Deposit')

INSERT INTO Deposits(Amount, StartDate, EndDate, DepositTypeID, CustomerID)
SELECT CASE
			WHEN c.DateOfBirth > '1980-01-01' THEN 1000
			ELSE 1500
		END
		+
		CASE	
			WHEN c.Gender = 'm' THEN 100
			ELSE 200
		END AS Amount,
		GETDATE(),
		NULL,
		CASE	
			WHEN c.CustomerID > 15 THEN 3
			WHEN c.CustomerID % 2 = 0 THEN 2
			WHEN c.CustomerID % 2 = 1 THEN 1
		END,
		c.CustomerID
  FROM [dbo].[Customers] AS c
 WHERE c.CustomerID < 20

INSERT INTO EmployeesDeposits(EmployeeID, DepositID)
VALUES
(15, 4),
(20, 15),
(8, 7),
(4, 8),
(3, 13),
(3, 8),
(4, 10),
(10, 1),
(13, 4),
(14, 9)
--3
UPDATE [dbo].[Employees]
   SET ManagerID = CASE
					WHEN EmployeeID BETWEEN 2 AND 10 THEN 1
					WHEN EmployeeID BETWEEN 12 AND 20 THEN 11
					WHEN EmployeeID BETWEEN 22 AND 30 THEN 21
					WHEN EmployeeID IN (11,21) THEN 1
				   END
--4
DELETE [dbo].[EmployeesDeposits]
WHERE DepositID = 9
   OR EmployeeID = 3

--
 SELECT	 e.[EmployeeID], e.[HireDate], e.[Salary], e.[BranchID]
   FROM [dbo].[Employees] AS e
  WHERE e.Salary > 2000
    AND e.HireDate > '2009-06-15'

--
  SELECT c.[FirstName],	c.[DateOfBirth],
		 DATEDIFF(YEAR, c.DateOfBirth, '2016-10-01') AS Age
    FROM [dbo].[Customers] AS c
   WHERE DATEDIFF(YEAR, c.DateOfBirth, '2016-10-01') BETWEEN 40 AND 50

   --
   SELECT c.[CustomerID], c.[FirstName], c.[LastName], c.[Gender], cn.[CityName] 
     FROM [dbo].[Customers] AS c
	INNER JOIN [dbo].[Cities] AS cn
	   ON cn.CityID = c.CityID
	WHERE (SUBSTRING(c.LastName, 1, 2) = 'Bu'
	   OR SUBSTRING(REVERSE(c.FirstName),1,1) = 'a')
	  AND LEN(cn.CityName) >= 8
	ORDER BY c.CustomerID ASC

	--
	SELECT TOP 5 e.[EmployeeID], e.[FirstName], a.[AccountNumber]
      FROM [dbo].[Employees] AS e
	 INNER JOIN [dbo].[EmployeesAccounts] AS ea
	    ON ea.EmployeeID = e.EmployeeID
	 INNER JOIN [dbo].[Accounts] AS a
	    ON a.AccountID = ea.AccountID
	 WHERE YEAR(a.StartDate) >  '2012'
	 ORDER BY e.FirstName DESC

	 --
	 SELECT c.[CityName], b.[Name], COUNT(*) AS EmployeesCount
	   FROM [dbo].[Employees] AS e
      INNER JOIN [dbo].[Branches] AS b
	     ON b.BranchID = e.BranchID
	  INNER JOIN [dbo].[Cities] AS c
	     ON c.CityID = b.CityID
	  WHERE c.CityID NOT IN (4,5)
	  GROUP BY c.[CityName], b.[Name]
	 HAVING COUNT(*) >= 3

	 --
	 SELECT SUM(l.Amount) AS TotalLoanAmount,
	        MAX(l.Interest) AS MaxInterest,
			MIN(e.Salary) AS MinEmployeeSalary
	   FROM [dbo].[Employees] AS e
	  INNER JOIN [dbo].[EmployeesLoans] el
	     ON el.EmployeeID = e.EmployeeID
	  INNER JOIN  [dbo].[Loans] AS l
	     ON l.LoanID = el.LoanID

	--
	SELECT TOP 3 e.FirstName, c.CityName
	  FROM [dbo].[Employees] AS e
	 INNER JOIN [dbo].[Branches] AS b
	    ON b.BranchID = e.BranchID
	 INNER JOIN [dbo].[Cities] AS c
	    ON c.CityID = b.CityID
		UNION ALL
	SELECT TOP 3 c.FirstName, ci.CityName
	 FROM [dbo].[Customers] AS c
	INNER JOIN [dbo].[Cities] AS ci
	   ON ci.CityID = c.CityID

	 --
	 SELECT c.CustomerID, c.Height
	   FROM [dbo].[Accounts] AS a
	   RIGHT JOIN [dbo].[Customers] AS c
	     ON c.CustomerID = a.CustomerID
	  WHERE c.Height BETWEEN 1.74 AND 2.04
	    AND a.AccountNumber IS NULL
	
	--
	 SELECT TOP 5 c.CustomerID, l.Amount 
	   FROM [dbo].[Customers] AS c
	  INNER JOIN [dbo].[Loans] AS l
	     ON l.CustomerID = c.CustomerID
	  WHERE l.Amount > 
	  (SELECT AVG(l.Amount) AS Average
	    FROM [dbo].[Customers] AS c
	   INNER JOIN  [dbo].[Loans] AS l
	      ON l.CustomerID = c.CustomerID
	   WHERE c.Gender = 'm') 
	   ORDER BY c.LastName ASC

	   --
	   SELECT c.CustomerID, c.FirstName, a.StartDate
	     FROM [dbo].[Customers] AS c
		INNER JOIN [dbo].[Accounts] AS a
		   ON a.CustomerID = c.CustomerID
		WHERE a.StartDate IN (SELECT MIN(a.StartDate) FROM [dbo].[Accounts] AS a)

		--
		CREATE FUNCTION udf_ConcatString (@first VARCHAR(MAX), @second VARCHAR(MAX))
		RETURNS VARCHAR(MAX)
		BEGIN
			RETURN CONCAT(REVERSE(@first), REVERSE(@second))
		END

		SELECT [dbo].[udf_ConcatString]('Soft', 'Uni')

		--
	CREATE PROCEDURE usp_CustomersWithUnexpiredLoans(@CustomerID INT)
	AS
	BEGIN
			SELECT c.CustomerID, c.FirstName, l.LoanID
			 FROM [dbo].[Customers] AS c
			 LEFT JOIN [dbo].[Loans] AS l
			   ON l.CustomerID = c.CustomerID
			WHERE c.CustomerID = @CustomerID
			  AND l.ExpirationDate IS NULL
	END

	EXEC usp_CustomersWithUnexpiredLoans @CustomerID = 9