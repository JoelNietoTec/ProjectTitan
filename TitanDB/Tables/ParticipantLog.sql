CREATE TABLE [dbo].[ParticipantLog]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ParticipantID] INT NULL, 
    [UserID] INT NULL, 
    [TypeID] INT NULL, 
    [ActivityDate] DATETIME NULL
)
