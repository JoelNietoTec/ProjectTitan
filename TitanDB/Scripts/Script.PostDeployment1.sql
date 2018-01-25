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

IF NOT EXISTS (SELECT 1 FROM dbo.Recurrence)
BEGIN
	INSERT INTO Recurrence (Name, EnglishName)
	SELECT N'Diario', N'Daily'

	INSERT INTO Recurrence (Name, EnglishName)
	SELECT N'Semanal', N'Weekly'

	INSERT INTO Recurrence (Name, EnglishName)
	SELECT N'Quincenal', N'Biweekly'

	INSERT INTO Recurrence (Name, EnglishName)
	SELECT N'Mensual', N'Monthly'

	INSERT INTO Recurrence (Name, EnglishName)
	SELECT N'Trimensual', N'Quarter'

	INSERT INTO Recurrence (Name, EnglishName)
	SELECT N'Semestral', N'BiAnnual'

	INSERT INTO Recurrence (Name, EnglishName)
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