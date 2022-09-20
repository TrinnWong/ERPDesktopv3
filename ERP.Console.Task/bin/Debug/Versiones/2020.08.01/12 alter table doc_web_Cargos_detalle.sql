
IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'CargoDetalleId'
          AND Object_ID = Object_ID(N'doc_web_carrito_detalle'))
BEGIN  
	

	alter table doc_web_carrito_detalle
	add CargoDetalleId int null

	ALTER TABLE doc_web_carrito_detalle
	ADD CONSTRAINT FK_Carrito_Cargo_Detalle
	FOREIGN KEY (CargoDetalleId) REFERENCES doc_cargos_detalle(CargoDetalleId); 

END
go
