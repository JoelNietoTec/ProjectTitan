﻿CREATE TABLE [dbo].[Documents]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
	[FileName] NVARCHAR(100) NULL,
    [File] VARBINARY(MAX) NULL , 
    [Type] NVARCHAR(100) NOT NULL DEFAULT 'application/pdf'
)
