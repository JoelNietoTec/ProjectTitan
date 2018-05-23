CREATE TABLE [dbo].[AlertReasons]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
	[AlertSourceID] INT,
    [Name] NVARCHAR(50) NULL, 
    [EnglishName] NVARCHAR(50) NULL, 
    [AlertPriorityID] INT NULL DEFAULT 1, 
    [Code] NVARCHAR(50) NOT NULL UNIQUE
)
