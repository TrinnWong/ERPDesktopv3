
IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'PesoDefault'
          AND Object_ID = Object_ID(N'cat_basculas_configuracion'))
BEGIN

		
	alter table  cat_basculas_configuracion
	ADD PesoDefault decimal(10,4) null

		
END
go
