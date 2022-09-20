IF NOT EXISTS (
	SELECT 1
	FROM cat_tipos_bascula_bitacora
	WHERE TipoBasculaBitacoraId = 14
)
BEGIN
	INSERT INTO cat_tipos_bascula_bitacora
	SELECT 14,'Precio Empleado',GETDATE()
END
GO