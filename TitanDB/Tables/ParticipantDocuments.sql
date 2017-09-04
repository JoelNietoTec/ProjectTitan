CREATE TABLE [dbo].[ParticipantDocuments]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DocumentTypeID] INT NOT NULL, 
    [ParticipantID] INT NOT NULL, 
    [DocumentCode] NVARCHAR(50) NULL, 
    [ExpeditionDate] DATE NULL, 
    [ExpirationDate] DATE NULL, 
    [FilePath] VARCHAR(200) NULL, 
    [CountryID] INT NULL, 
    [FileID] INT NULL 
)
