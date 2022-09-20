IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'FileByte'
          AND Object_ID = Object_ID('cat_productos_imagenes'))
BEGIN
	alter table cat_productos_imagenes
	add FileByte image null
END
go

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'FileByte'
          AND Object_ID = Object_ID('cat_productos_imagenes'))
BEGIN
	alter table cat_productos_imagenes
	add FileByte image null
END
go