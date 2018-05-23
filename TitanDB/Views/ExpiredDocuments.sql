CREATE VIEW [dbo].[ExpiredDocuments]
	AS SELECT D.ID, D.DocumentTypeID, D.ParticipantID, D.DocumentCode, D.ExpeditionDate, D.ExpirationDate, D.FilePath 
	FROM  [dbo].[ParticipantDocuments] D
	WHERE D.ExpeditionDate <= GETDATE()

