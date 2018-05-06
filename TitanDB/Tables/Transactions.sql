CREATE TABLE [dbo].[Transactions]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AccountID] INT NOT NULL,
	[ProfileProductID] INT DEFAULT 1,
	[ParticipantID] INT NULL,
	[ParticipantProfileID] INT NULL,
	[TransactionTypeID] INT NULL,
	[TransactionSourceID] INT NULL DEFAULT 1,
    [Description] NVARCHAR(200) NULL, 
    [Title] NVARCHAR(100) NULL,
    [Date] DATETIME NULL,
    [Amount] DECIMAL(18, 2) NULL
)

GO

CREATE TRIGGER [dbo].[Trigger_Transactions]
    ON [dbo].[Transactions]
    FOR INSERT
    AS
    BEGIN
        SET NoCount ON
		DECLARE @Type INT
		DECLARE @ProductType INT

		SELECT @ProductType = ProductTypeID FROM FinancialProducts
		LEFT OUTER JOIN ProfileProducts ON ProfileProducts.FinancialProductID = FinancialProducts.ID
		INNER JOIN  inserted ON ProfileProducts.ID = inserted.ProfileProductID

		SELECT @Type = TransactionTypeID FROM inserted 
		IF (@Type = 1)
		BEGIN
			--- Accounts ---
			--UPDATE ProfileAccounts SET Amount = ProfileAccounts.Amount + inserted.Amount FROM inserted WHERE inserted.AccountID = ProfileAccounts.ID
			--- Products
			IF (@ProductType = 1)
				UPDATE ProfileProducts SET Balance = Balance + inserted.Amount FROM inserted WHERE inserted.ProfileProductID = ProfileProducts.ID

			IF (@ProductType = 2)
				UPDATE ProfileProducts SET Balance = Balance - inserted.Amount FROM inserted WHERE inserted.ProfileProductID = ProfileProducts.ID
		END
		IF (@Type = 2)
		BEGIN
			--UPDATE ProfileAccounts SET Amount = ProfileAccounts.Amount - inserted.Amount FROM inserted WHERE inserted.AccountID = ProfileAccounts.ID

			--- Products
			IF (@ProductType = 1)
				UPDATE ProfileProducts SET Balance = Balance - inserted.Amount FROM inserted WHERE inserted.ProfileProductID = ProfileProducts.ID

			IF (@ProductType = 2)
				UPDATE ProfileProducts SET Balance = Balance + inserted.Amount FROM inserted WHERE inserted.ProfileProductID = ProfileProducts.ID
		END
		
    END