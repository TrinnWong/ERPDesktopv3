IF EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'ProductoId'
          AND Object_ID = Object_ID(N'doc_cargos'))
BEGIN  
	
	alter table doc_cargos
	alter column ProductoId int null

END
go

IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Descripcion'
          AND Object_ID = Object_ID(N'doc_cargos'))
BEGIN  
	
	alter table doc_cargos
	add Descripcion varchar(250) null

END
go