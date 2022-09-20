
IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'TipoCajaId'
          AND Object_ID = Object_ID(N'cat_cajas'))
BEGIN


	alter table  [dbo].cat_cajas
	ADD TipoCajaId SMALLINT null
	

	ALTER TABLE cat_cajas
	ADD CONSTRAINT FK_cat_cajas_cat_tipos_cajas
	FOREIGN KEY (TipoCajaId) REFERENCES cat_tipos_cajas(TipoCajaId);

		
END
go