IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Credito'
          AND Object_ID = Object_ID(N'doc_pedidos_orden'))
BEGIN

	
	ALTER TABLE doc_pedidos_orden
	ADD Credito BIT NULL

		
END
go

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Credito'
          AND Object_ID = Object_ID(N'doc_basculas_bitacora'))
BEGIN

	
	ALTER TABLE doc_basculas_bitacora
	ADD Credito BIT NULL

		
END
go