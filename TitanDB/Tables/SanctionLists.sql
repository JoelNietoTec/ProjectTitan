CREATE TABLE [dbo].[SanctionLists]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NULL, 
    [URL] NVARCHAR(100) NULL, 
    [ElementIDs] NVARCHAR(50) NULL, 
    [TermField] NVARCHAR(50) NULL, 
    [CommentsField] NVARCHAR(50) NULL, 
    [CountryField] NVARCHAR(50) NULL, 
    [ActiveSearch] BIT NULL
)
