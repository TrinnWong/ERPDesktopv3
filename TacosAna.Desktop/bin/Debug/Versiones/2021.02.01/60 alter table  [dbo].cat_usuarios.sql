IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'CajaDefaultId'
          AND Object_ID = Object_ID(N'cat_usuarios'))
BEGIN


	
	alter table  [dbo].cat_usuarios
	ADD CajaDefaultId int null
	

	ALTER TABLE cat_usuarios
	ADD CONSTRAINT FK_cat_usuarios_cat_cajas
	FOREIGN KEY (CajaDefaultId) REFERENCES cat_cajas(Clave);

		
END
go