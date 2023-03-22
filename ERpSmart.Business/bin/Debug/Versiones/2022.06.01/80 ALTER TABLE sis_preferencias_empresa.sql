IF  EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Valor'
          AND Object_ID = Object_ID(N'sis_preferencias_empresa'))
BEGIN

	
	
		ALTER TABLE sis_preferencias_empresa
		ALTER COLUMN Valor VARCHAR(1000) NULL	
		
END
go
IF  EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Valor'
          AND Object_ID = Object_ID(N'sis_preferencias_sucursales'))
BEGIN

	
	
		ALTER TABLE sis_preferencias_sucursales
		ALTER COLUMN Valor VARCHAR(1000) NULL	
		
END
go