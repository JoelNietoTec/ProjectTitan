CREATE TABLE [dbo].[Events]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(100) NULL, 
    [Description] NTEXT NULL, 
    [BeginDate] NCHAR(10) NULL
)
