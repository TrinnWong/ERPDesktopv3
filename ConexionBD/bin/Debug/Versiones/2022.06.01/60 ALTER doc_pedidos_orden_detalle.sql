IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'CantidadOriginal'
          AND Object_ID = Object_ID(N'doc_pedidos_orden_detalle'))
BEGIN

	
	ALTER TABLE doc_pedidos_orden_detalle
	ADD CantidadOriginal DECIMAL(14,3) NULL

		
END
go
IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'CantidadDevolucion'
          AND Object_ID = Object_ID(N'doc_pedidos_orden_detalle'))
BEGIN

	
	ALTER TABLE doc_pedidos_orden_detalle
	ADD CantidadDevolucion DECIMAL(14,3) NULL

		
END
go