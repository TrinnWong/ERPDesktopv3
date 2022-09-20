

IF EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Descripcion'
          AND Object_ID = Object_ID(N'cat_productos'))
BEGIN  
	
	alter table cat_productos
	alter column Descripcion varchar(500) null


END



IF EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'DescripcionCorta'
          AND Object_ID = Object_ID(N'cat_productos'))
BEGIN  
	
	alter table cat_productos
	alter column DescripcionCorta varchar(250) null


END


IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'CodigoBarras'
          AND Object_ID = Object_ID(N'cat_productos'))
BEGIN  
	
	alter table cat_productos
	ADD CodigoBarras varchar(25) null
	


END
go


IF NOT EXISTS(SELECT 1 FROM sys.indexes 
          WHERE Name = N'IDX_CAT_PRODUCTOS_CODIGO_BARRAS'
          AND Object_ID = Object_ID(N'cat_productos'))
BEGIN  
	
	

	update cat_productos
	set CodigoBarras = cast(productoId as varchar)

	CREATE UNIQUE INDEX IDX_CAT_PRODUCTOS_CODIGO_BARRAS
	ON cat_productos (CodigoBarras); 
	


END
go


