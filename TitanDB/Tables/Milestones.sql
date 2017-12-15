CREATE TABLE [dbo].[Milestones]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NTEXT NULL, 
    [ScheduleID] INT NULL,
	[Goal] NTEXT NULL,
    [BeginDate] DATE NULL, 
    [CompleteDate] DATE NULL, 
    [Completion] NUMERIC(5, 2) NULL 
)
