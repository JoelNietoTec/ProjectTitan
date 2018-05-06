CREATE TABLE [dbo].[ProfileAccounts]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY,
	[ParticipantProfileID] INT NULL,
	[BankID] INT NULL,
    [Name] NVARCHAR(200) NULL, 
    [Code] VARCHAR(20) NULL, 
    [AccountTypeID] INT NULL, 
    [Amount] MONEY NULL, 
    [MonthlyIncomeLimit] MONEY NULL DEFAULT 0, 
    [MonthlyExpenseLimit] MONEY NULL DEFAULT 0
)

GO

CREATE TRIGGER [dbo].[Trigger_ProfileAccounts]
    ON [dbo].[ProfileAccounts]
    FOR INSERT, UPDATE
    AS
    BEGIN
        SET NoCount ON
		DECLARE @TOTAL MONEY 
		SELECT @TOTAL = SUM(P.Amount) FROM ProfileAccounts P, inserted I WHERE P.ParticipantProfileID = I.ParticipantProfileID
		UPDATE [dbo].[ParticipantProfiles] SET Total = @TOTAL FROM inserted I WHERE [ParticipantProfiles].ID = I.ParticipantProfileID
    END