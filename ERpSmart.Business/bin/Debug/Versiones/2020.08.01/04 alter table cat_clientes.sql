IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Clave'
          AND Object_ID = Object_ID(N'cat_clientes'))
BEGIN
   
	alter table cat_clientes
	add Clave varchar(20) null
	
END
go
