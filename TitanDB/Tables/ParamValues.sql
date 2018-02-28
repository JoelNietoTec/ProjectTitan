CREATE TABLE [dbo].[ParamValues]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
	[ParamTableID] INT NOT NULL,
    [DisplayValue] NVARCHAR(100) NULL, 
    [EnglishDisplayValue] NVARCHAR(100) NULL, 
    [Score] NUMERIC(10, 2) NULL, 
    CONSTRAINT [FK_ParamValues_ToTables] FOREIGN KEY ([ParamTableID]) REFERENCES [ParamTables]([ID]) ON  DELETE CASCADE
)

GO

CREATE UNIQUE INDEX [IX_ParamValues_DisplayValue] ON [dbo].[ParamValues] ([ParamTableID], [DisplayValue])

GO

CREATE UNIQUE INDEX [IX_ParamValues_EnglishDisplayValue] ON [dbo].[ParamValues] ([ParamTableID], [EnglishDisplayValue])

GO

CREATE TRIGGER [dbo].[Trigger_ParamValues]
    ON [dbo].[ParamValues]
    FOR UPDATE
    AS
    BEGIN
	SET NoCount ON
        UPDATE ParticipantParams 
		SET Score = inserted.Score 
		FROM inserted WHERE ParamValueID = inserted.ID
    END