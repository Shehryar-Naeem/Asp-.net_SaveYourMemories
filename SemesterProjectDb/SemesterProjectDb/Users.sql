CREATE TABLE [dbo].[Users]
(
	[userId] INT NOT NULL PRIMARY KEY, 
    [userName] VARCHAR(150) NULL, 
    [userEmail] VARCHAR(255) NULL, 
    [userPass] NCHAR(20) NULL
)
