CREATE FUNCTION [dbo].[ShortName]
(
	@ParticipantID INT
)
RETURNS NVARCHAR(500)
AS
BEGIN
	DECLARE @Type INT
	DECLARE @Name NVARCHAR(500)
	SELECT @Type = ParticipantTypeID FROM Participants WHERE ID = @ParticipantID
	IF (@Type = 1)
		SELECT @Name = FirstName + ' ' + ThirdName FROM Participants WHERE ID = @ParticipantID
	ELSE 
		SELECT @Name = SecondName FROM Participants WHERE ID = @ParticipantID

	RETURN  @Name
END
