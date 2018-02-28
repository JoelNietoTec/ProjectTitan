CREATE TABLE [dbo].[Roadmaps]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(200) NOT NULL, 
    [StartDate] DATE NULL, 
    [EndDate] DATE NULL, 
    [Year] INT NULL, 
    [Active] BIT NULL, 
    [Completed] BIT NULL
)
