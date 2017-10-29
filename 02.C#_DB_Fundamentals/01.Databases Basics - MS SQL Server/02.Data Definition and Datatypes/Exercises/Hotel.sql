--USE Hotel
--GO

--CREATE TABLE Employees(
--Id INT PRIMARY KEY IDENTITY,
--FirstName VARCHAR(20) NOT NULL, 
--LastName VARCHAR(20) NOT NULL, 
--Title VARCHAR(20), 
--Notes VARCHAR(30))

--CREATE TABLE Customers(
--Id INT PRIMARY KEY IDENTITY,
--AccountNumber VARCHAR(12) NOT NULL, 
--FirstName VARCHAR(20) NOT NULL, 
--LastName VARCHAR(20) NOT NULL, 
--PhoneNumber VARCHAR(10) NOT NULL, 
--EmergencyName VARCHAR(20) NOT NULL, 
--EmergencyNumber VARCHAR(10) NOT NULL, 
--Notes VARCHAR(30))

--CREATE TABLE RoomStatus(
--Id INT PRIMARY KEY IDENTITY, 
--RoomStatus VARCHAR(20) NOT NULL, 
--Notes VARCHAR(30))

--CREATE TABLE RoomTypes(
--Id INT PRIMARY KEY IDENTITY, 
--RoomType VARCHAR(20) NOT NULL, 
--Notes VARCHAR(30))

--CREATE TABLE BedTypes(
--Id INT PRIMARY KEY IDENTITY, 
--BedType VARCHAR(10) NOT NULL, 
--Notes VARCHAR(30))

--CREATE TABLE Rooms(
--Id INT PRIMARY KEY IDENTITY,
--RoomNumber INT NOT NULL, 
--RoomType INT NOT NULL, 
--BedType INT NOT NULL, 
--Rate FLOAT, 
--RoomStatus INT NOT NULL)

--CREATE TABLE Payments(
--Id INT PRIMARY KEY IDENTITY, 
--EmployeeId INT NOT NULL, 
--PaymentDate DATE, 
--AccountNumber VARCHAR(12), 
--FirstDateOccupied DATE, 
--LastDateOccupied DATE, 
--TotalDays INT, 
--AmountCharged VARCHAR(10), 
--TaxRate FLOAT, 
--TaxAmount FLOAT, 
--PaymentTotal FLOAT)

--CREATE TABLE Occupancies(
--Id INT PRIMARY KEY IDENTITY, 
--EmployeeId INT NOT NULL, 
--DateOccupied DATE, 
--AccountNumber VARCHAR(12), 
--RoomNumber INT, 
--RateApplied FLOAT, 
--PhoneCharge FLOAT) 

--ALTER TABLE Rooms
--ADD Notes VARCHAR(30),
--CONSTRAINT FK_Rooms_RoomType FOREIGN KEY (RoomType) REFERENCES [dbo].[RoomTypes](Id),
--CONSTRAINT FK_Rooms_BedType FOREIGN KEY (BedType) REFERENCES [dbo].BedTypes(Id),
--CONSTRAINT FK_Rooms_RoomStatus FOREIGN KEY (RoomStatus) REFERENCES [dbo].[RoomStatus](Id)

--ALTER TABLE Payments
--ADD Notes VARCHAR(30)
--CONSTRAINT FK_Payments_EmployeeId FOREIGN KEY (EmployeeId) REFERENCES [dbo].[Employees](Id)

--ALTER TABLE Occupancies
--ADD Notes VARCHAR(30)
--CONSTRAINT FK_Occupancies_EmployeeId FOREIGN KEY (EmployeeId) REFERENCES [dbo].[Employees](Id)

--INSERT INTO Employees(FirstName, LastName, Title, Notes)
--VALUES('Ivo', 'Ivanov', 'Operator', null),
--('Ivan', 'Petrov', 'Boss', 'djckijcnmjfcki'),
--('Niki', 'Angelov', 'Team Leader', null) 

--INSERT INTO Customers(AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
--VALUES('123456', 'Ivan', 'Ivanov', '0897123456', 'George', '0897654321', null),
--('897456', 'Aleks', 'Georgiev', '0897123456', 'George', '0897654321', 'jrdjcdjrd'),
--('324567', 'Peter', 'Petrov', '0897123456', 'George', '0897654321', null)

--INSERT INTO RoomStatus (RoomStatus, Notes)
--VALUES('Reseved', null),
--('Avaliable', null),
--('Reseved', null)

--INSERT INTO RoomTypes (RoomType, Notes)
--VALUES('Flat', null),
--('Apartment', 'jfjcoidjc'),
--('Standard Room', null)

--INSERT INTO BedTypes (BedType, Notes)
--VALUES('Singal', NULL),
--('Double', 'FKDMCDK'),
--('Standart',NULL)

--INSERT INTO Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
--VALUES (245, 1, 2, 4.5, 3, NULL),
--(067, 2, 3, 5.6, 2, 'JDNHCJD'),
--(13, 3, 1, 3.7, 1, NULL)

--INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
--VALUES(1,'2016-11-11', '123456789', '2016-05-09', '2016-08-09', 15, 'DFFSA', 3.3, 4.5, 7.7, 'HDNCJDS'),
--(2,'2016-11-11', '123456789', '2016-05-09', '2016-08-09', 15, 'DFFSA', 3.3, 4.5, 7.7, 'HDNCJDS'),
--(3,'2016-11-11', '123456789', '2016-05-09', '2016-08-09', 15, 'DFFSA', 3.3, 4.5, 7.7, 'HDNCJDS')

--INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
--VALUES (1, '2016-01-01', '1234567', 012, 5.5, 30.6, NULL),
--(2, '2016-01-01', '1234567', 025, 6.5, 40.6, 'DJNFCKSD'),
--(3, '2016-01-01', '1234567', 123, 2.5, 30.6, NULL)

--UPDATE Payments
--SET TaxRate = TaxRate - (TaxRate * 0.03)
--SELECT TaxRate FROM Payments

DELETE FROM Occupancies