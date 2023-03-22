IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Activo'
          AND Object_ID = Object_ID(N'doc_cargos'))
BEGIN  
	
	alter table doc_Cargos
	add Activo bit null

END
go
IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'CargoDetalleId'
          AND Object_ID = Object_ID(N'doc_ventas_detalle'))
BEGIN  	
	
	alter table doc_ventas_detalle
	add CargoDetalleId int null

	ALTER TABLE doc_ventas_detalle
	ADD CONSTRAINT FK_Ventas_CargoDetalle
	FOREIGN KEY (CargoDetalleId) REFERENCES doc_cargos_detalle(CargoDetalleId); 

END


go