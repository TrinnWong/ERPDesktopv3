IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'SucursalId'
          AND Object_ID = Object_ID(N'cat_equipos_computo'))
BEGIN	
	
		ALTER TABLE cat_equipos_computo
		Add SucursalId INT NULL		

		ALTER TABLE cat_equipos_computo
		ADD CONSTRAINT FK_cat_equipos_computo_cat_sucursales
		FOREIGN KEY (SucursalId) REFERENCES cat_sucursales(Clave);
		
END
go