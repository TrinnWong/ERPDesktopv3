IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'PermitirEliminar'
          AND Object_ID = Object_ID(N'rh_puestos'))
BEGIN
   alter table rh_puestos
	add PermitirEliminar bit null
END
go

IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Mostrar'
          AND Object_ID = Object_ID(N'rh_puestos'))
BEGIN
   alter table rh_puestos
	add Mostrar bit null
END
go
