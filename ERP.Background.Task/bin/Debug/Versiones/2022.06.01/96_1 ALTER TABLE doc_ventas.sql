IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'EmpleadoId'
          AND Object_ID = Object_ID(N'doc_ventas'))
BEGIN	
	
		ALTER TABLE doc_ventas
		Add EmpleadoId INT NULL		

		ALTER TABLE doc_ventas
		ADD CONSTRAINT FK_doc_ventas_rh_empleados
		FOREIGN KEY (EmpleadoId) REFERENCES rh_empleados(NumEmpleado);
		
END
go