CREATE TABLE [dbo].[AlertReasons]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
	[AlertSourceID] INT,
    [Name] NVARCHAR(50) NULL, 
    [EnglishName] NVARCHAR(50) NULL
)
