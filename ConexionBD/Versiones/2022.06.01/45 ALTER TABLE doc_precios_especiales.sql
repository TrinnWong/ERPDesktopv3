IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'SucursalId'
          AND Object_ID = Object_ID(N'doc_precios_especiales'))
BEGIN

	
	ALTER TABLE doc_precios_especiales
	ADD SucursalId INT NULL

	ALTER TABLE doc_precios_especiales
	ADD CONSTRAINT FK_doc_precios_especiales_cat_sucursales
	FOREIGN KEY (SucursalId) REFERENCES cat_sucursales(Clave)
		
END
go