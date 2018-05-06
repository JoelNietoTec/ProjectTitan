CREATE TABLE [dbo].[ProfileProducts]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ParticipantProfileID] INT NULL, 
	[FinancialProductID] INT NULL,
	[Name] NVARCHAR(50),
	[Description] TEXT,
    [StartDate] DATETIME NULL, 
    [DueDate] DATETIME NULL, 
    [MonthlyPayment] MONEY NULL DEFAULT 0, 
    [Balance] MONEY NULL DEFAULT 0
)
