IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = 'Giro'
          AND Object_ID = Object_ID('cat_configuracion'))
BEGIN
	alter table cat_configuracion
add Giro varchar(10) null



END
go



update cat_configuracion
set Giro = CASE WHEN Giro IS NULL THEN  'AUTOLAV' ELSE Giro End
GO