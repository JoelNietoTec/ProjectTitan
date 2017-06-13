CREATE TABLE [dbo].[ParamMaster]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(100) NULL, 
    [EnglishName] NVARCHAR(100) NULL, 
    [FreeField] TINYINT NULL, 
    [IsRequired] TINYINT NULL 
)
