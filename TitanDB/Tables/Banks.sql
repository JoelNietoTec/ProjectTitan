﻿CREATE TABLE [dbo].[Banks]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY,
	[BankTypeID] INT NOT NULL,
    [Name] NVARCHAR(200) NOT NULL, 
    [ShortName] NVARCHAR(50) NULL
)
