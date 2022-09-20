IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Cancelado'
          AND Object_ID = Object_ID(N'doc_pedidos_orden_detalle'))
BEGIN
	alter table [doc_pedidos_orden_detalle]
	add Cancelado bit null

END
go


