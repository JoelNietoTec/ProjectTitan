CREATE VIEW [dbo].[TasksEvents]
	AS SELECT ID [id], Title [title], BeginDate [start], ExpirationDate [end], 'blue' [color]  FROM Tasks
UNION ALL
SELECT ID [id], Title [title], StartDate [start], EndDate [end], 'red' [color] FROM Milestones
