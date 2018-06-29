CREATE TABLE [dbo].[Projects]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY,
    [Title] NVARCHAR(200) NULL, 
    [Description] NVARCHAR(1000) NULL, 
    [StartDate] DATE NULL, 
    [DueDate] DATE NULL, 
    [Active] BIT NULL 
)
