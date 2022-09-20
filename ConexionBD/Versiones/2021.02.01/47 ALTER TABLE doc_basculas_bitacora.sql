
IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'ProductoId'
          AND Object_ID = Object_ID(N'doc_basculas_bitacora'))
BEGIN

		
	alter table  [dbo].[doc_basculas_bitacora]
	ADD ProductoId INT null
	

	ALTER TABLE doc_basculas_bitacora
	ADD CONSTRAINT FK_doc_basculas_bitacora_cat_productos
	FOREIGN KEY (ProductoId) REFERENCES cat_productos(ProductoId);


		
END
go