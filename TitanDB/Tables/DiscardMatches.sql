CREATE TABLE [dbo].[DiscardMatches]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DiscardID] INT NULL, 
    [SanctionID] INT NULL, 
    [ParticipantID] INT NULL, 
    [Pending] BIT NULL DEFAULT 1, 
    [Valid] BIT NULL DEFAULT 0
)
