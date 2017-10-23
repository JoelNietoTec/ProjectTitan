CREATE TABLE [dbo].[Participants]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
	[Code] NVARCHAR(50),
    [FirstName] NVARCHAR(200) NULL, 
    [SecondName] NVARCHAR(100) NULL, 
    [ThirdName] NVARCHAR(100) NULL, 
    [FourthName] NVARCHAR(100) NULL, 
    [GenderID] INT NOT NULL DEFAULT 1, 
    [BirthDate] DATE NULL, 
    [Email] VARCHAR(100) NULL, 
    [ParticipantTypeID] INT NOT NULL DEFAULT 1, 
    [Address] NTEXT NULL, 
    [WebSite] NVARCHAR(100) NULL, 
    [LegalRepresentative] NVARCHAR(100) NULL, 
    [Phone] NVARCHAR(50) NULL, 
    [MobilePhone] NVARCHAR(50) NULL, 
    [ParamMatrixID] INT NULL, 
    [Score] NUMERIC(5, 3) NULL, 
    [Rate] NVARCHAR(50) NULL, 
	[CreateDate] DATETIME NULL,
	[CreatedBy] INT DEFAULT 1,
    [PurposeID] INT NULL DEFAULT 1, 
    [PEP] BIT NULL , 
    [MatrixReady] BIT NULL, 
    CONSTRAINT [FK_Participants_ToType] FOREIGN KEY ([ParticipantTypeID]) REFERENCES [ParticipantTypes]([ID]), 
    CONSTRAINT [FK_Participants_ToGenders] FOREIGN KEY ([GenderID]) REFERENCES [Genders]([ID]) ,
	CONSTRAINT [FK_Participants_ToUsers] FOREIGN KEY ([CreatedBy]) REFERENCES [Users]([ID]) 
)

GO

CREATE TRIGGER [dbo].[Trigger_Participants]
    ON [dbo].[Participants]
    FOR INSERT
    AS
    BEGIN
        SET NoCount ON
		UPDATE P 
		SET ParamMatrixID = PM.ID 
		FROM dbo.Participants P 
		INNER JOIN ParamMatrices PM ON P.ParticipantTypeID = PM.MatrixTypeID
		INNER JOIN inserted INS ON INS.ID = P.ID;


		INSERT INTO dbo.ParticipantParams (ParticipantID, ParamMatrixID, ParamCategoryID, ParamID)
		SELECT ins.ID, PM.ID ParamMatrixID, PC.ID ParamCategoryID, PR.ID ParamID
		FROM inserted ins
		INNER JOIN dbo.ParamMatrices PM ON ins.ParticipantTypeID = PM.MatrixTypeID
		INNER JOIN dbo.ParamCategories PC ON PC.ParamMatrixID = PM.ID
		INNER JOIN dbo.Params PR ON PR.ParamCategoryID = PC.ID;

		UPDATE dbo.Participants SET CreateDate = GETDATE() FROM inserted INS INNER JOIN dbo.Participants ON dbo.Participants.ID = INS.ID
		
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