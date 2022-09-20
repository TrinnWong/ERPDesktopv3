IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Requerido'
          AND Object_ID = Object_ID(N'cat_productos_base'))
BEGIN

	
	ALTER TABLE cat_productos_base
	ADD Requerido BIT NULL


END
go

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Orden'
          AND Object_ID = Object_ID(N'cat_productos_base'))
BEGIN

	
	ALTER TABLE cat_productos_base
	ADD Orden INT NULL

	
	
END
go


IF  EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Orden'
          AND Object_ID = Object_ID(N'cat_productos_base'))
BEGIN

	
	UPDATE cat_productos_base
	set Orden = 1
END
go