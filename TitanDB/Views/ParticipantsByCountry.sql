CREATE VIEW [dbo].[ParticipantsByCountry]
	AS SELECT [Participants].CountryID, [Countries].Name AS Country, [Countries].Code, [Countries].Abbreviation,  COUNT(*) Value 
	FROM [Participants] 
	LEFT OUTER JOIN [Countries] ON [Participants].CountryID = [Countries].ID 
	GROUP BY [Participants].CountryID, [Countries].Name, [Countries].Code, [Countries].Abbreviation
