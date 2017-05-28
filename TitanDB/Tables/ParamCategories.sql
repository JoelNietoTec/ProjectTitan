﻿CREATE TABLE [dbo].[ParamCategories]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY,
	[MatrixID] INT NOT NULL,
    [Name] NVARCHAR(100) NULL, 
    [EnglishName] NVARCHAR(100) NULL, 
    [Weighting] NUMERIC(5, 2) NULL, 
    CONSTRAINT [FK_ParamCategories_ToMatrices] FOREIGN KEY ([MatrixID]) REFERENCES [ParamMatrices]([ID])
)
