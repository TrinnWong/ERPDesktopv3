IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'UUID'
          AND Object_ID = Object_ID(N'cat_clientes'))
BEGIN
   
	alter table cat_clientes
	add UUID UNIQUEIDENTIFIER NULL


END
go


IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'KeyClient'
          AND Object_ID = Object_ID(N'cat_clientes'))
BEGIN
   
	alter table cat_clientes
	add KeyClient varchar(50) null
	
END
go


