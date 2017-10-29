--CREATE TABLE Towns (
--	TownID INT,
--	TownName VARCHAR(30) NOT NULL,
--	CONSTRAINT PK_Towns PRIMARY KEY(TownID)
--)

--CREATE TABLE Airports (
--	AirportID INT,
--	AirportName VARCHAR(50) NOT NULL,
--	TownID INT NOT NULL,
--	CONSTRAINT PK_Airports PRIMARY KEY(AirportID),
--	CONSTRAINT FK_Airports_Towns FOREIGN KEY(TownID) REFERENCES Towns(TownID)
--)

--CREATE TABLE Airlines (
--	AirlineID INT,
--	AirlineName VARCHAR(30) NOT NULL,
--	Nationality VARCHAR(30) NOT NULL,
--	Rating INT DEFAULT(0),
--	CONSTRAINT PK_Airlines PRIMARY KEY(AirlineID)
--)

--CREATE TABLE Customers (
--	CustomerID INT,
--	FirstName VARCHAR(20) NOT NULL,
--	LastName VARCHAR(20) NOT NULL,
--	DateOfBirth DATE NOT NULL,
--	Gender VARCHAR(1) NOT NULL CHECK (Gender='M' OR Gender='F'),
--	HomeTownID INT NOT NULL,
--	CONSTRAINT PK_Customers PRIMARY KEY(CustomerID),
--	CONSTRAINT FK_Customers_Towns FOREIGN KEY(HomeTownID) REFERENCES Towns(TownID)
--)

--INSERT INTO Towns(TownID, TownName)
--VALUES
--(1, 'Sofia'),
--(2, 'Moscow'),
--(3, 'Los Angeles'),
--(4, 'Athene'),
--(5, 'New York')

--INSERT INTO Airports(AirportID, AirportName, TownID)
--VALUES
--(1, 'Sofia International Airport', 1),
--(2, 'New York Airport', 5),
--(3, 'Royals Airport', 1),
--(4, 'Moscow Central Airport', 2)

--INSERT INTO Airlines(AirlineID, AirlineName, Nationality, Rating)
--VALUES
--(1, 'Royal Airline', 'Bulgarian', 200),
--(2, 'Russia Airlines', 'Russian', 150),
--(3, 'USA Airlines', 'American', 100),
--(4, 'Dubai Airlines', 'Arabian', 149),
--(5, 'South African Airlines', 'African', 50),
--(6, 'Sofia Air', 'Bulgarian', 199),
--(7, 'Bad Airlines', 'Bad', 10)

--INSERT INTO Customers(CustomerID, FirstName, LastName, DateOfBirth, Gender, HomeTownID)
--VALUES
--(1, 'Cassidy', 'Isacc', '19971020', 'F', 1),
--(2, 'Jonathan', 'Half', '19830322', 'M', 2),
--(3, 'Zack', 'Cody', '19890808', 'M', 4),
--(4, 'Joseph', 'Priboi', '19500101', 'M', 5),
--(5, 'Ivy', 'Indigo', '19931231', 'F', 1)

--Data Definition
--1
CREATE TABLE Flights(
FlightID INT PRIMARY KEY,
DepartureTime DATETIME NOT NULL,
ArrivalTime DATETIME NOT NULL,
[Status] VARCHAR(9),
OriginAirportID INT,
DestinationAirportID INT,
AirlineID INT,
CONSTRAINT chk_Status CHECK ([Status] IN ('Departing', 'Delayed', 'Arrived', 'Cancelled')),
CONSTRAINT FK_Flights_Airports FOREIGN KEY (OriginAirportID)
REFERENCES Airports(AirportID),FOREIGN KEY (DestinationAirportID)
REFERENCES Airports(AirportID),
CONSTRAINT FK_Flights_Airlines FOREIGN KEY (AirlineID)
REFERENCES Airlines(AirlineID)
)

