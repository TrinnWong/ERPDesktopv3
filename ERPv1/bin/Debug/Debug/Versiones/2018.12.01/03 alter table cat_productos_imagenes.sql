

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'Principal'
          AND Object_ID = Object_ID('cat_productos_imagenes'))
BEGIN
	alter table cat_productos_imagenes
	add Principal bit null
END
go

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'Miniatura'
          AND Object_ID = Object_ID('cat_productos_imagenes'))
BEGIN
	alter table cat_productos_imagenes
	add Miniatura bit null
END
go
