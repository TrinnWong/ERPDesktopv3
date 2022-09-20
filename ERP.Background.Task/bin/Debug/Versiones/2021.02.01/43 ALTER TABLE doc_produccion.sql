
IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'ProductoId'
          AND Object_ID = Object_ID(N'doc_produccion'))
BEGIN

		
	alter table  doc_produccion
	ADD ProductoId INT null
	

	ALTER TABLE doc_produccion
	ADD CONSTRAINT FK_doc_produccion_cat_productos
	FOREIGN KEY (ProductoId) REFERENCES cat_productos(ProductoId);


		
END
go
