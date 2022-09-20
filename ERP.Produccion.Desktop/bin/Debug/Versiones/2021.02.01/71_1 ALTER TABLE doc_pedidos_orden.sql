IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'TipoPedidoId'
          AND Object_ID = Object_ID(N'doc_pedidos_orden'))
BEGIN


	
	alter table  [dbo].doc_pedidos_orden
	ADD TipoPedidoId int null
	
	alter table  [dbo].doc_pedidos_orden
	ADD Folio varchar(20)

	ALTER TABLE doc_pedidos_orden
	ADD CONSTRAINT FK_doc_pedidos_orden_cat_tipos_pedido
	FOREIGN KEY (TipoPedidoId) REFERENCES cat_tipos_pedido(TipoPedidoId);

		
END
go