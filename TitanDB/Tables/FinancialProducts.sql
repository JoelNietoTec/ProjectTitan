CREATE TABLE [dbo].[FinancialProducts]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY,
	[ProductTypeID] INT,
    [Name] NVARCHAR(50) NULL,
    [EnglishName] NVARCHAR(50) NULL 
)
