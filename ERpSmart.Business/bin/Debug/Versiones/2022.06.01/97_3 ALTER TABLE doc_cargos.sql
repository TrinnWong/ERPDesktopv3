IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'SucursalId'
          AND Object_ID = Object_ID(N'doc_cargos'))
BEGIN	
	
		ALTER TABLE doc_cargos
		ADD SucursalId INT NULL

		ALTER TABLE doc_cargos
		ADD CONSTRAINT FK_doc_Cargos_cat_sucursales
		FOREIGN KEY (SucursalId) REFERENCES cat_sucursales(Clave);
		
END
go