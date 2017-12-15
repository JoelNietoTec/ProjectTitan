CREATE TABLE [dbo].[Schedules]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
	[Year] INT,
    [Title] NVARCHAR(50) NULL, 
    [Description] NTEXT NULL, 
    [BeginDate] DATE NULL, 
    [CompleteDate] DATE NULL, 
    [Status] BIT NULL
)
