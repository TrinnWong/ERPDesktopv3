if  EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_doc_inventario_captura_grd'
)
DROP PROC p_doc_inventario_captura_grd
go
CREATE PROC p_doc_inventario_captura_grd
@pSucursalId INT
AS

	SELECT P.Clave,
	P.CodigoBarras,
	P.Descripcion,
	ConteoInv = SUM(IC.Cantidad),
	ExistenciaTeorica = max(PE.ExistenciaTeorica),
	Cerrado = cast(ISNULL(IC.Cerrado,0) as bit)
	FROM doc_inventario_captura IC
	INNER JOIN cat_productos P ON P.ProductoId = ic.ProductoId
	INNER JOIN cat_productos_existencias PE ON PE.ProductoId = IC.ProductoId AND
										PE.SucursalId = IC.SucursalId
	WHERE IC.SucursalId = @pSucursalId
	GROUP BY P.Clave,
	P.CodigoBarras,
	P.Descripcion,
	IC.Cerrado