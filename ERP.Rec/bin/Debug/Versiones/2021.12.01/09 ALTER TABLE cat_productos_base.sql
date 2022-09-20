IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'ParaCocina'
          AND Object_ID = Object_ID(N'cat_productos_base'))
BEGIN

	
	ALTER TABLE cat_productos_base
	ADD ParaCocina BIT NULL


		
END
go