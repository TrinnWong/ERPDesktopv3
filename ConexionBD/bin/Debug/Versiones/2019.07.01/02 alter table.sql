IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'SolicitarComanda'
          AND Object_ID = Object_ID(N'cat_configuracion'))
BEGIN
   alter table [dbo].cat_configuracion
	add SolicitarComanda bit null

END
go