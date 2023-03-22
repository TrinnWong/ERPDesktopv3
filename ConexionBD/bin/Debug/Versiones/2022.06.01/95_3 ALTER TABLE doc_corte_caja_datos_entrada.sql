IF NOT  EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'MaizKg'
          AND Object_ID = Object_ID(N'doc_corte_caja_datos_entrada'))
BEGIN

	
	
		ALTER TABLE doc_corte_caja_datos_entrada
		ADD MaizKg DECIMAL(14,3) NULL	
		
END
go


IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'ModificadoEl'
          AND Object_ID = Object_ID(N'doc_corte_caja_datos_entrada'))
BEGIN

	
	
		ALTER TABLE doc_corte_caja_datos_entrada
		ADD ModificadoEl DATETIME NULL	
		
END
go



IF NOT  EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'ModificadoPor'
          AND Object_ID = Object_ID(N'doc_corte_caja_datos_entrada'))
BEGIN

	
	
		ALTER TABLE doc_corte_caja_datos_entrada
		ADD ModificadoPor INT NULL	
		
END
go

