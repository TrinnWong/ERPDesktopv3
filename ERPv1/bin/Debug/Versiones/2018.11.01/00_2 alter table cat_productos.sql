
IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'Especificaciones'
          AND Object_ID = Object_ID('cat_productos'))
BEGIN
	alter table cat_productos
	add Especificaciones varchar(500) null

END
go


