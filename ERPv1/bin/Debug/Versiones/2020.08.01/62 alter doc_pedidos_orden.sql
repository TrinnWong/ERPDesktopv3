IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Notas'
          AND Object_ID = Object_ID(N'doc_pedidos_orden'))
BEGIN  
	
	alter table doc_pedidos_orden
	add Notas varchar(250) null


END