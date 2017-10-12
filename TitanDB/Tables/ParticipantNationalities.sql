CREATE TABLE [dbo].[ParticipantNationalities]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ParticipantID] INT NOT NULL, 
    [CountryID] INT NOT NULL
)
