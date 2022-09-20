
IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'CargoAdicionalId'
          AND Object_ID = Object_ID(N'doc_ventas_detalle'))
BEGIN  
	
	alter table doc_ventas_detalle
	add CargoAdicionalId smallint null

	ALTER TABLE doc_ventas_detalle
	ADD CONSTRAINT FK_doc_ventas_detalle_cat_cargos_Adicionales
	FOREIGN KEY (CargoAdicionalId) REFERENCES cat_cargos_Adicionales(CargoAdicionalId);


END