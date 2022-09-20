IF  NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'DepartamentoId'
          AND Object_ID = Object_ID(N'doc_produccion_solicitud'))
BEGIN


	
	alter table  [dbo].doc_produccion_solicitud
	ADD DepartamentoId INT null
	
	ALTER TABLE doc_produccion_solicitud
	ADD CONSTRAINT FK_doc_produccion_solicitud_cat_departamentos
	FOREIGN KEY (DepartamentoId) REFERENCES cat_departamentos(DepartamentoId);
		
END
go