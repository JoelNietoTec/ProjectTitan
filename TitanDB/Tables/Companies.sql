CREATE TABLE [dbo].[Companies]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
	[AccountID] INT NULL,
	[CompanyID] INT,
	[TypeID] INT NULL,
    [Name] NVARCHAR(50) NULL,
	[IndustryID] INT NULL,
    [FullName] NVARCHAR(200) NULL, 
    [ShortName] NVARCHAR(10) NULL, 
    [Address] NVARCHAR(200) NULL, 
    [Active] BIT NULL
)
