IF  EXISTS (
	SELECT *
	FROM SYSOBJECTS
	WHERE NAME = 'p_producto_precio_especial_vigente'
)
DROP PROC p_producto_precio_especial_vigente
GO
CREATE PROC p_producto_precio_especial_vigente
@pProductoId INT
AS

	SELECT PED.*
	FROM doc_precios_especiales_detalle PED
	INNER JOIN doc_precios_especiales PE ON PE.Id = PED.PrecioEspeciaId AND
								PE.FechaVigencia > GETDATE()
	WHERE PED.ProductoId = @pProductoId 