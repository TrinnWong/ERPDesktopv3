
IF NOT EXISTS (
	SELECT 1
	FROM cat_tipos_bascula_bitacora
	WHERE TipoBasculaBitacoraId = 12
)
BEGIN
	INSERT INTO cat_tipos_bascula_bitacora
	SELECT 12,'Cancelación Producto PV',GETDATE()
END
GO


IF NOT EXISTS (
	SELECT 1
	FROM cat_tipos_bascula_bitacora
	WHERE TipoBasculaBitacoraId = 13
)
BEGIN
	INSERT INTO cat_tipos_bascula_bitacora
	SELECT 13,'Cancelación Venta PV',GETDATE()
END
GO