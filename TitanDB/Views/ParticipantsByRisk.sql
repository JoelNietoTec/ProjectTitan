CREATE VIEW [dbo].[ParticipantsByRisk]
	AS SELECT COUNT(*) Count, CASE WHEN Score IS NULL THEN 'Incomplete' WHEN Score < 3 THEN 'Low' WHEN Score < 6 THEN 'Medium' ELSE 'High' END Rate,
CASE WHEN Score IS NULL THEN 'secondary' WHEN Score < 3 THEN 'success' WHEN Score < 6 THEN 'warning' ELSE 'danger' END ColorType,
CASE WHEN Score IS NULL THEN 'cancel-outline' WHEN Score < 3 THEN 'tick-outline' WHEN Score < 6 THEN 'warning-outline' ELSE 'times-outline' END  Icon,
CASE WHEN Score IS NULL THEN 0 WHEN Score < 3 THEN 1 WHEN Score < 6 THEN 2 ELSE 3 END Sort
FROM Participants
GROUP BY CASE WHEN Score IS NULL THEN 'Incomplete' WHEN Score < 3 THEN 'Low' WHEN Score < 6 THEN 'Medium' ELSE 'High' END,
CASE WHEN Score IS NULL THEN 0 WHEN Score < 3 THEN 1 WHEN Score < 6 THEN 2 ELSE 3 END,
CASE WHEN Score IS NULL THEN 'secondary' WHEN Score < 3 THEN 'success' WHEN Score < 6 THEN 'warning' ELSE 'danger' END,
CASE WHEN Score IS NULL THEN 'cancel-outline' WHEN Score < 3 THEN 'tick-outline' WHEN Score < 6 THEN 'warning-outline' ELSE 'times-outline' END 