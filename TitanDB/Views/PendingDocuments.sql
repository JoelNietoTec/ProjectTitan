CREATE VIEW [dbo].[PendingDocuments]
	AS SELECT DT.ID, P.ID ParticipantID, DT.Name, DT.EnglishName, ISNULL(PD.ID, 0) Uploaded
	FROM [Participants] P
	LEFT OUTER JOIN 
	[DocumentTypes] DT ON CASE 
	WHEN P.ParticipantTypeID = 1 AND RequiredIndividual = 1 THEN 1
	WHEN P.ParticipantTypeID = 2 AND RequiredEntity = 1 THEN 1
	ELSE 0
	END = 1
	LEFT OUTER JOIN [ParticipantDocuments] PD ON P.ID = PD.ParticipantID AND PD.DocumentTypeID = DT.ID

