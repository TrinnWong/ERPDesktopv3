IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'SucursalId'
          AND Object_ID = Object_ID(N'cat_basculas_configuracion'))
BEGIN	
	
		ALTER TABLE cat_basculas_configuracion
		Add SucursalId INT NULL		

		ALTER TABLE cat_basculas_configuracion
		ADD CONSTRAINT FK_cat_basculas_configuracion_cat_sucursales
		FOREIGN KEY (SucursalId) REFERENCES cat_sucursales(Clave);
		
END
go