USE Movies
GO

CREATE TABLE Directors(
Id INT PRIMARY KEY IDENTITY(1,1),
DirectorName VARCHAR(50) NOT NULL,
Notes VARCHAR(MAX))

CREATE TABLE Genres(
Id INT PRIMARY KEY IDENTITY(1,1),
GenresName VARCHAR(50) NOT NULL,
Notes VARCHAR(MAX))

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY(1,1),
CategoryName VARCHAR(50) NOT NULL,
Notes VARCHAR(MAX))

CREATE TABLE Movies(
Id INT PRIMARY KEY IDENTITY(1,1),
Title VARCHAR(50) NOT NULL,
DirectorId INT NOT NULL,
CopyrightYear DATE NOT NULL,
Lenght VARCHAR(5),
GenreId INT NOT NULL,
CategoryId INT NOT NULL,
Rating FLOAT)

ALTER TABLE Movies
ADD Notes VARCHAR(MAX)
CONSTRAINT FK_Movies_DirectorId FOREIGN KEY (DirectorId) REFERENCES [dbo].[Directors](Id),
CONSTRAINT FK_Movies_GenresId FOREIGN KEY (GenreId) REFERENCES [dbo].[Genres](Id),
CONSTRAINT FK_Movies_CategoryId FOREIGN KEY (CategoryId) REFERENCES [dbo].[Categories](Id) 

SET IDENTITY_INSERT Directors ON
INSERT INTO Directors(Id, DirectorName, Notes)
VALUES (1,'Stamat', 'sffcjuc juhhj kjdxjfj'),
(2,'Gerge', 'sffcjuc juhhj kjdxjfj'),
(3,'Peter', 'sffcjuc juhhj kjdxjfj'),
(4,'Aleksandyr', 'sffcjuc juhhj kjdxjfj'),
(5,'Teodor', 'sffcjuc juhhj kjdxjfj')
SET IDENTITY_INSERT Directors OFF

SET IDENTITY_INSERT Genres ON
INSERT INTO Genres(Id, GenresName, Notes)
VALUES (1,'Action', 'sffcjuc juhhj kjdxjfj'),
(2,'Triler', 'sffcjuc juhhj kjdxjfj'),
(3,'Comedy', 'jsjh jdhjfck kjkj'),
(4,'Fantasy', 'sffcjuc juhhj kjdxjfj'),
(5,'Drama', 'sffcjuc juhhj kjdxjfj')
SET IDENTITY_INSERT Genres OFF

SET IDENTITY_INSERT Categories ON
INSERT INTO Categories(Id, CategoryName, Notes)
VALUES (1,'Cat1', 'sffcjuc juhhj kjdxjfj'),
(2,'Cat2', 'sffcjuc juhhj kjdxjfj'),
(3,'Cat3', 'sffcjuc juhhj kjdxjfj'),
(4,'Cat4', 'sffcjuc juhhj kjdxjfj'),
(5,'Cat5', 'sffcjuc juhhj kjdxjfj')
SET IDENTITY_INSERT Categories OFF

SET IDENTITY_INSERT Movies ON
INSERT INTO Movies
(Id, Title, DirectorId, CopyrightYear, Lenght, GenreId, CategoryId, Rating, Notes)
VALUES (1, 'Title1', 1, '2016-11-22', '1:30', 1, 1, 5.6, 'jhjh lkll jhekclo pok'),
(2, 'Title2', 2, '2016-08-22', '1:50', 2, 2, 9.6, 'jhjh lkll jhekclo pok'),
(3, 'Title3', 3, '2016-04-22', '1:40', 3, 3, 8.6, 'jhjh lkll jhekclo pok'),
(4, 'Title4', 4, '2016-12-22', '1:20', 4, 4, 7.6, 'jhjh lkll jhekclo pok'),
(5, 'Title5', 5, '2016-01-22', '1:10', 5, 5, 6.6, 'jhjh lkll jhekclo pok')
SET IDENTITY_INSERT Movies OFF