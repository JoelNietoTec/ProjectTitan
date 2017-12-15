CREATE VIEW [dbo].[ParticipantsByRisk]
	AS SELECT COUNT(*) Count, CASE WHEN Score IS NULL THEN 'No disponible' WHEN Score < 3 THEN 'Bajo' WHEN Score < 6 THEN 'Medio' ELSE 'Alto' END Rate,
CASE WHEN Score IS NULL THEN 'secondary' WHEN Score < 3 THEN 'success' WHEN Score < 6 THEN 'warning' ELSE 'danger' END ColorType,
CASE WHEN Score IS NULL THEN 'cancel-outline' WHEN Score < 3 THEN 'tick-outline' WHEN Score < 6 THEN 'warning-outline' ELSE 'times-outline' END  Icon,
CASE WHEN Score IS NULL THEN 0 WHEN Score < 3 THEN 1 WHEN Score < 6 THEN 2 ELSE 3 END Sort
FROM Participants
GROUP BY CASE WHEN Score IS NULL THEN 'No disponible' WHEN Score < 3 THEN 'Bajo' WHEN Score < 6 THEN 'Medio' ELSE 'Alto' END,
CASE WHEN Score IS NULL THEN 0 WHEN Score < 3 THEN 1 WHEN Score < 6 THEN 2 ELSE 3 END,
CASE WHEN Score IS NULL THEN 'secondary' WHEN Score < 3 THEN 'success' WHEN Score < 6 THEN 'warning' ELSE 'danger' END,
CASE WHEN Score IS NULL THEN 'cancel-outline' WHEN Score < 3 THEN 'tick-outline' WHEN Score < 6 THEN 'warning-outline' ELSE 'times-outline' END 