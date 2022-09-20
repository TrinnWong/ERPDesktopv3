IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Descripcion'
          AND Object_ID = Object_ID(N'doc_ventas_detalle'))
BEGIN  

	alter table doc_ventas_detalle
	add Descripcion varchar(60) null

end