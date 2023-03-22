IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'SucursalBaseId'
          AND Object_ID = Object_ID(N'cat_clientes'))
BEGIN  
	
	alter table cat_clientes
	add SucursalBaseId int 
	
	ALTER TABLE cat_clientes
	ADD CONSTRAINT FK_Clientes_Sucursal
	FOREIGN KEY (SucursalBaseId) REFERENCES cat_sucursales(Clave); 

END
go