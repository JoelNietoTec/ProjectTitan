CREATE TABLE [dbo].[Tasks]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY,
	[ProjectID] INT NOT NULL DEFAULT 1,
    [Title] NVARCHAR(100) NULL, 
    [Description] NTEXT NULL, 
    [CreatedDate] DATETIME NULL, 
    [CreatedBy] INT NULL, 
    [BeginDate] DATETIME NULL, 
    [ExpirationDate] DATETIME NULL, 
    [CompletedDate] DATETIME NULL, 
    [StatusID] INT NULL, 
    [ParticipantID] INT NULL, 
    [RecurrenceID] INT NULL
)
