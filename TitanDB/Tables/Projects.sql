CREATE TABLE [dbo].[Projects]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(50) NULL, 
    [Description] NCHAR(10) NULL, 
    [BeginDate] DATE NULL, 
    [EndDate] NCHAR(10) NULL
)
