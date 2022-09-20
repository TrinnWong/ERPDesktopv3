
IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'CargoTipoId'
          AND Object_ID = Object_ID(N'cat_cargos_adicionales'))
BEGIN  
	
	alter table cat_cargos_adicionales
	add CargoTipoId tinyint null

	

	ALTER TABLE cat_cargos_adicionales
	ADD CONSTRAINT FK_cat_cargo_adicional_cargo_tipo
	FOREIGN KEY (CargoTipoId) REFERENCES cat_cargos_tipos(CargoTipoId);

END



go