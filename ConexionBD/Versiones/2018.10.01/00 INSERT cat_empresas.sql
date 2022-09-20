IF NOT EXISTS (
	SELECT 1
	FROM cat_empresas
)
BEGIN
INSERT INTO cat_empresas(Clave,Nombre,Estatus)
VALUES(1,'MI EMPRESA',1)
END
GO

IF NOT EXISTS (
	SELECT 1
	FROM cat_sucursales
)
BEGIN
	INSERT INTO cat_sucursales(Clave,Empresa,NombreSucursal,Estatus)
	VALUES(1,1,'SUCURSAL 01',1)
END
GO