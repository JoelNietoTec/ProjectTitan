CREATE TABLE [dbo].[Notifications]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [NotificationTypeID] INT NOT NULL, 
    [Description] NVARCHAR(100) NULL, 
    [Date] DATETIME NULL, 
    [ElementID] INT NULL
)
