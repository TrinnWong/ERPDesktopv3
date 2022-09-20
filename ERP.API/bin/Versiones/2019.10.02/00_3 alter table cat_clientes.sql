

IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'GiroNegocioId'
          AND Object_ID = Object_ID(N'cat_clientes'))
BEGIN
   
	alter table cat_clientes
	add GiroNegocioId int null


END
go

IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'ApellidoPaterno'
          AND Object_ID = Object_ID(N'cat_clientes'))
BEGIN
   
	alter table cat_clientes
	add ApellidoPaterno varchar(50) null


END
go


IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'ApellidoMaterno'
          AND Object_ID = Object_ID(N'cat_clientes'))
BEGIN
   
	alter table cat_clientes
	add ApellidoMaterno varchar(50) null


END
go