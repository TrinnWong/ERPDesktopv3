
IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'pass'
          AND Object_ID = Object_ID(N'cat_clientes'))
BEGIN  
	
	alter table cat_clientes
	add pass varchar(50) null

END
go