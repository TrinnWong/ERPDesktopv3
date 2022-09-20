IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'ValorRango1_1'
          AND Object_ID = Object_ID(N'doc_produccion_conceptos'))
BEGIN

	
	ALTER TABLE doc_produccion_conceptos
	ADD ValorRango1_1 float NULL


END
go

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'ValorRango1_2'
          AND Object_ID = Object_ID(N'doc_produccion_conceptos'))
BEGIN

	
	ALTER TABLE doc_produccion_conceptos
	ADD ValorRango1_2 float NULL


END
go