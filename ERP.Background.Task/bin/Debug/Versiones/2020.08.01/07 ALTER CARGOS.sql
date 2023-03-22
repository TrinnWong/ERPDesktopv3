IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Saldo'
          AND Object_ID = Object_ID(N'doc_cargos'))
BEGIN  
	
	alter table doc_cargos
	add Saldo money null


END

IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Saldo'
          AND Object_ID = Object_ID(N'doc_cargos_detalle'))
BEGIN  
	
	alter table doc_cargos_detalle
	add Saldo money null


END


