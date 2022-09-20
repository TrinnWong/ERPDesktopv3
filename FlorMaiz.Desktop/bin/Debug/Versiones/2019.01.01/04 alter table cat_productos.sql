
IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'Liquidacion'
          AND Object_ID = Object_ID('cat_productos'))
BEGIN
	alter table cat_productos
	add Liquidacion bit null
END
go



IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'Liquidacion'
          AND Object_ID = Object_ID('cat_productos_agrupados'))
BEGIN
	alter table cat_productos_agrupados
	add Liquidacion bit null
END
go

