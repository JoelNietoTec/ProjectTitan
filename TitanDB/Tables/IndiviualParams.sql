CREATE TABLE [dbo].[IndiviualParams]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IndividualID] INT NOT NULL,
	[ParamCategoryID] INT NOT NULL,
    [ParamMasterID] INT NOT NULL, 
    [ParamValueID] INT NOT NULL
)

GO


CREATE UNIQUE INDEX [IX_IndiviualParams] ON [dbo].[IndiviualParams] ([IndividualID], [ParamMasterID])
