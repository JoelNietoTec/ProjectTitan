CREATE VIEW [dbo].[UsersInfo]
	AS SELECT ID, AccountID, UserName, Email, Active, CreateDate, RoleID  FROM [Users]
