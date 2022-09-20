

IF NOT EXISTS (
	SELECT 1
	FROM cat_tipos_bascula_bitacora
	WHERE TipoBasculaBitacoraId = 11
)
BEGIN
	INSERT INTO cat_tipos_bascula_bitacora
	SELECT 11,'Desperdicio de Inventario',GETDATE()
END
GO