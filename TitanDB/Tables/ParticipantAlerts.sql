CREATE TABLE [dbo].[ParticipantAlerts]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ParticipantID] INT NULL, 
    [AlertTypeID] INT NULL, 
    [Name] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(100) NULL, 
    [Discard] BIT NULL, 
    [Date] DATETIME NULL, 
    [Clarification] TEXT NULL, 
    [DiscardedUser] INT NULL
)
