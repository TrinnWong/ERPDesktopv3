IF  EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_doc_precios_especiales_grd'
)
DROP PROC p_doc_precios_especiales_grd
GO

-- p_doc_precios_especiales_grd 1,'COLA',0
CREATE PROC p_doc_precios_especiales_grd
@pPrecioEspecialId INT,
@pBuscar varchar(250),
@pSoloConPrecioEspecial BIT
AS

	SELECT 
		PrecioEspecialId = PE.Id,
		PrecioEspecialDetalleId = ped.Id,
		PE.Id,
		p.ProductoId,
		p.Clave,
		Producto = p.Descripcion,
		Familia = f.Descripcion,
		PrecioVenta = PP.Precio,
		PED.PrecioEspecial,
		PED.MontoAdicional,
		PrecioEspecialFinal = CASE WHEN ISNULL(PED.PrecioEspecial,0) > 0 THEN ISNULL(PED.PrecioEspecial,0)
								WHEN ISNULL(PED.MontoAdicional,0) > 0 THEN ISNULL(PP.Precio,0) + ISNULL(PED.MontoAdicional,0)
								ELSE PP.Precio
							END							   
	FROM cat_productos p
	INNER JOIN cat_familias f on f.Clave = p.ClaveFamilia
	INNER JOIN cat_productos_precios PP ON PP.IdProducto = p.ProductoId AND
											PP.IdPrecio = 1
	LEFT JOIN  doc_precios_especiales PE ON PE.Id = @pPrecioEspecialId 
	LEFT JOIN doc_precios_especiales_detalle PED ON PED.PrecioEspeciaId = PE.Id AND
											PED.ProductoId = p.ProductoId 
	WHERE p.Estatus = 1 AND
	((p.Descripcion LIKE '%'+RTRIM(@pBuscar)+'%' OR @pBuscar = '') OR
	(f.Descripcion LIKE '%'+RTRIM(@pBuscar)+'%' OR @pBuscar = '')) AND
	(
		@pSoloConPrecioEspecial = 0	OR 
		(PED.Id IS NOT NULL AND @pSoloConPrecioEspecial = 1)
	) 