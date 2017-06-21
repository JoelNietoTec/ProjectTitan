﻿CREATE TABLE [dbo].[ParamValues]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
	[ParamTableID] INT NOT NULL,
    [DisplayValue] NVARCHAR(100) NULL, 
    [EnglishDisplayValue] NVARCHAR(100) NULL, 
    [Score] NUMERIC(10, 2) NULL, 
    CONSTRAINT [FK_ParamValues_ToTables] FOREIGN KEY ([ParamTableID]) REFERENCES [ParamTables]([ID])
)
