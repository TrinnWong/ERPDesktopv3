---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
ALTER PROC p_producto_precio_especial_vigente
@pProductoId INT,
@pSucursalId INT=0
AS

	SELECT PED.*
	FROM doc_precios_especiales_detalle PED
	INNER JOIN doc_precios_especiales PE ON PE.Id = PED.PrecioEspeciaId AND
								PE.FechaVigencia > GETDATE()
	WHERE PED.ProductoId = @pProductoId  AND
	PE.SucursalId = @pSucursalId

