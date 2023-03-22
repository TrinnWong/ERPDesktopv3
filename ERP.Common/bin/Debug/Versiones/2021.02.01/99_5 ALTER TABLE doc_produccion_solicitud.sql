
IF  NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Aceptada'
          AND Object_ID = Object_ID(N'doc_produccion_solicitud'))
BEGIN


	
	alter table  [dbo].doc_produccion_solicitud
	ADD Aceptada BIT null	

		
END
go