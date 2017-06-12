CREATE TABLE [dbo].[ParamMaster]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(100) NULL, 
    [EnglishName] NVARCHAR(100) NULL, 
    [FreeField] CHAR(2) NULL, 
    [IsRequired] CHAR(2) NULL 
)
