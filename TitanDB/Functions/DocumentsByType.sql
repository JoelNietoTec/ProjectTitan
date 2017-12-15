CREATE FUNCTION [dbo].[DocumentsByType]
(
	@TypeID int
)
RETURNS @documents TABLE
(
	ID int,
	Name nvarchar(100),
	EnglishName nvarchar(100)
)
AS
BEGIN
	
	IF @TypeID = 1
	INSERT INTO @documents
	SELECT ID, Name, EnglishName FROM DocumentTypes WHERE RequiredIndividual = 1

	IF @TypeID = 2
	INSERT INTO @documents
	SELECT ID, Name, EnglishName FROM DocumentTypes WHERE RequiredEntity = 1

	RETURN
END
