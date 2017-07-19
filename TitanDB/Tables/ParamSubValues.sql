CREATE TABLE [dbo].[ParamSubValues]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ParamValueID] INT NOT NULL, 
    [DisplayValue] NVARCHAR(200) NULL, 
    [EnglishDisplayValue] NVARCHAR(200) NULL, 
    [Score] NUMERIC(10, 2) NULL, 
    CONSTRAINT [FK_ParamSubValues_ToParamValue] FOREIGN KEY ([ParamValueID]) REFERENCES [ParamValues]([ID]) 
)

GO
