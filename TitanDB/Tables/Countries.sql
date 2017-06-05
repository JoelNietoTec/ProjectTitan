CREATE TABLE [dbo].[Countries]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY,
	[ContinentID] INT NOT NULL, 
    [RegionID] INT NOT NULL, 
    [Name] NVARCHAR(100) NOT NULL, 
    [OfficialName] NVARCHAR(200) NULL, 
    [ShortName] NVARCHAR(50) NULL, 
    [English Name] NVARCHAR(100) NULL, 
    [EnglishOfficialName] NVARCHAR(200) NULL, 
    [EnglishShortName] NVARCHAR(50) NULL, 
    [Demonyn] NVARCHAR(50) NULL, 
    [EnglishDemonyn] NVARCHAR(50) NULL, 
    [Score] NUMERIC(18, 5) NULL, 
    CONSTRAINT [FK_Countries_ToContinents] FOREIGN KEY ([ContinentID]) REFERENCES [Continents]([ID]), 
    CONSTRAINT [FK_Countries_ToRegions] FOREIGN KEY ([RegionID]) REFERENCES [Regions]([ID])
)
