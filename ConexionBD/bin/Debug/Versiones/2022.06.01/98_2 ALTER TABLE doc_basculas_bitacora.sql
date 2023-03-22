
IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'VentaId'
          AND Object_ID = Object_ID(N'doc_basculas_bitacora'))
BEGIN	

	ALTER TABLE doc_basculas_bitacora
	ADD VentaId BIGINT NULL

	ALTER TABLE doc_basculas_bitacora
	ADD CONSTRAINT FK_doc_basculas_bitacora_doc_ventas
	FOREIGN KEY (VentaId) REFERENCES doc_ventas(VentaId);
		
END
go