
IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'DejarEnCero'
          AND Object_ID = Object_ID(N'doc_productos_sobrantes_config'))
BEGIN

	
	
		ALTER TABLE doc_productos_sobrantes_config
		Add DejarEnCero BIT NULL		
		
END
go
