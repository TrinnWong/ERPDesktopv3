IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'SucursalCobroId'
          AND Object_ID = Object_ID(N'doc_pedidos_orden'))
BEGIN

	
	
		ALTER TABLE doc_pedidos_orden
		Add SucursalCobroId INT NULL

		ALTER TABLE doc_pedidos_orden
		ADD FOREIGN KEY (SucursalCobroId) REFERENCES cat_sucursales(Clave)

		
END
go
