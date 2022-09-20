IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Impreso'
          AND Object_ID = Object_ID(N'doc_pedidos_orden_detalle'))
BEGIN
   alter table [dbo].doc_pedidos_orden_detalle
	add Impreso bit null

END
go


IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'ComandaId'
          AND Object_ID = Object_ID(N'doc_pedidos_orden_detalle'))
BEGIN
	alter table [dbo].doc_pedidos_orden_detalle
	add ComandaId int null

	ALTER TABLE doc_pedidos_orden_detalle
	ADD CONSTRAINT FK_doc_pedidos_orden_detalle_cat_rest_comandas
	FOREIGN KEY (ComandaId) REFERENCES cat_rest_comandas(ComandaId)

END
go