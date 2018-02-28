CREATE TABLE [dbo].[ProfileAccounts]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY,
	[ParticipantProfileID] INT,
    [Name] NVARCHAR(200) NULL, 
    [Code] VARCHAR(20) NULL, 
    [AccountTypeID] INT NULL
)
