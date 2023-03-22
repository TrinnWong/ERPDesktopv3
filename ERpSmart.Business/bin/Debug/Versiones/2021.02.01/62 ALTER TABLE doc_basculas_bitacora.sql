IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'PedidoDetalleId'
          AND Object_ID = Object_ID(N'doc_basculas_bitacora'))
BEGIN


	alter table  [dbo].doc_basculas_bitacora
	ADD PedidoDetalleId INT null


	ALTER TABLE doc_basculas_bitacora
	ADD CONSTRAINT FK_doc_basculas_bitacora_doc_pedidos_orden_detalle
	FOREIGN KEY (PedidoDetalleId) REFERENCES doc_pedidos_orden_detalle(PedidoDetalleId);

		
END
go