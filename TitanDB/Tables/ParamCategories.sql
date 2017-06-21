CREATE TABLE [dbo].[ParamCategories]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY,
	[ParamMatrixID] INT NOT NULL,
    [Name] NVARCHAR(100) NULL, 
    [EnglishName] NVARCHAR(100) NULL, 
    [Weighting] NUMERIC(5, 2) NULL 
)
