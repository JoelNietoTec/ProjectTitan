CREATE TABLE [dbo].[SanctionMatches]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SanctionListID] INT NULL, 
    [ParticipantID] INT NULL, 
    [SanctionTerm] NVARCHAR(400) NULL, 
    [SanctionComments] NTEXT NULL, 
    [Date] DATETIME NULL, 
    [Status] CHAR NULL
)
