IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'TipoDescuentoId'
          AND Object_ID = Object_ID(N'doc_ventas_Detalle'))
BEGIN
   
	alter table doc_ventas_Detalle
	add TipoDescuentoId tinyint NULL

	ALTER TABLE doc_ventas_Detalle
	ADD FOREIGN KEY (TipoDescuentoId) REFERENCES Cat_tipos_descuento(TipoDescuentoId);


END
go

