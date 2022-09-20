IF NOT EXISTS (
	SELECT 1
	FROM cat_tipos_bascula_bitacora
	WHERE TipoBasculaBitacoraId = 15
)
BEGIN
	INSERT INTO cat_tipos_bascula_bitacora
	SELECT 15,'Venta Mayoreo por Pagar',GETDATE()
END
GO