IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_doc_productos_max_min_grd'
)
DROP PROC p_doc_productos_max_min_grd
GO
-- p_doc_productos_max_min_grd 1,1
CREATE PROC p_doc_productos_max_min_grd
@pSucursalId INT,
@pSoloAsignadasSucursal BIT=0
AS

	SELECT SucursalId = @pSucursalId,
		Sucursal = S.NombreSucursal,
		P.ProductoId,
		P.Clave,
		P.Descripcion,
		Maximo = ISNULL(PMM.Maximo,0),
		Minimo = ISNULL(PMM.Minimo,0)
	FROM cat_productos P
	INNER JOIN cat_sucursales S ON S.Clave = @pSucursalId
	LEFT JOIN doc_productos_max_min PMM ON PMM.ProductoId = P.ProductoId AND
											PMM.SucursalId = S.Clave
	LEFT JOIN cat_sucursales_productos SP ON SP.SucursalId = S.Clave AND
											SP.ProductoId = P.ProductoId
	WHERE (@pSoloAsignadasSucursal = 1 AND SP.ProductoId IS NOT NULL )
	OR @pSoloAsignadasSucursal = 0

	