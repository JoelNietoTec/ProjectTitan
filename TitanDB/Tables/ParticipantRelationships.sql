CREATE TABLE [dbo].[ParticipantRelationships]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ParticipantID] INT NULL, 
    [RelatedParticipantID] INT NULL, 
    [RelationshipTypeID] INT NULL
)
