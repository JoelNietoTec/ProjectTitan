CREATE TABLE [dbo].[ParamMaster]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY,
    [ParamCategoryID] INT NOT NULL, 
    [Name] NVARCHAR(100) NULL, 
    [EnglishName] NVARCHAR(100) NULL, 
    [FreeField] CHAR(2) NULL, 
    [IsRequired] CHAR(2) NULL, 
    [Weighting] NUMERIC(5, 2) NULL, 
    CONSTRAINT [FK_ParamMaster_ToCategories] FOREIGN KEY ([ParamCategoryID]) REFERENCES [ParamCategories]([ID])
)
