IF EXISTS (
	SELECT 1
	FROM SYSOBJECTS
	WHERE name = 'p_doc_pedidos_orden_detalle_cargo_upd'
)
DROP PROC p_doc_pedidos_orden_detalle_cargo_upd
GO
CREATE PROC p_doc_pedidos_orden_detalle_cargo_upd
@pPedidoId INT,
@pPorcentaje decimal(14,2)
AS
BEGIN

	update doc_pedidos_orden_detalle
	set CargoAdicionalMonto = (Cantidad * PrecioUnitario) * (ISNULL(@pPOrcentaje,0)/100)
	WHERE PedidoId = @pPedidoId

	update doc_pedidos_orden_detalle
	set Total = (Cantidad * PrecioUnitario) +  CargoAdicionalMonto
	WHERE PedidoId = @pPedidoId

	update doc_pedidos_orden
	SET Total = (SELECT SUM(Total) FROM doc_pedidos_orden_detalle WHERE PedidoId = @pPedidoId AND Activo = 1)
	where PedidoId = @pPedidoId
END