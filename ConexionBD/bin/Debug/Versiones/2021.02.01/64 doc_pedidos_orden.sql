IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'CajaId'
          AND Object_ID = Object_ID(N'doc_pedidos_orden'))
BEGIN


	
	alter table  [dbo].doc_pedidos_orden
	ADD CajaId int null
	

	ALTER TABLE doc_pedidos_orden
	ADD CONSTRAINT FK_doc_pedidos_orden_cat_cajas
	FOREIGN KEY (CajaId) REFERENCES cat_cajas(Clave);

		
END
go