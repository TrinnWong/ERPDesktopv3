
IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'ImprimirTicketMediaCarta'
          AND Object_ID = Object_ID('cat_configuracion'))
BEGIN
	alter table cat_configuracion
	add ImprimirTicketMediaCarta bit null
	
	
END
go
