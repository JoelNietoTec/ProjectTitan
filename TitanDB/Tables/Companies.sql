﻿CREATE TABLE [dbo].[Companies]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NULL, 
    [FullName] NVARCHAR(200) NULL, 
    [ShortName] NVARCHAR(10) NULL
)
