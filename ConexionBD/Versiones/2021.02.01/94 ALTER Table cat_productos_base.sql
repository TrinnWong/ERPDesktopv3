
IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'UnidadCocinaId'
          AND Object_ID = Object_ID(N'cat_productos_base'))
BEGIN

	
	alter table  [dbo].cat_productos_base
	ADD UnidadCocinaId int null
	
	ALTER TABLE cat_productos_base
	ADD CONSTRAINT FK_cat_productos_base_cat_unidadesmed
	FOREIGN KEY (UnidadCocinaId) REFERENCES cat_unidadesmed(Clave); 

		
END
go