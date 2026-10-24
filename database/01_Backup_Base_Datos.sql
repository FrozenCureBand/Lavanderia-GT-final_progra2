/* ============================================================
   01_Backup_Base_Datos.sql
   Proyecto : Pfinal_labanderia - Programacion II 2026
   Estado   : NO EJECUTADO (plantilla)
   Objetivo : Crear una copia de seguridad completa (.bak) de la
              base de datos antes de cambios importantes.
   ------------------------------------------------------------
   ANTES DE EJECUTAR (solo con autorizacion del estudiante):
   1. Confirmar el nombre real de la base de datos (PENDIENTE).
      App.config apunta hoy a Db_ParqueoAutosUmg: revisar en el documento 02.
   2. La carpeta de destino debe existir EN EL EQUIPO DONDE CORRE
      SQL Server y el servicio de SQL Server debe poder escribir en ella.
   3. Reemplazar los dos valores marcados con <<PENDIENTE...>>.
   ============================================================ */

USE master;
GO

-- Datos que el estudiante debe completar.
DECLARE @NombreBD SYSNAME       = N'<<PENDIENTE_NOMBRE_BD>>';
DECLARE @Carpeta  NVARCHAR(260) = N'<<PENDIENTE_CARPETA>>';   -- Ejemplo: N'C:\Backups\' (terminar en \)
DECLARE @Archivo  NVARCHAR(400);

-- Proteccion: si la plantilla no se completo, se detiene sin hacer nada.
IF @NombreBD LIKE N'<<%' OR @Carpeta LIKE N'<<%'
BEGIN
    RAISERROR(N'Plantilla sin completar: reemplace los valores <<PENDIENTE...>>.', 16, 1);
    RETURN;
END

-- Verifica que la base de datos exista en este servidor.
IF DB_ID(@NombreBD) IS NULL
BEGIN
    RAISERROR(N'La base de datos %s no existe en este servidor.', 16, 1, @NombreBD);
    RETURN;
END

-- Nombre del archivo con fecha y hora: NombreBD_AAAAMMDD_HHMMSS.bak
SET @Archivo = @Carpeta + @NombreBD + N'_'
             + CONVERT(NVARCHAR(8), GETDATE(), 112) + N'_'
             + REPLACE(CONVERT(NVARCHAR(8), GETDATE(), 108), N':', N'')
             + N'.bak';

-- Copia de seguridad completa.
-- INIT     : si el archivo existiera, lo reemplaza.
-- CHECKSUM : comprueba la integridad de las paginas al copiar.
-- STATS=10 : muestra el avance cada 10 %.
BACKUP DATABASE @NombreBD
TO DISK = @Archivo
WITH INIT, CHECKSUM, STATS = 10,
     NAME = N'Backup completo - Pfinal_labanderia';

-- Verifica que el archivo .bak se pueda leer (no restaura nada).
RESTORE VERIFYONLY FROM DISK = @Archivo WITH CHECKSUM;

PRINT N'Backup creado y verificado: ' + @Archivo;
GO
