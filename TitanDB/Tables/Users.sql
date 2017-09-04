CREATE TABLE [dbo].[Users]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
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

CREATE TRIGGER [dbo].[Trigger_NewUsers]
    ON [dbo].[Users]
    FOR INSERT
    AS
    BEGIN
        SET NoCount ON
		UPDATE Users SET CreateDate = GETDATE() FROM inserted WHERE Users.ID = inserted.ID
    END