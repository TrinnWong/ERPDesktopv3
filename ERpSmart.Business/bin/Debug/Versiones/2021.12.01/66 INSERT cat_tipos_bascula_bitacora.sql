IF NOT EXISTS (
	SELECT 1
	FROM cat_tipos_bascula_bitacora
	WHERE TipoBasculaBitacoraId = 4
)
BEGIN
	INSERT INTO cat_tipos_bascula_bitacora
	SELECT 4,'Indefinido',GETDATE()
END
GO
IF NOT EXISTS (
	SELECT 1
	FROM cat_tipos_bascula_bitacora
	WHERE TipoBasculaBitacoraId = 5
)
BEGIN
	INSERT INTO cat_tipos_bascula_bitacora
	SELECT 5,'Pedido Mayoreo',GETDATE()
END
GO
IF NOT EXISTS (
	SELECT 1
	FROM cat_tipos_bascula_bitacora
	WHERE TipoBasculaBitacoraId = 6
)
BEGIN
	INSERT INTO cat_tipos_bascula_bitacora
	SELECT 6,'Producto Sobrante',GETDATE()
END
GO
IF NOT EXISTS (
	SELECT 1
	FROM cat_tipos_bascula_bitacora
	WHERE TipoBasculaBitacoraId = 7
)
BEGIN
	INSERT INTO cat_tipos_bascula_bitacora
	SELECT 7,'Traspasos',GETDATE()
END
GO


IF NOT EXISTS (
	SELECT 1
	FROM cat_tipos_bascula_bitacora
	WHERE TipoBasculaBitacoraId = 8
)
BEGIN
	INSERT INTO cat_tipos_bascula_bitacora
	SELECT 8,'Cortesía',GETDATE()
END
GO


IF NOT EXISTS (
	SELECT 1
	FROM cat_tipos_bascula_bitacora
	WHERE TipoBasculaBitacoraId = 9
)
BEGIN
	INSERT INTO cat_tipos_bascula_bitacora
	SELECT 9,'Entrada Inventario',GETDATE()
END
GO


IF NOT EXISTS (
	SELECT 1
	FROM cat_tipos_bascula_bitacora
	WHERE TipoBasculaBitacoraId = 10
)
BEGIN
	INSERT INTO cat_tipos_bascula_bitacora
	SELECT 10,'Salida Inventario',GETDATE()
END
GO