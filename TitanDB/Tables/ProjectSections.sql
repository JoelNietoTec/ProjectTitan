CREATE TABLE [dbo].[ProjectSections]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(100) NULL UNIQUE, 
    [Description] NVARCHAR(500) NULL, 
    [Active] BIT NULL
)
