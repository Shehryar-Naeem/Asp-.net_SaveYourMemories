CREATE TABLE [dbo].[ImageSaver]
(
	[imgId] INT NOT NULL PRIMARY KEY, 
    [imgTitle] VARCHAR(255) NULL, 
    [imgDisc] VARCHAR(MAX) NULL, 
    [imgSelf] VARBINARY(MAX) NULL
)
