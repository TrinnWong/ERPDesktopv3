IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_doc_productos_max_min_sel'
)
DROP PROC p_doc_productos_max_min_sel
GO

CREATE PROC p_doc_productos_max_min_sel
@pSucursalId INT
AS

	SELECT CalveProducto = P.Clave,
		MM.ProductoId,
		MM.SucursalId,
		Disponible = ISNULL(PE.Disponible,0),
		Maximo = ISNULL(MM.Maximo,0),
		Minimo = ISNULL(MM.Minimo,0),
		Solicitar = ISNULL(MM.Minimo,0) - ISNULL(PE.Disponible,0),
		Producto = P.Descripcion
	FROM doc_productos_max_min MM
	INNER JOIN cat_productos P ON P.ProductoId = MM.ProductoId
	LEFT JOIN cat_productos_existencias PE ON PE.ProductoId = MM.ProductoId AND
									PE.SucursalId = MM.SucursalId AND
									ISNULL(MM.Minimo,0) > 0
	WHERE MM.SucursalId = @pSucursalId  AND
	ISNULL(MM.Minimo,0) - ISNULL(PE.Disponible,0) > 0