CREATE TABLE [dbo].[Regions]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ContinentID] INT NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [EnglishName] NVARCHAR(50) NOT NULL, 
    [ShortName] NVARCHAR(50) NULL, 
    [EnglishShortName] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_Regions_ToContinent] FOREIGN KEY ([ContinentID]) REFERENCES [Continents]([ID])
)

GO
