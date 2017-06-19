CREATE TABLE [dbo].[Params]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ParamCategoryID] INT NOT NULL, 
    [Name] NVARCHAR(100) NULL, 
    [EnglishName] NVARCHAR(100) NULL, 
    [Description] NTEXT NULL, 
    [ParamTableID] INT NOT NULL, 
    [Weighting] NUMERIC(5, 2) NULL, 
    CONSTRAINT [FK_Params_ToParamTable] FOREIGN KEY ([ParamTableID]) REFERENCES [ParamTables]([ID]), 
    CONSTRAINT [FK_Params_ToCategories] FOREIGN KEY ([ParamCategoryID]) REFERENCES [ParamCategories]([ID])
)
