IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'PromocionCMId'
          AND Object_ID = Object_ID(N'doc_pedidos_orden_detalle'))
BEGIN	

	alter table doc_pedidos_orden_detalle
	add PromocionCMId int null


	ALTER TABLE doc_pedidos_orden_detalle
	ADD FOREIGN KEY (PromocionCMId) REFERENCES doc_promociones_cm(PromocionCMId);



END
go

IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'PromocionCMId'
          AND Object_ID = Object_ID(N'doc_ventas_detalle'))
BEGIN	

	alter table doc_ventas_detalle
	add PromocionCMId int null


	ALTER TABLE doc_ventas_detalle
	ADD FOREIGN KEY (PromocionCMId) REFERENCES doc_promociones_cm(PromocionCMId);



END
go
