CREATE TABLE [dbo].[ParamCategories]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY,
	[ParamMatrixID] INT NOT NULL,
    [Name] NVARCHAR(100) NULL, 
    [EnglishName] NVARCHAR(100) NULL, 
    [Weighting] NUMERIC(5, 2) NULL 
)

GO

CREATE UNIQUE INDEX [IX_ParamCategories_Name] ON [dbo].[ParamCategories] ([ParamMatrixID], [Name])

GO

CREATE UNIQUE INDEX [IX_ParamCategories_EnglishName] ON [dbo].[ParamCategories] ([ParamMatrixID], [EnglishName])

GO

CREATE TRIGGER [dbo].[Trigger_ParamCategories]
    ON [dbo].[ParamCategories]
    FOR INSERT
    AS
    BEGIN
        SET NoCount ON

		
    END