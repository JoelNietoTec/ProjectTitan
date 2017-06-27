CREATE TABLE [dbo].[ParamTables]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(100) NULL, 
    [EnglishName] NVARCHAR(100) NULL, 
    [CreateDate] DATETIME NULL, 
    [ModificateDate] DATETIME NULL, 
    [TableTypeID] INT NOT NULL DEFAULT 1 
)

GO

CREATE UNIQUE INDEX [IX_ParamTables_Name] ON [dbo].[ParamTables] ([Name])

GO

CREATE UNIQUE INDEX [IX_ParamTables_EnglishName] ON [dbo].[ParamTables] ([EnglishName])
