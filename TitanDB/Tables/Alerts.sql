CREATE TABLE [dbo].[Alerts]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AlertSourceID] INT NULL, 
    [AlertReasonID] INT NULL, 
    [Description] NVARCHAR(200) NULL, 
    [CreateDate] DATETIME NULL, 
    [ParticipantID] INT NULL,
	[DocumentID] INT NULL,
    [Cleared] BIT NULL DEFAULT 0, 
    [ClearedDate] DATETIME NULL, 
    [Clarification] NVARCHAR(200) NULL, 
    [ClearedBy] INT NULL
)
