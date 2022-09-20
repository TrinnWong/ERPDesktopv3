IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Detalle'
          AND Object_ID = Object_ID(N'doc_basculas_bitacora'))
BEGIN

	
	ALTER TABLE doc_basculas_bitacora
	ADD Detalle varchar(500) NULL

		
END
go