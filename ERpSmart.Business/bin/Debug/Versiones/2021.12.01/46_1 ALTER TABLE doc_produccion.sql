IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'ProduccionSolicitudId'
          AND Object_ID = Object_ID(N'doc_produccion'))
BEGIN

	
	ALTER TABLE doc_produccion
	ADD ProduccionSolicitudId INT NULL

	ALTER TABLE doc_produccion
	ADD CONSTRAINT FK_doc_produccion_doc_produccion_solicitud
	FOREIGN KEY (ProduccionSolicitudId) REFERENCES [doc_produccion_solicitud](ProduccionSolicitudId); 


END
go