CREATE TABLE [dbo].[Alerts]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AlertTypeID] INT NULL, 
    [AlertReasonID] INT NULL, 
    [Description] NVARCHAR(200) NULL, 
    [CreateDate] DATETIME NULL, 
    [ParticipantID] INT NULL, 
    [Cleared] BIT NULL, 
    [ClearedDate] DATETIME NULL, 
    [Clarification] NVARCHAR(200) NULL, 
    [ClearedBy] INT NULL
)
