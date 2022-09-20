IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Descripcion'
          AND Object_ID = Object_ID(N'doc_pedidos_orden_detalle'))
BEGIN  
	
	alter table doc_pedidos_orden_detalle
	add Descripcion varchar(500) null


END


IF  EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Descripcion'
          AND Object_ID = Object_ID(N'doc_ventas_detalle'))
BEGIN  

	alter table doc_ventas_detalle
	alter column Descripcion varchar(500) null

end