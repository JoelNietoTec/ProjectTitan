CREATE TABLE [dbo].[Params]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY,
	[ParamMatrixID] INT NULL,
    [ParamCategoryID] INT NOT NULL, 
    [Name] NVARCHAR(100) NULL, 
    [EnglishName] NVARCHAR(100) NULL, 
    [Description] NVARCHAR(500) NULL, 
    [ParamTableID] INT NOT NULL, 
    [Weighting] NUMERIC(5, 2) NULL, 
    CONSTRAINT [FK_Params_ToParamTable] FOREIGN KEY ([ParamTableID]) REFERENCES [ParamTables]([ID]), 
    CONSTRAINT [FK_Params_ToCategories] FOREIGN KEY ([ParamCategoryID]) REFERENCES [ParamCategories]([ID])
)

GO

CREATE UNIQUE INDEX [IX_Params_Name] ON [dbo].[Params] ([ParamCategoryID], [Name])

GO

CREATE UNIQUE INDEX [IX_Params_EnglishName] ON [dbo].[Params] ([ParamCategoryID], [EnglishName])
