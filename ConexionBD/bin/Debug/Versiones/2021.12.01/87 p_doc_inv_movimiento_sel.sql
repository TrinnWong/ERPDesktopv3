IF  EXISTS (
	SELECT 1
	 FROM SYSOBJECTS
	 WHERE NAME = 'p_doc_inv_movimiento_sel'
)
DROP PROC p_doc_inv_movimiento_sel
GO
CREATE PROC p_doc_inv_movimiento_sel
@pSucursalId INT,
@pFechaMovimiento DATETIME,
@pTipoMovimiento INT
AS

	SELECT *
	FROM doc_inv_movimiento
	WHERE SucursalId = @pSucursalId AND
	CONVERT(VARCHAR,FechaMovimiento,112) = CONVERT(VARCHAR,@pFechaMovimiento,112) AND
	TipoMovimientoId = @pTipoMovimiento