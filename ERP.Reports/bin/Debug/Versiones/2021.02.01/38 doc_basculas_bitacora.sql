IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'TipoBasculaBitacoraId'
          AND Object_ID = Object_ID(N'doc_basculas_bitacora'))
BEGIN
	

	alter table doc_basculas_bitacora
	add TipoBasculaBitacoraId int  NULL


	ALTER TABLE doc_basculas_bitacora
	ADD CONSTRAINT FK_doc_basculas_bitacora_cat_tipos_bascula_bitacora
	FOREIGN KEY (TipoBasculaBitacoraId) REFERENCES cat_tipos_bascula_bitacora(TipoBasculaBitacoraId); 
		
END
go