CREATE TABLE [dbo].[ParticipantParams]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ParticipantID] INT NOT NULL,
	[ParamMatrixID] INT NOT NULL,
    [ParamCategoryID] INT NOT NULL,
	[ParamID] INT NOT NULL,
    [ParamValueID] INT NULL,
	[ParamSubValueID] INT NULL,
    [Score] NUMERIC(5, 2) NULL
)

GO


CREATE TRIGGER [dbo].[Trigger_Params]
    ON [dbo].[ParticipantParams]
    FOR UPDATE
    AS
    BEGIN
        SET NoCount ON
		DECLARE @id int

		SELECT @id = ParticipantID FROM inserted

		EXEC GetParticipantScore @id
    END