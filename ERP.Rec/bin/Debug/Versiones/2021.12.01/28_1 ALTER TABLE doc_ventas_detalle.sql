IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'ParaLlevar'
          AND Object_ID = Object_ID(N'doc_ventas_detalle'))
BEGIN

	
	ALTER TABLE doc_ventas_detalle
	ADD ParaLlevar BIT NULL

END
go

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'ParaMesa'
          AND Object_ID = Object_ID(N'doc_ventas_detalle'))
BEGIN

	
	ALTER TABLE doc_ventas_detalle
	ADD ParaMesa BIT NULL

END


go