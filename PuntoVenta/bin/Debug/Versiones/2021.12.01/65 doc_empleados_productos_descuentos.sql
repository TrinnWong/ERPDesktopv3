

IF EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'EmpleadoId'
          AND Object_ID = Object_ID(N'doc_empleados_productos_descuentos'))
BEGIN

	
	ALTER TABLE doc_empleados_productos_descuentos
	ALTER COLUMN EmpleadoId INT NULL


END
go