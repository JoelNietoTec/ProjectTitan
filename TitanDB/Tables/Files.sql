﻿CREATE TABLE [dbo].[Files]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FileName] VARCHAR(200) NULL, 
    [FilePath] NVARCHAR(200) NULL
)