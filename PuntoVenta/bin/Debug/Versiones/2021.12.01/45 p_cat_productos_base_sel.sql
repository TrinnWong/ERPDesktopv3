if  exists (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_cat_productos_base_sel'
)
DROP PROC p_cat_productos_base_sel
GO
-- p_cat_productos_base_sel 5
CREATE PROC p_cat_productos_base_sel
@ProductoId INT
as

	SELECT 
		PB.ProductoMateriaPrimaId,
		P.ProductoId,
		Producto = P.DescripcionCorta,
		PB.ProductoBaseId,
		ProductoBase = P2.DescripcionCorta,		
		PB.Cantidad,
		UnidadId = PB.UnidadCocinaId,
		Unidad = U.DescripcionCorta,
		ProduccionPorUnidadMP = CASE WHEN PB.Cantidad > 0 THEN 1 / PB.Cantidad ELSE 0 END
	FROM cat_productos_base PB
	INNER JOIN cat_productos P ON P.ProductoId = PB.ProductoId
	INNER JOIN cat_productos P2 ON P2.ProductoId = PB.ProductoBaseId
	INNER JOIN cat_unidadesmed U ON U.Clave = PB.UnidadCocinaId
	WHERE P.ProductoId = @ProductoId