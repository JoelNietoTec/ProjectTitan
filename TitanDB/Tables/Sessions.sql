CREATE TABLE [dbo].[Sessions]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserID] INT NOT NULL, 
    [SessionID] NVARCHAR(20) NOT NULL UNIQUE, 
    [LoginTime] DATETIME NULL, 
    [LogoutTime] DATETIME NULL, 
    [IP] NVARCHAR(100) NULL, 
    [Browser] NVARCHAR(200) NULL
)

GO

CREATE UNIQUE INDEX [IX_Sessions_Users] ON [dbo].[Sessions] ([UserID], [SessionID])
