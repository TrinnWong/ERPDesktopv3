if exists (
	select 1
	from sysobjects
	where name = 'p_doc_pedidos_orden_adicional_del'
)
drop proc p_doc_pedidos_orden_adicional_del
go
create proc p_doc_pedidos_orden_adicional_del
@pPedidoDetalleId int
as


	delete [dbo].[doc_pedidos_orden_adicional]
	where PedidoDetalleId = @pPedidoDetalleId