USE CarRental
GO

CREATE TABLE Categories
(
Id INT PRIMARY KEY IDENTITY,
Category VARCHAR(50),
DailyRate FLOAT,
WeeklyRate FLOAT,
MonthlyRate FLOAT,
WeekendRate FLOAT
)

CREATE TABLE Cars
(
Id INT PRIMARY KEY IDENTITY,
PlateNumber VARCHAR(8),
Make VARCHAR(50),
Model VARCHAR(50),
CarYear DATE,
CategoryId INT NOT NULL,
Doors INT,
Picture BINARY,
Condition VARCHAR(50)
)

CREATE TABLE Employees
(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(50),
LastName VARCHAR(50),
Title VARCHAR(50),
Notes VARCHAR(60)
)

CREATE TABLE Customers 
(
Id INT PRIMARY KEY IDENTITY,
DriverLicenceNumber VARCHAR(50),
FullName VARCHAR(50),
Address VARCHAR(50),
City VARCHAR(50),
ZipCode INT,
Notes VARCHAR(50)
)

CREATE TABLE RentalOrders
(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT,
CustomerId INT,
CarId INT,
CarCondition VARCHAR(10), 
TankLevel INT, 
KilometrageStart INT, 
KilometrageEnd INT, 
TotalKilometrage INT, 
StartDate DATE, 
EndDate DATE, 
TotalDays INT, 
RateApplied FLOAT, 
TaxRate FLOAT, 
OrderStatus VARCHAR(50)
)

ALTER TABLE Cars
ADD Available BIT
CONSTRAINT FK_Cars_CategoryId FOREIGN KEY (CategoryId) REFERENCES [dbo].[Categories](Id)

ALTER TABLE RentalOrders
ADD Notes VARCHAR(50)
CONSTRAINT FK_RentalOrders_EmployeeId FOREIGN KEY (EmployeeId) REFERENCES [dbo].[Employees](Id),
CONSTRAINT FK_RentalOrders_CustomerId FOREIGN KEY (CustomerId) REFERENCES [dbo].[Customers](Id),
CONSTRAINT FK_RentalOrders_CarId FOREIGN KEY (CarId) REFERENCES [dbo].[Cars](Id)

INSERT INTO Categories(Category, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES('hjKJNFDS', 3.5, 5.7, 78.9, 79.0),
('SWKIHKJND', 2.6, 7.8, 8.9, 7.0),
('hjKJNFDSSUDJCK', 5.5, 8.7, 8.9, 9.0)


INSERT INTO Cars(PlateNumber, Make, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
VALUES('CA6578NT', 'HJHDKJ', 'XSARA', '2018-11-22', 1, 4, NULL, 'OLD', 'true'),
('CA9090XP', 'DFHJHDKJ', 'ASTRA', '2016-11-22', 2, 2, NULL, 'OLD', 'true'),
('CA6578NT', 'HJHDKJ', 'XSARA', '2018-11-22', 3, 4, NULL, 'NEW', 'false')

INSERT INTO Employees(FirstName, LastName, Title, Notes)
VALUES('Ivan', 'Ivanov', 'Boss', null),
('Asen', 'Petrov', 'Team leader', 'kjdsjdkicnmdkjfd'),
('George', 'Geshov', 'Opersator', null)

INSERT INTO Customers(DriverLicenceNumber, FullName, Address, City, ZipCode, Notes)
VALUES('12234BVN56', 'Peter Petrov', 'Bulgaria bul. 15', 'Sofia', 1220, null),
('877647dnhd', 'Asen Petrov', 'Bulgaria bul. 15', 'Plovdiv', 1450, 'dsfrifdmc'),
('idsmjfc88783', 'PeSashoter Petrov', 'Bulgaria bul. 15', 'Varna', 1220, null)

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, CarCondition, TankLevel, KilometrageStart, 
KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
VALUES
(1, 3, 2, 'OLD', 100, 200, 12345, 43211, NULL, NULL, 365, 4.6, 5.6, 'DSDSGS', 'DFFF'),
(2, 2, 3, 'OLD', 100, 200, 12345, 43211, '2016-11-22', '2016-12-23', 365, 4.6, 5.6, 'DSDSGS', NULL),
(3, 1, 1, 'OLD', 100, 200, 12345, 43211, NULL, NULL, 365, 4.6, 5.6, 'DSDSGS', 'dffkjf')