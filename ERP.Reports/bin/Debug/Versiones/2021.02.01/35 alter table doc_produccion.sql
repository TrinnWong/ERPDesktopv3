IF  EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'FechaHoraFin'
          AND Object_ID = Object_ID(N'doc_produccion'))
BEGIN

		
	alter table  doc_produccion
	alter column FechaHoraFin DateTime null

		
END
go

