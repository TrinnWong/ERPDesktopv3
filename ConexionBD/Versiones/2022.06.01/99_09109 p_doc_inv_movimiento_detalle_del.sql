IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'p_doc_inv_movimiento_detalle_del'
)
DROP PROC  dbo.p_doc_inv_movimiento_detalle_del
GO

CREATE PROC dbo.p_doc_inv_movimiento_detalle_del
@pMovimientoId INT
AS

	DELETE doc_inv_movimiento_detalle
	WHERE MovimientoId = @pMovimientoId