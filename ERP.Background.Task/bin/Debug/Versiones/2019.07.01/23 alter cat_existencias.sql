IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Apartado'
          AND Object_ID = Object_ID(N'cat_productos_existencias'))
begin

alter table cat_productos_existencias
add Apartado decimal(14,2) null


END

IF not EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Disponible'
          AND Object_ID = Object_ID(N'cat_productos_existencias'))
begin

alter table cat_productos_existencias
add Disponible decimal(14,2) null

END

