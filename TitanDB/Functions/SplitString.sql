CREATE FUNCTION [dbo].[SplitString]
(
	@String NVARCHAR(MAX)
)
RETURNS @Words TABLE([Name] [NVARCHAR] (500))
AS
BEGIN
	DECLARE @Name [NVARCHAR] (500)
	DECLARE @Pos INT

	WHILE CHARINDEX(' ', @String) > 0
	BEGIN
		SELECT @Pos = CHARINDEX(' ', @String)
		SELECT @Name = SUBSTRING(@String, 1, @Pos -1)

		INSERT INTO @Words 
		SELECT @Name

		SELECT @String = SUBSTRING(@String, @Pos + 1, LEN(@String) - @Pos)
	END

	INSERT INTO @Words
	SELECT @String

	RETURN
END
