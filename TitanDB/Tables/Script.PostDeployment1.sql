﻿/*
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
	INSERT INTO dbo.ParamTables (Name, EnglishName)
	SELECT N'Simple', N'Simple'

	INSERT INTO dbo.ParamTables (Name, EnglishName)
	SELECT N'Compuesto', N'Complex'
END

GO