CREATE TABLE Tickets(
TicketID INT PRIMARY KEY,
Price DECIMAL(8, 2) NOT NULL,
Class VARCHAR(6),
Seat VARCHAR(5) NOT NULL,
CustomerID INT,
FlightID INT,
CONSTRAINT chk_Class CHECK (Class IN ('First', 'Second', 'Third')),
CONSTRAINT FK_Tickets_Customers FOREIGN KEY (CustomerID)
REFERENCES Customers(CustomerID),
CONSTRAINT FK_Tickets_Flights FOREIGN KEY (FlightID)
REFERENCES Flights(FlightID)
)
--Database Manipulations
--1
INSERT INTO Flights(FlightID, DepartureTime, ArrivalTime, [Status],	OriginAirportID, DestinationAirportID, AirlineID)
VALUES
(1,	'2016-10-13 06:00 AM', '2016-10-13 10:00 AM',  'Delayed', 1, 4,	1),
(2,	'2016-10-12 12:00 PM', '2016-10-12 12:01 PM',  'Departing',	1, 3, 2),
(3,	'2016-10-14 03:00 PM', '2016-10-20 04:00 AM',  'Delayed', 4, 2,	4),
(4,	'2016-10-12 01:24 PM', '2016-10-12 4:31 PM'	,  'Departing',	3, 1, 3),
(5,	'2016-10-12 08:11 AM', '2016-10-12 11:22 PM',  'Departing',	4, 1, 1),
(6,	'1995-06-21 12:30 PM', '1995-06-22 08:30 PM',  'Arrived', 2, 3,	5),
(7,	'2016-10-12 11:34 PM', '2016-10-13 03:00 AM',  'Departing',	2, 4, 2),
(8,	'2016-11-11 01:00 PM', '2016-11-12 10:00 PM',  'Delayed', 4, 3,	1),
(9,	'2015-10-01 12:00 PM', '2015-12-01 01:00 AM',  'Arrived', 1, 2,	1),
(10, '2016-10-12 07:30 PM', '2016-10-13 12:30 PM', 'Departing', 2, 1, 7)

INSERT INTO Tickets(TicketID, Price, Class,	Seat, CustomerID, FlightID)
VALUES
(1,	3000.00, 'First', '233-A', 3, 8),
(2,	1799.90, 'Second', '123-D', 1, 1),
(3,	1200.50, 'Second' ,'12-Z', 2, 5),
(4,	410.68, 'Third', '45-Q', 2,	8),
(5,	560.00, 'Third', '201-R', 4, 6),
(6,	2100.00, 'Second', '13-T', 1, 9),
(7,	5500.00, 'First', '98-O', 2, 7)

--2
UPDATE [dbo].[Flights]
   SET AirlineID = 1
 WHERE [Status] = 'Arrived'

 --3
 UPDATE [dbo].[Tickets]
    SET Price = Price + (Price * 0.5)
	  FROM [dbo].[Flights] AS f
	 INNER JOIN [dbo].[Tickets] AS t
	    ON t.FlightID = f.FlightID
	 INNER JOIN [dbo].[Airlines] AS a
	    ON a.AirlineID = f.AirlineID
	 WHERE a.Rating = 200
	 

	 --4
CREATE TABLE CustomerReviews(
ReviewID INT PRIMARY KEY,
ReviewContent VARCHAR(MAX) NOT NULL,
ReviewGrade INTEGER,
AirlineID INT,
CustomerID INT,
CONSTRAINT FK_CustomerReviews_Airlines FOREIGN KEY (AirlineID)
REFERENCES Airlines(AirlineID),
CONSTRAINT FK_CustomerReviews_Customers FOREIGN KEY (CustomerID)
REFERENCES Customers(CustomerID)
)

