IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'Talla'
          AND Object_ID = Object_ID('cat_productos'))
BEGIN
   alter table cat_productos
	add Talla varchar(5) null
END

IF  NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'ParaSexo'
          AND Object_ID = Object_ID('cat_productos'))
BEGIN
  alter table cat_productos
add ParaSexo varchar(1) null
END

IF  NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'Color'
          AND Object_ID = Object_ID('cat_productos'))
BEGIN
  alter table cat_productos
add Color varchar(10) null
END

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'Color2'
          AND Object_ID = Object_ID('cat_productos'))
BEGIN
	alter table cat_productos
	add Color2 varchar(10) null
END

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'SobrePedido'
          AND Object_ID = Object_ID('cat_productos'))
BEGIN
	alter table cat_productos
	add SobrePedido varchar(10) null
END

GO