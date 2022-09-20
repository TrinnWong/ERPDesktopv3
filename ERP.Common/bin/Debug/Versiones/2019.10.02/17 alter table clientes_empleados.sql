IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'EmpleadoId'
          AND Object_ID = Object_ID(N'cat_clientes'))
BEGIN
	
	alter table cat_clientes
	add EmpleadoId int null
	

	ALTER TABLE cat_clientes
	ADD CONSTRAINT FK_Clientes_Empleados
	FOREIGN KEY (EmpleadoId) REFERENCES rh_empleados(NumEmpleado)

END

	
