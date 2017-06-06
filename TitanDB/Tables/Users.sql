CREATE TABLE [dbo].[Users]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserName] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(50) NOT NULL, 
    [FullName] NVARCHAR(100) NOT NULL
)

GO

CREATE UNIQUE INDEX [IX_Users_Username] ON [dbo].[Users] ([UserName])
