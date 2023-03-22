IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'ProduccionId'
          AND Object_ID = Object_ID(N'doc_produccion_solicitud'))
BEGIN

	
	ALTER TABLE doc_produccion_solicitud
	ADD ProduccionId INT NULL

	ALTER TABLE doc_produccion_solicitud
	ADD CONSTRAINT FK_doc_produccion_solicitud_doc_produccion
	FOREIGN KEY (ProduccionId) REFERENCES [doc_produccion](ProduccionId); 


END
go