CREATE TABLE CustomerBankAccounts(
AccountID INT PRIMARY KEY,
AccountNumber VARCHAR(10) UNIQUE NOT NULL,
Balance DECIMAL(10, 2) NOT NULL,
CustomerID INT,
CONSTRAINT FK_CustomerBankAccounts_Customers FOREIGN KEY (CustomerID)
REFERENCES Customers(CustomerID)
)	
--5
INSERT INTO CustomerReviews(ReviewID, ReviewContent, ReviewGrade, AirlineID, CustomerID)
VALUES
(1,'Me is very happy. Me likey this airline. Me good.',	10,	1, 1),
(2,'Ja, Ja, Ja... Ja, Gut, Gut, Ja Gut! Sehr Gut!',	10,	1, 4),
(3,'Meh...', 5,	4, 3),
(4,'Well Ive seen better, but Ive certainly seen a lot worse...', 7, 3,	5)

INSERT INTO CustomerBankAccounts(AccountID, AccountNumber, Balance, CustomerID)
VALUES
(1,'123456790',	2569.23, 1),
(2,'18ABC23672', 14004568.23, 2),
(3,'F0RG0100N3', 19345.20, 5)

--QUERING
--1
SELECT t.TicketID, t.Price, t.Class, t.Seat
  FROM [dbo].[Tickets] AS t
 ORDER BY t.TicketID ASC

 --2
 SELECT c.CustomerID, 
       (c.FirstName + ' ' + c.LastName) AS FullName,
	   c.Gender
  FROM [dbo].[Customers] AS c
 ORDER BY FullName ASC, c.CustomerID ASC

 --3
 SELECT f.FlightID, f.DepartureTime, f.ArrivalTime
   FROM [dbo].[Flights] AS f
  WHERE f.[Status] = 'Delayed'
  ORDER BY f.FlightID ASC

  --4
   SELECT TOP 5 a.AirlineID, a.AirlineName, a.Nationality, a.Rating 
     FROM [dbo].[Flights] AS f
	INNER JOIN [dbo].[Airlines] AS a
	   ON a.AirlineID = f.AirlineID
	   GROUP BY  a.AirlineID, a.AirlineName, a.Nationality, a.Rating 
	   ORDER BY a.Rating DESC, a.AirlineID ASC
   --5
   SELECT t.TicketID, 
          a.AirportName AS Destination,
		  (c.FirstName + ' ' + c.LastName) AS CustomerName
     FROM [dbo].[Tickets] AS t
	INNER JOIN [dbo].[Customers] AS c
	   ON c.CustomerID = t.CustomerID
	INNER JOIN [dbo].[Flights] AS f
	   ON f.FlightID = t.FlightID
	INNER JOIN [dbo].[Airports] AS a
	   ON a.AirportID = f.DestinationAirportID
	WHERE t.Price < 5000
	  AND t.Class = 'First'
	ORDER BY t.TicketID ASC

	--6
	SELECT c.CustomerID, (c.FirstName + ' ' + c.LastName) AS FullName, tow.TownName
	  FROM [dbo].[Tickets] AS t
	 INNER JOIN [dbo].[Customers] AS c
	    ON c.CustomerID = t.CustomerID
	 INNER JOIN [dbo].[Flights] AS f
	    ON f.FlightID = t.FlightID
	 INNER JOIN [dbo].[Towns] AS tow
	    ON tow.TownID = c.HomeTownID
	 WHERE f.[Status] = 'Departing'
	   AND c.HomeTownID = f.OriginAirportID

		--7
		SELECT c.CustomerID, 
		      (c.FirstName + ' ' + c.LastName) AS FullName,
			  DATEDIFF(YEAR, c.DateOfBirth, '2016') AS Age
		  FROM [dbo].[Tickets] AS t
		 INNER JOIN [dbo].[Flights] AS f
		    ON f.FlightID = t.FlightID
		 INNER JOIN [dbo].[Customers] AS c
		    ON c.CustomerID = t.CustomerID
		 WHERE f.[Status] = 'Departing'
		 GROUP BY c.CustomerID, (c.FirstName + ' ' + c.LastName),  DATEDIFF(YEAR, c.DateOfBirth, '2016')
		 ORDER BY c.CustomerID ASC

		 --8
		 SELECT TOP 3 c.CustomerID, 
		        c.FirstName + ' ' + c.LastName AS FullName,
		        t.Price AS TicketPrice,
				a.AirportName AS Destination
		   FROM [dbo].[Tickets] AS t
		  INNER JOIN [dbo].[Flights] AS f
		     ON f.FlightID = t.FlightID
		  INNER JOIN [dbo].[Airports] AS a
		     ON a.AirportID = f.DestinationAirportID
		  INNER JOIN [dbo].[Customers] AS c
		     ON c.CustomerID = t.CustomerID

		--9
		SELECT TOP 5 f.FlightID, f.DepartureTime, f.ArrivalTime, 
		       a.AirportName AS Origin, a1.AirportName AS Destination
		  FROM [dbo].[Flights] AS f
		 INNER JOIN [dbo].[Airports] AS a
		    ON a.AirportID = f.OriginAirportID
			INNER JOIN [dbo].[Airports] AS a1
		    ON a1.AirportID = f.DestinationAirportID
		 WHERE f.[Status] = 'Departing'
		 ORDER BY f.DepartureTime ASC

		 --10
		 SELECT c.CustomerID, 
		       (c.FirstName + ' ' + c.LastName) AS FullName,
			   DATEDIFF(YEAR, c.DateOfBirth, '2016') AS Age
		   FROM [dbo].[Tickets] AS t
		 INNER JOIN [dbo].[Flights] AS f
		    ON f.FlightID = t.FlightID
		 INNER JOIN [dbo].[Customers] AS c
		    ON c.CustomerID = t.CustomerID
		 WHERE DATEDIFF(YEAR, c.DateOfBirth, '2016') < 21
		   AND f.[Status] = 'Arrived'
		 ORDER BY Age DESC, c.CustomerID ASC

		 --11
		 SELECT a.AirportID, a.AirportName, COUNT(t.CustomerID) AS Passengers 
		   FROM [dbo].[Tickets] AS t
		  RIGHT JOIN [dbo].[Flights] AS f
		     ON f.FlightID = t.FlightID
		  RIGHT JOIN [dbo].[Airports] AS a
		     ON a.AirportID = f.OriginAirportID
		  WHERE f.[Status] = 'Departing'
		  GROUP BY  a.AirportID, a.AirportName
		 HAVING COUNT(t.CustomerID) != 0
		  ORDER BY a.AirportID ASC

		  --Programmability
	--1
	CREATE PROCEDURE usp_SubmitReview
	(@CustomerID INT, @ReviewContent VARCHAR(MAX), @ReviewGrade INTEGER, @AirlineName VARCHAR(30))
	AS
	BEGIN
		BEGIN TRAN
		SELECT cr.CustomerID, cr.ReviewContent, cr.ReviewGrade, a.AirlineName 
	      FROM [dbo].[CustomerReviews] AS cr
	     RIGHT JOIN [dbo].[Airlines] AS a
	        ON a.AirlineID = cr.AirlineID
		 WHERE a.AirlineName = @AirlineName
		 --WHERE cr.CustomerID = @CustomerID
		 --  AND cr.ReviewContent = @ReviewContent
		 --  AND cr.ReviewGrade = @ReviewGrade
		 --  AND a.AirlineName = @AirlineName
		 IF (@AirlineName!=a.AirlineName)
		 BEGIN
			ROLLBACK
			RAISERROR('Airline does not exist.', 16, 1)
		 END
		 ELSE
		 BEGIN
		 COMMIT
		 END
	END
	EXEC [dbo].[usp_SubmitReview] @CustomerID=1, @ReviewContent='Me is very happy. Me likey this airline. Me good.', @ReviewGrade=10, @AirlineName='HG'
	SELECT * 
	  FROM [dbo].[CustomerReviews] AS cr
	  LEFT JOIN [dbo].[Airlines] AS e
	    ON e.AirlineID = cr.AirlineID

