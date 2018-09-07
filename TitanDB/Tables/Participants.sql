CREATE TABLE [dbo].[Participants]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
	[Code] NVARCHAR(50),
    [FirstName] NVARCHAR(200) NULL, 
    [SecondName] NVARCHAR(100) NULL, 
    [ThirdName] NVARCHAR(100) NULL, 
    [FourthName] NVARCHAR(100) NULL, 
    [GenderID] INT NOT NULL DEFAULT 1, 
    [BirthDate] DATETIME NULL, 
    [Email] VARCHAR(100) NULL, 
    [ParticipantTypeID] INT NOT NULL DEFAULT 1, 
    [Address] NVARCHAR(2000) NULL, 
    [WebSite] NVARCHAR(100) NULL, 
    [LegalRepresentative] NVARCHAR(100) NULL, 
    [Phone] NVARCHAR(50) NULL, 
    [MobilePhone] NVARCHAR(50) NULL, 
    [ParamMatrixID] INT NULL, 
    [Score] NUMERIC(5, 3) NULL, 
    [Rate] NVARCHAR(50) NULL, 
	[CreateDate] DATETIME NULL,
	[CreatedUserID] INT DEFAULT 1,
    [PurposeID] INT NULL DEFAULT 1, 
    [PEP] BIT NULL , 
    [MatrixReady] BIT NULL, 
    [CountryID] INT NOT NULL DEFAULT 165, 
    [Status] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [FK_Participants_ToType] FOREIGN KEY ([ParticipantTypeID]) REFERENCES [ParticipantTypes]([ID]), 
    CONSTRAINT [FK_Participants_ToGenders] FOREIGN KEY ([GenderID]) REFERENCES [Genders]([ID]) ,
	CONSTRAINT [FK_Participants_ToUsers] FOREIGN KEY ([CreatedUserID]) REFERENCES [Users]([ID]) 
)

GO

CREATE TRIGGER [dbo].[Trigger_Participants]
    ON [dbo].[Participants]
    FOR INSERT
    AS
    BEGIN
        SET NoCount ON

		INSERT INTO dbo.ParticipantParams (ParticipantID, ParamMatrixID, ParamCategoryID, ParamID, ParamValueID, ParamSubValueID)
		SELECT ins.ID, PM.ID ParamMatrixID, PC.ID ParamCategoryID, PR.ID ParamID, 0 ParamValueID, 0 ParamSubValueID
		FROM inserted ins
		INNER JOIN dbo.ParamMatrices PM ON ins.ParticipantTypeID = PM.MatrixTypeID
		INNER JOIN dbo.ParamCategories PC ON PC.ParamMatrixID = PM.ID
		INNER JOIN dbo.Params PR ON PR.ParamCategoryID = PC.ID;

		INSERT INTO ParticipantProfiles 
		SELECT ID, 0, GETDATE(), 0, 0, 0 FROM inserted
		
    END
GO


CREATE TRIGGER [dbo].[Trigger_PEP]
    ON [dbo].[Participants]
    AFTER UPDATE
    AS
    BEGIN
        SET NoCount ON
		DECLARE @ID INT
		SELECT @ID = inserted.ID FROM inserted
		EXEC GetParticipantScore @ID
    END
GO

CREATE TRIGGER [dbo].[Trigger_Tasks]
    ON [dbo].[Participants]
    FOR INSERT
    AS
    BEGIN
        SET NoCount ON
		INSERT INTO [Tasks] (ParticipantID, CategoryID, ProjectID, Title, StatusID, CreatedDate, CreatedBy)
		SELECT inserted.ID, 2, 1, PendingDocuments.Name, 1, GETDATE(), inserted.[CreatedUserID]
		FROM [PendingDocuments] INNER JOIN inserted ON PendingDocuments.ParticipantID = inserted.ID
		WHERE PendingDocuments.Uploaded = 0
    END