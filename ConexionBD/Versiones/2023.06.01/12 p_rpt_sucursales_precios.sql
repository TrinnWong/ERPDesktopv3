IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_rpt_sucursales_precios'
)
DROP PROC p_rpt_sucursales_precios
GO

-- p_rpt_sucursales_precios 0,1
CREATE PROC p_rpt_sucursales_precios
@pSucursalId INT,
@pUsuarioId INT
AS


	SELECT
		Id = CAST(ROW_NUMBER() OVER(ORDER BY S.Clave ASC) AS INT),
		SucursalId = S.Clave,
		Sucursal = S.NombreSucursal,
		ProductoId = P.ProductoId,
		Producto = P.Descripcion,
		Precio = CASE WHEN ISNULL(PED.PrecioEspecial,0) > 0 THEN ISNULL(PED.PrecioEspecial,0) ELSE ISNULL(PP.Precio,0) END
	from cat_sucursales S
	INNER JOIN cat_usuarios_sucursales US ON US.SucursalId = s.Clave AND
										US.UsuarioId = @pUsuarioId AND
										@pSucursalId in(0,s.Clave)
	INNER JOIN cat_productos P ON P.Empresa = S.Empresa
	INNER JOIN cat_productos_precios PP ON PP.IdProducto = P.ProductoId AND
										PP.IdPrecio = 1
	LEFT JOIN doc_precios_especiales PE ON PE.SucursalId = S.Clave
	LEFT JOIN doc_precios_especiales_detalle PED ON PED.ProductoId = P.ProductoId AND
													PED.PrecioEspeciaId  = PE.Id
	ORDER BY S.NombreSucursal, p.Descripcion