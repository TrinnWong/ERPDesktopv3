IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE NAME = 'p_doc_pedidos_orden_total_upd'
)
DROP PROC p_doc_pedidos_orden_total_upd
GO
CREATE PROC p_doc_pedidos_orden_total_upd
@pPedidoId INT
AS
BEGIN
	DECLARE @total MONEY

	SELECT @total = ISNULL(SUM(Total),0)
	FROM doc_pedidos_orden_detalle
	WHERE PedidoId = @pPedidoId AND
	ISNULL(Cancelado,0)= 0

	UPDATE doc_pedidos_orden
	SET Total = @total
	WHERE PedidoId = @pPedidoId

END