/*
Plantilla de script posterior a la implementación							
--------------------------------------------------------------------------------------
 Este archivo contiene instrucciones de SQL que se anexarán al script de compilación.		
 Use la sintaxis de SQLCMD para incluir un archivo en el script posterior a la implementación.			
 Ejemplo:      :r .\miArchivo.sql								
 Use la sintaxis de SQLCMD para hacer referencia a una variable en el script posterior a la implementación.		
 Ejemplo:      :setvar TableName miTabla							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


IF NOT EXISTS (SELECT 1 FROM dbo.TableTypes)
BEGIN
	INSERT INTO dbo.TableTypes (Name, EnglishName)
	SELECT N'Simple', N'Simple'

	INSERT INTO dbo.TableTypes (Name, EnglishName)
	SELECT N'Compuesto', N'Complex'
END

IF NOT EXISTS (SELECT 1 FROM dbo.Genders)
BEGIN
	INSERT INTO dbo.Genders (Name, EnglishName)
	SELECT N'Femenino', N'Female'

	INSERT INTO dbo.Genders(Name, EnglishName)
	SELECT N'Masculino', N'Male'
END

GO

IF NOT EXISTS (SELECT 1 FROM dbo.ParticipantTypes)
BEGIN
	INSERT INTO dbo.ParticipantTypes (Name, EnglishName)
	SELECT N'Individuo', N'Individual'

	INSERT INTO dbo.ParticipantTypes (Name, EnglishName)
	SELECT N'Entidad', N'Entities'

END

IF NOT EXISTS (SELECT 1 FROM dbo.MatrixTypes)
BEGIN
	INSERT INTO dbo.MatrixTypes (Name, EnglishName)
	SELECT N'Individuo', N'Individual'

	INSERT INTO dbo.MatrixTypes (Name, EnglishName)
	SELECT N'Entidad', N'Entities'

END

IF NOT EXISTS (SELECT 1 FROM dbo.DocumentTypes)
BEGIN
	INSERT INTO DocumentTypes (Name, EnglishName)
	SELECT N'Pasaporte', N'Passport'

	INSERT INTO DocumentTypes (Name, EnglishName)
	SELECT N'Cédula', N'Carnet'

	INSERT INTO DocumentTypes (Name, EnglishName)
	SELECT N'Licencia de conducir', N'Driver''s license'

	INSERT INTO DocumentTypes (Name, EnglishName)
	SELECT N'Declaración de renta', N'Income statement'
END

IF NOT EXISTS (SELECT 1 FROM dbo.TaskStatus)
BEGIN
	INSERT INTO TaskStatus (Name, EnglishName)
	SELECT N'Sin Iniciar', N'To Do'

	INSERT INTO TaskStatus (Name, EnglishName)
	SELECT N'En Progreso', N'Doing'

	INSERT INTO TaskStatus (Name, EnglishName)
	SELECT N'Terminada', N'Done'
END

IF NOT EXISTS (SELECT 1 FROM dbo.Recurrences)
BEGIN
	INSERT INTO Recurrences (Name, EnglishName)
	SELECT N'Diario', N'Daily'

	INSERT INTO Recurrences (Name, EnglishName)
	SELECT N'Semanal', N'Weekly'

	INSERT INTO Recurrences (Name, EnglishName)
	SELECT N'Quincenal', N'Biweekly'

	INSERT INTO Recurrences (Name, EnglishName)
	SELECT N'Mensual', N'Monthly'

	INSERT INTO Recurrences (Name, EnglishName)
	SELECT N'Trimensual', N'Quarter'

	INSERT INTO Recurrences (Name, EnglishName)
	SELECT N'Semestral', N'BiAnnual'

	INSERT INTO Recurrences (Name, EnglishName)
	SELECT N'Anual', N'Annual'
END

IF NOT EXISTS (SELECT 1 FROM dbo.Schedules WHERE Year = YEAR(GETDATE()))
BEGIN 
INSERT INTO Schedules 
SELECT YEAR(GETDATE()), 'Programa de Operativo Anual 2017', 'Programa de Operativo Anual 2017', '20170101', '20171231', 1
END

IF NOT EXISTS (SELECT 1 FROM dbo.TaskCategories)
BEGIN
	INSERT INTO TaskCategories (Name)
	SELECT N'Diarias'

	INSERT INTO TaskCategories (Name)
	SELECT N'Participantes'

	INSERT INTO TaskCategories (Name)
	SELECT N'Cronograma'
END


IF NOT EXISTS (SELECT 1 FROM dbo.BankTypes)
BEGIN
	INSERT INTO BankTypes (Name)
	SELECT N'Local'

	INSERT INTO BankTypes (Name)
	SELECT N'Extranjero'
END

IF NOT EXISTS (SELECT 1 FROM dbo.ProductTypes)
BEGIN
	INSERT INTO ProductTypes(Name, EnglishName)
	SELECT N'Activo', N'Asset'

	INSERT INTO ProductTypes (Name, EnglishName)
	SELECT N'Deuda', N'Debt'
END

IF NOT EXISTS (SELECT 1 FROM dbo.NotificationTypes)
BEGIN
	INSERT INTO dbo.NotificationTypes (Name, URL, Icon)
	SELECT N'Participantes', 'app/participantes', 'fa-users'

	INSERT INTO dbo.NotificationTypes (Name, URL, Icon)
	SELECT N'Tareas', 'app/tareas', 'fa-tasks'
END

IF NOT EXISTS (SELECT 1 FROM dbo.AlertTypes)
BEGIN
	INSERT INTO dbo.AlertTypes (Name)
	SELECT N'Sanción'

	INSERT INTO dbo.AlertTypes (Name)
	SELECT N'Financiero'

END


IF NOT EXISTS (SELECT 1 FROM dbo.TransactionSources)
BEGIN
	INSERT INTO dbo.TransactionSources(Name, EnglishName)
	SELECT N'Efectivo', N'Cash'

	INSERT INTO dbo.TransactionSources(Name, EnglishName)
	SELECT N'Transferencia local', N'Local Transfer'

	INSERT INTO dbo.TransactionSources(Name, EnglishName)
	SELECT N'Transferencia internacional', N'International transfer'

	INSERT INTO dbo.TransactionSources(Name, EnglishName)
	SELECT N'Tarjeta de crédito', N'Credit card'

	INSERT INTO dbo.TransactionSources(Name, EnglishName)
	SELECT N'Cheque local', N'Local check'

	INSERT INTO dbo.TransactionSources(Name, EnglishName)
	SELECT N'Cheque internacional', N'International check'
END

IF NOT EXISTS (SELECT 1 FROM dbo.UserProfiles)
BEGIN
	INSERT INTO dbo.UserProfiles (Name, EnglishName)
	SELECT N'Administrador', N'Administrator'

	INSERT INTO dbo.UserProfiles (Name, EnglishName)
	SELECT N'Usuario', N'User'

	INSERT INTO dbo.UserProfiles (Name, EnglishName)
	SELECT N'Prueba', N'Test'
END

IF NOT EXISTS (SELECT 1 FROM dbo.TransactionTypes)
BEGIN
	INSERT INTO dbo.TransactionTypes (Name, EnglishName)
	SELECT N'Ingreso/Pago', N'Entry/Payment'

	INSERT INTO dbo.TransactionTypes (Name, EnglishName)
	SELECT N'Desembolso', N'Withdrawal'
END

IF NOT EXISTS (SELECT 1 FROM dbo.AlertSources)
BEGIN
	INSERT INTO dbo.AlertSources (Name, EnglishName)
	SELECT N'Presupuesto', N'Budget'

	INSERT INTO dbo.AlertSources (Name, EnglishName)
	SELECT N'Documentos', N'Documents'

	INSERT INTO dbo.AlertSources (Name, EnglishName)
	SELECT N'Sanciones', N'Sanctions'

END

IF NOT EXISTS (SELECT 1 FROM dbo.AlertPriorities)
BEGIN
	INSERT INTO dbo.AlertPriorities (Name, EnglishName)
	SELECT N'Baja', N'Low'

	INSERT INTO dbo.AlertPriorities (Name, EnglishName)
	SELECT N'Media', N'Medium'

	INSERT INTO dbo.AlertPriorities (Name, EnglishName)
	SELECT N'Alta', N'High'
END

IF NOT EXISTS (SELECT 1 FROM dbo.Progress)
BEGIN
	INSERT INTO dbo.Progress (Name, EnglishName)
	SELECT N'Por empezar', N'Not started'

	INSERT INTO dbo.Progress (Name, EnglishName)
	SELECT N'En progreso', N'In progress'

	INSERT INTO dbo.Progress (Name, EnglishName)
	SELECT N'Completado', N'Completed'
END

IF NOT EXISTS (SELECT 1 FROM dbo.AssignmentTypes)
BEGIN
	INSERT INTO dbo.AssignmentTypes (Name, EnglishName)
	SELECT N'General', N'General'

	INSERT INTO dbo.AssignmentTypes (Name, EnglishName)
	SELECT N'Participants', N'Participants'

	INSERT INTO dbo.AssignmentTypes (Name, EnglishName)
	SELECT N'Proyectos', N'Projects'

END

IF NOT EXISTS (SELECT 1 FROM dbo.Stages)
BEGIN
	INSERT INTO Stages (Name, EnglishName)
	SELECT N'Sin Iniciar', N'To Do'

	INSERT INTO Stages (Name, EnglishName)
	SELECT N'En Progreso', N'Doing'

	INSERT INTO Stages (Name, EnglishName)
	SELECT N'Terminada', N'Done'
END