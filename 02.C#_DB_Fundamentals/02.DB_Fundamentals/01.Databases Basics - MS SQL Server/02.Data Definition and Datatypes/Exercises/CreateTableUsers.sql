USE SoftUni
GO

CREATE TABLE Users
(
Id INT PRIMARY KEY IDENTITY(1,1),
Username NCHAR(30) NOT NULL,
Password NCHAR(26) NOT NULL,
ProfilePicture VARBINARY(900),
LastLoginTime DATE,
IsDeleted BIT NOT NULL
)

INSERT INTO Users(Username, Password, ProfilePicture, LastLoginTime, IsDeleted)
VALUES('Pesho', '1234567', null, null, 'true'),
('Aleks', 'ksjdhfkjn', null, null, 'false'),
('Sasho', 'jncmks', null, null, 'false'),
('Joro', 'knmdskjuh', null, null, 'true'),
('Doko', '87sjhfd', null, null, 'true')