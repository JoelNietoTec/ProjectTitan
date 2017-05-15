CREATE TABLE [dbo].[IndividualsDocuments]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DocumentTypeID] INT NOT NULL, 
    [IndividualID] INT NOT NULL, 
    [DocumentCode] NVARCHAR(50) NULL, 
    [ExpeditionDate] DATE NULL, 
    [ExpirationDate] DATE NULL, 
    [FilePath] VARCHAR(200) NULL, 
    CONSTRAINT [FK_IndividualsDocuments_ToIndividual] FOREIGN KEY ([IndividualID]) REFERENCES [Individuals]([ID]), 
    CONSTRAINT [FK_IndividualsDocuments_ToDocumentType] FOREIGN KEY ([DocumentTypeID]) REFERENCES [DocumentTypes]([ID])
)
