CREATE TABLE [dbo].[Countries]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(100) NOT NULL, 
    [EnglishName] NVARCHAR(100) NULL, 
    [Abbreviation] NVARCHAR(10) NULL, 
    [Code] NVARCHAR(10) NULL 
)
