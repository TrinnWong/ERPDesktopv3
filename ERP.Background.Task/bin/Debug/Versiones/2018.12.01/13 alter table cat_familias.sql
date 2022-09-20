
IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'ProductoPortadaId'
          AND Object_ID = Object_ID('cat_familias'))
BEGIN
	alter table cat_familias
	add ProductoPortadaId int null
	
END
go



IF NOT EXISTS (SELECT * 
  FROM sys.foreign_keys 
   WHERE object_id = OBJECT_ID(N'dbo.FK_familias_productos')
   AND parent_object_id = OBJECT_ID(N'dbo.cat_familias')
)
Begin
	ALTER TABLE cat_familias
	ADD CONSTRAINT FK_familias_productos
	FOREIGN KEY (ProductoPortadaId) REFERENCES cat_productos(ProductoId)
	select 1
	
End
go