CREATE TABLE [dbo].[ParticipantMatrices]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ParticipantID] INT NOT NULL, 
    [ParamMatrixID] INT NOT NULL, 
    [Active] INT NULL, 
    [Score] NUMERIC(5, 2) NULL
)
