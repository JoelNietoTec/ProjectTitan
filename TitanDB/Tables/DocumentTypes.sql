CREATE TABLE [dbo].[DocumentTypes]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NULL, 
    [EnglishName] NVARCHAR(50) NULL, 
    [RequiredIndividual] BIT NULL DEFAULT 0, 
    [RequiredEntity] BIT NULL DEFAULT 0 
)
