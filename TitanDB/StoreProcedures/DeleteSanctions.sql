CREATE PROCEDURE [dbo].[DeleteSanctions]
	@ListID INT
AS
	DELETE FROM [dbo].[SanctionedItems] WHERE ListID = @ListID
