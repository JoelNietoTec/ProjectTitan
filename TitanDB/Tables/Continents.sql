﻿CREATE TABLE [dbo].[Continents]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [EnglishName] NVARCHAR(50) NOT NULL, 
    [ShortName] NVARCHAR(50) NULL
)
