﻿CREATE TABLE [dbo].[ParticipantsDocuments]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DocumentTypeID] INT NOT NULL, 
    [ParticipantID] INT NOT NULL, 
    [DocumentCode] NVARCHAR(50) NULL, 
    [ExpeditionDate] DATE NULL, 
    [ExpirationDate] DATE NULL, 
    [FilePath] VARCHAR(200) NULL 
)