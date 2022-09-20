if exists (
	select 1
	from sysobjects
	where name = 'p_doc_pedidos_orden_detalle_del'
)
drop proc p_doc_pedidos_orden_detalle_del
go

create proc p_doc_pedidos_orden_detalle_del
@pPedidoDetalleId int
as

	--begin tran

	--delete [dbo].[doc_pedidos_orden_adicional]
	--where PedidoDetalleId = @pPedidoDetalleId

	--if @@error <> 0
	--begin
	--	rollback tran
	--	goto fin

	--end

	--delete [dbo].[doc_pedidos_orden_ingre]
	--where PedidoDetalleId = @pPedidoDetalleId

	--if @@error <> 0
	--begin
	--	rollback tran
	--	goto fin

	--end

	--delete [dbo].[doc_pedidos_orden_detalle]
	--where PedidoDetalleId = @pPedidoDetalleId

	update doc_pedidos_orden_detalle
	set Cantidad = 0,
		Cancelado = 1,		
		Descuento = 0,
		Impuestos = 0,
		Total = 0
	where PedidoDetalleId = @pPedidoDetalleId

	
	--if @@error <> 0
	--begin
	--	rollback tran
	--	goto fin

	--end



	--commit tran
	fin:

