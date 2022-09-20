IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Folio'
          AND Object_ID = Object_ID(N'cat_tipos_pedido'))
BEGIN

	
	ALTER TABLE cat_tipos_pedido
	ADD Folio varchar(10) NULL

END


go