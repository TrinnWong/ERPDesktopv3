IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'CargoId'
          AND Object_ID = Object_ID(N'doc_pedidos_orden'))
BEGIN

		alter table [doc_pedidos_orden]
		add CargoId int null
		

		ALTER TABLE doc_pedidos_orden
		ADD CONSTRAINT FK_doc_pedidos_orden_doc_cargos
		FOREIGN KEY (CargoId) REFERENCES doc_cargos(CargoId) 
		
END
go