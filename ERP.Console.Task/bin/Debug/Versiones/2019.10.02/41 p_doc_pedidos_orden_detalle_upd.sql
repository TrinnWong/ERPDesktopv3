if exists (
	select 1
	from sysobjects
	where name = 'p_doc_pedidos_orden_detalle_upd'
)
drop proc p_doc_pedidos_orden_detalle_upd
go
create proc p_doc_pedidos_orden_detalle_upd
@pPedidoDetalleId int,
@pCantidad decimal(14,3),
@pImpreso bit
as

	update doc_pedidos_orden_detalle
	set Impreso = @pImpreso,
		Cantidad = @pCantidad
	where PedidoDetalleId = @pPedidoDetalleId