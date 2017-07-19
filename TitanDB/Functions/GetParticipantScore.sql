CREATE PROCEDURE [dbo].[GetParticipantScore]
(
	@ParticipantID INT
)
--RETURNS NUMERIC(5,3)
AS
BEGIN
	DECLARE @Score NUMERIC (5,3)
	
	IF NOT EXISTS (SELECT 1 FROM ParticipantParams WHERE ParticipantID = @ParticipantID AND Score IS NULL)

	SELECT @Score = SUM(CAT.Score * (PC.Weighting/100)) FROM (
	SELECT PP.ParamCategoryID, SUM(PP.Score * (P.Weighting/100)) Score  FROM 
	ParticipantParams PP
	INNER JOIN Params P ON PP.ParamID = P.ID 
	WHERE PP.ParticipantID = @ParticipantID
	GROUP BY  PP.ParamCategoryID) CAT
	INNER JOIN ParamCategories PC ON PC.ID = CAT.ParamCategoryID
	ELSE 
	SET @Score = NULL

	UPDATE dbo.Participants SET Score = @Score WHERE ID = @ParticipantID

	SELECT @Score Score
END
