IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'CargoAdicionalMonto'
          AND Object_ID = Object_ID(N'doc_pedidos_orden_detalle'))
BEGIN

	
	ALTER TABLE doc_pedidos_orden_detalle
	ADD CargoAdicionalMonto MONEY NULL

		
END
go