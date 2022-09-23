IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'CostoCapturaUsuario'
          AND Object_ID = Object_ID(N'cat_productos_existencias'))
BEGIN

	
	ALTER TABLE cat_productos_existencias
	ADD CostoCapturaUsuario decimal NULL

		
END
go