CREATE TABLE [dbo].[Jobs]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NTEXT NULL, 
    [MilestoneID] INT NULL, 
    [Goal] NTEXT NULL, 
    [Comments] NTEXT NULL, 
    [BeginDate] DATE NULL, 
    [CompleteDate] DATE NULL, 
    [Completion] NUMERIC(5, 2) NULL, 
    [Status] BIT NULL
)
