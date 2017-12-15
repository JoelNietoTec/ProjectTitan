CREATE TABLE [dbo].[Events]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(100) NOT NULL, 
    [Description] NTEXT NULL, 
    [BeginDate] DATE NULL, 
    [BeginHour] TIME NULL, 
    [EndDate] DATE NULL, 
    [EndHour] TIME NULL, 
    [FullDay] BIT NOT NULL, 
    [Active] BIT NULL, 
    [Recurring] BIT NULL, 
    [MainID] INT NULL
)
