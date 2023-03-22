IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Orden'
          AND Object_ID = Object_ID(N'cat_productos'))
BEGIN	
	
		ALTER TABLE cat_productos
		Add Orden INT NULL		
		
		
		
END
go

Update cat_productos
		SET Orden = 999
		Where orden is null
		GO