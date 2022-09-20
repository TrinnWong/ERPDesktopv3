IF  NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Enviada'
          AND Object_ID = Object_ID(N'doc_produccion_solicitud'))
BEGIN


	
	alter table  [dbo].doc_produccion_solicitud
	ADD Enviada BIT null
	

		
END
go


IF  NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Iniciada'
          AND Object_ID = Object_ID(N'doc_produccion_solicitud'))
BEGIN


	
	alter table  [dbo].doc_produccion_solicitud
	ADD Iniciada BIT null

	alter table  [dbo].doc_produccion_solicitud
	ADD FechaInicioEjecucion DateTime null

	alter table  [dbo].doc_produccion_solicitud
	ADD FechaFinEjecucion DateTime null
	

		
END
go