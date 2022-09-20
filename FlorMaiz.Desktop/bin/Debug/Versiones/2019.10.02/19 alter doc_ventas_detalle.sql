IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'TipoDescuentoId'
          AND Object_ID = Object_ID(N'doc_ventas_detalle'))
BEGIN
   alter table doc_ventas_detalle
	add TipoDescuentoId tinyint null

		
	ALTER TABLE doc_ventas_detalle
	ADD CONSTRAINT FK_doc_ventas_detalle_Tipo_Descuento
	FOREIGN KEY (TipoDescuentoId) REFERENCES cat_tipos_descuento(TipoDescuentoId)

	

END
go