CREATE TABLE [dbo].[ParticipantContacts]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
	[Correlative] INT NOT NULL,
	[ParticipantID] INT NOT NULL,
    [Name] NVARCHAR(50) NOT NULL, 
    [Phone] NVARCHAR(50) NULL, 
    [Email] NVARCHAR(50) NULL, 
    [MobilePhone] NVARCHAR(50) NULL, 
    [Fax] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_ParticipantContacts_ToParticipants] FOREIGN KEY ([ParticipantID]) REFERENCES [Participants]([ID]) 
)
