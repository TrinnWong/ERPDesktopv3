IF  EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_rpt_bascula_bitacora'
)
DROP PROC p_rpt_bascula_bitacora
GO

-- p_rpt_bascula_bitacora 0
create proc p_rpt_bascula_bitacora
@pFechaIni DateTime,
@pFechaFin DateTime,
@pSucursalId int
as
BEGIN

	select	
			B.Id,
			B.BasculaId,
			Bascula = BA.Alias,
			Sucursal = SUC.NombreSucursal,
			Cantidad = B.Cantidad,
			Fecha = B.Fecha,
			TipoMovimiento = ISNULL(t.Nombre,'INDEFINIDO'),
			ClaveProducto = P.Clave,
			Producto = P.Descripcion
	from doc_basculas_bitacora B
	INNER JOIN cat_basculas BA ON BA.BasculaId = B.BasculaId
	
	INNER JOIN cat_sucursales SUC ON SUC.Clave = B.SucursalId
	LEFT JOIN cat_tipos_bascula_bitacora T ON T.TipoBasculaBitacoraId = B.TipoBasculaBitacoraId
	LEFT JOIN cat_productos P ON P.ProductoId = B.ProductoId
	WHERE @pSucursalId in ( 0,B.SucursalId) AND
	CONVERT(VARCHAR,B.Fecha,112) BETWEEN CONVERT(VARCHAR,@pFechaIni,112) AND CONVERT(VARCHAR,@pFechaFin,112)
	ORDER BY B.Fecha DESC
END