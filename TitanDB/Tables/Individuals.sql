﻿CREATE TABLE [dbo].[Individuals]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
	[Code] NVARCHAR(50),
    [FirstName] NVARCHAR(100) NULL, 
    [SecondName] NVARCHAR(100) NULL, 
    [ThirdName] NVARCHAR(100) NULL, 
    [FourthName] NVARCHAR(100) NULL, 
    [GenderID] INT NOT NULL, 
    [BirthDate] DATE NULL, 
    [Email] VARCHAR(100) NULL, 
    CONSTRAINT [FK_Individuals_ToGenders] FOREIGN KEY ([GenderID]) REFERENCES [Genders]([ID])
)
