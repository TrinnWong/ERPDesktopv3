IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Flete'
          AND Object_ID = Object_ID(N'doc_productos_compra_detalle'))
BEGIN
   
	alter table doc_productos_compra_detalle
	add Flete float null
	
END
go

IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Comisiones'
          AND Object_ID = Object_ID(N'doc_productos_compra_detalle'))
BEGIN
   
	alter table doc_productos_compra_detalle
	add Comisiones float null
	
END
go

IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Flete'
          AND Object_ID = Object_ID(N'doc_inv_movimiento_detalle'))
BEGIN
   
	alter table doc_inv_movimiento_detalle
	add Flete float null
	
END
go

IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Comisiones'
          AND Object_ID = Object_ID(N'doc_inv_movimiento_detalle'))
BEGIN
   
	alter table doc_inv_movimiento_detalle
	add Comisiones float null
	
END
go
