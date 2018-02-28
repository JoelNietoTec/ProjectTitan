CREATE TABLE [dbo].[Milestones]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PhaseID] INT NOT NULL, 
    [Title] NVARCHAR(200) NULL, 
    [Description] NVARCHAR(500) NULL, 
    [StartDate] DATE NULL, 
    [EndDate] DATE NULL, 
    [Completion] NUMERIC NULL, 
    [RecurrenceID] INT NULL
)
