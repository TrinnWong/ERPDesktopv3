
IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'UberEats'
          AND Object_ID = Object_ID(N'doc_pedidos_orden'))
BEGIN  
	
	alter table doc_pedidos_orden
	add UberEats bit null

END


IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'CargoAdicionalId'
          AND Object_ID = Object_ID(N'doc_pedidos_orden_detalle'))
BEGIN  
	
	alter table doc_pedidos_orden_detalle
	add CargoAdicionalId smallint null

END