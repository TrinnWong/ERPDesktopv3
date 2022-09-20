

IF  NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Comentarios'
          AND Object_ID = Object_ID(N'doc_produccion_solicitud_aceptacion'))
BEGIN


	
	ALTER TABLE [dbo].[doc_produccion_solicitud_aceptacion]
	ADD Comentarios varchar(1500) NULL

		
END
go