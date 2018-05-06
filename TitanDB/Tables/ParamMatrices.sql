CREATE TABLE [dbo].[ParamMatrices]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(100) NOT NULL, 
    [Code] NVARCHAR(50) NOT NULL, 
    [Description] NTEXT NULL, 
    [CreateDate] DATETIME NULL, 
    [ModificateDate] DATETIME NULL, 
    [MatrixTypeID] INT NOT NULL, 
    CONSTRAINT [FK_ParamMatrices_ToMatrixTypes] FOREIGN KEY ([MatrixTypeID]) REFERENCES [MatrixTypes]([ID])
)

GO

CREATE UNIQUE INDEX [IX_ParamMatrices_Code] ON [dbo].[ParamMatrices] ([Code])
