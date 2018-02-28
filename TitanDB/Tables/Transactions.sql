CREATE TABLE [dbo].[Transactions]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AccountID] INT NOT NULL, 
	[TransactionTypeID] INT NULL, 
    [Description] NVARCHAR(200) NULL, 
    [Title] NVARCHAR(100) NULL,
    [Date] DATE NULL, 
    [Amount] DECIMAL(18, 2) NULL
)
