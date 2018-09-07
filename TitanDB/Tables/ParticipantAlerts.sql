CREATE TABLE [dbo].[ParticipantAlerts]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ParticipantID] INT NULL, 
    [AlertTypeID] INT NULL, 
    [Name] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(100) NULL, 
    [Discard] BIT NULL, 
    [Date] DATETIME NULL, 
    [Clarification] NVARCHAR(500) NULL, 
    [DiscardedUser] INT NULL
)
