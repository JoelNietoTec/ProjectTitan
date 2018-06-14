CREATE TABLE [dbo].[Assignments]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AssignmentTypeID] INT NOT NULL, 
    [Title] NVARCHAR(200) NOT NULL, 
    [Description] NTEXT NULL, 
    [CreatedDate] DATETIME NULL, 
    [CreateUserID] INT NULL, 
    [StartDate] DATETIME NULL, 
    [DueDate] DATETIME NULL, 
    [CompletedDate] DATETIME NULL, 
    [AssignedUserID] INT NULL, 
    [ParticipantID] INT NULL, 
    [ProgressID] INT NULL
)
