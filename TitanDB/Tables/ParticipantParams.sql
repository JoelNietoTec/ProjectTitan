CREATE TABLE [dbo].[ParticipantParams]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ParticipantID] INT NOT NULL,
	[ParamMatrixID] INT NOT NULL,
    [ParamCategoryID] INT NOT NULL,
	[ParamID] INT NOT NULL,
    [ParamValueID] INT NULL,
	[ParamSubValueID] INT NULL,
    [Score] NUMERIC(5, 2) NULL
)

GO
