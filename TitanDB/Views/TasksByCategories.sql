CREATE VIEW [dbo].[TasksByCategories]
	AS SELECT [Tasks].CategoryID, [TaskCategories].Name Category, [Tasks].StatusID, [TaskStatus].Name Status, COUNT(*) Count 
	FROM 
	[Tasks]
	INNER JOIN [TaskStatus] ON [Tasks].StatusID = [TaskStatus].ID
	INNER JOIN [TaskCategories] ON [TaskCategories].ID = [Tasks].CategoryID
	GROUP BY 
	[Tasks].CategoryID, [TaskCategories].Name, [Tasks].StatusID, [TaskStatus].Name 