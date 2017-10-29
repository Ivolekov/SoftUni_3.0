USE SoftUni
GO

CREATE TABLE People(
Id INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR(200) NOT NULL,
Picture VARBINARY,
Height FLOAT,
Weight FLOAT,
Gender NCHAR(1) NOT NULL,
Birthdate DATE NOT NULL,
Biography VARCHAR(MAX) )

SET IDENTITY_INSERT People ON

INSERT INTO People (
[Id],
[Name], 
[Picture], 
[Height], 
[Weight], 
[Gender], 
[Birthdate], 
[Biography])
VALUES (1, 'Bob', null, 2.43, 3.56, 'M', '2016-11-22', 'kjdsfdsjf erthjhsfd!'),
(2, 'Bary', null, 6.83, 8.46, 'F', '2014-10-12', 'dszffdsfdsfjjj  rthjhsfd!'),
(3, 'Gary', null, 21.43, 33.56, 'M', '1987-04-25', 'swuiyfcnjsbd kjhuihyc khjfdd!'),
(4, 'Hary', null, 2.43, 3.56, 'F', '1976-03-07', 'kjirdnckiswui ijj odjcmj eoij '),
(5, 'Peter', null, 2.43, 3.56, 'M', '1999-05-08', 'kjdsfdsjf erthjhsfd!')

SET IDENTITY_INSERT People OFF
