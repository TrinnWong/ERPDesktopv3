IF  EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'CajaId'
          AND Object_ID = Object_ID(N'doc_sesiones_punto_venta'))
BEGIN


	
	alter table  [dbo].doc_sesiones_punto_venta
	ALTER COLUMN CajaId int null
	

		
END
go