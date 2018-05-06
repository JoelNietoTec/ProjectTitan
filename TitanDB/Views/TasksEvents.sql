CREATE VIEW [dbo].[TasksEvents]
	AS SELECT ROW_NUMBER() OVER(ORDER BY taskid) id, *
FROM (
SELECT ID [taskid], 1 [categoryid], Title [title], BeginDate [start], ExpirationDate [end],  'blue' [color]  FROM Tasks
UNION ALL
SELECT ID [taskid], 2 [categoryid], Title [title], StartDate [start], EndDate [end], 'red' [color] FROM Milestones
) AS X