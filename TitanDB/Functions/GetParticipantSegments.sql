CREATE FUNCTION [dbo].[GetParticipantSegments]
(
	@ParamID int
)
RETURNS @returntable TABLE
(
	ValueName nvarchar(200),
	EnglishValueName nvarchar(200),
	ValueID int,
	SubValueID int,
	Count int
)
AS
BEGIN

	DECLARE @TableType int

	SELECT @TableType = ParamTables.TableTypeID FROM 
	[dbo].[Params]
	INNER JOIN [dbo].[ParamTables] ON Params.ParamTableID = ParamTables.ID 
	where Params.ID = @ParamID

	IF (@TableType = 1)
	INSERT INTO @returntable(ValueName, EnglishValueName, ValueID, SubValueID, Count)
	SELECT 
	ISNULL(ParamValues.DisplayValue, 'No definido') AS ValueName,
	ISNULL(ParamValues.EnglishDisplayValue, 'Not defined') AS EnglishValueName,
	ISNULL(ParamValues.ID, 0) ValueID,
	0 SubValueID,
	COUNT(*) Count
	FROM [dbo].[ParticipantParams]
	LEFT OUTER JOIN [dbo].[ParamValues] ON ParamValues.ID = ParticipantParams.ParamValueID
	WHERE ParamID = @ParamID
	GROUP BY ISNULL(ParamValues.DisplayValue, 'No definido'),  
	ISNULL(ParamValues.EnglishDisplayValue, 'Not defined'),
	ISNULL(ParamValues.ID, 0)
	
	IF (@TableType = 2)
	INSERT INTO @returntable(ValueName, EnglishValueName, ValueID, SubValueID, Count)
	SELECT 
	ISNULL(ParamSubValues.DisplayValue, 'No definido') AS ValueName,
	ISNULL(ParamSubValues.EnglishDisplayValue, 'Not defined') AS EnglishValueName,
	ISNULL(ParamValues.ID, 0)  ValueID,
	ISNULL(ParamSubValues.ID, 0)  SubValueID,
	COUNT(*) Count
	FROM [dbo].[ParticipantParams]
	LEFT OUTER JOIN [dbo].[ParamValues] ON ParamValues.ID = ParticipantParams.ParamValueID
	LEFT OUTER JOIN [dbo].[ParamSubValues] ON ParamSubValues.ID = ParticipantParams.ParamSubValueID
	WHERE ParamID = @ParamID
	GROUP BY 
	ISNULL(ParamSubValues.DisplayValue, 'No definido'),  
	ISNULL(ParamSubValues.EnglishDisplayValue, 'Not defined'),
	ISNULL(ParamValues.ID, 0),
	ISNULL(ParamSubValues.ID, 0)

	RETURN
END
