IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Cerrado'
          AND Object_ID = Object_ID(N'doc_productos_sobrantes_registro'))
BEGIN

	
	
		ALTER TABLE doc_productos_sobrantes_registro
		Add Cerrado BIT NULL		
		
END
go

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'CerradoEl'
          AND Object_ID = Object_ID(N'doc_productos_sobrantes_registro'))
BEGIN

	
	
		ALTER TABLE doc_productos_sobrantes_registro
		Add CerradoEl DATETIME NULL		
		
END
go


IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'CerradoPor'
          AND Object_ID = Object_ID(N'doc_productos_sobrantes_registro'))
BEGIN

	
	
		ALTER TABLE doc_productos_sobrantes_registro
		Add CerradoPor INT NULL		

		ALTER TABLE doc_productos_sobrantes_registro
		ADD FOREIGN KEY (CerradoPor) REFERENCES cat_usuarios(IdUsuario); 
		
END
go


IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'CantidadInventario'
          AND Object_ID = Object_ID(N'doc_productos_sobrantes_registro'))
BEGIN	
	
		ALTER TABLE doc_productos_sobrantes_registro
		Add CantidadInventario DECIMAL(14,3) NULL		
		
END
go

