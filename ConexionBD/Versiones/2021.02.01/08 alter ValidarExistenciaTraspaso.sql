IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'ValidarExistenciaTraspaso'
          AND Object_ID = Object_ID(N'cat_empresas_config_inventario'))
BEGIN

		alter table cat_empresas_config_inventario
		add ValidarExistenciaTraspaso bit null

		
END
go