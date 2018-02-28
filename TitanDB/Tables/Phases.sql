CREATE TABLE [dbo].[Phases]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY,
	[RoadmapID] INT NOT NULL,
    [Title] NVARCHAR(200) NULL, 
    [Description] NVARCHAR(500) NULL, 
    [StartDate] DATE NULL, 
    [EndDate] DATE NULL
)
