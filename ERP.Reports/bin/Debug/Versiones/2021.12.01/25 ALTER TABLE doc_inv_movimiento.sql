

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'TipoMermaId'
          AND Object_ID = Object_ID(N'doc_inv_movimiento'))
BEGIN

	
	ALTER TABLE doc_inv_movimiento
	ADD TipoMermaId smallint NULL

	ALTER TABLE doc_inv_movimiento
	ADD CONSTRAINT FK_doc_inv_movimiento_cat_tipos_merma
	FOREIGN KEY (TipoMermaId) REFERENCES [cat_tipos_mermas]([TipoMermaId]); 

END


go