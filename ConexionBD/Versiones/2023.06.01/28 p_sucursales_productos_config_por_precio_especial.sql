IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_sucursales_productos_config_por_precio_especial'
)
DROP PROC p_sucursales_productos_config_por_precio_especial
GO


-- p_sucursales_productos_config_por_precio_especial 7
CREATE PROC p_sucursales_productos_config_por_precio_especial
@PrecioEspecialId INT
AS

	SELECT PE.SucursalId,
		PED.ProductoId
	INTO #TMP_SUCURSALES_PRODUCTOS
	FROM doc_precios_especiales PE
	INNER JOIN doc_precios_especiales_detalle PED ON PED.PrecioEspeciaId = PE.Id AND
											(ISNULL(PED.PrecioEspecial,0) > 0 OR ISNULL(PED.MontoAdicional,0) > 0 OR PED.ProductoId = 1 OR PED.ProductoId = 2)
	WHERE PE.FechaVigencia >= GETDATE() AND
	PE.Id = @PrecioEspecialId


	DELETE cat_sucursales_productos
	FROM cat_sucursales_productos SP
	INNER JOIN #TMP_SUCURSALES_PRODUCTOS TMP ON TMP.SucursalId = SP.SucursalId

	INSERT INTO cat_sucursales_productos(SucursalId,ProductoId,CreadoEl)
	SELECT SucursalId,ProductoId,GETDATE()
	FROM #TMP_SUCURSALES_PRODUCTOS