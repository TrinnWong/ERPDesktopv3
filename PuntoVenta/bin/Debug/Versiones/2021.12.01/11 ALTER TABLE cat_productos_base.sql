IF  EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Cantidad'
          AND Object_ID = Object_ID(N'cat_productos_base'))
BEGIN

	
	ALTER TABLE cat_productos_base
	alter column Cantidad decimal(14,4)


		
END
go