IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_doc_aceptaciones_sucursal_grd'
)
DROP PROC p_doc_aceptaciones_sucursal_grd
GO
-- select * from doc_inv_movimiento
-- p_doc_aceptaciones_sucursal_grd 1070
CREATE PROC p_doc_aceptaciones_sucursal_grd
@pMovimientoId INT
AS


	SELECT AD.Id,
			ID.MovimientoId,
		   ID.MovimientoDetalleId,
		   p.ProductoId,
		   Producto = P.Descripcion,
		   CantidadMovimiento = ID.Cantidad,
		   CantidadReal = AD.CantidadReal,
		   AD.MovimientoDetalleAjusteId
	FROM doc_inv_movimiento I
	INNER JOIN doc_inv_movimiento_detalle ID ON ID.MovimientoId = I.MovimientoId
	INNER JOIN cat_productos P ON P.ProductoId = ID.ProductoId
	LEFT JOIN doc_aceptaciones_sucursal_detalle AD ON AD.MovimientoDetalleId = ID.MovimientoDetalleId
	WHERE I.MovimientoId = @pMovimientoId

