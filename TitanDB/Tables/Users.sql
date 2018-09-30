CREATE TABLE [dbo].[Users]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY,
	[AccountID] INT NULL DEFAULT 1,
	[RoleID] INT ,
    [UserName] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(100) NULL, 
    [Active] INT NULL, 
    [CreateDate] DATETIME NULL, 
    [LastChangePassword] DATETIME NULL 
)

GO

CREATE UNIQUE INDEX [IX_Users_Username] ON [dbo].[Users] ([UserName])

GO


CREATE UNIQUE INDEX [IX_Users_Email] ON [dbo].[Users] ([Email])
