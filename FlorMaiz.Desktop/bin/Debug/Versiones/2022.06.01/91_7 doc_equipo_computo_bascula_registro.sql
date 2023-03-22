IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'SucursalId'
          AND Object_ID = Object_ID(N'doc_equipo_computo_bascula_registro'))
BEGIN

	
	
		ALTER TABLE doc_equipo_computo_bascula_registro
		Add SucursalId INT NULL		

		ALTER TABLE doc_equipo_computo_bascula_registro
		ADD CONSTRAINT FK_doc_equipo_computo_bascula_registro_cat_sucursales
		FOREIGN KEY (SucursalId) REFERENCES cat_sucursales(Clave);
		
END
go