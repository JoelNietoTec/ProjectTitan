CREATE TABLE [dbo].[ParamMatrices]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(100) NOT NULL, 
    [Code] NVARCHAR(50) NOT NULL, 
    [Description] NTEXT NULL, 
    [CreateDate] DATE NULL, 
    [ModificateDate] DATE NULL, 
    [MatrixTypeID] INT NOT NULL, 
    CONSTRAINT [FK_ParamMatrices_ToMatrixTypes] FOREIGN KEY ([MatrixTypeID]) REFERENCES [MatrixTypes]([ID])
)
