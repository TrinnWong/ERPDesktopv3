
IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Facturar'
          AND Object_ID = Object_ID(N'doc_pedidos_orden'))
BEGIN

	
	ALTER TABLE doc_pedidos_orden
	ADD Facturar BIT NULL

END
go

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Facturar'
          AND Object_ID = Object_ID(N'doc_ventas'))
BEGIN

	
	ALTER TABLE doc_ventas
	ADD Facturar BIT NULL

END
go