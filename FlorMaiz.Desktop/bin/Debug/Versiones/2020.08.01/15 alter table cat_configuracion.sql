
IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'MontoRecargoDiario'
          AND Object_ID = Object_ID(N'cat_configuracion'))
BEGIN  
	
	alter table cat_configuracion
	add MontoRecargoDiario money null

	

END
go


IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Descuento'
          AND Object_ID = Object_ID(N'doc_cargos'))
BEGIN  
	
	alter table doc_cargos
	add Descuento money null	

END
go


IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Descuento'
          AND Object_ID = Object_ID(N'doc_cargos_detalle'))
BEGIN  
	
	alter table doc_cargos_detalle
	add Descuento money null	

END
go

