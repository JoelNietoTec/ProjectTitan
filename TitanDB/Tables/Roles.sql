﻿CREATE TABLE [dbo].[Roles]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Admin] BIT NOT NULL
)
