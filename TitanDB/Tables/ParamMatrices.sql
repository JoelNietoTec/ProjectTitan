CREATE TABLE [dbo].[ParamMatrices]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(100) NOT NULL, 
    [Code] NVARCHAR(50) NOT NULL, 
    [Description] NTEXT NULL
)
