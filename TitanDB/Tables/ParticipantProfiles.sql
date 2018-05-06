CREATE TABLE [dbo].[ParticipantProfiles]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ParticipantID] INT NOT NULL, 
    [Total] MONEY NULL, 
    [ModifiedDate] DATETIME NULL, 
    [MonthlyIncomeLimit] MONEY NULL, 
    [MonthlyExpenseLimit] MONEY NULL
)

GO

CREATE TRIGGER [dbo].[Trigger_ParticipantProfiles]
    ON [dbo].[ParticipantProfiles]
    FOR UPDATE
    AS
    BEGIN
        SET NoCount ON;
		UPDATE P 
		SET P.ModifiedDate = GETDATE()
		FROM [ParticipantProfiles] P
		INNER JOIN inserted I ON P.ID = I.ID
    END