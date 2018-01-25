CREATE TABLE [dbo].[Matches]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ComparisonID] INT NULL, 
    [ParticipantID] INT NULL, 
    [Term1] NVARCHAR(200) NULL, 
    [Term2] NVARCHAR(200) NULL, 
    [Pending] BIT NULL, 
    [Confirmed] BIT NULL, 
    [Score] INT NULL
)
