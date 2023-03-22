IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'FechaCorteExistencia'
          AND Object_ID = Object_ID(N'doc_inv_movimiento'))
BEGIN	

	ALTER TABLE doc_inv_movimiento
	ADD FechaCorteExistencia DATETIME NULL
	
		
END
go