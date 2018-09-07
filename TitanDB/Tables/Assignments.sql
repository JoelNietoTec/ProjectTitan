CREATE TABLE [dbo].[Assignments]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY,
	[ProjectID] INT NULL,
    [AssignmentTypeID] INT NOT NULL, 
    [Title] NVARCHAR(200) NOT NULL, 
    [Description] NVARCHAR(2000) NULL, 
    [CreatedDate] DATETIME NULL, 
    [CreateUserID] INT NULL, 
    [StartDate] DATETIME NULL, 
    [DueDate] DATETIME NULL, 
    [CompletedDate] DATETIME NULL, 
    [AssignedUserID] INT NULL, 
    [ParticipantID] INT NULL, 
    [ProgressID] INT NULL
)
