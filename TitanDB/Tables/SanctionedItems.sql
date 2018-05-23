CREATE TABLE [dbo].[SanctionedItems]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ListID] INT NULL, 
    [Term1] NVARCHAR(400) NULL, 
    [Term2] NVARCHAR(400) NULL, 
    [Term3] NVARCHAR(400) NULL, 
    [Term4] NVARCHAR(400) NULL, 
    [Comments] TEXT NULL,
	[Country] NVARCHAR(400) NULL,
	[Nationality] NVARCHAR(400) NULL,
    [Date] DATETIME NULL
)
